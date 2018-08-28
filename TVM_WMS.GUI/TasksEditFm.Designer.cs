namespace TVM_WMS.GUI
{
    partial class TasksEditFm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TasksEditFm));
            this.tasksTreeList = new DevExpress.XtraTreeList.TreeList();
            this.taskCaptionCol = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.taskNameCol = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.checkedCol = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.accessRightCol = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.repositoryItemCheckEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.headerImageCollection = new DevExpress.Utils.ImageCollection(this.components);
            this.cancelBtn = new DevExpress.XtraEditors.SimpleButton();
            this.saveBtn = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.tasksTreeList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerImageCollection)).BeginInit();
            this.SuspendLayout();
            // 
            // tasksTreeList
            // 
            this.tasksTreeList.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.checkedCol,
            this.taskCaptionCol,
            this.taskNameCol,
            this.accessRightCol});
            this.tasksTreeList.ColumnsImageList = this.headerImageCollection;
            this.tasksTreeList.Cursor = System.Windows.Forms.Cursors.Default;
            this.tasksTreeList.Location = new System.Drawing.Point(0, -1);
            this.tasksTreeList.Name = "tasksTreeList";
            this.tasksTreeList.OptionsBehavior.AllowRecursiveNodeChecking = true;
            this.tasksTreeList.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1,
            this.repositoryItemCheckEdit2});
            this.tasksTreeList.Size = new System.Drawing.Size(645, 562);
            this.tasksTreeList.TabIndex = 0;
            this.tasksTreeList.TreeLineStyle = DevExpress.XtraTreeList.LineStyle.Solid;
            this.tasksTreeList.CustomNodeCellEdit += new DevExpress.XtraTreeList.GetCustomNodeCellEditEventHandler(this.tasksTreeList_CustomNodeCellEdit);
            // 
            // taskCaptionCol
            // 
            this.taskCaptionCol.AppearanceHeader.Options.UseTextOptions = true;
            this.taskCaptionCol.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.taskCaptionCol.Caption = "Наименование";
            this.taskCaptionCol.FieldName = "TaskCaption";
            this.taskCaptionCol.Name = "taskCaptionCol";
            this.taskCaptionCol.OptionsColumn.AllowEdit = false;
            this.taskCaptionCol.OptionsColumn.AllowFocus = false;
            this.taskCaptionCol.Visible = true;
            this.taskCaptionCol.VisibleIndex = 1;
            this.taskCaptionCol.Width = 331;
            // 
            // taskNameCol
            // 
            this.taskNameCol.AppearanceHeader.Options.UseTextOptions = true;
            this.taskNameCol.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.taskNameCol.Caption = "Код ";
            this.taskNameCol.FieldName = "TaskName";
            this.taskNameCol.Name = "taskNameCol";
            this.taskNameCol.OptionsColumn.AllowEdit = false;
            this.taskNameCol.OptionsColumn.AllowFocus = false;
            this.taskNameCol.Visible = true;
            this.taskNameCol.VisibleIndex = 2;
            this.taskNameCol.Width = 179;
            // 
            // checkedCol
            // 
            this.checkedCol.AppearanceHeader.Options.UseImage = true;
            this.checkedCol.AppearanceHeader.Options.UseTextOptions = true;
            this.checkedCol.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.checkedCol.ColumnEdit = this.repositoryItemCheckEdit1;
            this.checkedCol.FieldName = "Checked";
            this.checkedCol.ImageAlignment = System.Drawing.StringAlignment.Center;
            this.checkedCol.ImageIndex = 0;
            this.checkedCol.Name = "checkedCol";
            this.checkedCol.Visible = true;
            this.checkedCol.VisibleIndex = 0;
            this.checkedCol.Width = 65;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            this.repositoryItemCheckEdit1.CheckStateChanged += new System.EventHandler(this.repositoryItemCheckEdit1_CheckStateChanged);
            // 
            // accessRightCol
            // 
            this.accessRightCol.AppearanceHeader.Options.UseImage = true;
            this.accessRightCol.AppearanceHeader.Options.UseTextOptions = true;
            this.accessRightCol.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.accessRightCol.Caption = "Чтение";
            this.accessRightCol.ColumnEdit = this.repositoryItemCheckEdit2;
            this.accessRightCol.FieldName = "AccessRight";
            this.accessRightCol.ImageIndex = 0;
            this.accessRightCol.Name = "accessRightCol";
            this.accessRightCol.Visible = true;
            this.accessRightCol.VisibleIndex = 3;
            this.accessRightCol.Width = 101;
            // 
            // repositoryItemCheckEdit2
            // 
            this.repositoryItemCheckEdit2.AutoHeight = false;
            this.repositoryItemCheckEdit2.Name = "repositoryItemCheckEdit2";
            this.repositoryItemCheckEdit2.CheckedChanged += new System.EventHandler(this.repositoryItemCheckEdit2_CheckedChanged);
            // 
            // headerImageCollection
            // 
            this.headerImageCollection.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("headerImageCollection.ImageStream")));
            this.headerImageCollection.InsertGalleryImage("checkbox2_16x16.png", "images/toolbox%20items/checkbox2_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/toolbox%20items/checkbox2_16x16.png"), 0);
            this.headerImageCollection.Images.SetKeyName(0, "checkbox2_16x16.png");
            // 
            // cancelBtn
            // 
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Location = new System.Drawing.Point(564, 567);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 10;
            this.cancelBtn.Text = "Отмена";
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // saveBtn
            // 
            this.saveBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.saveBtn.Location = new System.Drawing.Point(483, 567);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(75, 23);
            this.saveBtn.TabIndex = 9;
            this.saveBtn.Text = "Сохранить";
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // TasksEditFm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(646, 602);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.tasksTreeList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TasksEditFm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Меню системы";
            ((System.ComponentModel.ISupportInitialize)(this.tasksTreeList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerImageCollection)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTreeList.TreeList tasksTreeList;
        private DevExpress.XtraTreeList.Columns.TreeListColumn taskCaptionCol;
        private DevExpress.XtraTreeList.Columns.TreeListColumn taskNameCol;
        private DevExpress.XtraTreeList.Columns.TreeListColumn checkedCol;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraEditors.SimpleButton cancelBtn;
        private DevExpress.XtraEditors.SimpleButton saveBtn;
        private DevExpress.Utils.ImageCollection headerImageCollection;
        private DevExpress.XtraTreeList.Columns.TreeListColumn accessRightCol;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit2;
    }
}