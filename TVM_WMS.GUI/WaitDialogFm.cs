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
using TVM_WMS.BLL.Infrastructure.PlcWrapper;
using TVM_WMS.BLL.Infrastructure.SerialPortListener;
using TVM_WMS.BLL.DTO;
using System.IO;
using TVM_WMS.BLL.BusinessLogicModule;
using TVM_WMS.BLL.DTO.QueryDTO;

namespace TVM_WMS.GUI
{
    public partial class WaitDialogFm : DevExpress.XtraEditors.XtraForm
    {
        private PLC _plc;

        private BindingSource processInfoBS = new BindingSource();

        private string _errorList;
        private Utils.ProcessComand _command;
        private int _interval;

        private List<DataItemsQueryDTO> TagList = new List<DataItemsQueryDTO>();

        public WaitDialogFm(PLC plc, Utils.ProcessComand command, int interval , Utils.ProcessInfo infoSource)
        {
            InitializeComponent();

            _plc = plc;
            _interval = interval;
            _command = command;

            processInfoBS.DataSource = infoSource;

            operationInfoLbl.DataBindings.Add("Text", processInfoBS, "OperationName");
            stackerInfoLbl.DataBindings.Add("Text", processInfoBS, "StackerName");
            cellInfoLbl.DataBindings.Add("Text", processInfoBS, "CellNumber");
            dropoffInfoLbl.DataBindings.Add("Text", processInfoBS, "WindowNumber");

            this.Focus();

            StartTimer();
        }
        
        private void StartTimer()
        {
            if (_plc.ConnectionState == ConnectionStates.Online)
            {
                waitTimer.Interval = _interval;
                waitTimer.Start();
            }
            else
            {
                MessageBox.Show("Ошибка при соединении!", "Cоединение с контроллером PLC", MessageBoxButtons.OK, MessageBoxIcon.Error);

                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                this.Close();

            }
        }

        private void waitTimer_Tick(object sender, EventArgs e)
        {
            TagList = _plc.Return();

            ProcessIndicator(_command, TagList);
        }
        
        private void ProcessIndicator(Utils.ProcessComand currCommand, List<DataItemsQueryDTO> itemSource)
        {
            if (currCommand != Utils.ProcessComand.None)
            {
                bool error = false;
                bool result = Boolean.TryParse(itemSource.First(s => s.Name == "Error").CurrentValue, out error);

                _errorList = itemSource.First(s => s.Name == "ErrorList").CurrentValue.Replace("\0", String.Empty);

                if (error || _errorList.Length > 0)
                    _command = Utils.ProcessComand.Error;
            }

            switch (currCommand)
            {
                case Utils.ProcessComand.ConfirmQuantity:
                    break;

                case Utils.ProcessComand.ChangeCell:
                    operationInfoLbl.Text = "Вернуть ячейку на склад";
                    bool putToDoneForChange = Boolean.Parse(itemSource.First(s => s.Name == "PutToDone").CurrentValue);
                    if (putToDoneForChange)
                    {
                        _command = Utils.ProcessComand.OpenCell;
                        
                        var itemCellNumber = TagList.First(s => s.Name == "CellNumber");
                        var itemPLCDropoffWind = TagList.First(s => s.Name == "PLCDropoffWind");
                        var ItemPLCSetOpen = TagList.First(s => s.Name == "PLCSetOpen");

                        _plc.WriteTag(itemCellNumber.AbsoleteItemName, ((Utils.ProcessInfo)processInfoBS.Current).CellNumber);
                        _plc.WriteTag(itemPLCDropoffWind.AbsoleteItemName, ((Utils.ProcessInfo)processInfoBS.Current).WindowNumber);
                        _plc.WriteTag(ItemPLCSetOpen.AbsoleteItemName, 1);

                        operationInfoLbl.Text = "Выдвинуть ячейку";
                    }
                    break; 
                   
                case Utils.ProcessComand.CellCloseAgain:
                    bool putToDoneRetry = Boolean.Parse(itemSource.First(s => s.Name == "PutToDone").CurrentValue);
                    if (putToDoneRetry)
                    {
                        _command = Utils.ProcessComand.None;

                        _plc.ResetAllVar();
                        
                        DialogResult = System.Windows.Forms.DialogResult.Retry;
                        this.Close();
                    }
                    break;

                case Utils.ProcessComand.CancelOperation:
                case Utils.ProcessComand.CloseCellWithLoadUp:
                case Utils.ProcessComand.CloseCellFull:
                    bool putToDone = Boolean.Parse(itemSource.First(s => s.Name == "PutToDone").CurrentValue);
                    if (putToDone)
                    {
                        _command = Utils.ProcessComand.None;

                        _plc.ResetAllVar();
                        
                        DialogResult = System.Windows.Forms.DialogResult.OK;
                        this.Close();
                    }
                    break;

               case Utils.ProcessComand.BreakOperation:
                    var ItemStopBit = TagList.First(s => s.Name == "StopBit");
                    _plc.WriteTag(ItemStopBit.AbsoleteItemName, true);

                    using (OperationCustomWaitFm operationUCFromError = new OperationCustomWaitFm(_command))
                    {
                        if (operationUCFromError.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        {
                            _command = operationUCFromError.Return();

                            if (_command == Utils.ProcessComand.CellOpenAgain)
                            {
                                operationInfoLbl.Text = "Выдвинуть ячейку";
                                processInfoBS.EndEdit();
                                var ItemSetOpenAgain = TagList.First(s => s.Name == "SetOpenAgain");
                                _plc.WriteTag(ItemSetOpenAgain.AbsoleteItemName, true);
                            }
                            else
                            {
                                operationInfoLbl.Text = "Вернуть ячейку";
                                processInfoBS.EndEdit();
                                var ItemSetCloseAgain = TagList.First(s => s.Name == "SetCloseAgain");
                                _plc.WriteTag(ItemSetCloseAgain.AbsoleteItemName, true);
                            }
                        }
                    }

                    waitTimer.Start();
                    break;
                case Utils.ProcessComand.CellOpenAgain:
                    bool getFromDoneIgnore = Boolean.Parse(itemSource.First(s => s.Name == "GetFromDone").CurrentValue);
                    if (getFromDoneIgnore)
                    {
                        _command = Utils.ProcessComand.None;

                        var itemPLCLoadStatus = TagList.First(s => s.Name == "PLCLoadStatus");
                        var ItemPLCSetOpen = TagList.First(s => s.Name == "PLCSetOpen");
                        _plc.WriteTag(itemPLCLoadStatus.AbsoleteItemName, 0);
                        _plc.WriteTag(ItemPLCSetOpen.AbsoleteItemName, 0);
                        
                        DialogResult = System.Windows.Forms.DialogResult.Ignore;
                        this.Close();
                    }
                    break;
                case Utils.ProcessComand.OpenCell:
                    bool getFromDone = Boolean.Parse(itemSource.First(s => s.Name == "GetFromDone").CurrentValue);
                    if (getFromDone)
                    {
                        _command = Utils.ProcessComand.None;

                        var itemPLCLoadStatus = TagList.First(s => s.Name == "PLCLoadStatus");
                        var ItemPLCSetOpen = TagList.First(s => s.Name == "PLCSetOpen");
                        _plc.WriteTag(itemPLCLoadStatus.AbsoleteItemName, 0);
                        _plc.WriteTag(ItemPLCSetOpen.AbsoleteItemName, 0);
                        
                        DialogResult = System.Windows.Forms.DialogResult.OK;
                        this.Close();
                    }
                    break;
                case Utils.ProcessComand.Error:
                    _command = Utils.ProcessComand.None;

                    waitTimer.Stop();

                    ErrorListControl displayAlarm = new ErrorListControl(AlarmsList(_errorList));
                    DevExpress.XtraEditors.XtraDialog.Show(displayAlarm, "Журнал ошибок", MessageBoxButtons.OK);

                    var itemMessageReset = TagList.First(s => s.Name == "MessageReset");
                    var itemErrorList = TagList.First(s => s.Name == "ErrorList");
                    var itemError = TagList.First(s => s.Name == "Error");

                    _plc.WriteTag(itemMessageReset.AbsoleteItemName, true);
                    _plc.WriteTag(itemError.AbsoleteItemName, false);
                    _plc.WriteEmptyTextTag(itemErrorList, (_errorList.Length > 0) ? _errorList.Length : 1);

                    _errorList = string.Empty;

                    int itemPLCSetOpenValue = 0;
                    bool isDigitStatus = Int32.TryParse(TagList.First(s => s.Name == "PLCSetOpen").CurrentValue, out itemPLCSetOpenValue);
                    
                    //определяем управляющую команду перед вызовом журнала ошибок, путем исключеия...
                    _command = (itemPLCSetOpenValue == 1) ? Utils.ProcessComand.OpenCell : Utils.ProcessComand.CloseCellFull;

                    using (OperationCustomWaitFm operationUCFromError = new OperationCustomWaitFm(_command))
                    {
                        if (operationUCFromError.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        {
                            _command = operationUCFromError.Return();

                            if (_command == Utils.ProcessComand.CellOpenAgain)
                            {
                                operationInfoLbl.Text = "Выдвинуть ячейку";
                                processInfoBS.EndEdit();
                                var ItemSetOpenAgain = TagList.First(s => s.Name == "SetOpenAgain");
                                _plc.WriteTag(ItemSetOpenAgain.AbsoleteItemName, true);
                            }
                            else
                            {
                                operationInfoLbl.Text = "Вернуть ячейку";
                                processInfoBS.EndEdit();
                                var ItemSetCloseAgain = TagList.First(s => s.Name == "SetCloseAgain");
                                _plc.WriteTag(ItemSetCloseAgain.AbsoleteItemName, true);
                            }
                        }
                    }
                    waitTimer.Start();

                    break;
                default:
                    break;
            }
        }

        private void breakBtn_Click(object sender, EventArgs e)
        {
            waitTimer.Stop();

            ProcessIndicator(Utils.ProcessComand.BreakOperation, TagList);
        }

        #region Alarm method's

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
        
    }
}