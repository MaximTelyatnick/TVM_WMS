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
using Ninject;
using TVM_WMS.BLL.Infrastructure;
using TVM_WMS.BLL.Interfaces;
using TVM_WMS.BLL.BusinessLogicModule;
using System.IO;

namespace TVM_WMS.GUI
{
    public partial class AuthorizationSettingsFm : DevExpress.XtraEditors.XtraForm
    {
        IUsersService usersService;
        ISettingsService settingsService;

        private string HomePath = Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]);
        private string config;

        public AuthorizationSettingsFm()
        {
            InitializeComponent();

            config = HomePath + @"\Settings.xml";

            ConfigClass.Instance.GetLocaSettings(config);

            dbFilePathTBox.Text = ConfigClass.Instance.GlobalLocalSettings.DbAlias ?? "";
            dbIpTBox.Text = ConfigClass.Instance.GlobalLocalSettings.DbServerName ?? "";

        }

        private bool ControlValidation()
        {
            return baseValidationProvider.Validate();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            if (!ControlValidation()) return;

            if (MessageBox.Show("Сохранить изменения?", "Сохранение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (SaveBaseSettings())
                {
                    DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }

        private bool SaveBaseSettings()
        {
            try
            {
                string connectionString = "User=SYSDBA; Password=masterkey; " +
                                          "DataBase=" + dbFilePathTBox.Text + "; " +
                                          "Server=" + dbIpTBox.Text + "; " +
                                          "Dialect=3";

                ConfigClass.Instance.ConnectionString = connectionString;
                ConfigClass.Instance.GlobalLocalSettings.DbServerName = dbIpTBox.Text;
                ConfigClass.Instance.GlobalLocalSettings.DbAlias = dbFilePathTBox.Text;
                ConfigClass.Instance.SetLocalSettings(config);

                Program.kernel = new StandardKernel(new ServiceModule(connectionString));
                settingsService = Program.kernel.Get<ISettingsService>();

                ConfigClass.Instance.ConfigSave();

                ConfigClass.Instance.ConfigLoad(settingsService);

                MessageBox.Show("Изменения сохранены!", "Сохранение", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при сохранении!\n" + ex.Message, "Сохранение", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return false;
            }        
        }

        private string GetConnectionStringFromTestValue()
        {
            string testConnectionString = "User=SYSDBA; Password=masterkey; " +
                                          "DataBase=" + dbFilePathTBox.Text + "; " +
                                          "Server=" + dbIpTBox.Text + "; " +
                                          "Dialect=3; Charset=UTF8";

            return testConnectionString;
        }

        private void dbIpTBox_TextChanged(object sender, EventArgs e)
        {
            baseValidationProvider.Validate((Control)sender);
        }

        private void dbFilePathTBox_TextChanged(object sender, EventArgs e)
        {
            baseValidationProvider.Validate((Control)sender);
        }

        private void baseValidationProvider_ValidationFailed(object sender, DevExpress.XtraEditors.DXErrorProvider.ValidationFailedEventArgs e)
        {
            this.saveBtn.Enabled = false;
            this.validateLbl.Visible = true;
        }

        private void baseValidationProvider_ValidationSucceeded(object sender, DevExpress.XtraEditors.DXErrorProvider.ValidationSucceededEventArgs e)
        {
            bool isValidate = (baseValidationProvider.GetInvalidControls().Count == 0);
            this.saveBtn.Enabled = isValidate;
            this.validateLbl.Visible = !isValidate;
        }

        private void testDbBtn_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            
            try
            {
                Program.kernel = new StandardKernel(new ServiceModule(GetConnectionStringFromTestValue()));
                usersService = Program.kernel.Get<IUsersService>();
                var users = usersService.GetUsers();
                MessageBox.Show("Соединение успешно!", "Тест соединения", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при соединении! \n" + ex.Message, "Тест соединения", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            Cursor = Cursors.Default;
        }
    }
}