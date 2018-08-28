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

namespace TVM_WMS.GUI
{
    public partial class ExpendituresFromKeepingFm : DevExpress.XtraEditors.XtraForm
    {
        private IEnumerable<StoreNamesDTO> storeList;
        private IEnumerable<StoreNamesDTO> storeHeaderList;
        private IEnumerable<StoreBindingsDTO> storeBindingsList;

        private IReceiptsService receiptsService;
        private IStoreNamesService storeNamesService;
        private IWareHousesService wareHousesService;
        private IMaterialsService materialsService;
        private ISettingsService settingsService;
        private IKeepingsService keepingsService;
        private IExpendituresService expendituresService;
        private IReceiptAcceptancesService receiptAcceptancesService;
        private IOrdersService ordersService;

        private BindingSource keepingBS = new BindingSource();
        private BindingSource keepingsFirtWndBS = new BindingSource();
        private BindingSource keepingsSecondWndBS = new BindingSource();
        private IEnumerable<KeepingMaterialsDTO> keepingMaterials;
        private List<CellPresenceDTO> cellPresenceList;
        private List<ExpendituresDTO> expenditureMaterials = new List<ExpendituresDTO>();

        private int storageId;

        private int firstWindDefaultCell = -1;
        private int secondWindDefaultCell = -1;

        public ExpendituresFromKeepingFm()
        {
            InitializeComponent();
            splashScreenManager.ShowWaitForm();
            LoadStoreNamesData();

            storageId = storeHeaderList.FirstOrDefault().StoreNameId;
            storageListEdit.DataSource = storeHeaderList;
            storageListEdit.DisplayMember = "Name";
            storageListEdit.ValueMember = "StoreNameId";
            storageListEditItem.EditValue = storageId;
            cellCompletedFirstChk.EditValue = "0";

            LoadKeepingData(storageId);
            locateBtn.Enabled = (keepingBS.Count > 0);

            splitContainerControl1.SplitterPosition = (this.Height - ribbonControl1.Height);
            splashScreenManager.CloseWaitForm();
        }
        
        private void LoadKeepingData(int storeEntry)
        {
            receiptsService = Program.kernel.Get<IReceiptsService>();
            wareHousesService = Program.kernel.Get<IWareHousesService>();
            materialsService = Program.kernel.Get<IMaterialsService>();
            keepingsService = Program.kernel.Get<IKeepingsService>();
            expendituresService = Program.kernel.Get<IExpendituresService>();

            keepingMaterials = keepingsService.GetExpendituresFromKeeping().Where(s => s.StoreNameId == storeEntry || s.StoreNameId == 0).ToList();
            keepingBS.DataSource = keepingMaterials;
            expendituresGrid.DataSource = keepingBS;
        }

        private void LoadStoreNamesData()
        {
            storeNamesService = Program.kernel.Get<IStoreNamesService>();

            storeList = storeNamesService.GetStoreNames();
            storeHeaderList = storeList.Where(s => s.ParentId == null);
        }

        private bool TakeKeeping(KeepingMaterialsDTO model)
        {
            receiptsService = Program.kernel.Get<IReceiptsService>();
            receiptAcceptancesService = Program.kernel.Get<IReceiptAcceptancesService>();
            ordersService = Program.kernel.Get<IOrdersService>();
            keepingsService = Program.kernel.Get<IKeepingsService>();
            expendituresService = Program.kernel.Get<IExpendituresService>();

            int wareHouseId = model.WareHouseId;

            if (wareHouseId > 0)
            {
                firstWindDefaultCell = wareHouseId;

                if ((int)barEditItem1.EditValue == 0)
                {
                    if (cellPresenceList == null)
                       cellPresenceList = wareHousesService.GetCellPresence(wareHouseId).ToList();

                    keepingsFirtWndBS.DataSource = cellPresenceList;
                    keepingsFirstWindGrid.DataSource = keepingsFirtWndBS;

                    WareHousesDTO cellInfo = wareHousesService.GetCellInfo(wareHouseId);
                    numberCellFirstLbl.Text = cellInfo.NumberCell.ToString();
                    cellCompletedFirstChk.EditValue = (cellInfo.LoadingStatusId == 3 ? true : false);

                    bool canEdit = true;

                    ConfirmQuantityDTO kdto = new ConfirmQuantityDTO
                    {
                        Quantity = (decimal)model.QuantityStore,
                        Article = model.Article,
                        MaterialName = model.MaterialName,
                        KeepingId = model.KeepingId
                    };

                    //using (ConfirmQuantityFm confirmQuantityFm = new ConfirmQuantityFm(kdto, canEdit))
                    //{
                    //    if (confirmQuantityFm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    //    {
                    //        kdto = confirmQuantityFm.Return();

                    //        keepingsFirstWindGridView.BeginDataUpdate();
                    //        cellPresenceList.Where(c => c.KeepingId == (int)kdto.KeepingId).Select(c => { c.QuantityStore = (c.QuantityStore - kdto.Quantity); c.QuantityChanged = c.QuantityChanged + kdto.Quantity; return c; }).ToList();
                    //        keepingsFirstWindGridView.EndDataUpdate();

                    //        expendituresGridView.BeginDataUpdate();
                    //        keepingMaterials.Where(c => c.KeepingId == (int)kdto.KeepingId).Select(k => { k.QuantityStore = (k.QuantityStore - kdto.Quantity); return k; }).ToList();
                    //        expendituresGridView.EndDataUpdate();

                    //        int rowHandle = keepingsFirstWindGridView.LocateByValue("KeepingId", model.KeepingId);
                    //        keepingsFirstWindGridView.FocusedRowHandle = rowHandle;
                    //    }
                    //}
                }

                return true;
            }
            else
                return false;
        }

        private void puchFirstBtn_Click(object sender, EventArgs e)
        {
            SaveDate();
        }

        private void SaveDate()
        {
            expenditureMaterials = cellPresenceList.Where(c => c.QuantityChanged > 0).Select(c => new ExpendituresDTO { KeepingId = c.KeepingId, ReceiptAcceptanceId = c.ReceiptAcceptanceId, Quantity = c.QuantityChanged, ExpDate = DateTime.Today }).ToList();

            if (expenditureMaterials.Count > 0)
            {
                WareHousesDTO whdto = wareHousesService.GetWareHouseById(firstWindDefaultCell);

                int loading = (cellPresenceList.Sum(c => c.QuantityStore) == 0 ? 1 : 2);
                whdto.LoadingStatusId = (cellCompletedFirstChk.Checked) ? 3 : loading;
                wareHousesService.WareHousesUpdate(whdto);

                expendituresService.CreateRange(expenditureMaterials);
                expenditureMaterials.Clear();
                cellPresenceList.Clear();
                LoadKeepingData(storageId);
            }

            cellCompletedFirstChk.Checked = false;
            numberCellFirstLbl.Text = "";
            keepingsFirtWndBS.DataSource = null;
            firstWindDefaultCell = -1;
        }

        private void repositoryItemButtonEdit1_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 0) 
            {
                if (((KeepingMaterialsDTO)keepingBS.Current).QuantityStore != 0)
                {
                    if (TakeKeeping((KeepingMaterialsDTO)keepingBS.Current))
                    {


                    }
                    else
                    {
                        MessageBox.Show("");
                    }
                }
                
            }
            
        }

        private void editBtnRepository_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            decimal currentQuantity = ((CellPresenceDTO)keepingsFirtWndBS.Current).QuantityChanged;
            if (currentQuantity > 0)
            {
                if (e.Button.Index == 0)// редактировать
                {
                    decimal maxQuantity = ((CellPresenceDTO)keepingsFirtWndBS.Current).QuantityKeeping;
                    using (QuantityEditFm quantytiEditFm = new QuantityEditFm(currentQuantity, maxQuantity))
                    {
                        if (quantytiEditFm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        {
                            decimal return_quantity = quantytiEditFm.Return();
                            int currentId = ((CellPresenceDTO)keepingsFirtWndBS.Current).KeepingId;
                            decimal quantity = ((CellPresenceDTO)keepingsFirtWndBS.Current).QuantityChanged - return_quantity;
                            expendituresGridView.BeginDataUpdate();
                            keepingMaterials.Where(c => c.KeepingId == currentId).Select(k => { k.QuantityStore = (k.QuantityStore + quantity); return k; }).ToList();
                            expendituresGridView.EndDataUpdate();
                            keepingsFirstWindGridView.BeginUpdate();
                            cellPresenceList.Where(c => c.KeepingId == currentId).Select(c => { c.QuantityChanged = return_quantity; c.QuantityStore = (c.QuantityStore + quantity); return c; }).ToList();
                            keepingsFirstWindGridView.EndUpdate();

                        }
                    }
                }
                if (e.Button.Index == 1)// удалить
                {
                    if (MessageBox.Show("Отменить списание выбранной номенклатуры?", "Подтвердить", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        int currentId = ((CellPresenceDTO)keepingsFirtWndBS.Current).KeepingId;

                        expendituresGridView.BeginDataUpdate();
                        keepingMaterials.Where(c => c.KeepingId == currentId).Select(k => { k.QuantityStore = (k.QuantityStore + currentQuantity); return k; }).ToList();
                        expendituresGridView.EndDataUpdate();
                        keepingsFirstWindGridView.BeginDataUpdate();
                        cellPresenceList.Where(c => c.KeepingId == currentId).Select(c => { c.QuantityChanged = 0; c.QuantityStore = c.QuantityKeeping; return c; }).ToList();
                        keepingsFirstWindGridView.EndDataUpdate();

                    }
                }
            }

        }
   
    }
}