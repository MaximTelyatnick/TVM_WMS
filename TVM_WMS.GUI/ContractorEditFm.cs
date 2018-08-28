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
    public partial class ContractorEditFm : Form
    {

        private IContractorsService contractorsService;
        private BindingSource contractorsBS = new BindingSource();
        private Utils.Operation operation;
        
        public ObjectBase Item
        {
            get { return contractorsBS.Current as ObjectBase; }
            set
            {
                contractorsBS.DataSource = value;
                //set in edit mode
                value.BeginEdit();
            }
        }

        public ContractorEditFm(Utils.Operation operation, ContractorsDTO contractor)
        {
            InitializeComponent();
            LoadContractorsData();
            this.operation = operation;
            contractorsBS.DataSource = Item = contractor;

            nameTBox.DataBindings.Add("EditValue", contractorsBS, "Name");
            shortNameTBox.DataBindings.Add("EditValue", contractorsBS, "ShortName");
            srnTBox.DataBindings.Add("EditValue", contractorsBS, "Srn");
            tinTBox.DataBindings.Add("EditValue", contractorsBS, "Tin");
         }

        #region Event's

        private void saveBtn_Click(object sender, EventArgs e)
        {
            if (!ControlValidation()) return;

            if (MessageBox.Show("Сохранить изменения?", "Сохранение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                SaveContractor();

                DialogResult = DialogResult.OK;
                this.Close();
            }

            this.Close();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Item.CancelEdit();
            this.Close();
        }

        # endregion

        #region Metod's

        private void LoadContractorsData()
        {
            contractorsService = Program.kernel.Get<IContractorsService>();
        }

        private void SaveContractor()
        {
            this.Item.EndEdit();

            if (this.operation == Utils.Operation.Add)
                ((ContractorsDTO)Item).ContractorId = contractorsService.ContractorCreate((ContractorsDTO)Item);
            else
                contractorsService.ContractorUpdate((ContractorsDTO)Item);
        }

        private bool ControlValidation()
        {
            return contractorValidationProvider.Validate();
        }

        public int Return()
        {
            return ((ContractorsDTO)Item).ContractorId;
        }

        # endregion

        #region Validation's

        private void nameTBox_TextChanged(object sender, EventArgs e)
        {
            contractorValidationProvider.Validate((Control)sender);
        }

        private void contractorValidationProvider_ValidationFailed(object sender, DevExpress.XtraEditors.DXErrorProvider.ValidationFailedEventArgs e)
        {
            this.saveBtn.Enabled = false;
            this.validateLbl.Visible = true;
        }

        private void contractorValidationProvider_ValidationSucceeded(object sender, DevExpress.XtraEditors.DXErrorProvider.ValidationSucceededEventArgs e)
        {
            bool isValidate = (contractorValidationProvider.GetInvalidControls().Count == 0);
            this.saveBtn.Enabled = isValidate;
            this.validateLbl.Visible = !isValidate;
        }
        # endregion
    }
}