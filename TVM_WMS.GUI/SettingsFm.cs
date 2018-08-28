using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using TVM_WMS.BLL.Infrastructure.PlcWrapper;
using S7.Net;
using Ninject;
using TVM_WMS.BLL.Infrastructure;
using TVM_WMS.BLL.Interfaces;
using System.Configuration;
using TVM_WMS.BLL.Infrastructure.SerialPortListener;
using System.IO;
using TVM_WMS.BLL.BusinessLogicModule;
using System.IO.Ports;
using DevExpress.XtraReports.UI;
using DevExpress.LookAndFeel;
using TVM_WMS.BLL.DTO.QueryDTO;
using TVM_WMS.BLL.DTO;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using System.Drawing;
using DevExpress.XtraEditors;
using TVM_WMS.BLL.Infrastructure.WatchDog;
using TVM_WMS.BLL.Infrastructure.Logger;

namespace TVM_WMS.GUI
{
    public partial class SettingsFm : DevExpress.XtraEditors.XtraForm
    {
        private IUsersService usersService;
        private ISettingsService settingsService;
        private IStoreNamesService storeNamesService;
        private IWareHousesService wareHousesService;
        private IReportsService reportsService;

        private BindingSource dataItemBS = new BindingSource();
        private BindingSource stackerBS = new BindingSource();
        private BindingSource storeNamesBS = new BindingSource();

        private SerialPortManager _spManager;
        private PLC plc;

        List<WareHousesDTO> cellList = new List<WareHousesDTO>();
        int missingCellCount = 0;

        
        private string HomePath = Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]);
        private string config;
        
        public SettingsFm()
        {
            InitializeComponent();
            config = HomePath + @"\Settings.xml";

            settingSSManager.ShowWaitForm();
            
            LoadConfiguration();
            LoadStoreNamesData();
                        
            settingSSManager.CloseWaitForm();
        }

        #region DataBase settings

        private string GetConnectionStringFromTestValue()
        {
            string testConnectionString = "User=SYSDBA; Password=masterkey; " +
                                          "DataBase=" + dbFilePathTBox.Text + "; " +
                                          "Server=" + dbIpTBox.Text + "; " +
                                          "Dialect=3; Charset=UTF8";

            return testConnectionString;
        }

        private void testDbBtn_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            
            try
            {
                Program.kernel = new StandardKernel(new ServiceModule(GetConnectionStringFromTestValue()));
                usersService = Program.kernel.Get<IUsersService>();
                var users = usersService.GetUsers();
                MessageBox.Show("Соединение успешно!", "Тест соединения", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при соединении! \n" + ex.Message, "Тест соединения", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            Cursor = Cursors.Default;
        }

        #endregion

        #region PLC settings

        #region Event's
                
        private void testPlcBtn_Click(object sender, EventArgs e)
        {
            if (dataBlockEdit.EditValue != null)
            {
                Cursor = Cursors.WaitCursor;

                var dbItem = ConfigClass.Instance.DataItemList.First(s => s.DeviceId == (int)dataBlockEdit.EditValue);
                var plcItem = ConfigClass.Instance.PlcSettingList.First(s => s.DeviceId == dbItem.ParentDeviceId);

                if (plc == null)
                    plc = new PLC();

                plc.Connect(plcItem.CpuType,
                            plcItem.Ip,
                            plcItem.Rack,
                            plcItem.Slot
                           );

                if (plc.ConnectionState == ConnectionStates.Online)
                {
                    MessageBox.Show("Соединение успешно!", "Тест соединения", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    plc.Disconnect();
                }
                else
                    MessageBox.Show("Ошибка при соединении!", "Тест соединения", MessageBoxButtons.OK, MessageBoxIcon.Error);

                Cursor = Cursors.Default;

            }
        }

        private void startListenBtn_Click(object sender, EventArgs e)
        {
            if (dataBlockEdit.EditValue == null)
                return;

            if (StartPlcListen((int)dataBlockEdit.EditValue))
            {
                dataBlockEdit.Enabled = false;
                startListenBtn.Enabled = false;
                stopListenBtn.Enabled = true;
                refreshSpin.Enabled = false;
            }
        }

        private void stopListenBtn_Click(object sender, EventArgs e)
        {
            dataBlockEdit.Enabled = true;
            startListenBtn.Enabled = true;
            stopListenBtn.Enabled = false;
            refreshSpin.Enabled = true;
            
            StopPlcListen();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            plcVarGridView.BeginDataUpdate();
            dataItemBS.DataSource = plc.Return();
            plcVarGridView.EndDataUpdate();
        }
                

        private void dataBlockEdit_EditValueChanged(object sender, EventArgs e)
        {
            if (dataBlockEdit.EditValue != null)
            {
                dataItemBS.DataSource = null;
                dataItemBS.DataSource = ConfigClass.Instance.DataItemList.Where(s => s.DeviceId == (int)dataBlockEdit.EditValue).ToList();
                plcVarGrid.DataSource = dataItemBS;

                testPlcBtn.Enabled = true;
                startListenBtn.Enabled = true;
                stopListenBtn.Enabled = true;
                refreshSpin.Enabled = true;
            }
            else
            {
                dataItemBS.DataSource = null;

                testPlcBtn.Enabled = false;
                startListenBtn.Enabled = false;
                stopListenBtn.Enabled = false;
                refreshSpin.Enabled = false;
            }
        }

        private void dataBlockEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                dataBlockEdit.Properties.DataSource = ConfigClass.Instance.DataItemList.Select(s => new { s.DeviceId, s.DeviceName }).Distinct().ToList();
                dataBlockEdit.EditValue = null;
            }
        }

        #endregion

        #region Method's
        
        private bool StartPlcListen(int deviceId)
        {
            List<DataItemsQueryDTO> TagList = new List<DataItemsQueryDTO>();
            TagList = (List<DataItemsQueryDTO>)dataItemBS.DataSource;

            double interval = Convert.ToDouble(refreshSpin.EditValue);
            int plcDeviceId = ConfigClass.Instance.DataItemList.First(s => s.DeviceId == deviceId).ParentDeviceId;
            var plcSource = (ConfigClass.PlcSettingSource)ConfigClass.Instance.PlcSettingList.FirstOrDefault(s => s.DeviceId == plcDeviceId);
            var cpu = plcSource.CpuType;

            plc = new PLC(TagList);

            plc.CurrentDb = Int32.Parse(ConfigClass.Instance.DeviceSettingsList.First(s => s.DeviceId == deviceId && s.KindName == "DataBlockIndex").SettingValue);
            plc.Connect(cpu, plcSource.Ip, plcSource.Rack, plcSource.Slot);

            if (plc.ConnectionState == ConnectionStates.Online)
            {
                timer.Interval = (int)TimeSpan.FromSeconds(interval).TotalMilliseconds;
                timer.Start();

                return true;
            }
            else
            {
                MessageBox.Show("Ошибка при соединении!", "Cоединение с контроллером PLC", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

        }

        private void StopPlcListen()
        {
            timer.Stop();
            plc.Disconnect();
        }

        #endregion

        #endregion

        #region Barcode scanner settings

        #region Event's
                
        private void barcodeConnectBtn_Click(object sender, EventArgs e)
        {
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
                    MessageBox.Show("Соединение успешно!", "Тест соединения", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    doneConnectLbl.Visible = true;
                    errorConnectLbl.Visible = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при соединении! \n" + ex.Message + "\nПроверьте настройки оборудования.", "Тест соединения", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    doneConnectLbl.Visible = false;
                    errorConnectLbl.Visible = true;
                    _spManager.NewSerialDataRecieved -= new EventHandler<SerialDataEventArgs>(_spManager_NewSerialDataRecieved);
                }
            }
            else
                MessageBox.Show("Список доступного оборудования пуст. Добавьте сначала оборудование.", "Тест соединения", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        }

        private void scannerEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                scannerEdit.Properties.DataSource = ConfigClass.Instance.BarcodeSettingList.Select(s => new { s.DeviceId, s.Name }).Distinct().ToList();
                scannerEdit.EditValue = null;
            }
        }

        private void scannerEdit_EditValueChanged(object sender, EventArgs e)
        {
            barcodeConnectBtn.Enabled = (scannerEdit.EditValue != null);
        }

        #endregion
        
        #endregion

        #region Stacker settings

        #region Event's

        private void bindStackerBtnItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            List<DeviceInfoDTO> deviceSource = ConfigClass.Instance.DeviceSettingsList.Where(s => s.TypeName == "Stacker").ToList();

            using (DeviceBindingEditControl deviceControl = new DeviceBindingEditControl(deviceSource, Utils.DeviceTypes.Stacker))
            {
                if (DevExpress.XtraEditors.XtraDialog.Show(deviceControl, "Выбор устройства", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                {
                    settingSSManager.ShowWaitForm();

                    int returnDeviceId = deviceControl.ReturnDeviceId();
                    int returnStoreNameId = deviceControl.ReturnStoreNameId();

                    if (returnDeviceId > 0 && returnStoreNameId > 0)
                    {
                        settingsService = Program.kernel.Get<ISettingsService>();

                        var currentDeviceBindingDTO = ConfigClass.Instance.DeviceBindingSettingList.FirstOrDefault(s => s.DeviceId == returnDeviceId);

                        int currentDeviceBindingId = (currentDeviceBindingDTO == null) ? 0 : currentDeviceBindingDTO.Id;

                        if (!settingsService.GetStoreBindings(ConfigClass.Instance.LocalCPUID).Any(s => s.StoreNameId == returnStoreNameId && s.DeviceBindingId == currentDeviceBindingId))
                        {
                            DeviceBindingsDTO modelDB = new DeviceBindingsDTO()
                            {
                                ParentId = null,
                                DeviceId = returnDeviceId
                            };

                            currentDeviceBindingId = settingsService.DeviceBindingCreate(modelDB);

                            StoreBindingsDTO modelSB = new StoreBindingsDTO()
                            {
                                StoreNameId = returnStoreNameId,
                                DeviceBindingId = currentDeviceBindingId
                            };

                            settingsService.StoreBindingCreate(modelSB);

                            ConfigClass.Instance.ConfigLoad(settingsService);
                                                        
                            stackerTree.Nodes.Clear();
                            var treeDetailSource = settingsService.GetDeviceBindingSettings(ConfigClass.Instance.LocalCPUID).ToList();
                            var treeParentSource = settingsService.GetStoreBindings(ConfigClass.Instance.LocalCPUID).ToList();
                            CreateNodes(stackerTree, treeDetailSource, treeParentSource);
                            stackerTree.ExpandAll();
                        }
                        else
                        {
                            MessageBox.Show("Устройство с таким именем уже добавлено в структуру!", "Привязка оборудования", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Устройство с таким именем уже добавлено в структуру!", "Привязка оборудования", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    
                    settingSSManager.CloseWaitForm();
                }
            }
        }

        private void bindDBBtnItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var currentNode = stackerTree.FocusedNode;

            int parentId = (int)currentNode.Tag;

            List<DeviceInfoDTO> deviceSource = ConfigClass.Instance.DeviceSettingsList
                .Where(s => s.TypeName == "DB")
                .GroupBy(d => d.DeviceId)
                .Select(s => new DeviceInfoDTO{ DeviceId = s.First().DeviceId, Name = s.First().Name})
                .OrderBy(o => o.Name)
                .ToList();

            using (DeviceBindingEditControl deviceControl = new DeviceBindingEditControl(deviceSource, Utils.DeviceTypes.DB))
            {
                if (DevExpress.XtraEditors.XtraDialog.Show(deviceControl, "Выбор устройства", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                {
                    settingSSManager.ShowWaitForm();

                    int returnId = deviceControl.ReturnDeviceId();

                    if (returnId > 0)
                    {
                        if (!ConfigClass.Instance.DeviceBindingSettingList.Any(s => s.ParentId == parentId && s.DeviceId == returnId))
                        {
                            DeviceBindingsDTO model = new DeviceBindingsDTO()
                            {
                                ParentId = parentId,
                                DeviceId = returnId
                            };

                            settingsService = Program.kernel.Get<ISettingsService>();

                            settingsService.DeviceBindingCreate(model);

                            ConfigClass.Instance.ConfigLoad(settingsService);

                            stackerTree.Nodes.Clear();
                            var treeDetailSource = settingsService.GetDeviceBindingSettings(ConfigClass.Instance.LocalCPUID).ToList();
                            var treeParentSource = settingsService.GetStoreBindings(ConfigClass.Instance.LocalCPUID).ToList();
                            CreateNodes(stackerTree, treeDetailSource, treeParentSource);
                            stackerTree.ExpandAll();
                        }
                        else
                        {
                            MessageBox.Show("Устройство с таким именем уже добавлено в выделенную структуру!", "Привязка оборудования", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }

                    settingSSManager.CloseWaitForm();
                }
            }
        }

        private void bindDropoffWindBtnItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var currentNode = stackerTree.FocusedNode;

            int parentId = (int)currentNode.Tag;

            List<DeviceInfoDTO> deviceSource = ConfigClass.Instance.DeviceSettingsList.Where(s => s.TypeName == "DropoffWindow").ToList();

            using (DeviceBindingEditControl deviceControl = new DeviceBindingEditControl(deviceSource, Utils.DeviceTypes.DropoffWindow))
            {
                if (DevExpress.XtraEditors.XtraDialog.Show(deviceControl, "Выбор устройства", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                {
                    settingSSManager.ShowWaitForm();

                    int returnId = deviceControl.ReturnDeviceId();

                    if (returnId > 0)
                    {
                        if (!ConfigClass.Instance.DeviceBindingSettingList.Any(s => s.ParentId == parentId && s.DeviceId == returnId))
                        {
                            DeviceBindingsDTO model = new DeviceBindingsDTO()
                            {
                                ParentId = parentId,
                                DeviceId = returnId
                            };

                            settingsService = Program.kernel.Get<ISettingsService>();

                            settingsService.DeviceBindingCreate(model);

                            ConfigClass.Instance.ConfigLoad(settingsService);

                            stackerTree.Nodes.Clear();
                            var treeDetailSource = settingsService.GetDeviceBindingSettings(ConfigClass.Instance.LocalCPUID).ToList();
                            var treeParentSource = settingsService.GetStoreBindings(ConfigClass.Instance.LocalCPUID).ToList();
                            CreateNodes(stackerTree, treeDetailSource, treeParentSource);
                            stackerTree.ExpandAll();
                        }
                        else
                        {
                            MessageBox.Show("Устройство с таким именем уже добавлено в выделенную структуру!", "Привязка оборудования", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }

                    settingSSManager.CloseWaitForm();
                }
            }
        }
    
        private void deletedeviceBindBtnItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var currentNode = stackerTree.FocusedNode;

            int parentId = (int)currentNode.Tag;
            var childList = currentNode.TreeList.Nodes.Where(p => p.ParentNode == currentNode);

            string message = (childList.Count() > 0) ? "Удалить всю ветку?" : "Удалить выделенную строку?";

            if (MessageBox.Show(message, "Удаление привязки", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    settingSSManager.ShowWaitForm();

                    settingsService = Program.kernel.Get<ISettingsService>();

                    settingsService.DeviceBindingDelete(parentId);
                }
                catch (Exception ex)
                {
                    settingSSManager.CloseWaitForm();
                    MessageBox.Show("Ошибка при удалении записей\n" + ex.Message, "Удаление привязки", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }
                finally
                {
                    ConfigClass.Instance.ConfigLoad(settingsService);

                    stackerTree.Nodes.Clear();
                    var treeDetailSource = settingsService.GetDeviceBindingSettings(ConfigClass.Instance.LocalCPUID).ToList();
                    var treeParentSource = settingsService.GetStoreBindings(ConfigClass.Instance.LocalCPUID).ToList();
                    CreateNodes(stackerTree, treeDetailSource, treeParentSource);
                    stackerTree.ExpandAll();

                    settingSSManager.CloseWaitForm();
                }
            }
        }

        private void refreshBtnItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            settingSSManager.ShowWaitForm();

            ConfigClass.Instance.ConfigLoad(settingsService);

            stackerTree.Nodes.Clear();
            var treeDetailSource = settingsService.GetDeviceBindingSettings(ConfigClass.Instance.LocalCPUID).ToList();
            var treeParentSource = settingsService.GetStoreBindings(ConfigClass.Instance.LocalCPUID).ToList();
            CreateNodes(stackerTree, treeDetailSource, treeParentSource);
            stackerTree.ExpandAll();

            settingSSManager.CloseWaitForm();
        }

        private void stackerTree_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
        {
            if (stackerTree.Nodes.Count > 0)
            {
                switch (stackerTree.FocusedNode.Level)
                {
                    case 0:
                        bindStackerBtnItem.Enabled = true;
                        bindDropoffWindBtnItem.Enabled = false;
                        bindDBBtnItem.Enabled = false;
                        deletedeviceBindBtnItem.Enabled = false;
                        break;
                    case 1:
                        bindStackerBtnItem.Enabled = true;
                        bindDropoffWindBtnItem.Enabled = true;
                        bindDBBtnItem.Enabled = false;
                        deletedeviceBindBtnItem.Enabled = true;
                        break;
                    case 2:
                        bindStackerBtnItem.Enabled = true;
                        bindDropoffWindBtnItem.Enabled = false;
                        bindDBBtnItem.Enabled = true;
                        deletedeviceBindBtnItem.Enabled = true;
                        break;
                    case 3:
                        bindStackerBtnItem.Enabled = true;
                        bindDropoffWindBtnItem.Enabled = false;
                        bindDBBtnItem.Enabled = false;
                        deletedeviceBindBtnItem.Enabled = true;
                        break;
                }
            }
        }

        #endregion

        #region Method's

        private void CreateNodes(TreeList tl, List<DeviceBindingSettingsDTO> detailSource, List<StoreBindingsDTO> parentSource)
        {
            tl.BeginUnboundLoad();

            List<StoreBindingsDTO> _parentSource = parentSource.GroupBy(w => w.StoreNameId).Select(s => new StoreBindingsDTO() { StoreNameId = s.First().StoreNameId, Name = s.First().Name }).ToList();

            foreach (var storeParentItem in _parentSource)
            {
                //StoreName
                TreeListNode parentForRootStoreNodes = null;
                TreeListNode rootStoreNode = tl.AppendNode(new object[] { storeParentItem.Name, null }, parentForRootStoreNodes);
                rootStoreNode.StateImageIndex = 8;
                rootStoreNode.Tag = -1;

                List<DeviceBindingSettingsDTO> _detailSource = detailSource.Where(s => s.StoreNameId == storeParentItem.StoreNameId).ToList();

                foreach (var parentItem in _detailSource)
                {
                    if (parentItem.ParentId == null)
                    {
                        //Stacker
                        TreeListNode childStackerNode = tl.AppendNode(new object[] { parentItem.Name, parentItem.SettingValue, parentItem.Description }, rootStoreNode);
                        childStackerNode.StateImageIndex = 1;
                        childStackerNode.Tag = parentItem.Id;

                        //DropoffWindow
                        var dropoffWindSource = detailSource.Where(s => s.ParentId == parentItem.Id).ToList();

                        foreach (var windItem in dropoffWindSource)
                        {
                            TreeListNode childWindNode = tl.AppendNode(new object[] { windItem.Name, windItem.SettingValue, windItem.Description }, childStackerNode);
                            childWindNode.StateImageIndex = 2;
                            childWindNode.Tag = windItem.Id;

                            //DB
                            var dbItem = detailSource.Where(s => s.ParentId == windItem.Id).FirstOrDefault();

                            if (dbItem != null)
                            {
                                TreeListNode childDBNode = tl.AppendNode(new object[] { dbItem.Name, dbItem.SettingValue, dbItem.Description }, childWindNode);
                                childDBNode.StateImageIndex = 0;
                                childDBNode.Tag = dbItem.Id;
                            }
                        }
                    }
                }
            }

            tl.EndUnboundLoad();

            if (stackerTree.Nodes.Count == 0)
            {
                bindStackerBtnItem.Enabled = true;
                bindDropoffWindBtnItem.Enabled = false;
                bindDBBtnItem.Enabled = false;
                deletedeviceBindBtnItem.Enabled = false;
            }

        }

        #endregion

        #endregion

        #region Store settings

        #region Event's

        private void addStoreBtnItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            StoreNameEdit(Utils.Operation.Add, new StoreNamesDTO());
        }

        private void addRowBtnItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            StoreRowEdit(Utils.Operation.Add, new StoreNamesDTO() { ParentId = ((StoreNamesDTO)storeNamesBS.Current).StoreNameId });
        }

        private void editBtnItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (storeNamesBS.Count != 0)
            {
                if (((StoreNamesDTO)storeNamesBS.Current).ParentId == null)
                {
                    StoreNameEdit(Utils.Operation.Update, (StoreNamesDTO)storeNamesBS.Current);
                }
                else
                {
                    if (((StoreNamesDTO)storeNamesBS.Current).IsNumbering == "1")
                    {
                        MessageBox.Show("Невозможно редактировать ряд с нумерацией!\n Удалите нумерацию склада и повторите попытку.", "Редактирование", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    StoreRowEdit(Utils.Operation.Update, (StoreNamesDTO)storeNamesBS.Current);
                }
            }
        }

        private void deleteBtnItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (storeNamesBS.Count != 0)
            {
                if (MessageBox.Show("Удалить запись?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (this.storeNamesService.StoreNameDelete((StoreNamesDTO)storeNamesBS.Current))
                        LoadStoreNamesData();
                }
            }
        }

        private void showWareHouseBtnItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            settingSSManager.ShowWaitForm();

            wareHousesService = Program.kernel.Get<IWareHousesService>();

            StoreNamesDTO item = (StoreNamesDTO)storeNamesBS.Current;
            cellList = GetCellList(item.StoreNameId);

            if (cellList.Count == 0)
            {
                List<WareHousesDTO> wareHouse = new List<WareHousesDTO>();

                for (int i = 0; i < (item.LineCount * item.ColumnCount); i++)
                    wareHouse.Add(new WareHousesDTO
                    {
                        StoreNameId = item.StoreNameId,
                        MaxWeight = 0.0m,
                        CurrentWeight = 0.0m,
                        LoadingStatusId = 1
                    });

                wareHousesService.WareHousesRangeCreate(wareHouse);

                cellList = GetCellList(item.StoreNameId);
            }

            RunToControlVisual(item, cellList);

            if (settingSSManager.IsSplashFormVisible)
                settingSSManager.CloseWaitForm();
        }

        private void cellNumberBtnItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            wareHousesService = Program.kernel.Get<IWareHousesService>();

            StoreNamesDTO item = (StoreNamesDTO)storeNamesBS.Current;

            if (cellList.Count > 0)
            {
                settingSSManager.ShowWaitForm();

                int checkedCount = cellList.Count(s => s.Checked);

                if (missingCellCount == checkedCount)
                {
                    wareHousesService.SetEnumerationCells(cellList);
                    RunToControlVisual(item, cellList);

                    LoadStoreNamesData();
                    storeNamesTree.SetFocusedNode(storeNamesTree.FindNodeByKeyID(item.StoreNameId));

                    settingSSManager.CloseWaitForm();

                    showWareHouseBtnItem_ItemClick(this, e);
                }
                else
                {
                    MessageBox.Show("Отмечены (" + checkedCount.ToString() + ") из (" + missingCellCount.ToString() + ") отсутствующих ячеек.\n Отметьте все необходимые ячейки и повторите попытку.", "Нумерация ячеек", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (settingSSManager.IsSplashFormVisible)
                        settingSSManager.CloseWaitForm();
                }
            }
            else
            {
                MessageBox.Show("Список ячеек для нумерации пуст.\n Запустите сначала карту склада и повторите попытку.", "Нумерация ячеек", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void printBtnItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var cellList = GetCellList(((StoreNamesDTO)storeNamesBS.Current).StoreNameId);

            reportsService = Program.kernel.Get<IReportsService>();
            reportsService.PrintWareHouses(cellList, (StoreNamesDTO)storeNamesBS.Current);
        }
         
        private void storeNamesTree_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
        {
            editBtnItem.Enabled = true;
            deleteBtnItem.Enabled = true;

            panel.Controls.Clear();

            if (this.storeNamesTree.FocusedNode.Level != 0)
            // добавить Ряд можно , если выбран склад (корневые группы)
            {
                bool isRowNumerating = (((StoreNamesDTO)storeNamesBS.Current).IsNumbering == "1") ? true : false;

                addRowBtnItem.Enabled = false;
                showWareHouseBtnItem.Enabled = true;
                cellNumberBtnItem.Enabled = false;
                printBtnItem.Enabled = isRowNumerating;
            }
            else
            {
                addRowBtnItem.Enabled = true;
                showWareHouseBtnItem.Enabled = false;
                cellNumberBtnItem.Enabled = false;
                printBtnItem.Enabled = false;
            }
        }

        protected void grControl_Click(object sender, EventArgs e)
        {
            DevExpress.XtraEditors.LabelControl grControl = sender as DevExpress.XtraEditors.LabelControl;
            
            if (!cellList[(int)grControl.Tag].Checked && missingCellCount > cellList.Count(s => s.Checked))
            {
                cellList[(int)grControl.Tag].Checked = true;
                grControl.BackColor = Color.Black;
            }
            else if (cellList[(int)grControl.Tag].Checked)
            {
                cellList[(int)grControl.Tag].Checked = false;
                grControl.BackColor = Color.GhostWhite;
            }
        }
                
        #endregion

        #region Method's

        private void RunToControlVisual(StoreNamesDTO item, List<WareHousesDTO> source)
        {
            int line = item.LineCount ?? 1;
            int column = item.ColumnCount ?? 1;
            int cell = item.CellCount ?? 1;

            missingCellCount = line * column - cell;

            ControlVisual(line, column, missingCellCount, source);

            if ((source[1].NumberCell == null))
            {
                if (missingCellCount > 0)
                {
                    settingSSManager.CloseWaitForm();
                    MessageBox.Show("Необходимо указать " + missingCellCount.ToString() + " отсутствующие ячейки!" + '\n' + " Кликните левой кнопкой мыши на отсутствующей ячейке!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                cellNumberBtnItem.Enabled = true;
            }
            else
                cellNumberBtnItem.Enabled = false;

        }

        private void ControlVisual(int line, int column, int missingCell, List<WareHousesDTO> cellList)
        {
            panel.Controls.Clear();
            
            DevExpress.XtraEditors.LabelControl grCont = new DevExpress.XtraEditors.LabelControl();
            panel.Controls.Add(grCont);
            grCont.MaximumSize = new Size { Width = 30, Height = 20 };
            grCont.MinimumSize = new Size { Width = 30, Height = 20 };
            grCont.Left = 2;
            grCont.Top = 2;
            grCont.Text = "С/Э";
            grCont.BackColor = Color.SkyBlue;
            grCont.Anchor = ((AnchorStyles)((AnchorStyles.Left)));
            grCont.Appearance.Font = new Font("Tahoma", 9, FontStyle.Bold);
            grCont.Appearance.ForeColor = Color.Indigo;
            grCont.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            grCont.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            grCont.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            //
            int interval = 2;
            int grHeight = ((panel.Height - grCont.Height) / line) - interval;
            int grWidth = ((panel.Width - grCont.Width) / column) - interval;
            int dinamicTop = grCont.Height;
            int dinamicLeft = grCont.Width;
            int grLeft;
            int grTop;
            int k = 0;

            for (int j = 0; j < line; j++)
            {
                grLeft = interval + dinamicLeft;
                grTop = interval + dinamicTop;

                for (int i = 0; i < column; i++)
                {
                    grLeft = interval + dinamicLeft;

                    DevExpress.XtraEditors.LabelControl grControl = new DevExpress.XtraEditors.LabelControl();
                    grControl.Name = "grControl" + k;
                    panel.Controls.Add(grControl);

                    grControl.MaximumSize = new Size { Width = grWidth, Height = grHeight };
                    grControl.MinimumSize = new Size { Width = grWidth, Height = grHeight };
                    grControl.Left = grLeft;
                    grControl.Top = grTop;
                    grControl.Anchor = ((AnchorStyles)((AnchorStyles.Left)));
                    grControl.Appearance.Font = new Font("Tahoma", 8, FontStyle.Bold);
                    grControl.Appearance.ForeColor = Color.Firebrick;
                    grControl.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    grControl.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                    grControl.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;

                    if (cellList[k].NumberCell > 0)
                    {
                        grControl.Text = cellList[k].NumberCell.ToString();
                        grControl.BackColor = Color.LightGreen;
                    }
                    else
                    {
                        grControl.Text = "";
                        grControl.BackColor = Color.GhostWhite; 
                    }

                    if (cellList[k].NumberCell != null)
                    {
                        grControl.Click -= new EventHandler(grControl_Click);
                    }
                    else
                    {
                        grControl.Click += new EventHandler(grControl_Click);
                    }

                    grControl.Tag = k;

                    dinamicLeft = dinamicLeft + (grWidth + interval);

                    if (j == 0) // только на первом ряду названия стелажей
                    {
                        //контейнер название стелажей
                        DevExpress.XtraEditors.LabelControl grContSt = new DevExpress.XtraEditors.LabelControl();
                        panel.Controls.Add(grContSt);
                        grContSt.MaximumSize = new Size { Width = grWidth, Height = 20 };
                        grContSt.MinimumSize = new Size { Width = grWidth, Height = 20 };
                        grContSt.Left = grLeft; 
                        grContSt.Top = 2;
                        grContSt.BackColor = Color.SkyBlue;
                        grContSt.Anchor = ((AnchorStyles)((AnchorStyles.Left)));
                        grContSt.Text = (i + 1).ToString();
                        grContSt.Appearance.Font = new Font("Tahoma", 9, FontStyle.Bold);
                        grContSt.Appearance.ForeColor = Color.Indigo;
                        grContSt.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        grContSt.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                        grContSt.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
                        //
                    }
                                       
                    k = k + 1;
                }

                //контейнер название этажей
                DevExpress.XtraEditors.LabelControl grContEt = new DevExpress.XtraEditors.LabelControl();
                panel.Controls.Add(grContEt);
                grContEt.MaximumSize = new Size { Width = 30, Height = grHeight };
                grContEt.MinimumSize = new Size { Width = 30, Height = grHeight };
                grContEt.Left = 2;
                grContEt.BackColor = Color.SkyBlue;
                grContEt.Top = grTop;
                grContEt.Anchor = ((AnchorStyles)((AnchorStyles.Left)));
                grContEt.Text = (line - j).ToString();
                grContEt.Appearance.Font = new Font("Tahoma", 9, FontStyle.Bold);
                grContEt.Appearance.ForeColor = Color.Indigo;
                grContEt.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                grContEt.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                grContEt.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
                //
                dinamicLeft = grCont.Width;
                dinamicTop = dinamicTop + grHeight + interval;
            }

        }

        private void StoreNameEdit(Utils.Operation operation, StoreNamesDTO model)
        {
            using (StoreNameEditFm storeNameEditFm = new StoreNameEditFm(operation, model))
            {
                if (storeNameEditFm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    int return_StoreNameId = storeNameEditFm.Return();

                    LoadStoreNamesData();

                    storeNamesTree.SetFocusedNode(storeNamesTree.FindNodeByKeyID(return_StoreNameId));
                }

                storeNamesTree.Refresh();
            }        
        }

        private void StoreRowEdit(Utils.Operation operation, StoreNamesDTO model)
        {
            using (StoreRowEditFm storeRowEditFm = new StoreRowEditFm(operation, model))
            {
                if (storeRowEditFm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    int return_StoreNameId = storeRowEditFm.Return();

                    LoadStoreNamesData();

                    storeNamesTree.SetFocusedNode(storeNamesTree.FindNodeByKeyID(return_StoreNameId));
                }

                storeNamesTree.Refresh();
            }
        }
  
        private List<WareHousesDTO> GetCellList(int storeNameId)
        {
            return wareHousesService.GetWareHouses().Where(s => s.StoreNameId == storeNameId).ToList();
        }

        private void LoadStoreNamesData()
        {
            storeNamesService = Program.kernel.Get<IStoreNamesService>();
            wareHousesService = Program.kernel.Get<IWareHousesService>();

            try
            {
                var result = (from sn in storeNamesService.GetStoreNamesWithTypes()
                              select new StoreNamesDTO()
                              {
                                  StoreNameId = sn.StoreNameId,
                                  ParentId = sn.ParentId,
                                  CellCount = sn.CellCount,
                                  ColumnCount = sn.ColumnCount,
                                  LineCount = sn.LineCount,
                                  Name = sn.Name,
                                  StoreTypeId = sn.StoreTypeId,
                                  StoreTypeName = sn.StoreTypeName,
                                  EnableAuthomatization = sn.EnableAuthomatization,
                                  EnumerationTypeId = sn.EnumerationTypeId,
                                  IsNumbering = (wareHousesService.GetWareHouses().Any(s => s.StoreNameId == sn.StoreNameId && s.NumberCell != null)) ? "1" : "0"
                              })
                         .OrderBy(s => s.Name)
                         .ToList();
                
                storeNamesBS.Clear();
                storeNamesBS.DataSource = result;
                storeNamesTree.DataSource = storeNamesBS;

                storeNamesTree.KeyFieldName = "StoreNameId";
                storeNamesTree.ParentFieldName = "ParentId";
                storeNamesTree.ExpandAll();

                cellNumberBtnItem.Enabled = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка " + ex.Message, "Информация", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #endregion

        #region Device settings

        #region Event's

        private void addPlcBtnItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            EditPlcConfig(Utils.Operation.Add, new ConfigClass.PlcSettingSource());
        }

        private void addScannerBtnItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            EditBarcodeScannerConfig(Utils.Operation.Add, new ConfigClass.BarcodeSettingSource());
        }

        private void addDbBtnItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            EditDataItemsConfig(Utils.Operation.Add, -1, (int)deviceTree.FocusedNode.Tag);
        }

        private void addStackerBtnItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            EditStackerConfig(Utils.Operation.Add, new DevicesDTO());
        }

        private void addDropoffWindBtnItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            EditDropoffWindowConfig(Utils.Operation.Add, new DeviceInfoDTO());
        }

        private void editDeviceBtnItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int focusedTagId = (int)deviceTree.FocusedNode.Tag;

            string deviceType = (ConfigClass.Instance.DeviceSettingsList).FirstOrDefault(s => s.DeviceId == focusedTagId).TypeName;

            switch (deviceType)
            {
                case "PLC":
                    var plcSource = (ConfigClass.Instance.PlcSettingList).First(s => s.DeviceId == focusedTagId);
                    EditPlcConfig(Utils.Operation.Update, plcSource);
                    break;
                case "BarcodeScanner":
                    var scanSource = (ConfigClass.Instance.BarcodeSettingList).First(s => s.DeviceId == focusedTagId);
                    EditBarcodeScannerConfig(Utils.Operation.Update, scanSource);
                    break;
                case "Stacker":
                    var stackerSource = (ConfigClass.Instance.DeviceSettingsList).First(s => s.DeviceId == focusedTagId);
                    var model = new DevicesDTO()
                    {
                        Id = stackerSource.DeviceId,
                        Name = stackerSource.Name,
                        LocalCPUID = stackerSource.LocalCPUID,
                        TypeId = stackerSource.TypeId
                    };
                    
                    EditStackerConfig(Utils.Operation.Update, model);
                    
                    break;
                case "DropoffWindow":
                    var windSource = (ConfigClass.Instance.DeviceSettingsList).First(s => s.DeviceId == focusedTagId);
                    EditDropoffWindowConfig(Utils.Operation.Update, windSource);
                    
                    break;
                case "DB":
                    int parentDeviceId = ConfigClass.Instance.DataItemList.First(s => s.DeviceId == focusedTagId).ParentDeviceId;
                    EditDataItemsConfig(Utils.Operation.Update, focusedTagId, parentDeviceId);

                    break;
                default:
                    break;
            }
                           
        }

        private void deleteDeviceBtnItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int focusedTagId = (int)deviceTree.FocusedNode.Tag;

            string deviceType = (ConfigClass.Instance.DeviceSettingsList).FirstOrDefault(s => s.DeviceId == focusedTagId).TypeName;

            switch (deviceType)
            {
                case "PLC":
                    if (MessageBox.Show("Удалить?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        bool isHaveDB = (ConfigClass.Instance.DataItemList).Any(s => s.ParentDeviceId == focusedTagId);
                        if (!isHaveDB)
                        {
                            settingsService.DeviceDeleteWithProperties(focusedTagId);
                            break;
                        }
                        else 
                        {
                            MessageBox.Show("У контроллера имеются в настройках блоки памяти (DB).\n Удалите сначала блоки памяти.", "Удаление", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }
                    else
                    {
                        return;
                    }
                
                default:
                    if (MessageBox.Show("Удалить?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        settingsService.DeviceDeleteWithProperties(focusedTagId);
                        break;
                    }
                    else
                    {
                        return;
                    }
            }
            
            settingSSManager.ShowWaitForm();

            deviceTree.Nodes.Clear();

            settingsService = Program.kernel.Get<ISettingsService>();
            ConfigClass.Instance.ConfigLoad(settingsService);

            CreateDeviceNodes(deviceTree);

            deviceTree.ExpandAll();

            settingSSManager.CloseWaitForm();
        }

        private void deviceTree_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
        {
            if (deviceTree.Nodes.Count > 0)
            {
                bool canVisible = (deviceTree.FocusedNode.Level >= 1);

                editDeviceBtnItem.Enabled = canVisible;
                deleteDeviceBtnItem.Enabled = canVisible;

                bool isPLC = (deviceTree.FocusedNode.Tag == null) ? false : ConfigClass.Instance.PlcSettingList.Any(s => s.DeviceId == (int)deviceTree.FocusedNode.Tag);

                addDbBtnItem.Enabled = (canVisible && isPLC);

                switch (deviceTree.FocusedNode.Level)
                {
                    case 1:
                        propertyGrid.BeginUpdate();
                        propertyGrid.DataSource = ConfigClass.Instance.DeviceSettingsList.Where(s => s.DeviceId == (int)deviceTree.FocusedNode.Tag);
                        propertyGrid.EndUpdate();
                        break;
                    case 2:
                        propertyGrid.BeginUpdate();

                        var settingDBList = ConfigClass.Instance.DeviceSettingsList.Where(s => s.DeviceId == (int)deviceTree.FocusedNode.Tag);
                        var settingDataItemList = ConfigClass.Instance.DataItemList.Where(w => w.DeviceId == (int)deviceTree.FocusedNode.Tag).Select(s => new DeviceInfoDTO() { KindName = s.Name, SettingValue = (s.AbsoleteItemName + "(" + s.TypeName + ")"), Description = ((s.CanListen) ? "включено" : "отключено") });
                        propertyGrid.DataSource = settingDBList.Union(settingDataItemList).ToList();
                        
                        propertyGrid.EndUpdate();
                        break;
                    default:
                        propertyGrid.DataSource = null;
                        break;
                }
            }
        }

        #endregion

        #region Method's

        private void EditPlcConfig(Utils.Operation operation, ConfigClass.PlcSettingSource model)
        {
            using (SettingsPlcEditFm plcEditFm = new SettingsPlcEditFm(operation, model))
            {
                if (plcEditFm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    settingSSManager.ShowWaitForm();

                    int return_DeviceId = plcEditFm.Return();

                    deviceTree.Nodes.Clear();

                    settingsService = Program.kernel.Get<ISettingsService>();
                    ConfigClass.Instance.ConfigLoad(settingsService);

                    CreateDeviceNodes(deviceTree);

                    deviceTree.ExpandAll();

                    settingSSManager.CloseWaitForm();
                }
            }
        }

        private void EditBarcodeScannerConfig(Utils.Operation operation, ConfigClass.BarcodeSettingSource model)
        {
            using (SettingScannerEditFm scannerEditFm = new SettingScannerEditFm(operation, model))
            {
                if (scannerEditFm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    settingSSManager.ShowWaitForm();

                    int return_DeviceId = scannerEditFm.Return();

                    deviceTree.Nodes.Clear();

                    settingsService = Program.kernel.Get<ISettingsService>();
                    ConfigClass.Instance.ConfigLoad(settingsService);

                    CreateDeviceNodes(deviceTree);

                    deviceTree.ExpandAll();

                    settingSSManager.CloseWaitForm();
                }
            }
        }

        private void EditStackerConfig(Utils.Operation operation, DevicesDTO model)
        {
            using (SettingsStackerEditFm stackerEditFm = new SettingsStackerEditFm(operation, model))
            {
                if (stackerEditFm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    settingSSManager.ShowWaitForm();

                    int return_DeviceId = stackerEditFm.Return();

                    deviceTree.Nodes.Clear();

                    settingsService = Program.kernel.Get<ISettingsService>();
                    ConfigClass.Instance.ConfigLoad(settingsService);

                    CreateDeviceNodes(deviceTree);

                    deviceTree.ExpandAll();

                    settingSSManager.CloseWaitForm();
                }
            }
        }

        private void EditDropoffWindowConfig(Utils.Operation operation, DeviceInfoDTO model)
        {
            using (SettingsDropoffWindEditFm dropoffEditFm = new SettingsDropoffWindEditFm(operation, model))
            {
                if (dropoffEditFm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    settingSSManager.ShowWaitForm();

                    int return_DeviceId = dropoffEditFm.Return();

                    deviceTree.Nodes.Clear();

                    settingsService = Program.kernel.Get<ISettingsService>();
                    ConfigClass.Instance.ConfigLoad(settingsService);

                    CreateDeviceNodes(deviceTree);

                    deviceTree.ExpandAll();

                    settingSSManager.CloseWaitForm();
                }
            }
        }

        private void EditDataItemsConfig(Utils.Operation operation, int deviceId, int parentDeviceId)
        {
            using (SettingsDBEditFm dataItemsEditFm = new SettingsDBEditFm(operation, deviceId, parentDeviceId))
            {
                if (dataItemsEditFm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    settingSSManager.ShowWaitForm();

                    int return_DeviceId = dataItemsEditFm.Return();

                    deviceTree.Nodes.Clear();

                    settingsService = Program.kernel.Get<ISettingsService>();
                    ConfigClass.Instance.ConfigLoad(settingsService);

                    CreateDeviceNodes(deviceTree);

                    deviceTree.ExpandAll();

                    settingSSManager.CloseWaitForm();
                }
            }
        }

        private void CreateDeviceNodes(TreeList tl)
        {
            tl.BeginUnboundLoad();

            int imageIndex = -1;

            settingsService = Program.kernel.Get<ISettingsService>();
            var deviceTypes = settingsService.GetDeviceTypes();
            var devices = settingsService.GetDevices(ConfigClass.Instance.LocalCPUID);

            foreach (var typeItem in deviceTypes)
            {
                switch (typeItem.TypeName)
                {
                    case "PLC":
                        imageIndex = 5;
                        break;
                    case "BarcodeScanner":
                        imageIndex = 6;
                        break;
                    case "Stacker":
                        imageIndex = 1;
                        break;
                    case "DropoffWindow":
                        imageIndex = 2;
                        break;
                    default:
                        break;
                }

                if (typeItem.TypeName != "DB")
                {
                    TreeListNode parentForRootNodes = null;
                    TreeListNode rootNode = tl.AppendNode(new object[] { typeItem.TypeDescription }, parentForRootNodes);

                    rootNode.StateImageIndex = imageIndex;
                    rootNode.Tag = typeItem.Id;



                    var childDeviceList = devices.Where(s => s.TypeId == typeItem.Id);

                    foreach (var deviceItem in childDeviceList)
                    {
                        TreeListNode childNode = tl.AppendNode(new object[] { deviceItem.Name }, rootNode);
                        childNode.Tag = deviceItem.Id;
                        childNode.StateImageIndex = 7;

                        if (typeItem.TypeName == "PLC")
                        {
                            var childPLCList = ConfigClass.Instance.DataItemList.Where(w => w.ParentDeviceId == deviceItem.Id).Select(s => new { s.DeviceId, s.DeviceName }).Distinct().ToList();

                            if (childPLCList.Count() > 0)
                            {
                                foreach (var dbItem in childPLCList)
                                {
                                    TreeListNode childPLCNode = tl.AppendNode(new object[] { dbItem.DeviceName }, childNode);
                                    childPLCNode.Tag = dbItem.DeviceId;
                                    childPLCNode.StateImageIndex = 0;
                                }
                            }
                        }
                    }
                }
            }

            tl.EndUnboundLoad();
        }

        #endregion

        #endregion

        #region General settings

        private void printBarcodeCommandBtn_Click(object sender, EventArgs e)
        {
            BarcodeAllCommandReport reportSource = new BarcodeAllCommandReport();
            
            using (ReportPrintTool printTool = new ReportPrintTool(reportSource))
            {
               printTool.ShowPreviewDialog(UserLookAndFeel.Default);
            }
        }

        private void printSingleBarcodeCommandBtn_Click(object sender, EventArgs e)
        {
            BindingSource reportBS = new BindingSource();
            List<TVM_WMS.GUI.Utils.BarcodeCommandSourse> comList = new List<TVM_WMS.GUI.Utils.BarcodeCommandSourse>();

            comList.Add(new TVM_WMS.GUI.Utils.BarcodeCommandSourse() { ComandNumber = 1, BarcodeText = "*1*1", CommandText = "ПОДТВЕРДИТЬ КОЛИЧЕСТВО" });
            comList.Add(new TVM_WMS.GUI.Utils.BarcodeCommandSourse() { ComandNumber = 2, BarcodeText = "*1*2", CommandText = "ПЕРЕВЫБРАТЬ КАССЕТУ" });
            comList.Add(new TVM_WMS.GUI.Utils.BarcodeCommandSourse() { ComandNumber = 3, BarcodeText = "*1*3", CommandText = "ЗАДВИНУТЬ КАССЕТУ С ПРИЗНАКОМ ЗАПОЛНЕНИЯ" });
            comList.Add(new TVM_WMS.GUI.Utils.BarcodeCommandSourse() { ComandNumber = 4, BarcodeText = "*1*4", CommandText = "ЗАДВИНУТЬ КАССЕТУ С ПРИЗНАКОМ ДОГРУЗКИ" });
            comList.Add(new TVM_WMS.GUI.Utils.BarcodeCommandSourse() { ComandNumber = 5, BarcodeText = "*1*5", CommandText = "ОТМЕНИТЬ ОПЕРАЦИЮ" });
            comList.Add(new TVM_WMS.GUI.Utils.BarcodeCommandSourse() { ComandNumber = 6, BarcodeText = "*1*6", CommandText = "ПРЕРВАТЬ ВЫПОЛНЕНИЕ ЗАДАНИЯ" });
            comList.Add(new TVM_WMS.GUI.Utils.BarcodeCommandSourse() { ComandNumber = 7, BarcodeText = "*1*7", CommandText = "ВЕРНУТЬ КАССЕТУ НА СКЛАД" });
            comList.Add(new TVM_WMS.GUI.Utils.BarcodeCommandSourse() { ComandNumber = 8, BarcodeText = "*1*8", CommandText = "ВЕРНУТЬ КАССЕТУ В ОКНО ВЫДАЧИ" });

            BarcodeLabelCommandReport report = new BarcodeLabelCommandReport();

            reportBS.DataSource = comList;
            report.DataSource = reportBS;
            report.FindControl("BarcodeText", true).DataBindings.Add("Text", reportBS, "BarcodeText");
            report.FindControl("CommandText", true).DataBindings.Add("Text", reportBS, "CommandText");

            ReportPrintTool pt = new ReportPrintTool(report);

            using (ReportPrintTool printTool = new ReportPrintTool(report))
            {
                printTool.ShowPreviewDialog(UserLookAndFeel.Default);
            }
        }

        #endregion

        #region Label settings

        #region Event's

        private void showStickerBtn_Click(object sender, EventArgs e)
        {
            BarcodeLabelReport report = new BarcodeLabelReport();

            report.FindControl("StickerOrderDate", true).Text = DateTime.Now.ToShortDateString();
            report.FindControl("StickerOrderDate", true).Visible = StickerOrderDateCheck.Checked;
            report.FindControl("StickerOrderDateLbl", true).Visible = StickerOrderDateCheck.Checked;

            report.FindControl("StickerOrderNumber", true).Text = "1034";
            report.FindControl("StickerOrderNumber", true).Visible = StickerOrderNumberCheck.Checked;
            report.FindControl("StickerOrderNumberLbl", true).Visible = StickerOrderNumberCheck.Checked;

            report.FindControl("StickerPartNumber", true).Text = "20171012-12";
            report.FindControl("StickerPartNumber", true).Visible = StickerPartNumberCheck.Checked;
            report.FindControl("StickerPartNumberLbl", true).Visible = StickerPartNumberCheck.Checked;

            report.FindControl("StickerQuantity", true).Text = "160";
            report.FindControl("StickerQuantity", true).Visible = StickerQuantityCheck.Checked;
            report.FindControl("StickerQuantityLbl", true).Visible = StickerQuantityCheck.Checked;

            report.FindControl("StickerUnitLocalName", true).Text = "шт";
            report.FindControl("StickerUnitLocalName", true).Visible = StickerUnitLocalNameCheck.Checked;
            report.FindControl("StickerUnitLocalNameLbl", true).Visible = StickerUnitLocalNameCheck.Checked;

            report.FindControl("StickerArticle", true).Text = "1023650";
            report.FindControl("StickerArticle", true).Visible = StickerArticleCheck.Checked;
            report.FindControl("StickerArticleLbl", true).Visible = StickerArticleCheck.Checked;

            report.FindControl("StickerName", true).Text = "Лист ст.3";
            report.FindControl("StickerName", true).Visible = StickerNameCheck.Checked;
            report.FindControl("StickerNameLbl", true).Visible = StickerNameCheck.Checked;

            report.FindControl("StickerContractorName", true).Text = "General Motors";
            report.FindControl("StickerContractorName", true).Visible = StickerContractorNameCheck.Checked;
            report.FindControl("StickerContractorNameLbl", true).Visible = StickerContractorNameCheck.Checked;

            report.FindControl("StickerDateProduction", true).Text = DateTime.Now.ToShortDateString();
            report.FindControl("StickerDateProduction", true).Visible = StickerDateProductionCheck.Checked;
            report.FindControl("StickerDateProductionLbl", true).Visible = StickerDateProductionCheck.Checked;

            report.FindControl("StickerDateExpiration", true).Text = DateTime.Now.ToShortDateString();
            report.FindControl("StickerDateExpiration", true).Visible = StickerDateExpirationCheck.Checked;
            report.FindControl("StickerDateExpirationLbl", true).Visible = StickerDateExpirationCheck.Checked;

            ReportPrintTool pt = new ReportPrintTool(report);

            using (ReportPrintTool printTool = new ReportPrintTool(report))
            {
                printTool.ShowPreviewDialog(UserLookAndFeel.Default);
            }
        }

        private void saveStickerBtn_Click(object sender, EventArgs e)
        {
            settingSSManager.ShowWaitForm();

            try
            {
                var sourceList = (from gs in ConfigClass.Instance.GlobalSettingsList
                                  select new GlobalSettingsDTO
                                  {
                                      Id = gs.GlobalSettingId ?? 0,
                                      SettingTypeId = gs.SettingTypeId ?? 0,
                                      SettingKindId = gs.SettingKindId ?? 0,
                                      SettingValue = (gs.Printable) ? "True" : "False"
                                  })
                             .ToList();
                settingsService = Program.kernel.Get<ISettingsService>();

                settingsService.LabelSettingsUpdate(sourceList);

                settingSSManager.CloseWaitForm();
            }
            catch (Exception ex)
            {
                settingSSManager.CloseWaitForm();
                MessageBox.Show("Ошибка при сохранении настроек.\n" + ex.Message, "Сохранение", MessageBoxButtons.OK, MessageBoxIcon.Error);                
            }
            
        }

        private void StickerOrderDateCheck_CheckedChanged(object sender, EventArgs e)
        {
            StickerOrderDateLbl.ForeColor = (StickerOrderDateCheck.Checked) ? Color.Green : Color.DarkRed;
            ConfigClass.Instance.GlobalSettingsList.First(s => s.KindName == "StickerOrderDate").Printable = StickerOrderDateCheck.Checked;
        }

        private void StickerOrderNumberCheck_CheckedChanged(object sender, EventArgs e)
        {
            StickerOrderNumberLbl.ForeColor = (StickerOrderNumberCheck.Checked) ? Color.Green : Color.DarkRed;
            ConfigClass.Instance.GlobalSettingsList.First(s => s.KindName == "StickerOrderNumber").Printable = StickerOrderNumberCheck.Checked;
        }

        private void StickerQuantityCheck_CheckedChanged(object sender, EventArgs e)
        {
            StickerQuantityLbl.ForeColor = (StickerQuantityCheck.Checked) ? Color.Green : Color.DarkRed;
            ConfigClass.Instance.GlobalSettingsList.First(s => s.KindName == "StickerQuantity").Printable = StickerQuantityCheck.Checked;
        }

        private void StickerUnitLocalNameCheck_CheckedChanged(object sender, EventArgs e)
        {
            StickerUnitLocalNameLbl.ForeColor = (StickerUnitLocalNameCheck.Checked) ? Color.Green : Color.DarkRed;
            ConfigClass.Instance.GlobalSettingsList.First(s => s.KindName == "StickerUnitLocalName").Printable = StickerUnitLocalNameCheck.Checked;
        }

        private void StickerArticleCheck_CheckedChanged(object sender, EventArgs e)
        {
            StickerArticleLbl.ForeColor = (StickerArticleCheck.Checked) ? Color.Green : Color.DarkRed;
            ConfigClass.Instance.GlobalSettingsList.First(s => s.KindName == "StickerArticle").Printable = StickerArticleCheck.Checked;
        }

        private void StickerNameCheck_CheckedChanged(object sender, EventArgs e)
        {
            StickerNameLbl.ForeColor = (StickerNameCheck.Checked) ? Color.Green : Color.DarkRed;
            ConfigClass.Instance.GlobalSettingsList.First(s => s.KindName == "StickerName").Printable = StickerNameCheck.Checked;
        }

        private void StickerContractorNameCheck_CheckedChanged(object sender, EventArgs e)
        {
            StickerContractorNameLbl.ForeColor = (StickerContractorNameCheck.Checked) ? Color.Green : Color.DarkRed;
            ConfigClass.Instance.GlobalSettingsList.First(s => s.KindName == "StickerContractorName").Printable = StickerContractorNameCheck.Checked;
        }

        private void StickerDateProductionCheck_CheckedChanged(object sender, EventArgs e)
        {
            StickerDateProductionLbl.ForeColor = (StickerDateProductionCheck.Checked) ? Color.Green : Color.DarkRed;
            ConfigClass.Instance.GlobalSettingsList.First(s => s.KindName == "StickerDateProduction").Printable = StickerDateProductionCheck.Checked;
        }

        private void StickerDateExpirationCheck_CheckedChanged(object sender, EventArgs e)
        {
            StickerDateExpirationLbl.ForeColor = (StickerDateExpirationCheck.Checked) ? Color.Green : Color.DarkRed;
            ConfigClass.Instance.GlobalSettingsList.First(s => s.KindName == "StickerDateExpiration").Printable = StickerDateExpirationCheck.Checked;
        }

        private void StickerPartNumberCheck_CheckedChanged(object sender, EventArgs e)
        {
            StickerPartNumberLbl.ForeColor = (StickerPartNumberCheck.Checked) ? Color.Green : Color.DarkRed;
            ConfigClass.Instance.GlobalSettingsList.First(s => s.KindName == "StickerPartNumber").Printable = StickerPartNumberCheck.Checked;
        }

        #endregion

        #region Method's

        private void LabelPageInit()
        {
            var pageSourse = ConfigClass.Instance.GlobalSettingsList;

            var stickerOrderDateCheck = pageSourse.First(s => s.KindName == "StickerOrderDate").Printable;
            StickerOrderDateCheck.Checked = stickerOrderDateCheck;
            StickerOrderDateLbl.ForeColor = (stickerOrderDateCheck) ? Color.Green : Color.DarkRed;

            var stickerOrderNumberCheck = pageSourse.First(s => s.KindName == "StickerOrderNumber").Printable;
            StickerOrderNumberCheck.Checked = stickerOrderNumberCheck;
            StickerOrderNumberLbl.ForeColor = (stickerOrderNumberCheck) ? Color.Green : Color.DarkRed;

            var stickerPartNumberCheck = pageSourse.First(s => s.KindName == "StickerPartNumber").Printable;
            StickerPartNumberCheck.Checked = stickerPartNumberCheck;
            StickerPartNumberLbl.ForeColor = (stickerPartNumberCheck) ? Color.Green : Color.DarkRed;

            var stickerQuantityCheck = pageSourse.First(s => s.KindName == "StickerQuantity").Printable;
            StickerQuantityCheck.Checked = stickerQuantityCheck;
            StickerQuantityLbl.ForeColor = (stickerQuantityCheck) ? Color.Green : Color.DarkRed;

            var stickerUnitLocalNameCheck = pageSourse.First(s => s.KindName == "StickerUnitLocalName").Printable;
            StickerUnitLocalNameCheck.Checked = stickerUnitLocalNameCheck;
            StickerUnitLocalNameLbl.ForeColor = (stickerUnitLocalNameCheck) ? Color.Green : Color.DarkRed;

            var stickerArticleCheck = pageSourse.First(s => s.KindName == "StickerArticle").Printable;
            StickerArticleCheck.Checked = stickerArticleCheck;
            StickerArticleLbl.ForeColor = (stickerArticleCheck) ? Color.Green : Color.DarkRed;

            var stickerNameCheck = pageSourse.First(s => s.KindName == "StickerName").Printable;
            StickerNameCheck.Checked = stickerNameCheck;
            StickerNameLbl.ForeColor = (stickerNameCheck) ? Color.Green : Color.DarkRed;

            var stickerContractorNameCheck = pageSourse.First(s => s.KindName == "StickerContractorName").Printable;
            StickerContractorNameCheck.Checked = stickerContractorNameCheck;
            StickerContractorNameLbl.ForeColor = (stickerContractorNameCheck) ? Color.Green : Color.DarkRed;

            var stickerDateProductionCheck = pageSourse.First(s => s.KindName == "StickerDateProduction").Printable;
            StickerDateProductionCheck.Checked = stickerDateProductionCheck;
            StickerDateProductionLbl.ForeColor = (stickerDateProductionCheck) ? Color.Green : Color.DarkRed;

            var stickerDateExpirationCheck = pageSourse.First(s => s.KindName == "StickerDateExpiration").Printable;
            StickerDateExpirationCheck.Checked = stickerDateExpirationCheck;
            StickerDateExpirationLbl.ForeColor = (stickerDateExpirationCheck) ? Color.Green : Color.DarkRed;
        }

        #endregion

        #endregion

        #region Form event's

        private void saveBtn_Click(object sender, EventArgs e)
        {
            SaveConfiguration();

            //Допилить!!!!!!

            //if (ConfigClass.Instance.PlcSettingList.FirstOrDefault(s => s.Name == "plc") != null)
            //{

                //var plcSource = (ConfigClass.PlcSettingSource)ConfigClass.Instance.PlcSettingList.FirstOrDefault(s => s.Name == "plc1");


                //var plcSource = (ConfigClass.PlcSettingSource)ConfigClass.Instance.PlcSettingList.FirstOrDefault(s => s.DeviceId != 0);
                //var cpu = plcSource.CpuType;

                //plc = new WatchDog();
                //WatchDog.Instance.Connect(cpu, plcSource.Ip, plcSource.Rack, plcSource.Slot);
            //}

        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SettingsFm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_spManager != null)
                _spManager.Dispose();
        }

        private void openFolderLogFilesBtn_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
            folderBrowser.Description = "Выбор каталога для хранения Log файлов";

            DialogResult result = folderBrowser.ShowDialog();

            if (result == DialogResult.OK)
                logFileTBox.Text = folderBrowser.SelectedPath;
            else
                logFileTBox.Text = Directory.GetCurrentDirectory();
        }

        private void openReceiptXMLPathBtn_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
            folderBrowser.Description = "Выбор каталога для каталога файлов прихода";

            DialogResult result = folderBrowser.ShowDialog();

            if (result == DialogResult.OK)
                exportReceiptXMLTBox.Text = folderBrowser.SelectedPath;
            else
                exportReceiptXMLTBox.Text = Directory.GetCurrentDirectory();
        }

        private void openExpenditureXMLPathBtn_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
            folderBrowser.Description = "Выбор каталога для каталога файлов списания";

            DialogResult result = folderBrowser.ShowDialog();

            if (result == DialogResult.OK)
                exportExpenditureXMLTBox.Text = folderBrowser.SelectedPath;
            else
                exportExpenditureXMLTBox.Text = Directory.GetCurrentDirectory();
        }



        #endregion

        #region Form method's

        private void LoadConfiguration()
        {
            //ConfigClass.Instance.GetDbSettings(config);
            ConfigClass.Instance.GetLocaSettings(config);

            try
            {
                Program.kernel = new StandardKernel(new ServiceModule(ConfigClass.Instance.ConnectionString));
                settingsService = Program.kernel.Get<ISettingsService>();

                ConfigClass.Instance.ConfigLoad(settingsService);

                dbFilePathTBox.Text = ConfigClass.Instance.GlobalLocalSettings.DbAlias ?? "";
                dbIpTBox.Text = ConfigClass.Instance.GlobalLocalSettings.DbServerName ?? "";
                logFileTBox.Text = ConfigClass.Instance.GlobalLocalSettings.LogFilePath ?? "";
                numberSaveLogEdit.Text = ConfigClass.Instance.GlobalLocalSettings.LogSaveDay.ToString();
                exportReceiptXMLTBox.Text = ConfigClass.Instance.GlobalLocalSettings.ReceiptXMLPath ?? "";
                exportExpenditureXMLTBox.Text = ConfigClass.Instance.GlobalLocalSettings.ExpenditureXMLPath ?? "";
                watchDogPCEdit.Text = ConfigClass.Instance.GlobalLocalSettings.WatchDogPCOffset ?? "";
                watchDogPLCEdit.Text = ConfigClass.Instance.GlobalLocalSettings.WatchDogPLCOffset ?? "";
                watchDogDbNameEdit.Text = ConfigClass.Instance.GlobalLocalSettings.WatchDogDBName ?? "";
                watchDogPlcNameEdit.Text = ConfigClass.Instance.GlobalLocalSettings.WatchDogPLCName ?? "";

                scannerEdit.Properties.DataSource = ConfigClass.Instance.BarcodeSettingList.Select(s => new { s.DeviceId, s.Name }).Distinct().ToList();
                scannerEdit.Properties.ValueMember = "DeviceId";
                scannerEdit.Properties.DisplayMember = "Name";

                dataBlockEdit.Properties.DataSource = ConfigClass.Instance.DataItemList.Select(s => new { s.DeviceId, s.DeviceName}).Distinct().ToList();
                dataBlockEdit.Properties.ValueMember = "DeviceId";
                dataBlockEdit.Properties.DisplayMember = "DeviceName";

                var bindTreeDetailSource = settingsService.GetDeviceBindingSettings(ConfigClass.Instance.LocalCPUID).ToList();
                var bindTreeParentSource = settingsService.GetStoreBindings(ConfigClass.Instance.LocalCPUID).ToList();

                CreateNodes(stackerTree, bindTreeDetailSource, bindTreeParentSource);
                stackerTree.ExpandAll();

                CreateDeviceNodes(deviceTree);
                deviceTree.ExpandAll();

                testPlcBtn.Enabled = false;
                startListenBtn.Enabled = false;
                stopListenBtn.Enabled = false;
                refreshSpin.Enabled = false;

                barcodeConnectBtn.Enabled = false;

                LabelPageInit();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при инициализации базы данных! Проверьте настройки подключения.\n" + ex.Message, "Загрузка настроек", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dbFilePathTBox.Text = ConfigClass.Instance.GlobalLocalSettings.DbAlias ?? "";
                dbIpTBox.Text = ConfigClass.Instance.GlobalLocalSettings.DbServerName ?? "";

                settingsTab.SelectedTabPage = basePage;
            }

        }

        private void SaveConfiguration()
        {
            try
            {
                string connectionString = "User=SYSDBA; Password=masterkey; " +
                                          "DataBase=" + dbFilePathTBox.Text + "; " +
                                          "Server=" + dbIpTBox.Text + "; " +
                                          "Dialect=3";

                ConfigClass.Instance.ConnectionString = connectionString;
                ConfigClass.Instance.GlobalLocalSettings.DbServerName = dbIpTBox.Text;
                ConfigClass.Instance.GlobalLocalSettings.DbAlias = dbFilePathTBox.Text;
                ConfigClass.Instance.GlobalLocalSettings.LogFilePath = logFileTBox.Text;
                ConfigClass.Instance.GlobalLocalSettings.LogSaveDay = Convert.ToInt16(numberSaveLogEdit.Text);
                ConfigClass.Instance.GlobalLocalSettings.ReceiptXMLPath = exportReceiptXMLTBox.Text;
                ConfigClass.Instance.GlobalLocalSettings.ExpenditureXMLPath = exportExpenditureXMLTBox.Text;
                ConfigClass.Instance.GlobalLocalSettings.WatchDogPCOffset = watchDogPCEdit.Text;
                ConfigClass.Instance.GlobalLocalSettings.WatchDogPLCOffset = watchDogPLCEdit.Text;
                ConfigClass.Instance.GlobalLocalSettings.WatchDogDBName = watchDogDbNameEdit.Text;
                ConfigClass.Instance.GlobalLocalSettings.WatchDogPLCName = watchDogPlcNameEdit.Text;

                ConfigClass.Instance.SetLocalSettings(config);

                Program.kernel = new StandardKernel(new ServiceModule(connectionString));
                settingsService = Program.kernel.Get<ISettingsService>();

                ConfigClass.Instance.ConfigSave();

                ConfigClass.Instance.ConfigLoad(settingsService);

                Logger.InitLogger();

                MessageBox.Show("Обновление информации успешно!", "Обновление информации", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при обновлении!\n" + ex.Message, "Обновление информации", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        #endregion

        

       
        
    }
}