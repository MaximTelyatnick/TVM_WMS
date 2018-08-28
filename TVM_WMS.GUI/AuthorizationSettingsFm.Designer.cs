namespace TVM_WMS.GUI
{
    partial class AuthorizationSettingsFm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AuthorizationSettingsFm));
            this.cancelBtn = new DevExpress.XtraEditors.SimpleButton();
            this.saveBtn = new DevExpress.XtraEditors.SimpleButton();
            this.dbFilePathTBox = new DevExpress.XtraEditors.TextEdit();
            this.label5 = new System.Windows.Forms.Label();
            this.dbIpTBox = new DevExpress.XtraEditors.TextEdit();
            this.label6 = new System.Windows.Forms.Label();
            this.baseValidationProvider = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
            this.validateLbl = new DevExpress.XtraEditors.LabelControl();
            this.testDbBtn = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.dbFilePathTBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbIpTBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.baseValidationProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // cancelBtn
            // 
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.cancelBtn.Location = new System.Drawing.Point(389, 127);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(95, 23);
            this.cancelBtn.TabIndex = 44;
            this.cancelBtn.Text = "Отмена";
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // saveBtn
            // 
            this.saveBtn.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.saveBtn.Location = new System.Drawing.Point(288, 127);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(95, 23);
            this.saveBtn.TabIndex = 43;
            this.saveBtn.Text = "Сохранить";
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // dbFilePathTBox
            // 
            this.dbFilePathTBox.Location = new System.Drawing.Point(15, 64);
            this.dbFilePathTBox.Name = "dbFilePathTBox";
            this.dbFilePathTBox.Properties.Mask.IgnoreMaskBlank = false;
            this.dbFilePathTBox.Properties.Mask.ShowPlaceHolders = false;
            this.dbFilePathTBox.Size = new System.Drawing.Size(469, 20);
            this.dbFilePathTBox.TabIndex = 48;
            conditionValidationRule1.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule1.ErrorText = "Не введено имя файла базы данных";
            conditionValidationRule1.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical;
            this.baseValidationProvider.SetValidationRule(this.dbFilePathTBox, conditionValidationRule1);
            this.dbFilePathTBox.TextChanged += new System.EventHandler(this.dbFilePathTBox_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(315, 13);
            this.label5.TabIndex = 47;
            this.label5.Text = "База данных (имя файла с расширением .fdb или псевдоним)";
            // 
            // dbIpTBox
            // 
            this.dbIpTBox.Location = new System.Drawing.Point(15, 25);
            this.dbIpTBox.Name = "dbIpTBox";
            this.dbIpTBox.Properties.Mask.EditMask = "([1-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])(\\.([0-9]|[1-9][0-9]|1[0-9][0-9" +
    "]|2[0-4][0-9]|25[0-5])){3}";
            this.dbIpTBox.Properties.Mask.IgnoreMaskBlank = false;
            this.dbIpTBox.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.dbIpTBox.Properties.Mask.ShowPlaceHolders = false;
            this.dbIpTBox.Size = new System.Drawing.Size(469, 20);
            this.dbIpTBox.TabIndex = 45;
            conditionValidationRule2.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule2.ErrorText = "Не введено поле IP адрес или имя сервера";
            conditionValidationRule2.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical;
            this.baseValidationProvider.SetValidationRule(this.dbIpTBox, conditionValidationRule2);
            this.dbIpTBox.TextChanged += new System.EventHandler(this.dbIpTBox_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(229, 13);
            this.label6.TabIndex = 46;
            this.label6.Text = "IP адрес или DNS имя сервера базы данных";
            // 
            // baseValidationProvider
            // 
            this.baseValidationProvider.ValidationMode = DevExpress.XtraEditors.DXErrorProvider.ValidationMode.Auto;
            this.baseValidationProvider.ValidationFailed += new DevExpress.XtraEditors.DXErrorProvider.ValidationFailedEventHandler(this.baseValidationProvider_ValidationFailed);
            this.baseValidationProvider.ValidationSucceeded += new DevExpress.XtraEditors.DXErrorProvider.ValidationSucceededEventHandler(this.baseValidationProvider_ValidationSucceeded);
            // 
            // validateLbl
            // 
            this.validateLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.validateLbl.Appearance.BackColor = System.Drawing.SystemColors.Info;
            this.validateLbl.Appearance.ForeColor = System.Drawing.Color.OrangeRed;
            this.validateLbl.Location = new System.Drawing.Point(20, 133);
            this.validateLbl.Name = "validateLbl";
            this.validateLbl.Size = new System.Drawing.Size(263, 13);
            this.validateLbl.TabIndex = 61;
            this.validateLbl.Text = "*Для сохранения заполните все необходимые поля";
            // 
            // testDbBtn
            // 
            this.testDbBtn.Location = new System.Drawing.Point(15, 90);
            this.testDbBtn.Name = "testDbBtn";
            this.testDbBtn.Size = new System.Drawing.Size(114, 23);
            this.testDbBtn.TabIndex = 62;
            this.testDbBtn.Text = "Тест соединения";
            this.testDbBtn.Click += new System.EventHandler(this.testDbBtn_Click);
            // 
            // AuthorizationSettingsFm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(496, 162);
            this.Controls.Add(this.testDbBtn);
            this.Controls.Add(this.validateLbl);
            this.Controls.Add(this.dbFilePathTBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dbIpTBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.saveBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AuthorizationSettingsFm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Настройки базы данных";
            ((System.ComponentModel.ISupportInitialize)(this.dbFilePathTBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbIpTBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.baseValidationProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton cancelBtn;
        private DevExpress.XtraEditors.SimpleButton saveBtn;
        private DevExpress.XtraEditors.TextEdit dbFilePathTBox;
        private System.Windows.Forms.Label label5;
        private DevExpress.XtraEditors.TextEdit dbIpTBox;
        private System.Windows.Forms.Label label6;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider baseValidationProvider;
        private DevExpress.XtraEditors.LabelControl validateLbl;
        private DevExpress.XtraEditors.SimpleButton testDbBtn;
    }
}