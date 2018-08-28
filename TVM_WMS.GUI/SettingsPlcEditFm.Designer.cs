namespace TVM_WMS.GUI
{
    partial class SettingsPlcEditFm
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
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule3 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule4 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            this.plcSettingValidationProvider = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
            this.slotTBox = new DevExpress.XtraEditors.TextEdit();
            this.rackTBox = new DevExpress.XtraEditors.TextEdit();
            this.ipTBox = new DevExpress.XtraEditors.TextEdit();
            this.nameTBox = new DevExpress.XtraEditors.TextEdit();
            this.validateLbl = new DevExpress.XtraEditors.LabelControl();
            this.saveBtn = new DevExpress.XtraEditors.SimpleButton();
            this.closeBtn = new DevExpress.XtraEditors.SimpleButton();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cpuTypeEdit = new DevExpress.XtraEditors.LookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.plcSettingValidationProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.slotTBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rackTBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipTBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nameTBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpuTypeEdit.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // plcSettingValidationProvider
            // 
            this.plcSettingValidationProvider.ValidationMode = DevExpress.XtraEditors.DXErrorProvider.ValidationMode.Auto;
            this.plcSettingValidationProvider.ValidationFailed += new DevExpress.XtraEditors.DXErrorProvider.ValidationFailedEventHandler(this.plcSettingValidationProvider_ValidationFailed);
            this.plcSettingValidationProvider.ValidationSucceeded += new DevExpress.XtraEditors.DXErrorProvider.ValidationSucceededEventHandler(this.plcSettingValidationProvider_ValidationSucceeded);
            // 
            // slotTBox
            // 
            this.slotTBox.Location = new System.Drawing.Point(130, 116);
            this.slotTBox.Name = "slotTBox";
            this.slotTBox.Properties.Mask.EditMask = "n0";
            this.slotTBox.Properties.Mask.IgnoreMaskBlank = false;
            this.slotTBox.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.slotTBox.Properties.Mask.ShowPlaceHolders = false;
            this.slotTBox.Size = new System.Drawing.Size(321, 20);
            this.slotTBox.TabIndex = 64;
            conditionValidationRule1.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.GreaterOrEqual;
            conditionValidationRule1.ErrorText = "Введите свойство \"Slot\" устройства";
            conditionValidationRule1.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical;
            conditionValidationRule1.Value1 = 0;
            this.plcSettingValidationProvider.SetValidationRule(this.slotTBox, conditionValidationRule1);
            this.slotTBox.TextChanged += new System.EventHandler(this.slotTBox_TextChanged);
            // 
            // rackTBox
            // 
            this.rackTBox.Location = new System.Drawing.Point(130, 90);
            this.rackTBox.Name = "rackTBox";
            this.rackTBox.Properties.Mask.EditMask = "n0";
            this.rackTBox.Properties.Mask.IgnoreMaskBlank = false;
            this.rackTBox.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.rackTBox.Properties.Mask.ShowPlaceHolders = false;
            this.rackTBox.Size = new System.Drawing.Size(321, 20);
            this.rackTBox.TabIndex = 63;
            conditionValidationRule2.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.GreaterOrEqual;
            conditionValidationRule2.ErrorText = "Введите свойство \"Rack\" устройства";
            conditionValidationRule2.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical;
            conditionValidationRule2.Value1 = 0;
            this.plcSettingValidationProvider.SetValidationRule(this.rackTBox, conditionValidationRule2);
            this.rackTBox.TextChanged += new System.EventHandler(this.rackTBox_TextChanged);
            // 
            // ipTBox
            // 
            this.ipTBox.Location = new System.Drawing.Point(130, 38);
            this.ipTBox.Name = "ipTBox";
            this.ipTBox.Properties.Mask.EditMask = "([1-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])(\\.([0-9]|[1-9][0-9]|1[0-9][0-9" +
    "]|2[0-4][0-9]|25[0-5])){3}";
            this.ipTBox.Properties.Mask.IgnoreMaskBlank = false;
            this.ipTBox.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.ipTBox.Properties.Mask.ShowPlaceHolders = false;
            this.ipTBox.Size = new System.Drawing.Size(321, 20);
            this.ipTBox.TabIndex = 61;
            conditionValidationRule3.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule3.ErrorText = "Введите IP адрес устройства";
            conditionValidationRule3.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical;
            this.plcSettingValidationProvider.SetValidationRule(this.ipTBox, conditionValidationRule3);
            this.ipTBox.TextChanged += new System.EventHandler(this.ipTBox_TextChanged);
            // 
            // nameTBox
            // 
            this.nameTBox.Location = new System.Drawing.Point(130, 12);
            this.nameTBox.Name = "nameTBox";
            this.nameTBox.Properties.Mask.IgnoreMaskBlank = false;
            this.nameTBox.Properties.Mask.ShowPlaceHolders = false;
            this.nameTBox.Size = new System.Drawing.Size(321, 20);
            this.nameTBox.TabIndex = 69;
            conditionValidationRule4.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule4.ErrorText = "Введите наименование устройства";
            conditionValidationRule4.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical;
            this.plcSettingValidationProvider.SetValidationRule(this.nameTBox, conditionValidationRule4);
            this.nameTBox.TextChanged += new System.EventHandler(this.nameTBox_TextChanged);
            // 
            // validateLbl
            // 
            this.validateLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.validateLbl.Appearance.BackColor = System.Drawing.SystemColors.Info;
            this.validateLbl.Appearance.ForeColor = System.Drawing.Color.OrangeRed;
            this.validateLbl.Location = new System.Drawing.Point(12, 231);
            this.validateLbl.Name = "validateLbl";
            this.validateLbl.Size = new System.Drawing.Size(263, 13);
            this.validateLbl.TabIndex = 60;
            this.validateLbl.Text = "*Для сохранения заполните все необходимые поля";
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(295, 226);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(75, 23);
            this.saveBtn.TabIndex = 56;
            this.saveBtn.Text = "Сохранить";
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // closeBtn
            // 
            this.closeBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.closeBtn.Location = new System.Drawing.Point(376, 226);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(75, 23);
            this.closeBtn.TabIndex = 57;
            this.closeBtn.Text = "Отмена";
            this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(41, 67);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(86, 13);
            this.label12.TabIndex = 68;
            this.label12.Text = "Тип процессора";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(69, 119);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(58, 13);
            this.label11.TabIndex = 67;
            this.label11.Text = "Слот(Slot)";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(52, 93);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(75, 13);
            this.label8.TabIndex = 66;
            this.label8.Text = "Стойка(Rack)";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 41);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(119, 13);
            this.label7.TabIndex = 65;
            this.label7.Text = "IP адрес контроллера";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(47, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 70;
            this.label1.Text = "Наименование";
            // 
            // cpuTypeEdit
            // 
            this.cpuTypeEdit.Location = new System.Drawing.Point(130, 64);
            this.cpuTypeEdit.Name = "cpuTypeEdit";
            this.cpuTypeEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cpuTypeEdit.Properties.NullText = "";
            this.cpuTypeEdit.Properties.PopupSizeable = false;
            this.cpuTypeEdit.Size = new System.Drawing.Size(321, 20);
            this.cpuTypeEdit.TabIndex = 62;
            this.cpuTypeEdit.EditValueChanged += new System.EventHandler(this.cpuCBox_EditValueChanged);
            // 
            // SettingsPlcEditFm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(463, 261);
            this.Controls.Add(this.nameTBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.slotTBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.rackTBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.ipTBox);
            this.Controls.Add(this.validateLbl);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.closeBtn);
            this.Controls.Add(this.cpuTypeEdit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsPlcEditFm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Редактировать настройки";
            ((System.ComponentModel.ISupportInitialize)(this.plcSettingValidationProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.slotTBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rackTBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipTBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nameTBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpuTypeEdit.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider plcSettingValidationProvider;
        private DevExpress.XtraEditors.LabelControl validateLbl;
        private DevExpress.XtraEditors.SimpleButton saveBtn;
        private DevExpress.XtraEditors.SimpleButton closeBtn;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private DevExpress.XtraEditors.TextEdit slotTBox;
        private System.Windows.Forms.Label label8;
        private DevExpress.XtraEditors.TextEdit rackTBox;
        private System.Windows.Forms.Label label7;
        private DevExpress.XtraEditors.TextEdit ipTBox;
        private DevExpress.XtraEditors.TextEdit nameTBox;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.LookUpEdit cpuTypeEdit;
    }
}