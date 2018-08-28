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

namespace TVM_WMS.GUI
{
    public partial class UnitEditFm : DevExpress.XtraEditors.XtraForm
    {

        private IUnitsService unitsService;
        private BindingSource unitsBS = new BindingSource();
        private Utils.Operation operation;

        public ObjectBase Item
        {
            get { return unitsBS.Current as ObjectBase; }
            set
            {
                unitsBS.DataSource = value;
                //set in edit mode
                value.BeginEdit();
            }
        }

        public UnitEditFm(Utils.Operation operation, UnitsDTO unit)
        {
            InitializeComponent();
            unitsService = Program.kernel.Get<IUnitsService>();
            this.operation = operation;
            unitsBS.DataSource = Item = unit;

            unitLocalNameTBox.DataBindings.Add("EditValue", unitsBS, "UnitLocalName");
            unitFullNameTBox.DataBindings.Add("EditValue", unitsBS, "UnitFullName");
        }

        # region Metod's

     
          private void SaveUnit()
            {
                this.Item.EndEdit();

                if (this.operation == Utils.Operation.Add)
                    ((UnitsDTO)Item).UnitId = unitsService.UnitCreate((UnitsDTO)Item);
                else
                    unitsService.UnitUpdate((UnitsDTO)Item);
            }

            private bool ControlValidation()
            {
                return unitValidationProvider.Validate();
            }

            private bool IsDuplicateRecord(string unitLocalName)
            {
                int itemCount = unitsService.GetUnits().Count(s => s.UnitLocalName== unitLocalName);

                return (itemCount > 0);
            }

            public int Return()
            {
                return ((UnitsDTO)Item).UnitId;
            }

           #endregion

        #region Events's

            private void saveBtn_Click(object sender, EventArgs e)
            {
             if (!ControlValidation()) return;

             if (MessageBox.Show("Сохранить изменения?", "Сохранение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
             {
                 if (operation == Utils.Operation.Add && IsDuplicateRecord(((UnitsDTO)Item).UnitLocalName))
                 {
                     MessageBox.Show("Единица измерения с такими кодом уже существует!", "Сохранение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                     unitLocalNameTBox.Focus();
                     return;
                 }

                 SaveUnit();

                 DialogResult = DialogResult.OK;
                 this.Close();
             }
             }

            private void cancelBtn_Click(object sender, EventArgs e)
            {
                this.Item.CancelEdit();
                this.Close();
            }
            #endregion

        #region Validation's

        private void unitLocalNameTBox_TextChanged(object sender, EventArgs e)
        {
            unitValidationProvider.Validate((Control)sender);
         }

        private void unitFullName_TextChanged(object sender, EventArgs e)
        {
           unitValidationProvider.Validate((Control)sender);
        }

        private void unitValidationProvider_ValidationFailed(object sender, DevExpress.XtraEditors.DXErrorProvider.ValidationFailedEventArgs e)
        {
            this.saveBtn.Enabled = false;
            this.validateLbl.Visible = true;
        }

        private void unitValidationProvider_ValidationSucceeded(object sender, DevExpress.XtraEditors.DXErrorProvider.ValidationSucceededEventArgs e)
        {
            bool isValidate = (unitValidationProvider.GetInvalidControls().Count == 0);
            this.saveBtn.Enabled = isValidate;
            this.validateLbl.Visible = !isValidate;
        }
        #endregion
    }
}