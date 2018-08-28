namespace TVM_WMS.GUI
{
    partial class UnitEditFm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UnitEditFm));
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.unitFullNameTBox = new DevExpress.XtraEditors.TextEdit();
            this.unitLocalNameTBox = new DevExpress.XtraEditors.TextEdit();
            this.cancelBtn = new DevExpress.XtraEditors.SimpleButton();
            this.saveBtn = new DevExpress.XtraEditors.SimpleButton();
            this.validateLbl = new DevExpress.XtraEditors.LabelControl();
            this.unitValidationProvider = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.unitFullNameTBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.unitLocalNameTBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.unitValidationProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(12, 50);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(73, 13);
            this.labelControl2.TabIndex = 18;
            this.labelControl2.Text = "Наименование";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(13, 14);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(61, 13);
            this.labelControl1.TabIndex = 17;
            this.labelControl1.Text = "Код ед.изм.";
            // 
            // unitFullNameTBox
            // 
            this.unitFullNameTBox.Location = new System.Drawing.Point(91, 47);
            this.unitFullNameTBox.Name = "unitFullNameTBox";
            this.unitFullNameTBox.Properties.MaxLength = 100;
            this.unitFullNameTBox.Size = new System.Drawing.Size(503, 20);
            this.unitFullNameTBox.TabIndex = 2;
            conditionValidationRule1.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule1.ErrorText = "Поле Наименование обязательное для заполнения";
            conditionValidationRule1.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical;
            this.unitValidationProvider.SetValidationRule(this.unitFullNameTBox, conditionValidationRule1);
            this.unitFullNameTBox.TextChanged += new System.EventHandler(this.unitFullName_TextChanged);
            // 
            // unitLocalNameTBox
            // 
            this.unitLocalNameTBox.Location = new System.Drawing.Point(93, 12);
            this.unitLocalNameTBox.Name = "unitLocalNameTBox";
            this.unitLocalNameTBox.Properties.AllowFocused = false;
            this.unitLocalNameTBox.Properties.Mask.EditMask = "\\p{L}+";
            this.unitLocalNameTBox.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.unitLocalNameTBox.Properties.MaxLength = 20;
            this.unitLocalNameTBox.Size = new System.Drawing.Size(129, 20);
            this.unitLocalNameTBox.TabIndex = 1;
            conditionValidationRule2.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule2.ErrorText = "Поле  Код обязательное для заполнения";
            conditionValidationRule2.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical;
            this.unitValidationProvider.SetValidationRule(this.unitLocalNameTBox, conditionValidationRule2);
            this.unitLocalNameTBox.TextChanged += new System.EventHandler(this.unitLocalNameTBox_TextChanged);
            // 
            // cancelBtn
            // 
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Location = new System.Drawing.Point(520, 88);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 14;
            this.cancelBtn.Text = "Отмена";
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(439, 88);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(75, 23);
            this.saveBtn.TabIndex = 3;
            this.saveBtn.Text = "Сохранить";
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // validateLbl
            // 
            this.validateLbl.Appearance.BackColor = System.Drawing.SystemColors.Info;
            this.validateLbl.Appearance.ForeColor = System.Drawing.Color.OrangeRed;
            this.validateLbl.Location = new System.Drawing.Point(13, 92);
            this.validateLbl.Name = "validateLbl";
            this.validateLbl.Size = new System.Drawing.Size(263, 13);
            this.validateLbl.TabIndex = 32;
            this.validateLbl.Text = "*Для сохранения заполните все необходимые поля";
            // 
            // unitValidationProvider
            // 
            this.unitValidationProvider.ValidationMode = DevExpress.XtraEditors.DXErrorProvider.ValidationMode.Auto;
            this.unitValidationProvider.ValidationFailed += new DevExpress.XtraEditors.DXErrorProvider.ValidationFailedEventHandler(this.unitValidationProvider_ValidationFailed);
            this.unitValidationProvider.ValidationSucceeded += new DevExpress.XtraEditors.DXErrorProvider.ValidationSucceededEventHandler(this.unitValidationProvider_ValidationSucceeded);
            // 
            // UnitEditFm
            // 
            this.AcceptButton = this.saveBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.CancelButton = this.cancelBtn;
            this.ClientSize = new System.Drawing.Size(606, 122);
            this.Controls.Add(this.validateLbl);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.unitFullNameTBox);
            this.Controls.Add(this.unitLocalNameTBox);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.saveBtn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UnitEditFm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Единица измерения";
            ((System.ComponentModel.ISupportInitialize)(this.unitFullNameTBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.unitLocalNameTBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.unitValidationProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit unitFullNameTBox;
        private DevExpress.XtraEditors.TextEdit unitLocalNameTBox;
        private DevExpress.XtraEditors.SimpleButton cancelBtn;
        private DevExpress.XtraEditors.SimpleButton saveBtn;
        private DevExpress.XtraEditors.LabelControl validateLbl;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider unitValidationProvider;
    }
}