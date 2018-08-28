using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TVM_WMS.BLL.Infrastructure;
using Ninject;
using System.Threading;
using System.Configuration;
using TVM_WMS.BLL.Interfaces;
using TVM_WMS.BLL.BusinessLogicModule;
using System.IO;
using TVM_WMS.BLL.Infrastructure.Logger;

namespace TVM_WMS.GUI
{
    static class Program
    {
        private static string HomePath = Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]);
        public static IKernel kernel;

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            bool flag = false;
            Mutex mutex = new Mutex(false, "WMS", out flag);
            if (!flag)
            {
                MessageBox.Show("Программа уже запущена!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                ConfigClass.Instance.GetLocaSettings(HomePath + @"\Settings.xml");

                kernel = new StandardKernel(new ServiceModule(ConfigClass.Instance.ConnectionString));

                ISettingsService settingsService = kernel.Get<ISettingsService>();

                ConfigClass.Instance.ConfigLoad(settingsService);

                Logger.InitLogger();

                Logger.Log.Debug("Запуск программы.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при запуске программы.\n" + ex.Message, "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
            Application.Run(new AuthorizationFm());

            mutex.Close();
        }
    }
}
