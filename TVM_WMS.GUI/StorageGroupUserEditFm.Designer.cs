namespace TVM_WMS.GUI
{
    partial class StorageGroupUserEditFm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StorageGroupUserEditFm));
            this.cancelBtn = new DevExpress.XtraEditors.SimpleButton();
            this.saveBtn = new DevExpress.XtraEditors.SimpleButton();
            this.storageGroupGrid = new DevExpress.XtraGrid.GridControl();
            this.storageGroupGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.checkDeleteCol = new DevExpress.XtraGrid.Columns.GridColumn();
            this.checkForDeleteStorageRepository = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.storageGroupNameCol = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.storageGroupGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.storageGroupGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkForDeleteStorageRepository)).BeginInit();
            this.SuspendLayout();
            // 
            // cancelBtn
            // 
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Location = new System.Drawing.Point(410, 429);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 12;
            this.cancelBtn.Text = "Отмена";
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // saveBtn
            // 
            this.saveBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.saveBtn.Location = new System.Drawing.Point(329, 429);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(75, 23);
            this.saveBtn.TabIndex = 11;
            this.saveBtn.Text = "Добавить";
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // storageGroupGrid
            // 
            this.storageGroupGrid.Dock = System.Windows.Forms.DockStyle.Top;
            this.storageGroupGrid.Location = new System.Drawing.Point(0, 0);
            this.storageGroupGrid.MainView = this.storageGroupGridView;
            this.storageGroupGrid.Name = "storageGroupGrid";
            this.storageGroupGrid.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.checkForDeleteStorageRepository});
            this.storageGroupGrid.Size = new System.Drawing.Size(497, 423);
            this.storageGroupGrid.TabIndex = 13;
            this.storageGroupGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.storageGroupGridView});
            // 
            // storageGroupGridView
            // 
            this.storageGroupGridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.checkDeleteCol,
            this.storageGroupNameCol});
            this.storageGroupGridView.GridControl = this.storageGroupGrid;
            this.storageGroupGridView.Name = "storageGroupGridView";
            this.storageGroupGridView.OptionsDetail.DetailMode = DevExpress.XtraGrid.Views.Grid.DetailMode.Default;
            this.storageGroupGridView.OptionsView.ShowAutoFilterRow = true;
            this.storageGroupGridView.OptionsView.ShowGroupPanel = false;
            // 
            // checkDeleteCol
            // 
            this.checkDeleteCol.ColumnEdit = this.checkForDeleteStorageRepository;
            this.checkDeleteCol.FieldName = "GroupChecked";
            this.checkDeleteCol.Image = ((System.Drawing.Image)(resources.GetObject("checkDeleteCol.Image")));
            this.checkDeleteCol.ImageAlignment = System.Drawing.StringAlignment.Center;
            this.checkDeleteCol.Name = "checkDeleteCol";
            this.checkDeleteCol.Visible = true;
            this.checkDeleteCol.VisibleIndex = 0;
            this.checkDeleteCol.Width = 34;
            // 
            // checkForDeleteStorageRepository
            // 
            this.checkForDeleteStorageRepository.AutoHeight = false;
            this.checkForDeleteStorageRepository.Name = "checkForDeleteStorageRepository";
            // 
            // storageGroupNameCol
            // 
            this.storageGroupNameCol.AppearanceHeader.Options.UseTextOptions = true;
            this.storageGroupNameCol.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.storageGroupNameCol.Caption = "Наименование";
            this.storageGroupNameCol.FieldName = "StorageGroupName";
            this.storageGroupNameCol.Name = "storageGroupNameCol";
            this.storageGroupNameCol.OptionsColumn.AllowEdit = false;
            this.storageGroupNameCol.OptionsColumn.AllowFocus = false;
            this.storageGroupNameCol.Visible = true;
            this.storageGroupNameCol.VisibleIndex = 1;
            this.storageGroupNameCol.Width = 548;
            // 
            // StorageGroupUserEditFm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(497, 464);
            this.Controls.Add(this.storageGroupGrid);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.saveBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StorageGroupUserEditFm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Складские группы";
            ((System.ComponentModel.ISupportInitialize)(this.storageGroupGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.storageGroupGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkForDeleteStorageRepository)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton cancelBtn;
        private DevExpress.XtraEditors.SimpleButton saveBtn;
        private DevExpress.XtraGrid.GridControl storageGroupGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView storageGroupGridView;
        private DevExpress.XtraGrid.Columns.GridColumn storageGroupNameCol;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit checkForDeleteStorageRepository;
        private DevExpress.XtraGrid.Columns.GridColumn checkDeleteCol;
    }
}