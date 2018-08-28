namespace TVM_WMS.GUI
{
    partial class RequirementOrderEditFm
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
            this.standaloneBarDockControl1 = new DevExpress.XtraBars.StandaloneBarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.deleteRequirementMaterialBtn = new DevExpress.XtraBars.BarButtonItem();
            this.editRequirementMaterialBtn = new DevExpress.XtraBars.BarButtonItem();
            this.addRequirementMaterialBtn = new DevExpress.XtraBars.BarButtonItem();
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.requirementMaterialsGrid = new DevExpress.XtraGrid.GridControl();
            this.requirementMaterialsGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.articleCol = new DevExpress.XtraGrid.Columns.GridColumn();
            this.nameCol = new DevExpress.XtraGrid.Columns.GridColumn();
            this.requiredQuantityCol = new DevExpress.XtraGrid.Columns.GridColumn();
            this.unitLocalNameCol = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cancelBtn = new DevExpress.XtraEditors.SimpleButton();
            this.saveBtn = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.responsiblePersonEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.requirementDateTBox = new DevExpress.XtraEditors.DateEdit();
            this.requirementNumberTBox = new DevExpress.XtraEditors.TextEdit();
            this.storeQuantityCol = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.requirementMaterialsGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.requirementMaterialsGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.responsiblePersonEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.requirementDateTBox.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.requirementDateTBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.requirementNumberTBox.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // standaloneBarDockControl1
            // 
            this.standaloneBarDockControl1.CausesValidation = false;
            this.standaloneBarDockControl1.Location = new System.Drawing.Point(-3, 71);
            this.standaloneBarDockControl1.Name = "standaloneBarDockControl1";
            this.standaloneBarDockControl1.Size = new System.Drawing.Size(1197, 29);
            this.standaloneBarDockControl1.Text = "standaloneBarDockControl1";
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1197, 0);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 615);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 615);
            this.barDockControlBottom.Size = new System.Drawing.Size(1197, 0);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(1197, 0);
            // 
            // deleteRequirementMaterialBtn
            // 
            this.deleteRequirementMaterialBtn.Caption = "Удалить";
            this.deleteRequirementMaterialBtn.Glyph = global::TVM_WMS.GUI.Properties.Resources.Delete;
            this.deleteRequirementMaterialBtn.Id = 8;
            this.deleteRequirementMaterialBtn.Name = "deleteRequirementMaterialBtn";
            this.deleteRequirementMaterialBtn.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.deleteRequirementMaterialBtn_ItemClick);
            // 
            // editRequirementMaterialBtn
            // 
            this.editRequirementMaterialBtn.Caption = "Редактировать";
            this.editRequirementMaterialBtn.Glyph = global::TVM_WMS.GUI.Properties.Resources.Edit;
            this.editRequirementMaterialBtn.Id = 7;
            this.editRequirementMaterialBtn.Name = "editRequirementMaterialBtn";
            // 
            // addRequirementMaterialBtn
            // 
            this.addRequirementMaterialBtn.Caption = "Добавить";
            this.addRequirementMaterialBtn.Glyph = global::TVM_WMS.GUI.Properties.Resources.Add;
            this.addRequirementMaterialBtn.Id = 6;
            this.addRequirementMaterialBtn.Name = "addRequirementMaterialBtn";
            this.addRequirementMaterialBtn.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.addRequirementMaterialBtn_ItemClick);
            // 
            // bar2
            // 
            this.bar2.BarName = "Custom 2";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Standalone;
            this.bar2.FloatLocation = new System.Drawing.Point(78, 182);
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.addRequirementMaterialBtn, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.deleteRequirementMaterialBtn, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar2.OptionsBar.AllowQuickCustomization = false;
            this.bar2.OptionsBar.DrawDragBorder = false;
            this.bar2.StandaloneBarDockControl = this.standaloneBarDockControl1;
            this.bar2.Text = "Custom 2";
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
            this.addRequirementMaterialBtn,
            this.editRequirementMaterialBtn,
            this.deleteRequirementMaterialBtn});
            this.barManager1.MaxItemId = 21;
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 615);
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "gridColumn2";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 1;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "gridColumn1";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 0;
            // 
            // gridView3
            // 
            this.gridView3.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn5,
            this.gridColumn6});
            this.gridView3.GridControl = this.requirementMaterialsGrid;
            this.gridView3.Name = "gridView3";
            this.gridView3.OptionsDetail.DetailMode = DevExpress.XtraGrid.Views.Grid.DetailMode.Default;
            // 
            // requirementMaterialsGrid
            // 
            this.requirementMaterialsGrid.AllowDrop = true;
            this.requirementMaterialsGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.requirementMaterialsGrid.Location = new System.Drawing.Point(-3, 101);
            this.requirementMaterialsGrid.MainView = this.requirementMaterialsGridView;
            this.requirementMaterialsGrid.Name = "requirementMaterialsGrid";
            this.requirementMaterialsGrid.ShowOnlyPredefinedDetails = true;
            this.requirementMaterialsGrid.Size = new System.Drawing.Size(1197, 468);
            this.requirementMaterialsGrid.TabIndex = 19;
            this.requirementMaterialsGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.requirementMaterialsGridView,
            this.gridView3});
            // 
            // requirementMaterialsGridView
            // 
            this.requirementMaterialsGridView.ColumnPanelRowHeight = 40;
            this.requirementMaterialsGridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.articleCol,
            this.nameCol,
            this.storeQuantityCol,
            this.requiredQuantityCol,
            this.unitLocalNameCol});
            this.requirementMaterialsGridView.GridControl = this.requirementMaterialsGrid;
            this.requirementMaterialsGridView.Name = "requirementMaterialsGridView";
            this.requirementMaterialsGridView.OptionsDetail.DetailMode = DevExpress.XtraGrid.Views.Grid.DetailMode.Default;
            this.requirementMaterialsGridView.OptionsView.ShowAutoFilterRow = true;
            this.requirementMaterialsGridView.OptionsView.ShowFooter = true;
            this.requirementMaterialsGridView.OptionsView.ShowGroupPanel = false;
            this.requirementMaterialsGridView.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.requirementMaterialsGridView_CellValueChanged);
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
            this.nameCol.VisibleIndex = 1;
            this.nameCol.Width = 499;
            // 
            // requiredQuantityCol
            // 
            this.requiredQuantityCol.AppearanceCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.requiredQuantityCol.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 10F);
            this.requiredQuantityCol.AppearanceCell.ForeColor = System.Drawing.Color.Maroon;
            this.requiredQuantityCol.AppearanceCell.Options.UseBackColor = true;
            this.requiredQuantityCol.AppearanceCell.Options.UseFont = true;
            this.requiredQuantityCol.AppearanceCell.Options.UseForeColor = true;
            this.requiredQuantityCol.AppearanceHeader.Options.UseTextOptions = true;
            this.requiredQuantityCol.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.requiredQuantityCol.Caption = "Кол-во к выдаче";
            this.requiredQuantityCol.FieldName = "RequiredQuantity";
            this.requiredQuantityCol.Name = "requiredQuantityCol";
            this.requiredQuantityCol.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.requiredQuantityCol.Visible = true;
            this.requiredQuantityCol.VisibleIndex = 3;
            this.requiredQuantityCol.Width = 85;
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
            this.unitLocalNameCol.VisibleIndex = 4;
            this.unitLocalNameCol.Width = 60;
            // 
            // cancelBtn
            // 
            this.cancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelBtn.Location = new System.Drawing.Point(1102, 575);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(83, 28);
            this.cancelBtn.TabIndex = 18;
            this.cancelBtn.Text = "Отмена";
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // saveBtn
            // 
            this.saveBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.saveBtn.Location = new System.Drawing.Point(1001, 575);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(83, 28);
            this.saveBtn.TabIndex = 17;
            this.saveBtn.Text = "Сохранить";
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(397, 6);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(106, 13);
            this.labelControl3.TabIndex = 16;
            this.labelControl3.Text = "Ответственное лицо";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(234, 6);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(84, 13);
            this.labelControl2.TabIndex = 15;
            this.labelControl2.Text = "Дата документа";
            // 
            // responsiblePersonEdit
            // 
            this.responsiblePersonEdit.Location = new System.Drawing.Point(397, 31);
            this.responsiblePersonEdit.Name = "responsiblePersonEdit";
            this.responsiblePersonEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.responsiblePersonEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Наименование"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ShortName", "Краткое наименование")});
            this.responsiblePersonEdit.Size = new System.Drawing.Size(507, 20);
            this.responsiblePersonEdit.TabIndex = 13;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(7, 6);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(89, 13);
            this.labelControl1.TabIndex = 12;
            this.labelControl1.Text = "Номер документа";
            // 
            // requirementDateTBox
            // 
            this.requirementDateTBox.EditValue = null;
            this.requirementDateTBox.Location = new System.Drawing.Point(234, 31);
            this.requirementDateTBox.Name = "requirementDateTBox";
            this.requirementDateTBox.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.requirementDateTBox.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.requirementDateTBox.Size = new System.Drawing.Size(146, 20);
            this.requirementDateTBox.TabIndex = 11;
            // 
            // requirementNumberTBox
            // 
            this.requirementNumberTBox.Location = new System.Drawing.Point(7, 31);
            this.requirementNumberTBox.Name = "requirementNumberTBox";
            this.requirementNumberTBox.Size = new System.Drawing.Size(207, 20);
            this.requirementNumberTBox.TabIndex = 10;
            // 
            // storeQuantityCol
            // 
            this.storeQuantityCol.AppearanceHeader.Options.UseTextOptions = true;
            this.storeQuantityCol.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.storeQuantityCol.Caption = "Доступно";
            this.storeQuantityCol.FieldName = "StoreQuantity";
            this.storeQuantityCol.Name = "storeQuantityCol";
            this.storeQuantityCol.OptionsColumn.AllowEdit = false;
            this.storeQuantityCol.OptionsColumn.AllowFocus = false;
            this.storeQuantityCol.Visible = true;
            this.storeQuantityCol.VisibleIndex = 2;
            // 
            // RequirementOrderEditFm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1197, 615);
            this.Controls.Add(this.standaloneBarDockControl1);
            this.Controls.Add(this.requirementMaterialsGrid);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.responsiblePersonEdit);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.requirementDateTBox);
            this.Controls.Add(this.requirementNumberTBox);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "RequirementOrderEditFm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Новый расходный документ";
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.requirementMaterialsGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.requirementMaterialsGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.responsiblePersonEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.requirementDateTBox.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.requirementDateTBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.requirementNumberTBox.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.StandaloneBarDockControl standaloneBarDockControl1;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarButtonItem deleteRequirementMaterialBtn;
        private DevExpress.XtraBars.BarButtonItem editRequirementMaterialBtn;
        private DevExpress.XtraBars.BarButtonItem addRequirementMaterialBtn;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraGrid.GridControl requirementMaterialsGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraEditors.SimpleButton cancelBtn;
        private DevExpress.XtraEditors.SimpleButton saveBtn;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LookUpEdit responsiblePersonEdit;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.DateEdit requirementDateTBox;
        private DevExpress.XtraEditors.TextEdit requirementNumberTBox;
        private DevExpress.XtraGrid.Views.Grid.GridView requirementMaterialsGridView;
        private DevExpress.XtraGrid.Columns.GridColumn articleCol;
        private DevExpress.XtraGrid.Columns.GridColumn nameCol;
        private DevExpress.XtraGrid.Columns.GridColumn requiredQuantityCol;
        private DevExpress.XtraGrid.Columns.GridColumn unitLocalNameCol;
        private DevExpress.XtraGrid.Columns.GridColumn storeQuantityCol;
    }
}