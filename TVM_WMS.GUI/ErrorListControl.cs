using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using TVM_WMS.BLL.DTO;
using DevExpress.XtraGrid.Views.Grid;

namespace TVM_WMS.GUI
{
    public partial class ErrorListControl : DevExpress.XtraEditors.XtraUserControl
    {
        public ErrorListControl(List<AlarmsDTO> source)
        {
            InitializeComponent();

            alarmGrid.DataSource = source;
        }

        private void alarmGridView_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            GridView View = sender as GridView;
            if (e.RowHandle >= 0)
            {
                if (e.RowHandle % 2 != 0)
                    e.Appearance.BackColor = Color.LightGray;
            }
        }
    }
}
