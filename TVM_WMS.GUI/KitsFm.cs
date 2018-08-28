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
    public partial class KitsFm : DevExpress.XtraEditors.XtraForm
    {
        private IReceiptAcceptancesService receiptAcceptancesService;
        private BindingSource receiptAcceptancesBS = new BindingSource();
        private BindingSource receiptBS = new BindingSource();
        List<ReceiptAcceptancesDTO> receiptAcceptances = new List<ReceiptAcceptancesDTO>();
        private ReceiptsDTO receiptDTO;

        public KitsFm(ReceiptsDTO receipt)
        {
            InitializeComponent();
            receiptBS.DataSource = receipt;
            receiptDTO = receipt;
            receiptAcceptancesService = Program.kernel.Get<IReceiptAcceptancesService>();

            orderNumberTBox.DataBindings.Add("EditValue", receiptBS, "OrderNumber");
            orderDateEdit.DataBindings.Add("EditValue", receiptBS, "OrderDate");
            articleTBox.DataBindings.Add("EditValue", receiptBS, "Article");
            nameTBox.DataBindings.Add("EditValue", receiptBS, "Name");
            quantityTBox.DataBindings.Add("EditValue", receiptBS, "Quantity");

            quantityInKitTBox.EditValue = receipt.Quantity;
            kitsControl.Controls["quantityInKitTBox"].Focus();
            saveBtn.Enabled = false;
        }

        #region Event's

            private void addBtn_Click(object sender, EventArgs e)
            {
                var quantityInKut = (decimal)quantityInKitTBox.EditValue;
                var sumKits = receiptAcceptances.Sum(r => r.Quantity);

                if (quantityInKut == 0) return;

                if ((quantityInKut + sumKits) > receiptDTO.Quantity)
                {
                    MessageBox.Show("Количество больше прихода!", "Сохранение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    QuantityInKit();
                    return;
                }

                var newDTO = new ReceiptAcceptancesDTO
                {
                    OrderId = receiptDTO.OrderId,
                    ReceiptId = receiptDTO.ReceiptId,
                    Quantity = quantityInKut,
                    StatusId = 5,
                };

                receiptAcceptances.Add(newDTO);

                receiptAcceptancesBS.DataSource = null;
                receiptAcceptancesBS.DataSource = receiptAcceptances;

                kitsGridView.BeginDataUpdate();
                kitsGrid.DataSource = receiptAcceptancesBS;
                kitsGridView.EndDataUpdate();
                QuantityInKit();
            }

            private void deleteBtn_Click(object sender, EventArgs e)
            {
                if (receiptAcceptancesBS.List.Count > 0)
                {
                    if (MessageBox.Show("Удалить данные?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        receiptAcceptancesBS.EndEdit();
                        var current = (ReceiptAcceptancesDTO)receiptAcceptancesBS.Current;
                        receiptAcceptances.Remove(current);
                        receiptAcceptancesBS.DataSource = receiptAcceptances;
                        kitsGrid.DataSource = receiptAcceptancesBS;
                        kitsGridView.RefreshData();
                        QuantityInKit();
                    }
                }
            }

            private void saveBtn_Click(object sender, EventArgs e)
            {
                if (receiptAcceptancesBS.List.Count > 0)
                {
                    if (MessageBox.Show("Сохранить изменения?", "Сохранение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        receiptAcceptancesService.CreateRange(receiptAcceptances);
                        DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
                else
                    MessageBox.Show("Комплектация уже существует! Для создания новой комплектации удалите текущую!", "Сохранение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        # endregion

        #region Metod's
            private void QuantityInKit()
            {
                var sum = receiptAcceptances.Sum(r => r.Quantity);
                var result = receiptDTO.Quantity - sum;
                quantityInKitTBox.EditValue = result;
                if (result == 0)
                {
                    addBtn.Enabled = false;
                    quantityInKitTBox.Enabled = false;
                    saveBtn.Enabled = true;
                }
                else
                {
                    addBtn.Enabled = true;
                    quantityInKitTBox.Enabled = true;
                    saveBtn.Enabled = false;
                }
                kitsControl.Controls["quantityInKitTBox"].Focus();
           }
        # endregion
    }
}