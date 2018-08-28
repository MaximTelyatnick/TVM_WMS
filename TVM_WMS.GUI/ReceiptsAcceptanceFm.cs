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
using TVM_WMS.BLL.DTO.QueryDTO;
using System.Collections.Generic;
using System.Reflection;
using System;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraReports.UI;
using DevExpress.LookAndFeel;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.Utils;

namespace TVM_WMS.GUI
{
    public partial class ReceiptsAcceptanceFm : Form
    {
        private IReceiptsService receiptsService;
        private IOrdersService ordersService;
        private IReceiptAcceptancesService receiptAcceptancesService;

        private BindingSource receiptsBS = new BindingSource();
        private BindingSource receiptAcceptancesBS = new BindingSource();

        private List<ReceiptsForAcceptanceDTO> receiptsList;
        private List<ReceiptAcceptancesDTO> receiptAcceptancesList;
        private bool access;

        public ReceiptsAcceptanceFm()
        {
            InitializeComponent();

            splashScreenManager.ShowWaitForm();

            access = UsersService.AuthorizatedUserAccess.Any(c => c.TaskName == "receiptsAcceptanceItem" && c.AccessRightId == 1);//чтение
            if (access)
                AuthorizatedUserAccess();

            LoadReceiptsData((int)statusItem.EditValue);

            cancelAcceptanceBtn.Enabled = false;

            if (receiptsBS.Count > 0)
            {
                receiptsGridView.FocusedRowHandle = 0;
                receiptsGridView.ExpandAllGroups();
            }

            

            splashScreenManager.CloseWaitForm();
        }

        #region Event's

        private void receiptsGridView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (receiptsBS.Count > 0)
            {
                LoadDataKits(((ReceiptsForAcceptanceDTO)receiptsBS.Current).ReceiptId);

                if (!access)
                {
                    printStickersBtn.Enabled = ((ReceiptsForAcceptanceDTO)receiptsBS.Current).IsFilled;
                    deleteKitsBtn.Enabled = ((ReceiptsForAcceptanceDTO)receiptsBS.Current).IsFilled;

                    allCreateBtn.Enabled = !((ReceiptsForAcceptanceDTO)receiptsBS.Current).IsFilled;
                    createKitsBtn.Enabled = !((ReceiptsForAcceptanceDTO)receiptsBS.Current).IsFilled;
                }
            }
        }

        private void receiptsGridView_ShowingEditor(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (((GridView)sender).FocusedColumn.FieldName == "Checked" && !((ReceiptsForAcceptanceDTO)receiptsBS.Current).IsFilled)
                e.Cancel = true;
        }

        private void repositoryStatusItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = (int)statusItem.EditValue;

            if (!access)
            {
                repositoryCheckAllItem.Enabled = (index == 0 ? true : false);
                deleteKitsBtn.Enabled = (index == 0 ? true : false);
                allCreateBtn.Enabled = (index == 0 ? true : false);
                cancelAcceptanceBtn.Enabled = (index == 1 ? true : false);
                createKitsBtn.Enabled = (index == 0 ? true : false);
                receiptsGridView.Columns[1].Visible = (index == 0 ? true : false);
                saveBtn.Enabled = (index == 0 ? true : false);
            }

            receiptsGridView.BeginDataUpdate();
            LoadReceiptsData(index);
            receiptsGridView.EndDataUpdate();

            if (receiptsBS.Count > 0)
            {
                receiptsGridView.FocusedRowHandle = 0;
                receiptsGridView.ExpandAllGroups();
            }
        }

        private void repositoryCheckAllItem_CheckedChanged(object sender, EventArgs e)
        {
            DevExpress.XtraEditors.CheckEdit editor = sender as DevExpress.XtraEditors.CheckEdit;

            receiptsGridView.BeginDataUpdate();

            receiptsList.Where(r => r.IsFilled).Select(c => { c.Checked = (editor.CheckState == CheckState.Checked ? true : false); return c; }).ToList();

            receiptsGridView.EndDataUpdate();
        }

        private void receiptsGridView_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            ReceiptsForAcceptanceDTO item = (ReceiptsForAcceptanceDTO)receiptsBS[e.ListSourceRowIndex];

            if (e.Column == filledColumn && e.IsGetData)
            {
                int flag = item.IsFilled ? 1 : 0;

                e.Value = receiptImageCollection.Images[flag];
            }

            if (e.Column == materialEntryColumn && e.IsGetData)
            {
                if (item.MaterialEntryStatus)
                    e.Value = receiptImageCollection.Images[2];
            }
        }

        private void receiptsCheck_EditValueChanged(object sender, EventArgs e)
        {
            receiptsGrid.FocusedView.PostEditor();
        }

        private void toolTipController_GetActiveObjectInfo(object sender, DevExpress.Utils.ToolTipControllerGetActiveObjectInfoEventArgs e)
        {
            if (e.SelectedControl is GridControl)
            {
                GridView view = ((GridControl)e.SelectedControl).GetViewAt(e.ControlMousePosition) as GridView;

                if (view == null) return;

                GridHitInfo hi = view.CalcHitInfo(e.ControlMousePosition);

                if (hi.HitTest == GridHitTest.RowCell && hi.Column != null && hi.Column == filledColumn)
                {
                    Image relatedImage = (Image)view.GetRowCellValue(hi.RowHandle, hi.Column);
                    if (relatedImage != null)
                    {
                        if (relatedImage == receiptImageCollection.Images[0])
                            e.Info = new ToolTipControlInfo(hi.Column, "Материал не доступен для принятия, т.к. не содержит комплекты.");
                        else
                            e.Info = new ToolTipControlInfo(hi.Column, "Материал доступен к принятию.");
                    }
                }
                if (hi.HitTest == GridHitTest.RowCell && hi.Column != null && hi.Column == materialEntryColumn)
                {
                    Image relatedImage = (Image)view.GetRowCellValue(hi.RowHandle, hi.Column);
                    if (relatedImage != null)
                    {
                        if (relatedImage == receiptImageCollection.Images[2])
                            e.Info = new ToolTipControlInfo(hi.Column, "Для материала не определена зона хранения или складская группа, либо зона хранения не содержит ячеек.");
                    }
                }
            }
        }

        private void cancelAcceptanceBtn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            receiptAcceptancesService = Program.kernel.Get<IReceiptAcceptancesService>();
            receiptsService = Program.kernel.Get<IReceiptsService>();
            ordersService = Program.kernel.Get<IOrdersService>();

            if (receiptsBS.List.Count == 0) return;

            var currentReceipt = (ReceiptsForAcceptanceDTO)receiptsBS.Current;

            if ((currentReceipt.StatusId == 6) && (!receiptAcceptancesList.Any(ra => ra.StatusId > 6))) // отменить прием можно если статус Принят и нет не одной записи в receiptAcceptances со статусом Выше (хранение, частично обработан или отгружен)
            {
                if (MessageBox.Show("Отменить прием выбранной номенклатуры?", "Сохранение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (receiptsService.GetReceiptsForAcceptance().Any(m => m.OrderId == currentReceipt.OrderId && m.StatusId == 6 && m.ReceiptId != currentReceipt.ReceiptId))
                    {
                        var orderItem = ordersService.GetOrderById(currentReceipt.OrderId);
                        orderItem.StatusId = 1;
                        ordersService.OrderUpdate(orderItem);
                    }

                    var receiptItem = receiptsService.GetReceiptById(currentReceipt.ReceiptId);
                    receiptItem.StatusId = 5;
                    receiptsService.ReceiptUpdate(receiptItem);

                    receiptAcceptancesService.UpdateRange(receiptAcceptancesList.Select(ra => { ra.StatusId = 5; return ra; }).ToList());

                    receiptsGridView.BeginDataUpdate();

                    LoadReceiptsData((int)statusItem.EditValue);

                    receiptsGridView.EndDataUpdate();

                    int handle = receiptsGridView.LocateByValue("ReceiptId", currentReceipt.ReceiptId);
                    receiptsGridView.FocusedRowHandle = handle;
                }
            }
            else
            {
                MessageBox.Show("Нельзя отменить принятие, поскольку один или несколько комплектов находятся на хранении.", "Отменить принятие прихода", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void printStickersBtn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var printList = receiptAcceptancesList.Select(c => { c.BarCodeText = ("*3*" + c.AcceptanceId.ToString()); return c; }).ToList();
            BindingSource reportBS = new BindingSource();

            BarcodeLabelReport report = new BarcodeLabelReport();

            reportBS.DataSource = printList;
            report.DataSource = reportBS;

            var printableSourse = ConfigClass.Instance.GlobalSettingsList;

            report.FindControl("BarcodeText", true).DataBindings.Add("Text", reportBS, "BarCodeText");

            var stickerOrderDateCheck = printableSourse.First(s => s.KindName == "StickerOrderDate").Printable;
            report.FindControl("StickerOrderDate", true).DataBindings.Add("Text", reportBS, "OrderDate").FormatString = "{0:dd.MM.yyyy}";
            report.FindControl("StickerOrderDate", true).Visible = stickerOrderDateCheck;
            report.FindControl("StickerOrderDateLbl", true).Visible = stickerOrderDateCheck;

            var stickerOrderNumberCheck = printableSourse.First(s => s.KindName == "StickerOrderNumber").Printable;
            report.FindControl("StickerOrderNumber", true).DataBindings.Add("Text", reportBS, "OrderNumber");
            report.FindControl("StickerOrderNumber", true).Visible = stickerOrderNumberCheck;
            report.FindControl("StickerOrderNumberLbl", true).Visible = stickerOrderNumberCheck;

            var stickerPartNumberCheck = printableSourse.First(s => s.KindName == "StickerPartNumber").Printable;
            report.FindControl("StickerPartNumber", true).DataBindings.Add("Text", reportBS, "PartNumber");
            report.FindControl("StickerPartNumber", true).Visible = stickerPartNumberCheck;
            report.FindControl("StickerPartNumberLbl", true).Visible = stickerPartNumberCheck;

            var stickerQuantityCheck = printableSourse.First(s => s.KindName == "StickerQuantity").Printable;
            report.FindControl("StickerQuantity", true).DataBindings.Add("Text", reportBS, "Quantity");
            report.FindControl("StickerQuantity", true).Visible = stickerQuantityCheck;
            report.FindControl("StickerQuantityLbl", true).Visible = stickerQuantityCheck;

            var stickerUnitLocalNameCheck = printableSourse.First(s => s.KindName == "StickerUnitLocalName").Printable;
            report.FindControl("StickerUnitLocalName", true).DataBindings.Add("Text", reportBS, "UnitLocalName");
            report.FindControl("StickerUnitLocalName", true).Visible = stickerUnitLocalNameCheck;
            report.FindControl("StickerUnitLocalNameLbl", true).Visible = stickerUnitLocalNameCheck;

            var stickerArticleCheck = printableSourse.First(s => s.KindName == "StickerArticle").Printable;
            report.FindControl("StickerArticle", true).DataBindings.Add("Text", reportBS, "Article");
            report.FindControl("StickerArticle", true).Visible = stickerArticleCheck;
            report.FindControl("StickerArticleLbl", true).Visible = stickerArticleCheck;

            var stickerNameCheck = printableSourse.First(s => s.KindName == "StickerName").Printable;
            report.FindControl("StickerName", true).DataBindings.Add("Text", reportBS, "Name");
            report.FindControl("StickerName", true).Visible = stickerNameCheck;
            report.FindControl("StickerNameLbl", true).Visible = stickerNameCheck;

            var stickerContractorNameCheck = printableSourse.First(s => s.KindName == "StickerContractorName").Printable;
            report.FindControl("StickerContractorName", true).DataBindings.Add("Text", reportBS, "ContractorName");
            report.FindControl("StickerContractorName", true).Visible = stickerContractorNameCheck;
            report.FindControl("StickerContractorNameLbl", true).Visible = stickerContractorNameCheck;

            var stickerDateProductionCheck = printableSourse.First(s => s.KindName == "StickerDateProduction").Printable;
            report.FindControl("StickerDateProduction", true).DataBindings.Add("Text", reportBS, "DateProduction").FormatString = "{0:dd.MM.yyyy}";
            report.FindControl("StickerDateProduction", true).Visible = stickerDateProductionCheck;
            report.FindControl("StickerDateProductionLbl", true).Visible = stickerDateProductionCheck;

            var stickerDateExpirationCheck = printableSourse.First(s => s.KindName == "StickerDateExpiration").Printable;
            report.FindControl("StickerDateExpiration", true).DataBindings.Add("Text", reportBS, "DateExpiration").FormatString = "{0:dd.MM.yyyy}";
            report.FindControl("StickerDateExpiration", true).Visible = stickerDateExpirationCheck;
            report.FindControl("StickerDateExpirationLbl", true).Visible = stickerDateExpirationCheck;

            ReportPrintTool pt = new ReportPrintTool(report);

            using (ReportPrintTool printTool = new ReportPrintTool(report))
            {
                printTool.ShowPreviewDialog(UserLookAndFeel.Default);
            }
        }

        private void allCreateBtn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int currReceiptId = ((ReceiptsForAcceptanceDTO)receiptsBS.Current).ReceiptId;

            List<ReceiptAcceptancesDTO> receiptAcceptances = receiptsList
                .Where(r => r.ReceiptId == currReceiptId)
                .Select(s => new ReceiptAcceptancesDTO { OrderId = s.OrderId, ReceiptId = s.ReceiptId, Quantity = s.Quantity, StatusId = 5 })
                .ToList();

            receiptAcceptancesService.CreateRange(receiptAcceptances);

            receiptsGridView.BeginDataUpdate();

            LoadReceiptsData((int)statusItem.EditValue);

            receiptsGridView.EndDataUpdate();

            int handle = receiptsGridView.LocateByValue("ReceiptId", currReceiptId);
            receiptsGridView.FocusedRowHandle = handle;


        }

        private void deleteKitsBtn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int currReceiptId = ((ReceiptsForAcceptanceDTO)receiptsBS.Current).ReceiptId;

            if (MessageBox.Show("Удалить комплектацию?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Error.ErrorCRUD result = receiptAcceptancesService.DeleteAll(currReceiptId);
                if (result == Error.ErrorCRUD.NoError)
                {
                    receiptsGridView.BeginDataUpdate();

                    LoadReceiptsData((int)statusItem.EditValue);

                    receiptsGridView.EndDataUpdate();

                    int handle = receiptsGridView.LocateByValue("ReceiptId", currReceiptId);
                    receiptsGridView.FocusedRowHandle = handle;
                }
                else
                {
                    switch (result)
                    {
                        case Error.ErrorCRUD.RelationError:
                            MessageBox.Show("Комплекты нельзя удалить. Есть связанные данные!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                        case Error.ErrorCRUD.DatabaseError:
                            MessageBox.Show("Ошибка Базы данных!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                        default:
                            break;
                    }

                }
            }
        }

        private void createKitsBtn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (receiptAcceptancesBS.List.Count == 0)
            {
                int currReceiptId = ((ReceiptsForAcceptanceDTO)receiptsBS.Current).ReceiptId;

                ReceiptsDTO model = new ReceiptsDTO()
                {
                    ReceiptId = ((ReceiptsForAcceptanceDTO)receiptsBS.Current).ReceiptId,
                    OrderId = ((ReceiptsForAcceptanceDTO)receiptsBS.Current).OrderId,
                    Article = ((ReceiptsForAcceptanceDTO)receiptsBS.Current).Article,
                    Name = ((ReceiptsForAcceptanceDTO)receiptsBS.Current).Name,
                    OrderNumber = ((ReceiptsForAcceptanceDTO)receiptsBS.Current).OrderNumber,
                    OrderDate = ((ReceiptsForAcceptanceDTO)receiptsBS.Current).OrderDate,
                    Quantity = ((ReceiptsForAcceptanceDTO)receiptsBS.Current).Quantity
                };

                using (KitsFm kitsFm = new KitsFm(model))
                {
                    if (kitsFm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        receiptsGridView.BeginDataUpdate();

                        LoadReceiptsData((int)statusItem.EditValue);

                        receiptsGridView.EndDataUpdate();

                        int handle = receiptsGridView.LocateByValue("ReceiptId", currReceiptId);
                        receiptsGridView.FocusedRowHandle = handle;
                    }
                }
            }
            else
            {
                MessageBox.Show("Комплектация уже существует! Для создания новой комплектации удалите текущую!", "Создание комплектов", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void saveBtn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {            
            if (receiptsList.Any(r => r.Checked))
            {
                if (MessageBox.Show("Сохранить изменения?", "Сохранение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int curOrderId = 0;

                    ordersService = Program.kernel.Get<IOrdersService>();
                    receiptsService = Program.kernel.Get<IReceiptsService>();
                    receiptAcceptancesService = Program.kernel.Get<IReceiptAcceptancesService>();

                    foreach (var checkReceipt in receiptsList.Where(r => r.Checked))
                    {
                        if (curOrderId != checkReceipt.OrderId)
                        {
                            curOrderId = checkReceipt.OrderId;
                            var orderItem = ordersService.GetOrderById(curOrderId);
                            orderItem.StatusId = 2;
                            ordersService.OrderUpdate(orderItem);
                        }

                        var receiptItem = receiptsService.GetReceiptById(checkReceipt.ReceiptId);
                        receiptItem.StatusId = 6;
                        receiptsService.ReceiptUpdate(receiptItem);

                        var curReceiptAcceptancesList = receiptAcceptancesService.GetReceiptAcceptanceByReceiptId(checkReceipt.ReceiptId).Select(ra => { ra.StatusId = 6; return ra; }).ToList();
                        receiptAcceptancesService.UpdateRange(curReceiptAcceptancesList);
                    }

                    receiptsGridView.BeginDataUpdate();
                    LoadReceiptsData((int)statusItem.EditValue);
                    receiptsGridView.EndDataUpdate();

                    if (receiptsBS.Count > 0)
                    {
                        receiptsGridView.FocusedRowHandle = 0;
                        receiptsGridView.ExpandAllGroups();
                    }
                }
            }
            else
            {
                MessageBox.Show("Не выбраны данные для принятия!", "Принятие прихода", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void closeBtn_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void refreshBtn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            splashScreenManager.ShowWaitForm();

            LoadReceiptsData((int)statusItem.EditValue);
            cancelAcceptanceBtn.Enabled = false;
            receiptsGridView.ExpandAllGroups();

            splashScreenManager.CloseWaitForm();
        }

        #endregion

        #region Metod's

        private void LoadReceiptsData(int statusValue)
        {
            receiptsService = Program.kernel.Get<IReceiptsService>();

            switch (statusValue)
            {
                case 0:
                    receiptsList = receiptsService.GetReceiptsForAcceptance().Where(r => r.StatusId == 5).ToList();
                    break;
                case 1:
                    receiptsList = receiptsService.GetReceiptsForAcceptance().Where(r => r.StatusId == 6).ToList();
                    break;
                case 2:
                    receiptsList = receiptsService.GetReceiptsForAcceptance().ToList();
                    break;
                default:
                    break;
            }

            receiptsBS.DataSource = receiptsList;
            receiptsGrid.DataSource = receiptsBS;
        }

        private void LoadDataKits(int receiptId)
        {
            receiptAcceptancesService = Program.kernel.Get<IReceiptAcceptancesService>();
            receiptAcceptancesList = receiptAcceptancesService.GetReceiptAcceptanceByReceiptId(receiptId).ToList();
            receiptAcceptancesBS.DataSource = receiptAcceptancesList;
            receiptAcceptancesGrid.DataSource = receiptAcceptancesBS;
        }

        private void AuthorizatedUserAccess()
        {
                allCreateBtn.Enabled = false;
                createKitsBtn.Enabled = false;
                deleteKitsBtn.Enabled = false;
                cancelAcceptanceBtn.Enabled = false;
                saveBtn.Enabled = false;
                checkGroupItem.Enabled = false;
                receiptsGridView.Columns[1].Visible = false;
        }

        #endregion

    }
}
