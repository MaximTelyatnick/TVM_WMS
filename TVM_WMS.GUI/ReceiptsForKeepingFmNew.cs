using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ninject;
using System.Collections;
using DevExpress.XtraTreeList;
using System.Linq;
using TVM_WMS.BLL.BusinessLogicModule;
using TVM_WMS.BLL.Interfaces;
using TVM_WMS.BLL.Services;
using TVM_WMS.BLL.DTO;
using TVM_WMS.BLL.DTO.QueryDTO;
using System.Collections.Generic;
using System.Reflection;
using System;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using System.Drawing;
using System.Data;
using TVM_WMS.BLL.Infrastructure.SerialPortListener;
using System.IO;
using TVM_WMS.BLL.Infrastructure.PlcWrapper;
using S7.Net;
using DevExpress.Utils;
using DevExpress.XtraEditors.ViewInfo;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraEditors.Repository;
using System.Threading;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid;

namespace TVM_WMS.GUI
{
    public partial class ReceiptsForKeepingFmNew : DevExpress.XtraEditors.XtraForm
    {
        private IReceiptsService receiptsService;
        private IStoreNamesService storeNamesService;
        private IWareHousesService wareHousesService;
        private IMaterialsService materialsService;
        private IReceiptAcceptancesService receiptAcceptancesService;
        private IOrdersService ordersService;
        private IUsersService usersService;
        private ICellZonesService cellZonesService;
        private IKeepingsService keepingsService;
        private IStorageGroupZonesService storageGroupZonesService;

        private BindingSource receiptsBS = new BindingSource();
        private BindingSource keepingsFirstWindBS = new BindingSource();
        private BindingSource keepingsSecondWindBS = new BindingSource();

        private Utils.ProcessInfo processInfo = new Utils.ProcessInfo();
        private Utils.ProcessComand command;

        private List<CellPresenceDTO> cellPresenceFirstList = new List<CellPresenceDTO>();
        private List<CellPresenceDTO> cellPresenceSecondList = new List<CellPresenceDTO>();
        private List<HistoryKeepingsDTO> historyKeepingFirstList = new List<HistoryKeepingsDTO>();
        private List<HistoryKeepingsDTO> historyKeepingSecondList = new List<HistoryKeepingsDTO>();
        private List<StoreNamesDTO> storeList;
        private List<StoreNamesDTO> storeHeaderList;
        private List<ReceiptsForKeepingDTO> receiptsByOrder;
        private List<DataItemsQueryDTO> tagList = new List<DataItemsQueryDTO>();
        private List<StorageGroupUsersDTO> storageGroupUsersList;
        private List<ConfigClass.BindedWindowItem> bindedWindowItemList;

        private PLC plc;
        private SerialPortManager spManager;

        private StorageGroupZonePresenceDTO cellFirstItem;
        private StorageGroupZonePresenceDTO cellSecondItem;

        private int storageId;
        private int plcDeviceId = -1;
        private int _interval;

        public ReceiptsForKeepingFmNew()
        {
            InitializeComponent();
            
            splashScreenManager.ShowWaitForm();

            LoadStoreNamesData();
                        
            storageGridRepository.DataSource = storeHeaderList;
            storageGridRepository.DisplayMember = "Name";
            storageGridRepository.ValueMember = "StoreNameId";
            
            if (storageId != 0)
            storageGridEditItem.EditValue = storageId;

            LoadReceiptsData(storageId);
            SetEnableReserveItem(storageId);

            keepingsFirstWindGrid.DataSource = null;
            keepingsSecondWindGrid.DataSource = null;

            firstWindPage.PageVisible = false;
            secondWindPage.PageVisible = false;

            OpenBarcodeDevice();
            
            if (storeHeaderList.Count > 0 && storeHeaderList.FirstOrDefault(s => s.StoreNameId == storageId).EnableAuthomatization == 1)
            {
                OpenPlcDevice();
            }
            else
            {
                firstWindPage.PageVisible = true;
                SetDeviceIndicators(Utils.DeviceIndication.Offline, 1);
                plcImageEdit.Enabled = false;
            }

            splashScreenManager.CloseWaitForm();

            pushFullCellFirstBtn.Enabled = false;
            pushPartlyCellFirstBtn.Enabled = false;
            changeCellFirstBtn.Enabled = false;
            cancelFirstBtn.Enabled = false;

            pushFullCellSecondBtn.Enabled = false;
            pushPartlyCellSecondBtn.Enabled = false;
            changeCellSecondBtn.Enabled = false;
            cancelSecondBtn.Enabled = false;

            splitContainerControl1.SplitterPosition = (this.Height - ribbonControl1.Height);
        }

        #region Method's

        #region Get data method's

        private void LoadCurrentUserInfo()
        {
            usersService = Program.kernel.Get<IUsersService>();

            storageGroupUsersList = usersService.GetStorageGroupUsers(UsersService.AuthorizatedUser.UserId).ToList();
        }

        private void LoadReceiptsData(int storeEntry)
        {
            receiptsService = Program.kernel.Get<IReceiptsService>();

            var source = receiptsService.GetReceiptsForKeeping().Where(s => s.StoreNameHeaderId == storeEntry || s.StoreNameHeaderId == 0).ToList();

            LoadCurrentUserInfo();

            if (storageGroupUsersList.Count > 0)
            {
                source = source.Where(s => storageGroupUsersList.Where(sg => sg.StorageGroupId == s.StorageGroupId).Any()).ToList();
            }

            receiptsByOrder = source;
            receiptsBS.DataSource = receiptsByOrder;
            receiptsGrid.DataSource = receiptsBS;
        }

        private void LoadStoreNamesData()
        {
            storeNamesService = Program.kernel.Get<IStoreNamesService>();

            storeList = storeNamesService.GetStoreNames().ToList();

            storeHeaderList = storeNamesService.GetBindedStoreNames();

            storeHeaderList.AddRange(storeList.Where(s => s.ParentId == null && s.EnableAuthomatization == 0));
            storeHeaderList = storeHeaderList.OrderBy(o => o.Name).ToList();

            var storageItem = storeHeaderList.FirstOrDefault();
            storageId = (storageItem != null) ? storageItem.StoreNameId : 0;
        }

        #endregion

        #region Other method's

        private void SetTooltip(int deviceIndex, string itemText, Image resImage)
        {
            SuperToolTip sTooltip = new SuperToolTip();
            ToolTipTitleItem titleItem = new ToolTipTitleItem();
            if (deviceIndex == 1)
                titleItem.Text = "Информация по контроллеру";
            else
                titleItem.Text = "Информация по сканеру";
 
            ToolTipItem item = new ToolTipItem();
            item.Image = resImage;
            item.Text = itemText;
            sTooltip.Items.Add(titleItem);
            sTooltip.Items.Add(item);
            
            if (deviceIndex == 1)
                plcImageEdit.SuperTip = sTooltip;
            else
                barcodeImageEdit.SuperTip = sTooltip;
        }

        private void BarcodeParseOperation(string source)
        {
            if (source.Substring(0, 1) == "*")
            {
                var bcSourceStr = source.Replace("\r", "").Split('*');


            }
        }

        private void SetEnableReserveItem(int storageId)
        {
            if (storageId > 0)
            {
                cellZonesService = Program.kernel.Get<ICellZonesService>();
                algorithmGroup.Items[3].Enabled = cellZonesService.FindReserveZoneByStoreName(storageId);
            }
        }

        private List<AlarmsDTO> AlarmsList(string alarmString)
        {
            var alarmList = Split(alarmString, 3)  // делим alarmString на части по 3
           .Select(s => new AlarmsDTO { AlarmNumber = Int32.Parse(s.PadLeft(2, '0')), Id = 0 })
           .ToList();

            var listText = ConfigClass.Instance.AlarmList;

            List<AlarmsDTO> errors = (from l in alarmList
                                      join a in listText on l.AlarmNumber equals a.AlarmNumber into las
                                      from a in las.DefaultIfEmpty()
                                      select new AlarmsDTO
                                      {
                                          AlarmNumber = l.AlarmNumber,
                                          AlarmText = a == null ? "<Текст сообщения об ошибке не определен>" : a.AlarmText
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
        
        #region Device method's

        private void OpenPlcDevice()
        {
            command = Utils.ProcessComand.None;

            if (storageId > 0)
            {
                var bindDbItem = ConfigClass.Instance.DeviceBindingSettingList.FirstOrDefault(s => s.StoreNameParentId == storageId && s.TypeName == "DB");

                var plcDeviceItem = ConfigClass.Instance.DataItemList.FirstOrDefault(s => s.DeviceId == ((bindDbItem != null) ? bindDbItem.DeviceId : 0));

                int currPlcDeviceId = (plcDeviceItem != null) ? plcDeviceItem.ParentDeviceId : 0;

                if (currPlcDeviceId == plcDeviceId) //не переподключаем контроллер, если устройство не изменилось
                {
                    bindedWindowItemList = ConfigClass.Instance.BindedWindowItemList.Where(s => s.StoreNameParentId == storageId).ToList();

                    secondWindPage.PageVisible = bindedWindowItemList.Any(b => b.WindowNumber == 2);
                    firstWindPage.PageVisible = bindedWindowItemList.Any(b => b.WindowNumber == 1);
                    
                    return;
                }

                if (currPlcDeviceId > 0)
                {
                    plcDeviceId = currPlcDeviceId;

                    if (ConnectPlc(plcDeviceId))
                    {
                        SetDeviceIndicators(Utils.DeviceIndication.Connected, 1);
                        plcImageEdit.Enabled = false;

                        bindedWindowItemList = ConfigClass.Instance.BindedWindowItemList.Where(s => s.StoreNameParentId == storageId).ToList();

                        firstWindPage.PageVisible = bindedWindowItemList.Any(b => b.WindowNumber == 1);
                        secondWindPage.PageVisible = bindedWindowItemList.Any(b => b.WindowNumber == 2);

                        locateBtnRepository.Buttons[0].Enabled = true;
                    }
                    else
                    {
                        SetDeviceIndicators(Utils.DeviceIndication.Disabled, 1);
                        plcImageEdit.Enabled = true;
                        locateBtnRepository.Buttons[0].Enabled = false;
                    }
                }
                else
                {
                    firstWindPage.PageVisible = false;
                    secondWindPage.PageVisible = false;

                    plcDeviceId = -1;

                    SetDeviceIndicators(Utils.DeviceIndication.Disabled, 1);
                    plcImageEdit.Enabled = true;
                    locateBtnRepository.Buttons[0].Enabled = false;

                    MessageBox.Show("Ошибка при получении настроек. Проверьте привязку оборудования к складу!", "Поключение устройств", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Ряд склада не выбран. Воспользуйтесь списком рядов для выбора.", "Поключение устройств", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void SetDeviceConnection()
        {
            if (storageId > 0)
            {
                if (plcDeviceId > 0)
                {
                    if (ConnectPlc(plcDeviceId))
                        SetDeviceIndicators(Utils.DeviceIndication.Connected, 1);
                    else
                        SetDeviceIndicators(Utils.DeviceIndication.Disabled, 1);
                    if (ConnectBarcode())
                        SetDeviceIndicators(Utils.DeviceIndication.Connected, 2);
                    else
                        SetDeviceIndicators(Utils.DeviceIndication.Disabled, 2);
                }
                else
                {
                    MessageBox.Show("Ошибка при получении настроек. Проверьте привязку оборудования к складу!", "Поключение устройств", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Выберите ряд!", "Поключение устройств", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void SetDeviceIndicators(Utils.DeviceIndication status, int deviceIndex) // 1 - PLC, 2 - Barcode
        {
            string textItem = "";
            Image resImage;

            switch (status)
            {
                case Utils.DeviceIndication.Connected:
                    if (deviceIndex == 1)
                    {
                        plcImageEdit.Glyph = indicatorCollection.Images[6];
                        resImage = indicatorCollection.Images[6];
                    }
                    else
                    {
                        barcodeImageEdit.Glyph = indicatorCollection.Images[2];
                        resImage = indicatorCollection.Images[2];
                    }
                    textItem = "Подключен";
                    break;
                case Utils.DeviceIndication.Loaded:
                    if (deviceIndex == 1)
                    {
                        plcImageEdit.Glyph = indicatorCollection.Images[7];
                        resImage = indicatorCollection.Images[7];
                    }
                    else
                    {
                        barcodeImageEdit.Glyph = indicatorCollection.Images[3];
                        resImage = indicatorCollection.Images[3];
                    }
                    textItem = "В процессе работы";
                    break;
                case Utils.DeviceIndication.Disabled:
                    if (deviceIndex == 1)
                    {
                        plcImageEdit.Glyph = indicatorCollection.Images[4];
                        resImage = indicatorCollection.Images[4];
                    }
                    else
                    {
                        barcodeImageEdit.Glyph = indicatorCollection.Images[0];
                        resImage = indicatorCollection.Images[0];
                    }
                    textItem = "Ошибка подключения";
                    break;
                default:
                    if (deviceIndex == 1)
                    {
                        plcImageEdit.Glyph = indicatorCollection.Images[5];
                        resImage = indicatorCollection.Images[5];
                    }
                    else
                    {
                        barcodeImageEdit.Glyph = indicatorCollection.Images[1];
                        resImage = indicatorCollection.Images[1];
                    }
                    textItem = "Оборудование отсутствует";
                    break;
            }

            SetTooltip(deviceIndex, textItem, resImage);
        }

        private void OpenBarcodeDevice()
        {
            command = Utils.ProcessComand.None;

            if (ConnectBarcode())
                SetDeviceIndicators(Utils.DeviceIndication.Connected, 2);
            else
                SetDeviceIndicators(Utils.DeviceIndication.Disabled, 2);
        }

        private bool ConnectBarcode()
        {
            bool result = false;

            try
            {
                if (spManager != null)
                    spManager.StopListening();

                var scannerItem = ConfigClass.Instance.BarcodeSettingList.FirstOrDefault();

                spManager = new SerialPortManager(scannerItem);

                spManager.NewSerialDataRecieved += new EventHandler<SerialDataEventArgs>(_spManager_NewSerialDataRecieved);

                spManager.StartListening();

                result = true;
            }
            catch (Exception ex)
            {
                spManager.NewSerialDataRecieved -= new EventHandler<SerialDataEventArgs>(_spManager_NewSerialDataRecieved);

                result = false;
            }

            return result;
        }

        private void DisconnectBarcode()
        {
            if (spManager != null)
            {
                spManager.NewSerialDataRecieved -= new EventHandler<SerialDataEventArgs>(_spManager_NewSerialDataRecieved);
                spManager.StopListening();
            }
        }

        private bool ConnectPlc(int plcDeviceId)
        {
            var plcSource = (ConfigClass.PlcSettingSource)ConfigClass.Instance.PlcSettingList.FirstOrDefault(s => s.DeviceId == plcDeviceId);
            var cpu = plcSource.CpuType;

            tagList = ConfigClass.Instance.DataItemList.Where(s => s.DeviceId == plcDeviceId).ToList();

            plc = new PLC();

            plc.Connect(cpu, plcSource.Ip, plcSource.Rack, plcSource.Slot);

            tagList = plc.Return();

            if (plc.ConnectionState == ConnectionStates.Online)
            {
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
                plc.Disconnect();
        }

        #endregion
        
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

        private bool ActivateDbScan(ConfigClass.BindedWindowItem windowItem)
        {
            var bindDBItem = ConfigClass.Instance.DeviceBindingSettingList.Where(s => s.ParentId == windowItem.ItemId).FirstOrDefault();

            if (bindDBItem != null)
            {
                plc.CurrentDb = Int32.Parse(ConfigClass.Instance.DeviceSettingsList.First(s => s.DeviceId == bindDBItem.DeviceId && s.KindName == "DataBlockIndex").SettingValue);
                _interval = Int32.Parse(ConfigClass.Instance.DeviceSettingsList.First(s => s.DeviceId == bindDBItem.DeviceId && s.KindName == "Interval").SettingValue);
                plc.Interval = Convert.ToDouble((int)TimeSpan.FromSeconds(_interval).TotalMilliseconds);

                tagList = ConfigClass.Instance.DataItemList.Where(s => s.DeviceId == bindDBItem.DeviceId).ToList();

                plc.TimerStart(tagList);
                
                return true;
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

        private void LocateReceipt(ReceiptsForKeepingDTO model, StorageGroupZonePresenceDTO cellItem, ConfigClass.BindedWindowItem windowItem)
        {
            wareHousesService = Program.kernel.Get<IWareHousesService>();

            if (GetCellFromStorageDone(windowItem, cellItem.NumberCell ?? 0))
            {
                storageGridEditItem.Enabled = false;

                switch (windowItem.WindowNumber)
                {
                    case 1:
                        cellPresenceFirstList = wareHousesService.GetCellPresence(cellItem.WareHouseId).ToList();
                        keepingsFirstWindBS.DataSource = cellPresenceFirstList;
                        keepingsFirstWindGrid.DataSource = keepingsFirstWindBS;
                        numberCellFirstLbl.Text = cellItem.NumberCell.ToString();
                        break;
                    case 2:
                        cellPresenceSecondList = wareHousesService.GetCellPresence(cellItem.WareHouseId).ToList();
                        keepingsSecondWindBS.DataSource = cellPresenceSecondList;
                        keepingsSecondWindGrid.DataSource = keepingsSecondWindBS;
                        numberCellSecondLbl.Text = cellItem.NumberCell.ToString();
                        break;
                }

                bool canEdit = (model.FlagAcceptance == 1);

                ConfirmQuantityDTO cqdto = new ConfirmQuantityDTO
                {
                    ReceiptAcceptanceId = model.AcceptanceId,
                    Quantity = (decimal)model.QuantityForKeep,
                    Article = model.Article,
                    MaterialName = model.Name,
                    UnitLocalName = model.UnitLocalName,
                    OldWeight = 0,
                    CurrentWeight = 0
                };

                using (ConfirmQuantityFm confirmQuantityFm = new ConfirmQuantityFm(plc, spManager, cqdto, canEdit))
                {
                    if (confirmQuantityFm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        cqdto = confirmQuantityFm.Return();
                                                
                        receiptsGridView.BeginDataUpdate();

                        receiptsByOrder.Where(r => r.AcceptanceId == model.AcceptanceId).Select(c => { c.QuantityForKeep -= cqdto.Quantity; return c; }).ToList();

                        receiptsGridView.EndDataUpdate();

                        int rowHandle;

                        switch (windowItem.WindowNumber)
                        {
                            case 1:
                                keepingsFirstWindGridView.BeginDataUpdate();

                                if (cellPresenceFirstList.Any(c => c.ReceiptAcceptanceId == model.AcceptanceId))
                                {
                                    cellPresenceFirstList.Where(c => c.ReceiptAcceptanceId == model.AcceptanceId).Select(c => { c.QuantityStore += cqdto.Quantity; 
                                        c.QuantityChanged += cqdto.Quantity; 
                                        c.CurrentWeight = cqdto.CurrentWeight; 
                                        c.OldWeight = cqdto.OldWeight; return c; }).ToList();

                                    historyKeepingFirstList.Add(new HistoryKeepingsDTO()
                                    {
                                        KeepingId = cellPresenceFirstList.First(c => c.ReceiptAcceptanceId == model.AcceptanceId).KeepingId,
                                        WareHouseId = cellItem.WareHouseId,
                                        ReceiptAcceptanceId = model.AcceptanceId,
                                        Quantity = cqdto.Quantity,
                                        DateAdded = DateTime.Now,
                                        UserId = UsersService.AuthorizatedUser.UserId
                                    });
                                }
                                else
                                {
                                    cellPresenceFirstList.Add(new CellPresenceDTO()
                                    {
                                        KeepingId = 0,
                                        ReceiptAcceptanceId = model.AcceptanceId,
                                        ReceiptId = model.ReceiptId,
                                        OrderId = model.OrderId,
                                        Article = model.Article,
                                        MaterialName = model.Name,
                                        MaterialId = model.MaterialId,
                                        OrderDate = model.OrderDate,
                                        OrderNumber = model.OrderNumber,
                                        UnitLocalName = model.UnitLocalName,
                                        WareHouseId = cellItem.WareHouseId,
                                        QuantityKeeping = 0,
                                        QuantityStore = cqdto.Quantity,
                                        QuantityChanged = cqdto.Quantity,
                                        OldWeight = cqdto.OldWeight,
                                        CurrentWeight = cqdto.CurrentWeight
                                    });
                                    
                                    historyKeepingFirstList.Add(new HistoryKeepingsDTO()
                                    {
                                        KeepingId = 0,
                                        WareHouseId = cellItem.WareHouseId,
                                        ReceiptAcceptanceId = model.AcceptanceId,
                                        Quantity = cqdto.Quantity,
                                        DateAdded = DateTime.Now,
                                        UserId = UsersService.AuthorizatedUser.UserId
                                    });
                                }

                                keepingsFirstWindBS.CurrencyManager.Refresh();

                                keepingsFirstWindGridView.EndDataUpdate();

                                rowHandle = keepingsFirstWindGridView.LocateByValue("ReceiptAcceptanceId", model.AcceptanceId);
                                keepingsFirstWindGridView.FocusedRowHandle = rowHandle;
                                
                                pushFullCellFirstBtn.Enabled = true;
                                pushPartlyCellFirstBtn.Enabled = ((int)algorithmGroupItem.EditValue != 3) ? true : false;
                                changeCellFirstBtn.Enabled = true;
                                cancelFirstBtn.Enabled = true;

                                break;
                            case 2:
                                keepingsSecondWindGridView.BeginDataUpdate();

                                if (cellPresenceSecondList.Any(c => c.ReceiptAcceptanceId == model.AcceptanceId))
                                {
                                    cellPresenceSecondList.Where(c => c.ReceiptAcceptanceId == model.AcceptanceId).Select(c => { c.QuantityStore += cqdto.Quantity; 
                                        c.QuantityChanged += cqdto.Quantity;
                                        c.CurrentWeight = cqdto.CurrentWeight;
                                        c.OldWeight = cqdto.OldWeight;
                                        return c; }).ToList();

                                    historyKeepingSecondList.Add(new HistoryKeepingsDTO()
                                    {
                                        KeepingId = cellPresenceSecondList.First(c => c.ReceiptAcceptanceId == model.AcceptanceId).KeepingId,
                                        WareHouseId = cellItem.WareHouseId,
                                        ReceiptAcceptanceId = model.AcceptanceId,
                                        Quantity = cqdto.Quantity,
                                        DateAdded = DateTime.Now,
                                        UserId = UsersService.AuthorizatedUser.UserId
                                    });
                                }
                                else
                                {
                                    cellPresenceSecondList.Add(new CellPresenceDTO()
                                    {
                                        KeepingId = 0,
                                        ReceiptAcceptanceId = model.AcceptanceId,
                                        Article = model.Article,
                                        MaterialName = model.Name,
                                        MaterialId = model.MaterialId,
                                        OrderDate = model.OrderDate,
                                        OrderNumber = model.OrderNumber,
                                        UnitLocalName = model.UnitLocalName,
                                        WareHouseId = cellItem.WareHouseId,
                                        QuantityKeeping = 0,
                                        QuantityStore = cqdto.Quantity,
                                        QuantityChanged = cqdto.Quantity,
                                        OldWeight = cqdto.OldWeight,
                                        CurrentWeight = cqdto.CurrentWeight
                                    });
                                    
                                    historyKeepingSecondList.Add(new HistoryKeepingsDTO()
                                    {
                                        KeepingId = 0,
                                        WareHouseId = cellItem.WareHouseId,
                                        ReceiptAcceptanceId = model.AcceptanceId,
                                        Quantity = cqdto.Quantity,
                                        DateAdded = DateTime.Now,
                                        UserId = UsersService.AuthorizatedUser.UserId
                                    });
                                }

                                keepingsSecondWindBS.CurrencyManager.Refresh();

                                keepingsSecondWindGridView.EndDataUpdate();

                                rowHandle = keepingsSecondWindGridView.LocateByValue("ReceiptAcceptanceId", model.AcceptanceId);
                                keepingsSecondWindGridView.FocusedRowHandle = rowHandle;
                                                                
                                pushFullCellSecondBtn.Enabled = true;
                                pushPartlyCellSecondBtn.Enabled = ((int)algorithmGroupItem.EditValue != 3) ? true : false;
                                changeCellSecondBtn.Enabled = true;
                                cancelSecondBtn.Enabled = true;

                                break;
                        }
                    }
                    else
                    {
                        if (windowItem.WindowNumber == 1)
                        {
                            pushFullCellFirstBtn.Enabled = true;
                            pushPartlyCellFirstBtn.Enabled = ((int)algorithmGroupItem.EditValue != 3) ? true : false;
                            changeCellFirstBtn.Enabled = true;
                            cancelFirstBtn.Enabled = true;
                        }
                        else
                        {
                            pushFullCellSecondBtn.Enabled = true;
                            pushPartlyCellSecondBtn.Enabled = ((int)algorithmGroupItem.EditValue != 3) ? true : false;
                            changeCellSecondBtn.Enabled = true;
                            cancelSecondBtn.Enabled = true;
                        }
                    }

                    plc.TimerStop();
                }
            }
            else
            {
                //MessageBox.Show("Произошла ошибка при вызове кассеты со склада, либо действие отменено.", "Вызов кассеты со склада", MessageBoxButtons.OK, MessageBoxIcon.Error);

                storageGridEditItem.Enabled = true;

                return;
            }
               
        }

        private void AddingReceipt(ReceiptsForKeepingDTO model, StorageGroupZonePresenceDTO cellItem, ConfigClass.BindedWindowItem windowItem)
        {
            if (ActivateDbScan(windowItem))
            {

                bool canEdit = (model.FlagAcceptance == 1);

                ConfirmQuantityDTO cqdto = new ConfirmQuantityDTO
                {
                    ReceiptAcceptanceId = model.AcceptanceId,
                    Quantity = (decimal)model.QuantityForKeep,
                    Article = model.Article,
                    MaterialName = model.Name,
                    UnitLocalName = model.UnitLocalName,
                    OldWeight = 0,
                    CurrentWeight = 0
                };

                using (ConfirmQuantityFm confirmQuantityFm = new ConfirmQuantityFm(plc, spManager, cqdto, canEdit))
                {
                    if (confirmQuantityFm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        cqdto = confirmQuantityFm.Return();

                        receiptsGridView.BeginDataUpdate();

                        receiptsByOrder.Where(r => r.AcceptanceId == model.AcceptanceId).Select(c => { c.QuantityForKeep -= cqdto.Quantity; return c; }).ToList();

                        receiptsGridView.EndDataUpdate();

                        int rowHandle;

                        switch (windowItem.WindowNumber)
                        {
                            case 1:
                                keepingsFirstWindGridView.BeginDataUpdate();

                                if (cellPresenceFirstList.Any(c => c.ReceiptAcceptanceId == model.AcceptanceId))
                                {
                                    cellPresenceFirstList.Where(c => c.ReceiptAcceptanceId == model.AcceptanceId).Select(c => { c.QuantityStore += cqdto.Quantity; 
                                        c.QuantityChanged += cqdto.Quantity;
                                        c.CurrentWeight = cqdto.CurrentWeight;
                                        c.OldWeight = cqdto.OldWeight;
                                        return c; }).ToList();

                                    if (historyKeepingFirstList.Any(c => c.ReceiptAcceptanceId == model.AcceptanceId))
                                    {
                                        historyKeepingFirstList.Where(c => c.ReceiptAcceptanceId == model.AcceptanceId).Select(h => { h.Quantity += cqdto.Quantity; return h; }).ToList();
                                    }
                                    else
                                    {
                                        historyKeepingFirstList.Add(new HistoryKeepingsDTO()
                                        {
                                            KeepingId = cellPresenceFirstList.First(c => c.ReceiptAcceptanceId == model.AcceptanceId).KeepingId,
                                            WareHouseId = cellItem.WareHouseId,
                                            ReceiptAcceptanceId = model.AcceptanceId,
                                            Quantity = cqdto.Quantity,
                                            DateAdded = DateTime.Now,
                                            UserId = UsersService.AuthorizatedUser.UserId
                                        }); 
                                    }
                                }
                                else
                                {
                                    cellPresenceFirstList.Add(new CellPresenceDTO()
                                    {
                                        KeepingId = 0,
                                        ReceiptAcceptanceId = model.AcceptanceId,
                                        ReceiptId = model.ReceiptId,
                                        OrderId = model.OrderId,
                                        Article = model.Article,
                                        MaterialId = model.MaterialId,
                                        MaterialName = model.Name,
                                        OrderDate = model.OrderDate,
                                        OrderNumber = model.OrderNumber,
                                        UnitLocalName = model.UnitLocalName,
                                        WareHouseId = cellItem.WareHouseId,
                                        QuantityKeeping = 0,
                                        QuantityStore = cqdto.Quantity,
                                        QuantityChanged = cqdto.Quantity,
                                        OldWeight = cqdto.OldWeight,
                                        CurrentWeight = cqdto.CurrentWeight
                                    });
                                    
                                    historyKeepingFirstList.Add(new HistoryKeepingsDTO()
                                    {
                                        KeepingId = 0,
                                        WareHouseId = cellItem.WareHouseId,
                                        ReceiptAcceptanceId = model.AcceptanceId,
                                        Quantity = cqdto.Quantity,
                                        DateAdded = DateTime.Now,
                                        UserId = UsersService.AuthorizatedUser.UserId
                                    });
                                }

                                keepingsFirstWindBS.CurrencyManager.Refresh();

                                keepingsFirstWindGridView.EndDataUpdate();

                                rowHandle = keepingsFirstWindGridView.LocateByValue("ReceiptAcceptanceId", model.AcceptanceId);
                                keepingsFirstWindGridView.FocusedRowHandle = rowHandle;

                                break;
                            case 2:
                                keepingsSecondWindGridView.BeginDataUpdate();

                                if (cellPresenceSecondList.Any(c => c.ReceiptAcceptanceId == model.AcceptanceId))
                                {
                                    cellPresenceSecondList.Where(c => c.ReceiptAcceptanceId == model.AcceptanceId).Select(c => { c.QuantityStore += cqdto.Quantity; 
                                        c.QuantityChanged += cqdto.Quantity;
                                        c.CurrentWeight = cqdto.CurrentWeight;
                                        c.OldWeight = cqdto.OldWeight;
                                        return c; }).ToList();

                                    if (historyKeepingSecondList.Any(c => c.ReceiptAcceptanceId == model.AcceptanceId))
                                    {
                                        historyKeepingSecondList.Where(c => c.ReceiptAcceptanceId == model.AcceptanceId).Select(h => { h.Quantity += cqdto.Quantity; return h; }).ToList();
                                    }
                                    else
                                    {
                                        historyKeepingFirstList.Add(new HistoryKeepingsDTO()
                                        {
                                            KeepingId = cellPresenceFirstList.First(c => c.ReceiptAcceptanceId == model.AcceptanceId).KeepingId,
                                            WareHouseId = cellItem.WareHouseId,
                                            ReceiptAcceptanceId = model.AcceptanceId,
                                            Quantity = cqdto.Quantity,
                                            DateAdded = DateTime.Now,
                                            UserId = UsersService.AuthorizatedUser.UserId
                                        });
                                    }
                                }
                                else
                                {
                                    cellPresenceSecondList.Add(new CellPresenceDTO()
                                    {
                                        KeepingId = 0,
                                        ReceiptAcceptanceId = model.AcceptanceId,
                                        Article = model.Article,
                                        MaterialName = model.Name,
                                        MaterialId = model.MaterialId,
                                        OrderDate = model.OrderDate,
                                        OrderNumber = model.OrderNumber,
                                        UnitLocalName = model.UnitLocalName,
                                        WareHouseId = cellItem.WareHouseId,
                                        QuantityKeeping = 0,
                                        QuantityStore = cqdto.Quantity,
                                        QuantityChanged = cqdto.Quantity,
                                        OldWeight = cqdto.OldWeight,
                                        CurrentWeight = cqdto.CurrentWeight
                                    });
                                                                        
                                    historyKeepingSecondList.Add(new HistoryKeepingsDTO()
                                    {
                                        KeepingId = 0,
                                        WareHouseId = cellItem.WareHouseId,
                                        ReceiptAcceptanceId = model.AcceptanceId,
                                        Quantity = cqdto.Quantity,
                                        DateAdded = DateTime.Now,
                                        UserId = UsersService.AuthorizatedUser.UserId
                                    });
                                }

                                keepingsSecondWindBS.CurrencyManager.Refresh();

                                keepingsSecondWindGridView.EndDataUpdate();

                                rowHandle = keepingsSecondWindGridView.LocateByValue("ReceiptAcceptanceId", model.AcceptanceId);
                                keepingsSecondWindGridView.FocusedRowHandle = rowHandle;

                                break;
                        }
                    }

                    plc.TimerStop();
                }
            }
            else
            {
                MessageBox.Show("Произошла ошибка при обмене данными с контроллером.", "Получение данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private bool OpenCell(List<DataItemsQueryDTO> currTagList, int numberCell, int interval, ConfigClass.BindedWindowItem windowItem)
        {
            currTagList = plc.Return();

            int currPLCLoadStatus = 0;
            bool isDigitStatus = Int32.TryParse(currTagList.First(s => s.Name == "PLCLoadStatus").CurrentValue, out currPLCLoadStatus);

            if (currPLCLoadStatus == 1)
            {
                MessageBox.Show("Манипулятор находится в движении.Повторите попытку позже.", "Выполнение операции", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            try
            {
            var itemCellNumber = currTagList.First(s => s.Name == "CellNumber");
            var itemPLCDropoffWind = currTagList.First(s => s.Name == "PLCDropoffWind");
            var ItemPLCSetOpen = currTagList.First(s => s.Name == "PLCSetOpen");
                var itemPLCLoadStatus = currTagList.First(s => s.Name == "PLCLoadStatus");

                plc.WriteTag(itemCellNumber.AbsoleteItemName, numberCell);
                plc.WriteTag(itemPLCDropoffWind.AbsoleteItemName, windowItem.WindowNumber);
                plc.WriteTag(ItemPLCSetOpen.AbsoleteItemName, 1);
                plc.WriteTag(itemPLCLoadStatus.AbsoleteItemName, 1);
            }
            catch (Exception ex)
            {
                MessageBox.Show("При обмене данными с контроллером возникла ошибка.\n Проверьте подключение и повторите попытку.\n" + ex.Message, "Выполнение операции", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            Thread.Sleep(1500);

            currTagList = plc.Return();

            bool error = false;
            bool result = Boolean.TryParse(currTagList.First(s => s.Name == "Error").CurrentValue, out error);
            string _errorList = currTagList.First(s => s.Name == "ErrorList").CurrentValue.Replace("\0", String.Empty);

            if (error || _errorList.Length > 0)
            {
                ErrorListControl displayAlarm = new ErrorListControl(AlarmsList(_errorList));
                DevExpress.XtraEditors.XtraDialog.Show(displayAlarm, "Журнал ошибок", MessageBoxButtons.OK);
                
                try
            {
                    plc.ResetAllVar();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("При обмене данными с контроллером возникла ошибка.\n Проверьте подключение и повторите попытку.\n" + ex.Message, "Выполнение операции", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                return false;
            }
            else
            {
                command = Utils.ProcessComand.OpenCell;

                try
                {
                    processInfo.CellNumber = numberCell;
                    processInfo.OperationName = "Выдвинуть кассету";
                    processInfo.WindowNumber = windowItem.WindowNumber;
                    processInfo.StackerName = ConfigClass.Instance.DeviceBindingSettingList.FirstOrDefault(b => b.Id == windowItem.ParentItemId).Name;

                    using (WaitDialogFm form = new WaitDialogFm(plc, command, (int)TimeSpan.FromSeconds(interval).TotalMilliseconds, processInfo))
                    {
                        DialogResult formResult = form.ShowDialog();
                        
                        if (formResult == System.Windows.Forms.DialogResult.OK || formResult == System.Windows.Forms.DialogResult.Ignore)
                        {
                            //MessageBox.Show(String.Format("Операция выполнена успешно"), "Выполнение операции", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            bindedWindowItemList.Where(b => b.DeviceId == windowItem.DeviceId).Select(s => { s.BusyWindow = true; return s; }).ToList();
                            return true;
                        }
                        else
                        {
                            //MessageBox.Show(String.Format("Операция не выполнена"), "Выполнение операции", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private bool CloseCell(List<DataItemsQueryDTO> currTagList, int numberCell, int interval, ConfigClass.BindedWindowItem windowItem)
        {
            currTagList = plc.Return();

            int currPLCLoadStatus = 0;
            bool isDigitStatus = Int32.TryParse(currTagList.First(s => s.Name == "PLCLoadStatus").CurrentValue, out currPLCLoadStatus);

            if (currPLCLoadStatus == 1)
            {
                MessageBox.Show("Манипулятор находится в движении.Повторите попытку позже.", "Выполнение операции", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            int currCell = 0;
            bool isDigit = Int32.TryParse(currTagList.First(s => s.Name == "CellNumber").CurrentValue, out currCell);

            if (currCell == 0)
            {
                MessageBox.Show("Кассета отсутствует на столе выдачи.\n Выдвиньте сначала кассету и повторите попытку.", "Выполнение операции", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            try
            {
                var itemSetClose = currTagList.First(s => s.Name == "PLCSetClose");
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

            currTagList = plc.Return();

            bool error = false;
            bool result = Boolean.TryParse(currTagList.First(s => s.Name == "Error").CurrentValue, out error);
            string _errorList = currTagList.First(s => s.Name == "ErrorList").CurrentValue.Replace("\0", String.Empty);

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

                    return false;
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

                    using (WaitDialogFm form = new WaitDialogFm(plc, command, (int)TimeSpan.FromSeconds(interval).TotalMilliseconds, processInfo))
                    {
                        DialogResult formResult = form.ShowDialog();
                        
                        if (formResult == System.Windows.Forms.DialogResult.OK || formResult == System.Windows.Forms.DialogResult.Ignore)
                        {
                            //MessageBox.Show(String.Format("Операция выполнена успешно"), "Выполнение операции", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            bindedWindowItemList.Where(b => b.DeviceId == windowItem.DeviceId).Select(s => { s.BusyWindow = false; return s; }).ToList();
                            return true;
                        }
                        else
                        {
                            //MessageBox.Show(String.Format("Операция не выполнена"), "Выполнение операции", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            try
            {
                var itemSetClose = currTagList.First(s => s.Name == "PLCSetClose");
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

            currTagList = plc.Return();

            bool error = false;
            bool result = Boolean.TryParse(currTagList.First(s => s.Name == "Error").CurrentValue, out error);
            string _errorList = currTagList.First(s => s.Name == "ErrorList").CurrentValue.Replace("\0", String.Empty);

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

                    return false;
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
                    var itemPLCLoadStatus = currTagList.First(s => s.Name == "PLCLoadStatus");
                    plc.WriteTag(itemPLCLoadStatus.AbsoleteItemName, 1);

                    command = Utils.ProcessComand.CancelOperation;

                    processInfo.CellNumber = Int32.Parse(currTagList.First(s => s.Name == "CellNumber").CurrentValue);
                    processInfo.OperationName = "Отменить операцию и вернуть кассету";
                    processInfo.WindowNumber = windowItem.WindowNumber;
                    processInfo.StackerName = ConfigClass.Instance.DeviceBindingSettingList.FirstOrDefault(b => b.Id == windowItem.ParentItemId).Name;

                    using (WaitDialogFm form = new WaitDialogFm(plc, command, (int)TimeSpan.FromSeconds(_interval).TotalMilliseconds, processInfo))
                    {
                        DialogResult formResult = form.ShowDialog();

                        if (formResult == System.Windows.Forms.DialogResult.OK || formResult == System.Windows.Forms.DialogResult.Retry)
                        {
                            //MessageBox.Show(String.Format("Операция выполнена успешно"), "Выполнение операции", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            bindedWindowItemList.Where(b => b.DeviceId == windowItem.DeviceId).Select(s => { s.BusyWindow = false; return s; }).ToList();
                            plc.ResetAllVar();
                            
                            return true;
                        }
                        else
                        {
                            //MessageBox.Show(String.Format("Операция не выполнена"), "Выполнение операции", MessageBoxButtons.OK, MessageBoxIcon.Error);

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

        private bool SaveKeeping(List<CellPresenceDTO> itemList, List<ReceiptsForKeepingDTO> receiptList, List<HistoryKeepingsDTO> historyKeepingList, bool complited)
        {
            keepingsService = Program.kernel.Get<IKeepingsService>();
            ordersService = Program.kernel.Get<IOrdersService>();
            receiptsService = Program.kernel.Get<IReceiptsService>();
            receiptAcceptancesService = Program.kernel.Get<IReceiptAcceptancesService>();
            wareHousesService = Program.kernel.Get<IWareHousesService>();

            KeepingsDTO keepingItem = new KeepingsDTO();
            WareHousesDTO whdto = new WareHousesDTO();
            OrdersDTO odto = new OrdersDTO();
            ReceiptsDTO rdto = new ReceiptsDTO();
            ReceiptAcceptancesDTO radto = new ReceiptAcceptancesDTO();

            List<CellPresenceDTO> _itemList = itemList;

            decimal remainsAcceptance;
            decimal totalQuantityFromKeeping;
            bool isReceiptPartlyKeep;
            bool isReceiptAsseptancePartlyKeep;
            int currKeepingId;

            try
            {
                foreach (var item in _itemList)
                {
                    keepingItem = new KeepingsDTO()
                    {
                        KeepingId = item.KeepingId,
                        WareHouseId = item.WareHouseId,
                        ReceiptAcceptanceId = item.ReceiptAcceptanceId,
                        DataAdded = DateTime.Now,
                        Quantity = item.QuantityStore
                    };

                    //update Keeping
                    if (item.KeepingId == 0)
                    {
                        currKeepingId = keepingsService.KeepingCreate(keepingItem);
                    }
                    else
                    {
                        keepingsService.KeepingUpdate(keepingItem);
                        currKeepingId = item.KeepingId;
                    }
                    
                    //update HistoryKeeping collection
                    historyKeepingList.Where(h => h.ReceiptAcceptanceId == item.ReceiptAcceptanceId).Select(c => { c.KeepingId = currKeepingId; return c; }).ToList();

                    //update ReceiptAcceptances
                    radto = receiptAcceptancesService.GetReceiptAcceptanceById((int)item.ReceiptAcceptanceId);
                    remainsAcceptance = receiptList.First(r => r.AcceptanceId == item.ReceiptAcceptanceId).QuantityForKeep;
                    radto.StatusId = (remainsAcceptance == 0) ? 7 : 9;
                    receiptAcceptancesService.ReceiptAcceptanceUpdate(radto);

                    //update Receipts 
                    rdto = receiptsService.GetReceiptById(item.ReceiptId);
                    totalQuantityFromKeeping = keepingsService.GetQuantitySumByReceiptId(item.ReceiptId);
                    rdto.StatusId = ((rdto.Quantity - totalQuantityFromKeeping) == 0) ? 7 : 6;
                    receiptsService.ReceiptUpdate(rdto);
                    
                    //update Orders
                    odto = ordersService.GetOrderById(item.OrderId);
                    
                    isReceiptPartlyKeep = receiptsService.GetReceiptsByOrderId(odto.OrderId).Any(s => s.StatusId <= 6); // проверяем на наличие приходы со статусом "принято"
                    isReceiptAsseptancePartlyKeep = receiptAcceptancesService.GetReceiptAcceptanceByOrderId(odto.OrderId).Any(s => s.StatusId == 7 || s.StatusId == 9); // проверяем на наличие комплектов со статусом "на хранении"

                    if (isReceiptPartlyKeep && isReceiptAsseptancePartlyKeep)
                    {
                        odto.StatusId = 4;
                        ordersService.OrderUpdate(odto);
                    }
                    else if (!isReceiptPartlyKeep)
                    {
                        odto.StatusId = 3;
                        ordersService.OrderUpdate(odto);
                    }
                    
                }

                //update WareHouses
                whdto = wareHousesService.GetWareHouseById(itemList[0].WareHouseId);
                whdto.CurrentWeight = itemList.Max(ra => ra.CurrentWeight);
                whdto.LoadingStatusId = (complited) ? 3 : 2;
                wareHousesService.WareHousesUpdate(whdto);

                if (historyKeepingList.Count > 0)
                    keepingsService.HistoryKeepingCreateRange(historyKeepingList.Where(h => h.Quantity > 0).ToList());

                return true;
            }
            catch (Exception)
            {

                return false;
            }
            
        }

        #endregion

        #endregion
        
        #region Event's

        #region Device event's

        private void _spManager_NewSerialDataRecieved(object sender, SerialDataEventArgs e)
        {
            if (this.InvokeRequired)
            {
                // Using this.Invoke causes deadlock when closing serial port, and BeginInvoke is good practice anyway.
                this.BeginInvoke(new EventHandler<SerialDataEventArgs>(_spManager_NewSerialDataRecieved), new object[] { sender, e });
                return;
            }

            string str = Encoding.UTF8.GetString(e.Data);

            BarcodeParseOperation(str);
        }

        #endregion

        #region Button click event's

        private void barcodeImageEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenBarcodeDevice();
        }

        private void plcImageEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenPlcDevice();
        }

        private void showZonePresenceBtn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (receiptsBS.Count > 0 && ((ReceiptsForKeepingDTO)receiptsBS.Current).MaterialEntryStatus == 0)
            {
                new ZonePresenceFm(((ReceiptsForKeepingDTO)receiptsBS.Current).ZoneNameId ?? 0, ((ReceiptsForKeepingDTO)receiptsBS.Current).ZoneName).ShowDialog();
        }
            else
            {
                MessageBox.Show("Данный материал/складская группа не входит в зону хранения. \nПроверьте данные.", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void refreshDataBtn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            splashScreenManager.ShowWaitForm();

            //Refresh StorageList data
            int curStorageId = storageId;
                        
            LoadStoreNamesData();

            if (storageId > 0)
            {
                storageId = storeHeaderList.Any(s => s.StoreNameId == curStorageId) ? curStorageId : storageId;
            }

            storageGridRepository.DataSource = storeHeaderList;

            if (storageId > 0)
                storageGridEditItem.EditValue = storageId;
            else
                storageGridEditItem.EditValue = null;
            //--------------------------------------

            LoadReceiptsData(storageId);
            SetEnableReserveItem(storageId);

            splashScreenManager.CloseWaitForm();
        }

        private void locateBtnRepository_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if ((int)modeGroupItem.EditValue == 0) //автоматический
            {
                if (storeHeaderList.FirstOrDefault(s => s.StoreNameId == storageId).EnableAuthomatization == 1)
                {
                    bool locateIsDone = false;

                    cellZonesService = Program.kernel.Get<ICellZonesService>();

                    var storesByZoneList = cellZonesService.GetStoreNamesByZoneId(((ReceiptsForKeepingDTO)receiptsBS.Current).ZoneNameId ?? 0);

                    //определяем окно выдачи
                    var windowListByStoreNameId = bindedWindowItemList
                        .Where(w => storesByZoneList.Contains(w.StoreNameId))
                        .OrderBy(o => o.WindowNumber)
                        .ToList();

                    var windowDistinctList = windowListByStoreNameId
                                .GroupBy(g => g.DeviceId)
                                .Select(s => s.First())
                                .OrderBy(o => o.BusyWindow)
                                .ToList();

                    switch ((int)algorithmGroupItem.EditValue)
                    {
                        #region 0 - Free cell algorithm

                        case 0:
                            locateIsDone = false;

                            foreach (var windItem in windowDistinctList)
                            {
                                if (windItem.BusyWindow)
                                {
                                    var currZoneNameId = (windItem.WindowNumber == 1) ? cellFirstItem.ZoneNameId : cellSecondItem.ZoneNameId;

                                    if (((ReceiptsForKeepingDTO)receiptsBS.Current).ZoneNameId != currZoneNameId)
                                    {
                                        continue;
                                    }

                                    var checkCount = (windItem.WindowNumber == 1) ? (cellPresenceFirstList.Count > 0) : (cellPresenceSecondList.Count > 0);

                                    if (checkCount)
                    {
                                        continue;
                                    }

                                    var currCellItem = (windItem.WindowNumber == 1) ? cellFirstItem : cellSecondItem;
                                    AddingReceipt((ReceiptsForKeepingDTO)receiptsBS.Current, currCellItem, windItem);

                                    locateIsDone = true;

                                    break;
                    }
                    else
                    {
                                    var storesByWindowList = bindedWindowItemList.Where(s => s.DeviceId == windItem.DeviceId).Select(s => s.StoreNameId).ToList();

                                    //определяем номер ячейки
                                    storageGroupZonesService = Program.kernel.Get<IStorageGroupZonesService>();

                                    var cellList = storageGroupZonesService.GetStorageGroupZonePresence(((ReceiptsForKeepingDTO)receiptsBS.Current).ZoneNameId ?? 0, ((ReceiptsForKeepingDTO)receiptsBS.Current).MaterialId, 0);

                                    var currCellItem = cellList.FirstOrDefault(c => storesByWindowList.Contains(c.StoreNameId));

                                    if (currCellItem != null)
                                    {
                                        switch (windItem.WindowNumber)
                        {
                                            case 1:
                                                cellFirstItem = currCellItem;
                                                LocateReceipt((ReceiptsForKeepingDTO)receiptsBS.Current, cellFirstItem, windItem);
                                                xtraTabControl1.SelectedTabPage = firstWindPage;
                        
                                                break;
                                            case 2:
                                                cellSecondItem = currCellItem;
                                                LocateReceipt((ReceiptsForKeepingDTO)receiptsBS.Current, cellSecondItem, windItem);
                                                xtraTabControl1.SelectedTabPage = secondWindPage;
                                                break;
                                        }

                                        locateIsDone = true;

                                        break;
                                    }
                                }
                            }

                            if (!locateIsDone)
                                MessageBox.Show("Не удалось выполнить размещение по одной из причин:\n" +
                                    " - зона хранения не подходит для размещения данного материала;\n" +
                                    "- на кассете размещены материалы;\n" +
                                    " - подходящих ячеек не определено.\nВыберите другой способ раскладки или проверьте загруженность зоны хранения.", "Размещение", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            break;

                        #endregion

                        #region 1 - Find cell with current material
                                                        
                        case 1:
                            locateIsDone = false;

                            foreach (var windItem in windowDistinctList)
                            {
                                if (windItem.BusyWindow)
                            {
                                    var currZoneNameId = (windItem.WindowNumber == 1) ? cellFirstItem.ZoneNameId : cellSecondItem.ZoneNameId;

                                    if (((ReceiptsForKeepingDTO)receiptsBS.Current).ZoneNameId != currZoneNameId)
                                    {
                                        //MessageBox.Show("Зона хранения не подходит для размещения данного материала.\nВыберите другой материал или смените кассету.", "Размещение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        return;
                            }

                                    var checkMaterialEntry = (windItem.WindowNumber == 1) ?
                                        (!cellPresenceFirstList.Any(cp => cp.MaterialId == ((ReceiptsForKeepingDTO)receiptsBS.Current).MaterialId)) :
                                        (!cellPresenceSecondList.Any(cp => cp.MaterialId == ((ReceiptsForKeepingDTO)receiptsBS.Current).MaterialId));

                                    if (checkMaterialEntry)
                            {
                                        // MessageBox.Show("На кассете отсутствует одноименная номенклатура.\nВыберите подходящий алгоритм раскладки или смените кассету.", "Размещение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }

                                    var currCellItem = (windItem.WindowNumber == 1) ? cellFirstItem : cellSecondItem;
                                    AddingReceipt((ReceiptsForKeepingDTO)receiptsBS.Current, currCellItem, windItem);

                                    locateIsDone = true;

                                    break;
                        }
                        else
                        {
                                    var storesByWindowList = bindedWindowItemList.Where(s => s.DeviceId == windItem.DeviceId).Select(s => s.StoreNameId).ToList();

                                    //определяем номер ячейки
                                    storageGroupZonesService = Program.kernel.Get<IStorageGroupZonesService>();

                                    var cellList = storageGroupZonesService.GetStorageGroupZonePresence(((ReceiptsForKeepingDTO)receiptsBS.Current).ZoneNameId ?? 0, ((ReceiptsForKeepingDTO)receiptsBS.Current).MaterialId, 1);

                                    var currCellItem = cellList.FirstOrDefault(c => storesByWindowList.Contains(c.StoreNameId));

                                    if (currCellItem != null)
                                    {
                                        switch (windItem.WindowNumber)
                                        {
                                            case 1:
                                                cellFirstItem = currCellItem;
                                                LocateReceipt((ReceiptsForKeepingDTO)receiptsBS.Current, cellFirstItem, windItem);
                                                break;
                                            case 2:
                                                cellSecondItem = currCellItem;
                                                LocateReceipt((ReceiptsForKeepingDTO)receiptsBS.Current, cellSecondItem, windItem);
                                                break;
                                        }

                                        locateIsDone = true;

                                        break;
                                    }
                                }
                            }

                            if (!locateIsDone)
                                MessageBox.Show("Не удалось выполнить размещение по одной из причин:\n" +
                                    " - зона хранения не подходит для размещения данного материала;\n" +
                                    "- на кассете отсутствует одноименная номенклатура;\n" +
                                    " - подходящих ячеек не определено.\nВыберите другой способ раскладки или проверьте загруженность зоны хранения.", "Размещение", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            break;

                        #endregion

                        #region 2 - Find cell with any material

                        case 2:
                            locateIsDone = false;

                            foreach (var windItem in windowDistinctList)
                            {
                                if (windItem.BusyWindow)
                                {
                                    var currZoneNameId = (windItem.WindowNumber == 1) ? cellFirstItem.ZoneNameId : cellSecondItem.ZoneNameId;

                                    if (((ReceiptsForKeepingDTO)receiptsBS.Current).ZoneNameId != currZoneNameId)
                                    {
                                        //MessageBox.Show("Зона хранения не подходит для размещения данного материала.\nВыберите другой материал или смените кассету.", "Размещение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }

                                    var currCellItem = (windItem.WindowNumber == 1) ? cellFirstItem : cellSecondItem;
                                    AddingReceipt((ReceiptsForKeepingDTO)receiptsBS.Current, currCellItem, windItem);

                                    locateIsDone = true;

                                    break;
                                }
                                else
                            {
                                    var storesByWindowList = bindedWindowItemList.Where(s => s.DeviceId == windItem.DeviceId).Select(s => s.StoreNameId).ToList();

                                    //определяем номер ячейки
                                    storageGroupZonesService = Program.kernel.Get<IStorageGroupZonesService>();

                                    var cellList = storageGroupZonesService.GetStorageGroupZonePresence(((ReceiptsForKeepingDTO)receiptsBS.Current).ZoneNameId ?? 0, ((ReceiptsForKeepingDTO)receiptsBS.Current).MaterialId, 2);

                                    var currCellItem = cellList.FirstOrDefault(c => storesByWindowList.Contains(c.StoreNameId));

                                    if (currCellItem != null)
                                    {
                                        switch (windItem.WindowNumber)
                                        {
                                            case 1:
                                                cellFirstItem = currCellItem;
                                                LocateReceipt((ReceiptsForKeepingDTO)receiptsBS.Current, cellFirstItem, windItem);
                                                break;
                                            case 2:
                                                cellSecondItem = currCellItem;
                                                LocateReceipt((ReceiptsForKeepingDTO)receiptsBS.Current, cellSecondItem, windItem);
                                                break;
                                        }

                                        locateIsDone = true;

                                        break;
                                    }
                                }
                                    }

                            if (!locateIsDone)
                                MessageBox.Show("Не удалось выполнить размещение по одной из причин:\n" +
                                    " - зона хранения не подходит для размещения данного материала;\n" +
                                    " - подходящих ячеек не определено.\nВыберите другой способ раскладки или проверьте загруженность зоны хранения.", "Размещение", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    break;


                        #endregion

                        #region 3 - Find cell from reserve cell zone

                        case 3:
                            locateIsDone = false;

                            foreach (var windItem in windowDistinctList)
                            {
                                if (windItem.BusyWindow)
                                {
                                    var currZoneNameId = (windItem.WindowNumber == 1) ? cellFirstItem.ZoneNameId : cellSecondItem.ZoneNameId;

                                    if (((ReceiptsForKeepingDTO)receiptsBS.Current).ZoneNameId != currZoneNameId)
                                    {
                                        //MessageBox.Show("Зона хранения не подходит для размещения данного материала.\nВыберите другой материал или смените кассету.", "Размещение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        return;
                                    }

                                    var checkReserve = (windItem.WindowNumber == 1) ? (cellFirstItem.ZoneTypeId != 2) : (cellSecondItem.ZoneTypeId != 2);

                                    if (checkReserve)
                                    {
                                        //MessageBox.Show("Кассета не из резервной зоны.\nВыберите подходящий алгоритм раскладки или смените кассету.", "Размещение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        return;
                                    }

                                    var currCellItem = (windItem.WindowNumber == 1) ? cellFirstItem : cellSecondItem;
                                    AddingReceipt((ReceiptsForKeepingDTO)receiptsBS.Current, currCellItem, windItem);

                                    locateIsDone = true;

                                    break;
                                }
                                else
                                {
                                    var storesByWindowList = bindedWindowItemList.Where(s => s.DeviceId == windItem.DeviceId).Select(s => s.StoreNameId).ToList();

                                    //определяем номер ячейки
                                    storageGroupZonesService = Program.kernel.Get<IStorageGroupZonesService>();

                                    var cellList = storageGroupZonesService.GetReserveZonePresence(storageId, 1);

                                    var currCellItem = cellList.FirstOrDefault(c => storesByWindowList.Contains(c.StoreNameId));

                                    if (currCellItem != null)
                                    {
                                        switch (windItem.WindowNumber)
                                        {
                                            case 1:
                                                cellFirstItem = currCellItem;
                                                LocateReceipt((ReceiptsForKeepingDTO)receiptsBS.Current, cellFirstItem, windItem);
                                    break;
                                            case 2:
                                                cellSecondItem = currCellItem;
                                                LocateReceipt((ReceiptsForKeepingDTO)receiptsBS.Current, cellSecondItem, windItem);
                                                break;
                            }

                                        locateIsDone = true;

                                        break;
                                    }
                                }
                        }

                            if (!locateIsDone)
                                MessageBox.Show("Не удалось выполнить размещение по одной из причин:\n" +
                                    " - кассета не из резервной зоны;\n" +
                                    " - подходящих ячеек не определено.\nВыберите другой способ раскладки или проверьте загруженность зоны хранения.", "Размещение", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            break;

                        #endregion
                    }
                }
            }
            else //ручной
            {
                if (storeHeaderList.FirstOrDefault(s => s.StoreNameId == storageId).EnableAuthomatization == 1)
                {
                    //определяем окно выдачи
                    var windowListByStoreNameId = bindedWindowItemList.GroupBy(g => g.DeviceId).Select(s => s.First()).ToList();

                    if (windowListByStoreNameId.Count > 1)
                    {

                    }
                    else
                    {
                        if (!windowListByStoreNameId[0].BusyWindow)
                        {
                            storageGroupZonesService = Program.kernel.Get<IStorageGroupZonesService>();
                            var cellList = storageGroupZonesService.GetStorageGroupZonePresence(((ReceiptsForKeepingDTO)receiptsBS.Current).ZoneNameId ?? 0, ((ReceiptsForKeepingDTO)receiptsBS.Current).MaterialId, -1).Where(c => c.LoadingStatusId < 3);

                            storageGroupZonesService = Program.kernel.Get<IStorageGroupZonesService>();
                            List<StorageGroupZonePresenceDTO> resultList = cellList.Union(storageGroupZonesService.GetReserveZonePresence(storageId, 0)).ToList();

                            if (resultList.Count > 0)
                            {
                                using (StoreCellPresenceFm form = new StoreCellPresenceFm(resultList))
                                {
                                    if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                                    {
                                        switch (windowListByStoreNameId[0].WindowNumber)
                                        {
                                            case 1:
                                                cellFirstItem = form.Return();
                                                LocateReceipt((ReceiptsForKeepingDTO)receiptsBS.Current, cellFirstItem, windowListByStoreNameId[0]);
                                                break;
                                            case 2:
                                                cellSecondItem = form.Return();
                                                LocateReceipt((ReceiptsForKeepingDTO)receiptsBS.Current, cellSecondItem, windowListByStoreNameId[0]);
                                                break;
                                        }

                                        plc.TimerStop();
                                    }
                                }

                            }
                            else
                            {
                                MessageBox.Show("Подходящих ячеек не определено.\nВыберите другой способ раскладки или проверьте загруженность зоны хранения.", "Размещение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                        }
                        else
                        {
                            cellZonesService = Program.kernel.Get<ICellZonesService>();

                            var currZoneNameId = (windowListByStoreNameId[0].WindowNumber == 1) ? cellFirstItem.ZoneNameId : cellSecondItem.ZoneNameId;

                            if (((ReceiptsForKeepingDTO)receiptsBS.Current).ZoneNameId != currZoneNameId)
                            {
                                MessageBox.Show("Зона хранения не подходит для размещения данного материала.\nВыберите другой материал или смените кассету.", "Размещение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
            }

                            var currCellItem = (windowListByStoreNameId[0].WindowNumber == 1) ? cellFirstItem : cellSecondItem;
                            AddingReceipt((ReceiptsForKeepingDTO)receiptsBS.Current, currCellItem, windowListByStoreNameId[0]);
                        }
        }
                }
            }
        }

        #region First window button's click event

        private void cancelFirstBtn_Click(object sender, EventArgs e)
        {
            try
            {
                int numberCell = Int32.Parse(numberCellFirstLbl.Text);
                var windowItem = bindedWindowItemList.FirstOrDefault(w => w.WindowNumber == 1);
                
                if (PutCellToStorageForCancel(windowItem, numberCell))
                {                    
                    LoadReceiptsData(storageId);

                    keepingsFirstWindBS.DataSource = null;
                    historyKeepingFirstList.Clear();

                    numberCellFirstLbl.Text = "";
                    storageGridEditItem.Enabled = true;
                    pushFullCellFirstBtn.Enabled = false;
                    pushPartlyCellFirstBtn.Enabled = false;
                    changeCellFirstBtn.Enabled = false;
                    cancelFirstBtn.Enabled = false;
                }
                else
                {
                    return;
                }

                plc.TimerStop();
            }
            catch (Exception ex)
            {
                MessageBox.Show("При выполнении операции возникла ошибка.\n" + ex.Message, "Выполнение операции", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void pushFullCellFirstBtn_Click(object sender, EventArgs e)
        {
            int numberCell = Int32.Parse(numberCellFirstLbl.Text);
            var windowItem = bindedWindowItemList.FirstOrDefault(w => w.WindowNumber == 1);
            var keepingList = cellPresenceFirstList.Where(cp => cp.QuantityChanged > 0).ToList();

            if (keepingList.Count > 0)
            {
                if (PutCellToStorageDone(windowItem, numberCell))
                {
                    if (SaveKeeping(keepingList, receiptsByOrder, historyKeepingFirstList, true))
                    {
                        LoadReceiptsData(storageId);

                        keepingsFirstWindBS.DataSource = null;
                        historyKeepingFirstList.Clear();

                        numberCellFirstLbl.Text = "";
                        storageGridEditItem.Enabled = true;
                        pushFullCellFirstBtn.Enabled = false;
                        pushPartlyCellFirstBtn.Enabled = false;
                        changeCellFirstBtn.Enabled = false;
                        cancelFirstBtn.Enabled = false;
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    return;
                }

                plc.TimerStop();
            }
            else 
            {
                MessageBox.Show("Нет данных для сохранения. Выполните сначала операцию размещения", "Сохранение", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void changeCellFirstBtn_Click(object sender, EventArgs e)
        {
            if (cellPresenceFirstList.Any(c => c.QuantityChanged > 0))
            {
                MessageBox.Show("Перевыбор кассеты не доступен.\n Очистите список вновь размещенных материалов и повторите попытку.", "Перевыбор кассеты", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                storageGroupZonesService = Program.kernel.Get<IStorageGroupZonesService>();

                List<StorageGroupZonePresenceDTO> resultList = new List<StorageGroupZonePresenceDTO>();

                if ((int)modeGroupItem.EditValue == 0)
                {
                    var cellList = ((int)algorithmGroupItem.EditValue != 3)
                                    ? storageGroupZonesService.GetStorageGroupZonePresence(((ReceiptsForKeepingDTO)receiptsBS.Current).ZoneNameId ?? 0, ((ReceiptsForKeepingDTO)receiptsBS.Current).MaterialId, (int)algorithmGroupItem.EditValue)
                                    : storageGroupZonesService.GetReserveZonePresence(storageId, 1);
                    resultList = cellList.ToList();
        }
                else
                {
                    var cellList = storageGroupZonesService.GetStorageGroupZonePresence(((ReceiptsForKeepingDTO)receiptsBS.Current).ZoneNameId ?? 0, ((ReceiptsForKeepingDTO)receiptsBS.Current).MaterialId, -1).Where(c => c.LoadingStatusId < 3);

                    storageGroupZonesService = Program.kernel.Get<IStorageGroupZonesService>();
                    resultList = cellList.Union(storageGroupZonesService.GetReserveZonePresence(storageId, 0)).ToList();
                }

                if (resultList.Count > 0)
                {
                    using (StoreCellPresenceFm form = new StoreCellPresenceFm(resultList))
                    {
                        if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        {
                            int oldCell = cellFirstItem.NumberCell ?? 0;

                            cellFirstItem = form.Return();

                            if (oldCell == cellFirstItem.NumberCell)
                            {
                                MessageBox.Show("Кассета с таким номером находится на столе выдачи.\n Выбирите кассету с другим номером.", "Выполнение операции", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }

                            var windowItem = bindedWindowItemList.FirstOrDefault(w => w.WindowNumber == 1);
                                                        
                            if (PutCellToStorageDone(windowItem, cellFirstItem.NumberCell ?? 0))
                            {
                                LocateReceipt((ReceiptsForKeepingDTO)receiptsBS.Current, cellFirstItem, windowItem);
                            }
                            else
                            {
                                return;
                            }

                            plc.TimerStop();
                        }
                    }
   
                }
                else
                {
                    MessageBox.Show("Подходящих ячеек не определено.\nВыберите другой способ раскладки или проверьте загруженность зоны хранения.", "Размещение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
        }

        private void pushPartlyCellFirstBtn_Click(object sender, EventArgs e)
        {
            int numberCell = Int32.Parse(numberCellFirstLbl.Text);
            var windowItem = bindedWindowItemList.FirstOrDefault(w => w.WindowNumber == 1);
            var keepingList = cellPresenceFirstList.Where(cp => cp.QuantityChanged > 0).ToList();

            if (keepingList.Count > 0)
            {
                if (PutCellToStorageDone(windowItem, numberCell))
                {
                    if (SaveKeeping(keepingList, receiptsByOrder, historyKeepingFirstList, false))
                    {
                        LoadReceiptsData(storageId);

                        keepingsFirstWindBS.DataSource = null;
                        historyKeepingFirstList.Clear();

                        numberCellFirstLbl.Text = "";
                        storageGridEditItem.Enabled = true;
                        pushFullCellFirstBtn.Enabled = false;
                        pushPartlyCellFirstBtn.Enabled = false;
                        changeCellFirstBtn.Enabled = false;
                        cancelFirstBtn.Enabled = false;
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    return;
                }

                plc.TimerStop();
            }
            else
            {
                MessageBox.Show("Нет данных для сохранения. Выполните сначала операцию размещения", "Сохранение", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void editBtnFirstRepository_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            int currReceiptAcceptanceId = ((CellPresenceDTO)keepingsFirstWindBS.Current).ReceiptAcceptanceId;

            decimal currentMaxQuantity = receiptsByOrder.First(r => r.AcceptanceId == currReceiptAcceptanceId).QuantityForKeepMax;

            decimal currQuantity = ((CellPresenceDTO)keepingsFirstWindBS.Current).QuantityChanged;

            if (e.Button.Index == 0)// редактировать
            {
                using (QuantityEditFm quantytiEditFm = new QuantityEditFm(currQuantity, currentMaxQuantity))
                {
                    if (quantytiEditFm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        decimal return_quantity = quantytiEditFm.Return();
                        decimal quantity = ((CellPresenceDTO)keepingsFirstWindBS.Current).QuantityChanged - return_quantity;

                        receiptsGridView.BeginDataUpdate();
                        receiptsByOrder.Where(c => c.AcceptanceId == currReceiptAcceptanceId).Select(r => { r.QuantityForKeep += quantity; return r; }).ToList();
                        receiptsGridView.EndDataUpdate();

                        keepingsFirstWindGridView.BeginUpdate();
                        cellPresenceFirstList.Where(c => c.ReceiptAcceptanceId == currReceiptAcceptanceId).Select(c => { c.QuantityChanged = return_quantity; c.QuantityStore -= quantity; return c; }).ToList();
                        keepingsFirstWindGridView.EndUpdate();

                        historyKeepingFirstList.Where(c => c.ReceiptAcceptanceId == currReceiptAcceptanceId).Select(h => { h.Quantity -= quantity; return h; }).ToList();
                    }
                }
            }

            if (e.Button.Index == 1)// удалить
            {
                if (MessageBox.Show("Отменить размещение выбранной номенклатуры?", "Подтвердить", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    receiptsGridView.BeginDataUpdate();
                    receiptsByOrder.Where(c => c.AcceptanceId == currReceiptAcceptanceId).Select(k => { k.QuantityForKeep += currQuantity; return k; }).ToList();
                    receiptsGridView.EndDataUpdate();
                    
                    keepingsFirstWindGridView.BeginDataUpdate();
                    
                    ((CellPresenceDTO)keepingsFirstWindBS.Current).QuantityChanged = 0;
                    ((CellPresenceDTO)keepingsFirstWindBS.Current).QuantityStore = ((CellPresenceDTO)keepingsFirstWindBS.Current).QuantityKeeping;
                    
                    if (((CellPresenceDTO)keepingsFirstWindBS.Current).QuantityKeeping == 0)
                    { 
                        cellPresenceFirstList.Remove((CellPresenceDTO)keepingsFirstWindBS.Current); 
                    }

                    keepingsFirstWindGridView.EndDataUpdate();

                    historyKeepingFirstList.RemoveAll(c => c.ReceiptAcceptanceId == currReceiptAcceptanceId);
                }
            }
        }

        #endregion

        #region Second window button's click event

        private void pushFullCellSecondBtn_Click(object sender, EventArgs e)
        {
            int numberCell = Int32.Parse(numberCellSecondLbl.Text);
            var windowItem = bindedWindowItemList.FirstOrDefault(w => w.WindowNumber == 2);
            var keepingList = cellPresenceSecondList.Where(cp => cp.QuantityChanged > 0).ToList();

            if (keepingList.Count > 0)
            {
                if (PutCellToStorageDone(windowItem, numberCell))
                {
                    if (SaveKeeping(keepingList, receiptsByOrder, historyKeepingSecondList, true))
                    {
                        LoadReceiptsData(storageId);

                        keepingsSecondWindBS.DataSource = null;
                        historyKeepingSecondList.Clear();

                        numberCellSecondLbl.Text = "";
                        storageGridEditItem.Enabled = true;
                        pushFullCellSecondBtn.Enabled = false;
                        pushPartlyCellSecondBtn.Enabled = false;
                        changeCellSecondBtn.Enabled = false;
                        cancelSecondBtn.Enabled = false;
                    }
                    else
                    {
                        return;
                    }
            }
                else
                {
                    return;
                }

                plc.TimerStop();
        }
            else
            {
                MessageBox.Show("Нет данных для сохранения. Выполните сначала операцию размещения", "Сохранение", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pushPartlyCellSecondBtn_Click(object sender, EventArgs e)
        {
            int numberCell = Int32.Parse(numberCellSecondLbl.Text);
            var windowItem = bindedWindowItemList.FirstOrDefault(w => w.WindowNumber == 2);
            var keepingList = cellPresenceSecondList.Where(cp => cp.QuantityChanged > 0).ToList();
        
            if (keepingList.Count > 0)
            {
                if (PutCellToStorageDone(windowItem, numberCell))
                {
                    if (SaveKeeping(keepingList, receiptsByOrder, historyKeepingSecondList, false))
                    {
                        LoadReceiptsData(storageId);

                        keepingsSecondWindBS.DataSource = null;
                        historyKeepingSecondList.Clear();

                        numberCellSecondLbl.Text = "";
                        storageGridEditItem.Enabled = true;
                        pushFullCellSecondBtn.Enabled = false;
                        pushPartlyCellSecondBtn.Enabled = false;
                        changeCellSecondBtn.Enabled = false;
                        cancelSecondBtn.Enabled = false;
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    return;
                }

                plc.TimerStop();
            }
            else
            {
                MessageBox.Show("Нет данных для сохранения. Выполните сначала операцию размещения", "Сохранение", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void changeCellSecondBtn_Click(object sender, EventArgs e)
        {
            if (cellPresenceSecondList.Any(c => c.QuantityChanged > 0))
            {
                MessageBox.Show("Перевыбор кассеты не доступен.\n Очистите список вновь размещенных материалов и повторите попытку.", "Перевыбор кассеты", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                storageGroupZonesService = Program.kernel.Get<IStorageGroupZonesService>();

                List<StorageGroupZonePresenceDTO> resultList = new List<StorageGroupZonePresenceDTO>();

                if ((int)modeGroupItem.EditValue == 0)
                {
                    var cellList = ((int)algorithmGroupItem.EditValue != 3)
                                    ? storageGroupZonesService.GetStorageGroupZonePresence(((ReceiptsForKeepingDTO)receiptsBS.Current).ZoneNameId ?? 0, ((ReceiptsForKeepingDTO)receiptsBS.Current).MaterialId, (int)algorithmGroupItem.EditValue)
                                    : storageGroupZonesService.GetReserveZonePresence(storageId, 1);
                    resultList = cellList.ToList();
                }
                else
                {
                    var cellList = storageGroupZonesService.GetStorageGroupZonePresence(((ReceiptsForKeepingDTO)receiptsBS.Current).ZoneNameId ?? 0, ((ReceiptsForKeepingDTO)receiptsBS.Current).MaterialId, -1).Where(c => c.LoadingStatusId < 3);

                    storageGroupZonesService = Program.kernel.Get<IStorageGroupZonesService>();
                    resultList = cellList.Union(storageGroupZonesService.GetReserveZonePresence(storageId, 0)).ToList();
                }

                if (resultList.Count > 0)
                {
                    using (StoreCellPresenceFm form = new StoreCellPresenceFm(resultList))
                    {
                        if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        {
                            int oldCell = cellSecondItem.NumberCell ?? 0;

                            cellSecondItem = form.Return();

                            if (oldCell == cellSecondItem.NumberCell)
                            {
                                MessageBox.Show("Кассета с таким номером находится на столе выдачи.\n Выбирите кассету с другим номером.", "Выполнение операции", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }

                            var windowItem = bindedWindowItemList.FirstOrDefault(w => w.WindowNumber == 2);

                            if (PutCellToStorageDone(windowItem, cellSecondItem.NumberCell ?? 0))
                            {
                                LocateReceipt((ReceiptsForKeepingDTO)receiptsBS.Current, cellSecondItem, windowItem);
                            }
                            else
                            {
                                return;
                            }

                            plc.TimerStop();
                        }
                    }

                }
                else
                {
                    MessageBox.Show("Подходящих ячеек не определено.\nВыберите другой способ раскладки или проверьте загруженность зоны хранения.", "Размещение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
        }

        private void cancelSecondBtn_Click(object sender, EventArgs e)
        {
            try
            {
                int numberCell = Int32.Parse(numberCellSecondLbl.Text);
                var windowItem = bindedWindowItemList.FirstOrDefault(w => w.WindowNumber == 2);

                if (PutCellToStorageForCancel(windowItem, numberCell))
                {
                    LoadReceiptsData(storageId);

                    keepingsSecondWindBS.DataSource = null;
                    historyKeepingSecondList.Clear();

                    numberCellSecondLbl.Text = "";
                    storageGridEditItem.Enabled = true;
                    pushFullCellSecondBtn.Enabled = false;
                    pushPartlyCellSecondBtn.Enabled = false;
                    changeCellSecondBtn.Enabled = false;
                    cancelSecondBtn.Enabled = false;
                }
                else
                {
                    return;
                }

                plc.TimerStop();
            }
            catch (Exception ex)
            {
                MessageBox.Show("При выполнении операции возникла ошибка.\n" + ex.Message, "Выполнение операции", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void editBtnSecondRepository_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            int currReceiptAcceptanceId = ((CellPresenceDTO)keepingsSecondWindBS.Current).ReceiptAcceptanceId;

            decimal currentMaxQuantity = receiptsByOrder.First(r => r.AcceptanceId == currReceiptAcceptanceId).QuantityForKeepMax;

            decimal currQuantity = ((CellPresenceDTO)keepingsSecondWindBS.Current).QuantityChanged;

            if (e.Button.Index == 0)// редактировать
            {
                using (QuantityEditFm quantytiEditFm = new QuantityEditFm(currQuantity, currentMaxQuantity))
                {
                    if (quantytiEditFm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        decimal return_quantity = quantytiEditFm.Return();
                        decimal quantity = ((CellPresenceDTO)keepingsSecondWindBS.Current).QuantityChanged - return_quantity;

                        receiptsGridView.BeginDataUpdate();
                        receiptsByOrder.Where(c => c.AcceptanceId == currReceiptAcceptanceId).Select(r => { r.QuantityForKeep = (r.QuantityForKeep + quantity); return r; }).ToList();
                        receiptsGridView.EndDataUpdate();

                        keepingsSecondWindGridView.BeginUpdate();
                        cellPresenceSecondList.Where(c => c.ReceiptAcceptanceId == currReceiptAcceptanceId).Select(c => { c.QuantityChanged = return_quantity; c.QuantityStore = (c.QuantityStore - quantity); return c; }).ToList();
                        keepingsSecondWindGridView.EndUpdate();

                        historyKeepingSecondList.Where(c => c.ReceiptAcceptanceId == currReceiptAcceptanceId).Select(h => { h.Quantity -= quantity; return h; }).ToList();
                    }
                }
            }

            if (e.Button.Index == 1)// удалить
            {
                if (MessageBox.Show("Отменить размещение выбранной номенклатуры?", "Подтвердить", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    receiptsGridView.BeginDataUpdate();
                    receiptsByOrder.Where(c => c.AcceptanceId == currReceiptAcceptanceId).Select(k => { k.QuantityForKeep = (k.QuantityForKeep + currQuantity); return k; }).ToList();
                    receiptsGridView.EndDataUpdate();

                    keepingsSecondWindGridView.BeginDataUpdate();

                    ((CellPresenceDTO)keepingsSecondWindBS.Current).QuantityChanged = 0;
                    ((CellPresenceDTO)keepingsSecondWindBS.Current).QuantityStore = ((CellPresenceDTO)keepingsSecondWindBS.Current).QuantityKeeping;

                    if (((CellPresenceDTO)keepingsSecondWindBS.Current).QuantityKeeping == 0)
                    {
                        cellPresenceSecondList.Remove((CellPresenceDTO)keepingsSecondWindBS.Current);
                    }

                    keepingsSecondWindGridView.EndDataUpdate();

                    historyKeepingSecondList.RemoveAll(c => c.ReceiptAcceptanceId == currReceiptAcceptanceId);
                }
            }
        }
        
        #endregion

        #endregion

        #region Control event's
        
        private void receiptsGridView_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.Column == informationColumn && e.IsGetData)
            {
                int flag = ((ReceiptsForKeepingDTO)receiptsBS[e.ListSourceRowIndex]).MaterialEntryStatus;

                e.Value = columnCollection.Images[flag];
            }
            
        }

        private void receiptsGridView_CustomRowCellEdit(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            if (receiptsBS.Count > 0)
            {
                if (e.Column == locateCol)
                {
                    bool status = (Convert.ToInt32(receiptsGridView.GetRowCellValue(e.RowHandle, "MaterialEntryStatus")) == 1);
                    bool enoughQuantity = (Convert.ToDecimal(receiptsGridView.GetRowCellValue(e.RowHandle, "QuantityForKeep")) == 0);

                    if (status || enoughQuantity)
                    {
                        RepositoryItemButtonEdit ritem = new RepositoryItemButtonEdit();
                        ritem.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
                        ritem.ReadOnly = true;
                        ritem.Buttons[0].Enabled = false;
                        e.RepositoryItem = ritem;
                    }
                }
            }
        }

        private void keepingsFirstWindGridView_CustomRowCellEdit(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            if (keepingsFirstWindBS.Count > 0)
            {
                if (e.Column == firstEditBtnCol)
                {
                    bool enoughQuantity = (Convert.ToDecimal(keepingsFirstWindGridView.GetRowCellValue(e.RowHandle, "QuantityChanged")) > 0);

                    if (!enoughQuantity)
                    {
                        RepositoryItemButtonEdit ritem = new RepositoryItemButtonEdit();
                        
                        ritem.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
                        ritem.ReadOnly = true;
                        ritem.Buttons[0].Enabled = false;
                        
                        e.RepositoryItem = ritem;
                    }
                }
            }
        }

        private void keepingsSecondWindGridView_CustomRowCellEdit(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            if (keepingsSecondWindBS.Count > 0)
            {
                if (e.Column == secondEditBtnCol)
                {
                    bool enoughQuantity = (Convert.ToDecimal(keepingsSecondWindGridView.GetRowCellValue(e.RowHandle, "QuantityChanged")) > 0);

                    if (!enoughQuantity)
                    {
                        RepositoryItemButtonEdit ritem = new RepositoryItemButtonEdit();

                        ritem.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
                        ritem.ReadOnly = true;
                        ritem.Buttons[0].Enabled = false;
                        
                        e.RepositoryItem = ritem;
                    }
                }
            }
        }

        private void storageGridRepository_EditValueChanged(object sender, EventArgs e)
        {
            ButtonEdit editor = sender as ButtonEdit;
            storageId = Int32.Parse(editor.EditValue.ToString());

            LoadReceiptsData(storageId);
            SetEnableReserveItem(storageId);

            if (storeList.FirstOrDefault(s => s.StoreNameId == storageId).EnableAuthomatization == 1)
            {
                OpenPlcDevice();
            }
            else
            {
                firstWindPage.PageVisible = true;
                SetDeviceIndicators(Utils.DeviceIndication.Offline, 1);
                DisconnectPLC();
                plcImageEdit.Enabled = false;
                locateBtnRepository.Buttons[0].Enabled = true;
            }
        }
        
        private void modeGroup_EditValueChanged(object sender, EventArgs e)
        {
            algorithmGroupItem.EditValue = 0;
            algorithmGroupItem.Enabled = ((int)modeGroupItem.EditValue == 1);
        }

        #endregion

        #region Form event's

        private void ReceiptsForKeepingFmNew_FormClosed(object sender, FormClosedEventArgs e)
        {
            DisconnectPLC();
            DisconnectBarcode();
        }

        private void toolTipController_GetActiveObjectInfo(object sender, ToolTipControllerGetActiveObjectInfoEventArgs e)
        {
            if (e.SelectedControl is GridControl)
            {
                GridView view = ((GridControl)e.SelectedControl).GetViewAt(e.ControlMousePosition) as GridView;

                if (view == null) return;

                GridHitInfo hi = view.CalcHitInfo(e.ControlMousePosition);

                if (hi.HitTest == GridHitTest.RowCell && hi.Column != null && hi.Column == informationColumn)
                {
                    Image relatedImage = (Image)view.GetRowCellValue(hi.RowHandle, hi.Column);
                    if (relatedImage != null)
                    {
                        if (relatedImage == columnCollection.Images[1])
                            e.Info = new ToolTipControlInfo(hi.Column, "Материал не доступен к размещению.\n Не определена зона хранения или складская группа, либо зона хранения не содержит ячеек.");
                        else
                            e.Info = new ToolTipControlInfo(hi.Column, "Материал доступен к размещению.");
                    }
                }
            }
        }

        #endregion

        #endregion
    }
}