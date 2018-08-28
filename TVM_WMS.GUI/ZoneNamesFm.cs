using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ninject;
using System.Collections;
using DevExpress.XtraTreeList;
using System.Collections.Generic;
using System.ComponentModel;

using DevExpress.XtraEditors;
using DevExpress.Utils;
using DevExpress.XtraEditors.Controls;

using TVM_WMS.BLL.BusinessLogicModule;
using TVM_WMS.BLL.Interfaces;
using TVM_WMS.BLL.Services;
using TVM_WMS.BLL.DTO;

using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;
using DevExpress.XtraPrinting.Preview;
using DevExpress.XtraTreeList.Nodes;
using TVM_WMS.BLL.DTO.QueryDTO;

namespace TVM_WMS.GUI
{
    public partial class ZoneNamesFm : DevExpress.XtraEditors.XtraForm
    {
        private IStoreNamesService storeNamesService;
        private IWareHousesService wareHousesService;
        private IReportsService reportsService;
        private IZoneNamesService zoneNamesService;

        private BindingSource storeNamesBS = new BindingSource();
        private BindingSource zoneNamesBS = new BindingSource();
        private BindingSource zoneUnspecifiedBS = new BindingSource();
        private BindingSource zoneInfoBS = new BindingSource();

        List<WareHousesDTO> cellList = new List<WareHousesDTO>();
        private IEnumerable<ZoneNamesByStoreDTO> zoneNamesList;
        private IEnumerable<CellQuantityByZonesDTO> zoneInfoList;
        private int cellNo;
        private bool access;

        public ZoneNamesFm()
        {
            cellNo = 0;
            InitializeComponent();
            splashScreenManager.ShowWaitForm();
            LoadData();
            storeNamesGrid.DataSource = storeNamesBS;
            zoneUnspecifiedGrid.DataSource = zoneUnspecifiedBS;
            if (storeNamesBS.Count == 0)
            {
                showWareHouseBtn.Enabled = false;
                addStorageGroupByZoneBtn.Enabled = false;
                printBtn.Enabled = false;
            }
            access = UsersService.AuthorizatedUserAccess.Any(c => c.TaskName == "zoneNamesItem" && c.AccessRightId == 1);//чтение
            if (access)
                AuthorizatedUserAccess();

            splashScreenManager.CloseWaitForm();
        }

        #region Metods's

        private void LoadData()
        {
            storeNamesService = Program.kernel.Get<IStoreNamesService>();

            wareHousesService = Program.kernel.Get<IWareHousesService>();
            reportsService = Program.kernel.Get<IReportsService>();
            zoneNamesService = Program.kernel.Get<IZoneNamesService>();
            storeNamesBS.Clear();
            storeNamesBS.DataSource = storeNamesService.GetStoreNames().Where(sn => sn.ParentId != null).OrderBy(o => o.ParentName);
            zoneNamesList = zoneNamesService.GetZoneNameByStore();
            zoneUnspecifiedBS.DataSource = zoneNamesService.GetZonesUnspecified();
            zoneInfoList = zoneNamesService.GetCellQuantityByZones();
        }

        public void AuthorizatedUserAccess()
        {
            addZoneBtn.Enabled = false;
            showStorageGroupByZoneBtn.Enabled = false;
            addStorageGroupByZoneBtn.Enabled = false;
        }

        private void RunToControlVisual()
        {
            wareHousesService = Program.kernel.Get<IWareHousesService>();

            if (storeNamesBS.Count != 0)
            {
                showWareHouseBtn.Enabled = true;

                int line = (int)((StoreNamesDTO)storeNamesBS.Current).LineCount;

                int column = (int)((StoreNamesDTO)storeNamesBS.Current).ColumnCount;
                int cell = (int)((StoreNamesDTO)storeNamesBS.Current).CellCount;
                cellNo = line * column - cell;

                GetCellList();

                if (cellList.Count != 0)
                {

                    ControlVisual(line, column, cellList);

                    if ((cellList[1].NumberCell == null))
                    {
                        if ((line * column - cell) > 0)
                            MessageBox.Show("Необходимо указать " + (line * column - cell).ToString() + " отсутствующие ячейки!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
                else
                    panel.Controls.Clear();
            }
            else
                panel.Controls.Clear();
        }

        private void ControlVisual(int line, int column, List<WareHousesDTO> cellList)
        {
            panel.Controls.Clear();

            DevExpress.XtraEditors.LabelControl grCont = new DevExpress.XtraEditors.LabelControl();
            panel.Controls.Add(grCont);
            grCont.MaximumSize = new Size { Width = 30, Height = 20 };
            grCont.MinimumSize = new Size { Width = 30, Height = 20 };
            grCont.Left = 2;
            grCont.Top = 18;// 18 - вЫсота заголовка в панели
            grCont.Text = "С/Э";
            grCont.BackColor = Color.SkyBlue;
            grCont.Anchor = ((AnchorStyles)((AnchorStyles.Left)));
            grCont.Appearance.Font = new Font("Tahoma", 9, FontStyle.Bold);
            grCont.Appearance.ForeColor = Color.Indigo;
            grCont.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            grCont.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            grCont.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            //
            int interval = 2;
            int grHeight = (((panel.Height - 18) - grCont.Height) / line) - interval; // 18 - вЫсота заголовка в панели
            int grWidth = ((panel.Width - grCont.Width) / column) - interval;
            int dinamicTop = grCont.Height + 18;// 18 - вЫсота заголовка в панели
            int dinamicLeft = grCont.Width;
            int grLeft;
            int grTop;
            int k = 0;

            for (int j = 0; j < line; j++)
            {
                grLeft = interval + dinamicLeft;
                grTop = interval + dinamicTop;

                for (int i = 0; i < column; i++)
                {
                    grLeft = interval + dinamicLeft;

                    DevExpress.XtraEditors.LabelControl grControl = new DevExpress.XtraEditors.LabelControl();
                    grControl.Name = "grControl" + k;
                    panel.Controls.Add(grControl);

                    grControl.MaximumSize = new Size { Width = grWidth, Height = grHeight };
                    grControl.MinimumSize = new Size { Width = grWidth, Height = grHeight };
                    grControl.Left = grLeft;
                    grControl.Top = grTop;
                    grControl.Anchor = ((AnchorStyles)((AnchorStyles.Left)));
                    grControl.Appearance.Font = new Font("Tahoma", 8, FontStyle.Bold);
                    grControl.Appearance.ForeColor = Color.Firebrick;
                    grControl.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    grControl.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                    grControl.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.BottomCenter;
                    grControl.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;

                    if (cellList[k].NumberCell > 0)
                    {
                       if (cellList[k].LoadingStatusId > 1)
                          grControl.Appearance.Image = (cellList[k].LoadingStatusId == 2 ? cellImageCollection.Images[1] : cellImageCollection.Images[2]);

                        grControl.Text = cellList[k].NumberCell.ToString();
                        if (cellList[k].ZoneColor != null)
                           grControl.BackColor = ColorTranslator.FromHtml(cellList[k].ZoneColor.ToString());
                    }
                    else
                    {
                        grControl.Text = "";
                        grControl.BackColor = Color.GhostWhite;
                    }

                    grControl.Tag = k;

                    dinamicLeft = dinamicLeft + (grWidth + interval);

                    if (j == 0) // только на первом ряду названия стелажей
                    {
                        //контейнер название стелажей
                        DevExpress.XtraEditors.LabelControl grContSt = new DevExpress.XtraEditors.LabelControl();
                        panel.Controls.Add(grContSt);
                        grContSt.MaximumSize = new Size { Width = grWidth, Height = 20 };
                        grContSt.MinimumSize = new Size { Width = grWidth, Height = 20 };
                        grContSt.Left = grLeft;
                        grContSt.Top = 18;
                        grContSt.BackColor = Color.SkyBlue;
                        grContSt.Anchor = ((AnchorStyles)((AnchorStyles.Left)));
                        grContSt.Text = (i + 1).ToString();
                        grContSt.Appearance.Font = new Font("Tahoma", 9, FontStyle.Bold);
                        grContSt.Appearance.ForeColor = Color.Indigo;
                        grContSt.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        grContSt.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                        grContSt.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
                        //
                    }

                    k = k + 1;
                }

                //контейнер название этажей
                DevExpress.XtraEditors.LabelControl grContEt = new DevExpress.XtraEditors.LabelControl();
                panel.Controls.Add(grContEt);
                grContEt.MaximumSize = new Size { Width = 30, Height = grHeight };
                grContEt.MinimumSize = new Size { Width = 30, Height = grHeight };
                grContEt.Left = 2;
                grContEt.BackColor = Color.SkyBlue;
                grContEt.Top = grTop;
                grContEt.Anchor = ((AnchorStyles)((AnchorStyles.Left)));
                grContEt.Text = (line - j).ToString();
                grContEt.Appearance.Font = new Font("Tahoma", 9, FontStyle.Bold);
                grContEt.Appearance.ForeColor = Color.Indigo;
                grContEt.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                grContEt.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                grContEt.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
                //
                dinamicLeft = grCont.Width;
                dinamicTop = dinamicTop + grHeight + interval;
            }
     

        }

        private void GetCellList()
        {
            int curStoreId = ((StoreNamesDTO)storeNamesBS.Current).StoreNameId;

            cellList = wareHousesService.GetWareHouses().Where(s => s.StoreNameId == curStoreId).ToList();
        }

        private void LoadZoneInfo()
        {
            if (zoneNamesBS.Count > 0)
            {
                int curZoneId = ((ZoneNamesByStoreDTO)zoneNamesBS.Current).ZoneNameId;
                zoneInfoBS.DataSource = zoneInfoList.Where(c => c.ZoneNameId == curZoneId).ToList();
                zoneInfoGrid.DataSource = zoneInfoBS;
            }
        }

        private void LoadZoneNames()
        {
            if (storeNamesBS.Count > 0)
            {
                int? curStoreId = ((StoreNamesDTO)storeNamesBS.Current).StoreNameId;
                zoneNamesBS.DataSource = zoneNamesList.Where(c => c.StoreNameId == curStoreId).ToList();
                zoneNamesGrid.DataSource = zoneNamesBS;
            }
        }

        #endregion

        #region Event's

     
        private void showBtn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            RunToControlVisual();
        }


        private void printBtn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (cellList.Count == 0)
                GetCellList();

            reportsService.PrintWareHouses(cellList, (StoreNamesDTO)storeNamesBS.Current);
        }

        private void addStorageGroupByZoneBtn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            new CellZonesFm(((StoreNamesDTO)storeNamesBS.Current)).ShowDialog();
        }

        private void addZoneBtn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            new SpravochFm(Utils.GridName.ZoneNames).ShowDialog();
        }

        private void showStorageGroupByZoneBtn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            new StorageGroupsByZonesFm().ShowDialog();
        }

        private void storeNamesGridView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
                LoadZoneNames();
                LoadZoneInfo();

                cellList.Clear();
        }

        private void zoneNamesGridView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
               LoadZoneInfo();
        }

        private void refreshDataBtn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
            splashScreenManager.ShowWaitForm();

            LoadData();

            splashScreenManager.CloseWaitForm();
        }

        #endregion
   
    }
}