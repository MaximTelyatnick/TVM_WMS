namespace TVM_WMS.GUI
{
    partial class KitsFm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KitsFm));
            this.receiptControl = new DevExpress.XtraEditors.GroupControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.nameTBox = new DevExpress.XtraEditors.TextEdit();
            this.orderDateEdit = new DevExpress.XtraEditors.DateEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.quantityTBox = new DevExpress.XtraEditors.TextEdit();
            this.articleTBox = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.orderNumberTBox = new DevExpress.XtraEditors.TextEdit();
            this.saveBtn = new DevExpress.XtraEditors.SimpleButton();
            this.cancelBtn = new DevExpress.XtraEditors.SimpleButton();
            this.kitsControl = new DevExpress.XtraEditors.GroupControl();
            this.quantityInKitTBox = new DevExpress.XtraEditors.TextEdit();
            this.deleteBtn = new DevExpress.XtraEditors.SimpleButton();
            this.addBtn = new DevExpress.XtraEditors.SimpleButton();
            this.kitsGrid = new DevExpress.XtraGrid.GridControl();
            this.kitsGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.quantityCol = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.receiptControl)).BeginInit();
            this.receiptControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nameTBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderDateEdit.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderDateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quantityTBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.articleTBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderNumberTBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kitsControl)).BeginInit();
            this.kitsControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.quantityInKitTBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kitsGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kitsGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // receiptControl
            // 
            this.receiptControl.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.receiptControl.AppearanceCaption.ForeColor = System.Drawing.Color.Navy;
            this.receiptControl.AppearanceCaption.Options.UseFont = true;
            this.receiptControl.AppearanceCaption.Options.UseForeColor = true;
            this.receiptControl.Controls.Add(this.labelControl5);
            this.receiptControl.Controls.Add(this.nameTBox);
            this.receiptControl.Controls.Add(this.orderDateEdit);
            this.receiptControl.Controls.Add(this.labelControl4);
            this.receiptControl.Controls.Add(this.labelControl3);
            this.receiptControl.Controls.Add(this.labelControl2);
            this.receiptControl.Controls.Add(this.quantityTBox);
            this.receiptControl.Controls.Add(this.articleTBox);
            this.receiptControl.Controls.Add(this.labelControl1);
            this.receiptControl.Controls.Add(this.orderNumberTBox);
            this.receiptControl.Location = new System.Drawing.Point(2, 1);
            this.receiptControl.Name = "receiptControl";
            this.receiptControl.Size = new System.Drawing.Size(416, 150);
            this.receiptControl.TabIndex = 9;
            this.receiptControl.Text = "Приход";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(10, 52);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(20, 13);
            this.labelControl5.TabIndex = 19;
            this.labelControl5.Text = "Код";
            // 
            // nameTBox
            // 
            this.nameTBox.Enabled = false;
            this.nameTBox.Location = new System.Drawing.Point(106, 75);
            this.nameTBox.Name = "nameTBox";
            this.nameTBox.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black;
            this.nameTBox.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.nameTBox.Size = new System.Drawing.Size(298, 20);
            this.nameTBox.TabIndex = 18;
            // 
            // orderDateEdit
            // 
            this.orderDateEdit.EditValue = null;
            this.orderDateEdit.Enabled = false;
            this.orderDateEdit.Location = new System.Drawing.Point(283, 23);
            this.orderDateEdit.Name = "orderDateEdit";
            this.orderDateEdit.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black;
            this.orderDateEdit.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.orderDateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.orderDateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.orderDateEdit.Size = new System.Drawing.Size(121, 20);
            this.orderDateEdit.TabIndex = 17;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(11, 112);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(60, 13);
            this.labelControl4.TabIndex = 16;
            this.labelControl4.Text = "Количество";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(10, 78);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(73, 13);
            this.labelControl3.TabIndex = 15;
            this.labelControl3.Text = "Наименование";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(251, 26);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(26, 13);
            this.labelControl2.TabIndex = 14;
            this.labelControl2.Text = "Дата";
            // 
            // quantityTBox
            // 
            this.quantityTBox.Enabled = false;
            this.quantityTBox.Location = new System.Drawing.Point(106, 107);
            this.quantityTBox.Name = "quantityTBox";
            this.quantityTBox.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.quantityTBox.Properties.Appearance.Options.UseFont = true;
            this.quantityTBox.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.DarkRed;
            this.quantityTBox.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.quantityTBox.Size = new System.Drawing.Size(162, 26);
            this.quantityTBox.TabIndex = 12;
            // 
            // articleTBox
            // 
            this.articleTBox.Enabled = false;
            this.articleTBox.Location = new System.Drawing.Point(106, 49);
            this.articleTBox.Name = "articleTBox";
            this.articleTBox.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black;
            this.articleTBox.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.articleTBox.Size = new System.Drawing.Size(139, 20);
            this.articleTBox.TabIndex = 11;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(11, 26);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(89, 13);
            this.labelControl1.TabIndex = 10;
            this.labelControl1.Text = "Номер документа";
            // 
            // orderNumberTBox
            // 
            this.orderNumberTBox.Enabled = false;
            this.orderNumberTBox.Location = new System.Drawing.Point(106, 23);
            this.orderNumberTBox.Name = "orderNumberTBox";
            this.orderNumberTBox.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black;
            this.orderNumberTBox.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.orderNumberTBox.Size = new System.Drawing.Size(139, 20);
            this.orderNumberTBox.TabIndex = 9;
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(262, 518);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(75, 23);
            this.saveBtn.TabIndex = 18;
            this.saveBtn.Text = "Сохранить";
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Location = new System.Drawing.Point(343, 518);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 19;
            this.cancelBtn.Text = "Отмена";
            // 
            // kitsControl
            // 
            this.kitsControl.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.kitsControl.AppearanceCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.kitsControl.AppearanceCaption.Options.UseFont = true;
            this.kitsControl.AppearanceCaption.Options.UseForeColor = true;
            this.kitsControl.Controls.Add(this.quantityInKitTBox);
            this.kitsControl.Controls.Add(this.deleteBtn);
            this.kitsControl.Controls.Add(this.addBtn);
            this.kitsControl.Controls.Add(this.kitsGrid);
            this.kitsControl.Location = new System.Drawing.Point(2, 157);
            this.kitsControl.Name = "kitsControl";
            this.kitsControl.Size = new System.Drawing.Size(416, 355);
            this.kitsControl.TabIndex = 1;
            this.kitsControl.Text = "Комплекты";
            // 
            // quantityInKitTBox
            // 
            this.quantityInKitTBox.Location = new System.Drawing.Point(21, 61);
            this.quantityInKitTBox.Name = "quantityInKitTBox";
            this.quantityInKitTBox.Properties.Mask.EditMask = "n2";
            this.quantityInKitTBox.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.quantityInKitTBox.Properties.NullText = "0.00";
            this.quantityInKitTBox.Properties.NullValuePrompt = "0.00";
            this.quantityInKitTBox.Properties.NullValuePromptShowForEmptyValue = true;
            this.quantityInKitTBox.Size = new System.Drawing.Size(106, 20);
            this.quantityInKitTBox.TabIndex = 2;
            // 
            // deleteBtn
            // 
            this.deleteBtn.Image = global::TVM_WMS.GUI.Properties.Resources.Delete;
            this.deleteBtn.Location = new System.Drawing.Point(21, 90);
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Size = new System.Drawing.Size(106, 29);
            this.deleteBtn.TabIndex = 21;
            this.deleteBtn.Text = "Удалить";
            this.deleteBtn.Click += new System.EventHandler(this.deleteBtn_Click);
            // 
            // addBtn
            // 
            this.addBtn.Image = global::TVM_WMS.GUI.Properties.Resources.Add;
            this.addBtn.Location = new System.Drawing.Point(21, 26);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(106, 29);
            this.addBtn.TabIndex = 2;
            this.addBtn.Text = "Добавить";
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // kitsGrid
            // 
            this.kitsGrid.Location = new System.Drawing.Point(148, 26);
            this.kitsGrid.MainView = this.kitsGridView;
            this.kitsGrid.Name = "kitsGrid";
            this.kitsGrid.Size = new System.Drawing.Size(256, 324);
            this.kitsGrid.TabIndex = 3;
            this.kitsGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.kitsGridView});
            // 
            // kitsGridView
            // 
            this.kitsGridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.quantityCol});
            this.kitsGridView.GridControl = this.kitsGrid;
            this.kitsGridView.Name = "kitsGridView";
            this.kitsGridView.OptionsDetail.DetailMode = DevExpress.XtraGrid.Views.Grid.DetailMode.Default;
            this.kitsGridView.OptionsView.ShowFooter = true;
            this.kitsGridView.OptionsView.ShowGroupPanel = false;
            // 
            // quantityCol
            // 
            this.quantityCol.AppearanceCell.Options.UseTextOptions = true;
            this.quantityCol.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.quantityCol.AppearanceHeader.Options.UseTextOptions = true;
            this.quantityCol.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.quantityCol.Caption = "Количество";
            this.quantityCol.FieldName = "Quantity";
            this.quantityCol.Name = "quantityCol";
            this.quantityCol.OptionsColumn.AllowEdit = false;
            this.quantityCol.OptionsColumn.AllowFocus = false;
            this.quantityCol.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Quantity", "Сумма={0:0.##}")});
            this.quantityCol.Visible = true;
            this.quantityCol.VisibleIndex = 0;
            // 
            // KitsFm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(425, 549);
            this.Controls.Add(this.kitsControl);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.receiptControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "KitsFm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Создание комплектов";
            ((System.ComponentModel.ISupportInitialize)(this.receiptControl)).EndInit();
            this.receiptControl.ResumeLayout(false);
            this.receiptControl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nameTBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderDateEdit.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderDateEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quantityTBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.articleTBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderNumberTBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kitsControl)).EndInit();
            this.kitsControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.quantityInKitTBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kitsGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kitsGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl receiptControl;
        private DevExpress.XtraEditors.DateEdit orderDateEdit;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit quantityTBox;
        private DevExpress.XtraEditors.TextEdit articleTBox;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit orderNumberTBox;
        private DevExpress.XtraEditors.SimpleButton saveBtn;
        private DevExpress.XtraEditors.SimpleButton cancelBtn;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.TextEdit nameTBox;
        private DevExpress.XtraEditors.GroupControl kitsControl;
        private DevExpress.XtraEditors.SimpleButton deleteBtn;
        private DevExpress.XtraEditors.SimpleButton addBtn;
        private DevExpress.XtraGrid.GridControl kitsGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView kitsGridView;
        private DevExpress.XtraGrid.Columns.GridColumn quantityCol;
        private DevExpress.XtraEditors.TextEdit quantityInKitTBox;

    }
}