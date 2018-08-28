namespace TVM_WMS.GUI
{
    partial class SettingsDropoffWindEditFm
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
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule1 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule2 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            this.nameTBox = new DevExpress.XtraEditors.TextEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.validateLbl = new DevExpress.XtraEditors.LabelControl();
            this.saveBtn = new DevExpress.XtraEditors.SimpleButton();
            this.closeBtn = new DevExpress.XtraEditors.SimpleButton();
            this.windNumberTBox = new DevExpress.XtraEditors.TextEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.dropoffSettingValidationProvider = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.nameTBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.windNumberTBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dropoffSettingValidationProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // nameTBox
            // 
            this.nameTBox.Location = new System.Drawing.Point(102, 12);
            this.nameTBox.Name = "nameTBox";
            this.nameTBox.Properties.Mask.IgnoreMaskBlank = false;
            this.nameTBox.Properties.Mask.ShowPlaceHolders = false;
            this.nameTBox.Size = new System.Drawing.Size(345, 20);
            this.nameTBox.TabIndex = 76;
            conditionValidationRule1.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule1.ErrorText = "Введите наименование";
            conditionValidationRule1.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical;
            this.dropoffSettingValidationProvider.SetValidationRule(this.nameTBox, conditionValidationRule1);
            this.nameTBox.TextChanged += new System.EventHandler(this.nameTBox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 77;
            this.label1.Text = "Наименование";
            // 
            // validateLbl
            // 
            this.validateLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.validateLbl.Appearance.BackColor = System.Drawing.SystemColors.Info;
            this.validateLbl.Appearance.ForeColor = System.Drawing.Color.OrangeRed;
            this.validateLbl.Location = new System.Drawing.Point(22, 86);
            this.validateLbl.Name = "validateLbl";
            this.validateLbl.Size = new System.Drawing.Size(263, 13);
            this.validateLbl.TabIndex = 75;
            this.validateLbl.Text = "*Для сохранения заполните все необходимые поля";
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(291, 81);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(75, 23);
            this.saveBtn.TabIndex = 73;
            this.saveBtn.Text = "Сохранить";
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // closeBtn
            // 
            this.closeBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.closeBtn.Location = new System.Drawing.Point(372, 81);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(75, 23);
            this.closeBtn.TabIndex = 74;
            this.closeBtn.Text = "Отмена";
            this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
            // 
            // windNumberTBox
            // 
            this.windNumberTBox.Location = new System.Drawing.Point(102, 38);
            this.windNumberTBox.Name = "windNumberTBox";
            this.windNumberTBox.Properties.Mask.EditMask = "n0";
            this.windNumberTBox.Properties.Mask.IgnoreMaskBlank = false;
            this.windNumberTBox.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.windNumberTBox.Properties.Mask.ShowPlaceHolders = false;
            this.windNumberTBox.Size = new System.Drawing.Size(74, 20);
            this.windNumberTBox.TabIndex = 78;
            conditionValidationRule2.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule2.ErrorText = "Введите номер окна выдачи";
            conditionValidationRule2.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical;
            this.dropoffSettingValidationProvider.SetValidationRule(this.windNumberTBox, conditionValidationRule2);
            this.windNumberTBox.TextChanged += new System.EventHandler(this.textEdit1_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 79;
            this.label2.Text = "Номер окна";
            // 
            // dropoffSettingValidationProvider
            // 
            this.dropoffSettingValidationProvider.ValidationMode = DevExpress.XtraEditors.DXErrorProvider.ValidationMode.Auto;
            this.dropoffSettingValidationProvider.ValidationFailed += new DevExpress.XtraEditors.DXErrorProvider.ValidationFailedEventHandler(this.dropoffSettingValidationProvider_ValidationFailed);
            this.dropoffSettingValidationProvider.ValidationSucceeded += new DevExpress.XtraEditors.DXErrorProvider.ValidationSucceededEventHandler(this.dropoffSettingValidationProvider_ValidationSucceeded);
            // 
            // SettingsDropoffWindEditFm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(459, 116);
            this.Controls.Add(this.windNumberTBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nameTBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.validateLbl);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.closeBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsDropoffWindEditFm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Редактирование";
            ((System.ComponentModel.ISupportInitialize)(this.nameTBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.windNumberTBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dropoffSettingValidationProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit nameTBox;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.LabelControl validateLbl;
        private DevExpress.XtraEditors.SimpleButton saveBtn;
        private DevExpress.XtraEditors.SimpleButton closeBtn;
        private DevExpress.XtraEditors.TextEdit windNumberTBox;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider dropoffSettingValidationProvider;
    }
}