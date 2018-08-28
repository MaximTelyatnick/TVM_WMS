namespace TVM_WMS.GUI
{
    partial class MaterialGroupEditFm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MaterialGroupEditFm));
            this.isRootGroupChBox = new DevExpress.XtraEditors.CheckEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.nameTBox = new DevExpress.XtraEditors.TextEdit();
            this.codeTBox = new DevExpress.XtraEditors.TextEdit();
            this.cancelBtn = new DevExpress.XtraEditors.SimpleButton();
            this.saveBtn = new DevExpress.XtraEditors.SimpleButton();
            this.validateLbl = new DevExpress.XtraEditors.LabelControl();
            this.materialGroupValidationProvider = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.isRootGroupChBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nameTBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.codeTBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.materialGroupValidationProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // isRootGroupChBox
            // 
            this.isRootGroupChBox.Location = new System.Drawing.Point(9, 73);
            this.isRootGroupChBox.Name = "isRootGroupChBox";
            this.isRootGroupChBox.Properties.Caption = "Корневая группа";
            this.isRootGroupChBox.Size = new System.Drawing.Size(113, 19);
            this.isRootGroupChBox.TabIndex = 13;
            this.isRootGroupChBox.CheckedChanged += new System.EventHandler(this.isRootGroupChBox_CheckedChanged);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(9, 43);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(73, 13);
            this.labelControl2.TabIndex = 12;
            this.labelControl2.Text = "Наименование";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(9, 14);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(60, 13);
            this.labelControl1.TabIndex = 11;
            this.labelControl1.Text = "Код группы";
            // 
            // nameTBox
            // 
            this.nameTBox.Location = new System.Drawing.Point(88, 40);
            this.nameTBox.Name = "nameTBox";
            this.nameTBox.Properties.MaxLength = 75;
            this.nameTBox.Size = new System.Drawing.Size(503, 20);
            this.nameTBox.TabIndex = 2;
            conditionValidationRule1.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule1.ErrorText = "Поле НАИМЕНОВАНИЕ обязательное для заполнения";
            conditionValidationRule1.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical;
            this.materialGroupValidationProvider.SetValidationRule(this.nameTBox, conditionValidationRule1);
            this.nameTBox.TextChanged += new System.EventHandler(this.nameTBox_TextChanged);
            // 
            // codeTBox
            // 
            this.codeTBox.Location = new System.Drawing.Point(88, 11);
            this.codeTBox.Name = "codeTBox";
            this.codeTBox.Properties.MaxLength = 25;
            this.codeTBox.Size = new System.Drawing.Size(131, 20);
            this.codeTBox.TabIndex = 1;
            conditionValidationRule2.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule2.ErrorText = "Поле КОД обязательное для заполнения";
            conditionValidationRule2.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical;
            this.materialGroupValidationProvider.SetValidationRule(this.codeTBox, conditionValidationRule2);
            this.codeTBox.TextChanged += new System.EventHandler(this.codeTBox_TextChanged);
            // 
            // cancelBtn
            // 
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Location = new System.Drawing.Point(543, 99);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 4;
            this.cancelBtn.Text = "Отмена";
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(462, 99);
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
            this.validateLbl.Location = new System.Drawing.Point(9, 104);
            this.validateLbl.Name = "validateLbl";
            this.validateLbl.Size = new System.Drawing.Size(263, 13);
            this.validateLbl.TabIndex = 32;
            this.validateLbl.Text = "*Для сохранения заполните все необходимые поля";
            // 
            // materialGroupValidationProvider
            // 
            this.materialGroupValidationProvider.ValidationFailed += new DevExpress.XtraEditors.DXErrorProvider.ValidationFailedEventHandler(this.materialValidationProvider_ValidationFailed);
            this.materialGroupValidationProvider.ValidationSucceeded += new DevExpress.XtraEditors.DXErrorProvider.ValidationSucceededEventHandler(this.materialValidationProvider_ValidationSucceeded);
            // 
            // MaterialGroupEditFm
            // 
            this.AcceptButton = this.saveBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(630, 133);
            this.Controls.Add(this.validateLbl);
            this.Controls.Add(this.isRootGroupChBox);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.nameTBox);
            this.Controls.Add(this.codeTBox);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.saveBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MaterialGroupEditFm";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Группа";
            ((System.ComponentModel.ISupportInitialize)(this.isRootGroupChBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nameTBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.codeTBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.materialGroupValidationProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.CheckEdit isRootGroupChBox;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit nameTBox;
        private DevExpress.XtraEditors.TextEdit codeTBox;
        private DevExpress.XtraEditors.SimpleButton cancelBtn;
        private DevExpress.XtraEditors.SimpleButton saveBtn;
        private DevExpress.XtraEditors.LabelControl validateLbl;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider materialGroupValidationProvider;
    }
}