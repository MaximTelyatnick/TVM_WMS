using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using TVM_WMS.BLL.Interfaces;
using TVM_WMS.BLL.BusinessLogicModule;
using TVM_WMS.BLL.DTO;
using Ninject;
using DevExpress.XtraEditors.DXErrorProvider;

namespace TVM_WMS.GUI
{
    public partial class UserEditFm : DevExpress.XtraEditors.XtraForm
    {
        private IUsersService usersService;
        private BindingSource usersBS = new BindingSource();
        private Utils.Operation operation;

        public ObjectBase Item
        {
            get { return usersBS.Current as ObjectBase; }
            set
            {
                usersBS.DataSource = value;
                //set in edit mode
                value.BeginEdit();
            }
        }

        private class CustomValidationRule : ValidationRule
        {
            public override bool Validate(Control control, object value)
            {
                string str = value as String;
                if (str != null)
                    return (str.Length > 0 && str.Length <= 20);
                else
                    return false;
            }
        }

        public UserEditFm(Utils.Operation operation, UsersDTO model)
        {
            InitializeComponent();

            usersService = Program.kernel.Get<IUsersService>();

            this.operation = operation;
            usersBS.DataSource = Item = model;

            fioTBox.DataBindings.Add("EditValue", usersBS, "Fio");
            loginTBox.DataBindings.Add("EditValue", usersBS, "Login");
            passwordTBox.DataBindings.Add("EditValue", usersBS, "Password");
            
            roleEdit.DataBindings.Add("EditValue", usersBS, "UserRoleId");
            roleEdit.Properties.DataSource = usersService.GetUserRoles();
            roleEdit.Properties.ValueMember = "RoleId";
            roleEdit.Properties.DisplayMember = "RoleName";

            if (operation == Utils.Operation.Add)
                roleEdit.EditValue = 0;

            CustomValidationRule customValidationRule = new CustomValidationRule();
            customValidationRule.ErrorText = "Поле пароль обязательное для заполнения, длинной не более 20 символов";
            customValidationRule.ErrorType = ErrorType.Critical;

            userValidationProvider.SetValidationRule(passwordTBox, customValidationRule);

            userValidationProvider.Validate();
        }

        #region Event's

        private void saveBtn_Click(object sender, EventArgs e)
        {
            if (!ControlValidation()) return;

            if (MessageBox.Show("Сохранить изменения?", "Сохранение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (operation == Utils.Operation.Add && IsDuplicateRecord(((UsersDTO)Item).Login))
                {
                    MessageBox.Show("Пользователь с такими данными уже существует!", "Сохранение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    loginTBox.Focus();
                    return;
                }
                
                SaveUser();

                DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Item.CancelEdit();

            this.Close();
        }

        private void passwordChk_CheckedChanged(object sender, EventArgs e)
        {
            passwordTBox.Properties.UseSystemPasswordChar = !passwordChk.Checked;
        }

        #endregion
               
        
        #region Method's

        private void SaveUser()
        {
            this.Item.EndEdit();

            if (this.operation == Utils.Operation.Add)
                ((UsersDTO)Item).UserId = usersService.UserCreate((UsersDTO)Item);
            else
                usersService.UserUpdate((UsersDTO)Item);
        }

        private bool IsDuplicateRecord(string login)
        {
            int itemCount = usersService.GetUsers().Count(s => s.Login == login);

            return (itemCount > 0);
        }

        private bool ControlValidation()
        {
            return userValidationProvider.Validate();
        }

        public int Return()
        {
            return ((UsersDTO)Item).UserId;
        }

        #endregion


        #region Validation's

        private void fioTBox_TextChanged(object sender, EventArgs e)
        {
            userValidationProvider.Validate((Control)sender);
        }

        private void loginTBox_TextChanged(object sender, EventArgs e)
        {
            userValidationProvider.Validate((Control)sender);
        }

        private void passwordTBox_TextChanged(object sender, EventArgs e)
        {
            userValidationProvider.Validate((Control)sender);
        }

        private void roleEdit_EditValueChanged(object sender, EventArgs e)
        {
            userValidationProvider.Validate((Control)sender);
        }

        private void userValidationProvider_ValidationFailed(object sender, DevExpress.XtraEditors.DXErrorProvider.ValidationFailedEventArgs e)
        {
            this.saveBtn.Enabled = false;
            this.validateLbl.Visible = true;
        }

        private void userValidationProvider_ValidationSucceeded(object sender, DevExpress.XtraEditors.DXErrorProvider.ValidationSucceededEventArgs e)
        {
            bool isValidate = (userValidationProvider.GetInvalidControls().Count == 0);
            this.saveBtn.Enabled = isValidate;
            this.validateLbl.Visible = !isValidate;
        }

        #endregion

    }
}