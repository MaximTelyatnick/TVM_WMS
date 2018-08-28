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
    public partial class MaterialGroupEditFm : DevExpress.XtraEditors.XtraForm
    {     
      
        private IMaterialGroupsService materialGroupsService;
        private BindingSource materialGroupsBS = new BindingSource();

        private Utils.Operation operation;
        public ObjectBase Item
        {
            get { return materialGroupsBS.Current as ObjectBase; }
            set
            {
                materialGroupsBS.DataSource = value;
                //set in edit mode
                value.BeginEdit();
            }
        }

        public MaterialGroupEditFm(Utils.Operation operation, MaterialGroupsDTO materialGroup)
        {
            InitializeComponent();
            LoadMaterialGroupsData();
            this.operation = operation;
            materialGroupsBS.DataSource = Item = materialGroup;

            codeTBox.DataBindings.Add("EditValue", materialGroupsBS, "Code");
            nameTBox.DataBindings.Add("EditValue", materialGroupsBS, "Name");
            
            if (operation == Utils.Operation.Add)
               isRootGroupChBox.Visible = true;
            else
                isRootGroupChBox.Visible = false;
        }

        #region Event's

            private void isRootGroupChBox_CheckedChanged(object sender, EventArgs e)
            {
                if (isRootGroupChBox.Checked)
                    ((MaterialGroupsDTO)Item).ParentId = null;
                else
                {
                    if (((MaterialGroupsDTO)Item) != null)
                        ((MaterialGroupsDTO)Item).ParentId = ((MaterialGroupsDTO)Item).MaterialGroupId;
                }
            }

            private void saveBtn_Click(object sender, EventArgs e)
            {
                if (!ControlValidation()) return;

                if (MessageBox.Show("Сохранить изменения?", "Сохранение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (operation == Utils.Operation.Add && IsDuplicateRecord(((MaterialGroupsDTO)Item).Code))
                    {
                        MessageBox.Show("Группа с таким кодом уже существует!", "Сохранение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        codeTBox.Focus();
                        return;
                    }

                    SaveMaterialGroup();

                    DialogResult = DialogResult.OK;
                    this.Close();
                }

            }

            private void cancelBtn_Click(object sender, EventArgs e)
            {
                this.Item.CancelEdit();
                this.Close();
            }

        # endregion

        #region  Method's

            private void LoadMaterialGroupsData()
            {
                materialGroupsService = Program.kernel.Get<IMaterialGroupsService>();
            }

            private void SaveMaterialGroup()
            {
                this.Item.EndEdit();

                if (this.operation == Utils.Operation.Add)
                    ((MaterialGroupsDTO)Item).MaterialGroupId = materialGroupsService.MaterialGroupCreate((MaterialGroupsDTO)Item);
                else
                    materialGroupsService.MaterialGroupUpdate((MaterialGroupsDTO)Item);
            }

            private bool ControlValidation()
            {
                return materialGroupValidationProvider.Validate();
            }

            private bool IsDuplicateRecord(string code)
            {
                int itemCount = materialGroupsService.GetMaterialGroups().Count(s => s.Code == code);

                return (itemCount > 0);
            }

            public int Return()
            {
                return ((MaterialGroupsDTO)Item).MaterialGroupId;
            }

        # endregion

        #region Validation's

            private void codeTBox_TextChanged(object sender, EventArgs e)
            {
                materialGroupValidationProvider.Validate((Control)sender);
            }

            private void nameTBox_TextChanged(object sender, EventArgs e)
            {
                materialGroupValidationProvider.Validate((Control)sender);
            }

            private void materialValidationProvider_ValidationFailed(object sender, DevExpress.XtraEditors.DXErrorProvider.ValidationFailedEventArgs e)
            {
                this.saveBtn.Enabled = false;
                this.validateLbl.Visible = true;
            }

            private void materialValidationProvider_ValidationSucceeded(object sender, DevExpress.XtraEditors.DXErrorProvider.ValidationSucceededEventArgs e)
            {
                bool isValidate = (materialGroupValidationProvider.GetInvalidControls().Count == 0);
                this.saveBtn.Enabled = isValidate;
                this.validateLbl.Visible = !isValidate;
            }

        # endregion
    
    }
}