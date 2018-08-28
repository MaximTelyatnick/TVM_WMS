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

using TVM_WMS.BLL.BusinessLogicModule;
using TVM_WMS.BLL.Interfaces;
using TVM_WMS.BLL.Services;
using TVM_WMS.BLL.DTO;
using TVM_WMS.BLL.DTO.QueryDTO;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.Utils;

namespace TVM_WMS.GUI
{
    public partial class StoreLoadFm : DevExpress.XtraEditors.XtraForm
    {
        private IStoreNamesService storeNamesService;
        private IWareHousesService wareHousesService;
        private IKeepingsService keepingsService;
        private IExpendituresService expendituresService;

        private List<StoreLoadDTO> storeLoadList;
        private List<WareHousesDTO> cellLoadList;
        private List<WareHousePresencesDTO> cellPresenceList;
        private List<HistoryKeepingsDTO> journalKeepList;
        private List<ExpendituresDTO> journalExpList;
        
        private BindingSource presenceBS = new BindingSource();
        private BindingSource journalKeepBS = new BindingSource();
        private BindingSource journalExpBS = new BindingSource();

        public StoreLoadFm()
        {
            InitializeComponent();

            splashScreenManager.ShowWaitForm();

            LoadData();
            CreateStoreTreeList();

            if (storeLoadTree.FocusedNode != null)
            {
                RefreshStoreGridData(storeLoadTree.FocusedNode.Level, (int)storeLoadTree.FocusedNode.Tag);
            }

            expBeginDateEditItem.EditValue = DateTime.Now;
            expEndDateEditItem.EditValue = DateTime.Now;
            keepBeginDateEditItem.EditValue = DateTime.Now;
            keepEndDateEditItem.EditValue = DateTime.Now;

            splashScreenManager.CloseWaitForm();
        }

        #region Method's

        private void LoadData()
        {
            storeNamesService = Program.kernel.Get<IStoreNamesService>();
            wareHousesService = Program.kernel.Get<IWareHousesService>();

            storeLoadList = storeNamesService.GetStoreLoad().ToList();
            cellLoadList = wareHousesService.GetWareHouses().ToList();
            cellPresenceList = wareHousesService.GetWareHousePresences().ToList();
        }

        private void CreateStoreTreeList()
        {
            storeLoadTree.Nodes.Clear();
                        
            LoadStoreNodes(storeLoadTree);
            
        }
        
        private void LoadStoreNodes(TreeList tl)
        {
                       
            tl.BeginUnboundLoad();

            var parentNodes = storeLoadList.Where(s => s.ParentId == null).OrderBy(o => o.StoreName);
            
            foreach (var parentItem in parentNodes)
            {
                TreeListNode parentForRootNodes = null;
                TreeListNode rootNode = tl.AppendNode(new object[] { 
                                                                     parentItem.StoreName, 
                                                                     parentItem.StoreFullWeight, 
                                                                     parentItem.StoreCurrentWeight,
                                                                     parentItem.StoreRemainsWeight,
                                                                     parentItem.StoreFullLoad
                                                                   }, parentForRootNodes);

                rootNode.StateImageIndex = 0;
                rootNode.Tag = parentItem.StoreNameId;
                
                var childStoreNodes = storeLoadList.Where(s => s.ParentId == parentItem.StoreNameId).OrderBy(o => o.StoreName);

                foreach (var childItem in childStoreNodes)
                {
                    TreeListNode childNode = tl.AppendNode(new object[] { 
                                                                     childItem.StoreName, 
                                                                     childItem.RowFullWeight, 
                                                                     childItem.RowCurrentWeight,
                                                                     childItem.RowRemainsWeight,
                                                                     childItem.RowLoad
                                                                   }, rootNode);
                    childNode.StateImageIndex = 1;
                    childNode.Tag = childItem.StoreNameId;
                    
                    var childCellNodes = cellLoadList.Where(c => c.StoreNameId == childItem.StoreNameId && c.NumberCell > 0).OrderBy(o => o.NumberCell);

                    foreach (var cellItem in childCellNodes)
                    {
                        TreeListNode childCellNode = tl.AppendNode(new object[] { 
                                                                     cellItem.NumberCellString, 
                                                                     cellItem.MaxWeight, 
                                                                     cellItem.CurrentWeight,
                                                                     cellItem.RemainsWeight,
                                                                     cellItem.CellLoad
                                                                   }, childNode);
                        childCellNode.StateImageIndex = (cellItem.LoadingStatusId == 1) ? 2 : ((cellItem.LoadingStatusId == 2) ? 3 : 4);
                        childCellNode.Tag = cellItem.WareHouseId;
                        
                    }
                }
            }

            tl.EndUnboundLoad();
        }

        private void RefreshStoreGridData(int level, int tagId)
        {
            presenceGridView.BeginDataUpdate();

            if (level == 0)
                presenceBS.DataSource = cellPresenceList.Where(c => c.StoreNameParentId == tagId).OrderBy(o => o.NumberCell).ToList();
            else if (level == 1)
                presenceBS.DataSource = cellPresenceList.Where(c => c.StoreNameId == tagId).OrderBy(o => o.NumberCell).ToList();
            else if (level == 2)
                presenceBS.DataSource = cellPresenceList.Where(c => c.WareHouseId == tagId).OrderBy(o => o.NumberCell).ToList();

            presenceGrid.DataSource = presenceBS;

            presenceGridView.EndDataUpdate();
        }

        #endregion

        #region Event's

        private void storeLoadTree_CustomNodeCellEdit(object sender, GetCustomNodeCellEditEventArgs e)
        {
            if (e.Column == loadCol)
            {
                decimal percent = Convert.ToDecimal(e.Node[4]);
                if (percent <= 30)
                {
                    e.RepositoryItem = storeLoadRepositoryGreen;
                }
                if (percent > 30 && percent < 70)
                {
                    e.RepositoryItem = storeLoadRepositoryYellow;
                }
                if (percent >= 70)
                {
                    e.RepositoryItem = storeLoadRepositoryRed;
                }
            }
        }

        private void storeLoadTree_NodeCellStyle(object sender, GetCustomNodeCellStyleEventArgs e)
        {
            if (e.Node.Level < 2)
            {
                if (e.Column == fullWeightCol || e.Column == currentWeightCol || e.Column == remainsWeightCol)
                {
                    e.Appearance.ForeColor = Color.Navy;
                    e.Appearance.Font = new Font("Tahoma", 9, FontStyle.Bold);
                }
            }
            
        }
        
        private void refreshBtn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            splashScreenManager.ShowWaitForm();
            
            LoadData();
            CreateStoreTreeList();

            journalTab.SelectedTabPage = presencePage;

            splashScreenManager.CloseWaitForm();
        }

        private void storeLoadTree_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
        {
            if (storeLoadTree.Nodes.Count > 0 && storeLoadTree.FocusedNode.Tag != null)
            {
                RefreshStoreGridData(storeLoadTree.FocusedNode.Level, (int)storeLoadTree.FocusedNode.Tag);
            }
        }
        
        private void toolTipController_GetActiveObjectInfo(object sender, DevExpress.Utils.ToolTipControllerGetActiveObjectInfoEventArgs e)
        {
            if (e.SelectedControl == storeLoadTree)
            {
                
                DevExpress.XtraTreeList.TreeListHitInfo hit = storeLoadTree.CalcHitInfo(e.ControlMousePosition);
                
                if (hit.HitInfoType == HitInfoType.StateImage)
                {
                    object o = (object)hit.Node;
                    int imageIndex = hit.Node.StateImageIndex;
                    string toolText = String.Empty;

                    switch (imageIndex)
                    {
                        case 2:
                            toolText = "Кассета не загружена";
                            break;
                        case 3:
                            toolText = "Кассета частично загружена";
                            break;
                        case 4:
                            toolText = "Кассета загружена полностью";
                            break;
                    }

                    e.Info = new ToolTipControlInfo(o, toolText);
                }
            }
        }

        private void showKeepingForPeriodBtn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (storeLoadTree.Nodes.Count > 0 && storeLoadTree.FocusedNode.Tag != null)
            {
                keepingsService = Program.kernel.Get<IKeepingsService>();

                int tagId = (int)storeLoadTree.FocusedNode.Tag;
                int level = storeLoadTree.FocusedNode.Level;

                if(level == 0)
                    journalKeepList = keepingsService.GetHistoryKeepings((DateTime)keepBeginDateEditItem.EditValue, (DateTime)keepEndDateEditItem.EditValue).Where(k => k.StoreNameParentId == tagId)
                        .OrderBy(o => o.NumberCell)
                        .ThenBy(o => o.DateAdded)
                        .ToList();
                else if(level == 1)
                    journalKeepList = keepingsService.GetHistoryKeepings((DateTime)keepBeginDateEditItem.EditValue, (DateTime)keepEndDateEditItem.EditValue).Where(k => k.StoreNameId == tagId)
                        .OrderBy(o => o.NumberCell)
                        .ThenBy(t => t.DateAdded)
                        .ToList();
                else if(level == 2)
                    journalKeepList = keepingsService.GetHistoryKeepings((DateTime)keepBeginDateEditItem.EditValue, (DateTime)keepEndDateEditItem.EditValue).Where(k => k.WareHouseId == tagId)
                        .OrderBy(o => o.NumberCell)
                        .ThenBy(t => t.DateAdded)
                        .ToList();
                
                journalTab.SelectedTabPage = keepPage;

                journalKeepGridView.BeginDataUpdate();

                keepingsService = Program.kernel.Get<IKeepingsService>();
                journalKeepBS.DataSource = journalKeepList;
                journalKeepGrid.DataSource = journalKeepBS;

                journalKeepGridView.EndDataUpdate();
            }
        }

        private void showExpForPeriodBtn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (storeLoadTree.Nodes.Count > 0 && storeLoadTree.FocusedNode.Tag != null)
            {
                expendituresService = Program.kernel.Get<IExpendituresService>();
                
                int tagId = (int)storeLoadTree.FocusedNode.Tag;
                int level = storeLoadTree.FocusedNode.Level;

                if (level == 0)
                    journalExpList = expendituresService.GetExpendituresForJournal((DateTime)expBeginDateEditItem.EditValue, (DateTime)expEndDateEditItem.EditValue).Where(k => k.StoreNameParentId == tagId)
                        .OrderBy(o => o.NumberCell)
                        .ThenBy(t => t.ExpDate)
                        .ToList();
                else if (level == 1)
                    journalExpList = expendituresService.GetExpendituresForJournal((DateTime)expBeginDateEditItem.EditValue, (DateTime)expEndDateEditItem.EditValue).Where(k => k.StoreNameId == tagId)
                        .OrderBy(o => o.NumberCell)
                        .ThenBy(t => t.ExpDate)
                        .ToList();
                else if (level == 2)
                    journalExpList = expendituresService.GetExpendituresForJournal((DateTime)expBeginDateEditItem.EditValue, (DateTime)expEndDateEditItem.EditValue).Where(k => k.WareHouseId == tagId)
                        .OrderBy(o => o.NumberCell)
                        .ThenBy(t => t.ExpDate)
                        .ToList();
                
                journalTab.SelectedTabPage = expPage;

                journalExpGridView.BeginDataUpdate();

                expendituresService = Program.kernel.Get<IExpendituresService>();
                journalExpBS.DataSource = journalExpList;
                journalExpGrid.DataSource = journalExpBS;

                journalExpGridView.EndDataUpdate();
            }
        }

        #endregion
    }
}