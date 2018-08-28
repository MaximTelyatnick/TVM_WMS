namespace TVM_WMS.GUI
{
    partial class AlarmEditFm
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
            this.validateLbl = new DevExpress.XtraEditors.LabelControl();
            this.cancelBtn = new DevExpress.XtraEditors.SimpleButton();
            this.saveBtn = new DevExpress.XtraEditors.SimpleButton();
            this.alarmValidationProvider = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.alarmNumberTBox = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.alarmTextTBox = new DevExpress.XtraEditors.MemoEdit();
            ((System.ComponentModel.ISupportInitialize)(this.alarmValidationProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.alarmNumberTBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.alarmTextTBox.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // validateLbl
            // 
            this.validateLbl.Appearance.BackColor = System.Drawing.SystemColors.Info;
            this.validateLbl.Appearance.ForeColor = System.Drawing.Color.OrangeRed;
            this.validateLbl.Location = new System.Drawing.Point(12, 175);
            this.validateLbl.Name = "validateLbl";
            this.validateLbl.Size = new System.Drawing.Size(263, 13);
            this.validateLbl.TabIndex = 41;
            this.validateLbl.Text = "*Для сохранения заполните все необходимые поля";
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(432, 170);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 40;
            this.cancelBtn.Text = "Отмена";
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(351, 170);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(75, 23);
            this.saveBtn.TabIndex = 39;
            this.saveBtn.Text = "Сохранить";
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // alarmValidationProvider
            // 
            this.alarmValidationProvider.ValidationMode = DevExpress.XtraEditors.DXErrorProvider.ValidationMode.Auto;
            this.alarmValidationProvider.ValidationFailed += new DevExpress.XtraEditors.DXErrorProvider.ValidationFailedEventHandler(this.alarmValidationProvider_ValidationFailed);
            this.alarmValidationProvider.ValidationSucceeded += new DevExpress.XtraEditors.DXErrorProvider.ValidationSucceededEventHandler(this.alarmValidationProvider_ValidationSucceeded);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(12, 12);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(61, 13);
            this.labelControl2.TabIndex = 43;
            this.labelControl2.Text = "Код ошибки";
            // 
            // alarmNumberTBox
            // 
            this.alarmNumberTBox.Location = new System.Drawing.Point(12, 31);
            this.alarmNumberTBox.Name = "alarmNumberTBox";
            this.alarmNumberTBox.Properties.Mask.EditMask = "n0";
            this.alarmNumberTBox.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.alarmNumberTBox.Size = new System.Drawing.Size(495, 20);
            this.alarmNumberTBox.TabIndex = 42;
            conditionValidationRule1.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.Greater;
            conditionValidationRule1.ErrorText = "Введите код ошибки";
            conditionValidationRule1.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical;
            conditionValidationRule1.Value1 = 0;
            this.alarmValidationProvider.SetValidationRule(this.alarmNumberTBox, conditionValidationRule1);
            this.alarmNumberTBox.TextChanged += new System.EventHandler(this.alarmNumberTBox_TextChanged);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 57);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(70, 13);
            this.labelControl1.TabIndex = 45;
            this.labelControl1.Text = "Текст ошибки";
            // 
            // alarmTextTBox
            // 
            this.alarmTextTBox.Location = new System.Drawing.Point(12, 76);
            this.alarmTextTBox.Name = "alarmTextTBox";
            this.alarmTextTBox.Size = new System.Drawing.Size(495, 88);
            this.alarmTextTBox.TabIndex = 44;
            conditionValidationRule2.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule2.ErrorText = "Введите текст ошибки";
            conditionValidationRule2.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical;
            this.alarmValidationProvider.SetValidationRule(this.alarmTextTBox, conditionValidationRule2);
            this.alarmTextTBox.TextChanged += new System.EventHandler(this.alarmTextTBox_TextChanged);
            // 
            // AlarmEditFm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(519, 205);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.alarmNumberTBox);
            this.Controls.Add(this.validateLbl);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.alarmTextTBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AlarmEditFm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Журнал сообщений об ошибках";
            ((System.ComponentModel.ISupportInitialize)(this.alarmValidationProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.alarmNumberTBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.alarmTextTBox.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl validateLbl;
        private DevExpress.XtraEditors.SimpleButton cancelBtn;
        private DevExpress.XtraEditors.SimpleButton saveBtn;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider alarmValidationProvider;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit alarmNumberTBox;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.MemoEdit alarmTextTBox;
    }
}