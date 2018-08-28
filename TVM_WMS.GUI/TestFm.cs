using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using TVM_WMS.BLL.BusinessLogicModule;
using System.IO;
using TVM_WMS.BLL.DTO;
using TVM_WMS.BLL.Interfaces;
using Ninject;
using TVM_WMS.BLL.Infrastructure.PlcWrapper;
using TVM_WMS.BLL.Infrastructure.SerialPortListener;
using TVM_WMS.BLL.DTO.QueryDTO;
using System.Threading;
using TVM_WMS.BLL.Infrastructure.Logger;
using TVM_WMS.BLL.Infrastructure.WatchDog;

namespace TVM_WMS.GUI
{
    public partial class TestFm : DevExpress.XtraEditors.XtraForm
    {
        private IStoreNamesService storeNameService;
        private IWareHousesService wareHouseService;
        private IMaterialsService materialService;
        private IStorageGroupZonesService storageGroupZoneService;

        private BindingSource dataItemBS = new BindingSource();
        private BindingSource windowItemBS = new BindingSource();

        private SerialPortManager _spManager;
        private PLC plc;

        private List<DataItemsQueryDTO> tagList = new List<DataItemsQueryDTO>();
        private List<StoreNamesDTO> storeNamesList;
        private List<StoreNamesDTO> rowNamesList;
        private List<ConfigClass.BindedWindowItem> windowsCurrentRowList;
        private List<ConfigClass.BindedWindowItem> bindedWindowItemList;

        private List<Int32?> cellRange;

        private Utils.ProcessInfo processInfo = new Utils.ProcessInfo();

        private int plcDeviceId = -1;
        private int storehouseRowId;
        private int storehouseId;
        private int windowId;
        private int _interval;

        private Utils.ProcessComand command;

        public TestFm()
        {
            InitializeComponent();

            Logger.InitLogger();

            Logger.Log.Debug("Запуск формы 'Тестирование'");

            storeNameService = Program.kernel.Get<IStoreNamesService>();

            if (storeNameService.GetBindedStoreNames().ToList().Count != 0)
            {
                storeNamesList = storeNameService.GetBindedStoreNames().ToList();
                storeNameEdit.Properties.DataSource = storeNamesList;
                storeNameEdit.Properties.ValueMember = "StoreNameId";
                storeNameEdit.Properties.DisplayMember = "Name";
                SetDeviceIndicators(Utils.DeviceIndication.Offline, 1, Utils.StatusWindow.WindowNotBusy);
            }
            else
            {
                SetDeviceIndicators(Utils.DeviceIndication.Disabled, 1, Utils.StatusWindow.WindowNotBusy);
            }


            if (ConfigClass.Instance.BarcodeSettingList.Select(s => new { s.DeviceId, s.Name }).Distinct().ToList().Count != 0)
            {
                scannerEdit.Properties.DataSource = ConfigClass.Instance.BarcodeSettingList.Select(s => new { s.DeviceId, s.Name }).Distinct().ToList();
                scannerEdit.Properties.ValueMember = "DeviceId";
                scannerEdit.Properties.DisplayMember = "Name";
                SetDeviceIndicators(Utils.DeviceIndication.Offline, 2, Utils.StatusWindow.WindowNotBusy);
            }
            else
            {
                SetDeviceIndicators(Utils.DeviceIndication.Disabled, 2, Utils.StatusWindow.WindowNotBusy);
            }

            if (WatchDog.Instance.connectionState == ConnectionStates.Online)
                SetDeviceIndicators(Utils.DeviceIndication.Connected, 3, Utils.StatusWindow.WindowMissing);
            else
                SetDeviceIndicators(Utils.DeviceIndication.Offline, 3, Utils.StatusWindow.WindowMissing);

            //if (WatchDog.Instance.connectionState == ConnectionStates.Online)
            //{

            //}

        }

        #region Connect PLC

        private bool ConnectPlc(int plcDeviceId)
        {
            var plcSource = (ConfigClass.PlcSettingSource)ConfigClass.Instance.PlcSettingList.FirstOrDefault(s => s.DeviceId == plcDeviceId);
            var cpu = plcSource.CpuType;

            windowId = (int)windowEdit.EditValue;

            var currentWindow = ConfigClass.Instance.DeviceBindingSettingList.FirstOrDefault(s => s.StoreNameParentId == storehouseId && s.TypeName == "DropoffWindow" && s.Id == windowId);

            var bindDbItem = ConfigClass.Instance.DeviceBindingSettingList.FirstOrDefault(s => s.StoreNameParentId == storehouseId && s.TypeName == "DB" && s.ParentId == currentWindow.Id);

            plc = new PLC();
            plc.Connect(cpu, plcSource.Ip, plcSource.Rack, plcSource.Slot);


            if (plc.ConnectionState == ConnectionStates.Online)
            {

                plc.CurrentDb = Int32.Parse(ConfigClass.Instance.DeviceSettingsList.First(s => s.DeviceId == bindDbItem.DeviceId && s.KindName == "DataBlockIndex").SettingValue);
                _interval = Int32.Parse(ConfigClass.Instance.DeviceSettingsList.First(s => s.DeviceId == bindDbItem.DeviceId && s.KindName == "Interval").SettingValue);
                plc.Interval = Convert.ToDouble((int)TimeSpan.FromSeconds(_interval).TotalMilliseconds);

                tagList = ConfigClass.Instance.DataItemList.Where(s => s.DeviceId == bindDbItem.DeviceId).ToList();

                plc.TimerStart(tagList);

                startTimer();

                return true;
            }
            else
            {
                MessageBox.Show("Ошибка при соединении!", "Cоединение с контроллером PLC", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }

        }

        private void DisconnectPLC()
        {
            if (plc != null)
            {

                plc.Disconnect();
                dataItemBS.DataSource = null;

            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            tagList = plc.Return();

            plcVarGridView.BeginDataUpdate();

            dataItemBS.DataSource = tagList;
            plcVarGrid.DataSource = tagList;

            plcVarGridView.EndDataUpdate();
        }

        #endregion

        #region Connect barcode scanner

        private bool ConnectBarcode()
        {
            bool result = false;

            if (scannerEdit.EditValue != null)
            {
                try
                {
                    if (_spManager != null)
                        _spManager.StopListening();

                    var scannerItem = ConfigClass.Instance.BarcodeSettingList.First(s => s.DeviceId == (int)scannerEdit.EditValue);
                    _spManager = new SerialPortManager(scannerItem);

                    _spManager.NewSerialDataRecieved += new EventHandler<SerialDataEventArgs>(_spManager_NewSerialDataRecieved);

                    _spManager.StartListening();

                    result = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при соединении! \n" + ex.Message + "\nПроверьте настройки оборудования.", "Тест соединения", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    _spManager.NewSerialDataRecieved -= new EventHandler<SerialDataEventArgs>(_spManager_NewSerialDataRecieved);

                    result = false;
                }
            }
            else
                MessageBox.Show("Сканер не выбран. Воспользуйтесь списком для выбора. ", "Поключение устройств", MessageBoxButtons.OK, MessageBoxIcon.Information);

            return result;
        }

        private void DisconnectBarcode()
        {
            if (_spManager != null)
            {
                _spManager.NewSerialDataRecieved -= new EventHandler<SerialDataEventArgs>(_spManager_NewSerialDataRecieved);
                _spManager.StopListening();
            }
        }

        private void scannerEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                scannerEdit.Properties.DataSource = ConfigClass.Instance.BarcodeSettingList.Select(s => new { s.DeviceId, s.Name }).Distinct().ToList();
                scannerEdit.EditValue = null;
            }
        }

        private void _spManager_NewSerialDataRecieved(object sender, SerialDataEventArgs e)
        {
            if (this.InvokeRequired)
            {
                // Using this.Invoke causes deadlock when closing serial port, and BeginInvoke is good practice anyway.
                this.BeginInvoke(new EventHandler<SerialDataEventArgs>(_spManager_NewSerialDataRecieved), new object[] { sender, e });
                return;
            }

            string str = Encoding.UTF8.GetString(e.Data);

            barcodeTestTBox.Text = str;

            BarcodeParseOperation(str);
        }

        private void BarcodeParseOperation(string source)
        {
            if (source.Substring(0, 1) == "*")
            {
                var bcSourceStr = source.Replace("\r", "").Split('*');

                if (bcSourceStr[0] == "1")
                {
                    switch (bcSourceStr[1])
                    {
                        //ПЕРЕВЫБРАТЬ КАССЕТУ
                        case "2":
                            try
                            {
                                ChangeCell();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("При выполнении опеации возникла ошибка.\n" + ex.Message, "Выполнение операции", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            break;
                        //ЗАДВИНУТЬ КАССЕТУ С ПРИЗНАКОМ ЗАПОЛНЕНИЯ, ЗАДВИНУТЬ КАССЕТУ С ПРИЗНАКОМ ДОГРУЗКИ
                        case "3":
                        case "4":
                            try
                            {
                                //CloseCell();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("При выполнении опеации возникла ошибка.\n" + ex.Message, "Выполнение операции", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            break;
                        //ОТМЕНИТЬ ОПЕРАЦИЮ
                        case "5":
                            try
                            {
                                //CancelOperation();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("При выполнении опеации возникла ошибка.\n" + ex.Message, "Выполнение операции", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            break;
                    }
                }
            }
        }

        private List<AlarmsDTO> AlarmsList(string alarmString)
        {
            var alarmList = Split(alarmString, 3)  // делим alarmString на части по 3
           .Select(s => new AlarmsDTO { AlarmNumber = Int32.Parse(s.PadLeft(2, '0')), Id = 0 })
           .ToList();

            var listText = ConfigClass.Instance.AlarmList;

            List<AlarmsDTO> errors = (from l in alarmList
                                      join a in listText on l.AlarmNumber equals a.AlarmNumber into ro
                                      from a in ro.DefaultIfEmpty()
                                      select new AlarmsDTO
                                      {
                                          AlarmNumber = a.AlarmNumber,
                                          AlarmText = a.AlarmText,
                                          Id = a.Id
                                      }).ToList();
            return errors;
        }

        IEnumerable<string> Split(string s, int size, bool fixedSize = true)
        {
            var sr = new StringReader(s);
            return Split(sr, size, fixedSize);
        }

        IEnumerable<string> Split(TextReader sr, int size, bool fixedSize = true)
        {
            while (sr.Peek() >= 0)
            {
                var buffer = new char[size];
                var c = sr.ReadBlock(buffer, 0, size);
                yield return fixedSize ? new String(buffer) : new String(buffer, 0, c);
            }
        }

        #endregion

        #region Method's

        private void SetDeviceIndicators(Utils.DeviceIndication status, int deviceIndex, Utils.StatusWindow windowStatus) // 1 - PLC, 2 - Barcode, 3 - PLC (watchDog)
        {
            switch (status)
            {
                case Utils.DeviceIndication.Connected:
                    switch (deviceIndex)
                    {
                        case 1:
                            switch (windowStatus)
                            {
                                case Utils.StatusWindow.WindowNotBusy:
                                    plcImageEdit.EditValue = indicatorCollection.Images[6];
                                    openPlcDeviceBtn.Enabled = false;
                                    closePlcDeviceBtn.Enabled = true;
                                    resetVarBtn.Enabled = true;
                                    storeNameEdit.Enabled = false;
                                    storeRowEdit.Enabled = false;
                                    setOpenBtn.Enabled = true;
                                    setCloseBtn.Enabled = false;
                                    resetVarBtn.Enabled = true;
                                    numberCellTBox.Enabled = true;

                                    Logger.Log.Debug("PLC устройство подключено! Окно не занято.");
                                    logMessageEdit.MaskBox.AppendText(DateTime.Now + " PLC устройство подключено! Окно не занято." + Environment.NewLine);

                                    break;
                                case Utils.StatusWindow.WindowBusy:
                                    plcImageEdit.EditValue = indicatorCollection.Images[6];
                                    openPlcDeviceBtn.Enabled = false;
                                    closePlcDeviceBtn.Enabled = true;
                                    resetVarBtn.Enabled = true;
                                    storeNameEdit.Enabled = false;
                                    storeRowEdit.Enabled = false;
                                    setOpenBtn.Enabled = false;
                                    setCloseBtn.Enabled = true;
                                    resetVarBtn.Enabled = true;
                                    numberCellTBox.Enabled = false;

                                    Logger.Log.Debug("PLC устройство подключено! Окно занято.");
                                    logMessageEdit.MaskBox.AppendText(DateTime.Now + " PLC устройство подключено! Окно занято." + Environment.NewLine);

                                    break;
                            }
                            break;
                        case 2:
                            barcodeImageEdit.EditValue = indicatorCollection.Images[2];
                            openBarcodeDeviceBtn.Enabled = false;
                            closeBarcodeDeviceBtn.Enabled = true;
                            refreshSpin.Enabled = false;

                            Logger.Log.Debug("Сканер штрихкодов подключен!");
                            logMessageEdit.MaskBox.AppendText(DateTime.Now + " Сканер штрихкодов подключен!" + Environment.NewLine);

                            break;

                        case 3:

                            plcSyncImageEdit.EditValue = indicatorCollection.Images[6];
                            openPlcSyncBtn.Enabled = false;
                            closePlcSyncBtn.Enabled = true;
                            //refreshSpin.Enabled = false;

                            Logger.Log.Debug(" PLC устройство (WatchDog) подключено!");
                            logMessageEdit.MaskBox.AppendText(DateTime.Now + " PLC устройство (WatchDog) подключено!" + Environment.NewLine);

                            break;

                    }
                    break;
                case Utils.DeviceIndication.Loaded:
                    switch (deviceIndex)
                    {
                        case 1:
                            plcImageEdit.EditValue = indicatorCollection.Images[7];
                            break;

                        case 2:
                            barcodeImageEdit.EditValue = indicatorCollection.Images[3];
                            break;

                        case 3:
                            plcSyncImageEdit.EditValue = indicatorCollection.Images[7];
                            break;

                    }
                    break;    

                case Utils.DeviceIndication.Disabled:
                    switch (deviceIndex)
                    {
                        case 1:
                            switch (windowStatus)
                            {
                                case Utils.StatusWindow.WindowNotBusy:
                                    plcImageEdit.EditValue = indicatorCollection.Images[4];
                                    openPlcDeviceBtn.Enabled = true;
                                    closePlcDeviceBtn.Enabled = false;
                                    storeNameEdit.Enabled = true;
                                    storeRowEdit.Enabled = true;
                                    setOpenBtn.Enabled = false;
                                    setCloseBtn.Enabled = false;
                                    resetVarBtn.Enabled = false;

                                    Logger.Log.Debug("PLC устройство не найдено! Окно не занято.");
                                    logMessageEdit.MaskBox.AppendText(DateTime.Now + " PLC устройство не найдено! Окно не занято." + Environment.NewLine);

                                    break;
                                case Utils.StatusWindow.WindowBusy:
                                    plcImageEdit.EditValue = indicatorCollection.Images[4];
                                    openPlcDeviceBtn.Enabled = true;
                                    closePlcDeviceBtn.Enabled = false;
                                    storeNameEdit.Enabled = true;
                                    storeRowEdit.Enabled = true;
                                    setOpenBtn.Enabled = false;
                                    setCloseBtn.Enabled = false;
                                    resetVarBtn.Enabled = false;

                                    Logger.Log.Debug("PLC устройство не найдено! Окно занято.");
                                    logMessageEdit.MaskBox.AppendText(DateTime.Now + " PLC устройство не найдено! Окно занято." + Environment.NewLine);

                                    break;
                            }
                            break;
                        case 2:
                            barcodeImageEdit.EditValue = indicatorCollection.Images[0];
                            openBarcodeDeviceBtn.Enabled = true;
                            closeBarcodeDeviceBtn.Enabled = false;
                            refreshSpin.Enabled = true;

                            Logger.Log.Debug("Устройство сканер не найдено!");
                            logMessageEdit.MaskBox.AppendText(DateTime.Now + " Устройство сканер не найдено!" + Environment.NewLine);

                            break;
                        case 3:
                            plcSyncImageEdit.EditValue = indicatorCollection.Images[4];
                            openPlcSyncBtn.Enabled = true;
                            closePlcSyncBtn.Enabled = false;

                            Logger.Log.Debug(" PLC устройство (WatchDog) не найдено!");
                            logMessageEdit.MaskBox.AppendText(DateTime.Now + " PLC устройство (WatchDog) не найдено!" + Environment.NewLine);

                            break;
                    }
                    break;

                case Utils.DeviceIndication.Offline:
                    switch (deviceIndex)
                    {
                        case 1:
                            switch (windowStatus)
                            {
                                case Utils.StatusWindow.WindowNotBusy:
                                    plcImageEdit.EditValue = indicatorCollection.Images[5];
                                    openPlcDeviceBtn.Enabled = true;
                                    closePlcDeviceBtn.Enabled = false;
                                    storeNameEdit.Enabled = true;
                                    storeRowEdit.Enabled = true;
                                    setOpenBtn.Enabled = false;
                                    setCloseBtn.Enabled = false;
                                    resetVarBtn.Enabled = false;

                                    Logger.Log.Debug("PLC устройство отключено! Окно не занято");
                                    logMessageEdit.MaskBox.AppendText(DateTime.Now + " PLC устройство отключено!" + Environment.NewLine);

                                    break;
                                case Utils.StatusWindow.WindowBusy:
                                    plcImageEdit.EditValue = indicatorCollection.Images[5];
                                    openPlcDeviceBtn.Enabled = true;
                                    closePlcDeviceBtn.Enabled = false;
                                    storeNameEdit.Enabled = true;
                                    storeRowEdit.Enabled = true;
                                    setOpenBtn.Enabled = false;
                                    setCloseBtn.Enabled = false;
                                    resetVarBtn.Enabled = false;

                                    Logger.Log.Debug("PLC устройство отключено! Окно занято.");
                                    logMessageEdit.MaskBox.AppendText(DateTime.Now + " PLC устройство отключено! Окно занято." + Environment.NewLine);

                                    break;
                            }
                            break;
                        case 2:
                            barcodeImageEdit.EditValue = indicatorCollection.Images[1];
                            openBarcodeDeviceBtn.Enabled = true;
                            closeBarcodeDeviceBtn.Enabled = false;
                            refreshSpin.Enabled = true;

                            Logger.Log.Debug("Сканер штрихкодов отключен!");
                            logMessageEdit.MaskBox.AppendText(DateTime.Now + " Сканер штрихкодов отключен!" + Environment.NewLine);

                            break;
                        case 3:
                            plcSyncImageEdit.EditValue = indicatorCollection.Images[5];
                            openPlcSyncBtn.Enabled = true;
                            closePlcSyncBtn.Enabled = false;

                            Logger.Log.Debug(" PLC устройство (WatchDog) отключено!");
                            logMessageEdit.MaskBox.AppendText(DateTime.Now + " PLC устройство (WatchDog) отключено!" + Environment.NewLine);

                            break;
                    }
                    break;

                default:
                    switch (deviceIndex)
                    {
                        case 1:
                            resetVarBtn.Enabled = false;
                            plcImageEdit.EditValue = indicatorCollection.Images[5];
                            openPlcDeviceBtn.Enabled = true;
                            closePlcDeviceBtn.Enabled = false;
                            storeNameEdit.Enabled = true;
                            storeRowEdit.Enabled = true;
                            break;
                        case 2:
                            barcodeImageEdit.EditValue = indicatorCollection.Images[1];
                            break;
                    }                  
                    break;
            }
        }

        private List<int?> GiveAvailableCells()
        {

            wareHouseService = Program.kernel.Get<IWareHousesService>();

            cellRange = wareHouseService.GetWareHouses().Where(s => s.StoreNameId == storehouseRowId && s.NumberCell > 0).Select(s => s.NumberCell).OrderBy(o => o.Value).ToList<int?>();

            var _maxNumber = cellRange.Max();
            var _minNumber = cellRange.Min();

            cellLbl.Text = String.Format("№ кассеты (с {0} по {1})", _minNumber, _maxNumber);

            Logger.Log.Debug("Ищем занятые ячейки.");
            logMessageEdit.MaskBox.AppendText(DateTime.Now + " Ищем занятые ячейки." + Environment.NewLine);

            foreach (var item in windowsCurrentRowList)
            {

                var currentWindow = ConfigClass.Instance.DeviceBindingSettingList.FirstOrDefault(s => s.StoreNameParentId == storehouseId && s.TypeName == "DropoffWindow" && s.Id == item.ItemId);

                var bindDbItem = ConfigClass.Instance.DeviceBindingSettingList.FirstOrDefault(s => s.StoreNameParentId == storehouseId && s.TypeName == "DB" && s.ParentId == currentWindow.Id);

                var plcDeviceItem = ConfigClass.Instance.DataItemList.FirstOrDefault(s => s.DeviceId == ((bindDbItem != null) ? bindDbItem.DeviceId : 0));

                int currPlcDeviceId = (plcDeviceItem != null) ? plcDeviceItem.ParentDeviceId : 0;

                var plcSource = (ConfigClass.PlcSettingSource)ConfigClass.Instance.PlcSettingList.FirstOrDefault(s => s.DeviceId == currPlcDeviceId);
                var cpu = plcSource.CpuType;

                List<DataItemsQueryDTO> tagListRezerv = ConfigClass.Instance.DataItemList.Where(s => s.DeviceId == bindDbItem.DeviceId).ToList();

                PLC temporaryPlc = new PLC(tagListRezerv);

                temporaryPlc.Connect(cpu, plcSource.Ip, plcSource.Rack, plcSource.Slot);

                temporaryPlc.CurrentDb = Int32.Parse(ConfigClass.Instance.DeviceSettingsList.First(s => s.DeviceId == bindDbItem.DeviceId && s.KindName == "DataBlockIndex").SettingValue);
                _interval = Int32.Parse(ConfigClass.Instance.DeviceSettingsList.First(s => s.DeviceId == bindDbItem.DeviceId && s.KindName == "Interval").SettingValue);
                temporaryPlc.Interval = Convert.ToDouble((int)TimeSpan.FromSeconds(_interval).TotalMilliseconds);

                temporaryPlc.GetTags();

                tagListRezerv = temporaryPlc.Return();

                int randomCell = WindowLoadstatus(tagListRezerv);

                if (randomCell > 0)
                {
                    cellRange.Remove(randomCell);

                    Logger.Log.Debug("Ячейка № " + randomCell + " занята.");
                    logMessageEdit.MaskBox.AppendText(DateTime.Now + "Ячейка № " + randomCell + " занята." + Environment.NewLine);
                }
            }

            numberCellTBox.Properties.DataSource = cellRange;
            numberCellTBox.EditValue = _minNumber;

            return cellRange;
        }

        private int WindowLoadstatus(List<DataItemsQueryDTO> tagList)
        {

            int cell = 0;

            Int32.TryParse(tagList.First(s => s.Name == "CellNumber").CurrentValue, out cell);

            if (plc != null)
            {

                if (cell == 0)
                {

                    numberCellTBox.Enabled = true;
                    //setOpenBtn.Enabled = true;
                    //setCloseBtn.Enabled = false;

                    return cell;
                }
                else
                {
                    numberCellTBox.Enabled = false;
                    //setOpenBtn.Enabled = false;
                    //setCloseBtn.Enabled = true;

                    return cell;
                }
            }
            else
            {
                numberCellTBox.Enabled = false;
                //setOpenBtn.Enabled = false;
                //setCloseBtn.Enabled = false;
                return cell;
            }
        }

        private void startTimer()
        {
            if (plc.ConnectionState == ConnectionStates.Online)
            {
                timer.Interval = _interval;
                timer.Start();
            }
            else
            {
                MessageBox.Show("Ошибка при соединении!", "Cоединение с контроллером PLC", MessageBoxButtons.OK, MessageBoxIcon.Error);

                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                this.Close();

            }
        }

        private void stopTimer()
        {
            if (plc.ConnectionState == ConnectionStates.Offline)
            {
                timer.Stop();
            }
            else
            {
                MessageBox.Show("Ошибка разрыва соединения!", "Cоединение с контроллером PLC не разорвано ", MessageBoxButtons.OK, MessageBoxIcon.Error);

                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                this.Close();

            }
        }



        #endregion

        #region Operation method's with cells

        private bool OpenCell(List<DataItemsQueryDTO> currTagList, int numberCell, int interval, ConfigClass.BindedWindowItem windowItem)
        {
            tagList = plc.Return();

            int currPLCLoadStatus = 0;
            bool isDigitStatus = Int32.TryParse(tagList.First(s => s.Name == "PLCLoadStatus").CurrentValue, out currPLCLoadStatus);

            if (currPLCLoadStatus == 1)
            {
                MessageBox.Show("Манипулятор находится в движении.Повторите попытку позже.", "Выполнение операции", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            //int cell = Int32.Parse(numberCellTBox.Text);

            var itemCellNumber = tagList.First(s => s.Name == "CellNumber");
            var itemPLCDropoffWind = tagList.First(s => s.Name == "PLCDropoffWind");
            var ItemPLCSetOpen = tagList.First(s => s.Name == "PLCSetOpen");

            try
            {
                plc.WriteTag(itemCellNumber.AbsoleteItemName, numberCell);
                plc.WriteTag(itemPLCDropoffWind.AbsoleteItemName, windowItem.WindowNumber);
                plc.WriteTag(ItemPLCSetOpen.AbsoleteItemName, 1);

            }
            catch (Exception ex)
            {
                MessageBox.Show("При обмене данными с контроллером возникла ошибка.\n Проверьте подключение и повторите попытку.\n" + ex.Message, "Выполнение операции", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            Thread.Sleep(1500);

            currTagList = plc.Return();


            bool error = false;
            bool result = Boolean.TryParse(tagList.First(s => s.Name == "Error").CurrentValue, out error);
            string _errorList = tagList.First(s => s.Name == "ErrorList").CurrentValue.Replace("\0", String.Empty);

            if (!error || _errorList.Length == 0)
            {
                command = Utils.ProcessComand.OpenCell;

                try
                {
                    var itemPLCLoadStatus = tagList.First(s => s.Name == "PLCLoadStatus");
                    plc.WriteTag(itemPLCLoadStatus.AbsoleteItemName, 1);

                    processInfo.CellNumber = numberCell;
                    processInfo.OperationName = "Выдвинуть кассету";
                    processInfo.WindowNumber = windowItem.WindowNumber;
                    processInfo.StackerName = ConfigClass.Instance.DeviceBindingSettingList.FirstOrDefault(b => b.Id == windowItem.ParentItemId).Name;


                    using (WaitDialogFm form = new WaitDialogFm(plc, command, (int)TimeSpan.FromSeconds(_interval).TotalMilliseconds, processInfo))
                    {
                        DialogResult formResult = form.ShowDialog();

                        if (formResult == System.Windows.Forms.DialogResult.OK || formResult == System.Windows.Forms.DialogResult.Ignore)
                        {
                            MessageBox.Show(String.Format("Операция выполнена успешно"), "Выполнение операции", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            numberCellTBox.Enabled = false;
                            setOpenBtn.Enabled = false;
                            setCloseBtn.Enabled = true;

                            return true;
                        }
                        else if (formResult == System.Windows.Forms.DialogResult.Retry)
                        {

                            MessageBox.Show(String.Format("Операция отменена"), "Выполнение операции", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            return true;
                        }
                        else
                        {
                            MessageBox.Show(String.Format("Операция не выполнена"), "Выполнение операции", MessageBoxButtons.OK, MessageBoxIcon.Error);

                            return true;
                        }

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("При обмене данными с контроллером возникла ошибка.\n Проверьте подключение и повторите попытку.\n" + ex.Message, "Выполнение операции", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            else
            {
                ErrorListControl displayAlarm = new ErrorListControl(AlarmsList(_errorList));
                DevExpress.XtraEditors.XtraDialog.Show(displayAlarm, "Журнал ошибок", MessageBoxButtons.OK);

                //var itemMessageReset = tagList.First(s => s.Name == "MessageReset");
                //var itemErrorList = tagList.First(s => s.Name == "ErrorList");
                //var itemError = tagList.First(s => s.Name == "Error");

                try
                {
                    //plc.WriteTag(itemMessageReset.AbsoleteItemName, true);
                    //plc.WriteTag(itemError.AbsoleteItemName, false);
                    //plc.WriteEmptyTextTag(itemErrorList, _errorList.Length);

                    //plc.WriteTag(itemCellNumber.AbsoleteItemName, 0);
                    //plc.WriteTag(itemPLCDropoffWind.AbsoleteItemName, 0);
                    //plc.WriteTag(ItemPLCSetOpen.AbsoleteItemName, 0);
                    plc.ResetAllVar();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("При обмене данными с контроллером возникла ошибка.\n Проверьте подключение и повторите попытку.\n" + ex.Message, "Выполнение операции", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

            }
            return true;
        }

        private bool CloseCell(List<DataItemsQueryDTO> currTagList, int numberCell, int interval, ConfigClass.BindedWindowItem windowItem)
        {
            tagList = plc.Return();

            int currPLCLoadStatus = 0;
            bool isDigitStatus = Int32.TryParse(tagList.First(s => s.Name == "PLCLoadStatus").CurrentValue, out currPLCLoadStatus);

            if (currPLCLoadStatus == 1)
            {
                MessageBox.Show("Манипулятор находится в движении.Повторите попытку позже.", "Выполнение операции", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            int currCell = 0;
            bool isDigit = Int32.TryParse(tagList.First(s => s.Name == "CellNumber").CurrentValue, out currCell);

            if (currCell == 0)
            {
                MessageBox.Show("Кассета отсутствует на столе выдачи.\n Выдвиньте сначала кассету и повторите попытку.", "Выполнение операции", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            try
            {
                var itemSetClose = tagList.First(s => s.Name == "PLCSetClose");
                var itemPLCLoadStatus = currTagList.First(s => s.Name == "PLCLoadStatus");

                plc.WriteTag(itemPLCLoadStatus.AbsoleteItemName, 1);
                plc.WriteTag(itemSetClose.AbsoleteItemName, 1);
            }
            catch (Exception ex)
            {
                MessageBox.Show("При обмене данными с контроллером возникла ошибка.\n Проверьте подключение и повторите попытку.\n" + ex.Message, "Выполнение операции", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            Thread.Sleep(1500);

            tagList = plc.Return();

            bool error = false;
            bool result = Boolean.TryParse(tagList.First(s => s.Name == "Error").CurrentValue, out error);
            string _errorList = tagList.First(s => s.Name == "ErrorList").CurrentValue.Replace("\0", String.Empty);

            if (error || _errorList.Length > 0)
            {
                ErrorListControl displayAlarm = new ErrorListControl(AlarmsList(_errorList));
                DevExpress.XtraEditors.XtraDialog.Show(displayAlarm, "Журнал ошибок", MessageBoxButtons.OK);

                var itemMessageReset = tagList.First(s => s.Name == "MessageReset");
                var itemErrorList = tagList.First(s => s.Name == "ErrorList");
                var itemError = tagList.First(s => s.Name == "Error");
                var itemSetClose = currTagList.First(s => s.Name == "PLCSetClose");
                var itemPLCLoadStatus = currTagList.First(s => s.Name == "PLCLoadStatus");

                try
                {
                    plc.WriteTag(itemMessageReset.AbsoleteItemName, true);
                    plc.WriteTag(itemError.AbsoleteItemName, false);
                    plc.WriteEmptyTextTag(itemErrorList, _errorList.Length);
                    plc.WriteTag(itemSetClose.AbsoleteItemName, 0);
                    plc.WriteTag(itemPLCLoadStatus.AbsoleteItemName, 0);

                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("При обмене данными с контроллером возникла ошибка.\n Проверьте подключение и повторите попытку.\n" + ex.Message, "Выполнение операции", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

            }
            else
            {
                try
                {
                    command = Utils.ProcessComand.CloseCellFull;

                    processInfo.CellNumber = Int32.Parse(currTagList.First(s => s.Name == "CellNumber").CurrentValue);
                    processInfo.OperationName = "Вернуть кассету на склад";
                    processInfo.WindowNumber = windowItem.WindowNumber;
                    processInfo.StackerName = ConfigClass.Instance.DeviceBindingSettingList.FirstOrDefault(b => b.Id == windowItem.ParentItemId).Name;

                    using (WaitDialogFm form = new WaitDialogFm(plc, command, (int)TimeSpan.FromSeconds(_interval).TotalMilliseconds, processInfo))
                    {
                        DialogResult formResult = form.ShowDialog();

                        if (formResult == System.Windows.Forms.DialogResult.OK || formResult == System.Windows.Forms.DialogResult.Ignore)
                        {
                            MessageBox.Show(String.Format("Операция выполнена успешно"), "Выполнение операции", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            numberCellTBox.Text = "";

                            setOpenBtn.Enabled = true;
                            setCloseBtn.Enabled = false;
                            resetVarBtn.Enabled = true;
                            numberCellTBox.Enabled = true;

                            return true;
                        }
                        else
                        {
                            MessageBox.Show(String.Format("Операция не выполнена"), "Выполнение операции", MessageBoxButtons.OK, MessageBoxIcon.Error);

                            return false;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("При обмене данными с контроллером возникла ошибка.\n Проверьте подключение и повторите попытку.\n" + ex.Message, "Выполнение операции", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }

        private void ChangeCell()
        {
            #region Get data collection for with cell presence info

            wareHouseService = Program.kernel.Get<IWareHousesService>();
            materialService = Program.kernel.Get<IMaterialsService>();
            storageGroupZoneService = Program.kernel.Get<IStorageGroupZonesService>();

            int testMaterialId = 214; // Арт. 1101591 Ступица

            //получаем id зоны хранения для заданного материала
            int testZoneNameId = materialService.GetZoneNameByMaterial(testMaterialId).ZoneNameId;
            //получаем загруженности заданной зоны хранения
            var zonePresenceList = storageGroupZoneService.GetStorageGroupZonePresence(testZoneNameId, 0, -1);
            //получаем  коллекцию уникальных ячеек
            var cellsRangeList = zonePresenceList.GroupBy(g => g.WareHouseId).Select(s => s.First()).ToList();
            //обьединяем коллекции коллекцию ячеек с информацией о материалах
            var resultDataList = (from c in cellsRangeList
                                  join z in zonePresenceList on c.WareHouseId equals z.WareHouseId
                                  select new StorageGroupZonePresenceDTO()
                                  {
                                      WareHouseId = z.WareHouseId,
                                      StoreName = z.StoreName,
                                      RowName = z.RowName,
                                      NumberCell = z.NumberCell,
                                      CellMeasure = z.CellMeasure,
                                      CellPresence = z.CellPresence,
                                      MaxWeight = z.MaxWeight,
                                      CurrentWeight = z.CurrentWeight,
                                      FreeWeight = z.FreeWeight,
                                      MaterialId = z.MaterialId,
                                      Article = z.Article,
                                      MaterialName = z.MaterialName,
                                      UnitLocalName = z.UnitLocalName,
                                      QuantityStore = z.QuantityStore
                                  }
                                  )
                                  .ToList();

            #endregion

            using (StoreCellPresenceFm form = new StoreCellPresenceFm(resultDataList))
            {
                if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    int changeCellNumber = form.Return().NumberCell ?? 0;

                    int currPLCLoadStatus = 0;
                    bool isDigitStatus = Int32.TryParse(tagList.First(s => s.Name == "PLCLoadStatus").CurrentValue, out currPLCLoadStatus);

                    if (currPLCLoadStatus == 1)
                    {
                        MessageBox.Show("Манипулятор находится в движении.Повторите попытку позже.", "Выполнение операции", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    int currCell = 0;
                    bool isDigit = Int32.TryParse(tagList.First(s => s.Name == "CellNumber").CurrentValue, out currCell);

                    if (currCell == changeCellNumber)
                    {
                        MessageBox.Show("Кассета с таким номером находится на столе выдачи.\n Выбирите кассету с другим номером.", "Выполнение операции", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    var itemSetClose = tagList.First(s => s.Name == "PLCSetClose");

                    try
                    {
                        plc.WriteTag(itemSetClose.AbsoleteItemName, 1);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("При обмене данными с контроллером возникла ошибка.\n Проверьте подключение и повторите попытку.\n" + ex.Message, "Выполнение операции", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    bool error = false;
                    bool result = Boolean.TryParse(tagList.First(s => s.Name == "Error").CurrentValue, out error);
                    string _errorList = tagList.First(s => s.Name == "ErrorList").CurrentValue.Replace("\0", String.Empty);

                    if (!error || _errorList.Length == 0)
                    {
                        try
                        {
                            var itemPLCLoadStatus = tagList.First(s => s.Name == "PLCLoadStatus");
                            plc.WriteTag(itemPLCLoadStatus.AbsoleteItemName, 1);

                            command = Utils.ProcessComand.ChangeCell;

                            processInfo.CellNumber = changeCellNumber;
                            processInfo.OperationName = "Перевыбрать кассету";

                            using (WaitDialogFm formWait = new WaitDialogFm(plc, command, (int)TimeSpan.FromSeconds(_interval).TotalMilliseconds, processInfo))
                            {
                                if (formWait.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                                {
                                    MessageBox.Show(String.Format("Операция выполнена успешно"), "Выполнение операции", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    numberCellTBox.Text = "";

                                    setOpenBtn.Enabled = false;
                                    setCloseBtn.Enabled = true;
                                    resetVarBtn.Enabled = true;
                                    numberCellTBox.Enabled = false;
                                }
                                else
                                    MessageBox.Show(String.Format("Операция не выполнена"), "Выполнение операции", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("При обмене данными с контроллером возникла ошибка.\n Проверьте подключение и повторите попытку.\n" + ex.Message, "Выполнение операции", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    else
                    {
                        ErrorListControl displayAlarm = new ErrorListControl(AlarmsList(_errorList));
                        DevExpress.XtraEditors.XtraDialog.Show(displayAlarm, "Журнал ошибок", MessageBoxButtons.OK);

                        var itemMessageReset = tagList.First(s => s.Name == "MessageReset");
                        var itemErrorList = tagList.First(s => s.Name == "ErrorList");
                        var itemError = tagList.First(s => s.Name == "Error");

                        try
                        {
                            plc.WriteTag(itemMessageReset.AbsoleteItemName, true);
                            plc.WriteTag(itemError.AbsoleteItemName, false);
                            plc.WriteEmptyTextTag(itemErrorList, _errorList.Length);

                            plc.WriteTag(itemSetClose.AbsoleteItemName, 0);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("При обмене данными с контроллером возникла ошибка.\n Проверьте подключение и повторите попытку.\n" + ex.Message, "Выполнение операции", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                }
                else
                {
                    MessageBox.Show(String.Format("Кассета не выбрана!"), "Перевыбор кассеты", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        private bool CancelOperation(List<DataItemsQueryDTO> currTagList, int numberCell, int interval, ConfigClass.BindedWindowItem windowItem)
        {
            currTagList = plc.Return();

            int currPLCLoadStatus = 0;
            bool isDigitStatus = Int32.TryParse(currTagList.First(s => s.Name == "PLCLoadStatus").CurrentValue, out currPLCLoadStatus);

            if (currPLCLoadStatus == 1)
            {
                MessageBox.Show("Манипулятор находится в движении.Повторите попытку позже.", "Выполнение операции", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            var itemSetClose = tagList.First(s => s.Name == "PLCSetClose");

            try
            {
                plc.WriteTag(itemSetClose.AbsoleteItemName, 1);
            }
            catch (Exception ex)
            {
                MessageBox.Show("При обмене данными с контроллером возникла ошибка.\n Проверьте подключение и повторите попытку.\n" + ex.Message, "Выполнение операции", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            Thread.Sleep(1500);

            currTagList = plc.Return();

            bool error = false;
            bool result = Boolean.TryParse(tagList.First(s => s.Name == "Error").CurrentValue, out error);
            string _errorList = tagList.First(s => s.Name == "ErrorList").CurrentValue.Replace("\0", String.Empty);

            if (!error || _errorList.Length == 0)
            {
                try
                {
                    var itemPLCLoadStatus = tagList.First(s => s.Name == "PLCLoadStatus");
                    plc.WriteTag(itemPLCLoadStatus.AbsoleteItemName, 1);

                    command = Utils.ProcessComand.CancelOperation;

                    processInfo.CellNumber = Int32.Parse(tagList.First(s => s.Name == "CellNumber").CurrentValue);
                    processInfo.OperationName = "Отменить операцию и вернуть кассету";
                    processInfo.WindowNumber = windowItem.WindowNumber;
                    processInfo.StackerName = ConfigClass.Instance.DeviceBindingSettingList.FirstOrDefault(b => b.Id == windowItem.ParentItemId).Name;

                    using (WaitDialogFm form = new WaitDialogFm(plc, command, (int)TimeSpan.FromSeconds(_interval).TotalMilliseconds, processInfo))
                    {

                        DialogResult formResult = form.ShowDialog();

                        if (formResult == System.Windows.Forms.DialogResult.OK || formResult == System.Windows.Forms.DialogResult.Retry)
                        {
                            MessageBox.Show(String.Format("Операция выполнена успешно"), "Выполнение операции", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //numberCellTBox.Text = "";

                            plc.ResetAllVar();

                            //setOpenBtn.Enabled = true;
                            //setCloseBtn.Enabled = false;
                            ////changeCellBtn.Enabled = false;
                            //cancelOperationBtn.Enabled = false;
                            //resetVarBtn.Enabled = true;
                            //genQRBtn.Enabled = true;
                            //numberCellTBox.Enabled = true;
                            return true;

                        }
                        else
                        {
                            MessageBox.Show(String.Format("Операция не выполнена"), "Выполнение операции", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("При обмене данными с контроллером возникла ошибка.\n Проверьте подключение и повторите попытку.\n" + ex.Message, "Выполнение операции", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            else
            {
                ErrorListControl displayAlarm = new ErrorListControl(AlarmsList(_errorList));
                DevExpress.XtraEditors.XtraDialog.Show(displayAlarm, "Журнал ошибок", MessageBoxButtons.OK);

                var itemMessageReset = tagList.First(s => s.Name == "MessageReset");
                var itemErrorList = tagList.First(s => s.Name == "ErrorList");
                var itemError = tagList.First(s => s.Name == "Error");
                //var itemSetClose = currTagList.First(s => s.Name == "PLCSetClose");
                var itemPLCLoadStatus = currTagList.First(s => s.Name == "PLCLoadStatus");

                try
                {
                    plc.WriteTag(itemMessageReset.AbsoleteItemName, true);
                    plc.WriteTag(itemError.AbsoleteItemName, false);
                    plc.WriteEmptyTextTag(itemErrorList, _errorList.Length);
                    plc.WriteTag(itemSetClose.AbsoleteItemName, 0);
                    plc.WriteTag(itemPLCLoadStatus.AbsoleteItemName, 0);

                    return false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("При обмене данными с контроллером возникла ошибка.\n Проверьте подключение и повторите попытку.\n" + ex.Message, "Выполнение операции", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }

        private void ResetAllPlcVar()
        {
            if (plc != null)
            {
                plc.ResetAllVar();

                setOpenBtn.Enabled = true;
                setCloseBtn.Enabled = false;
                resetVarBtn.Enabled = true;
                genQRBtn.Enabled = true;
                numberCellTBox.Enabled = true;
            }
        }

        #region Keeping method's

        private bool GetCellFromStorageDone(ConfigClass.BindedWindowItem windowItem, int numberCell)
        {
            var bindDBItem = ConfigClass.Instance.DeviceBindingSettingList.Where(s => s.ParentId == windowItem.ItemId).FirstOrDefault();

            if (bindDBItem != null)
            {
                splashScreenManager.ShowWaitForm();

                plc.CurrentDb = Int32.Parse(ConfigClass.Instance.DeviceSettingsList.First(s => s.DeviceId == bindDBItem.DeviceId && s.KindName == "DataBlockIndex").SettingValue);
                _interval = Int32.Parse(ConfigClass.Instance.DeviceSettingsList.First(s => s.DeviceId == bindDBItem.DeviceId && s.KindName == "Interval").SettingValue);
                plc.Interval = Convert.ToDouble((int)TimeSpan.FromSeconds(_interval).TotalMilliseconds);

                tagList = ConfigClass.Instance.DataItemList.Where(s => s.DeviceId == bindDBItem.DeviceId).ToList();

                plc.TimerStart(tagList);

                splashScreenManager.CloseWaitForm();

                return (OpenCell(tagList, numberCell, _interval, windowItem));
            }
            else
            {
                return false;
            }
        }

        private bool PutCellToStorageDone(ConfigClass.BindedWindowItem windowItem, int numberCell)
        {
            var bindDBItem = ConfigClass.Instance.DeviceBindingSettingList.Where(s => s.ParentId == windowItem.ItemId).FirstOrDefault();

            if (bindDBItem != null)
            {
                splashScreenManager.ShowWaitForm();

                plc.CurrentDb = Int32.Parse(ConfigClass.Instance.DeviceSettingsList.First(s => s.DeviceId == bindDBItem.DeviceId && s.KindName == "DataBlockIndex").SettingValue);
                _interval = Int32.Parse(ConfigClass.Instance.DeviceSettingsList.First(s => s.DeviceId == bindDBItem.DeviceId && s.KindName == "Interval").SettingValue);
                plc.Interval = Convert.ToDouble((int)TimeSpan.FromSeconds(_interval).TotalMilliseconds);

                tagList = ConfigClass.Instance.DataItemList.Where(s => s.DeviceId == bindDBItem.DeviceId).ToList();

                plc.TimerStart(tagList);

                startTimer();

                splashScreenManager.CloseWaitForm();

                return (CloseCell(tagList, numberCell, _interval, windowItem));
            }
            else
            {
                return false;
            }
        }

        private bool PutCellToStorageForCancel(ConfigClass.BindedWindowItem windowItem, int numberCell)
        {
            var bindDBItem = ConfigClass.Instance.DeviceBindingSettingList.Where(s => s.ParentId == windowItem.ItemId).FirstOrDefault();

            if (bindDBItem != null)
            {
                splashScreenManager.ShowWaitForm();

                plc.CurrentDb = Int32.Parse(ConfigClass.Instance.DeviceSettingsList.First(s => s.DeviceId == bindDBItem.DeviceId && s.KindName == "DataBlockIndex").SettingValue);
                _interval = Int32.Parse(ConfigClass.Instance.DeviceSettingsList.First(s => s.DeviceId == bindDBItem.DeviceId && s.KindName == "Interval").SettingValue);
                plc.Interval = Convert.ToDouble((int)TimeSpan.FromSeconds(_interval).TotalMilliseconds);

                tagList = ConfigClass.Instance.DataItemList.Where(s => s.DeviceId == bindDBItem.DeviceId).ToList();

                plc.TimerStart(tagList);

                splashScreenManager.CloseWaitForm();

                return (CloseCell(tagList, numberCell, _interval, windowItem));
            }
            else
            {
                return false;
            }
        }

        #endregion

        #endregion

        #region Form element changed event's

        private void storeNameEdit_EditValueChanged(object sender, EventArgs e)
        {
            if (storeNameEdit.EditValue != null)
            {
                rowNamesList = storeNameService.GetRowByStoreNameId((int)storeNameEdit.EditValue);
                storeRowEdit.Properties.DataSource = rowNamesList;
                storeRowEdit.Properties.ValueMember = "StoreNameId";
                storeRowEdit.Properties.DisplayMember = "Name";
            }
        }

        private void storeRowEdit_EditValueChanged(object sender, EventArgs e)
        {
            splashScreenManager.ShowWaitForm();

            plcDeviceId = (int)storeNameEdit.EditValue;

            storehouseId = (int)storeNameEdit.EditValue;

            storehouseRowId = (int)storeRowEdit.EditValue;


            if (storeRowEdit.EditValue != null)
            {
                bindedWindowItemList = ConfigClass.Instance.BindedWindowItemList.Where(s => s.StoreNameParentId == storehouseId).ToList();

                var windows = bindedWindowItemList.Where(z => z.StoreNameId == storehouseRowId);

                var windowDistinctList = windows
                                .GroupBy(g => g.DeviceId)
                                .Select(s => s.First())
                                .ToList();

                windowsCurrentRowList = (List<ConfigClass.BindedWindowItem>)windowDistinctList;

                if (windowsCurrentRowList.Count() > 0)
                    windowId = windowsCurrentRowList[0].ItemId;
                else
                    MessageBox.Show("Не найдено окно выдачи!", "Поключение устройств", MessageBoxButtons.OK, MessageBoxIcon.Information);

                windowEdit.Properties.DataSource = windowsCurrentRowList;
                windowEdit.Properties.ValueMember = "ItemId";
                windowEdit.Properties.DisplayMember = "WindowNumber";
                windowEdit.EditValue = windowsCurrentRowList[0].ItemId;

                cellRange = GiveAvailableCells();

                genQRBtn.Enabled = true;
                numberCellTBox.Enabled = true;

            }

            Logger.Log.Debug("Изменили ряд склада.");
            logMessageEdit.MaskBox.AppendText(DateTime.Now + " Изменили ряд склада." + Environment.NewLine);

            splashScreenManager.CloseWaitForm();
        }

        private void windowEdit_EditValueChanged(object sender, EventArgs e)
        {

            windowId = (int)windowEdit.EditValue;

            if (plc != null)
            {
                plc.TimerStop();

                timer.Stop();

                Logger.Log.Debug("Изменили окно выдачи.");
                logMessageEdit.MaskBox.AppendText(DateTime.Now + " Изменили окно выдачи." + Environment.NewLine);

                var currentWindow = ConfigClass.Instance.DeviceBindingSettingList.FirstOrDefault(s => s.StoreNameParentId == storehouseId && s.TypeName == "DropoffWindow" && s.Id == windowId);

                var bindDbItem = ConfigClass.Instance.DeviceBindingSettingList.FirstOrDefault(s => s.StoreNameParentId == storehouseId && s.TypeName == "DB" && s.ParentId == currentWindow.Id);

                plc.CurrentDb = Int32.Parse(ConfigClass.Instance.DeviceSettingsList.First(s => s.DeviceId == bindDbItem.DeviceId && s.KindName == "DataBlockIndex").SettingValue);
                _interval = Int32.Parse(ConfigClass.Instance.DeviceSettingsList.First(s => s.DeviceId == bindDbItem.DeviceId && s.KindName == "Interval").SettingValue);
                plc.Interval = Convert.ToDouble((int)TimeSpan.FromSeconds(_interval).TotalMilliseconds);

                tagList = ConfigClass.Instance.DataItemList.Where(s => s.DeviceId == bindDbItem.DeviceId).ToList();

                int loadCell = WindowLoadstatus(tagList);

                if (loadCell == 0)
                {

                    splashScreenManager.ShowWaitForm();

                    GiveAvailableCells();

                    WindowLoadstatus(tagList);

                    //numberCellTBox.Enabled = true;

                    SetDeviceIndicators(Utils.DeviceIndication.Connected, 1, Utils.StatusWindow.WindowNotBusy);

                    splashScreenManager.CloseWaitForm();

                }
                else
                {

                    splashScreenManager.ShowWaitForm();

                    numberCellTBox.Properties.DataSource = cellRange;
                    numberCellTBox.EditValue = loadCell;
                    numberCellTBox.Enabled = false;

                    WindowLoadstatus(tagList);

                    SetDeviceIndicators(Utils.DeviceIndication.Connected, 1, Utils.StatusWindow.WindowBusy);

                    splashScreenManager.CloseWaitForm();

                }

                plc.TimerStart(tagList);

                startTimer();
            }
        }

        private void TestFm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_spManager != null)
                _spManager.Dispose();
        }



        #endregion

        #region Operation button event's

        #region Connect to PLC

        private void openPlcDeviceBtn_Click(object sender, EventArgs e)
        {
            command = Utils.ProcessComand.None;

            if (storehouseId > 0)
            {

                var bindDbItem = ConfigClass.Instance.DeviceBindingSettingList.FirstOrDefault(s => s.StoreNameParentId == storehouseId && s.TypeName == "DB");

                var plcDeviceItem = ConfigClass.Instance.DataItemList.FirstOrDefault(s => s.DeviceId == ((bindDbItem != null) ? bindDbItem.DeviceId : 0));

                int currPlcDeviceId = (plcDeviceItem != null) ? plcDeviceItem.ParentDeviceId : 0;

                bindedWindowItemList = ConfigClass.Instance.BindedWindowItemList.Where(s => s.StoreNameParentId == storehouseId).ToList();

                if (currPlcDeviceId > 0)
                {

                    splashScreenManager.ShowWaitForm();

                    plcDeviceId = currPlcDeviceId;

                    if (ConnectPlc(plcDeviceId))
                    {

                        tagList = plc.Return();

                        WindowLoadstatus(tagList);

                        if (WindowLoadstatus(tagList) > 0)
                            SetDeviceIndicators(Utils.DeviceIndication.Connected, 1, Utils.StatusWindow.WindowBusy);
                        else
                            SetDeviceIndicators(Utils.DeviceIndication.Connected, 1, Utils.StatusWindow.WindowNotBusy);


                    }
                    else
                    {
                        SetDeviceIndicators(Utils.DeviceIndication.Disabled, 1, Utils.StatusWindow.WindowNotBusy);

                        MessageBox.Show("Ошибка подключения", "Поключение устройств", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        logMessageEdit.MaskBox.AppendText(DateTime.Now + " Ошибка подключения!Не сработал метод ConnectPlc." + Environment.NewLine);

                    }

                    splashScreenManager.CloseWaitForm();

                }
                else
                {
                    MessageBox.Show("Ошибка при получении настроек. Проверьте привязку оборудования к складу!", "Поключение устройств", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Logger.Log.Debug("Ошибка при получении настроек. Проверьте привязку оборудования к складу!Id текущего устройства равен нулю");
                    logMessageEdit.MaskBox.AppendText(DateTime.Now + " Ошибка при получении настроек. Проверьте привязку оборудования к складу! Id текущего устройства равен нулю" + Environment.NewLine);
                }
            }
            else
            {
                MessageBox.Show("Ряд склада не выбран. Воспользуйтесь списком рядов для выбора.", "Поключение устройств", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Logger.Log.Debug("Ряд склада не выбран. Воспользуйтесь списком рядов для выбора.");
                logMessageEdit.MaskBox.AppendText(DateTime.Now + " Ряд склада не выбран. Воспользуйтесь списком рядов для выбора." + Environment.NewLine);
            }
        }

        private void closePlcDeviceBtn_Click(object sender, EventArgs e)
        {
            DisconnectPLC();

            SetDeviceIndicators(Utils.DeviceIndication.Offline, 1, Utils.StatusWindow.WindowNotBusy);

            stopTimer();

            plc = null;

            openPlcDeviceBtn.Enabled = true;
            closePlcDeviceBtn.Enabled = false;
            storeNameEdit.Enabled = true;
            storeRowEdit.Enabled = true;
            refreshSpin.Enabled = true;

            plcVarGrid.DataSource = null;

        }

        #endregion

        #region Connect to Scaner

        private void openBarcodeDeviceBtn_Click(object sender, EventArgs e)
        {
            command = Utils.ProcessComand.None;

            if (ConnectBarcode())
                SetDeviceIndicators(Utils.DeviceIndication.Connected, 2, Utils.StatusWindow.WindowMissing);
            else
                SetDeviceIndicators(Utils.DeviceIndication.Disabled, 2, Utils.StatusWindow.WindowMissing);
        }

        private void closeBarcodeDeviceBtn_Click(object sender, EventArgs e)
        {
            DisconnectBarcode();
            SetDeviceIndicators(Utils.DeviceIndication.Offline, 2, Utils.StatusWindow.WindowMissing);
        }

        private void genQRBtn_Click(object sender, EventArgs e)
        {
            testBCode.Text = numberCellTBox.Text;
        }

        #endregion

        #region Manipulate cells of storehouse

        private void setOpenBtn_Click(object sender, EventArgs e)
        {
            try
            {

                bindedWindowItemList = ConfigClass.Instance.BindedWindowItemList.Where(s => s.StoreNameParentId == storehouseId).ToList();

                int currentNumberCell = (int)numberCellTBox.EditValue;

                if (GetCellFromStorageDone(bindedWindowItemList.SingleOrDefault(z => z.ItemId == (int)windowEdit.EditValue), currentNumberCell))
                {
                    splashScreenManager.ShowWaitForm();

                    bindedWindowItemList.SingleOrDefault(z => z.ItemId == (int)windowEdit.EditValue).BusyWindow = true;
                    GiveAvailableCells();
                    WindowLoadstatus(plc.Return());

                    splashScreenManager.CloseWaitForm();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("При выполнении опеации возникла ошибка.\n" + ex.Message, "Выполнение операции", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }

        private void setCloseBtn_Click(object sender, EventArgs e)
        {
            try
            {
                bindedWindowItemList = ConfigClass.Instance.BindedWindowItemList.Where(s => s.StoreNameParentId == storehouseId).ToList();

                int currentNumberCell = (int)numberCellTBox.EditValue;

                if (PutCellToStorageDone(bindedWindowItemList.SingleOrDefault(z => z.ItemId == (int)windowEdit.EditValue), currentNumberCell))
                {
                    splashScreenManager.ShowWaitForm();

                    bindedWindowItemList.SingleOrDefault(z => z.ItemId == (int)windowEdit.EditValue).BusyWindow = false;
                    GiveAvailableCells();
                    WindowLoadstatus(plc.Return());

                    splashScreenManager.CloseWaitForm();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("При выполнении опеации возникла ошибка.\n" + ex.Message, "Выполнение операции", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void resetVarBtn_Click(object sender, EventArgs e)
        {
            splashScreenManager.ShowWaitForm();

            ResetAllPlcVar();

            splashScreenManager.CloseWaitForm();
        }


        #endregion

        private void openPlcSyncBtn_Click(object sender, EventArgs e)
        {
            try
            {
                var plcSource = (ConfigClass.PlcSettingSource)ConfigClass.Instance.PlcSettingList.FirstOrDefault(s => s.Name == ConfigClass.Instance.GlobalLocalSettings.WatchDogPLCName);

                var cpu = plcSource.CpuType;
                WatchDog.Instance.Connect(cpu, plcSource.Ip, plcSource.Rack, plcSource.Slot);

                if (WatchDog.Instance.connectionState == ConnectionStates.Online)
                    SetDeviceIndicators(Utils.DeviceIndication.Connected, 3, Utils.StatusWindow.WindowMissing);
                else
                    SetDeviceIndicators(Utils.DeviceIndication.Disabled, 3, Utils.StatusWindow.WindowMissing);


            }
            catch(Exception exp)
            {



            }
  
        }


        #endregion

        private void closePlcSyncBtn_Click(object sender, EventArgs e)
        {
            WatchDog.Instance.Disconnect();
            SetDeviceIndicators(Utils.DeviceIndication.Offline, 3, Utils.StatusWindow.WindowMissing);
        }





    }
}