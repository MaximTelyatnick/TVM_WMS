namespace TVM_WMS.GUI
{
    partial class MaterialsFm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MaterialsFm));
            this.materialsGrid = new DevExpress.XtraGrid.GridControl();
            this.materialsGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.articleCol = new DevExpress.XtraGrid.Columns.GridColumn();
            this.nameCol = new DevExpress.XtraGrid.Columns.GridColumn();
            this.descriptionCol = new DevExpress.XtraGrid.Columns.GridColumn();
            this.notesCol = new DevExpress.XtraGrid.Columns.GridColumn();
            this.storageGroupNameCol = new DevExpress.XtraGrid.Columns.GridColumn();
            this.materialGroupCol = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupsTree = new DevExpress.XtraTreeList.TreeList();
            this.codeTreeCol = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.nameTreeCol = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.groupControl = new DevExpress.XtraEditors.GroupControl();
            this.standaloneBarDockControl1 = new DevExpress.XtraBars.StandaloneBarDockControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.standaloneBarDockControl2 = new DevExpress.XtraBars.StandaloneBarDockControl();
            this.standaloneBarDockControl3 = new DevExpress.XtraBars.StandaloneBarDockControl();
            this.barManager2 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.addMaterial = new DevExpress.XtraBars.BarButtonItem();
            this.editMaterial = new DevExpress.XtraBars.BarButtonItem();
            this.deleteMaterial = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControl1 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl2 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl3 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl4 = new DevExpress.XtraBars.BarDockControl();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
            this.addGroupBtn = new DevExpress.XtraBars.BarButtonItem();
            this.editGroupBtn = new DevExpress.XtraBars.BarButtonItem();
            this.deleteGroupBtn = new DevExpress.XtraBars.BarButtonItem();
            this.addMaterialBtn = new DevExpress.XtraBars.BarButtonItem();
            this.editMaterialBtn = new DevExpress.XtraBars.BarButtonItem();
            this.deleteMaterialBtn = new DevExpress.XtraBars.BarButtonItem();
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.CheckItem = new DevExpress.XtraBars.BarCheckItem();
            this.treeListBtn = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.splashScreenManager = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::TVM_WMS.GUI.WaitForm1), true, true);
            ((System.ComponentModel.ISupportInitialize)(this.materialsGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.materialsGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupsTree)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl)).BeginInit();
            this.groupControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.barManager2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // materialsGrid
            // 
            this.materialsGrid.AllowDrop = true;
            this.materialsGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.materialsGrid.Location = new System.Drawing.Point(2, 49);
            this.materialsGrid.MainView = this.materialsGridView;
            this.materialsGrid.Name = "materialsGrid";
            this.materialsGrid.Size = new System.Drawing.Size(1049, 692);
            this.materialsGrid.TabIndex = 1;
            this.materialsGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.materialsGridView});
            // 
            // materialsGridView
            // 
            this.materialsGridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.articleCol,
            this.nameCol,
            this.descriptionCol,
            this.notesCol,
            this.storageGroupNameCol,
            this.materialGroupCol});
            this.materialsGridView.GridControl = this.materialsGrid;
            this.materialsGridView.Name = "materialsGridView";
            this.materialsGridView.OptionsDetail.DetailMode = DevExpress.XtraGrid.Views.Grid.DetailMode.Default;
            this.materialsGridView.OptionsFind.AllowFindPanel = false;
            this.materialsGridView.OptionsFind.AlwaysVisible = true;
            this.materialsGridView.OptionsView.ShowAutoFilterRow = true;
            this.materialsGridView.OptionsView.ShowFooter = true;
            this.materialsGridView.OptionsView.ShowGroupPanel = false;
            this.materialsGridView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.materialsGridView_KeyDown);
            this.materialsGridView.DoubleClick += new System.EventHandler(this.materialsGridView_DoubleClick);
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
            this.articleCol.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.articleCol.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "Article", "Всего = {0}")});
            this.articleCol.Visible = true;
            this.articleCol.VisibleIndex = 0;
            this.articleCol.Width = 69;
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
            this.nameCol.Width = 287;
            // 
            // descriptionCol
            // 
            this.descriptionCol.AppearanceHeader.Options.UseTextOptions = true;
            this.descriptionCol.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.descriptionCol.Caption = "Описание";
            this.descriptionCol.FieldName = "Description";
            this.descriptionCol.Name = "descriptionCol";
            this.descriptionCol.OptionsColumn.AllowEdit = false;
            this.descriptionCol.OptionsColumn.AllowFocus = false;
            this.descriptionCol.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.descriptionCol.Visible = true;
            this.descriptionCol.VisibleIndex = 2;
            this.descriptionCol.Width = 179;
            // 
            // notesCol
            // 
            this.notesCol.AppearanceHeader.Options.UseTextOptions = true;
            this.notesCol.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.notesCol.Caption = "Примечание";
            this.notesCol.FieldName = "Notes";
            this.notesCol.Name = "notesCol";
            this.notesCol.OptionsColumn.AllowEdit = false;
            this.notesCol.OptionsColumn.AllowFocus = false;
            this.notesCol.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.notesCol.Visible = true;
            this.notesCol.VisibleIndex = 3;
            this.notesCol.Width = 178;
            // 
            // storageGroupNameCol
            // 
            this.storageGroupNameCol.AppearanceHeader.Options.UseTextOptions = true;
            this.storageGroupNameCol.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.storageGroupNameCol.Caption = "Складская группа";
            this.storageGroupNameCol.FieldName = "StorageGroupName";
            this.storageGroupNameCol.Name = "storageGroupNameCol";
            this.storageGroupNameCol.OptionsColumn.AllowEdit = false;
            this.storageGroupNameCol.OptionsColumn.AllowFocus = false;
            this.storageGroupNameCol.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.storageGroupNameCol.Visible = true;
            this.storageGroupNameCol.VisibleIndex = 4;
            this.storageGroupNameCol.Width = 200;
            // 
            // materialGroupCol
            // 
            this.materialGroupCol.AppearanceHeader.Options.UseTextOptions = true;
            this.materialGroupCol.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.materialGroupCol.Caption = "Группа номенклатуры";
            this.materialGroupCol.FieldName = "GroupName";
            this.materialGroupCol.Name = "materialGroupCol";
            this.materialGroupCol.OptionsColumn.AllowEdit = false;
            this.materialGroupCol.OptionsColumn.AllowFocus = false;
            this.materialGroupCol.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.materialGroupCol.Visible = true;
            this.materialGroupCol.VisibleIndex = 5;
            this.materialGroupCol.Width = 118;
            // 
            // groupsTree
            // 
            this.groupsTree.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupsTree.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.codeTreeCol,
            this.nameTreeCol});
            this.groupsTree.ColumnsImageList = this.imageList1;
            this.groupsTree.Cursor = System.Windows.Forms.Cursors.Default;
            this.groupsTree.ImageIndexFieldName = "0";
            this.groupsTree.Location = new System.Drawing.Point(2, 49);
            this.groupsTree.Name = "groupsTree";
            this.groupsTree.OptionsBehavior.PopulateServiceColumns = true;
            this.groupsTree.SelectImageList = this.imageList1;
            this.groupsTree.Size = new System.Drawing.Size(427, 692);
            this.groupsTree.StateImageList = this.imageList1;
            this.groupsTree.TabIndex = 1;
            this.groupsTree.TreeLineStyle = DevExpress.XtraTreeList.LineStyle.Solid;
            this.groupsTree.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.groupsTree_FocusedNodeChanged);
            // 
            // codeTreeCol
            // 
            this.codeTreeCol.AppearanceHeader.Options.UseTextOptions = true;
            this.codeTreeCol.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.codeTreeCol.Caption = "Код";
            this.codeTreeCol.FieldName = "Code";
            this.codeTreeCol.MinWidth = 52;
            this.codeTreeCol.Name = "codeTreeCol";
            this.codeTreeCol.OptionsColumn.AllowEdit = false;
            this.codeTreeCol.OptionsColumn.AllowFocus = false;
            this.codeTreeCol.OptionsColumn.AllowSort = false;
            this.codeTreeCol.Visible = true;
            this.codeTreeCol.VisibleIndex = 0;
            this.codeTreeCol.Width = 108;
            // 
            // nameTreeCol
            // 
            this.nameTreeCol.AllNodesSummary = true;
            this.nameTreeCol.AppearanceHeader.Options.UseTextOptions = true;
            this.nameTreeCol.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.nameTreeCol.Caption = "Наименование";
            this.nameTreeCol.FieldName = "Name";
            this.nameTreeCol.Name = "nameTreeCol";
            this.nameTreeCol.OptionsColumn.AllowEdit = false;
            this.nameTreeCol.OptionsColumn.AllowFocus = false;
            this.nameTreeCol.OptionsColumn.AllowSort = false;
            this.nameTreeCol.Visible = true;
            this.nameTreeCol.VisibleIndex = 1;
            this.nameTreeCol.Width = 301;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "folder_32.png");
            this.imageList1.Images.SetKeyName(1, "gear_32.png");
            // 
            // groupControl
            // 
            this.groupControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupControl.AutoSize = true;
            this.groupControl.Controls.Add(this.groupsTree);
            this.groupControl.Controls.Add(this.standaloneBarDockControl1);
            this.groupControl.Location = new System.Drawing.Point(0, 1);
            this.groupControl.Name = "groupControl";
            this.groupControl.Size = new System.Drawing.Size(436, 764);
            this.groupControl.TabIndex = 2;
            this.groupControl.Text = "Группы";
            // 
            // standaloneBarDockControl1
            // 
            this.standaloneBarDockControl1.CausesValidation = false;
            this.standaloneBarDockControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.standaloneBarDockControl1.Location = new System.Drawing.Point(2, 20);
            this.standaloneBarDockControl1.Name = "standaloneBarDockControl1";
            this.standaloneBarDockControl1.Size = new System.Drawing.Size(432, 29);
            this.standaloneBarDockControl1.Text = "standaloneBarDockControl1";
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.groupControl1.Appearance.Options.UseBackColor = true;
            this.groupControl1.Controls.Add(this.materialsGrid);
            this.groupControl1.Controls.Add(this.standaloneBarDockControl2);
            this.groupControl1.Controls.Add(this.standaloneBarDockControl3);
            this.groupControl1.Location = new System.Drawing.Point(430, 1);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(1056, 775);
            this.groupControl1.TabIndex = 3;
            this.groupControl1.Text = "Номенклатура";
            // 
            // standaloneBarDockControl2
            // 
            this.standaloneBarDockControl2.CausesValidation = false;
            this.standaloneBarDockControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.standaloneBarDockControl2.Location = new System.Drawing.Point(2, 49);
            this.standaloneBarDockControl2.Name = "standaloneBarDockControl2";
            this.standaloneBarDockControl2.Size = new System.Drawing.Size(1052, 29);
            this.standaloneBarDockControl2.Text = "standaloneBarDockControl2";
            // 
            // standaloneBarDockControl3
            // 
            this.standaloneBarDockControl3.CausesValidation = false;
            this.standaloneBarDockControl3.Dock = System.Windows.Forms.DockStyle.Top;
            this.standaloneBarDockControl3.Location = new System.Drawing.Point(2, 20);
            this.standaloneBarDockControl3.Name = "standaloneBarDockControl3";
            this.standaloneBarDockControl3.Size = new System.Drawing.Size(1052, 29);
            this.standaloneBarDockControl3.Text = "standaloneBarDockControl3";
            // 
            // barManager2
            // 
            this.barManager2.AllowCustomization = false;
            this.barManager2.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar3});
            this.barManager2.DockControls.Add(this.barDockControl1);
            this.barManager2.DockControls.Add(this.barDockControl2);
            this.barManager2.DockControls.Add(this.barDockControl3);
            this.barManager2.DockControls.Add(this.barDockControl4);
            this.barManager2.DockControls.Add(this.standaloneBarDockControl2);
            this.barManager2.DockControls.Add(this.standaloneBarDockControl3);
            this.barManager2.DockControls.Add(this.standaloneBarDockControl1);
            this.barManager2.Form = this;
            this.barManager2.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barButtonItem1,
            this.barButtonItem2,
            this.barButtonItem3,
            this.addMaterial,
            this.editMaterial,
            this.deleteMaterial});
            this.barManager2.MaxItemId = 21;
            // 
            // bar3
            // 
            this.bar3.BarName = "Custom 3";
            this.bar3.DockCol = 0;
            this.bar3.DockRow = 0;
            this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Standalone;
            this.bar3.FloatLocation = new System.Drawing.Point(369, 197);
            this.bar3.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.addMaterial, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.editMaterial, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.deleteMaterial, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar3.OptionsBar.AllowQuickCustomization = false;
            this.bar3.OptionsBar.DrawDragBorder = false;
            this.bar3.StandaloneBarDockControl = this.standaloneBarDockControl3;
            this.bar3.Text = "Custom 3";
            // 
            // addMaterial
            // 
            this.addMaterial.Caption = "Добавить";
            this.addMaterial.Glyph = ((System.Drawing.Image)(resources.GetObject("addMaterial.Glyph")));
            this.addMaterial.Id = 9;
            this.addMaterial.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("addMaterial.LargeGlyph")));
            this.addMaterial.Name = "addMaterial";
            this.addMaterial.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.addMaterial_ItemClick);
            // 
            // editMaterial
            // 
            this.editMaterial.Caption = "Редактировать";
            this.editMaterial.Glyph = ((System.Drawing.Image)(resources.GetObject("editMaterial.Glyph")));
            this.editMaterial.Id = 10;
            this.editMaterial.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("editMaterial.LargeGlyph")));
            this.editMaterial.Name = "editMaterial";
            this.editMaterial.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.editMaterial_ItemClick);
            // 
            // deleteMaterial
            // 
            this.deleteMaterial.Caption = "Удалить";
            this.deleteMaterial.Glyph = ((System.Drawing.Image)(resources.GetObject("deleteMaterial.Glyph")));
            this.deleteMaterial.Id = 11;
            this.deleteMaterial.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("deleteMaterial.LargeGlyph")));
            this.deleteMaterial.Name = "deleteMaterial";
            this.deleteMaterial.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.deleteMaterial_ItemClick);
            // 
            // barDockControl1
            // 
            this.barDockControl1.CausesValidation = false;
            this.barDockControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControl1.Location = new System.Drawing.Point(0, 0);
            this.barDockControl1.Size = new System.Drawing.Size(1485, 0);
            // 
            // barDockControl2
            // 
            this.barDockControl2.CausesValidation = false;
            this.barDockControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControl2.Location = new System.Drawing.Point(0, 744);
            this.barDockControl2.Size = new System.Drawing.Size(1485, 0);
            // 
            // barDockControl3
            // 
            this.barDockControl3.CausesValidation = false;
            this.barDockControl3.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControl3.Location = new System.Drawing.Point(0, 0);
            this.barDockControl3.Size = new System.Drawing.Size(0, 744);
            // 
            // barDockControl4
            // 
            this.barDockControl4.CausesValidation = false;
            this.barDockControl4.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControl4.Location = new System.Drawing.Point(1485, 0);
            this.barDockControl4.Size = new System.Drawing.Size(0, 744);
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Id = 18;
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Id = 19;
            this.barButtonItem2.Name = "barButtonItem2";
            // 
            // barButtonItem3
            // 
            this.barButtonItem3.Id = 20;
            this.barButtonItem3.Name = "barButtonItem3";
            // 
            // addGroupBtn
            // 
            this.addGroupBtn.Caption = "Добавить";
            this.addGroupBtn.Glyph = ((System.Drawing.Image)(resources.GetObject("addGroupBtn.Glyph")));
            this.addGroupBtn.Id = 6;
            this.addGroupBtn.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("addGroupBtn.LargeGlyph")));
            this.addGroupBtn.Name = "addGroupBtn";
            this.addGroupBtn.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.addGroupBtn_ItemClick);
            // 
            // editGroupBtn
            // 
            this.editGroupBtn.Caption = "Редактировать";
            this.editGroupBtn.Glyph = ((System.Drawing.Image)(resources.GetObject("editGroupBtn.Glyph")));
            this.editGroupBtn.Id = 7;
            this.editGroupBtn.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("editGroupBtn.LargeGlyph")));
            this.editGroupBtn.Name = "editGroupBtn";
            this.editGroupBtn.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.editGroupBtn_ItemClick);
            // 
            // deleteGroupBtn
            // 
            this.deleteGroupBtn.Caption = "Удалить";
            this.deleteGroupBtn.Glyph = ((System.Drawing.Image)(resources.GetObject("deleteGroupBtn.Glyph")));
            this.deleteGroupBtn.Id = 8;
            this.deleteGroupBtn.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("deleteGroupBtn.LargeGlyph")));
            this.deleteGroupBtn.Name = "deleteGroupBtn";
            this.deleteGroupBtn.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.deleteGroupBtn_ItemClick);
            // 
            // addMaterialBtn
            // 
            this.addMaterialBtn.Id = 18;
            this.addMaterialBtn.Name = "addMaterialBtn";
            // 
            // editMaterialBtn
            // 
            this.editMaterialBtn.Id = 19;
            this.editMaterialBtn.Name = "editMaterialBtn";
            // 
            // deleteMaterialBtn
            // 
            this.deleteMaterialBtn.Id = 20;
            this.deleteMaterialBtn.Name = "deleteMaterialBtn";
            // 
            // bar1
            // 
            this.bar1.BarName = "Custom 2";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Standalone;
            this.bar1.FloatLocation = new System.Drawing.Point(78, 182);
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.addGroupBtn, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.editGroupBtn, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.deleteGroupBtn, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.CheckItem, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar1.OptionsBar.AllowQuickCustomization = false;
            this.bar1.OptionsBar.DrawDragBorder = false;
            this.bar1.StandaloneBarDockControl = this.standaloneBarDockControl1;
            this.bar1.Text = "Custom 2";
            // 
            // CheckItem
            // 
            this.CheckItem.Caption = "Развернуть";
            this.CheckItem.Glyph = ((System.Drawing.Image)(resources.GetObject("CheckItem.Glyph")));
            this.CheckItem.Id = 22;
            this.CheckItem.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("CheckItem.LargeGlyph")));
            this.CheckItem.Name = "CheckItem";
            this.CheckItem.CheckedChanged += new DevExpress.XtraBars.ItemClickEventHandler(this.CheckItem_CheckedChanged);
            // 
            // treeListBtn
            // 
            this.treeListBtn.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            this.treeListBtn.Caption = "Развернуть";
            this.treeListBtn.Glyph = global::TVM_WMS.GUI.Properties.Resources.view_tree;
            this.treeListBtn.Id = 21;
            this.treeListBtn.Name = "treeListBtn";
            this.treeListBtn.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.treeListBtn_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(1485, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 744);
            this.barDockControlBottom.Size = new System.Drawing.Size(1485, 0);
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
            this.barDockControlRight.Location = new System.Drawing.Point(1485, 0);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 744);
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
            this.barManager1.DockControls.Add(this.standaloneBarDockControl2);
            this.barManager1.DockControls.Add(this.standaloneBarDockControl3);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.addGroupBtn,
            this.editGroupBtn,
            this.deleteGroupBtn,
            this.addMaterialBtn,
            this.editMaterialBtn,
            this.deleteMaterialBtn,
            this.treeListBtn,
            this.CheckItem});
            this.barManager1.MaxItemId = 23;
            // 
            // splashScreenManager
            // 
            this.splashScreenManager.ClosingDelay = 500;
            // 
            // MaterialsFm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1485, 744);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.groupControl);
            this.Controls.Add(this.barDockControl3);
            this.Controls.Add(this.barDockControl4);
            this.Controls.Add(this.barDockControl2);
            this.Controls.Add(this.barDockControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MaterialsFm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Номенклатура";
            ((System.ComponentModel.ISupportInitialize)(this.materialsGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.materialsGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupsTree)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl)).EndInit();
            this.groupControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.barManager2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl materialsGrid;
        private DevExpress.XtraTreeList.TreeList groupsTree;
        private DevExpress.XtraEditors.GroupControl groupControl;
        private DevExpress.XtraBars.StandaloneBarDockControl standaloneBarDockControl1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraBars.StandaloneBarDockControl standaloneBarDockControl2;
        private DevExpress.XtraBars.StandaloneBarDockControl standaloneBarDockControl3;
        private DevExpress.XtraBars.BarDockControl barDockControl3;
        private DevExpress.XtraBars.BarDockControl barDockControl4;
        private DevExpress.XtraBars.BarDockControl barDockControl2;
        private DevExpress.XtraBars.BarDockControl barDockControl1;
        private DevExpress.XtraBars.BarManager barManager2;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarButtonItem addMaterial;
        private DevExpress.XtraBars.BarButtonItem editMaterial;
        private DevExpress.XtraBars.BarButtonItem deleteMaterial;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.BarButtonItem barButtonItem3;
        private DevExpress.XtraTreeList.Columns.TreeListColumn codeTreeCol;
        private DevExpress.XtraTreeList.Columns.TreeListColumn nameTreeCol;
        private System.Windows.Forms.ImageList imageList1;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarButtonItem addGroupBtn;
        private DevExpress.XtraBars.BarButtonItem editGroupBtn;
        private DevExpress.XtraBars.BarButtonItem deleteGroupBtn;
        private DevExpress.XtraBars.BarButtonItem addMaterialBtn;
        private DevExpress.XtraBars.BarButtonItem editMaterialBtn;
        private DevExpress.XtraBars.BarButtonItem deleteMaterialBtn;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraGrid.Views.Grid.GridView materialsGridView;
        private DevExpress.XtraGrid.Columns.GridColumn articleCol;
        private DevExpress.XtraGrid.Columns.GridColumn nameCol;
        private DevExpress.XtraGrid.Columns.GridColumn descriptionCol;
        private DevExpress.XtraGrid.Columns.GridColumn notesCol;
        private DevExpress.XtraGrid.Columns.GridColumn storageGroupNameCol;
        private DevExpress.XtraBars.BarButtonItem treeListBtn;
        private DevExpress.XtraBars.BarCheckItem CheckItem;
        private DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager;
        private DevExpress.XtraGrid.Columns.GridColumn materialGroupCol;

    }
}