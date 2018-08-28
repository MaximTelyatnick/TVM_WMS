using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using S7.Net;
using TVM_WMS.BLL.Infrastructure.PlcWrapper;
using TVM_WMS.BLL.DTO.QueryDTO;
using TVM_WMS.BLL.BusinessLogicModule;
using TVM_WMS.BLL.Infrastructure.Logger;
using System.Windows.Forms;
using System.Threading;

namespace TVM_WMS.BLL.Infrastructure.WatchDog
{
    public class WatchDog
    {

        public class DataItemsWatchDog
        {
            public string Name { get; set; }
            public string Offset { get; set; }
            public string AbsoleteItemName { get; set; }
            public string CurrentValue { get; set; }
            public string LastUpdateTime { get; set; }

        };

        private List<DataItemsWatchDog> dataItemsWatchDogList { get; set; }

        private int currentDb { get; set; }
        private sbyte intervalCycler { get; set; }
        private sbyte switchCounter { get; set; }
        private bool switchFlag { get; set; }
        private ISyncPlcDriver plcWatchDogDriver;

        public double interval { get; internal set; }

        public ConnectionStates connectionState { get { return plcWatchDogDriver != null ? plcWatchDogDriver.ConnectionState : ConnectionStates.Offline; } }

        

        System.Timers.Timer timerWatchDog = new System.Timers.Timer();

        private static readonly Lazy<WatchDog> _instance = new Lazy<WatchDog>(() => new WatchDog());

        public static WatchDog Instance
        {
            get
            {
               return _instance.Value;
            }
        }

        public void Connect(CpuType cpu, string ipAddress, short rack, short slot)
        {
            Logger.Logger.InitLogger();

            try
            {
                plcWatchDogDriver = new S7NetPlcDriver(cpu, ipAddress, rack, slot);
                plcWatchDogDriver.Connect();

                switchFlag = false;
                intervalCycler = 0;
                switchCounter = 0;

                dataItemsWatchDogList = Initalize();

                Logger.Logger.Log.Debug("Инициализация таймера WatchDog" + currentDb);

                TimerStart();
            }
            catch (Exception ex)
            {
                Logger.Logger.Log.Debug("ошибка подключения WatchDog" + currentDb);

                TimerStop();

            }
            finally
            {

            }

        }

        public List<DataItemsWatchDog> Initalize()
        {
            List<DataItemsWatchDog> watchDogList = new List<DataItemsWatchDog>();
            watchDogList.AddRange(new List<DataItemsWatchDog>
                {
                    new DataItemsWatchDog()
                    {
                        Name = "WatchDogPLC",
                        AbsoleteItemName = (ConfigClass.Instance.GlobalLocalSettings.WatchDogDBName + "." + ConfigClass.Instance.GlobalLocalSettings.WatchDogPLCOffset).ToString(),
                        CurrentValue = "",
                        LastUpdateTime = "",
                        Offset = (ConfigClass.Instance.GlobalLocalSettings.WatchDogPLCOffset).ToString()
                    },
                    new DataItemsWatchDog()
                    {
                        Name = "WatchDogPC",
                        AbsoleteItemName = (ConfigClass.Instance.GlobalLocalSettings.WatchDogDBName + "." + ConfigClass.Instance.GlobalLocalSettings.WatchDogPCOffset).ToString(),
                        CurrentValue = "",
                        LastUpdateTime = "",
                        Offset = (ConfigClass.Instance.GlobalLocalSettings.WatchDogPCOffset).ToString() 
                    },
                });

            return watchDogList;
        }

        public void Disconnect()
        {
            if (plcWatchDogDriver == null || this.connectionState == ConnectionStates.Offline)
            {
                return;
            }

            TimerStop();

            plcWatchDogDriver.Disconnect();

            plcWatchDogDriver = null;

            
        }


        private void timerWatchDog_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (plcWatchDogDriver == null || plcWatchDogDriver.ConnectionState != ConnectionStates.Online)
            {
                MessageBox.Show("Соиденение разорвано c PLC(таймер WatchDog)!", "Тест соединения", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Logger.Logger.Log.Debug("Соиденение разорвано c PLC(таймер WatchDog)!" + currentDb);
                return;
            }

            timerWatchDog.Enabled = false;

            try
            {
                
                if (Convert.ToBoolean(dataItemsWatchDogList[0].CurrentValue))
                {

                    WriteTag(dataItemsWatchDogList[1].AbsoleteItemName, true);

                    Logger.Logger.Log.Debug("Получили true, записали true " + intervalCycler + " " + DateTime.Now.ToString("dd.MM.yyyy hh:mm:ss:fff"));

                    ++intervalCycler;

                    ++switchCounter;
                    
                }
                else
                {
                    WriteTag(dataItemsWatchDogList[1].AbsoleteItemName, false);

                    Logger.Logger.Log.Debug("Получили false, записали false " + intervalCycler + " " + DateTime.Now.ToString("dd.MM.yyyy hh:mm:ss:fff"));

                    --intervalCycler;

                    ++switchCounter;

                }

                if (switchCounter > 15)
                {
                    switchCounter = 0;
                    intervalCycler = 0;    
                }
            }
            finally
            {
                RefreshTags();

                if (intervalCycler > 5 || intervalCycler < -5)
                {
                    timerWatchDog.Enabled = false;
                    MessageBox.Show("Соиденение разорвано c PLC(таймер WatchDog)! Причина: не ответа контроллера.", "Тест соединения", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Logger.Logger.Log.Debug("Connection state " + connectionState + " " + DateTime.Now.ToString("dd.MM.yyyy hh:mm:ss:fff"));
                    Logger.Logger.Log.Debug("Соиденение разорвано c PLC(таймер WatchDog)! Причина: не ответа контроллера.");
                    plcWatchDogDriver.DisconnectVegetablePLC();
                }
                else
                {
                    Logger.Logger.Log.Debug("Connection state " + connectionState + " " + DateTime.Now.ToString("dd.MM.yyyy hh:mm:ss:fff"));

                    timerWatchDog.Enabled = true;
                    switchFlag = !switchFlag;
                }
            }
        }

        public void TimerStart()
        {

            timerWatchDog.Interval = 500; 
            timerWatchDog.Elapsed += timerWatchDog_Elapsed;
            timerWatchDog.Enabled = true;

            RefreshTags();

            timerWatchDog.Start();

            Logger.Logger.Log.Debug("Запустили таймер WatchDog, текущая БД №" + currentDb);
        }

        public void TimerStop()
        {
            
            timerWatchDog.Stop();

            Logger.Logger.Log.Debug("Остановили таймер WatchDog, текущая БД №" + currentDb);
        }

        

        public void WriteTag(string varAlias, object varValue)
        {
            plcWatchDogDriver.WriteItem(varAlias, varValue);
        }

        private void RefreshTags()
        {
            if (dataItemsWatchDogList != null && plcWatchDogDriver != null)
            {
                for (int i = 0; i < dataItemsWatchDogList.Count; i++)
                {
                    var value = plcWatchDogDriver.ReadVar(dataItemsWatchDogList[i].AbsoleteItemName);
                    dataItemsWatchDogList[i].CurrentValue = (value != null) ? ((bool)value).ToString() : "<Данные не получены>";
                    dataItemsWatchDogList[i].LastUpdateTime = DateTime.Now.ToLongTimeString();

                }
            }
        }


    }
}
