using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ninject;
using System.Collections;
using DevExpress.XtraTreeList;

using TVM_WMS.BLL.BusinessLogicModule;
using TVM_WMS.BLL.Interfaces;
using TVM_WMS.BLL.Services;
using TVM_WMS.BLL.DTO;
using System.Collections.Generic;
using System;

namespace TVM_WMS.GUI
{
    public partial class RequirementOrdersFm : Form
    {
        private IRequirementsService requirementsService;
        private BindingSource requirementOrdersBS = new BindingSource();
        private BindingSource requirementMaterialsBS = new BindingSource();

        public RequirementOrdersFm()
        {
            InitializeComponent();
            splashScreenManager.ShowWaitForm();
            LoadOrdersData();
            splashScreenManager.CloseWaitForm();
        }

        public void LoadOrdersData()
        {
            requirementsService = Program.kernel.Get<IRequirementsService>();

            DateTime beginDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1); // год - месяц - день
            DateTime endDate = DateTime.Today;
            beginDateEdit.EditValue = beginDate;
            endDateEdit.EditValue = endDate;
            var orders = requirementsService.GetRequirementOrders(beginDate, endDate);
            requirementOrdersBS.DataSource = orders;
            requirementOrdersGrid.DataSource = null;
            requirementOrdersGrid.DataSource = requirementOrdersBS;

            LoadRequirementMaterialsData();
        }

        public void LoadRequirementMaterialsData()
        {
            var requirementMaterialsByOrders = (requirementOrdersBS.Count == 0 ? null : requirementsService.GetRequirementMaterials().Where(m => m.RequirementOrderId == ((RequirementOrdersDTO)requirementOrdersBS.Current).RequirementOrderId));
            this.requirementMaterialsGrid.DataSource = null;
            requirementMaterialsBS.DataSource = requirementMaterialsByOrders;
            this.requirementMaterialsGrid.DataSource = requirementMaterialsBS;
        }


        private void requirementOrdersGridView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            LoadRequirementMaterialsData();
        }

        private void deleteOrderBtn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            deleteOrder_();
        }

        private void deleteOrder_()
        {
            
                if (requirementOrdersBS.Count != 0)
                {
                    if (MessageBox.Show("Удалить документ?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (requirementMaterialsBS.Count != 0)
                        {
                            if (this.requirementsService.RequirementMaterialAllDelete(((RequirementOrdersDTO)requirementOrdersBS.Current).RequirementOrderId))
                            {
                                LoadRequirementMaterialsData();

                                if (this.requirementsService.RequirementOrderDelete((RequirementOrdersDTO)requirementOrdersBS.Current))
                                    this.requirementOrdersBS.RemoveCurrent();
                            }
                        }
                        else
                        {
                            if (this.requirementsService.RequirementOrderDelete((RequirementOrdersDTO)requirementOrdersBS.Current))
                            {
                                this.requirementOrdersBS.RemoveCurrent();
                                LoadRequirementMaterialsData();
                            }
                        }
                    }
                }
           
        }

        private void addOrderBtn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            addOrder_();
        }
        private void addOrder_()
        {
            //RequirementOrderEditFm ordersEditFm = new RequirementOrderEditFm(Utils.Operation.Add, new RequirementOrdersDTO(), (obj) => { requirementOrdersBS.Add(obj); });
            //MainFm mainFm = new MainFm();
            //ordersEditFm.MdiParent = this.MdiParent;
            //ordersEditFm.Show();
            //LoadOrdersData();
            //requirementOrdersGrid.Focus();
        }

        private void editOrderBtn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            editOrder_();
        }

        private void editOrder_()
        {
            RequirementOrderEditFm ordersEditFm = new RequirementOrderEditFm(Utils.Operation.Update, (RequirementOrdersDTO)requirementOrdersBS.Current, (obj) => { });
             //MainFm mainFm = new MainFm();
             //ordersEditFm.MdiParent = this.MdiParent;
             //ordersEditFm.Show();
             //LoadOrdersData();
             //requirementOrdersGrid.Focus();
         }


        private void showOrdersForDate_Click(object sender, EventArgs e)
        {
            DateTime beginDate = (DateTime)beginDateEdit.EditValue;
            DateTime endDate = (DateTime)endDateEdit.EditValue; ;
            var orders = requirementsService.GetRequirementOrders(beginDate, endDate);
            requirementOrdersBS.DataSource = orders;
            requirementOrdersGrid.DataSource = null;
            requirementOrdersGrid.DataSource = requirementOrdersBS;
            LoadRequirementMaterialsData();
        }

        private void orderGridView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && ((DevExpress.XtraGrid.Views.Grid.GridView)sender).RowCount > 0)
            {
                deleteOrder_();
            }
            if (e.KeyCode == Keys.Insert && ((DevExpress.XtraGrid.Views.Grid.GridView)sender).RowCount > 0)
            {
                addOrder_();
            }
            if (e.KeyCode == Keys.Enter && ((DevExpress.XtraGrid.Views.Grid.GridView)sender).RowCount > 0)
            {
                editOrder_();
            }
        }

    }
}
