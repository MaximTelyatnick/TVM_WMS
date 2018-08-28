namespace TVM_WMS.GUI
{
    partial class ZoneNameEditFm
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
            this.zoneNameTBox = new DevExpress.XtraEditors.TextEdit();
            this.cancelBtn = new DevExpress.XtraEditors.SimpleButton();
            this.saveBtn = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.colorPickEdit = new DevExpress.XtraEditors.ColorPickEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.zoneTypeEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.zoneValidationProvider = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
            this.validateLbl = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.zoneNameTBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorPickEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zoneTypeEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zoneValidationProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // zoneNameTBox
            // 
            this.zoneNameTBox.Location = new System.Drawing.Point(12, 26);
            this.zoneNameTBox.Name = "zoneNameTBox";
            this.zoneNameTBox.Size = new System.Drawing.Size(498, 20);
            this.zoneNameTBox.TabIndex = 0;
            conditionValidationRule1.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule1.ErrorText = "Поле Наименование обязательное для заполнения";
            conditionValidationRule1.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical;
            conditionValidationRule1.Value1 = "0";
            this.zoneValidationProvider.SetValidationRule(this.zoneNameTBox, conditionValidationRule1);
            this.zoneNameTBox.TextChanged += new System.EventHandler(this.zoneNameTBox_TextChanged);
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(435, 176);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 12;
            this.cancelBtn.Text = "Отмена";
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(354, 176);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(75, 23);
            this.saveBtn.TabIndex = 11;
            this.saveBtn.Text = "Сохранить";
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(12, 7);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(76, 13);
            this.labelControl2.TabIndex = 19;
            this.labelControl2.Text = "Наименование ";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 52);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(29, 13);
            this.labelControl1.TabIndex = 18;
            this.labelControl1.Text = "Цвет ";
            // 
            // colorPickEdit
            // 
            this.colorPickEdit.EditValue = System.Drawing.Color.Empty;
            this.colorPickEdit.Location = new System.Drawing.Point(12, 71);
            this.colorPickEdit.Name = "colorPickEdit";
            this.colorPickEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.colorPickEdit.Properties.ShowSystemColors = false;
            this.colorPickEdit.Properties.ShowWebColors = false;
            this.colorPickEdit.Size = new System.Drawing.Size(49, 20);
            this.colorPickEdit.TabIndex = 17;
            conditionValidationRule2.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.Greater;
            conditionValidationRule2.ErrorText = "This value is not valid";
            conditionValidationRule2.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical;
            this.zoneValidationProvider.SetValidationRule(this.colorPickEdit, conditionValidationRule2);
            this.colorPickEdit.EditValueChanged += new System.EventHandler(this.colorPickEdit_EditValueChanged);
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(12, 97);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(46, 13);
            this.labelControl3.TabIndex = 20;
            this.labelControl3.Text = "Тип зоны";
            // 
            // zoneTypeEdit
            // 
            this.zoneTypeEdit.Location = new System.Drawing.Point(12, 116);
            this.zoneTypeEdit.Name = "zoneTypeEdit";
            this.zoneTypeEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.zoneTypeEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ZoneTypeName", "Наименование")});
            this.zoneTypeEdit.Properties.ShowHeader = false;
            this.zoneTypeEdit.Size = new System.Drawing.Size(271, 20);
            this.zoneTypeEdit.TabIndex = 21;
            conditionValidationRule3.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.Greater;
            conditionValidationRule3.ErrorText = "This value is not valid";
            conditionValidationRule3.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical;
            conditionValidationRule3.Value1 = "0";
            this.zoneValidationProvider.SetValidationRule(this.zoneTypeEdit, conditionValidationRule3);
            this.zoneTypeEdit.EditValueChanged += new System.EventHandler(this.zoneTypeEdit_EditValueChanged);
            // 
            // zoneValidationProvider
            // 
            this.zoneValidationProvider.ValidationMode = DevExpress.XtraEditors.DXErrorProvider.ValidationMode.Auto;
            this.zoneValidationProvider.ValidationFailed += new DevExpress.XtraEditors.DXErrorProvider.ValidationFailedEventHandler(this.zoneValidationProvider_ValidationFailed);
            this.zoneValidationProvider.ValidationSucceeded += new DevExpress.XtraEditors.DXErrorProvider.ValidationSucceededEventHandler(this.zoneValidationProvider_ValidationSucceeded);
            // 
            // validateLbl
            // 
            this.validateLbl.Appearance.BackColor = System.Drawing.SystemColors.Info;
            this.validateLbl.Appearance.ForeColor = System.Drawing.Color.OrangeRed;
            this.validateLbl.Location = new System.Drawing.Point(12, 181);
            this.validateLbl.Name = "validateLbl";
            this.validateLbl.Size = new System.Drawing.Size(263, 13);
            this.validateLbl.TabIndex = 34;
            this.validateLbl.Text = "*Для сохранения заполните все необходимые поля";
            // 
            // ZoneNameEditFm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(520, 211);
            this.Controls.Add(this.validateLbl);
            this.Controls.Add(this.zoneTypeEdit);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.colorPickEdit);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.zoneNameTBox);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ZoneNameEditFm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Редактирование зоны хранения";
            ((System.ComponentModel.ISupportInitialize)(this.zoneNameTBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorPickEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zoneTypeEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zoneValidationProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit zoneNameTBox;
        private DevExpress.XtraEditors.SimpleButton cancelBtn;
        private DevExpress.XtraEditors.SimpleButton saveBtn;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.ColorPickEdit colorPickEdit;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LookUpEdit zoneTypeEdit;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider zoneValidationProvider;
        private DevExpress.XtraEditors.LabelControl validateLbl;
    }
}