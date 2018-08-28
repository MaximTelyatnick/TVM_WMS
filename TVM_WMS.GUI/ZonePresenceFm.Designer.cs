namespace TVM_WMS.GUI
{
    partial class ZonePresenceFm
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
            this.zonePresenceGrid = new DevExpress.XtraGrid.GridControl();
            this.zonePresenceGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.numberCellCol = new DevExpress.XtraGrid.Columns.GridColumn();
            this.materialNameCol = new DevExpress.XtraGrid.Columns.GridColumn();
            this.storeQuantityCol = new DevExpress.XtraGrid.Columns.GridColumn();
            this.loadingStatusNameCol = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemProgressBar1 = new DevExpress.XtraEditors.Repository.RepositoryItemProgressBar();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.zoneNameTBox = new DevExpress.XtraEditors.TextEdit();
            this.splashScreenManager = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::TVM_WMS.GUI.WaitForm1), true, true);
            ((System.ComponentModel.ISupportInitialize)(this.zonePresenceGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zonePresenceGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemProgressBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zoneNameTBox.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // zonePresenceGrid
            // 
            this.zonePresenceGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.zonePresenceGrid.Location = new System.Drawing.Point(-5, 35);
            this.zonePresenceGrid.MainView = this.zonePresenceGridView;
            this.zonePresenceGrid.Name = "zonePresenceGrid";
            this.zonePresenceGrid.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemProgressBar1});
            this.zonePresenceGrid.Size = new System.Drawing.Size(749, 554);
            this.zonePresenceGrid.TabIndex = 0;
            this.zonePresenceGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.zonePresenceGridView});
            // 
            // zonePresenceGridView
            // 
            this.zonePresenceGridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.numberCellCol,
            this.materialNameCol,
            this.storeQuantityCol,
            this.loadingStatusNameCol});
            this.zonePresenceGridView.GridControl = this.zonePresenceGrid;
            this.zonePresenceGridView.GroupCount = 1;
            this.zonePresenceGridView.Name = "zonePresenceGridView";
            this.zonePresenceGridView.OptionsDetail.DetailMode = DevExpress.XtraGrid.Views.Grid.DetailMode.Default;
            this.zonePresenceGridView.OptionsView.ShowAutoFilterRow = true;
            this.zonePresenceGridView.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.loadingStatusNameCol, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // numberCellCol
            // 
            this.numberCellCol.AppearanceHeader.Options.UseTextOptions = true;
            this.numberCellCol.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.numberCellCol.Caption = "Ячейка";
            this.numberCellCol.FieldName = "NumberCell";
            this.numberCellCol.Name = "numberCellCol";
            this.numberCellCol.OptionsColumn.AllowEdit = false;
            this.numberCellCol.OptionsColumn.AllowFocus = false;
            this.numberCellCol.Visible = true;
            this.numberCellCol.VisibleIndex = 0;
            this.numberCellCol.Width = 102;
            // 
            // materialNameCol
            // 
            this.materialNameCol.AppearanceHeader.Options.UseTextOptions = true;
            this.materialNameCol.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.materialNameCol.Caption = "Номенклатура";
            this.materialNameCol.FieldName = "MaterialName";
            this.materialNameCol.Name = "materialNameCol";
            this.materialNameCol.OptionsColumn.AllowEdit = false;
            this.materialNameCol.OptionsColumn.AllowFocus = false;
            this.materialNameCol.Visible = true;
            this.materialNameCol.VisibleIndex = 1;
            this.materialNameCol.Width = 479;
            // 
            // storeQuantityCol
            // 
            this.storeQuantityCol.AppearanceHeader.Options.UseTextOptions = true;
            this.storeQuantityCol.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.storeQuantityCol.Caption = "Кол-во";
            this.storeQuantityCol.FieldName = "QuantityStore";
            this.storeQuantityCol.Name = "storeQuantityCol";
            this.storeQuantityCol.OptionsColumn.AllowEdit = false;
            this.storeQuantityCol.OptionsColumn.AllowFocus = false;
            this.storeQuantityCol.Visible = true;
            this.storeQuantityCol.VisibleIndex = 2;
            this.storeQuantityCol.Width = 73;
            // 
            // loadingStatusNameCol
            // 
            this.loadingStatusNameCol.AppearanceHeader.Options.UseTextOptions = true;
            this.loadingStatusNameCol.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.loadingStatusNameCol.Caption = "Загруженность";
            this.loadingStatusNameCol.FieldName = "LoadingStatusName";
            this.loadingStatusNameCol.Name = "loadingStatusNameCol";
            this.loadingStatusNameCol.OptionsColumn.AllowEdit = false;
            this.loadingStatusNameCol.OptionsColumn.AllowFocus = false;
            this.loadingStatusNameCol.Visible = true;
            this.loadingStatusNameCol.VisibleIndex = 3;
            this.loadingStatusNameCol.Width = 77;
            // 
            // repositoryItemProgressBar1
            // 
            this.repositoryItemProgressBar1.Name = "repositoryItemProgressBar1";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(12, 12);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(75, 13);
            this.labelControl3.TabIndex = 4;
            this.labelControl3.Text = "Зона хранения";
            // 
            // zoneNameTBox
            // 
            this.zoneNameTBox.Enabled = false;
            this.zoneNameTBox.Location = new System.Drawing.Point(93, 9);
            this.zoneNameTBox.Name = "zoneNameTBox";
            this.zoneNameTBox.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black;
            this.zoneNameTBox.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.zoneNameTBox.Size = new System.Drawing.Size(651, 20);
            this.zoneNameTBox.TabIndex = 6;
            // 
            // splashScreenManager
            // 
            this.splashScreenManager.ClosingDelay = 500;
            // 
            // ZonePresenceFm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(744, 586);
            this.Controls.Add(this.zoneNameTBox);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.zonePresenceGrid);
            this.Name = "ZonePresenceFm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Загруженность зоны хранения ";
            ((System.ComponentModel.ISupportInitialize)(this.zonePresenceGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zonePresenceGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemProgressBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zoneNameTBox.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl zonePresenceGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView zonePresenceGridView;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit zoneNameTBox;
        private DevExpress.XtraGrid.Columns.GridColumn numberCellCol;
        private DevExpress.XtraGrid.Columns.GridColumn materialNameCol;
        private DevExpress.XtraGrid.Columns.GridColumn storeQuantityCol;
        private DevExpress.XtraGrid.Columns.GridColumn loadingStatusNameCol;
        private DevExpress.XtraEditors.Repository.RepositoryItemProgressBar repositoryItemProgressBar1;
        private DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager;
    }
}