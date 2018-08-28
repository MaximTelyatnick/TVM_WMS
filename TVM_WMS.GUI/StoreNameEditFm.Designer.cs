namespace TVM_WMS.GUI
{
    partial class StoreNameEditFm
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
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule3 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule1 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            this.nameTBox = new DevExpress.XtraEditors.TextEdit();
            this.saveBtn = new DevExpress.XtraEditors.SimpleButton();
            this.cancelBtn = new DevExpress.XtraEditors.SimpleButton();
            this.validateLbl = new DevExpress.XtraEditors.LabelControl();
            this.label1 = new System.Windows.Forms.Label();
            this.storeNameValidationProvider = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.storeTypeEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.enableAuthomatizationChk = new DevExpress.XtraEditors.CheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.nameTBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.storeNameValidationProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.storeTypeEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.enableAuthomatizationChk.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // nameTBox
            // 
            this.nameTBox.Location = new System.Drawing.Point(101, 12);
            this.nameTBox.Name = "nameTBox";
            this.nameTBox.Size = new System.Drawing.Size(379, 20);
            this.nameTBox.TabIndex = 1;
            conditionValidationRule3.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule3.ErrorText = "Введите наименование склада";
            conditionValidationRule3.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical;
            this.storeNameValidationProvider.SetValidationRule(this.nameTBox, conditionValidationRule3);
            this.nameTBox.TextChanged += new System.EventHandler(this.nameTBox_TextChanged);
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(324, 126);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(75, 23);
            this.saveBtn.TabIndex = 7;
            this.saveBtn.Text = "Сохранить";
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(405, 126);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 8;
            this.cancelBtn.Text = "Отмена";
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // validateLbl
            // 
            this.validateLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.validateLbl.Appearance.BackColor = System.Drawing.SystemColors.Info;
            this.validateLbl.Appearance.ForeColor = System.Drawing.Color.OrangeRed;
            this.validateLbl.Location = new System.Drawing.Point(37, 131);
            this.validateLbl.Name = "validateLbl";
            this.validateLbl.Size = new System.Drawing.Size(263, 13);
            this.validateLbl.TabIndex = 61;
            this.validateLbl.Text = "*Для сохранения заполните все необходимые поля";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 71;
            this.label1.Text = "Наименование";
            // 
            // storeNameValidationProvider
            // 
            this.storeNameValidationProvider.ValidationMode = DevExpress.XtraEditors.DXErrorProvider.ValidationMode.Auto;
            this.storeNameValidationProvider.ValidationFailed += new DevExpress.XtraEditors.DXErrorProvider.ValidationFailedEventHandler(this.storeNameValidationProvider_ValidationFailed);
            this.storeNameValidationProvider.ValidationSucceeded += new DevExpress.XtraEditors.DXErrorProvider.ValidationSucceededEventHandler(this.storeNameValidationProvider_ValidationSucceeded);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(14, 42);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(57, 13);
            this.labelControl2.TabIndex = 72;
            this.labelControl2.Text = "Тип склада";
            // 
            // storeTypeEdit
            // 
            this.storeTypeEdit.Location = new System.Drawing.Point(101, 38);
            this.storeTypeEdit.Name = "storeTypeEdit";
            this.storeTypeEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.storeTypeEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("StoreTypeName", "Наименование")});
            this.storeTypeEdit.Properties.ShowHeader = false;
            this.storeTypeEdit.Size = new System.Drawing.Size(379, 20);
            this.storeTypeEdit.TabIndex = 73;
            conditionValidationRule1.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.Greater;
            conditionValidationRule1.ErrorText = "Выберите тип склада";
            conditionValidationRule1.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical;
            conditionValidationRule1.Value1 = 0;
            this.storeNameValidationProvider.SetValidationRule(this.storeTypeEdit, conditionValidationRule1);
            this.storeTypeEdit.EditValueChanged += new System.EventHandler(this.storeTypeEdit_EditValueChanged);
            // 
            // enableAuthomatizationChk
            // 
            this.enableAuthomatizationChk.Location = new System.Drawing.Point(101, 64);
            this.enableAuthomatizationChk.Name = "enableAuthomatizationChk";
            this.enableAuthomatizationChk.Properties.AutoWidth = true;
            this.enableAuthomatizationChk.Properties.Caption = "Автоматическое управление";
            this.enableAuthomatizationChk.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.enableAuthomatizationChk.Size = new System.Drawing.Size(169, 19);
            this.enableAuthomatizationChk.TabIndex = 74;
            // 
            // StoreNameEditFm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(492, 161);
            this.Controls.Add(this.enableAuthomatizationChk);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.storeTypeEdit);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.validateLbl);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.nameTBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StoreNameEditFm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Редактирование";
            ((System.ComponentModel.ISupportInitialize)(this.nameTBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.storeNameValidationProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.storeTypeEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.enableAuthomatizationChk.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit nameTBox;
        private DevExpress.XtraEditors.SimpleButton saveBtn;
        private DevExpress.XtraEditors.SimpleButton cancelBtn;
        private DevExpress.XtraEditors.LabelControl validateLbl;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider storeNameValidationProvider;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LookUpEdit storeTypeEdit;
        private DevExpress.XtraEditors.CheckEdit enableAuthomatizationChk;

    }
}