namespace TVM_WMS.GUI
{
    partial class SpravochFm
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
            this.spravochGrid = new DevExpress.XtraGrid.GridControl();
            this.spravochGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.repositoryItemColorPickEdit = new DevExpress.XtraEditors.Repository.RepositoryItemColorPickEdit();
            this.repositoryItemColorEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemColorEdit();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.addSpravochItemBtn = new DevExpress.XtraBars.BarButtonItem();
            this.editSpravochItemBtn = new DevExpress.XtraBars.BarButtonItem();
            this.deleteSpravochItemBtn = new DevExpress.XtraBars.BarButtonItem();
            this.standaloneBarDockControl1 = new DevExpress.XtraBars.StandaloneBarDockControl();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.addMaterialBtn = new DevExpress.XtraBars.BarButtonItem();
            this.editMaterialBtn = new DevExpress.XtraBars.BarButtonItem();
            this.deleteMaterialBtn = new DevExpress.XtraBars.BarButtonItem();
            this.splashScreenManager = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::TVM_WMS.GUI.WaitForm1), true, true);
            ((System.ComponentModel.ISupportInitialize)(this.spravochGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spravochGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemColorPickEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemColorEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // spravochGrid
            // 
            this.spravochGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.spravochGrid.Location = new System.Drawing.Point(-3, 35);
            this.spravochGrid.MainView = this.spravochGridView;
            this.spravochGrid.Name = "spravochGrid";
            this.spravochGrid.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemColorPickEdit,
            this.repositoryItemColorEdit1});
            this.spravochGrid.Size = new System.Drawing.Size(719, 574);
            this.spravochGrid.TabIndex = 0;
            this.spravochGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.spravochGridView});
            // 
            // spravochGridView
            // 
            this.spravochGridView.GridControl = this.spravochGrid;
            this.spravochGridView.Name = "spravochGridView";
            this.spravochGridView.OptionsDetail.DetailMode = DevExpress.XtraGrid.Views.Grid.DetailMode.Default;
            this.spravochGridView.OptionsView.ShowAutoFilterRow = true;
            this.spravochGridView.OptionsView.ShowGroupPanel = false;
            // 
            // repositoryItemColorPickEdit
            // 
            this.repositoryItemColorPickEdit.AutoHeight = false;
            this.repositoryItemColorPickEdit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemColorPickEdit.Name = "repositoryItemColorPickEdit";
            // 
            // repositoryItemColorEdit1
            // 
            this.repositoryItemColorEdit1.AutoHeight = false;
            this.repositoryItemColorEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemColorEdit1.Name = "repositoryItemColorEdit1";
            this.repositoryItemColorEdit1.StoreColorAsInteger = true;
            // 
            // barManager1
            // 
            this.barManager1.AllowCustomization = false;
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.DockControls.Add(this.standaloneBarDockControl1);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.addSpravochItemBtn,
            this.editSpravochItemBtn,
            this.deleteSpravochItemBtn});
            this.barManager1.MaxItemId = 21;
            // 
            // bar1
            // 
            this.bar1.BarName = "Custom 2";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Standalone;
            this.bar1.FloatLocation = new System.Drawing.Point(78, 182);
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.addSpravochItemBtn, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.editSpravochItemBtn, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.deleteSpravochItemBtn, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar1.OptionsBar.AllowQuickCustomization = false;
            this.bar1.OptionsBar.DrawDragBorder = false;
            this.bar1.StandaloneBarDockControl = this.standaloneBarDockControl1;
            this.bar1.Text = "Custom 2";
            // 
            // addSpravochItemBtn
            // 
            this.addSpravochItemBtn.Caption = "Добавить";
            this.addSpravochItemBtn.Glyph = global::TVM_WMS.GUI.Properties.Resources.Add;
            this.addSpravochItemBtn.Id = 6;
            this.addSpravochItemBtn.Name = "addSpravochItemBtn";
            this.addSpravochItemBtn.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.addSpravochItemBtn_ItemClick);
            // 
            // editSpravochItemBtn
            // 
            this.editSpravochItemBtn.Caption = "Редактировать";
            this.editSpravochItemBtn.Glyph = global::TVM_WMS.GUI.Properties.Resources.Edit;
            this.editSpravochItemBtn.Id = 7;
            this.editSpravochItemBtn.Name = "editSpravochItemBtn";
            this.editSpravochItemBtn.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.editSpravochItemBtn_ItemClick);
            // 
            // deleteSpravochItemBtn
            // 
            this.deleteSpravochItemBtn.Caption = "Удалить";
            this.deleteSpravochItemBtn.Glyph = global::TVM_WMS.GUI.Properties.Resources.Delete;
            this.deleteSpravochItemBtn.Id = 8;
            this.deleteSpravochItemBtn.Name = "deleteSpravochItemBtn";
            this.deleteSpravochItemBtn.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.deleteSpravochItemBtn_ItemClick);
            // 
            // standaloneBarDockControl1
            // 
            this.standaloneBarDockControl1.CausesValidation = false;
            this.standaloneBarDockControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.standaloneBarDockControl1.Location = new System.Drawing.Point(0, 0);
            this.standaloneBarDockControl1.Name = "standaloneBarDockControl1";
            this.standaloneBarDockControl1.Size = new System.Drawing.Size(716, 29);
            this.standaloneBarDockControl1.Text = "standaloneBarDockControl1";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(716, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 607);
            this.barDockControlBottom.Size = new System.Drawing.Size(716, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 607);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(716, 0);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 607);
            // 
            // addMaterialBtn
            // 
            this.addMaterialBtn.Id = -1;
            this.addMaterialBtn.Name = "addMaterialBtn";
            // 
            // editMaterialBtn
            // 
            this.editMaterialBtn.Id = -1;
            this.editMaterialBtn.Name = "editMaterialBtn";
            // 
            // deleteMaterialBtn
            // 
            this.deleteMaterialBtn.Id = -1;
            this.deleteMaterialBtn.Name = "deleteMaterialBtn";
            // 
            // splashScreenManager
            // 
            this.splashScreenManager.ClosingDelay = 500;
            // 
            // SpravochFm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(716, 607);
            this.Controls.Add(this.standaloneBarDockControl1);
            this.Controls.Add(this.spravochGrid);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SpravochFm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Справочники";
            ((System.ComponentModel.ISupportInitialize)(this.spravochGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spravochGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemColorPickEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemColorEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl spravochGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView spravochGridView;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarButtonItem addSpravochItemBtn;
        private DevExpress.XtraBars.BarButtonItem editSpravochItemBtn;
        private DevExpress.XtraBars.BarButtonItem deleteSpravochItemBtn;
        private DevExpress.XtraBars.StandaloneBarDockControl standaloneBarDockControl1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem addMaterialBtn;
        private DevExpress.XtraBars.BarButtonItem editMaterialBtn;
        private DevExpress.XtraBars.BarButtonItem deleteMaterialBtn;
        private DevExpress.XtraEditors.Repository.RepositoryItemColorPickEdit repositoryItemColorPickEdit;
        private DevExpress.XtraEditors.Repository.RepositoryItemColorEdit repositoryItemColorEdit1;
        private DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager;
    }
}