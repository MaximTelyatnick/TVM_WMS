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
    public partial class UserRoleEditFm : DevExpress.XtraEditors.XtraForm
    {

        private IUsersService usersService;
        private BindingSource userRoleBS = new BindingSource();
        private Utils.Operation operation;

        public ObjectBase Item
        {
            get { return userRoleBS.Current as ObjectBase; }
            set
            {
                userRoleBS.DataSource = value;
                //set in edit mode
                value.BeginEdit();
            }
        }

        public UserRoleEditFm(Utils.Operation operation, UserRolesDTO userRole)
        {
            InitializeComponent();
            
            this.operation = operation;
            userRoleBS.DataSource = Item = userRole;

            roleNameTBox.DataBindings.Add("EditValue", userRoleBS, "RoleName");
        }

        # region Metod's

        private void SaveUserRole()
        {
            this.Item.EndEdit();

            

            if (this.operation == Utils.Operation.Add)
                ((UserRolesDTO)Item).RoleId = usersService.UserRoleCreate((UserRolesDTO)Item);
            else
                usersService.UserRoleUpdate((UserRolesDTO)Item);
        }

        private bool ControlValidation()
        {
            return userRoleValidationProvider.Validate();
        }

        private bool IsDuplicateRecord(string roleName)
        {
            return usersService.GetUserRoles().Any(s => s.RoleName == roleName);
        }

        public int Return()
        {
            return ((UserRolesDTO)Item).RoleId;
        }

        #endregion

        #region Events's

        private void saveBtn_Click(object sender, EventArgs e)
        {
            if (!ControlValidation()) return;

            if (MessageBox.Show("Сохранить изменения?", "Сохранение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                usersService = Program.kernel.Get<IUsersService>();
                
                if (operation == Utils.Operation.Add && IsDuplicateRecord(((UserRolesDTO)Item).RoleName))
                {
                    MessageBox.Show("Группа с такими кодом уже существует!", "Сохранение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    roleNameTBox.Focus();
                    return;
                }

                SaveUserRole();

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

        private void roleNameTBox_TextChanged(object sender, EventArgs e)
        {
            userRoleValidationProvider.Validate((Control)sender);
        }


        private void userRoleValidationProvider_ValidationFailed(object sender, DevExpress.XtraEditors.DXErrorProvider.ValidationFailedEventArgs e)
        {
            this.saveBtn.Enabled = false;
            this.validateLbl.Visible = true;
        }

        private void userRoleValidationProvider_ValidationSucceeded(object sender, DevExpress.XtraEditors.DXErrorProvider.ValidationSucceededEventArgs e)
        {
            bool isValidate = (userRoleValidationProvider.GetInvalidControls().Count == 0);
            this.saveBtn.Enabled = isValidate;
            this.validateLbl.Visible = !isValidate;
        }
        #endregion
    }
}