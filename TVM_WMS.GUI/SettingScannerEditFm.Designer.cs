namespace TVM_WMS.GUI
{
    partial class SettingScannerEditFm
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
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule5 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule6 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.baudRateEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.dataBitsEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.parityEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.stopBitsEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.portNameEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.nameTBox = new DevExpress.XtraEditors.TextEdit();
            this.saveBtn = new DevExpress.XtraEditors.SimpleButton();
            this.closeBtn = new DevExpress.XtraEditors.SimpleButton();
            this.validateLbl = new DevExpress.XtraEditors.LabelControl();
            this.scannerSettingValidationProvider = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.baudRateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataBitsEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.parityEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stopBitsEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.portNameEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nameTBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.scannerSettingValidationProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(4, 146);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(87, 13);
            this.label13.TabIndex = 48;
            this.label13.Text = "Стоповые биты";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(36, 120);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(55, 13);
            this.label12.TabIndex = 46;
            this.label12.Text = "Четность";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(16, 94);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(75, 13);
            this.label11.TabIndex = 44;
            this.label11.Text = "Биты данных";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 68);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 13);
            this.label8.TabIndex = 42;
            this.label8.Text = "Бит в секунду";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(34, 42);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 13);
            this.label7.TabIndex = 40;
            this.label7.Text = "COM порт";
            // 
            // baudRateEdit
            // 
            this.baudRateEdit.Location = new System.Drawing.Point(97, 65);
            this.baudRateEdit.Name = "baudRateEdit";
            this.baudRateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.baudRateEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Column", "BaudRate")});
            this.baudRateEdit.Properties.NullText = "";
            this.baudRateEdit.Properties.PopupSizeable = false;
            this.baudRateEdit.Properties.ShowHeader = false;
            this.baudRateEdit.Size = new System.Drawing.Size(352, 20);
            this.baudRateEdit.TabIndex = 3;
            conditionValidationRule1.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.Greater;
            conditionValidationRule1.ErrorText = "Выберите скорость порта";
            conditionValidationRule1.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical;
            conditionValidationRule1.Value1 = 0;
            this.scannerSettingValidationProvider.SetValidationRule(this.baudRateEdit, conditionValidationRule1);
            this.baudRateEdit.EditValueChanged += new System.EventHandler(this.baudRateEdit_EditValueChanged);
            // 
            // dataBitsEdit
            // 
            this.dataBitsEdit.Location = new System.Drawing.Point(97, 91);
            this.dataBitsEdit.Name = "dataBitsEdit";
            this.dataBitsEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dataBitsEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Column", "DataBits")});
            this.dataBitsEdit.Properties.NullText = "";
            this.dataBitsEdit.Properties.PopupSizeable = false;
            this.dataBitsEdit.Properties.ShowHeader = false;
            this.dataBitsEdit.Size = new System.Drawing.Size(352, 20);
            this.dataBitsEdit.TabIndex = 4;
            conditionValidationRule2.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.Greater;
            conditionValidationRule2.ErrorText = "Виберите биты данных";
            conditionValidationRule2.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical;
            conditionValidationRule2.Value1 = 0;
            this.scannerSettingValidationProvider.SetValidationRule(this.dataBitsEdit, conditionValidationRule2);
            this.dataBitsEdit.EditValueChanged += new System.EventHandler(this.dataBitsEdit_EditValueChanged);
            // 
            // parityEdit
            // 
            this.parityEdit.Location = new System.Drawing.Point(97, 117);
            this.parityEdit.Name = "parityEdit";
            this.parityEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.parityEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Column", "Parity")});
            this.parityEdit.Properties.NullText = "";
            this.parityEdit.Properties.PopupSizeable = false;
            this.parityEdit.Properties.ShowHeader = false;
            this.parityEdit.Size = new System.Drawing.Size(352, 20);
            this.parityEdit.TabIndex = 5;
            conditionValidationRule3.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.GreaterOrEqual;
            conditionValidationRule3.ErrorText = "Выберите четность порта";
            conditionValidationRule3.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical;
            conditionValidationRule3.Value1 = 0;
            this.scannerSettingValidationProvider.SetValidationRule(this.parityEdit, conditionValidationRule3);
            this.parityEdit.EditValueChanged += new System.EventHandler(this.parityEdit_EditValueChanged);
            // 
            // stopBitsEdit
            // 
            this.stopBitsEdit.Location = new System.Drawing.Point(97, 143);
            this.stopBitsEdit.Name = "stopBitsEdit";
            this.stopBitsEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.stopBitsEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Column", "StopBits")});
            this.stopBitsEdit.Properties.NullText = "";
            this.stopBitsEdit.Properties.PopupSizeable = false;
            this.stopBitsEdit.Properties.ShowHeader = false;
            this.stopBitsEdit.Size = new System.Drawing.Size(352, 20);
            this.stopBitsEdit.TabIndex = 6;
            conditionValidationRule4.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.GreaterOrEqual;
            conditionValidationRule4.ErrorText = "Выберите стоповые биты";
            conditionValidationRule4.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical;
            conditionValidationRule4.Value1 = 0;
            this.scannerSettingValidationProvider.SetValidationRule(this.stopBitsEdit, conditionValidationRule4);
            this.stopBitsEdit.EditValueChanged += new System.EventHandler(this.stopBitsEdit_EditValueChanged);
            // 
            // portNameEdit
            // 
            this.portNameEdit.Location = new System.Drawing.Point(97, 39);
            this.portNameEdit.Name = "portNameEdit";
            this.portNameEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.portNameEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Column", "COM порт")});
            this.portNameEdit.Properties.NullText = "";
            this.portNameEdit.Properties.PopupSizeable = false;
            this.portNameEdit.Properties.ShowHeader = false;
            this.portNameEdit.Size = new System.Drawing.Size(352, 20);
            this.portNameEdit.TabIndex = 2;
            conditionValidationRule5.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.Greater;
            conditionValidationRule5.ErrorText = "Выберите COM порт";
            conditionValidationRule5.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical;
            conditionValidationRule5.Value1 = 0;
            this.scannerSettingValidationProvider.SetValidationRule(this.portNameEdit, conditionValidationRule5);
            this.portNameEdit.EditValueChanged += new System.EventHandler(this.portNameEdit_EditValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 49;
            this.label1.Text = "Наименование";
            // 
            // nameTBox
            // 
            this.nameTBox.Location = new System.Drawing.Point(97, 13);
            this.nameTBox.Name = "nameTBox";
            this.nameTBox.Properties.Mask.IgnoreMaskBlank = false;
            this.nameTBox.Properties.Mask.ShowPlaceHolders = false;
            this.nameTBox.Size = new System.Drawing.Size(352, 20);
            this.nameTBox.TabIndex = 1;
            conditionValidationRule6.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule6.ErrorText = "Введите наименование сканера";
            conditionValidationRule6.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical;
            this.scannerSettingValidationProvider.SetValidationRule(this.nameTBox, conditionValidationRule6);
            this.nameTBox.TextChanged += new System.EventHandler(this.nameTBox_TextChanged);
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(293, 198);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(75, 23);
            this.saveBtn.TabIndex = 7;
            this.saveBtn.Text = "Сохранить";
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // closeBtn
            // 
            this.closeBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.closeBtn.Location = new System.Drawing.Point(374, 198);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(75, 23);
            this.closeBtn.TabIndex = 8;
            this.closeBtn.Text = "Отмена";
            this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
            // 
            // validateLbl
            // 
            this.validateLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.validateLbl.Appearance.BackColor = System.Drawing.SystemColors.Info;
            this.validateLbl.Appearance.ForeColor = System.Drawing.Color.OrangeRed;
            this.validateLbl.Location = new System.Drawing.Point(7, 202);
            this.validateLbl.Name = "validateLbl";
            this.validateLbl.Size = new System.Drawing.Size(263, 13);
            this.validateLbl.TabIndex = 53;
            this.validateLbl.Text = "*Для сохранения заполните все необходимые поля";
            // 
            // scannerSettingValidationProvider
            // 
            this.scannerSettingValidationProvider.ValidationMode = DevExpress.XtraEditors.DXErrorProvider.ValidationMode.Auto;
            this.scannerSettingValidationProvider.ValidationFailed += new DevExpress.XtraEditors.DXErrorProvider.ValidationFailedEventHandler(this.scannerSettingValidationProvider_ValidationFailed);
            this.scannerSettingValidationProvider.ValidationSucceeded += new DevExpress.XtraEditors.DXErrorProvider.ValidationSucceededEventHandler(this.scannerSettingValidationProvider_ValidationSucceeded);
            // 
            // SettingScannerEditFm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(461, 233);
            this.Controls.Add(this.validateLbl);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.closeBtn);
            this.Controls.Add(this.nameTBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.baudRateEdit);
            this.Controls.Add(this.dataBitsEdit);
            this.Controls.Add(this.parityEdit);
            this.Controls.Add(this.stopBitsEdit);
            this.Controls.Add(this.portNameEdit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingScannerEditFm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Редактировать настройки";
            ((System.ComponentModel.ISupportInitialize)(this.baudRateEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataBitsEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.parityEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stopBitsEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.portNameEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nameTBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.scannerSettingValidationProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private DevExpress.XtraEditors.LookUpEdit baudRateEdit;
        private DevExpress.XtraEditors.LookUpEdit dataBitsEdit;
        private DevExpress.XtraEditors.LookUpEdit parityEdit;
        private DevExpress.XtraEditors.LookUpEdit stopBitsEdit;
        private DevExpress.XtraEditors.LookUpEdit portNameEdit;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.TextEdit nameTBox;
        private DevExpress.XtraEditors.SimpleButton saveBtn;
        private DevExpress.XtraEditors.SimpleButton closeBtn;
        private DevExpress.XtraEditors.LabelControl validateLbl;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider scannerSettingValidationProvider;
    }
}