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
    public partial class ProfessionEditFm : DevExpress.XtraEditors.XtraForm
    {
        private BindingSource professionBS = new BindingSource();
        private IProfessionService professionService;
        private Utils.Operation operation;

        public ObjectBase Item
        {
            get { return professionBS.Current as ObjectBase; }
            set
            {
                professionBS.DataSource = value;
                //set in edit mode
                value.BeginEdit();
            }
        }

        public ProfessionEditFm(Utils.Operation operation, ProfessionsDTO profession)
        {
            InitializeComponent();

            professionService = Program.kernel.Get<IProfessionService>();
            this.operation = operation;
            professionBS.DataSource = Item = profession;

            professionNameTBox.DataBindings.Add("EditValue", professionBS, "ProfessionName");
        }

        # region Metod's

        private void SaveProfession()
        {
            this.Item.EndEdit();

            if (this.operation == Utils.Operation.Add)
                ((ProfessionsDTO)Item).Id = professionService.ProfessionCreate((ProfessionsDTO)Item);
            else
                professionService.ProfessionUpdate((ProfessionsDTO)Item);
        }

        private bool ControlValidation()
        {
            return professionValidationProvider.Validate();
        }

        private bool IsDuplicateRecord(string professionName)
        {
            int itemCount = professionService.GetProfession().Count(s => s.ProfessionName == professionName);

            return (itemCount > 0);
        }

        public int Return()
        {
            return ((ProfessionsDTO)Item).Id;
        }

        #endregion

        #region Events's

        private void saveBtn_Click(object sender, EventArgs e)
        {
            if (!ControlValidation()) return;

            if (MessageBox.Show("Сохранить изменения?", "Сохранение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (operation == Utils.Operation.Add && IsDuplicateRecord(((ProfessionsDTO)Item).ProfessionName))
                {
                    MessageBox.Show("Профессия уже существует!", "Сохранение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    professionNameTBox.Focus();
                    return;
                }

                SaveProfession();

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

        private void professionNameTBox_TextChanged(object sender, EventArgs e)
        {
            professionValidationProvider.Validate((Control)sender);
        }

        private void professionValidationProvider_ValidationFailed(object sender, DevExpress.XtraEditors.DXErrorProvider.ValidationFailedEventArgs e)
        {
            this.saveBtn.Enabled = false;
            this.validateLbl.Visible = true;
        }

        private void professionValidationProvider_ValidationSucceeded(object sender, DevExpress.XtraEditors.DXErrorProvider.ValidationSucceededEventArgs e)
        {
            bool isValidate = (professionValidationProvider.GetInvalidControls().Count == 0);
            this.saveBtn.Enabled = isValidate;
            this.validateLbl.Visible = !isValidate;
        }
        #endregion
    }

}