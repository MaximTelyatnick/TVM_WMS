namespace TVM_WMS.GUI
{
    partial class UsersByRolesEditFm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UsersByRolesEditFm));
            this.usersByRolesGrid = new DevExpress.XtraGrid.GridControl();
            this.usersByRolesGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.checkedCol = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.fioCol = new DevExpress.XtraGrid.Columns.GridColumn();
            this.loginCol = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cancelBtn = new DevExpress.XtraEditors.SimpleButton();
            this.saveBtn = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.usersByRolesGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.usersByRolesGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // usersByRolesGrid
            // 
            this.usersByRolesGrid.Location = new System.Drawing.Point(1, 1);
            this.usersByRolesGrid.MainView = this.usersByRolesGridView;
            this.usersByRolesGrid.Name = "usersByRolesGrid";
            this.usersByRolesGrid.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1});
            this.usersByRolesGrid.Size = new System.Drawing.Size(620, 556);
            this.usersByRolesGrid.TabIndex = 0;
            this.usersByRolesGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.usersByRolesGridView});
            // 
            // usersByRolesGridView
            // 
            this.usersByRolesGridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.checkedCol,
            this.fioCol,
            this.loginCol});
            this.usersByRolesGridView.GridControl = this.usersByRolesGrid;
            this.usersByRolesGridView.Name = "usersByRolesGridView";
            this.usersByRolesGridView.OptionsDetail.DetailMode = DevExpress.XtraGrid.Views.Grid.DetailMode.Default;
            this.usersByRolesGridView.OptionsView.ShowAutoFilterRow = true;
            this.usersByRolesGridView.OptionsView.ShowGroupPanel = false;
            // 
            // checkedCol
            // 
            this.checkedCol.AppearanceHeader.Options.UseTextOptions = true;
            this.checkedCol.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.checkedCol.Caption = "*";
            this.checkedCol.ColumnEdit = this.repositoryItemCheckEdit1;
            this.checkedCol.FieldName = "Checked";
            this.checkedCol.Name = "checkedCol";
            this.checkedCol.Visible = true;
            this.checkedCol.VisibleIndex = 0;
            this.checkedCol.Width = 27;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.DisplayValueChecked = "1";
            this.repositoryItemCheckEdit1.DisplayValueUnchecked = "0";
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            this.repositoryItemCheckEdit1.ValueChecked = "1";
            this.repositoryItemCheckEdit1.ValueUnchecked = "0";
            this.repositoryItemCheckEdit1.CheckStateChanged += new System.EventHandler(this.repositoryItemCheckEdit1_CheckStateChanged);
            // 
            // fioCol
            // 
            this.fioCol.AppearanceHeader.Options.UseTextOptions = true;
            this.fioCol.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.fioCol.Caption = "ФИО";
            this.fioCol.FieldName = "Fio";
            this.fioCol.Name = "fioCol";
            this.fioCol.OptionsColumn.AllowEdit = false;
            this.fioCol.OptionsColumn.AllowFocus = false;
            this.fioCol.Visible = true;
            this.fioCol.VisibleIndex = 1;
            this.fioCol.Width = 322;
            // 
            // loginCol
            // 
            this.loginCol.AppearanceHeader.Options.UseTextOptions = true;
            this.loginCol.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.loginCol.Caption = "Имя пользователя";
            this.loginCol.FieldName = "Login";
            this.loginCol.Name = "loginCol";
            this.loginCol.OptionsColumn.AllowEdit = false;
            this.loginCol.OptionsColumn.AllowFocus = false;
            this.loginCol.Visible = true;
            this.loginCol.VisibleIndex = 2;
            this.loginCol.Width = 156;
            // 
            // cancelBtn
            // 
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Location = new System.Drawing.Point(541, 567);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 8;
            this.cancelBtn.Text = "Отмена";
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // saveBtn
            // 
            this.saveBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.saveBtn.Location = new System.Drawing.Point(460, 567);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(75, 23);
            this.saveBtn.TabIndex = 7;
            this.saveBtn.Text = "Сохранить";
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // UsersByRolesEditFm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(622, 602);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.usersByRolesGrid);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UsersByRolesEditFm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Пользователи ";
            ((System.ComponentModel.ISupportInitialize)(this.usersByRolesGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.usersByRolesGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl usersByRolesGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView usersByRolesGridView;
        private DevExpress.XtraGrid.Columns.GridColumn fioCol;
        private DevExpress.XtraGrid.Columns.GridColumn loginCol;
        private DevExpress.XtraEditors.SimpleButton cancelBtn;
        private DevExpress.XtraEditors.SimpleButton saveBtn;
        private DevExpress.XtraGrid.Columns.GridColumn checkedCol;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
    }
}