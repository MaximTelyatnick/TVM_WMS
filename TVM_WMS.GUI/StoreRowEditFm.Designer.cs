namespace TVM_WMS.GUI
{
    partial class StoreRowEditFm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StoreRowEditFm));
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule1 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule2 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule3 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule4 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.pictureEdit3 = new DevExpress.XtraEditors.PictureEdit();
            this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            this.numberingRGroup = new DevExpress.XtraEditors.RadioGroup();
            this.cancelBtn = new DevExpress.XtraEditors.SimpleButton();
            this.saveBtn = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.columnCountTBox = new DevExpress.XtraEditors.TextEdit();
            this.lineCountTBox = new DevExpress.XtraEditors.TextEdit();
            this.cellCountTBox = new DevExpress.XtraEditors.TextEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.nameTBox = new DevExpress.XtraEditors.TextEdit();
            this.validateLbl = new DevExpress.XtraEditors.LabelControl();
            this.storeRowValidationProvider = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numberingRGroup.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.columnCountTBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lineCountTBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cellCountTBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nameTBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.storeRowValidationProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.pictureEdit3);
            this.groupControl2.Controls.Add(this.pictureEdit1);
            this.groupControl2.Controls.Add(this.numberingRGroup);
            this.groupControl2.Location = new System.Drawing.Point(248, 49);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(230, 117);
            this.groupControl2.TabIndex = 10;
            this.groupControl2.Text = "Тип нумерации ячеек";
            // 
            // pictureEdit3
            // 
            this.pictureEdit3.EditValue = ((object)(resources.GetObject("pictureEdit3.EditValue")));
            this.pictureEdit3.Location = new System.Drawing.Point(156, 41);
            this.pictureEdit3.Name = "pictureEdit3";
            this.pictureEdit3.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.pictureEdit3.Properties.Appearance.Options.UseBackColor = true;
            this.pictureEdit3.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pictureEdit3.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.pictureEdit3.Properties.ZoomAccelerationFactor = 1D;
            this.pictureEdit3.Size = new System.Drawing.Size(45, 49);
            this.pictureEdit3.TabIndex = 3;
            // 
            // pictureEdit1
            // 
            this.pictureEdit1.EditValue = ((object)(resources.GetObject("pictureEdit1.EditValue")));
            this.pictureEdit1.Location = new System.Drawing.Point(39, 43);
            this.pictureEdit1.Name = "pictureEdit1";
            this.pictureEdit1.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.pictureEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.pictureEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pictureEdit1.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.pictureEdit1.Properties.ZoomAccelerationFactor = 1D;
            this.pictureEdit1.Size = new System.Drawing.Size(45, 49);
            this.pictureEdit1.TabIndex = 1;
            // 
            // numberingRGroup
            // 
            this.numberingRGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numberingRGroup.Location = new System.Drawing.Point(2, 20);
            this.numberingRGroup.Name = "numberingRGroup";
            this.numberingRGroup.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.numberingRGroup.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.numberingRGroup.Properties.Appearance.Options.UseBackColor = true;
            this.numberingRGroup.Properties.Appearance.Options.UseFont = true;
            this.numberingRGroup.Properties.Columns = 2;
            this.numberingRGroup.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "1"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "2")});
            this.numberingRGroup.Size = new System.Drawing.Size(226, 95);
            this.numberingRGroup.TabIndex = 0;
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(404, 191);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 12;
            this.cancelBtn.Text = "Отмена";
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(323, 191);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(75, 23);
            this.saveBtn.TabIndex = 11;
            this.saveBtn.Text = "Сохранить";
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.labelControl4);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.columnCountTBox);
            this.groupControl1.Controls.Add(this.lineCountTBox);
            this.groupControl1.Controls.Add(this.cellCountTBox);
            this.groupControl1.Location = new System.Drawing.Point(12, 49);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(230, 117);
            this.groupControl1.TabIndex = 9;
            this.groupControl1.Text = "Характеристики склада";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(13, 88);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(45, 13);
            this.labelControl4.TabIndex = 5;
            this.labelControl4.Text = "Стелажи";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(21, 37);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(37, 13);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "Ячейки";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(25, 62);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(33, 13);
            this.labelControl3.TabIndex = 4;
            this.labelControl3.Text = "Этажи";
            // 
            // columnCountTBox
            // 
            this.columnCountTBox.Location = new System.Drawing.Point(64, 85);
            this.columnCountTBox.Name = "columnCountTBox";
            this.columnCountTBox.Properties.Mask.EditMask = "n0";
            this.columnCountTBox.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.columnCountTBox.Size = new System.Drawing.Size(161, 20);
            this.columnCountTBox.TabIndex = 6;
            conditionValidationRule1.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule1.ErrorText = "Укажите количество стелажей";
            conditionValidationRule1.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical;
            this.storeRowValidationProvider.SetValidationRule(this.columnCountTBox, conditionValidationRule1);
            this.columnCountTBox.TextChanged += new System.EventHandler(this.columnCountTBox_TextChanged);
            // 
            // lineCountTBox
            // 
            this.lineCountTBox.Location = new System.Drawing.Point(64, 59);
            this.lineCountTBox.Name = "lineCountTBox";
            this.lineCountTBox.Properties.Mask.EditMask = "n0";
            this.lineCountTBox.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.lineCountTBox.Size = new System.Drawing.Size(161, 20);
            this.lineCountTBox.TabIndex = 5;
            conditionValidationRule2.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule2.ErrorText = "Укажите количество этажей";
            conditionValidationRule2.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical;
            this.storeRowValidationProvider.SetValidationRule(this.lineCountTBox, conditionValidationRule2);
            this.lineCountTBox.TextChanged += new System.EventHandler(this.lineCountTBox_TextChanged);
            // 
            // cellCountTBox
            // 
            this.cellCountTBox.Location = new System.Drawing.Point(64, 33);
            this.cellCountTBox.Name = "cellCountTBox";
            this.cellCountTBox.Properties.Mask.EditMask = "n0";
            this.cellCountTBox.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.cellCountTBox.Size = new System.Drawing.Size(161, 20);
            this.cellCountTBox.TabIndex = 3;
            conditionValidationRule3.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule3.ErrorText = "Укажите количество ячеек ряда";
            conditionValidationRule3.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical;
            this.storeRowValidationProvider.SetValidationRule(this.cellCountTBox, conditionValidationRule3);
            this.cellCountTBox.TextChanged += new System.EventHandler(this.cellCountTBox_TextChanged);
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(12, 15);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(73, 13);
            this.labelControl5.TabIndex = 14;
            this.labelControl5.Text = "Наименование";
            // 
            // nameTBox
            // 
            this.nameTBox.Location = new System.Drawing.Point(91, 12);
            this.nameTBox.Name = "nameTBox";
            this.nameTBox.Size = new System.Drawing.Size(387, 20);
            this.nameTBox.TabIndex = 15;
            conditionValidationRule4.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule4.ErrorText = "Введите наименование ряда";
            conditionValidationRule4.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical;
            this.storeRowValidationProvider.SetValidationRule(this.nameTBox, conditionValidationRule4);
            this.nameTBox.TextChanged += new System.EventHandler(this.nameTBox_TextChanged);
            // 
            // validateLbl
            // 
            this.validateLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.validateLbl.Appearance.BackColor = System.Drawing.SystemColors.Info;
            this.validateLbl.Appearance.ForeColor = System.Drawing.Color.OrangeRed;
            this.validateLbl.Location = new System.Drawing.Point(26, 196);
            this.validateLbl.Name = "validateLbl";
            this.validateLbl.Size = new System.Drawing.Size(263, 13);
            this.validateLbl.TabIndex = 62;
            this.validateLbl.Text = "*Для сохранения заполните все необходимые поля";
            // 
            // storeRowValidationProvider
            // 
            this.storeRowValidationProvider.ValidationMode = DevExpress.XtraEditors.DXErrorProvider.ValidationMode.Auto;
            this.storeRowValidationProvider.ValidationFailed += new DevExpress.XtraEditors.DXErrorProvider.ValidationFailedEventHandler(this.storeRowValidationProvider_ValidationFailed);
            this.storeRowValidationProvider.ValidationSucceeded += new DevExpress.XtraEditors.DXErrorProvider.ValidationSucceededEventHandler(this.storeRowValidationProvider_ValidationSucceeded);
            // 
            // StoreRowEditFm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(490, 224);
            this.Controls.Add(this.validateLbl);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.nameTBox);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.groupControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StoreRowEditFm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Редактировать";
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numberingRGroup.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.columnCountTBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lineCountTBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cellCountTBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nameTBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.storeRowValidationProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.SimpleButton cancelBtn;
        private DevExpress.XtraEditors.SimpleButton saveBtn;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit columnCountTBox;
        private DevExpress.XtraEditors.TextEdit lineCountTBox;
        private DevExpress.XtraEditors.TextEdit cellCountTBox;
        private DevExpress.XtraEditors.PictureEdit pictureEdit1;
        private DevExpress.XtraEditors.RadioGroup numberingRGroup;
        private DevExpress.XtraEditors.PictureEdit pictureEdit3;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.TextEdit nameTBox;
        private DevExpress.XtraEditors.LabelControl validateLbl;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider storeRowValidationProvider;
    }
}