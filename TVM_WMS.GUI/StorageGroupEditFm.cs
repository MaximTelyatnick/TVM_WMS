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
    public partial class StorageGroupEditFm : DevExpress.XtraEditors.XtraForm
    {
        private IStorageGroupsService storageGroupsService;
        private BindingSource storageGroupsBS = new BindingSource();
        private Utils.Operation operation;

        public ObjectBase Item
        {
            get { return storageGroupsBS.Current as ObjectBase; }
            set
            {
                storageGroupsBS.DataSource = value;
                //set in edit mode
                value.BeginEdit();
            }
        }

        public StorageGroupEditFm(Utils.Operation operation, StorageGroupsDTO storageGroup)
        {
            InitializeComponent();

            LoadStorageGroupsData();
            this.operation = operation;
            storageGroupsBS.DataSource = Item = storageGroup;

            nameTBox.DataBindings.Add("EditValue", storageGroup, "StorageGroupName");
            descriptionTBox.DataBindings.Add("EditValue", storageGroup, "Description");
        }

        #region Event's

        private void saveBtn_Click(object sender, EventArgs e)
        {
            if (!ControlValidation()) return;

            if (MessageBox.Show("Сохранить изменения?", "Сохранение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                SaveStorageGroup();

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

        private void LoadStorageGroupsData()
        {
            storageGroupsService = Program.kernel.Get<IStorageGroupsService>();
        }

        private void SaveStorageGroup()
        {
            this.Item.EndEdit();

            if (this.operation == Utils.Operation.Add)
                ((StorageGroupsDTO)Item).StorageGroupId = storageGroupsService.StorageGroupsCreate((StorageGroupsDTO)Item);
            else
                storageGroupsService.StorageGroupsUpdate((StorageGroupsDTO)Item);
        }

        private bool ControlValidation()
        {
            return storageGroupValidationProvider.Validate();
        }

        public int Return()
        {
            return ((StorageGroupsDTO)Item).StorageGroupId;
        }

        # endregion

        #region Validation's

        private void nameTBox_TextChanged(object sender, EventArgs e)
        {
            storageGroupValidationProvider.Validate((Control)sender);
        }

        private void storageGroupValidationProvider_ValidationFailed(object sender, DevExpress.XtraEditors.DXErrorProvider.ValidationFailedEventArgs e)
        {
            this.saveBtn.Enabled = false;
            this.validateLbl.Visible = true;
        }

        private void storageGroupValidationProvider_ValidationSucceeded(object sender, DevExpress.XtraEditors.DXErrorProvider.ValidationSucceededEventArgs e)
        {
            bool isValidate = (storageGroupValidationProvider.GetInvalidControls().Count == 0);
            this.saveBtn.Enabled = isValidate;
            this.validateLbl.Visible = !isValidate;
        }
        # endregion
    }
}