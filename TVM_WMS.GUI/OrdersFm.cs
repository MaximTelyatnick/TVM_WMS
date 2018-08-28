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
    public partial class OrdersFm : Form
    {
        private IOrdersService ordersService;
        private BindingSource ordersBS = new BindingSource();
        private IReceiptsService receiptsService;
        private BindingSource receiptsBS = new BindingSource();
        private bool access;
 
        public OrdersFm()
        {
          InitializeComponent();
          splashScreenManager.ShowWaitForm();
          access = UsersService.AuthorizatedUserAccess.Any(c => c.TaskName == "receiptNewItem" && c.AccessRightId == 1);//чтение
          if (access)
              AuthorizatedUserAccess();

          LoadOrdersData();
          DateTime beginDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1); // год - месяц - день
          DateTime endDate = DateTime.Today;
          beginDateEditItem.EditValue = beginDate;
          endDateEditItem.EditValue = endDate;
          var orders = ordersService.GetOrders(beginDate, endDate);
          ordersBS.DataSource = orders;
          orderGrid.DataSource = ordersBS;
          LoadReceiptsData();
          
          splashScreenManager.CloseWaitForm();
        }
        #region Event's
         

        private void ordersGridView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
          LoadReceiptsData();
        }

        private void orderGrid_DoubleClick(object sender, EventArgs e)
        {
            editOrder_();
        }

        private void receiptsAcceptance_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            new ReceiptsAcceptanceFm().Show();
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
        }

        private void showItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DateTime beginDate = (DateTime)beginDateEditItem.EditValue;
            DateTime endDate = (DateTime)endDateEditItem.EditValue; ;
            var orders = ordersService.GetOrders(beginDate, endDate);
            ordersBS.DataSource = orders;
            orderGrid.DataSource = ordersBS;
            LoadReceiptsData();
        }

        private void addOrderBtn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            addOrder_();
        }

        private void editOrderBtn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            editOrder_();
        }

        private void deleteOrderBtn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            deleteOrder_();
        }

        #endregion

        #region Metod's

        public void LoadOrdersData()
        {
            receiptsService = Program.kernel.Get<IReceiptsService>();
            ordersService = Program.kernel.Get<IOrdersService>();
        }

        public void LoadReceiptsData()
        {
            var receiptsByOrder = (ordersBS.Count == 0 ? null : receiptsService.GetReceipts().Where(m => m.OrderId == ((OrdersDTO)ordersBS.Current).OrderId));
            receiptsBS.DataSource = receiptsByOrder;
            this.receiptsGrid.DataSource = receiptsBS;
        }

        public void AuthorizatedUserAccess()
        {
                addOrderBtn.Enabled = false;
                editOrderBtn.Enabled = false;
                deleteOrderBtn.Enabled = false;
        }

        private void deleteOrder_()
        {
            if ((OrdersDTO)ordersBS.Current != null)
            {
            if (((OrdersDTO)ordersBS.Current).StatusId == 1) //К поступлению
            {
                    if (MessageBox.Show("Удалить документ?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                            Error.ErrorCRUD result = this.ordersService.OrderDelete((OrdersDTO)ordersBS.Current);
                            if (result == Error.ErrorCRUD.NoError)
                        {
                                    this.ordersBS.RemoveCurrent();
                                LoadReceiptsData();
                            }
                        else
                        {
                                switch (result)
                            {
                                    case Error.ErrorCRUD.RelationError:
                                        MessageBox.Show("Документ нельзя удалить. Есть связанные данные!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        break;
                                    case Error.ErrorCRUD.DatabaseError:
                                        MessageBox.Show("Ошибка Базы данных!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        break;
                                    default :
                                        break;
                            }

                        }
                    }
                }
            else
            {
                MessageBox.Show("Документ нельзя удалить. Статус документа " + ((OrdersDTO)ordersBS.Current).StatusName, "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        }


        private void addOrder_()
        {
            using (OrderEditFm orderEditFm = new OrderEditFm(Utils.Operation.Add, new OrdersDTO()))
            {
                if (orderEditFm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    int return_OrderId = orderEditFm.Return();
                    orderGridView.BeginUpdate();
                    LoadOrdersData();
                    DateTime beginDate = (DateTime)beginDateEditItem.EditValue;
                    DateTime endDate = (DateTime)endDateEditItem.EditValue;
                    ordersBS.DataSource = ordersService.GetOrders(beginDate, endDate);
                    orderGrid.DataSource = ordersBS;
                    orderGridView.EndUpdate();
                    int rowHandle = orderGridView.LocateByValue("OrderId", return_OrderId);
                    orderGridView.FocusedRowHandle = rowHandle;
                    LoadReceiptsData();
                 }
            }
        }

        private void editOrder_()
        {
            if ((OrdersDTO)ordersBS.Current != null)
            {
            if (((OrdersDTO)ordersBS.Current).StatusId == 1) //К поступлению
            {
                        using (OrderEditFm orderEditFm = new OrderEditFm(Utils.Operation.Update, (OrdersDTO)ordersBS.Current))
        {
                            if (orderEditFm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
        {
                                int return_OrderId = orderEditFm.Return();
                                orderGridView.BeginUpdate();
            LoadOrdersData();
            DateTime beginDate = (DateTime)beginDateEditItem.EditValue;
            DateTime endDate = (DateTime)endDateEditItem.EditValue; ;
                                ordersBS.DataSource = ordersService.GetOrders(beginDate, endDate);
            orderGrid.DataSource = ordersBS;
                                orderGridView.EndUpdate();
                                int rowHandle = orderGridView.LocateByValue("OrderId", return_OrderId);
                                orderGridView.FocusedRowHandle = rowHandle;
            LoadReceiptsData();
        }
                        }
            }
                    else
            {
                        MessageBox.Show("Документ нельзя редактировать. Статус документа " + ((OrdersDTO)ordersBS.Current).StatusName, "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            }
        }

        #endregion

    }
}
