namespace TVM_WMS.GUI
{
    partial class UserEditFm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserEditFm));
            this.validateLbl = new DevExpress.XtraEditors.LabelControl();
            this.cancelBtn = new DevExpress.XtraEditors.SimpleButton();
            this.saveBtn = new DevExpress.XtraEditors.SimpleButton();
            this.userValidationProvider = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
            this.fioTBox = new DevExpress.XtraEditors.TextEdit();
            this.loginTBox = new DevExpress.XtraEditors.TextEdit();
            this.roleEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.passwordTBox = new DevExpress.XtraEditors.TextEdit();
            this.passwordChk = new DevExpress.XtraEditors.CheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.userValidationProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fioTBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.loginTBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.roleEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.passwordTBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.passwordChk.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // validateLbl
            // 
            this.validateLbl.Appearance.BackColor = System.Drawing.SystemColors.Info;
            this.validateLbl.Appearance.ForeColor = System.Drawing.Color.OrangeRed;
            this.validateLbl.Location = new System.Drawing.Point(3, 300);
            this.validateLbl.Name = "validateLbl";
            this.validateLbl.Size = new System.Drawing.Size(263, 13);
            this.validateLbl.TabIndex = 30;
            this.validateLbl.Text = "*Для сохранения заполните все необходимые поля";
            // 
            // cancelBtn
            // 
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Location = new System.Drawing.Point(374, 295);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 29;
            this.cancelBtn.Text = "Отмена";
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // saveBtn
            // 
            this.saveBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.saveBtn.Location = new System.Drawing.Point(293, 295);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(75, 23);
            this.saveBtn.TabIndex = 28;
            this.saveBtn.Text = "Сохранить";
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // userValidationProvider
            // 
            this.userValidationProvider.ValidationMode = DevExpress.XtraEditors.DXErrorProvider.ValidationMode.Auto;
            this.userValidationProvider.ValidationFailed += new DevExpress.XtraEditors.DXErrorProvider.ValidationFailedEventHandler(this.userValidationProvider_ValidationFailed);
            this.userValidationProvider.ValidationSucceeded += new DevExpress.XtraEditors.DXErrorProvider.ValidationSucceededEventHandler(this.userValidationProvider_ValidationSucceeded);
            // 
            // fioTBox
            // 
            this.fioTBox.Location = new System.Drawing.Point(55, 12);
            this.fioTBox.Name = "fioTBox";
            this.fioTBox.Properties.Mask.ShowPlaceHolders = false;
            this.fioTBox.Size = new System.Drawing.Size(394, 20);
            this.fioTBox.TabIndex = 31;
            conditionValidationRule1.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule1.ErrorText = "Поле ФИО обязательное для заполнения";
            conditionValidationRule1.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical;
            this.userValidationProvider.SetValidationRule(this.fioTBox, conditionValidationRule1);
            this.fioTBox.TextChanged += new System.EventHandler(this.fioTBox_TextChanged);
            // 
            // loginTBox
            // 
            this.loginTBox.Location = new System.Drawing.Point(55, 38);
            this.loginTBox.Name = "loginTBox";
            this.loginTBox.Properties.Mask.ShowPlaceHolders = false;
            this.loginTBox.Size = new System.Drawing.Size(394, 20);
            this.loginTBox.TabIndex = 35;
            conditionValidationRule2.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule2.ErrorText = "Поле логин обязательное для заполнения";
            conditionValidationRule2.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical;
            this.userValidationProvider.SetValidationRule(this.loginTBox, conditionValidationRule2);
            this.loginTBox.TextChanged += new System.EventHandler(this.loginTBox_TextChanged);
            // 
            // roleEdit
            // 
            this.roleEdit.Location = new System.Drawing.Point(55, 115);
            this.roleEdit.Name = "roleEdit";
            this.roleEdit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.roleEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.roleEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("RoleName", "Группа")});
            this.roleEdit.Properties.ImmediatePopup = true;
            this.roleEdit.Properties.PopupWidth = 553;
            this.roleEdit.Properties.ShowHeader = false;
            this.roleEdit.Size = new System.Drawing.Size(394, 20);
            this.roleEdit.TabIndex = 34;
            conditionValidationRule3.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.Greater;
            conditionValidationRule3.ErrorText = "Не выбрана группа";
            conditionValidationRule3.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical;
            conditionValidationRule3.Value1 = 0;
            this.userValidationProvider.SetValidationRule(this.roleEdit, conditionValidationRule3);
            this.roleEdit.EditValueChanged += new System.EventHandler(this.roleEdit_EditValueChanged);
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(13, 118);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(36, 13);
            this.labelControl3.TabIndex = 33;
            this.labelControl3.Text = "Группа";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(15, 15);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(35, 13);
            this.labelControl1.TabIndex = 32;
            this.labelControl1.Text = "Ф.И.О.";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(20, 41);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(30, 13);
            this.labelControl2.TabIndex = 36;
            this.labelControl2.Text = "Логин";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(13, 67);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(37, 13);
            this.labelControl4.TabIndex = 38;
            this.labelControl4.Text = "Пароль";
            // 
            // passwordTBox
            // 
            this.passwordTBox.Location = new System.Drawing.Point(55, 64);
            this.passwordTBox.Name = "passwordTBox";
            this.passwordTBox.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.passwordTBox.Properties.Appearance.Options.UseFont = true;
            this.passwordTBox.Properties.Mask.ShowPlaceHolders = false;
            this.passwordTBox.Properties.UseSystemPasswordChar = true;
            this.passwordTBox.Size = new System.Drawing.Size(394, 20);
            this.passwordTBox.TabIndex = 37;
            this.passwordTBox.TextChanged += new System.EventHandler(this.passwordTBox_TextChanged);
            // 
            // passwordChk
            // 
            this.passwordChk.Location = new System.Drawing.Point(55, 90);
            this.passwordChk.Name = "passwordChk";
            this.passwordChk.Properties.Caption = "Отобразить символы";
            this.passwordChk.Size = new System.Drawing.Size(131, 19);
            this.passwordChk.TabIndex = 39;
            this.passwordChk.CheckedChanged += new System.EventHandler(this.passwordChk_CheckedChanged);
            // 
            // UserEditFm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.CancelButton = this.cancelBtn;
            this.ClientSize = new System.Drawing.Size(462, 330);
            this.Controls.Add(this.passwordChk);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.passwordTBox);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.loginTBox);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.fioTBox);
            this.Controls.Add(this.validateLbl);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.roleEdit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UserEditFm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Редактировать";
            ((System.ComponentModel.ISupportInitialize)(this.userValidationProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fioTBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.loginTBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.roleEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.passwordTBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.passwordChk.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl validateLbl;
        private DevExpress.XtraEditors.SimpleButton cancelBtn;
        private DevExpress.XtraEditors.SimpleButton saveBtn;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider userValidationProvider;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit fioTBox;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit loginTBox;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit passwordTBox;
        private DevExpress.XtraEditors.CheckEdit passwordChk;
        private DevExpress.XtraEditors.LookUpEdit roleEdit;
    }
}