using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ninject;
using System.Collections;

using TVM_WMS.BLL.BusinessLogicModule;
using TVM_WMS.BLL.Interfaces;
using TVM_WMS.BLL.Services;
using TVM_WMS.BLL.DTO;

namespace TVM_WMS.GUI
{
    public partial class ReceiptsEditFm : DevExpress.XtraEditors.XtraForm
    {
        private IUnitsService unitsService;
        private IMaterialsService materialsService;
        private IReceiptsService receiptsService;
        private BindingSource receiptsBS = new BindingSource();

        private Utils.Operation operation;

        public ObjectBase Item
        {
            get { return receiptsBS.Current as ObjectBase; }
            set
            {
                receiptsBS.DataSource = value;
                //set in edit mode
                value.BeginEdit();
            }
        }

        public ReceiptsEditFm(Utils.Operation operation, ReceiptsDTO receipt)
        {
            InitializeComponent();
            LoadOrdersData();

            this.operation = operation;
            receiptsBS.DataSource = Item = receipt;

            quantityTBox.DataBindings.Add("EditValue", receiptsBS, "Quantity", true, DataSourceUpdateMode.OnPropertyChanged);
            unitPriceTBox.DataBindings.Add("EditValue", receiptsBS, "UnitPrice", true, DataSourceUpdateMode.OnPropertyChanged);
            totalPriceTBox.DataBindings.Add("EditValue", receiptsBS, "TotalPrice", true, DataSourceUpdateMode.OnPropertyChanged);
            dateProductionEdit.DataBindings.Add("EditValue", receiptsBS, "DateProduction", true, DataSourceUpdateMode.OnPropertyChanged);
            dateExpirationEdit.DataBindings.Add("EditValue", receiptsBS, "DateExpiration", true, DataSourceUpdateMode.OnPropertyChanged);

            materialsGridEdit.DataBindings.Add("EditValue", receiptsBS, "MaterialId", true, DataSourceUpdateMode.OnPropertyChanged);
            materialsGridEdit.Properties.DataSource = materialsService.GetMaterials();
            materialsGridEdit.Properties.ValueMember = "MaterialId";
            materialsGridEdit.Properties.DisplayMember = "Name";

            unitEdit.DataBindings.Add("EditValue", receiptsBS, "UnitId", true, DataSourceUpdateMode.OnPropertyChanged);
            unitEdit.Properties.DataSource = unitsService.GetUnits();
            unitEdit.Properties.ValueMember = "UnitId";
            unitEdit.Properties.DisplayMember = "UnitLocalName";

            if (this.operation == Utils.Operation.Add)
            {
                materialsGridEdit.EditValue = 0;
                unitEdit.EditValue = 0;
                materialsGridEdit.Text = "[нет данных]";
                ((ReceiptsDTO)Item).DateProduction = null;
                ((ReceiptsDTO)Item).DateExpiration = null;
            }

        }

        #region Event's

        private void saveBtn_Click(object sender, System.EventArgs e)
        {
            if (!ControlValidation()) return;

            if (MessageBox.Show("Сохранить изменения?", "Сохранение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ((ReceiptsDTO)Item).StatusId = 5;// Подготовлено
                ((ReceiptsDTO)Item).Name = ((MaterialsDTO)materialsGridEdit.GetSelectedDataRow()).Name;
                ((ReceiptsDTO)Item).Article = ((MaterialsDTO)materialsGridEdit.GetSelectedDataRow()).Article;
                ((ReceiptsDTO)Item).UnitLocalName = ((UnitsDTO)unitEdit.GetSelectedDataRow()).UnitLocalName;
                this.Item.EndEdit();
                DialogResult = DialogResult.OK;
            }
            else
                this.Item.CancelEdit();

            this.Close();
        }

        private void unitPriceTBox_TextChanged(object sender, System.EventArgs e)
        {
            CalcReceiptPayment();
        }

        private void cancelBtn_Click(object sender, System.EventArgs e)
        {
            this.Item.CancelEdit();
            this.Close();
        }

        private void unitEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            switch (e.Button.Index)
            {
                case 1: //Добавить
                    {
                        using (UnitEditFm unitEditFm = new UnitEditFm(Utils.Operation.Add, new UnitsDTO()))
                        {
                            if (unitEditFm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                            {
                                int return_UnitId = unitEditFm.Return();

                                unitsService = Program.kernel.Get<IUnitsService>();
                                unitEdit.Properties.DataSource = unitsService.GetUnits();
                                unitEdit.EditValue = return_UnitId;
                            }
                        }
                        break;
                    }
                case 2: //Корректировать
                    {
                        if (unitEdit.EditValue == DBNull.Value) return;

                        using (UnitEditFm unitEditFm = new UnitEditFm(Utils.Operation.Update, (UnitsDTO)unitEdit.GetSelectedDataRow()))
                        {
                            if (unitEditFm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                            {
                                int return_UnitId = unitEditFm.Return();

                                unitsService = Program.kernel.Get<IUnitsService>();
                                unitEdit.Properties.DataSource = unitsService.GetUnits();
                                unitEdit.EditValue = return_UnitId;
                            }
                        }
                        break;
                    }
                
                default:
                    {
                        break;
                    }
            }
        }

        private void materialsGridEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            switch (e.Button.Index)
            {
                case 1: //Добавить
                    {
                        using (MaterialEditFm materialEditFm = new MaterialEditFm(Utils.Operation.Add, new MaterialsDTO()))
                        {
                            if (materialEditFm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                            {
                                int return_MaterialId = materialEditFm.Return();

                                materialsService = Program.kernel.Get<IMaterialsService>();
                                materialsGridEdit.Properties.DataSource = materialsService.GetMaterials();
                                materialsGridEdit.EditValue = return_MaterialId;
                            }
                        }
                        break;
                    }
                case 2: //Корректировать
                    {
                        object key = materialsGridEdit.EditValue;
                        var selectedIndex = materialsGridEdit.Properties.GetIndexByKeyValue(key);

                        if (selectedIndex == -1) return;

                        using (MaterialEditFm materialEditFm = new MaterialEditFm(Utils.Operation.Update, (MaterialsDTO)materialsGridEdit.GetSelectedDataRow()))
                        {
                            if (materialEditFm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                            {
                                int return_MaterialId = materialEditFm.Return();

                                materialsService = Program.kernel.Get<IMaterialsService>();
                                materialsGridEdit.Properties.DataSource = materialsService.GetMaterials();
                                materialsGridEdit.EditValue = return_MaterialId;
                            }
                        }
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
            unitsService = Program.kernel.Get<IUnitsService>();
            materialsService = Program.kernel.Get<IMaterialsService>();
            receiptsService = Program.kernel.Get<IReceiptsService>();
        }

        private bool ControlValidation()
        {
            return receiptValidationProvider.Validate();
        }

        public ReceiptsDTO Return()
        {
            return (ReceiptsDTO)Item;
        }

        private void CalcReceiptPayment()
        {
            decimal curQuantity = ((ReceiptsDTO)Item).Quantity;
            decimal curUnitPrice = ((ReceiptsDTO)Item).UnitPrice;

            totalPriceTBox.EditValue = curQuantity * curUnitPrice;
        }
        #endregion

        #region Validation's

        private void quantityTBox_TextChanged(object sender, EventArgs e)
        {
            receiptValidationProvider.Validate((Control)sender);
            CalcReceiptPayment();
        }

        private void unitEdit_EditValueChanged(object sender, EventArgs e)
        {
            receiptValidationProvider.Validate((Control)sender);
        }

        private void materialsGridEdit_EditValueChanged(object sender, EventArgs e)
        {
            receiptValidationProvider.Validate((Control)sender);
        }

        private void receiptValidationProvider_ValidationFailed(object sender, DevExpress.XtraEditors.DXErrorProvider.ValidationFailedEventArgs e)
        {
            this.saveBtn.Enabled = false;
            this.validateLbl.Visible = true;
        }

        private void receiptValidationProvider_ValidationSucceeded(object sender, DevExpress.XtraEditors.DXErrorProvider.ValidationSucceededEventArgs e)
        {
            bool isValidate = (receiptValidationProvider.GetInvalidControls().Count == 0);
            this.saveBtn.Enabled = isValidate;
            this.validateLbl.Visible = !isValidate;
        }
        #endregion

       
    }
}
