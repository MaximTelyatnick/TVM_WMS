namespace TVM_WMS.GUI
{
    partial class CellZonesFm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CellZonesFm));
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.colorPickEdit = new DevExpress.XtraEditors.ColorPickEdit();
            this.cancelBtn = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.panel = new DevExpress.XtraEditors.PanelControl();
            this.rowLabel = new DevExpress.XtraEditors.LabelControl();
            this.imageCollection = new DevExpress.Utils.ImageCollection(this.components);
            this.SaveBtn = new DevExpress.XtraEditors.SimpleButton();
            this.noteBtn = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.allFreeCheckEdit = new DevExpress.XtraEditors.CheckEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.endNumberCellTBox = new DevExpress.XtraEditors.TextEdit();
            this.beginNumberCellTBox = new DevExpress.XtraEditors.TextEdit();
            this.zoneNameGridLookUpEdit = new DevExpress.XtraEditors.GridLookUpEdit();
            this.repositoryItemColorPickEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemColorPickEdit();
            this.gridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.zoneNameColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.zoneColorColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.splashScreenManager = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::TVM_WMS.GUI.WaitForm1), true, true);
            this.cellImageCollection = new DevExpress.Utils.ImageCollection(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.colorPickEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.allFreeCheckEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.endNumberCellTBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.beginNumberCellTBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zoneNameGridLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemColorPickEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cellImageCollection)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelControl1.Location = new System.Drawing.Point(550, 53);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(29, 13);
            this.labelControl1.TabIndex = 12;
            this.labelControl1.Text = "Цвет ";
            // 
            // colorPickEdit
            // 
            this.colorPickEdit.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.colorPickEdit.EditValue = System.Drawing.Color.Empty;
            this.colorPickEdit.Enabled = false;
            this.colorPickEdit.Location = new System.Drawing.Point(585, 45);
            this.colorPickEdit.Name = "colorPickEdit";
            this.colorPickEdit.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.colorPickEdit.Properties.Appearance.Options.UseFont = true;
            this.colorPickEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.colorPickEdit.Size = new System.Drawing.Size(49, 26);
            this.colorPickEdit.TabIndex = 11;
            // 
            // cancelBtn
            // 
            this.cancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelBtn.Location = new System.Drawing.Point(1366, 710);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 15;
            this.cancelBtn.Text = "Отмена";
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // labelControl2
            // 
            this.labelControl2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelControl2.Location = new System.Drawing.Point(12, 53);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(24, 13);
            this.labelControl2.TabIndex = 16;
            this.labelControl2.Text = "Зона";
            // 
            // panel
            // 
            this.panel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel.Location = new System.Drawing.Point(7, 86);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(1441, 608);
            this.panel.TabIndex = 17;
            // 
            // rowLabel
            // 
            this.rowLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.rowLabel.Appearance.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.rowLabel.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.rowLabel.Location = new System.Drawing.Point(12, 5);
            this.rowLabel.Name = "rowLabel";
            this.rowLabel.Size = new System.Drawing.Size(36, 23);
            this.rowLabel.TabIndex = 18;
            this.rowLabel.Text = "ряд";
            // 
            // imageCollection
            // 
            this.imageCollection.ImageSize = new System.Drawing.Size(64, 64);
            this.imageCollection.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection.ImageStream")));
            this.imageCollection.Images.SetKeyName(0, "1471349741_cross-24.png");
            // 
            // SaveBtn
            // 
            this.SaveBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SaveBtn.Appearance.Options.UseTextOptions = true;
            this.SaveBtn.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.SaveBtn.Location = new System.Drawing.Point(1280, 710);
            this.SaveBtn.Name = "SaveBtn";
            this.SaveBtn.Size = new System.Drawing.Size(80, 23);
            this.SaveBtn.TabIndex = 22;
            this.SaveBtn.Text = "Сохранить";
            this.SaveBtn.Click += new System.EventHandler(this.SaveBtn_Click);
            // 
            // noteBtn
            // 
            this.noteBtn.Location = new System.Drawing.Point(129, 43);
            this.noteBtn.Name = "noteBtn";
            this.noteBtn.Size = new System.Drawing.Size(86, 23);
            this.noteBtn.TabIndex = 4;
            this.noteBtn.Text = "Отметить";
            this.noteBtn.Click += new System.EventHandler(this.noteBtn_Click);
            // 
            // panelControl1
            // 
            this.panelControl1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panelControl1.Controls.Add(this.allFreeCheckEdit);
            this.panelControl1.Controls.Add(this.labelControl4);
            this.panelControl1.Controls.Add(this.labelControl3);
            this.panelControl1.Controls.Add(this.endNumberCellTBox);
            this.panelControl1.Controls.Add(this.beginNumberCellTBox);
            this.panelControl1.Controls.Add(this.noteBtn);
            this.panelControl1.Location = new System.Drawing.Point(1219, 5);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(229, 75);
            this.panelControl1.TabIndex = 27;
            // 
            // allFreeCheckEdit
            // 
            this.allFreeCheckEdit.Location = new System.Drawing.Point(12, 45);
            this.allFreeCheckEdit.Name = "allFreeCheckEdit";
            this.allFreeCheckEdit.Properties.Caption = "Все свободные";
            this.allFreeCheckEdit.Size = new System.Drawing.Size(96, 19);
            this.allFreeCheckEdit.TabIndex = 5;
            this.allFreeCheckEdit.CheckStateChanged += new System.EventHandler(this.allFreeCheckEdit_CheckStateChanged);
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(112, 12);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(15, 13);
            this.labelControl4.TabIndex = 29;
            this.labelControl4.Text = "ПО";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(12, 12);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(7, 13);
            this.labelControl3.TabIndex = 28;
            this.labelControl3.Text = "С";
            // 
            // endNumberCellTBox
            // 
            this.endNumberCellTBox.Location = new System.Drawing.Point(134, 10);
            this.endNumberCellTBox.Name = "endNumberCellTBox";
            this.endNumberCellTBox.Size = new System.Drawing.Size(66, 20);
            this.endNumberCellTBox.TabIndex = 3;
            // 
            // beginNumberCellTBox
            // 
            this.beginNumberCellTBox.Location = new System.Drawing.Point(28, 10);
            this.beginNumberCellTBox.Name = "beginNumberCellTBox";
            this.beginNumberCellTBox.Size = new System.Drawing.Size(68, 20);
            this.beginNumberCellTBox.TabIndex = 2;
            // 
            // zoneNameGridLookUpEdit
            // 
            this.zoneNameGridLookUpEdit.Location = new System.Drawing.Point(42, 45);
            this.zoneNameGridLookUpEdit.Name = "zoneNameGridLookUpEdit";
            this.zoneNameGridLookUpEdit.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.zoneNameGridLookUpEdit.Properties.Appearance.Options.UseFont = true;
            this.zoneNameGridLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.zoneNameGridLookUpEdit.Properties.ImmediatePopup = true;
            this.zoneNameGridLookUpEdit.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            this.zoneNameGridLookUpEdit.Properties.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemColorPickEdit1});
            this.zoneNameGridLookUpEdit.Properties.View = this.gridLookUpEdit1View;
            this.zoneNameGridLookUpEdit.Size = new System.Drawing.Size(495, 26);
            this.zoneNameGridLookUpEdit.TabIndex = 1;
            this.zoneNameGridLookUpEdit.QueryPopUp += new System.ComponentModel.CancelEventHandler(this.zoneNameGridLookUpEdit_QueryPopUp);
            this.zoneNameGridLookUpEdit.EditValueChanged += new System.EventHandler(this.zoneNameGridLookUpEdit_EditValueChanged);
            // 
            // repositoryItemColorPickEdit1
            // 
            this.repositoryItemColorPickEdit1.AutoHeight = false;
            this.repositoryItemColorPickEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemColorPickEdit1.Name = "repositoryItemColorPickEdit1";
            // 
            // gridLookUpEdit1View
            // 
            this.gridLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.zoneNameColumn,
            this.zoneColorColumn});
            this.gridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridLookUpEdit1View.Name = "gridLookUpEdit1View";
            this.gridLookUpEdit1View.OptionsDetail.DetailMode = DevExpress.XtraGrid.Views.Grid.DetailMode.Default;
            this.gridLookUpEdit1View.OptionsFind.AlwaysVisible = true;
            this.gridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridLookUpEdit1View.OptionsView.ShowAutoFilterRow = true;
            this.gridLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // zoneNameColumn
            // 
            this.zoneNameColumn.Caption = "Наименование зоны";
            this.zoneNameColumn.FieldName = "ZoneName";
            this.zoneNameColumn.Name = "zoneNameColumn";
            this.zoneNameColumn.OptionsColumn.AllowEdit = false;
            this.zoneNameColumn.OptionsColumn.AllowFocus = false;
            this.zoneNameColumn.Visible = true;
            this.zoneNameColumn.VisibleIndex = 0;
            this.zoneNameColumn.Width = 200;
            // 
            // zoneColorColumn
            // 
            this.zoneColorColumn.Caption = "Цвет";
            this.zoneColorColumn.ColumnEdit = this.repositoryItemColorPickEdit1;
            this.zoneColorColumn.FieldName = "ZoneColor";
            this.zoneColorColumn.Name = "zoneColorColumn";
            this.zoneColorColumn.OptionsColumn.AllowEdit = false;
            this.zoneColorColumn.OptionsColumn.AllowFocus = false;
            this.zoneColorColumn.Visible = true;
            this.zoneColorColumn.VisibleIndex = 1;
            // 
            // splashScreenManager
            // 
            this.splashScreenManager.ClosingDelay = 500;
            // 
            // cellImageCollection
            // 
            this.cellImageCollection.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("cellImageCollection.ImageStream")));
            this.cellImageCollection.InsertGalleryImage("database_16x16.png", "office2013/data/database_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("office2013/data/database_16x16.png"), 0);
            this.cellImageCollection.Images.SetKeyName(0, "database_16x16.png");
            this.cellImageCollection.InsertGalleryImage("addnewdatasource_16x16.png", "office2013/data/addnewdatasource_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("office2013/data/addnewdatasource_16x16.png"), 1);
            this.cellImageCollection.Images.SetKeyName(1, "addnewdatasource_16x16.png");
            this.cellImageCollection.InsertGalleryImage("deletedatasource_16x16.png", "office2013/data/deletedatasource_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("office2013/data/deletedatasource_16x16.png"), 2);
            this.cellImageCollection.Images.SetKeyName(2, "deletedatasource_16x16.png");
            // 
            // CellZonesFm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1454, 744);
            this.Controls.Add(this.zoneNameGridLookUpEdit);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.SaveBtn);
            this.Controls.Add(this.rowLabel);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.colorPickEdit);
            this.Name = "CellZonesFm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Распределение складских ячеек по зонам хранения";
            ((System.ComponentModel.ISupportInitialize)(this.colorPickEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.allFreeCheckEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.endNumberCellTBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.beginNumberCellTBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zoneNameGridLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemColorPickEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cellImageCollection)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.ColorPickEdit colorPickEdit;
        private DevExpress.XtraEditors.SimpleButton cancelBtn;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.PanelControl panel;
        private DevExpress.XtraEditors.LabelControl rowLabel;
        private DevExpress.Utils.ImageCollection imageCollection;
        private DevExpress.XtraEditors.SimpleButton SaveBtn;
        private DevExpress.XtraEditors.SimpleButton noteBtn;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.CheckEdit allFreeCheckEdit;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit endNumberCellTBox;
        private DevExpress.XtraEditors.TextEdit beginNumberCellTBox;
        private DevExpress.XtraEditors.GridLookUpEdit zoneNameGridLookUpEdit;
        private DevExpress.XtraGrid.Views.Grid.GridView gridLookUpEdit1View;
        private DevExpress.XtraGrid.Columns.GridColumn zoneNameColumn;
        private DevExpress.XtraGrid.Columns.GridColumn zoneColorColumn;
        private DevExpress.XtraEditors.Repository.RepositoryItemColorPickEdit repositoryItemColorPickEdit1;
        private DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager;
        private DevExpress.Utils.ImageCollection cellImageCollection;
    }
}