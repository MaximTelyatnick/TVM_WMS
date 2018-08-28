using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ninject;
using System;
using System.Collections;

using TVM_WMS.BLL.BusinessLogicModule;
using TVM_WMS.BLL.Interfaces;
using TVM_WMS.BLL.Services;
using TVM_WMS.BLL.DTO;
using System.Collections.Generic;
using System.ComponentModel;

namespace TVM_WMS.GUI
{
    public partial class OrderEditFm : DevExpress.XtraEditors.XtraForm
    {
        private IOrdersService ordersService;
        private IContractorsService contractorsService;
        private IReceiptsService receiptsService;
        private IReceiptAcceptancesService receiptAcceptancesService;
        private BindingSource receiptsBS = new BindingSource();
        private BindingSource ordersBS = new BindingSource();
         
        private Utils.Operation operation;
        private ReceiptsDTO resultDTO;
        private IEnumerable<ReceiptsDTO> receiptsByOrder;

        public ObjectBase Item
        {
            get {return ordersBS.Current as ObjectBase;}
            set
            {
                ordersBS.DataSource = value;
                //set in edit mode
                value.BeginEdit();
            }
        }

        public OrderEditFm(Utils.Operation operation,OrdersDTO order)
        {
            InitializeComponent();
            LoadOrdersData();
            
            this.operation = operation;
            ordersBS.DataSource = Item = order;
    
            LoadReceiptsData();

            orderNumberTBox.DataBindings.Add("EditValue", ordersBS, "OrderNumber");
            orderDateTBox.DataBindings.Add("EditValue", ordersBS, "OrderDate", true, DataSourceUpdateMode.OnPropertyChanged);

            contractorsGridEdit.DataBindings.Add("EditValue", ordersBS, "ContractorId", true, DataSourceUpdateMode.OnPropertyChanged);
            contractorsGridEdit.Properties.DataSource = contractorsService.GetContractors();
            contractorsGridEdit.Properties.ValueMember = "ContractorId";
            contractorsGridEdit.Properties.DisplayMember = "Name";
            contractorsGridEdit.Properties.NullText = "[нет данных]";

            if (this.operation == Utils.Operation.Add)
            {
                ((OrdersDTO)Item).OrderDate = DateTime.Today;
                contractorsGridEdit.EditValue = 0;
            }
        }
      
        #region Event's

        private void saveBtn_Click(object sender, EventArgs e)
        {
            if ((!ControlValidation()) || (receiptsBS.Count <= 0)) return;

            if (MessageBox.Show("Сохранить изменения?", "Сохранение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                SaveOrder();

                DialogResult = DialogResult.OK;
                this.Close();
            }
            this.Close();

        }

        private void receiptsGridView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && ((DevExpress.XtraGrid.Views.Grid.GridView)sender).RowCount > 0)
            {
                deleteReceipt_();
            }
            if (e.KeyCode == Keys.Insert && ((DevExpress.XtraGrid.Views.Grid.GridView)sender).RowCount > 0)
            {
                addReceipt_();
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Item.CancelEdit();
            this.Close();
        }

        private void addReceiptBtn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            addReceipt_();
        }

        private void editReceiptBtn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            editReceipt_();
        }

        private void deleteReceiptBtn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            deleteReceipt_();
        }

        private void receiptsGridView_DoubleClick(object sender, System.EventArgs e)
        {
            editReceipt_();
        }

        private void contractorsGridEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            switch (e.Button.Index)
            {
                case 1: //Добавить
                    {
                        using (ContractorEditFm contractorEditFm = new ContractorEditFm(Utils.Operation.Add, new ContractorsDTO()))
                        {
                            if (contractorEditFm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                            {
                                int return_ContractorId = contractorEditFm.Return();

                                contractorsService = Program.kernel.Get<IContractorsService>();
                                contractorsGridEdit.Properties.DataSource = contractorsService.GetContractors();
                                contractorsGridEdit.EditValue = return_ContractorId;
                            }
                        }
                        break;
                    }
                case 2: //Корректировать
                    {
                        object key = contractorsGridEdit.EditValue;
                        var selectedIndex = contractorsGridEdit.Properties.GetIndexByKeyValue(key);

                        if (selectedIndex == -1) return;

                        using (ContractorEditFm contractorEditFm = new ContractorEditFm(Utils.Operation.Update, (ContractorsDTO)contractorsGridEdit.GetSelectedDataRow()))
                        {
                            if (contractorEditFm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                            {
                                int return_ContractorId = contractorEditFm.Return();

                                contractorsService = Program.kernel.Get<IContractorsService>();
                                contractorsGridEdit.Properties.DataSource = contractorsService.GetContractors();
                                contractorsGridEdit.EditValue = return_ContractorId;
                            }
                        }
                        break;
                    }
                case 3: //Справочник
                    {

                        new SpravochFm(Utils.GridName.Contractors).ShowDialog();
                        contractorsService = Program.kernel.Get<IContractorsService>();
                        contractorsGridEdit.Properties.DataSource = contractorsService.GetContractors();

                        object key = contractorsGridEdit.EditValue;
                        var selectedIndex = contractorsGridEdit.Properties.GetIndexByKeyValue(key);

                        if (selectedIndex == -1)
                            contractorsGridEdit.EditValue = 0;
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }

        #endregion

        #region Metod's

        private void LoadOrdersData()
        {
            ordersService = Program.kernel.Get<IOrdersService>();
            contractorsService = Program.kernel.Get<IContractorsService>();
            receiptsService = Program.kernel.Get<IReceiptsService>();
            receiptAcceptancesService = Program.kernel.Get<IReceiptAcceptancesService>();
        }

        private void LoadReceiptsData()
        {
            receiptsByOrder = receiptsService.GetReceipts().Where(m => m.OrderId == ((OrdersDTO)Item).OrderId).ToList();

            receiptsBS.DataSource = receiptsByOrder;
            receiptsGrid.DataSource = receiptsBS;
            receiptsGridView.BeginSummaryUpdate();
            receiptsGridView.EndSummaryUpdate();
        }

        private bool ControlValidation()
        {
            return orderValidationProvider.Validate();
        }

        public int Return()
        {
            return ((OrdersDTO)Item).OrderId;
        }

        private void SaveOrder()
        {
            this.Item.EndEdit();

            if (this.operation == Utils.Operation.Add)
            {
                ((OrdersDTO)Item).StatusId = 1; //К поступлению
                ((OrdersDTO)Item).OrderId = ordersService.OrderCreate((OrdersDTO)Item);

                List<ReceiptsDTO> receiptsDTO = (List<ReceiptsDTO>)receiptsBS.DataSource;
                receiptsDTO.Select(c => { c.OrderId = ((OrdersDTO)Item).OrderId; return c; }).ToList();

                for (int i = 0; i <= receiptsDTO.Count - 1; i++)
                {
                    int pId = receiptsService.ReceiptCreate(receiptsDTO[i]);
                }
            }
            else
            {
                ordersService.OrderUpdate((OrdersDTO)Item);

                receiptsBS.DataSource = receiptsByOrder;

                List<ReceiptsDTO> receiptsDTO = (List<ReceiptsDTO>)receiptsBS.DataSource;

                for (int i = 0; i <= receiptsDTO.Count - 1; i++)
                {
                    switch (receiptsDTO[i].Changes)
                    {
                        case 1: //добавлена запись
                            {
                                int pId = receiptsService.ReceiptCreate(receiptsDTO[i]);
                                break;
                            }
                        case 2://отредактирована запись
                            {
                                receiptsService.ReceiptUpdate(receiptsDTO[i]);
                                break;
                            }
                        case 3://удалена запись
                            {
                               Error.ErrorCRUD result = receiptsService.ReceiptDelete(receiptsDTO[i]);
                               switch (result)
                               {
                                   case Error.ErrorCRUD.RelationError:
                                       MessageBox.Show("Приход нельзя удалить. Есть связанные данные!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                       break;
                                   case Error.ErrorCRUD.DatabaseError:
                                       MessageBox.Show("Ошибка Базы данных!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                       break;
                                   default:
                                       break;
                               }
                               break;
                            }
                        default:
                            break;
                    }
                }
            }
        }

        private void addReceipt_()
        {
            using (ReceiptsEditFm receiptEditFm = new ReceiptsEditFm(Utils.Operation.Add, new ReceiptsDTO()))
            {
                if (receiptEditFm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    resultDTO = receiptEditFm.Return();
                    receiptsGridView.BeginUpdate();
                    resultDTO.Changes = 1;
                    resultDTO.OrderId = ((OrdersDTO)Item).OrderId;
                    receiptsBS.Add(resultDTO);
                    receiptsBS.EndEdit();
                    receiptsGridView.EndUpdate();
                }
            }
            receiptsGridView.BeginSummaryUpdate();
            receiptsGridView.EndSummaryUpdate();
            receiptsGrid.Refresh();
        }

        private void editReceipt_()
        {
            if ((ReceiptsDTO)receiptsBS.Current != null)
            {
                using (ReceiptsEditFm receiptEditFm = new ReceiptsEditFm(Utils.Operation.Update, (ReceiptsDTO)receiptsBS.Current))
                {
                    if (receiptEditFm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        resultDTO = receiptEditFm.Return();
                        receiptsGridView.BeginUpdate();

                        if (resultDTO.Changes == null)
                            resultDTO.Changes = 2;

                        resultDTO.OrderId = ((OrdersDTO)Item).OrderId;
                        ((ReceiptsDTO)receiptsBS.Current).OrderId = resultDTO.OrderId;
                        ((ReceiptsDTO)receiptsBS.Current).UnitPrice = resultDTO.UnitPrice;
                        ((ReceiptsDTO)receiptsBS.Current).TotalPrice = resultDTO.TotalPrice;
                        ((ReceiptsDTO)receiptsBS.Current).Quantity = resultDTO.Quantity;
                        ((ReceiptsDTO)receiptsBS.Current).MaterialId = resultDTO.MaterialId;
                        ((ReceiptsDTO)receiptsBS.Current).Name = resultDTO.Name;
                        ((ReceiptsDTO)receiptsBS.Current).Article = resultDTO.Article;
                        ((ReceiptsDTO)receiptsBS.Current).UnitId = resultDTO.UnitId;
                        ((ReceiptsDTO)receiptsBS.Current).UnitLocalName = resultDTO.UnitLocalName;
                        receiptsBS.EndEdit();
                        receiptsBS.ResetCurrentItem();
                        receiptsGridView.EndUpdate();
                    }
                }
                receiptsGridView.Focus();
                receiptsGrid.Refresh();
                receiptsGridView.BeginSummaryUpdate();
                receiptsGridView.EndSummaryUpdate();
            }
        }
        
        private void deleteReceipt_()
        {
            if ((ReceiptsDTO)receiptsBS.Current != null)
            {
                if (((ReceiptsDTO)receiptsBS.Current).ReceiptId != 0)
                {
                    if (receiptAcceptancesService.GetReceiptAcceptanceByReceiptId(((ReceiptsDTO)receiptsBS.Current).ReceiptId) == null)
                    {
                        receiptsByOrder.Where(m => m.ReceiptId == ((ReceiptsDTO)receiptsBS.Current).ReceiptId).Select(c => { c.Changes = 3; return c; }).ToList();

                        receiptsBS.DataSource = receiptsByOrder.Where(m => m.Changes != 3);
                        receiptsGrid.DataSource = receiptsBS;
                    }
                    else
                        MessageBox.Show("Приход нельзя удалить. Есть связанные данные!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    receiptsBS.RemoveCurrent();
                }

            }

        }
        #endregion

        #region Validation's

        private void orderNumberTBox_TextChanged(object sender, EventArgs e)
        {
            orderValidationProvider.Validate((Control)sender);
        }

        private void contractorGridEdit_EditValueChanged(object sender, EventArgs e)
        {
           orderValidationProvider.Validate((Control)sender);
        }

        private void orderDateTBox_EditValueChanged(object sender, EventArgs e)
        {
            orderValidationProvider.Validate((Control)sender);
        }

        private void orderValidationProvider_ValidationFailed(object sender, DevExpress.XtraEditors.DXErrorProvider.ValidationFailedEventArgs e)
        {
            this.saveBtn.Enabled = false;
            this.validateLbl.Visible = true;
        }

        private void orderValidationProvider_ValidationSucceeded(object sender, DevExpress.XtraEditors.DXErrorProvider.ValidationSucceededEventArgs e)
        {
            bool isValidate = (orderValidationProvider.GetInvalidControls().Count == 0);
            this.saveBtn.Enabled = isValidate;
            this.validateLbl.Visible = !isValidate;
        }

        # endregion
    }
}
