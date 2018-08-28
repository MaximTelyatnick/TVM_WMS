namespace TVM_WMS.GUI
{
    partial class StorageGroupsByZonesFm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StorageGroupsByZonesFm));
            this.storageGroupsByZoneGrid = new DevExpress.XtraGrid.GridControl();
            this.storageGroupsByZonesgridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.zoneNameCol = new DevExpress.XtraGrid.Columns.GridColumn();
            this.zoneColorCol = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemColorPickEdit = new DevExpress.XtraEditors.Repository.RepositoryItemColorPickEdit();
            this.storageGroupNameCol = new DevExpress.XtraGrid.Columns.GridColumn();
            this.descriptionCol = new DevExpress.XtraGrid.Columns.GridColumn();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.colorPickEdit = new DevExpress.XtraEditors.ColorPickEdit();
            this.checkGroupAll = new DevExpress.XtraEditors.CheckEdit();
            this.storageGroupGrid = new DevExpress.XtraGrid.GridControl();
            this.storageGroupGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.checkCol = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheck = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.storageGroupNameColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.descriptionColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemButtonEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.addBtn = new DevExpress.XtraEditors.SimpleButton();
            this.zoneNameGridLookUpEdit = new DevExpress.XtraEditors.GridLookUpEdit();
            this.repositoryItemColorPickEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemColorPickEdit();
            this.gridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.zoneNameColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.zoneColorColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.deleteBtn = new DevExpress.XtraEditors.SimpleButton();
            this.SaveBtn = new DevExpress.XtraEditors.SimpleButton();
            this.cancelBtn = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.storageGroupsByZoneGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.storageGroupsByZonesgridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemColorPickEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorPickEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkGroupAll.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.storageGroupGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.storageGroupGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheck)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zoneNameGridLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemColorPickEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).BeginInit();
            this.SuspendLayout();
            // 
            // storageGroupsByZoneGrid
            // 
            this.storageGroupsByZoneGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.storageGroupsByZoneGrid.Location = new System.Drawing.Point(715, 2);
            this.storageGroupsByZoneGrid.MainView = this.storageGroupsByZonesgridView;
            this.storageGroupsByZoneGrid.Name = "storageGroupsByZoneGrid";
            this.storageGroupsByZoneGrid.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemColorPickEdit});
            this.storageGroupsByZoneGrid.Size = new System.Drawing.Size(738, 695);
            this.storageGroupsByZoneGrid.TabIndex = 5;
            this.storageGroupsByZoneGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.storageGroupsByZonesgridView});
            // 
            // storageGroupsByZonesgridView
            // 
            this.storageGroupsByZonesgridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.zoneNameCol,
            this.zoneColorCol,
            this.storageGroupNameCol,
            this.descriptionCol});
            this.storageGroupsByZonesgridView.GridControl = this.storageGroupsByZoneGrid;
            this.storageGroupsByZonesgridView.GroupCount = 1;
            this.storageGroupsByZonesgridView.Name = "storageGroupsByZonesgridView";
            this.storageGroupsByZonesgridView.OptionsBehavior.AutoExpandAllGroups = true;
            this.storageGroupsByZonesgridView.OptionsDetail.DetailMode = DevExpress.XtraGrid.Views.Grid.DetailMode.Default;
            this.storageGroupsByZonesgridView.OptionsView.ShowAutoFilterRow = true;
            this.storageGroupsByZonesgridView.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.zoneNameCol, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // zoneNameCol
            // 
            this.zoneNameCol.AppearanceHeader.Options.UseTextOptions = true;
            this.zoneNameCol.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.zoneNameCol.Caption = "Зона";
            this.zoneNameCol.FieldName = "ZoneName";
            this.zoneNameCol.Name = "zoneNameCol";
            this.zoneNameCol.OptionsColumn.AllowEdit = false;
            this.zoneNameCol.OptionsColumn.AllowFocus = false;
            this.zoneNameCol.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.zoneNameCol.Visible = true;
            this.zoneNameCol.VisibleIndex = 0;
            // 
            // zoneColorCol
            // 
            this.zoneColorCol.AppearanceHeader.Options.UseTextOptions = true;
            this.zoneColorCol.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.zoneColorCol.Caption = "Цвет";
            this.zoneColorCol.ColumnEdit = this.repositoryItemColorPickEdit;
            this.zoneColorCol.FieldName = "ZoneColor";
            this.zoneColorCol.Name = "zoneColorCol";
            this.zoneColorCol.OptionsColumn.AllowEdit = false;
            this.zoneColorCol.OptionsColumn.AllowFocus = false;
            this.zoneColorCol.Visible = true;
            this.zoneColorCol.VisibleIndex = 1;
            this.zoneColorCol.Width = 129;
            // 
            // repositoryItemColorPickEdit
            // 
            this.repositoryItemColorPickEdit.AutoHeight = false;
            this.repositoryItemColorPickEdit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemColorPickEdit.Name = "repositoryItemColorPickEdit";
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
            this.storageGroupNameCol.VisibleIndex = 0;
            this.storageGroupNameCol.Width = 457;
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
            this.descriptionCol.Width = 451;
            // 
            // labelControl2
            // 
            this.labelControl2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelControl2.Location = new System.Drawing.Point(12, 18);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(24, 13);
            this.labelControl2.TabIndex = 22;
            this.labelControl2.Text = "Зона";
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelControl1.Location = new System.Drawing.Point(543, 18);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(29, 13);
            this.labelControl1.TabIndex = 21;
            this.labelControl1.Text = "Цвет ";
            // 
            // colorPickEdit
            // 
            this.colorPickEdit.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.colorPickEdit.EditValue = System.Drawing.Color.Empty;
            this.colorPickEdit.Enabled = false;
            this.colorPickEdit.Location = new System.Drawing.Point(578, 12);
            this.colorPickEdit.Name = "colorPickEdit";
            this.colorPickEdit.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.colorPickEdit.Properties.Appearance.Options.UseFont = true;
            this.colorPickEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.colorPickEdit.Size = new System.Drawing.Size(49, 26);
            this.colorPickEdit.TabIndex = 20;
            // 
            // checkGroupAll
            // 
            this.checkGroupAll.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.checkGroupAll.Location = new System.Drawing.Point(12, 50);
            this.checkGroupAll.Name = "checkGroupAll";
            this.checkGroupAll.Properties.Caption = "Отметить все";
            this.checkGroupAll.Size = new System.Drawing.Size(104, 19);
            this.checkGroupAll.TabIndex = 28;
            this.checkGroupAll.CheckStateChanged += new System.EventHandler(this.checkGroupAll_CheckStateChanged);
            // 
            // storageGroupGrid
            // 
            this.storageGroupGrid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.storageGroupGrid.Location = new System.Drawing.Point(1, 75);
            this.storageGroupGrid.MainView = this.storageGroupGridView;
            this.storageGroupGrid.Name = "storageGroupGrid";
            this.storageGroupGrid.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheck,
            this.repositoryItemButtonEdit1});
            this.storageGroupGrid.Size = new System.Drawing.Size(645, 622);
            this.storageGroupGrid.TabIndex = 2;
            this.storageGroupGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.storageGroupGridView});
            // 
            // storageGroupGridView
            // 
            this.storageGroupGridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.checkCol,
            this.storageGroupNameColumn,
            this.descriptionColumn});
            this.storageGroupGridView.GridControl = this.storageGroupGrid;
            this.storageGroupGridView.Name = "storageGroupGridView";
            this.storageGroupGridView.OptionsDetail.DetailMode = DevExpress.XtraGrid.Views.Grid.DetailMode.Default;
            this.storageGroupGridView.OptionsView.ShowGroupPanel = false;
            // 
            // checkCol
            // 
            this.checkCol.ColumnEdit = this.repositoryItemCheck;
            this.checkCol.FieldName = "GroupChecked";
            this.checkCol.Image = ((System.Drawing.Image)(resources.GetObject("checkCol.Image")));
            this.checkCol.ImageAlignment = System.Drawing.StringAlignment.Center;
            this.checkCol.Name = "checkCol";
            this.checkCol.Visible = true;
            this.checkCol.VisibleIndex = 0;
            this.checkCol.Width = 32;
            // 
            // repositoryItemCheck
            // 
            this.repositoryItemCheck.Name = "repositoryItemCheck";
            this.repositoryItemCheck.CheckStateChanged += new System.EventHandler(this.repositoryItemCheck_CheckStateChanged);
            // 
            // storageGroupNameColumn
            // 
            this.storageGroupNameColumn.Caption = "Складские группы";
            this.storageGroupNameColumn.FieldName = "StorageGroupName";
            this.storageGroupNameColumn.Name = "storageGroupNameColumn";
            this.storageGroupNameColumn.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.storageGroupNameColumn.Visible = true;
            this.storageGroupNameColumn.VisibleIndex = 1;
            this.storageGroupNameColumn.Width = 288;
            // 
            // descriptionColumn
            // 
            this.descriptionColumn.Caption = "Описание";
            this.descriptionColumn.FieldName = "Description";
            this.descriptionColumn.Name = "descriptionColumn";
            this.descriptionColumn.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.descriptionColumn.Visible = true;
            this.descriptionColumn.VisibleIndex = 2;
            this.descriptionColumn.Width = 307;
            // 
            // repositoryItemButtonEdit1
            // 
            this.repositoryItemButtonEdit1.AutoHeight = false;
            this.repositoryItemButtonEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.repositoryItemButtonEdit1.Name = "repositoryItemButtonEdit1";
            // 
            // addBtn
            // 
            this.addBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.addBtn.Appearance.BackColor = System.Drawing.Color.LimeGreen;
            this.addBtn.Appearance.Options.UseBackColor = true;
            this.addBtn.Image = global::TVM_WMS.GUI.Properties.Resources.double_arrow_right;
            this.addBtn.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.addBtn.Location = new System.Drawing.Point(652, 312);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(57, 35);
            this.addBtn.TabIndex = 3;
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // zoneNameGridLookUpEdit
            // 
            this.zoneNameGridLookUpEdit.Location = new System.Drawing.Point(42, 12);
            this.zoneNameGridLookUpEdit.Name = "zoneNameGridLookUpEdit";
            this.zoneNameGridLookUpEdit.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.zoneNameGridLookUpEdit.Properties.Appearance.Options.UseFont = true;
            this.zoneNameGridLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.zoneNameGridLookUpEdit.Properties.ImmediatePopup = true;
            this.zoneNameGridLookUpEdit.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            this.zoneNameGridLookUpEdit.Properties.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemColorPickEdit1});
            this.zoneNameGridLookUpEdit.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.zoneNameGridLookUpEdit.Properties.View = this.gridLookUpEdit1View;
            this.zoneNameGridLookUpEdit.Size = new System.Drawing.Size(495, 26);
            this.zoneNameGridLookUpEdit.TabIndex = 1;
            this.zoneNameGridLookUpEdit.QueryPopUp += new System.ComponentModel.CancelEventHandler(this.zoneNameGridLookUpEdit_QueryPopUp);
            this.zoneNameGridLookUpEdit.EditValueChanged += new System.EventHandler(this.zoneNamesEdit_EditValueChanged);
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
            this.gridLookUpEdit1View.OptionsFind.SearchInPreview = true;
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
            this.zoneNameColumn.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
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
            // deleteBtn
            // 
            this.deleteBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.deleteBtn.Appearance.BackColor = System.Drawing.Color.Tomato;
            this.deleteBtn.Appearance.Options.UseBackColor = true;
            this.deleteBtn.Image = global::TVM_WMS.GUI.Properties.Resources.double_arrow_left;
            this.deleteBtn.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.deleteBtn.Location = new System.Drawing.Point(652, 353);
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Size = new System.Drawing.Size(57, 35);
            this.deleteBtn.TabIndex = 4;
            this.deleteBtn.Click += new System.EventHandler(this.deleteBtn_Click);
            // 
            // SaveBtn
            // 
            this.SaveBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SaveBtn.Appearance.Options.UseTextOptions = true;
            this.SaveBtn.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.SaveBtn.Location = new System.Drawing.Point(1288, 710);
            this.SaveBtn.Name = "SaveBtn";
            this.SaveBtn.Size = new System.Drawing.Size(75, 23);
            this.SaveBtn.TabIndex = 33;
            this.SaveBtn.Text = "Сохранить";
            this.SaveBtn.Click += new System.EventHandler(this.SaveBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelBtn.Location = new System.Drawing.Point(1369, 710);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 32;
            this.cancelBtn.Text = "Отмена";
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // StorageGroupsByZonesFm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1454, 744);
            this.Controls.Add(this.SaveBtn);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.deleteBtn);
            this.Controls.Add(this.zoneNameGridLookUpEdit);
            this.Controls.Add(this.addBtn);
            this.Controls.Add(this.checkGroupAll);
            this.Controls.Add(this.storageGroupGrid);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.colorPickEdit);
            this.Controls.Add(this.storageGroupsByZoneGrid);
            this.Name = "StorageGroupsByZonesFm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Вхождение складских групп в зоны";
            ((System.ComponentModel.ISupportInitialize)(this.storageGroupsByZoneGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.storageGroupsByZonesgridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemColorPickEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorPickEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkGroupAll.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.storageGroupGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.storageGroupGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheck)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zoneNameGridLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemColorPickEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl storageGroupsByZoneGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView storageGroupsByZonesgridView;
        private DevExpress.XtraGrid.Columns.GridColumn zoneNameCol;
        private DevExpress.XtraGrid.Columns.GridColumn zoneColorCol;
        private DevExpress.XtraEditors.Repository.RepositoryItemColorPickEdit repositoryItemColorPickEdit;
        private DevExpress.XtraGrid.Columns.GridColumn storageGroupNameCol;
        private DevExpress.XtraGrid.Columns.GridColumn descriptionCol;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.ColorPickEdit colorPickEdit;
        private DevExpress.XtraEditors.CheckEdit checkGroupAll;
        private DevExpress.XtraGrid.GridControl storageGroupGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView storageGroupGridView;
        private DevExpress.XtraGrid.Columns.GridColumn checkCol;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheck;
        private DevExpress.XtraGrid.Columns.GridColumn storageGroupNameColumn;
        private DevExpress.XtraGrid.Columns.GridColumn descriptionColumn;
        private DevExpress.XtraEditors.SimpleButton addBtn;
        private DevExpress.XtraEditors.GridLookUpEdit zoneNameGridLookUpEdit;
        private DevExpress.XtraEditors.Repository.RepositoryItemColorPickEdit repositoryItemColorPickEdit1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridLookUpEdit1View;
        private DevExpress.XtraGrid.Columns.GridColumn zoneNameColumn;
        private DevExpress.XtraGrid.Columns.GridColumn zoneColorColumn;
        private DevExpress.XtraEditors.SimpleButton deleteBtn;
        private DevExpress.XtraEditors.SimpleButton SaveBtn;
        private DevExpress.XtraEditors.SimpleButton cancelBtn;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEdit1;
    }
}