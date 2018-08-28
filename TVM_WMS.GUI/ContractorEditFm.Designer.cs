namespace TVM_WMS.GUI
{
    partial class ContractorEditFm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ContractorEditFm));
            this.nameTBox = new DevExpress.XtraEditors.TextEdit();
            this.shortNameTBox = new DevExpress.XtraEditors.TextEdit();
            this.srnTBox = new DevExpress.XtraEditors.TextEdit();
            this.tinTBox = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.saveBtn = new DevExpress.XtraEditors.SimpleButton();
            this.cancelBtn = new DevExpress.XtraEditors.SimpleButton();
            this.validateLbl = new DevExpress.XtraEditors.LabelControl();
            this.contractorValidationProvider = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.nameTBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shortNameTBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.srnTBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tinTBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.contractorValidationProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // nameTBox
            // 
            this.nameTBox.Location = new System.Drawing.Point(94, 10);
            this.nameTBox.Name = "nameTBox";
            this.nameTBox.Properties.MaxLength = 200;
            this.nameTBox.Size = new System.Drawing.Size(500, 20);
            this.nameTBox.TabIndex = 1;
            conditionValidationRule1.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule1.ErrorText = "Поле Наименование обязательное для заполнения";
            conditionValidationRule1.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical;
            conditionValidationRule1.Value1 = "0";
            this.contractorValidationProvider.SetValidationRule(this.nameTBox, conditionValidationRule1);
            this.nameTBox.TextChanged += new System.EventHandler(this.nameTBox_TextChanged);
            // 
            // shortNameTBox
            // 
            this.shortNameTBox.Location = new System.Drawing.Point(94, 45);
            this.shortNameTBox.Name = "shortNameTBox";
            this.shortNameTBox.Properties.MaxLength = 100;
            this.shortNameTBox.Size = new System.Drawing.Size(216, 20);
            this.shortNameTBox.TabIndex = 2;
            // 
            // srnTBox
            // 
            this.srnTBox.Location = new System.Drawing.Point(94, 80);
            this.srnTBox.Name = "srnTBox";
            this.srnTBox.Properties.MaxLength = 12;
            this.srnTBox.Size = new System.Drawing.Size(216, 20);
            this.srnTBox.TabIndex = 3;
            // 
            // tinTBox
            // 
            this.tinTBox.Location = new System.Drawing.Point(94, 115);
            this.tinTBox.Name = "tinTBox";
            this.tinTBox.Properties.MaxLength = 12;
            this.tinTBox.Size = new System.Drawing.Size(216, 20);
            this.tinTBox.TabIndex = 4;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 12);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(76, 13);
            this.labelControl1.TabIndex = 4;
            this.labelControl1.Text = "Наименование ";
            // 
            // labelControl2
            // 
            this.labelControl2.AllowHtmlString = true;
            this.labelControl2.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.labelControl2.Location = new System.Drawing.Point(12, 41);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(72, 26);
            this.labelControl2.TabIndex = 5;
            this.labelControl2.Text = "Краткое<br>наименование";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(12, 84);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(20, 13);
            this.labelControl3.TabIndex = 6;
            this.labelControl3.Text = "Код";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(12, 118);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(46, 13);
            this.labelControl4.TabIndex = 7;
            this.labelControl4.Text = "Доп. код";
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(434, 154);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(75, 23);
            this.saveBtn.TabIndex = 5;
            this.saveBtn.Text = "Сохранить";
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(515, 154);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 6;
            this.cancelBtn.Text = "Отмена";
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // validateLbl
            // 
            this.validateLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.validateLbl.Appearance.BackColor = System.Drawing.SystemColors.Info;
            this.validateLbl.Appearance.ForeColor = System.Drawing.Color.OrangeRed;
            this.validateLbl.Location = new System.Drawing.Point(12, 159);
            this.validateLbl.Name = "validateLbl";
            this.validateLbl.Size = new System.Drawing.Size(263, 13);
            this.validateLbl.TabIndex = 33;
            this.validateLbl.Text = "*Для сохранения заполните все необходимые поля";
            // 
            // contractorValidationProvider
            // 
            this.contractorValidationProvider.ValidationMode = DevExpress.XtraEditors.DXErrorProvider.ValidationMode.Auto;
            this.contractorValidationProvider.ValidationFailed += new DevExpress.XtraEditors.DXErrorProvider.ValidationFailedEventHandler(this.contractorValidationProvider_ValidationFailed);
            this.contractorValidationProvider.ValidationSucceeded += new DevExpress.XtraEditors.DXErrorProvider.ValidationSucceededEventHandler(this.contractorValidationProvider_ValidationSucceeded);
            // 
            // ContractorEditFm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(606, 188);
            this.Controls.Add(this.validateLbl);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.tinTBox);
            this.Controls.Add(this.srnTBox);
            this.Controls.Add(this.shortNameTBox);
            this.Controls.Add(this.nameTBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ContractorEditFm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Контрагент";
            ((System.ComponentModel.ISupportInitialize)(this.nameTBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.shortNameTBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.srnTBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tinTBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.contractorValidationProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit nameTBox;
        private DevExpress.XtraEditors.TextEdit shortNameTBox;
        private DevExpress.XtraEditors.TextEdit srnTBox;
        private DevExpress.XtraEditors.TextEdit tinTBox;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.SimpleButton saveBtn;
        private DevExpress.XtraEditors.SimpleButton cancelBtn;
        private DevExpress.XtraEditors.LabelControl validateLbl;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider contractorValidationProvider;
    }
}