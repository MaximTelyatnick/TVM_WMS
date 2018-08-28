using System;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace TVM_WMS.GUI
{
    public partial class SplashScreenFm : Form
    {
        public SplashScreenFm()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (progressBar1.Value != 260)
            {
                progressBar1.Value += 2;
            }
            else
            {
                timer1.Stop();
                this.Hide();
                new MainTabFm().ShowDialog();
            }
        }

    }
}
