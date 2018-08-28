namespace TVM_WMS.GUI
{
    partial class RequirementOrdersFm
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
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.addOrderBtn = new DevExpress.XtraBars.BarButtonItem();
            this.editOrderBtn = new DevExpress.XtraBars.BarButtonItem();
            this.deleteOrderBtn = new DevExpress.XtraBars.BarButtonItem();
            this.standaloneBarDockControl1 = new DevExpress.XtraBars.StandaloneBarDockControl();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.endDateEdit = new DevExpress.XtraEditors.DateEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.beginDateEdit = new DevExpress.XtraEditors.DateEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.showOrdersForDate = new DevExpress.XtraEditors.SimpleButton();
            this.requirementOrdersGrid = new DevExpress.XtraGrid.GridControl();
            this.requirementOrdersGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.requirementNumberCol = new DevExpress.XtraGrid.Columns.GridColumn();
            this.requirementDateCol = new DevExpress.XtraGrid.Columns.GridColumn();
            this.responsiblePersonCol = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.requirementMaterialsGrid = new DevExpress.XtraGrid.GridControl();
            this.requirementMaterialsGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.articleCol = new DevExpress.XtraGrid.Columns.GridColumn();
            this.nameCol = new DevExpress.XtraGrid.Columns.GridColumn();
            this.quantityCol = new DevExpress.XtraGrid.Columns.GridColumn();
            this.unitLocalNameCol = new DevExpress.XtraGrid.Columns.GridColumn();
            this.splashScreenManager = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::TVM_WMS.GUI.WaitForm1), true, true);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.endDateEdit.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.endDateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.beginDateEdit.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.beginDateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.requirementOrdersGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.requirementOrdersGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.requirementMaterialsGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.requirementMaterialsGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // bar1
            // 
            this.bar1.BarName = "Custom 2";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Standalone;
            this.bar1.FloatLocation = new System.Drawing.Point(78, 182);
            this.bar1.OptionsBar.AllowQuickCustomization = false;
            this.bar1.OptionsBar.DrawDragBorder = false;
            this.bar1.OptionsBar.MultiLine = true;
            this.bar1.OptionsBar.UseWholeRow = true;
            this.bar1.Text = "Custom 2";
            // 
            // barManager1
            // 
            this.barManager1.AllowCustomization = false;
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar2});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.DockControls.Add(this.standaloneBarDockControl1);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.addOrderBtn,
            this.editOrderBtn,
            this.deleteOrderBtn,
            this.barButtonItem1});
            this.barManager1.MaxItemId = 22;
            // 
            // bar2
            // 
            this.bar2.BarName = "Custom 2";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Standalone;
            this.bar2.FloatLocation = new System.Drawing.Point(78, 182);
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.addOrderBtn, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.editOrderBtn, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.deleteOrderBtn, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar2.OptionsBar.AllowQuickCustomization = false;
            this.bar2.OptionsBar.DrawDragBorder = false;
            this.bar2.StandaloneBarDockControl = this.standaloneBarDockControl1;
            this.bar2.Text = "Custom 2";
            // 
            // addOrderBtn
            // 
            this.addOrderBtn.Caption = "Добавить";
            this.addOrderBtn.Glyph = global::TVM_WMS.GUI.Properties.Resources.Add;
            this.addOrderBtn.Id = 6;
            this.addOrderBtn.Name = "addOrderBtn";
            this.addOrderBtn.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.addOrderBtn_ItemClick);
            // 
            // editOrderBtn
            // 
            this.editOrderBtn.Caption = "Редактировать";
            this.editOrderBtn.Glyph = global::TVM_WMS.GUI.Properties.Resources.Edit;
            this.editOrderBtn.Id = 7;
            this.editOrderBtn.Name = "editOrderBtn";
            this.editOrderBtn.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.editOrderBtn_ItemClick);
            // 
            // deleteOrderBtn
            // 
            this.deleteOrderBtn.Caption = "Удалить";
            this.deleteOrderBtn.Glyph = global::TVM_WMS.GUI.Properties.Resources.Delete;
            this.deleteOrderBtn.Id = 8;
            this.deleteOrderBtn.Name = "deleteOrderBtn";
            this.deleteOrderBtn.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.deleteOrderBtn_ItemClick);
            // 
            // standaloneBarDockControl1
            // 
            this.standaloneBarDockControl1.CausesValidation = false;
            this.standaloneBarDockControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.standaloneBarDockControl1.Location = new System.Drawing.Point(0, 0);
            this.standaloneBarDockControl1.Name = "standaloneBarDockControl1";
            this.standaloneBarDockControl1.Size = new System.Drawing.Size(1148, 41);
            this.standaloneBarDockControl1.Text = "standaloneBarDockControl1";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(1148, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 744);
            this.barDockControlBottom.Size = new System.Drawing.Size(1148, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 744);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1148, 0);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 744);
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "Зона Приемки";
            this.barButtonItem1.Glyph = global::TVM_WMS.GUI.Properties.Resources.Shopping_cart1;
            this.barButtonItem1.Id = 21;
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // endDateEdit
            // 
            this.endDateEdit.EditValue = null;
            this.endDateEdit.Location = new System.Drawing.Point(154, 8);
            this.endDateEdit.MenuManager = this.barManager1;
            this.endDateEdit.Name = "endDateEdit";
            this.endDateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.endDateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.endDateEdit.Size = new System.Drawing.Size(100, 20);
            this.endDateEdit.TabIndex = 7;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(131, 11);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(13, 13);
            this.labelControl2.TabIndex = 9;
            this.labelControl2.Text = "По";
            // 
            // beginDateEdit
            // 
            this.beginDateEdit.EditValue = null;
            this.beginDateEdit.Location = new System.Drawing.Point(21, 8);
            this.beginDateEdit.MenuManager = this.barManager1;
            this.beginDateEdit.Name = "beginDateEdit";
            this.beginDateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.beginDateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.beginDateEdit.Size = new System.Drawing.Size(100, 20);
            this.beginDateEdit.TabIndex = 6;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(8, 11);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(7, 13);
            this.labelControl1.TabIndex = 8;
            this.labelControl1.Text = "С";
            // 
            // showOrdersForDate
            // 
            this.showOrdersForDate.Image = global::TVM_WMS.GUI.Properties.Resources.filter;
            this.showOrdersForDate.Location = new System.Drawing.Point(260, 6);
            this.showOrdersForDate.Name = "showOrdersForDate";
            this.showOrdersForDate.Size = new System.Drawing.Size(27, 23);
            this.showOrdersForDate.TabIndex = 10;
            this.showOrdersForDate.ToolTip = "Фильтровать";
            this.showOrdersForDate.Click += new System.EventHandler(this.showOrdersForDate_Click);
            // 
            // requirementOrdersGrid
            // 
            this.requirementOrdersGrid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.requirementOrdersGrid.Location = new System.Drawing.Point(0, 36);
            this.requirementOrdersGrid.MainView = this.requirementOrdersGridView;
            this.requirementOrdersGrid.Name = "requirementOrdersGrid";
            this.requirementOrdersGrid.ShowOnlyPredefinedDetails = true;
            this.requirementOrdersGrid.Size = new System.Drawing.Size(1148, 344);
            this.requirementOrdersGrid.TabIndex = 11;
            this.requirementOrdersGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.requirementOrdersGridView});
            // 
            // requirementOrdersGridView
            // 
            this.requirementOrdersGridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.requirementNumberCol,
            this.requirementDateCol,
            this.responsiblePersonCol});
            this.requirementOrdersGridView.GridControl = this.requirementOrdersGrid;
            this.requirementOrdersGridView.Name = "requirementOrdersGridView";
            this.requirementOrdersGridView.OptionsDetail.DetailMode = DevExpress.XtraGrid.Views.Grid.DetailMode.Default;
            this.requirementOrdersGridView.OptionsView.ShowAutoFilterRow = true;
            this.requirementOrdersGridView.OptionsView.ShowGroupPanel = false;
            this.requirementOrdersGridView.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.requirementOrdersGridView_FocusedRowChanged);
            // 
            // requirementNumberCol
            // 
            this.requirementNumberCol.AppearanceHeader.Options.UseTextOptions = true;
            this.requirementNumberCol.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.requirementNumberCol.Caption = "Номер документа";
            this.requirementNumberCol.FieldName = "RequirementNumber";
            this.requirementNumberCol.Name = "requirementNumberCol";
            this.requirementNumberCol.OptionsColumn.AllowEdit = false;
            this.requirementNumberCol.OptionsColumn.AllowFocus = false;
            this.requirementNumberCol.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.requirementNumberCol.Visible = true;
            this.requirementNumberCol.VisibleIndex = 0;
            this.requirementNumberCol.Width = 297;
            // 
            // requirementDateCol
            // 
            this.requirementDateCol.AppearanceHeader.Options.UseTextOptions = true;
            this.requirementDateCol.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.requirementDateCol.Caption = "Дата документа";
            this.requirementDateCol.FieldName = "RequirementDate";
            this.requirementDateCol.Name = "requirementDateCol";
            this.requirementDateCol.OptionsColumn.AllowEdit = false;
            this.requirementDateCol.OptionsColumn.AllowFocus = false;
            this.requirementDateCol.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.requirementDateCol.Visible = true;
            this.requirementDateCol.VisibleIndex = 1;
            this.requirementDateCol.Width = 121;
            // 
            // responsiblePersonCol
            // 
            this.responsiblePersonCol.AppearanceHeader.Options.UseTextOptions = true;
            this.responsiblePersonCol.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.responsiblePersonCol.Caption = "Ответственное лицо";
            this.responsiblePersonCol.Name = "responsiblePersonCol";
            this.responsiblePersonCol.OptionsColumn.AllowEdit = false;
            this.responsiblePersonCol.OptionsColumn.AllowFocus = false;
            this.responsiblePersonCol.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.responsiblePersonCol.Visible = true;
            this.responsiblePersonCol.VisibleIndex = 2;
            this.responsiblePersonCol.Width = 485;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.showOrdersForDate);
            this.panelControl1.Controls.Add(this.endDateEdit);
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Controls.Add(this.beginDateEdit);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Location = new System.Drawing.Point(588, 1);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(294, 36);
            this.panelControl1.TabIndex = 14;
            // 
            // requirementMaterialsGrid
            // 
            this.requirementMaterialsGrid.AllowDrop = true;
            this.requirementMaterialsGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.requirementMaterialsGrid.Location = new System.Drawing.Point(0, 383);
            this.requirementMaterialsGrid.MainView = this.requirementMaterialsGridView;
            this.requirementMaterialsGrid.Name = "requirementMaterialsGrid";
            this.requirementMaterialsGrid.ShowOnlyPredefinedDetails = true;
            this.requirementMaterialsGrid.Size = new System.Drawing.Size(1148, 355);
            this.requirementMaterialsGrid.TabIndex = 12;
            this.requirementMaterialsGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.requirementMaterialsGridView});
            // 
            // requirementMaterialsGridView
            // 
            this.requirementMaterialsGridView.ColumnPanelRowHeight = 40;
            this.requirementMaterialsGridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.articleCol,
            this.nameCol,
            this.quantityCol,
            this.unitLocalNameCol});
            this.requirementMaterialsGridView.GridControl = this.requirementMaterialsGrid;
            this.requirementMaterialsGridView.Name = "requirementMaterialsGridView";
            this.requirementMaterialsGridView.OptionsDetail.DetailMode = DevExpress.XtraGrid.Views.Grid.DetailMode.Default;
            this.requirementMaterialsGridView.OptionsView.ShowAutoFilterRow = true;
            this.requirementMaterialsGridView.OptionsView.ShowFooter = true;
            this.requirementMaterialsGridView.OptionsView.ShowGroupPanel = false;
            // 
            // articleCol
            // 
            this.articleCol.AppearanceHeader.Options.UseTextOptions = true;
            this.articleCol.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.articleCol.Caption = "Код";
            this.articleCol.FieldName = "Article";
            this.articleCol.Name = "articleCol";
            this.articleCol.OptionsColumn.AllowEdit = false;
            this.articleCol.OptionsColumn.AllowFocus = false;
            this.articleCol.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.articleCol.Visible = true;
            this.articleCol.VisibleIndex = 0;
            this.articleCol.Width = 206;
            // 
            // nameCol
            // 
            this.nameCol.AppearanceHeader.Options.UseTextOptions = true;
            this.nameCol.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.nameCol.Caption = "Наименование";
            this.nameCol.FieldName = "Name";
            this.nameCol.Name = "nameCol";
            this.nameCol.OptionsColumn.AllowEdit = false;
            this.nameCol.OptionsColumn.AllowFocus = false;
            this.nameCol.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.nameCol.Visible = true;
            this.nameCol.VisibleIndex = 1;
            this.nameCol.Width = 663;
            // 
            // quantityCol
            // 
            this.quantityCol.AppearanceCell.Options.UseTextOptions = true;
            this.quantityCol.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.quantityCol.AppearanceHeader.Options.UseTextOptions = true;
            this.quantityCol.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.quantityCol.Caption = "Кол-во";
            this.quantityCol.FieldName = "RequiredQuantity";
            this.quantityCol.Name = "quantityCol";
            this.quantityCol.OptionsColumn.AllowEdit = false;
            this.quantityCol.OptionsColumn.AllowFocus = false;
            this.quantityCol.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.quantityCol.Visible = true;
            this.quantityCol.VisibleIndex = 2;
            this.quantityCol.Width = 160;
            // 
            // unitLocalNameCol
            // 
            this.unitLocalNameCol.AppearanceHeader.Options.UseTextOptions = true;
            this.unitLocalNameCol.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.unitLocalNameCol.Caption = "Ед.изм.";
            this.unitLocalNameCol.FieldName = "UnitLocalName";
            this.unitLocalNameCol.Name = "unitLocalNameCol";
            this.unitLocalNameCol.OptionsColumn.AllowEdit = false;
            this.unitLocalNameCol.OptionsColumn.AllowFocus = false;
            this.unitLocalNameCol.Visible = true;
            this.unitLocalNameCol.VisibleIndex = 3;
            this.unitLocalNameCol.Width = 101;
            // 
            // splashScreenManager
            // 
            this.splashScreenManager.ClosingDelay = 500;
            // 
            // RequirementOrdersFm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1148, 744);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.standaloneBarDockControl1);
            this.Controls.Add(this.requirementOrdersGrid);
            this.Controls.Add(this.requirementMaterialsGrid);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "RequirementOrdersFm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Расходные документы (требования)";
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.endDateEdit.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.endDateEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.beginDateEdit.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.beginDateEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.requirementOrdersGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.requirementOrdersGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.requirementMaterialsGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.requirementMaterialsGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarButtonItem addOrderBtn;
        private DevExpress.XtraBars.BarButtonItem editOrderBtn;
        private DevExpress.XtraBars.BarButtonItem deleteOrderBtn;
        private DevExpress.XtraBars.StandaloneBarDockControl standaloneBarDockControl1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton showOrdersForDate;
        private DevExpress.XtraEditors.DateEdit endDateEdit;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.DateEdit beginDateEdit;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraGrid.GridControl requirementOrdersGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView requirementOrdersGridView;
        private DevExpress.XtraGrid.Columns.GridColumn requirementNumberCol;
        private DevExpress.XtraGrid.Columns.GridColumn requirementDateCol;
        private DevExpress.XtraGrid.Columns.GridColumn responsiblePersonCol;
        private DevExpress.XtraGrid.GridControl requirementMaterialsGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView requirementMaterialsGridView;
        private DevExpress.XtraGrid.Columns.GridColumn nameCol;
        private DevExpress.XtraGrid.Columns.GridColumn quantityCol;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraGrid.Columns.GridColumn articleCol;
        private DevExpress.XtraGrid.Columns.GridColumn unitLocalNameCol;
        private DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager;
    }
}