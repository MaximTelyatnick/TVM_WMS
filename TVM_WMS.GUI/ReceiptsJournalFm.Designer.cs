namespace TVM_WMS.GUI
{
    partial class ReceiptsJournalFm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReceiptsJournalFm));
            this.splashScreenManager = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::TVM_WMS.GUI.WaitForm1), true, true);
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.printDropDown = new DevExpress.XtraEditors.DropDownButton();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.showForDate = new DevExpress.XtraEditors.SimpleButton();
            this.endDateEdit = new DevExpress.XtraEditors.DateEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.beginDateEdit = new DevExpress.XtraEditors.DateEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.receiptsJournalGrid = new DevExpress.XtraGrid.GridControl();
            this.receiptsJournalGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.articleCol = new DevExpress.XtraGrid.Columns.GridColumn();
            this.nameCol = new DevExpress.XtraGrid.Columns.GridColumn();
            this.quantityCol = new DevExpress.XtraGrid.Columns.GridColumn();
            this.unitLocalNameCol = new DevExpress.XtraGrid.Columns.GridColumn();
            this.imageCollection = new DevExpress.Utils.ImageCollection(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.endDateEdit.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.endDateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.beginDateEdit.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.beginDateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.receiptsJournalGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.receiptsJournalGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection)).BeginInit();
            this.SuspendLayout();
            // 
            // splashScreenManager
            // 
            this.splashScreenManager.ClosingDelay = 500;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.printDropDown);
            this.panelControl1.Controls.Add(this.panelControl2);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1416, 47);
            this.panelControl1.TabIndex = 0;
            // 
            // printDropDown
            // 
            this.printDropDown.Image = ((System.Drawing.Image)(resources.GetObject("printDropDown.Image")));
            this.printDropDown.Location = new System.Drawing.Point(314, 10);
            this.printDropDown.Name = "printDropDown";
            this.printDropDown.Size = new System.Drawing.Size(100, 23);
            this.printDropDown.TabIndex = 15;
            this.printDropDown.Text = "Экспорт";
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.showForDate);
            this.panelControl2.Controls.Add(this.endDateEdit);
            this.panelControl2.Controls.Add(this.labelControl2);
            this.panelControl2.Controls.Add(this.beginDateEdit);
            this.panelControl2.Controls.Add(this.labelControl1);
            this.panelControl2.Location = new System.Drawing.Point(4, 3);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(294, 39);
            this.panelControl2.TabIndex = 12;
            // 
            // showForDate
            // 
            this.showForDate.Image = global::TVM_WMS.GUI.Properties.Resources.filter;
            this.showForDate.Location = new System.Drawing.Point(260, 8);
            this.showForDate.Name = "showForDate";
            this.showForDate.Size = new System.Drawing.Size(27, 23);
            this.showForDate.TabIndex = 10;
            this.showForDate.ToolTip = "Фильтровать";
            this.showForDate.Click += new System.EventHandler(this.showForDate_Click);
            // 
            // endDateEdit
            // 
            this.endDateEdit.EditValue = null;
            this.endDateEdit.Location = new System.Drawing.Point(154, 10);
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
            this.labelControl2.Location = new System.Drawing.Point(131, 13);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(13, 13);
            this.labelControl2.TabIndex = 9;
            this.labelControl2.Text = "По";
            // 
            // beginDateEdit
            // 
            this.beginDateEdit.EditValue = null;
            this.beginDateEdit.Location = new System.Drawing.Point(21, 10);
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
            this.labelControl1.Location = new System.Drawing.Point(8, 13);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(7, 13);
            this.labelControl1.TabIndex = 8;
            this.labelControl1.Text = "С";
            // 
            // receiptsJournalGrid
            // 
            this.receiptsJournalGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.receiptsJournalGrid.Location = new System.Drawing.Point(0, 47);
            this.receiptsJournalGrid.MainView = this.receiptsJournalGridView;
            this.receiptsJournalGrid.Name = "receiptsJournalGrid";
            this.receiptsJournalGrid.Size = new System.Drawing.Size(1416, 597);
            this.receiptsJournalGrid.TabIndex = 1;
            this.receiptsJournalGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.receiptsJournalGridView});
            // 
            // receiptsJournalGridView
            // 
            this.receiptsJournalGridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.articleCol,
            this.nameCol,
            this.quantityCol,
            this.unitLocalNameCol});
            this.receiptsJournalGridView.GridControl = this.receiptsJournalGrid;
            this.receiptsJournalGridView.Name = "receiptsJournalGridView";
            this.receiptsJournalGridView.OptionsDetail.DetailMode = DevExpress.XtraGrid.Views.Grid.DetailMode.Default;
            this.receiptsJournalGridView.OptionsView.ShowAutoFilterRow = true;
            this.receiptsJournalGridView.OptionsView.ShowGroupPanel = false;
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
            this.articleCol.Width = 198;
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
            this.nameCol.Width = 905;
            // 
            // quantityCol
            // 
            this.quantityCol.AppearanceHeader.Options.UseTextOptions = true;
            this.quantityCol.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.quantityCol.Caption = "Количество";
            this.quantityCol.FieldName = "Quantity";
            this.quantityCol.Name = "quantityCol";
            this.quantityCol.OptionsColumn.AllowEdit = false;
            this.quantityCol.OptionsColumn.AllowFocus = false;
            this.quantityCol.Visible = true;
            this.quantityCol.VisibleIndex = 2;
            this.quantityCol.Width = 146;
            // 
            // unitLocalNameCol
            // 
            this.unitLocalNameCol.AppearanceHeader.Options.UseTextOptions = true;
            this.unitLocalNameCol.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.unitLocalNameCol.Caption = "Ед. изм.";
            this.unitLocalNameCol.FieldName = "UnitLocalName";
            this.unitLocalNameCol.Name = "unitLocalNameCol";
            this.unitLocalNameCol.OptionsColumn.AllowEdit = false;
            this.unitLocalNameCol.OptionsColumn.AllowFocus = false;
            this.unitLocalNameCol.Visible = true;
            this.unitLocalNameCol.VisibleIndex = 3;
            this.unitLocalNameCol.Width = 149;
            // 
            // imageCollection
            // 
            this.imageCollection.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection.ImageStream")));
            this.imageCollection.InsertGalleryImage("exporttoxml_16x16.png", "images/export/exporttoxml_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/export/exporttoxml_16x16.png"), 0);
            this.imageCollection.Images.SetKeyName(0, "exporttoxml_16x16.png");
            this.imageCollection.InsertGalleryImage("exporttopdf_16x16.png", "images/export/exporttopdf_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/export/exporttopdf_16x16.png"), 1);
            this.imageCollection.Images.SetKeyName(1, "exporttopdf_16x16.png");
            // 
            // ReceiptsJournalFm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1416, 644);
            this.Controls.Add(this.receiptsJournalGrid);
            this.Controls.Add(this.panelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ReceiptsJournalFm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Журнал прихода";
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.endDateEdit.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.endDateEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.beginDateEdit.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.beginDateEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.receiptsJournalGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.receiptsJournalGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.SimpleButton showForDate;
        private DevExpress.XtraEditors.DateEdit endDateEdit;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.DateEdit beginDateEdit;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraGrid.GridControl receiptsJournalGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView receiptsJournalGridView;
        private DevExpress.XtraGrid.Columns.GridColumn articleCol;
        private DevExpress.XtraGrid.Columns.GridColumn nameCol;
        private DevExpress.XtraGrid.Columns.GridColumn quantityCol;
        private DevExpress.XtraGrid.Columns.GridColumn unitLocalNameCol;
        private DevExpress.XtraEditors.DropDownButton printDropDown;
        private DevExpress.Utils.ImageCollection imageCollection;
    }
}