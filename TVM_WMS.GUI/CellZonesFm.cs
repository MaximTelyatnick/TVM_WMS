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
using DevExpress.XtraEditors.Repository;

using TVM_WMS.BLL.BusinessLogicModule;
using TVM_WMS.BLL.Interfaces;
using TVM_WMS.BLL.Services;
using TVM_WMS.BLL.DTO;
using TVM_WMS.BLL.DTO.QueryDTO;

using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;
using DevExpress.XtraPrinting.Preview;
using DevExpress.XtraTreeList.Nodes;

namespace TVM_WMS.GUI
{
    public partial class CellZonesFm : Form
   {
         private IZoneNamesService zoneNamesService;
         private IStoreNamesService storeNamesService;
         private IWareHousesService wareHousesService;
         private IStorageGroupsService storageGroupsService;
         private IStorageGroupZonesService storageGroupZonesService;
         private ICellZonesService cellZonesService;

         private BindingSource zoneNamesBS = new BindingSource();

         private StoreNamesDTO storeNames;
         private Color defColor = Color.Black;

        List<WareHousesDTO> cellList = new List<WareHousesDTO>();

        public CellZonesFm(StoreNamesDTO storeNames)
        {
            InitializeComponent();
            splashScreenManager.ShowWaitForm();
            this.storeNames = storeNames;
            LoadCellZonesData();
           // var parentName = storeNamesService.GetStoreNames().Where(m => m.StoreNameId == storeNames.ParentId).ToList();

            zoneNamesBS.DataSource = zoneNamesService.GetZoneNames((int)storeNames.ParentId);
            zoneNameGridLookUpEdit.Properties.DataSource = zoneNamesBS;
            zoneNameGridLookUpEdit.Properties.ValueMember = "ZoneNameId";
            zoneNameGridLookUpEdit.Properties.DisplayMember = "ZoneName";
            zoneNameGridLookUpEdit.Properties.NullText = "Нет данных";
            
            beginNumberCellTBox.Text = "";
            endNumberCellTBox.Text = "";

            rowLabel.Text = storeNames.ParentName + ' ' + storeNames.Name;

            RunToControlVisual();
            splashScreenManager.CloseWaitForm();
        }

        private void LoadCellZonesData()
        {
            zoneNamesService = Program.kernel.Get<IZoneNamesService>();
            storeNamesService = Program.kernel.Get<IStoreNamesService>();
            wareHousesService = Program.kernel.Get<IWareHousesService>();
            storageGroupsService = Program.kernel.Get<IStorageGroupsService>();
            storageGroupZonesService = Program.kernel.Get<IStorageGroupZonesService>();
            cellZonesService = Program.kernel.Get<ICellZonesService>();
        }

        private void RunToControlVisual()
        {
                int line = storeNames.LineCount ?? 0; 
                int column = storeNames.ColumnCount ?? 0; 
                int cell = storeNames.CellCount ?? 0; 

                cellList = wareHousesService.GetWareHouses().Where(s => s.StoreNameId == storeNames.StoreNameId).ToList();

                if ((cellList.Count != 0) && (cellList[1].NumberCell != null))
                {
                    ControlVisual(line, column, cellList);
                }
                else
                    MessageBox.Show("Для выбранного ряда нет номеров ячеек!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
         
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
                    grControl.Name = "grControl" + cellList[k].WareHouseId;
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

                    if  (cellList[k].NumberCell == 0) 
                    {
                        grControl.Click -= new EventHandler(grControl_Click);
                    }
                    else
                    {
                        grControl.Click += new EventHandler(grControl_Click);
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

        protected void grControl_Click(object sender, EventArgs e)

        {

            DevExpress.XtraEditors.LabelControl grControl = sender as DevExpress.XtraEditors.LabelControl;
  
            int cellIndex = (int)grControl.Tag;
            object key = zoneNameGridLookUpEdit.EditValue;
            var selectedIndex = zoneNameGridLookUpEdit.Properties.GetIndexByKeyValue(key);

            if (selectedIndex != -1)
            {
               
                    if (cellList[cellIndex].ZoneColor == null) // можно выделять только не закрепленные ячейки (не закрашенные)
                    {

                        grControl.BackColor = colorPickEdit.Color;

                        Color color = (Color)colorPickEdit.EditValue;
                        cellList[cellIndex].ZoneColor = '#' + color.Name;
                        cellList[cellIndex].ZoneNameId = ((ZoneNamesDTO)zoneNameGridLookUpEdit.GetSelectedDataRow()).ZoneNameId;
                        cellList[cellIndex].ZoneName = ((ZoneNamesDTO)zoneNameGridLookUpEdit.GetSelectedDataRow()).ZoneName;

                    }
                    else
                    {
                        if (cellList[cellIndex].ZoneNameId == ((ZoneNamesDTO)zoneNameGridLookUpEdit.GetSelectedDataRow()).ZoneNameId)
                        {
                            if (cellList[cellIndex].LoadingStatusId == 1) // можно откреплять есть не загружена ячейка
                            {
                                grControl.BackColor = defColor;

                                cellList[cellIndex].ZoneColor = null;
                                cellList[cellIndex].ZoneNameId = null;
                                cellList[cellIndex].ZoneName = null;
                            }
                            else
                                MessageBox.Show("В ячейке находятся материалы! Открепить можно только пустую ячейку.", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                            MessageBox.Show("Вы не можете работать с данной зоной, потому что выбрана другая зона хранения для работы!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
            }
            else
                MessageBox.Show("Не выбрана зона хранения", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

     
        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void zoneNameGridLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            object key = zoneNameGridLookUpEdit.EditValue;
            var selectedIndex = zoneNameGridLookUpEdit.Properties.GetIndexByKeyValue(key);

            if (selectedIndex != -1) 
            {
                var selected = ((ZoneNamesDTO)zoneNameGridLookUpEdit.GetSelectedDataRow()).ZoneColor;
                colorPickEdit.EditValue = ColorTranslator.FromHtml(selected);
            }
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Сохранить изменения?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                object key = zoneNameGridLookUpEdit.EditValue;
                var selectedIndex = zoneNameGridLookUpEdit.Properties.GetIndexByKeyValue(key);

                if ((cellList.Count() > 0) && (selectedIndex != -1))
                {

                    bool result = cellZonesService.RenewalCellZones(cellList);

                    if (result)
                    {
                        MessageBox.Show("Изменения успешно сохранены!", "Сохранение", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        this.Close();
                    }
                    else
                        return;
                }
                else
                    MessageBox.Show("Не выбраны ячейки или зона хранения!", "Сохранение", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
   
        private void radioGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {
            RadioGroup rg = (RadioGroup)sender;
            int index = rg.SelectedIndex;

            if (index == 0)// по одной ячейке
            {
                noteBtn.Enabled = false;
            }
            if (index == 1) //диапазон
            {
                noteBtn.Enabled = true;
            }
            if (index == 2)//все свободные
            {
                noteBtn.Enabled = true;
            }
        }

        private void noteBtn_Click(object sender, EventArgs e)
        {
            object key = zoneNameGridLookUpEdit.EditValue;
            var selectedIndex = zoneNameGridLookUpEdit.Properties.GetIndexByKeyValue(key);

            if (selectedIndex != -1) //если выбрана зона 
            {  
                    // отметить все свободные
                    if (allFreeCheckEdit.Checked == true)
                    {
                        var cellFreeList = cellList.Where(c => c.ZoneNameId == null && c.NumberCell > 0).ToList();//список не закрашенных ячеек т.е не закрепленных в зоны

                        if (cellFreeList.Count > 0)
                        {
                            MarkCells(cellFreeList);

                            allFreeCheckEdit.Checked = false;
                            beginNumberCellTBox.Enabled = false;
                            endNumberCellTBox.Enabled = false;
                            beginNumberCellTBox.Text = "";
                            endNumberCellTBox.Text = "";
                        }
                        else
                            MessageBox.Show("Нет свободных ячеек", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        // в диапазоне
                        if ((beginNumberCellTBox.Text != "") && (endNumberCellTBox.Text != ""))
                        {
                            var cellFreeList = cellList.Where(c => c.ZoneNameId == null && (c.NumberCell >= Convert.ToInt32(beginNumberCellTBox.Text) && c.NumberCell <= Convert.ToInt32(endNumberCellTBox.Text))).ToList();//список не закрашенных ячеек т.е не закрепленных в зоны

                            if (cellFreeList.Count > 0)
                            {
                                MarkCells(cellFreeList);

                                allFreeCheckEdit.Checked = false;
                                allFreeCheckEdit.Enabled = true;
                            }
                            else
                                MessageBox.Show("Нет свободных ячеек", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        //
                    }
                }
                else
                    MessageBox.Show("Не выбрана ЗОНА", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
             
        }

        private void allFreeCheckEdit_CheckStateChanged(object sender, EventArgs e)
        {
             DevExpress.XtraEditors.CheckEdit editor = sender as DevExpress.XtraEditors.CheckEdit;
             if (editor.CheckState == CheckState.Checked)
             {
                 beginNumberCellTBox.Enabled = false;
                 beginNumberCellTBox.Text = "";
                 endNumberCellTBox.Enabled = false;
                 endNumberCellTBox.Text = "";
             }
             else
             {
                 beginNumberCellTBox.Enabled = true;
                 endNumberCellTBox.Enabled = true;
             }
        }

        private void MarkCells(List<WareHousesDTO> cellFreeList)
        {
            for (int j = 0; j <= cellFreeList.Count - 1; j++)
            {
                string keyControl = "grControl" + (cellFreeList[j].WareHouseId).ToString();

                DevExpress.XtraEditors.LabelControl grControl = panel.Controls.Find(keyControl, true)[0] as DevExpress.XtraEditors.LabelControl;

                grControl.BackColor = colorPickEdit.Color;

                var zoneId =  ((ZoneNamesDTO)zoneNameGridLookUpEdit.GetSelectedDataRow()).ZoneNameId;
                var zoneName = ((ZoneNamesDTO)zoneNameGridLookUpEdit.GetSelectedDataRow()).ZoneName;
                 Color color = (Color)colorPickEdit.EditValue;
                var zoneColor = '#' + color.Name;
                cellList.Where(s => s.WareHouseId == cellFreeList[j].WareHouseId).Select(s => {s.ZoneNameId = zoneId; s.ZoneName = zoneName; s.ZoneColor = zoneColor; return s; }).ToList();

            }
        }

        private void zoneNameGridLookUpEdit_QueryPopUp(object sender, CancelEventArgs e)
        {
            GridLookUpEdit editor = (GridLookUpEdit)sender;
            RepositoryItemGridLookUpEdit properties = editor.Properties;
            properties.PopupFormSize = new Size(editor.Width - 4, properties.PopupFormSize.Height);
        }
    }
}
