namespace TVM_WMS.GUI
{
    partial class DeficitMaterialsFm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DeficitMaterialsFm));
            DevExpress.Utils.SuperToolTip superToolTip2 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem3 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem2 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.ToolTipSeparatorItem toolTipSeparatorItem2 = new DevExpress.Utils.ToolTipSeparatorItem();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem4 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SuperToolTip superToolTip1 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem1 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem1 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.ToolTipSeparatorItem toolTipSeparatorItem1 = new DevExpress.Utils.ToolTipSeparatorItem();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem2 = new DevExpress.Utils.ToolTipTitleItem();
            this.deficitGrid = new DevExpress.XtraGrid.GridControl();
            this.deficitGridView = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridView();
            this.gridBand1 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.articleCol = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.nameCol = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.unitLocalNameCol = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand2 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.quantityForDeficitCol = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.quantityForKeepCol = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.quantityStoreCol = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand3 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.rateCol = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.stockDayQuantityCol = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.stockPersentCol = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.repositoryItemProgressBar1 = new DevExpress.XtraEditors.Repository.RepositoryItemProgressBar();
            this.repositoryItemProgressBar2 = new DevExpress.XtraEditors.Repository.RepositoryItemProgressBar();
            this.repositoryItemProgressBar3 = new DevExpress.XtraEditors.Repository.RepositoryItemProgressBar();
            this.splashScreenManager = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::TVM_WMS.GUI.WaitForm1), true, true);
            this.ribbonControl = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.addNormBtn = new DevExpress.XtraBars.BarButtonItem();
            this.printDeficitBtn = new DevExpress.XtraBars.BarButtonItem();
            this.dayEditItem = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemCalcButtonEdit = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.refreshDataBtn = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ((System.ComponentModel.ISupportInitialize)(this.deficitGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deficitGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemProgressBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemProgressBar2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemProgressBar3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCalcButtonEdit)).BeginInit();
            this.SuspendLayout();
            // 
            // deficitGrid
            // 
            this.deficitGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.deficitGrid.Location = new System.Drawing.Point(0, 92);
            this.deficitGrid.MainView = this.deficitGridView;
            this.deficitGrid.Name = "deficitGrid";
            this.deficitGrid.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemProgressBar1,
            this.repositoryItemProgressBar2,
            this.repositoryItemProgressBar3});
            this.deficitGrid.Size = new System.Drawing.Size(1301, 579);
            this.deficitGrid.TabIndex = 5;
            this.deficitGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.deficitGridView});
            this.deficitGrid.DoubleClick += new System.EventHandler(this.deficitGrid_DoubleClick);
            // 
            // deficitGridView
            // 
            this.deficitGridView.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBand1,
            this.gridBand2,
            this.gridBand3});
            this.deficitGridView.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
            this.articleCol,
            this.nameCol,
            this.quantityForDeficitCol,
            this.quantityForKeepCol,
            this.quantityStoreCol,
            this.unitLocalNameCol,
            this.stockDayQuantityCol,
            this.stockPersentCol,
            this.rateCol});
            this.deficitGridView.GridControl = this.deficitGrid;
            this.deficitGridView.Name = "deficitGridView";
            this.deficitGridView.OptionsDetail.DetailMode = DevExpress.XtraGrid.Views.Grid.DetailMode.Default;
            this.deficitGridView.OptionsView.ShowAutoFilterRow = true;
            this.deficitGridView.OptionsView.ShowGroupPanel = false;
            this.deficitGridView.CustomRowCellEdit += new DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventHandler(this.deficitGridView_CustomRowCellEdit);
            // 
            // gridBand1
            // 
            this.gridBand1.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand1.Caption = "Номенклатура";
            this.gridBand1.Columns.Add(this.articleCol);
            this.gridBand1.Columns.Add(this.nameCol);
            this.gridBand1.Columns.Add(this.unitLocalNameCol);
            this.gridBand1.Name = "gridBand1";
            this.gridBand1.VisibleIndex = 0;
            this.gridBand1.Width = 596;
            // 
            // articleCol
            // 
            this.articleCol.AppearanceHeader.Options.UseTextOptions = true;
            this.articleCol.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.articleCol.Caption = "Код ";
            this.articleCol.FieldName = "Article";
            this.articleCol.Name = "articleCol";
            this.articleCol.OptionsColumn.AllowEdit = false;
            this.articleCol.OptionsColumn.AllowFocus = false;
            this.articleCol.Visible = true;
            this.articleCol.Width = 63;
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
            this.nameCol.Width = 485;
            // 
            // unitLocalNameCol
            // 
            this.unitLocalNameCol.AppearanceHeader.Options.UseTextOptions = true;
            this.unitLocalNameCol.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.unitLocalNameCol.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.unitLocalNameCol.Caption = "Ед.изм.";
            this.unitLocalNameCol.FieldName = "UnitLocalName";
            this.unitLocalNameCol.Name = "unitLocalNameCol";
            this.unitLocalNameCol.OptionsColumn.AllowEdit = false;
            this.unitLocalNameCol.OptionsColumn.AllowFocus = false;
            this.unitLocalNameCol.Visible = true;
            this.unitLocalNameCol.Width = 48;
            // 
            // gridBand2
            // 
            this.gridBand2.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand2.Caption = "Количество";
            this.gridBand2.Columns.Add(this.quantityForDeficitCol);
            this.gridBand2.Columns.Add(this.quantityForKeepCol);
            this.gridBand2.Columns.Add(this.quantityStoreCol);
            this.gridBand2.Name = "gridBand2";
            this.gridBand2.VisibleIndex = 1;
            this.gridBand2.Width = 275;
            // 
            // quantityForDeficitCol
            // 
            this.quantityForDeficitCol.AppearanceHeader.Options.UseTextOptions = true;
            this.quantityForDeficitCol.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.quantityForDeficitCol.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.quantityForDeficitCol.Caption = "Всего ";
            this.quantityForDeficitCol.FieldName = "QuantityForDeficit";
            this.quantityForDeficitCol.Name = "quantityForDeficitCol";
            this.quantityForDeficitCol.OptionsColumn.AllowEdit = false;
            this.quantityForDeficitCol.OptionsColumn.AllowFocus = false;
            this.quantityForDeficitCol.Visible = true;
            this.quantityForDeficitCol.Width = 90;
            // 
            // quantityForKeepCol
            // 
            this.quantityForKeepCol.AppearanceHeader.Options.UseTextOptions = true;
            this.quantityForKeepCol.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.quantityForKeepCol.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.quantityForKeepCol.Caption = "Принято";
            this.quantityForKeepCol.FieldName = "QuantityForKeep";
            this.quantityForKeepCol.Name = "quantityForKeepCol";
            this.quantityForKeepCol.OptionsColumn.AllowEdit = false;
            this.quantityForKeepCol.OptionsColumn.AllowFocus = false;
            this.quantityForKeepCol.Visible = true;
            this.quantityForKeepCol.Width = 90;
            // 
            // quantityStoreCol
            // 
            this.quantityStoreCol.AppearanceHeader.Options.UseTextOptions = true;
            this.quantityStoreCol.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.quantityStoreCol.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.quantityStoreCol.Caption = "Хранение";
            this.quantityStoreCol.FieldName = "QuantityStore";
            this.quantityStoreCol.Name = "quantityStoreCol";
            this.quantityStoreCol.OptionsColumn.AllowEdit = false;
            this.quantityStoreCol.OptionsColumn.AllowFocus = false;
            this.quantityStoreCol.Visible = true;
            this.quantityStoreCol.Width = 95;
            // 
            // gridBand3
            // 
            this.gridBand3.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand3.Caption = "Обеспеченность";
            this.gridBand3.Columns.Add(this.rateCol);
            this.gridBand3.Columns.Add(this.stockDayQuantityCol);
            this.gridBand3.Columns.Add(this.stockPersentCol);
            this.gridBand3.Name = "gridBand3";
            this.gridBand3.VisibleIndex = 2;
            this.gridBand3.Width = 412;
            // 
            // rateCol
            // 
            this.rateCol.AppearanceHeader.Options.UseTextOptions = true;
            this.rateCol.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.rateCol.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.rateCol.Caption = "Норма";
            this.rateCol.FieldName = "Rate";
            this.rateCol.Name = "rateCol";
            this.rateCol.OptionsColumn.AllowEdit = false;
            this.rateCol.OptionsColumn.AllowFocus = false;
            this.rateCol.Visible = true;
            this.rateCol.Width = 70;
            // 
            // stockDayQuantityCol
            // 
            this.stockDayQuantityCol.AppearanceHeader.Options.UseTextOptions = true;
            this.stockDayQuantityCol.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.stockDayQuantityCol.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.stockDayQuantityCol.Caption = "Дни";
            this.stockDayQuantityCol.FieldName = "StockDayQuantity";
            this.stockDayQuantityCol.Name = "stockDayQuantityCol";
            this.stockDayQuantityCol.OptionsColumn.AllowEdit = false;
            this.stockDayQuantityCol.OptionsColumn.AllowFocus = false;
            this.stockDayQuantityCol.Visible = true;
            this.stockDayQuantityCol.Width = 50;
            // 
            // stockPersentCol
            // 
            this.stockPersentCol.AppearanceHeader.Options.UseTextOptions = true;
            this.stockPersentCol.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.stockPersentCol.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.stockPersentCol.Caption = "Загруженность,%";
            this.stockPersentCol.ColumnEdit = this.repositoryItemProgressBar1;
            this.stockPersentCol.FieldName = "StockPersent";
            this.stockPersentCol.Name = "stockPersentCol";
            this.stockPersentCol.OptionsColumn.AllowEdit = false;
            this.stockPersentCol.OptionsColumn.AllowFocus = false;
            this.stockPersentCol.Visible = true;
            this.stockPersentCol.Width = 292;
            // 
            // repositoryItemProgressBar1
            // 
            this.repositoryItemProgressBar1.Appearance.ForeColor = System.Drawing.Color.Black;
            this.repositoryItemProgressBar1.EndColor = System.Drawing.Color.Red;
            this.repositoryItemProgressBar1.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.repositoryItemProgressBar1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.repositoryItemProgressBar1.Name = "repositoryItemProgressBar1";
            this.repositoryItemProgressBar1.ProgressViewStyle = DevExpress.XtraEditors.Controls.ProgressViewStyle.Solid;
            this.repositoryItemProgressBar1.ShowTitle = true;
            this.repositoryItemProgressBar1.StartColor = System.Drawing.Color.Red;
            // 
            // repositoryItemProgressBar2
            // 
            this.repositoryItemProgressBar2.Appearance.ForeColor = System.Drawing.Color.Black;
            this.repositoryItemProgressBar2.EndColor = System.Drawing.Color.Yellow;
            this.repositoryItemProgressBar2.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.repositoryItemProgressBar2.LookAndFeel.UseDefaultLookAndFeel = false;
            this.repositoryItemProgressBar2.Name = "repositoryItemProgressBar2";
            this.repositoryItemProgressBar2.ProgressViewStyle = DevExpress.XtraEditors.Controls.ProgressViewStyle.Solid;
            this.repositoryItemProgressBar2.ShowTitle = true;
            this.repositoryItemProgressBar2.StartColor = System.Drawing.Color.Yellow;
            // 
            // repositoryItemProgressBar3
            // 
            this.repositoryItemProgressBar3.Appearance.ForeColor = System.Drawing.Color.Black;
            this.repositoryItemProgressBar3.EndColor = System.Drawing.Color.Green;
            this.repositoryItemProgressBar3.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.repositoryItemProgressBar3.LookAndFeel.UseDefaultLookAndFeel = false;
            this.repositoryItemProgressBar3.Name = "repositoryItemProgressBar3";
            this.repositoryItemProgressBar3.ProgressViewStyle = DevExpress.XtraEditors.Controls.ProgressViewStyle.Solid;
            this.repositoryItemProgressBar3.ShowTitle = true;
            this.repositoryItemProgressBar3.StartColor = System.Drawing.Color.PaleGreen;
            // 
            // splashScreenManager
            // 
            this.splashScreenManager.ClosingDelay = 500;
            // 
            // ribbonControl
            // 
            this.ribbonControl.ExpandCollapseItem.Id = 0;
            this.ribbonControl.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl.ExpandCollapseItem,
            this.addNormBtn,
            this.printDeficitBtn,
            this.dayEditItem,
            this.refreshDataBtn});
            this.ribbonControl.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl.MaxItemId = 19;
            this.ribbonControl.Name = "ribbonControl";
            this.ribbonControl.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCalcButtonEdit});
            this.ribbonControl.ShowPageHeadersMode = DevExpress.XtraBars.Ribbon.ShowPageHeadersMode.Hide;
            this.ribbonControl.Size = new System.Drawing.Size(1301, 95);
            this.ribbonControl.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden;
            // 
            // addNormBtn
            // 
            this.addNormBtn.Caption = "Ввести норму";
            this.addNormBtn.Glyph = ((System.Drawing.Image)(resources.GetObject("addNormBtn.Glyph")));
            this.addNormBtn.Id = 8;
            this.addNormBtn.Name = "addNormBtn";
            this.addNormBtn.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.addNormBtn.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.addNormBtn_ItemClick);
            // 
            // printDeficitBtn
            // 
            this.printDeficitBtn.Caption = "Печать";
            this.printDeficitBtn.Glyph = ((System.Drawing.Image)(resources.GetObject("printDeficitBtn.Glyph")));
            this.printDeficitBtn.Id = 10;
            this.printDeficitBtn.Name = "printDeficitBtn";
            this.printDeficitBtn.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.printDeficitBtn.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.printDeficitBtn_ItemClick);
            // 
            // dayEditItem
            // 
            this.dayEditItem.Caption = "Кол-во дней";
            this.dayEditItem.Edit = this.repositoryItemCalcButtonEdit;
            this.dayEditItem.EditHeight = 10;
            this.dayEditItem.EditWidth = 80;
            this.dayEditItem.Glyph = ((System.Drawing.Image)(resources.GetObject("dayEditItem.Glyph")));
            this.dayEditItem.Id = 17;
            this.dayEditItem.Name = "dayEditItem";
            toolTipTitleItem3.Text = "Информация";
            toolTipItem2.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image1")));
            toolTipItem2.Appearance.Options.UseImage = true;
            toolTipItem2.Image = ((System.Drawing.Image)(resources.GetObject("toolTipItem2.Image")));
            toolTipItem2.LeftIndent = 6;
            toolTipItem2.Text = "Укажите количество дней для расчета дефицита. И нажмите кнопку Расчитать. ";
            toolTipTitleItem4.LeftIndent = 6;
            toolTipTitleItem4.Text = "По умолчанию дефицит рассчитывается на 7 дней";
            superToolTip2.Items.Add(toolTipTitleItem3);
            superToolTip2.Items.Add(toolTipItem2);
            superToolTip2.Items.Add(toolTipSeparatorItem2);
            superToolTip2.Items.Add(toolTipTitleItem4);
            this.dayEditItem.SuperTip = superToolTip2;
            // 
            // repositoryItemCalcButtonEdit
            // 
            this.repositoryItemCalcButtonEdit.Appearance.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.repositoryItemCalcButtonEdit.Appearance.Options.UseFont = true;
            this.repositoryItemCalcButtonEdit.AutoHeight = false;
            toolTipTitleItem1.Text = "Информация";
            toolTipItem1.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image")));
            toolTipItem1.Appearance.Options.UseImage = true;
            toolTipItem1.Image = ((System.Drawing.Image)(resources.GetObject("toolTipItem1.Image")));
            toolTipItem1.LeftIndent = 6;
            toolTipItem1.Text = "Укажите количество дней для расчета дефицита. И нажмите кнопку Рассчитать. ";
            toolTipTitleItem2.LeftIndent = 6;
            toolTipTitleItem2.Text = "По умолчанию дефицит рассчитывается на 7 дней";
            superToolTip1.Items.Add(toolTipTitleItem1);
            superToolTip1.Items.Add(toolTipItem1);
            superToolTip1.Items.Add(toolTipSeparatorItem1);
            superToolTip1.Items.Add(toolTipTitleItem2);
            this.repositoryItemCalcButtonEdit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "Рассчитать", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, ((System.Drawing.Image)(resources.GetObject("repositoryItemCalcButtonEdit.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, superToolTip1, true)});
            this.repositoryItemCalcButtonEdit.Mask.EditMask = "n0";
            this.repositoryItemCalcButtonEdit.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.repositoryItemCalcButtonEdit.Name = "repositoryItemCalcButtonEdit";
            this.repositoryItemCalcButtonEdit.Click += new System.EventHandler(this.repositoryItemCalcButtonEdit_Click);
            // 
            // refreshDataBtn
            // 
            this.refreshDataBtn.Caption = "Обновить данные";
            this.refreshDataBtn.Glyph = ((System.Drawing.Image)(resources.GetObject("refreshDataBtn.Glyph")));
            this.refreshDataBtn.Id = 18;
            this.refreshDataBtn.Name = "refreshDataBtn";
            this.refreshDataBtn.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.refreshDataBtn.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.refreshDataBtn_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup3,
            this.ribbonPageGroup1});
            this.ribbonPage1.Name = "ribbonPage1";
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.ItemLinks.Add(this.addNormBtn);
            this.ribbonPageGroup3.ItemLinks.Add(this.printDeficitBtn);
            this.ribbonPageGroup3.ItemLinks.Add(this.refreshDataBtn);
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            this.ribbonPageGroup3.ShowCaptionButton = false;
            this.ribbonPageGroup3.Text = "Данные";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.dayEditItem);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "Расчет дефицита";
            // 
            // DeficitMaterialsFm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1301, 671);
            this.Controls.Add(this.ribbonControl);
            this.Controls.Add(this.deficitGrid);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DeficitMaterialsFm";
            this.Text = "Дефицит материалов";
            ((System.ComponentModel.ISupportInitialize)(this.deficitGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deficitGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemProgressBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemProgressBar2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemProgressBar3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCalcButtonEdit)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl deficitGrid;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridView deficitGridView;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn articleCol;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn nameCol;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn unitLocalNameCol;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn quantityForDeficitCol;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn quantityForKeepCol;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn quantityStoreCol;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn stockDayQuantityCol;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn stockPersentCol;
        private DevExpress.XtraEditors.Repository.RepositoryItemProgressBar repositoryItemProgressBar1;
        private DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand1;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand2;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand3;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn rateCol;
        private DevExpress.XtraEditors.Repository.RepositoryItemProgressBar repositoryItemProgressBar2;
        private DevExpress.XtraEditors.Repository.RepositoryItemProgressBar repositoryItemProgressBar3;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl;
        private DevExpress.XtraBars.BarButtonItem addNormBtn;
        private DevExpress.XtraBars.BarButtonItem printDeficitBtn;
        private DevExpress.XtraBars.BarEditItem dayEditItem;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemCalcButtonEdit;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private DevExpress.XtraBars.BarButtonItem refreshDataBtn;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
    }
}