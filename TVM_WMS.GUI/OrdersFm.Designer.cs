namespace TVM_WMS.GUI
{
    partial class OrdersFm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrdersFm));
            this.orderGrid = new DevExpress.XtraGrid.GridControl();
            this.orderGridView = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridView();
            this.gridBand3 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.orderNumberCol = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.orderDataCol = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand4 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.contractorNameCol = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.srnCol = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.tinCol = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.statusCol = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
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
            this.gridBand5 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.statusReceiptCol = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.splashScreenManager = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::TVM_WMS.GUI.WaitForm1), true, true);
            this.defaultLookAndFeel1 = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.receiptsAcceptanceBtn = new DevExpress.XtraBars.BarButtonItem();
            this.cancelAcceptanceBtn = new DevExpress.XtraBars.BarButtonItem();
            this.addOrderBtn = new DevExpress.XtraBars.BarButtonItem();
            this.editOrderBtn = new DevExpress.XtraBars.BarButtonItem();
            this.deleteOrderBtn = new DevExpress.XtraBars.BarButtonItem();
            this.saveBtn = new DevExpress.XtraBars.BarButtonItem();
            this.beginDateEditItem = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemDateEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.endDateEditItem = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemDateEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.showItem = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ((System.ComponentModel.ISupportInitialize)(this.orderGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.receiptsGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.receiptsGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit2.CalendarTimeProperties)).BeginInit();
            this.SuspendLayout();
            // 
            // orderGrid
            // 
            this.orderGrid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.orderGrid.Location = new System.Drawing.Point(0, 92);
            this.orderGrid.MainView = this.orderGridView;
            this.orderGrid.Name = "orderGrid";
            this.orderGrid.ShowOnlyPredefinedDetails = true;
            this.orderGrid.Size = new System.Drawing.Size(1453, 284);
            this.orderGrid.TabIndex = 0;
            this.orderGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.orderGridView});
            this.orderGrid.DoubleClick += new System.EventHandler(this.orderGrid_DoubleClick);
            // 
            // orderGridView
            // 
            this.orderGridView.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBand3,
            this.gridBand4});
            this.orderGridView.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
            this.orderNumberCol,
            this.orderDataCol,
            this.contractorNameCol,
            this.srnCol,
            this.tinCol,
            this.statusCol});
            this.orderGridView.GridControl = this.orderGrid;
            this.orderGridView.Name = "orderGridView";
            this.orderGridView.OptionsDetail.DetailMode = DevExpress.XtraGrid.Views.Grid.DetailMode.Default;
            this.orderGridView.OptionsView.ShowAutoFilterRow = true;
            this.orderGridView.OptionsView.ShowGroupPanel = false;
            this.orderGridView.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.ordersGridView_FocusedRowChanged);
            this.orderGridView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.orderGridView_KeyDown);
            // 
            // gridBand3
            // 
            this.gridBand3.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gridBand3.AppearanceHeader.Options.UseFont = true;
            this.gridBand3.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand3.Caption = "Приход";
            this.gridBand3.Columns.Add(this.orderNumberCol);
            this.gridBand3.Columns.Add(this.orderDataCol);
            this.gridBand3.Name = "gridBand3";
            this.gridBand3.VisibleIndex = 0;
            this.gridBand3.Width = 289;
            // 
            // orderNumberCol
            // 
            this.orderNumberCol.AppearanceHeader.Options.UseTextOptions = true;
            this.orderNumberCol.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.orderNumberCol.Caption = "Номер документа";
            this.orderNumberCol.FieldName = "OrderNumber";
            this.orderNumberCol.Name = "orderNumberCol";
            this.orderNumberCol.OptionsColumn.AllowEdit = false;
            this.orderNumberCol.OptionsColumn.AllowFocus = false;
            this.orderNumberCol.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.orderNumberCol.Visible = true;
            this.orderNumberCol.Width = 174;
            // 
            // orderDataCol
            // 
            this.orderDataCol.AppearanceHeader.Options.UseTextOptions = true;
            this.orderDataCol.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.orderDataCol.Caption = "Дата документа";
            this.orderDataCol.FieldName = "OrderDate";
            this.orderDataCol.Name = "orderDataCol";
            this.orderDataCol.OptionsColumn.AllowEdit = false;
            this.orderDataCol.OptionsColumn.AllowFocus = false;
            this.orderDataCol.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.orderDataCol.Visible = true;
            this.orderDataCol.Width = 115;
            // 
            // gridBand4
            // 
            this.gridBand4.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gridBand4.AppearanceHeader.Options.UseFont = true;
            this.gridBand4.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand4.Caption = "Контрагент";
            this.gridBand4.Columns.Add(this.contractorNameCol);
            this.gridBand4.Columns.Add(this.srnCol);
            this.gridBand4.Columns.Add(this.tinCol);
            this.gridBand4.Columns.Add(this.statusCol);
            this.gridBand4.Name = "gridBand4";
            this.gridBand4.VisibleIndex = 1;
            this.gridBand4.Width = 1146;
            // 
            // contractorNameCol
            // 
            this.contractorNameCol.AppearanceHeader.Options.UseTextOptions = true;
            this.contractorNameCol.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.contractorNameCol.Caption = "Наименование предприятия";
            this.contractorNameCol.FieldName = "ContractorName";
            this.contractorNameCol.Name = "contractorNameCol";
            this.contractorNameCol.OptionsColumn.AllowEdit = false;
            this.contractorNameCol.OptionsColumn.AllowFocus = false;
            this.contractorNameCol.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.contractorNameCol.Visible = true;
            this.contractorNameCol.Width = 620;
            // 
            // srnCol
            // 
            this.srnCol.AppearanceHeader.Options.UseTextOptions = true;
            this.srnCol.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.srnCol.Caption = "Код по ОКПО";
            this.srnCol.FieldName = "Srn";
            this.srnCol.Name = "srnCol";
            this.srnCol.OptionsColumn.AllowEdit = false;
            this.srnCol.OptionsColumn.AllowFocus = false;
            this.srnCol.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.srnCol.Visible = true;
            this.srnCol.Width = 155;
            // 
            // tinCol
            // 
            this.tinCol.AppearanceHeader.Options.UseTextOptions = true;
            this.tinCol.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.tinCol.Caption = "Код по ИНН";
            this.tinCol.FieldName = "Tin";
            this.tinCol.Name = "tinCol";
            this.tinCol.OptionsColumn.AllowEdit = false;
            this.tinCol.OptionsColumn.AllowFocus = false;
            this.tinCol.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.tinCol.Visible = true;
            this.tinCol.Width = 160;
            // 
            // statusCol
            // 
            this.statusCol.AppearanceHeader.Options.UseTextOptions = true;
            this.statusCol.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.statusCol.Caption = "Статус";
            this.statusCol.FieldName = "StatusName";
            this.statusCol.Name = "statusCol";
            this.statusCol.OptionsColumn.AllowEdit = false;
            this.statusCol.OptionsColumn.AllowFocus = false;
            this.statusCol.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.statusCol.Visible = true;
            this.statusCol.Width = 211;
            // 
            // receiptsGrid
            // 
            this.receiptsGrid.AllowDrop = true;
            this.receiptsGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.receiptsGrid.Location = new System.Drawing.Point(0, 377);
            this.receiptsGrid.MainView = this.receiptsGridView;
            this.receiptsGrid.Name = "receiptsGrid";
            this.receiptsGrid.ShowOnlyPredefinedDetails = true;
            this.receiptsGrid.Size = new System.Drawing.Size(1454, 355);
            this.receiptsGrid.TabIndex = 1;
            this.receiptsGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.receiptsGridView});
            // 
            // receiptsGridView
            // 
            this.receiptsGridView.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBand1,
            this.gridBand2,
            this.gridBand5});
            this.receiptsGridView.ColumnPanelRowHeight = 40;
            this.receiptsGridView.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
            this.articleCol,
            this.nameCol,
            this.quantityCol,
            this.unitLocalNameCol,
            this.unitPriceCol,
            this.totalPriceCol,
            this.statusReceiptCol,
            this.dateProductionCol,
            this.dateExpirationCol});
            this.receiptsGridView.GridControl = this.receiptsGrid;
            this.receiptsGridView.Name = "receiptsGridView";
            this.receiptsGridView.OptionsDetail.DetailMode = DevExpress.XtraGrid.Views.Grid.DetailMode.Default;
            this.receiptsGridView.OptionsView.ShowAutoFilterRow = true;
            this.receiptsGridView.OptionsView.ShowFooter = true;
            this.receiptsGridView.OptionsView.ShowGroupPanel = false;
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
            this.gridBand1.Width = 871;
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
            this.articleCol.Visible = true;
            this.articleCol.Width = 130;
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
            this.nameCol.Width = 424;
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
            this.dateProductionCol.Width = 90;
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
            this.dateExpirationCol.Width = 88;
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
            this.quantityCol.Width = 79;
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
            this.gridBand2.Width = 245;
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
            this.unitPriceCol.Width = 107;
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
            this.totalPriceCol.Width = 138;
            // 
            // gridBand5
            // 
            this.gridBand5.Columns.Add(this.statusReceiptCol);
            this.gridBand5.Name = "gridBand5";
            this.gridBand5.VisibleIndex = 2;
            this.gridBand5.Width = 197;
            // 
            // statusReceiptCol
            // 
            this.statusReceiptCol.AppearanceHeader.Options.UseTextOptions = true;
            this.statusReceiptCol.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.statusReceiptCol.Caption = "Состояние";
            this.statusReceiptCol.FieldName = "StatusName";
            this.statusReceiptCol.Name = "statusReceiptCol";
            this.statusReceiptCol.OptionsColumn.AllowEdit = false;
            this.statusReceiptCol.OptionsColumn.AllowFocus = false;
            this.statusReceiptCol.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.statusReceiptCol.Visible = true;
            this.statusReceiptCol.Width = 197;
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
            // splashScreenManager
            // 
            this.splashScreenManager.ClosingDelay = 500;
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.receiptsAcceptanceBtn,
            this.cancelAcceptanceBtn,
            this.addOrderBtn,
            this.editOrderBtn,
            this.deleteOrderBtn,
            this.saveBtn,
            this.beginDateEditItem,
            this.endDateEditItem,
            this.showItem});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 21;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemDateEdit1,
            this.repositoryItemDateEdit2});
            this.ribbonControl1.ShowPageHeadersMode = DevExpress.XtraBars.Ribbon.ShowPageHeadersMode.Hide;
            this.ribbonControl1.Size = new System.Drawing.Size(1454, 95);
            this.ribbonControl1.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden;
            // 
            // receiptsAcceptanceBtn
            // 
            this.receiptsAcceptanceBtn.Caption = "Зона приемки";
            this.receiptsAcceptanceBtn.Glyph = ((System.Drawing.Image)(resources.GetObject("receiptsAcceptanceBtn.Glyph")));
            this.receiptsAcceptanceBtn.Id = 7;
            this.receiptsAcceptanceBtn.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("receiptsAcceptanceBtn.LargeGlyph")));
            this.receiptsAcceptanceBtn.Name = "receiptsAcceptanceBtn";
            this.receiptsAcceptanceBtn.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // cancelAcceptanceBtn
            // 
            this.cancelAcceptanceBtn.Caption = "Отменить принятие текущей номенклатуры";
            this.cancelAcceptanceBtn.Glyph = ((System.Drawing.Image)(resources.GetObject("cancelAcceptanceBtn.Glyph")));
            this.cancelAcceptanceBtn.Id = 12;
            this.cancelAcceptanceBtn.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("cancelAcceptanceBtn.LargeGlyph")));
            this.cancelAcceptanceBtn.Name = "cancelAcceptanceBtn";
            this.cancelAcceptanceBtn.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // addOrderBtn
            // 
            this.addOrderBtn.Caption = "Добавить";
            this.addOrderBtn.Glyph = ((System.Drawing.Image)(resources.GetObject("addOrderBtn.Glyph")));
            this.addOrderBtn.Id = 13;
            this.addOrderBtn.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("addOrderBtn.LargeGlyph")));
            this.addOrderBtn.Name = "addOrderBtn";
            this.addOrderBtn.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.addOrderBtn.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.addOrderBtn_ItemClick);
            // 
            // editOrderBtn
            // 
            this.editOrderBtn.Caption = "Редактировать";
            this.editOrderBtn.Glyph = ((System.Drawing.Image)(resources.GetObject("editOrderBtn.Glyph")));
            this.editOrderBtn.Id = 14;
            this.editOrderBtn.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("editOrderBtn.LargeGlyph")));
            this.editOrderBtn.Name = "editOrderBtn";
            this.editOrderBtn.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.editOrderBtn.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.editOrderBtn_ItemClick);
            // 
            // deleteOrderBtn
            // 
            this.deleteOrderBtn.Caption = "Удалить ";
            this.deleteOrderBtn.Glyph = ((System.Drawing.Image)(resources.GetObject("deleteOrderBtn.Glyph")));
            this.deleteOrderBtn.Id = 15;
            this.deleteOrderBtn.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("deleteOrderBtn.LargeGlyph")));
            this.deleteOrderBtn.Name = "deleteOrderBtn";
            this.deleteOrderBtn.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.deleteOrderBtn.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.deleteOrderBtn_ItemClick);
            // 
            // saveBtn
            // 
            this.saveBtn.Caption = "Принять отмеченные документы";
            this.saveBtn.Glyph = ((System.Drawing.Image)(resources.GetObject("saveBtn.Glyph")));
            this.saveBtn.Id = 16;
            this.saveBtn.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("saveBtn.LargeGlyph")));
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // beginDateEditItem
            // 
            this.beginDateEditItem.Caption = "Начальная дата";
            this.beginDateEditItem.CaptionAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.beginDateEditItem.Edit = this.repositoryItemDateEdit1;
            this.beginDateEditItem.EditWidth = 100;
            this.beginDateEditItem.Id = 17;
            this.beginDateEditItem.Name = "beginDateEditItem";
            // 
            // repositoryItemDateEdit1
            // 
            this.repositoryItemDateEdit1.AutoHeight = false;
            this.repositoryItemDateEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit1.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit1.Name = "repositoryItemDateEdit1";
            // 
            // endDateEditItem
            // 
            this.endDateEditItem.Caption = "Конечная дата";
            this.endDateEditItem.CaptionAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.endDateEditItem.Edit = this.repositoryItemDateEdit2;
            this.endDateEditItem.EditWidth = 100;
            this.endDateEditItem.Id = 18;
            this.endDateEditItem.Name = "endDateEditItem";
            // 
            // repositoryItemDateEdit2
            // 
            this.repositoryItemDateEdit2.AutoHeight = false;
            this.repositoryItemDateEdit2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit2.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit2.Name = "repositoryItemDateEdit2";
            // 
            // showItem
            // 
            this.showItem.Caption = "Показать";
            this.showItem.Glyph = ((System.Drawing.Image)(resources.GetObject("showItem.Glyph")));
            this.showItem.Id = 19;
            this.showItem.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("showItem.LargeGlyph")));
            this.showItem.Name = "showItem";
            this.showItem.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.showItem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.showItem_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup2,
            this.ribbonPageGroup3});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "ribbonPage1";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.AllowTextClipping = false;
            this.ribbonPageGroup2.ItemLinks.Add(this.beginDateEditItem);
            this.ribbonPageGroup2.ItemLinks.Add(this.endDateEditItem);
            this.ribbonPageGroup2.ItemLinks.Add(this.showItem);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.Text = "Фильтр";
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.AllowTextClipping = false;
            this.ribbonPageGroup3.ItemLinks.Add(this.addOrderBtn);
            this.ribbonPageGroup3.ItemLinks.Add(this.editOrderBtn);
            this.ribbonPageGroup3.ItemLinks.Add(this.deleteOrderBtn);
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            this.ribbonPageGroup3.ShowCaptionButton = false;
            this.ribbonPageGroup3.Text = "Документы";
            // 
            // OrdersFm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1454, 744);
            this.Controls.Add(this.ribbonControl1);
            this.Controls.Add(this.receiptsGrid);
            this.Controls.Add(this.orderGrid);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "OrdersFm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Документы-Приход";
            ((System.ComponentModel.ISupportInitialize)(this.orderGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.receiptsGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.receiptsGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit2.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl orderGrid;
        private DevExpress.XtraGrid.GridControl receiptsGrid;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridView receiptsGridView;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn nameCol;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn quantityCol;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn unitLocalNameCol;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn unitPriceCol;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn totalPriceCol;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridView orderGridView;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn orderNumberCol;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn orderDataCol;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn contractorNameCol;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn srnCol;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn tinCol;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn articleCol;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand3;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn statusCol;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand4;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn statusReceiptCol;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand1;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn dateProductionCol;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn dateExpirationCol;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand2;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand5;
        private DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager;
        private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel1;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.BarButtonItem receiptsAcceptanceBtn;
        private DevExpress.XtraBars.BarButtonItem cancelAcceptanceBtn;
        private DevExpress.XtraBars.BarButtonItem addOrderBtn;
        private DevExpress.XtraBars.BarButtonItem editOrderBtn;
        private DevExpress.XtraBars.BarButtonItem deleteOrderBtn;
        private DevExpress.XtraBars.BarButtonItem saveBtn;
        private DevExpress.XtraBars.BarEditItem beginDateEditItem;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit1;
        private DevExpress.XtraBars.BarEditItem endDateEditItem;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit2;
        private DevExpress.XtraBars.BarButtonItem showItem;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
    }
}