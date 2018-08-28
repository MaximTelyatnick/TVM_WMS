﻿namespace TVM_WMS.GUI
{
    partial class SettingsDBEditFm
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
            this.validateLbl = new DevExpress.XtraEditors.LabelControl();
            this.saveBtn = new DevExpress.XtraEditors.SimpleButton();
            this.closeBtn = new DevExpress.XtraEditors.SimpleButton();
            this.DBSettingValidationProvider = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
            this.nameTBox = new DevExpress.XtraEditors.TextEdit();
            this.dbIndexTBox = new DevExpress.XtraEditors.TextEdit();
            this.dbVarGrid = new DevExpress.XtraGrid.GridControl();
            this.dbVarGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.nameCol = new DevExpress.XtraGrid.Columns.GridColumn();
            this.itemTypeCol = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryTypeNameEdit = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.offsetCol = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryOffsetTBox = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.canListenCol = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryCanListenChk = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.label2 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.refreshSpin = new DevExpress.XtraEditors.SpinEdit();
            this.label15 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DBSettingValidationProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nameTBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbIndexTBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbVarGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbVarGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryTypeNameEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryOffsetTBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryCanListenChk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.refreshSpin.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // validateLbl
            // 
            this.validateLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.validateLbl.Appearance.BackColor = System.Drawing.SystemColors.Info;
            this.validateLbl.Appearance.ForeColor = System.Drawing.Color.OrangeRed;
            this.validateLbl.Location = new System.Drawing.Point(12, 501);
            this.validateLbl.Name = "validateLbl";
            this.validateLbl.Size = new System.Drawing.Size(263, 13);
            this.validateLbl.TabIndex = 78;
            this.validateLbl.Text = "*Для сохранения заполните все необходимые поля";
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(365, 496);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(75, 23);
            this.saveBtn.TabIndex = 76;
            this.saveBtn.Text = "Сохранить";
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // closeBtn
            // 
            this.closeBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.closeBtn.Location = new System.Drawing.Point(446, 496);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(75, 23);
            this.closeBtn.TabIndex = 77;
            this.closeBtn.Text = "Отмена";
            this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
            // 
            // DBSettingValidationProvider
            // 
            this.DBSettingValidationProvider.ValidationMode = DevExpress.XtraEditors.DXErrorProvider.ValidationMode.Auto;
            this.DBSettingValidationProvider.ValidationFailed += new DevExpress.XtraEditors.DXErrorProvider.ValidationFailedEventHandler(this.DBSettingValidationProvider_ValidationFailed);
            this.DBSettingValidationProvider.ValidationSucceeded += new DevExpress.XtraEditors.DXErrorProvider.ValidationSucceededEventHandler(this.DBSettingValidationProvider_ValidationSucceeded);
            // 
            // nameTBox
            // 
            this.nameTBox.Location = new System.Drawing.Point(124, 12);
            this.nameTBox.Name = "nameTBox";
            this.nameTBox.Properties.Mask.IgnoreMaskBlank = false;
            this.nameTBox.Properties.Mask.ShowPlaceHolders = false;
            this.nameTBox.Size = new System.Drawing.Size(397, 20);
            this.nameTBox.TabIndex = 80;
            conditionValidationRule1.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule1.ErrorText = "Введите наименование блока памяти";
            conditionValidationRule1.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical;
            this.DBSettingValidationProvider.SetValidationRule(this.nameTBox, conditionValidationRule1);
            this.nameTBox.TextChanged += new System.EventHandler(this.nameTBox_TextChanged);
            // 
            // dbIndexTBox
            // 
            this.dbIndexTBox.Location = new System.Drawing.Point(124, 38);
            this.dbIndexTBox.Name = "dbIndexTBox";
            this.dbIndexTBox.Properties.Mask.EditMask = "n0";
            this.dbIndexTBox.Properties.Mask.IgnoreMaskBlank = false;
            this.dbIndexTBox.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.dbIndexTBox.Properties.Mask.ShowPlaceHolders = false;
            this.dbIndexTBox.Size = new System.Drawing.Size(397, 20);
            this.dbIndexTBox.TabIndex = 83;
            conditionValidationRule2.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule2.ErrorText = "Введите индекс блока памяти";
            conditionValidationRule2.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical;
            this.DBSettingValidationProvider.SetValidationRule(this.dbIndexTBox, conditionValidationRule2);
            this.dbIndexTBox.TextChanged += new System.EventHandler(this.dbIndexTBox_TextChanged);
            // 
            // dbVarGrid
            // 
            this.dbVarGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dbVarGrid.Location = new System.Drawing.Point(2, 20);
            this.dbVarGrid.MainView = this.dbVarGridView;
            this.dbVarGrid.Name = "dbVarGrid";
            this.dbVarGrid.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryCanListenChk,
            this.repositoryTypeNameEdit,
            this.repositoryOffsetTBox});
            this.dbVarGrid.Size = new System.Drawing.Size(520, 346);
            this.dbVarGrid.TabIndex = 79;
            this.dbVarGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.dbVarGridView});
            // 
            // dbVarGridView
            // 
            this.dbVarGridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.nameCol,
            this.itemTypeCol,
            this.offsetCol,
            this.canListenCol});
            this.dbVarGridView.GridControl = this.dbVarGrid;
            this.dbVarGridView.Name = "dbVarGridView";
            this.dbVarGridView.OptionsDetail.DetailMode = DevExpress.XtraGrid.Views.Grid.DetailMode.Default;
            this.dbVarGridView.OptionsView.ShowGroupPanel = false;
            // 
            // nameCol
            // 
            this.nameCol.AppearanceHeader.Options.UseTextOptions = true;
            this.nameCol.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.nameCol.Caption = "Наименование";
            this.nameCol.FieldName = "Name";
            this.nameCol.Name = "nameCol";
            this.nameCol.OptionsColumn.AllowEdit = false;
            this.nameCol.Visible = true;
            this.nameCol.VisibleIndex = 0;
            // 
            // itemTypeCol
            // 
            this.itemTypeCol.AppearanceHeader.Options.UseTextOptions = true;
            this.itemTypeCol.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.itemTypeCol.Caption = "Тип данных";
            this.itemTypeCol.ColumnEdit = this.repositoryTypeNameEdit;
            this.itemTypeCol.FieldName = "ItemTypeId";
            this.itemTypeCol.Name = "itemTypeCol";
            this.itemTypeCol.Visible = true;
            this.itemTypeCol.VisibleIndex = 1;
            // 
            // repositoryTypeNameEdit
            // 
            this.repositoryTypeNameEdit.AutoHeight = false;
            this.repositoryTypeNameEdit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryTypeNameEdit.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TypeName", "Тип")});
            this.repositoryTypeNameEdit.Name = "repositoryTypeNameEdit";
            this.repositoryTypeNameEdit.ShowHeader = false;
            this.repositoryTypeNameEdit.EditValueChanged += new System.EventHandler(this.repositoryTypeNameEdit_EditValueChanged);
            // 
            // offsetCol
            // 
            this.offsetCol.AppearanceHeader.Options.UseTextOptions = true;
            this.offsetCol.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.offsetCol.Caption = "Смещение(Offset)";
            this.offsetCol.ColumnEdit = this.repositoryOffsetTBox;
            this.offsetCol.FieldName = "Offset";
            this.offsetCol.Name = "offsetCol";
            this.offsetCol.Visible = true;
            this.offsetCol.VisibleIndex = 2;
            // 
            // repositoryOffsetTBox
            // 
            this.repositoryOffsetTBox.AutoHeight = false;
            this.repositoryOffsetTBox.DisplayFormat.FormatString = "########0.0#";
            this.repositoryOffsetTBox.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.repositoryOffsetTBox.Mask.EditMask = "([0-9]*)(\\.([0-9]*))";
            this.repositoryOffsetTBox.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.repositoryOffsetTBox.Name = "repositoryOffsetTBox";
            // 
            // canListenCol
            // 
            this.canListenCol.AppearanceHeader.Options.UseTextOptions = true;
            this.canListenCol.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.canListenCol.Caption = "Прослушивание";
            this.canListenCol.ColumnEdit = this.repositoryCanListenChk;
            this.canListenCol.FieldName = "CanListen";
            this.canListenCol.Name = "canListenCol";
            this.canListenCol.Visible = true;
            this.canListenCol.VisibleIndex = 3;
            // 
            // repositoryCanListenChk
            // 
            this.repositoryCanListenChk.AutoHeight = false;
            this.repositoryCanListenChk.Name = "repositoryCanListenChk";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 81;
            this.label1.Text = "Наименование";
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.dbVarGrid);
            this.groupControl1.Location = new System.Drawing.Point(5, 122);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(524, 368);
            this.groupControl1.TabIndex = 82;
            this.groupControl1.Text = "Переменные блока памяти";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(2, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 13);
            this.label2.TabIndex = 84;
            this.label2.Text = "Индекс блока памяти";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(197, 67);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(32, 13);
            this.label16.TabIndex = 87;
            this.label16.Text = "(сек)";
            // 
            // refreshSpin
            // 
            this.refreshSpin.EditValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.refreshSpin.Location = new System.Drawing.Point(124, 64);
            this.refreshSpin.Name = "refreshSpin";
            this.refreshSpin.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.refreshSpin.Properties.Mask.EditMask = "n0";
            this.refreshSpin.Properties.MaxValue = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.refreshSpin.Properties.MinValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.refreshSpin.Size = new System.Drawing.Size(65, 20);
            this.refreshSpin.TabIndex = 86;
            conditionValidationRule3.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.Greater;
            conditionValidationRule3.ErrorText = "Укажите частоту обновления данных";
            conditionValidationRule3.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical;
            conditionValidationRule3.Value1 = 0;
            this.DBSettingValidationProvider.SetValidationRule(this.refreshSpin, conditionValidationRule3);
            this.refreshSpin.EditValueChanged += new System.EventHandler(this.refreshSpin_EditValueChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(31, 67);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(87, 13);
            this.label15.TabIndex = 85;
            this.label15.Text = "Частота опроса";
            // 
            // SettingsDBEditFm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(533, 534);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.refreshSpin);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.dbIndexTBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.nameTBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.validateLbl);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.closeBtn);
            this.Name = "SettingsDBEditFm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Редактировать";
            ((System.ComponentModel.ISupportInitialize)(this.DBSettingValidationProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nameTBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbIndexTBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbVarGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbVarGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryTypeNameEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryOffsetTBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryCanListenChk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.refreshSpin.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl validateLbl;
        private DevExpress.XtraEditors.SimpleButton saveBtn;
        private DevExpress.XtraEditors.SimpleButton closeBtn;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider DBSettingValidationProvider;
        private DevExpress.XtraGrid.GridControl dbVarGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView dbVarGridView;
        private DevExpress.XtraGrid.Columns.GridColumn nameCol;
        private DevExpress.XtraGrid.Columns.GridColumn itemTypeCol;
        private DevExpress.XtraGrid.Columns.GridColumn offsetCol;
        private DevExpress.XtraEditors.TextEdit nameTBox;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.TextEdit dbIndexTBox;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraGrid.Columns.GridColumn canListenCol;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryCanListenChk;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryTypeNameEdit;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryOffsetTBox;
        private System.Windows.Forms.Label label16;
        private DevExpress.XtraEditors.SpinEdit refreshSpin;
        private System.Windows.Forms.Label label15;
    }
}