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
using Ninject;

namespace TVM_WMS.GUI
{
    public partial class AuthorizationFm : DevExpress.XtraEditors.XtraForm
    {
        private IUsersService usersService;
        
        public AuthorizationFm()
        {
            InitializeComponent();
        }
        
        private void settingsBtn_Click(object sender, EventArgs e)
        {
            using (AuthorizationSettingsFm settingFm = new AuthorizationSettingsFm())
            {
                settingFm.ShowDialog();
            }
        }

        private void signBtn_Click(object sender, EventArgs e)
        {
            usersService = Program.kernel.Get<IUsersService>();

            if (loginTBox.Text.Length > 0 && passwordTBox.Text.Length > 0)
            {
                Cursor = Cursors.WaitCursor;
                try
                {
                    if (usersService.TryAuthorize(loginTBox.Text, passwordTBox.Text))
                    {                        
                        this.Hide();

                        new SplashScreenFm().ShowDialog();
                    }
                    else
                    {
                        XtraMessageBox.Show("Неверный логин или пароль!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("Не удалось подключиться к базе данных!\n" + ex.Message, "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                Cursor = Cursors.Default;
            }
            else
            {
                XtraMessageBox.Show("Не указан логин или пароль!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Cursor = Cursors.Default;
                passwordTBox.Focus();
            }
        }

        private void passwordTBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.signBtn_Click(signBtn, new EventArgs());
            }
        }

        private void AuthorizationFm_Shown(object sender, EventArgs e)
        {
            #if DEBUG

            loginTBox.Text = "Admin";
            passwordTBox.Text = "1111";

            signBtn_Click(signBtn, EventArgs.Empty);

            #endif
        }
    }
}