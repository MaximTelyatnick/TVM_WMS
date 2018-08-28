namespace TVM_WMS.GUI
{
    partial class OrderEditFm
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
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule1 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule2 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrderEditFm));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule3 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            this.orderNumberTBox = new DevExpress.XtraEditors.TextEdit();
            this.orderDateTBox = new DevExpress.XtraEditors.DateEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.saveBtn = new DevExpress.XtraEditors.SimpleButton();
            this.cancelBtn = new DevExpress.XtraEditors.SimpleButton();
            this.receiptsGrid = new DevExpress.XtraGrid.GridControl();
            this.receiptsGridView = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridView();
            this.gridBand1 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.articleCol = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.nameCol = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.dateProductionCol = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.dateExpirationCol = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.quantityCol = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.unitLocalNameCol = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand2 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.unitPriceCol = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.totalPriceCol = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.addReceiptBtn = new DevExpress.XtraBars.BarButtonItem();
            this.editReceiptBtn = new DevExpress.XtraBars.BarButtonItem();
            this.deleteReceiptBtn = new DevExpress.XtraBars.BarButtonItem();
            this.standaloneBarDockControl1 = new DevExpress.XtraBars.StandaloneBarDockControl();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.orderValidationProvider = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
            this.contractorsGridEdit = new DevExpress.XtraEditors.GridLookUpEdit();
            this.gridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.nameContrCol = new DevExpress.XtraGrid.Columns.GridColumn();
            this.shortNameCol = new DevExpress.XtraGrid.Columns.GridColumn();
            this.srnCol = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tinCol = new DevExpress.XtraGrid.Columns.GridColumn();
            this.validateLbl = new DevExpress.XtraEditors.LabelControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            ((System.ComponentModel.ISupportInitialize)(this.orderNumberTBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderDateTBox.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderDateTBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.receiptsGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.receiptsGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderValidationProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.contractorsGridEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // orderNumberTBox
            // 
            this.orderNumberTBox.Location = new System.Drawing.Point(13, 44);
            this.orderNumberTBox.Name = "orderNumberTBox";
            this.orderNumberTBox.Properties.MaxLength = 20;
            this.orderNumberTBox.Size = new System.Drawing.Size(207, 20);
            this.orderNumberTBox.TabIndex = 1;
            conditionValidationRule1.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule1.ErrorText = "Поле Номер Документа обязательное для заполнения";
            conditionValidationRule1.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical;
            this.orderValidationProvider.SetValidationRule(this.orderNumberTBox, conditionValidationRule1);
            this.orderNumberTBox.TextChanged += new System.EventHandler(this.orderNumberTBox_TextChanged);
            // 
            // orderDateTBox
            // 
            this.orderDateTBox.EditValue = null;
            this.orderDateTBox.Location = new System.Drawing.Point(226, 44);
            this.orderDateTBox.Name = "orderDateTBox";
            this.orderDateTBox.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.orderDateTBox.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.orderDateTBox.Size = new System.Drawing.Size(146, 20);
            this.orderDateTBox.TabIndex = 2;
            conditionValidationRule2.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.Greater;
            conditionValidationRule2.ErrorText = "Поле Дата Документа обязательное для заполнения";
            conditionValidationRule2.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical;
            this.orderValidationProvider.SetValidationRule(this.orderDateTBox, conditionValidationRule2);
            this.orderDateTBox.EditValueChanged += new System.EventHandler(this.orderDateTBox_EditValueChanged);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(13, 24);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(89, 13);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "Номер документа";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(226, 24);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(84, 13);
            this.labelControl2.TabIndex = 4;
            this.labelControl2.Text = "Дата документа";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(378, 23);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(57, 13);
            this.labelControl3.TabIndex = 5;
            this.labelControl3.Text = "Поставщик";
            // 
            // saveBtn
            // 
            this.saveBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.saveBtn.Location = new System.Drawing.Point(1144, 572);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(83, 28);
            this.saveBtn.TabIndex = 7;
            this.saveBtn.Text = "Сохранить";
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Location = new System.Drawing.Point(1233, 572);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(83, 28);
            this.cancelBtn.TabIndex = 8;
            this.cancelBtn.Text = "Отмена";
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // receiptsGrid
            // 
            this.receiptsGrid.AllowDrop = true;
            this.receiptsGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.receiptsGrid.Location = new System.Drawing.Point(3, 107);
            this.receiptsGrid.MainView = this.receiptsGridView;
            this.receiptsGrid.Name = "receiptsGrid";
            this.receiptsGrid.ShowOnlyPredefinedDetails = true;
            this.receiptsGrid.Size = new System.Drawing.Size(1316, 447);
            this.receiptsGrid.TabIndex = 4;
            this.receiptsGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.receiptsGridView,
            this.gridView3});
            // 
            // receiptsGridView
            // 
            this.receiptsGridView.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBand1,
            this.gridBand2});
            this.receiptsGridView.ColumnPanelRowHeight = 40;
            this.receiptsGridView.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
            this.articleCol,
            this.nameCol,
            this.quantityCol,
            this.unitLocalNameCol,
            this.unitPriceCol,
            this.totalPriceCol,
            this.dateProductionCol,
            this.dateExpirationCol});
            this.receiptsGridView.GridControl = this.receiptsGrid;
            this.receiptsGridView.Name = "receiptsGridView";
            this.receiptsGridView.OptionsDetail.DetailMode = DevExpress.XtraGrid.Views.Grid.DetailMode.Default;
            this.receiptsGridView.OptionsView.ShowAutoFilterRow = true;
            this.receiptsGridView.OptionsView.ShowFooter = true;
            this.receiptsGridView.OptionsView.ShowGroupPanel = false;
            this.receiptsGridView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.receiptsGridView_KeyDown);
            this.receiptsGridView.DoubleClick += new System.EventHandler(this.receiptsGridView_DoubleClick);
            // 
            // gridBand1
            // 
            this.gridBand1.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gridBand1.AppearanceHeader.Options.UseFont = true;
            this.gridBand1.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand1.Caption = "Номенклатура";
            this.gridBand1.Columns.Add(this.articleCol);
            this.gridBand1.Columns.Add(this.nameCol);
            this.gridBand1.Columns.Add(this.dateProductionCol);
            this.gridBand1.Columns.Add(this.dateExpirationCol);
            this.gridBand1.Columns.Add(this.quantityCol);
            this.gridBand1.Columns.Add(this.unitLocalNameCol);
            this.gridBand1.ImageAlignment = System.Drawing.StringAlignment.Center;
            this.gridBand1.Name = "gridBand1";
            this.gridBand1.VisibleIndex = 0;
            this.gridBand1.Width = 890;
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
            this.articleCol.Width = 96;
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
            this.nameCol.Width = 499;
            // 
            // dateProductionCol
            // 
            this.dateProductionCol.AppearanceHeader.Options.UseTextOptions = true;
            this.dateProductionCol.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.dateProductionCol.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.dateProductionCol.Caption = "Дата выпуска / прихода";
            this.dateProductionCol.FieldName = "DateProduction";
            this.dateProductionCol.Name = "dateProductionCol";
            this.dateProductionCol.OptionsColumn.AllowEdit = false;
            this.dateProductionCol.OptionsColumn.AllowFocus = false;
            this.dateProductionCol.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.dateProductionCol.Visible = true;
            // 
            // dateExpirationCol
            // 
            this.dateExpirationCol.AppearanceHeader.Options.UseTextOptions = true;
            this.dateExpirationCol.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.dateExpirationCol.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.dateExpirationCol.Caption = "Дата реализации";
            this.dateExpirationCol.FieldName = "DateExpiration";
            this.dateExpirationCol.Name = "dateExpirationCol";
            this.dateExpirationCol.OptionsColumn.AllowEdit = false;
            this.dateExpirationCol.OptionsColumn.AllowFocus = false;
            this.dateExpirationCol.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.dateExpirationCol.Visible = true;
            // 
            // quantityCol
            // 
            this.quantityCol.AppearanceHeader.Options.UseTextOptions = true;
            this.quantityCol.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.quantityCol.Caption = "Кол-во";
            this.quantityCol.FieldName = "Quantity";
            this.quantityCol.Name = "quantityCol";
            this.quantityCol.OptionsColumn.AllowEdit = false;
            this.quantityCol.OptionsColumn.AllowFocus = false;
            this.quantityCol.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.quantityCol.Visible = true;
            this.quantityCol.Width = 85;
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
            this.unitLocalNameCol.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.unitLocalNameCol.Visible = true;
            this.unitLocalNameCol.Width = 60;
            // 
            // gridBand2
            // 
            this.gridBand2.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gridBand2.AppearanceHeader.Options.UseFont = true;
            this.gridBand2.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand2.Caption = "Стоимость";
            this.gridBand2.Columns.Add(this.unitPriceCol);
            this.gridBand2.Columns.Add(this.totalPriceCol);
            this.gridBand2.Name = "gridBand2";
            this.gridBand2.VisibleIndex = 1;
            this.gridBand2.Width = 185;
            // 
            // unitPriceCol
            // 
            this.unitPriceCol.AppearanceHeader.Options.UseTextOptions = true;
            this.unitPriceCol.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.unitPriceCol.Caption = "Цена";
            this.unitPriceCol.FieldName = "UnitPrice";
            this.unitPriceCol.Name = "unitPriceCol";
            this.unitPriceCol.OptionsColumn.AllowEdit = false;
            this.unitPriceCol.OptionsColumn.AllowFocus = false;
            this.unitPriceCol.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.unitPriceCol.Visible = true;
            this.unitPriceCol.Width = 84;
            // 
            // totalPriceCol
            // 
            this.totalPriceCol.AppearanceHeader.Options.UseTextOptions = true;
            this.totalPriceCol.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.totalPriceCol.Caption = "Общая стоимость";
            this.totalPriceCol.FieldName = "TotalPrice";
            this.totalPriceCol.Name = "totalPriceCol";
            this.totalPriceCol.OptionsColumn.AllowEdit = false;
            this.totalPriceCol.OptionsColumn.AllowFocus = false;
            this.totalPriceCol.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.totalPriceCol.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalPrice", "Сумма={0:0.##}")});
            this.totalPriceCol.Visible = true;
            this.totalPriceCol.Width = 101;
            // 
            // gridView3
            // 
            this.gridView3.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn5,
            this.gridColumn6});
            this.gridView3.GridControl = this.receiptsGrid;
            this.gridView3.Name = "gridView3";
            this.gridView3.OptionsDetail.DetailMode = DevExpress.XtraGrid.Views.Grid.DetailMode.Default;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "gridColumn1";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 0;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "gridColumn2";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 1;
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
            this.addReceiptBtn,
            this.editReceiptBtn,
            this.deleteReceiptBtn});
            this.barManager1.MaxItemId = 21;
            // 
            // bar2
            // 
            this.bar2.BarName = "Custom 2";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Standalone;
            this.bar2.FloatLocation = new System.Drawing.Point(78, 182);
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.addReceiptBtn, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.editReceiptBtn, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.deleteReceiptBtn, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar2.OptionsBar.AllowQuickCustomization = false;
            this.bar2.OptionsBar.DrawDragBorder = false;
            this.bar2.StandaloneBarDockControl = this.standaloneBarDockControl1;
            this.bar2.Text = "Custom 2";
            // 
            // addReceiptBtn
            // 
            this.addReceiptBtn.Caption = "Добавить";
            this.addReceiptBtn.Glyph = global::TVM_WMS.GUI.Properties.Resources.Add;
            this.addReceiptBtn.Id = 6;
            this.addReceiptBtn.Name = "addReceiptBtn";
            this.addReceiptBtn.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.addReceiptBtn_ItemClick);
            // 
            // editReceiptBtn
            // 
            this.editReceiptBtn.Caption = "Редактировать";
            this.editReceiptBtn.Glyph = global::TVM_WMS.GUI.Properties.Resources.Edit;
            this.editReceiptBtn.Id = 7;
            this.editReceiptBtn.Name = "editReceiptBtn";
            this.editReceiptBtn.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.editReceiptBtn_ItemClick);
            // 
            // deleteReceiptBtn
            // 
            this.deleteReceiptBtn.Caption = "Удалить";
            this.deleteReceiptBtn.Glyph = global::TVM_WMS.GUI.Properties.Resources.Delete;
            this.deleteReceiptBtn.Id = 8;
            this.deleteReceiptBtn.Name = "deleteReceiptBtn";
            this.deleteReceiptBtn.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.deleteReceiptBtn_ItemClick);
            // 
            // standaloneBarDockControl1
            // 
            this.standaloneBarDockControl1.CausesValidation = false;
            this.standaloneBarDockControl1.Location = new System.Drawing.Point(2, 77);
            this.standaloneBarDockControl1.Name = "standaloneBarDockControl1";
            this.standaloneBarDockControl1.Size = new System.Drawing.Size(966, 29);
            this.standaloneBarDockControl1.Text = "standaloneBarDockControl1";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(1326, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 613);
            this.barDockControlBottom.Size = new System.Drawing.Size(1326, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 613);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1326, 0);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 613);
            // 
            // orderValidationProvider
            // 
            this.orderValidationProvider.ValidationMode = DevExpress.XtraEditors.DXErrorProvider.ValidationMode.Auto;
            this.orderValidationProvider.ValidationFailed += new DevExpress.XtraEditors.DXErrorProvider.ValidationFailedEventHandler(this.orderValidationProvider_ValidationFailed);
            this.orderValidationProvider.ValidationSucceeded += new DevExpress.XtraEditors.DXErrorProvider.ValidationSucceededEventHandler(this.orderValidationProvider_ValidationSucceeded);
            // 
            // contractorsGridEdit
            // 
            this.contractorsGridEdit.Location = new System.Drawing.Point(378, 43);
            this.contractorsGridEdit.Name = "contractorsGridEdit";
            this.contractorsGridEdit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.contractorsGridEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, ((System.Drawing.Image)(resources.GetObject("contractorsGridEdit.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "Добавить", null, null, true),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, ((System.Drawing.Image)(resources.GetObject("contractorsGridEdit.Properties.Buttons1"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "Корректировать", null, null, true),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3, "Справочник", null, null, true)});
            this.contractorsGridEdit.Properties.ImmediatePopup = true;
            this.contractorsGridEdit.Properties.PopupFormMinSize = new System.Drawing.Size(634, 250);
            this.contractorsGridEdit.Properties.PopupFormSize = new System.Drawing.Size(634, 250);
            this.contractorsGridEdit.Properties.PopupResizeMode = DevExpress.XtraEditors.Controls.ResizeMode.LiveResize;
            this.contractorsGridEdit.Properties.View = this.gridLookUpEdit1View;
            this.contractorsGridEdit.Size = new System.Drawing.Size(634, 22);
            this.contractorsGridEdit.TabIndex = 33;
            conditionValidationRule3.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.Greater;
            conditionValidationRule3.ErrorText = "Поле Поставщик обязательное для заполнения";
            conditionValidationRule3.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical;
            conditionValidationRule3.Value1 = "0";
            this.orderValidationProvider.SetValidationRule(this.contractorsGridEdit, conditionValidationRule3);
            this.contractorsGridEdit.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.contractorsGridEdit_ButtonClick);
            this.contractorsGridEdit.EditValueChanged += new System.EventHandler(this.contractorGridEdit_EditValueChanged);
            // 
            // gridLookUpEdit1View
            // 
            this.gridLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.nameContrCol,
            this.shortNameCol,
            this.srnCol,
            this.tinCol});
            this.gridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridLookUpEdit1View.Name = "gridLookUpEdit1View";
            this.gridLookUpEdit1View.OptionsDetail.DetailMode = DevExpress.XtraGrid.Views.Grid.DetailMode.Default;
            this.gridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridLookUpEdit1View.OptionsView.ShowAutoFilterRow = true;
            this.gridLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // nameContrCol
            // 
            this.nameContrCol.AppearanceHeader.Options.UseTextOptions = true;
            this.nameContrCol.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.nameContrCol.Caption = "Наименование";
            this.nameContrCol.FieldName = "Name";
            this.nameContrCol.Name = "nameContrCol";
            this.nameContrCol.OptionsColumn.AllowEdit = false;
            this.nameContrCol.OptionsColumn.AllowFocus = false;
            this.nameContrCol.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.nameContrCol.Visible = true;
            this.nameContrCol.VisibleIndex = 0;
            this.nameContrCol.Width = 487;
            // 
            // shortNameCol
            // 
            this.shortNameCol.AppearanceHeader.Options.UseTextOptions = true;
            this.shortNameCol.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.shortNameCol.Caption = "Краткое наим.";
            this.shortNameCol.FieldName = "ShortName";
            this.shortNameCol.Name = "shortNameCol";
            this.shortNameCol.OptionsColumn.AllowEdit = false;
            this.shortNameCol.OptionsColumn.AllowFocus = false;
            this.shortNameCol.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.shortNameCol.Visible = true;
            this.shortNameCol.VisibleIndex = 1;
            this.shortNameCol.Width = 138;
            // 
            // srnCol
            // 
            this.srnCol.AppearanceHeader.Options.UseTextOptions = true;
            this.srnCol.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.srnCol.Caption = "Код ОКПО";
            this.srnCol.FieldName = "Srn";
            this.srnCol.Name = "srnCol";
            this.srnCol.OptionsColumn.AllowEdit = false;
            this.srnCol.OptionsColumn.AllowFocus = false;
            this.srnCol.Visible = true;
            this.srnCol.VisibleIndex = 2;
            this.srnCol.Width = 141;
            // 
            // tinCol
            // 
            this.tinCol.AppearanceHeader.Options.UseTextOptions = true;
            this.tinCol.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.tinCol.Caption = "Инн";
            this.tinCol.FieldName = "Tin";
            this.tinCol.Name = "tinCol";
            this.tinCol.OptionsColumn.AllowEdit = false;
            this.tinCol.OptionsColumn.AllowFocus = false;
            this.tinCol.Visible = true;
            this.tinCol.VisibleIndex = 3;
            this.tinCol.Width = 146;
            // 
            // validateLbl
            // 
            this.validateLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.validateLbl.Appearance.BackColor = System.Drawing.SystemColors.Info;
            this.validateLbl.Appearance.ForeColor = System.Drawing.Color.OrangeRed;
            this.validateLbl.Location = new System.Drawing.Point(3, 579);
            this.validateLbl.Name = "validateLbl";
            this.validateLbl.Size = new System.Drawing.Size(263, 13);
            this.validateLbl.TabIndex = 32;
            this.validateLbl.Text = "*Для сохранения заполните все необходимые поля";
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.groupControl1.AppearanceCaption.Options.UseFont = true;
            this.groupControl1.Controls.Add(this.contractorsGridEdit);
            this.groupControl1.Controls.Add(this.orderNumberTBox);
            this.groupControl1.Controls.Add(this.orderDateTBox);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Location = new System.Drawing.Point(3, 2);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(1317, 75);
            this.groupControl1.TabIndex = 33;
            this.groupControl1.Text = "Документ";
            // 
            // OrderEditFm
            // 
            this.AcceptButton = this.saveBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(1326, 613);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.validateLbl);
            this.Controls.Add(this.standaloneBarDockControl1);
            this.Controls.Add(this.receiptsGrid);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(986, 564);
            this.Name = "OrderEditFm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Приходный документ";
            ((System.ComponentModel.ISupportInitialize)(this.orderNumberTBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderDateTBox.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderDateTBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.receiptsGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.receiptsGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderValidationProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.contractorsGridEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit orderNumberTBox;
        private DevExpress.XtraEditors.DateEdit orderDateTBox;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.SimpleButton saveBtn;
        private DevExpress.XtraEditors.SimpleButton cancelBtn;
        private DevExpress.XtraGrid.GridControl receiptsGrid;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridView receiptsGridView;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn articleCol;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn nameCol;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn quantityCol;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn unitLocalNameCol;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn unitPriceCol;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn totalPriceCol;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarButtonItem addReceiptBtn;
        private DevExpress.XtraBars.BarButtonItem editReceiptBtn;
        private DevExpress.XtraBars.BarButtonItem deleteReceiptBtn;
        private DevExpress.XtraBars.StandaloneBarDockControl standaloneBarDockControl1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand1;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn dateProductionCol;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn dateExpirationCol;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand2;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider orderValidationProvider;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.LabelControl validateLbl;
        private DevExpress.XtraEditors.GridLookUpEdit contractorsGridEdit;
        private DevExpress.XtraGrid.Views.Grid.GridView gridLookUpEdit1View;
        private DevExpress.XtraGrid.Columns.GridColumn shortNameCol;
        private DevExpress.XtraGrid.Columns.GridColumn nameContrCol;
        private DevExpress.XtraGrid.Columns.GridColumn srnCol;
        private DevExpress.XtraGrid.Columns.GridColumn tinCol;

    }
}