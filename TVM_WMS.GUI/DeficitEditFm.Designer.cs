namespace TVM_WMS.GUI
{
    partial class DeficitEditFm
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
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule2 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DeficitEditFm));
            this.articleTBox = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.rateTBox = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.unitLocalNameTBox = new DevExpress.XtraEditors.TextEdit();
            this.nameTBox = new DevExpress.XtraEditors.TextEdit();
            this.saveBtn = new DevExpress.XtraEditors.SimpleButton();
            this.cancelBtn = new DevExpress.XtraEditors.SimpleButton();
            this.deficitValidationProvider = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
            this.validateLbl = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.articleTBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rateTBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.unitLocalNameTBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nameTBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deficitValidationProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // articleTBox
            // 
            this.articleTBox.Enabled = false;
            this.articleTBox.Location = new System.Drawing.Point(104, 10);
            this.articleTBox.Name = "articleTBox";
            this.articleTBox.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black;
            this.articleTBox.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.articleTBox.Size = new System.Drawing.Size(125, 20);
            this.articleTBox.TabIndex = 2;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(15, 15);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(20, 13);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "Код";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.labelControl4);
            this.panelControl1.Controls.Add(this.rateTBox);
            this.panelControl1.Controls.Add(this.labelControl3);
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Controls.Add(this.unitLocalNameTBox);
            this.panelControl1.Controls.Add(this.nameTBox);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Controls.Add(this.articleTBox);
            this.panelControl1.Location = new System.Drawing.Point(3, 2);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(522, 141);
            this.panelControl1.TabIndex = 2;
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl4.Appearance.ForeColor = System.Drawing.Color.Maroon;
            this.labelControl4.Location = new System.Drawing.Point(15, 108);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(83, 13);
            this.labelControl4.TabIndex = 7;
            this.labelControl4.Text = "Норма в сутки";
            // 
            // rateTBox
            // 
            this.rateTBox.EditValue = "0,00";
            this.rateTBox.Location = new System.Drawing.Point(104, 105);
            this.rateTBox.Name = "rateTBox";
            this.rateTBox.Properties.Appearance.Options.UseTextOptions = true;
            this.rateTBox.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.rateTBox.Properties.DisplayFormat.FormatString = "0,00";
            this.rateTBox.Properties.Mask.EditMask = "f";
            this.rateTBox.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.rateTBox.Properties.NullText = "0.00";
            this.rateTBox.Size = new System.Drawing.Size(125, 20);
            this.rateTBox.TabIndex = 1;
            conditionValidationRule2.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.GreaterOrEqual;
            conditionValidationRule2.ErrorText = "Поле Норма должно быть больше или равно 0";
            conditionValidationRule2.Value1 = "0";
            this.deficitValidationProvider.SetValidationRule(this.rateTBox, conditionValidationRule2);
            this.rateTBox.TextChanged += new System.EventHandler(this.rateTBox_TextChanged);
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(16, 67);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(73, 13);
            this.labelControl3.TabIndex = 5;
            this.labelControl3.Text = "Ед. измерения";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(15, 41);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(73, 13);
            this.labelControl2.TabIndex = 4;
            this.labelControl2.Text = "Наименование";
            // 
            // unitLocalNameTBox
            // 
            this.unitLocalNameTBox.Enabled = false;
            this.unitLocalNameTBox.Location = new System.Drawing.Point(105, 64);
            this.unitLocalNameTBox.Name = "unitLocalNameTBox";
            this.unitLocalNameTBox.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black;
            this.unitLocalNameTBox.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.unitLocalNameTBox.Size = new System.Drawing.Size(125, 20);
            this.unitLocalNameTBox.TabIndex = 4;
            // 
            // nameTBox
            // 
            this.nameTBox.Enabled = false;
            this.nameTBox.Location = new System.Drawing.Point(104, 38);
            this.nameTBox.Name = "nameTBox";
            this.nameTBox.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black;
            this.nameTBox.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.nameTBox.Size = new System.Drawing.Size(407, 20);
            this.nameTBox.TabIndex = 3;
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(362, 152);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(75, 23);
            this.saveBtn.TabIndex = 3;
            this.saveBtn.Text = "Сохранить";
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Location = new System.Drawing.Point(443, 152);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 4;
            this.cancelBtn.Text = "Отмена";
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // deficitValidationProvider
            // 
            this.deficitValidationProvider.ValidationFailed += new DevExpress.XtraEditors.DXErrorProvider.ValidationFailedEventHandler(this.deficitValidationProvider_ValidationFailed);
            this.deficitValidationProvider.ValidationSucceeded += new DevExpress.XtraEditors.DXErrorProvider.ValidationSucceededEventHandler(this.deficitValidationProvider_ValidationSucceeded);
            // 
            // validateLbl
            // 
            this.validateLbl.Appearance.BackColor = System.Drawing.SystemColors.Info;
            this.validateLbl.Appearance.ForeColor = System.Drawing.Color.OrangeRed;
            this.validateLbl.Location = new System.Drawing.Point(18, 157);
            this.validateLbl.Name = "validateLbl";
            this.validateLbl.Size = new System.Drawing.Size(263, 13);
            this.validateLbl.TabIndex = 32;
            this.validateLbl.Text = "*Для сохранения заполните все необходимые поля";
            // 
            // DeficitEditFm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(529, 186);
            this.Controls.Add(this.validateLbl);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.panelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DeficitEditFm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Суточная норма расхода материала";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.DeficitEditFm_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.articleTBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rateTBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.unitLocalNameTBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nameTBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deficitValidationProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit articleTBox;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit rateTBox;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit unitLocalNameTBox;
        private DevExpress.XtraEditors.TextEdit nameTBox;
        private DevExpress.XtraEditors.SimpleButton saveBtn;
        private DevExpress.XtraEditors.SimpleButton cancelBtn;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider deficitValidationProvider;
        private DevExpress.XtraEditors.LabelControl validateLbl;

    }
}