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

namespace TVM_WMS.GUI
{
    public partial class QuantityEditFm : DevExpress.XtraEditors.XtraForm
    {
        decimal currentQuantity;
        decimal maxQuantity;

        public QuantityEditFm(decimal currentQuantity, decimal maxQuantity)
        {
            InitializeComponent();
            this.currentQuantity = currentQuantity;
            this.maxQuantity = maxQuantity;
            quantityTBox.EditValue = currentQuantity;
            maхQuantityLbl.Text = "Допустимое количество, шт - " + maxQuantity.ToString(); 
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            this.Close();
        }

        public decimal Return()
        {
            return (decimal)quantityTBox.EditValue;
        }

        private void quantityTBox_EditValueChanged(object sender, EventArgs e)
        {
            if ((decimal)quantityTBox.EditValue > maxQuantity)
            {
                MessageBox.Show("Введенное значение не может превышать количество, имеющееся на хранении!" , "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                quantityTBox.EditValue = currentQuantity;
                quantityTBox.Refresh();
                quantityTBox.Focus();
            }
        }
    }
}