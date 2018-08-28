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
using TVM_WMS.BLL.DTO.QueryDTO;

namespace TVM_WMS.GUI
{
    public partial class DeficitEditFm : DevExpress.XtraEditors.XtraForm
    {
        private IDeficitMaterialsService deficitMaterialsService;
        private BindingSource deficitBS = new BindingSource();

        private Utils.Operation operation;

        public ObjectBase Item
        {
            get { return deficitBS.Current as ObjectBase; }
            set
            {
                deficitBS.DataSource = value;
                //set in edit mode
                value.BeginEdit();
            }
        }

        public DeficitEditFm(Utils.Operation operation, DeficitCalcMaterialsDTO deficitRate)
        {
            InitializeComponent();
            deficitMaterialsService = Program.kernel.Get<IDeficitMaterialsService>();
            deficitBS.DataSource = Item = deficitRate;
            this.operation = operation;

            articleTBox.DataBindings.Add("EditValue", deficitBS, "Article");
            nameTBox.DataBindings.Add("EditValue", deficitBS, "Name");
            unitLocalNameTBox.DataBindings.Add("EditValue", deficitBS, "UnitLocalName");
            rateTBox.DataBindings.Add("EditValue", deficitBS, "Rate", true, DataSourceUpdateMode.OnPropertyChanged);
        }

        public int Return()
        {
            return (int)((DeficitCalcMaterialsDTO)Item).DeficitMaterialId;
        }

        #region Validation's

        private void rateTBox_TextChanged(object sender, EventArgs e)
        {
            deficitValidationProvider.Validate((Control)sender);
        }

        private void deficitValidationProvider_ValidationFailed(object sender, DevExpress.XtraEditors.DXErrorProvider.ValidationFailedEventArgs e)
        {
            this.saveBtn.Enabled = false;
            this.validateLbl.Visible = true;
        }

        private void deficitValidationProvider_ValidationSucceeded(object sender, DevExpress.XtraEditors.DXErrorProvider.ValidationSucceededEventArgs e)
        {
            bool isValidate = (deficitValidationProvider.GetInvalidControls().Count == 0);
            this.saveBtn.Enabled = isValidate;
            this.validateLbl.Visible = !isValidate;
        }
        #endregion

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Item.CancelEdit();
            this.Close();
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            if (!ControlValidation()) return;

            if (MessageBox.Show("Сохранить изменения?", "Сохранение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Item.EndEdit();
         
                if (this.operation == Utils.Operation.Add)
                {
                    DeficitMaterialsDTO deficitDTO = new DeficitMaterialsDTO { MaterialId = ((DeficitCalcMaterialsDTO)Item).MaterialId, UnitId = ((DeficitCalcMaterialsDTO)Item).UnitId, Rate = ((DeficitCalcMaterialsDTO)Item).Rate };
                    ((DeficitCalcMaterialsDTO)Item).DeficitMaterialId = deficitMaterialsService.DeficitMaterialCreate(deficitDTO);
                }
                else
                {
                    DeficitMaterialsDTO deficitDTO = new DeficitMaterialsDTO { Id = (int)((DeficitCalcMaterialsDTO)Item).DeficitMaterialId, MaterialId = ((DeficitCalcMaterialsDTO)Item).MaterialId, UnitId = ((DeficitCalcMaterialsDTO)Item).UnitId, Rate = ((DeficitCalcMaterialsDTO)Item).Rate };
                    deficitMaterialsService.DeficitMaterialUpdate(deficitDTO);
                }
               
                DialogResult = DialogResult.OK;
                this.Close();
            }
            else
                this.Item.CancelEdit();
        }

        private bool ControlValidation()
        {
            return deficitValidationProvider.Validate();
        }

        private void DeficitEditFm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Item.CancelEdit();
        }

    }
}