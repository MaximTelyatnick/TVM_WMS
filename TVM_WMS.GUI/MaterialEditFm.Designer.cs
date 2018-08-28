namespace TVM_WMS.GUI
{
    partial class MaterialEditFm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MaterialEditFm));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule3 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.nameTBox = new DevExpress.XtraEditors.TextEdit();
            this.articleTBox = new DevExpress.XtraEditors.TextEdit();
            this.saveBtn = new DevExpress.XtraEditors.SimpleButton();
            this.cancelBtn = new DevExpress.XtraEditors.SimpleButton();
            this.descriptionTBox = new DevExpress.XtraEditors.TextEdit();
            this.notesTBox = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.storageGroupsEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.materialValidationProvider = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
            this.materialGroupsEdit = new DevExpress.XtraEditors.TreeListLookUpEdit();
            this.materialGroupsTreeList = new DevExpress.XtraTreeList.TreeList();
            this.codeCol = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.nameCol = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.validateLbl = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.nameTBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.articleTBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.descriptionTBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.notesTBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.storageGroupsEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.materialValidationProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.materialGroupsEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.materialGroupsTreeList)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(11, 44);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(73, 13);
            this.labelControl2.TabIndex = 11;
            this.labelControl2.Text = "Наименование";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 17);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(97, 13);
            this.labelControl1.TabIndex = 10;
            this.labelControl1.Text = "Код номенклатуры";
            // 
            // nameTBox
            // 
            this.nameTBox.Location = new System.Drawing.Point(135, 42);
            this.nameTBox.Name = "nameTBox";
            this.nameTBox.Properties.MaxLength = 100;
            this.nameTBox.Size = new System.Drawing.Size(605, 20);
            this.nameTBox.TabIndex = 2;
            conditionValidationRule1.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule1.ErrorText = "Поле НАИМЕНОВАНИЕ обязательное для заполнения";
            this.materialValidationProvider.SetValidationRule(this.nameTBox, conditionValidationRule1);
            this.nameTBox.TextChanged += new System.EventHandler(this.nameTBox_TextChanged);
            // 
            // articleTBox
            // 
            this.articleTBox.Location = new System.Drawing.Point(135, 13);
            this.articleTBox.Name = "articleTBox";
            this.articleTBox.Properties.AllowFocused = false;
            this.articleTBox.Properties.MaxLength = 25;
            this.articleTBox.Size = new System.Drawing.Size(153, 20);
            this.articleTBox.TabIndex = 1;
            conditionValidationRule2.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule2.ErrorText = "Поле КОД обязательное для заполнения";
            conditionValidationRule2.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical;
            this.materialValidationProvider.SetValidationRule(this.articleTBox, conditionValidationRule2);
            this.articleTBox.TextChanged += new System.EventHandler(this.articleTBox_TextChanged);
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(580, 207);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(75, 23);
            this.saveBtn.TabIndex = 7;
            this.saveBtn.Text = "Сохранить";
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Location = new System.Drawing.Point(660, 207);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 8;
            this.cancelBtn.Text = "Отмена";
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // descriptionTBox
            // 
            this.descriptionTBox.Location = new System.Drawing.Point(135, 102);
            this.descriptionTBox.Name = "descriptionTBox";
            this.descriptionTBox.Properties.MaxLength = 100;
            this.descriptionTBox.Size = new System.Drawing.Size(605, 20);
            this.descriptionTBox.TabIndex = 4;
            // 
            // notesTBox
            // 
            this.notesTBox.Location = new System.Drawing.Point(135, 135);
            this.notesTBox.Name = "notesTBox";
            this.notesTBox.Properties.MaxLength = 100;
            this.notesTBox.Size = new System.Drawing.Size(605, 20);
            this.notesTBox.TabIndex = 5;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(12, 103);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(49, 13);
            this.labelControl3.TabIndex = 14;
            this.labelControl3.Text = "Описание";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(12, 136);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(61, 13);
            this.labelControl4.TabIndex = 15;
            this.labelControl4.Text = "Примечание";
            // 
            // storageGroupsEdit
            // 
            this.storageGroupsEdit.Location = new System.Drawing.Point(135, 167);
            this.storageGroupsEdit.Name = "storageGroupsEdit";
            this.storageGroupsEdit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.storageGroupsEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, ((System.Drawing.Image)(resources.GetObject("storageGroupsEdit.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "Добавить", null, null, true),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, ((System.Drawing.Image)(resources.GetObject("storageGroupsEdit.Properties.Buttons1"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "Корректировать", null, null, true)});
            this.storageGroupsEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("StorageGroupName", "Группа", 100, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Description", 100, "Описание")});
            this.storageGroupsEdit.Properties.ImmediatePopup = true;
            this.storageGroupsEdit.Properties.PopupWidth = 605;
            this.storageGroupsEdit.Size = new System.Drawing.Size(605, 22);
            this.storageGroupsEdit.TabIndex = 6;
            this.storageGroupsEdit.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.storageGroupsEdit_ButtonClick);
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(11, 169);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(93, 13);
            this.labelControl5.TabIndex = 23;
            this.labelControl5.Text = "Складская группа";
            // 
            // materialValidationProvider
            // 
            this.materialValidationProvider.ValidationFailed += new DevExpress.XtraEditors.DXErrorProvider.ValidationFailedEventHandler(this.materialValidationProvider_ValidationFailed);
            this.materialValidationProvider.ValidationSucceeded += new DevExpress.XtraEditors.DXErrorProvider.ValidationSucceededEventHandler(this.materialValidationProvider_ValidationSucceeded);
            // 
            // materialGroupsEdit
            // 
            this.materialGroupsEdit.Location = new System.Drawing.Point(135, 71);
            this.materialGroupsEdit.Name = "materialGroupsEdit";
            this.materialGroupsEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.materialGroupsEdit.Properties.ImmediatePopup = true;
            this.materialGroupsEdit.Properties.PopupFormMinSize = new System.Drawing.Size(605, 0);
            this.materialGroupsEdit.Properties.PopupFormSize = new System.Drawing.Size(605, 0);
            this.materialGroupsEdit.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.materialGroupsEdit.Properties.TreeList = this.materialGroupsTreeList;
            this.materialGroupsEdit.Size = new System.Drawing.Size(605, 20);
            this.materialGroupsEdit.TabIndex = 3;
            conditionValidationRule3.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.Greater;
            conditionValidationRule3.ErrorText = "Не выбрана группа материалов";
            conditionValidationRule3.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical;
            conditionValidationRule3.Value1 = 0;
            this.materialValidationProvider.SetValidationRule(this.materialGroupsEdit, conditionValidationRule3);
            this.materialGroupsEdit.EditValueChanged += new System.EventHandler(this.materialGroupsEdit_EditValueChanged);
            // 
            // materialGroupsTreeList
            // 
            this.materialGroupsTreeList.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.codeCol,
            this.nameCol});
            this.materialGroupsTreeList.Location = new System.Drawing.Point(0, 0);
            this.materialGroupsTreeList.Name = "materialGroupsTreeList";
            this.materialGroupsTreeList.OptionsBehavior.EnableFiltering = true;
            this.materialGroupsTreeList.OptionsBehavior.PopulateServiceColumns = true;
            this.materialGroupsTreeList.OptionsView.ShowIndentAsRowStyle = true;
            this.materialGroupsTreeList.Size = new System.Drawing.Size(400, 200);
            this.materialGroupsTreeList.TabIndex = 0;
            // 
            // codeCol
            // 
            this.codeCol.AppearanceHeader.Options.UseTextOptions = true;
            this.codeCol.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.codeCol.Caption = "Код";
            this.codeCol.FieldName = "Code";
            this.codeCol.Name = "codeCol";
            this.codeCol.OptionsColumn.AllowEdit = false;
            this.codeCol.OptionsColumn.AllowFocus = false;
            this.codeCol.OptionsFilter.AutoFilterCondition = DevExpress.XtraTreeList.Columns.AutoFilterCondition.Contains;
            this.codeCol.OptionsFilter.ImmediateUpdatePopupDateFilter = DevExpress.Utils.DefaultBoolean.True;
            this.codeCol.OptionsFilter.ShowBlanksFilterItems = DevExpress.Utils.DefaultBoolean.True;
            this.codeCol.Visible = true;
            this.codeCol.VisibleIndex = 0;
            this.codeCol.Width = 167;
            // 
            // nameCol
            // 
            this.nameCol.AppearanceHeader.Options.UseTextOptions = true;
            this.nameCol.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.nameCol.Caption = "Наименование";
            this.nameCol.FieldName = "Name";
            this.nameCol.Name = "nameCol";
            this.nameCol.OptionsColumn.AllowEdit = false;
            this.nameCol.OptionsColumn.AllowFocus = false;
            this.nameCol.OptionsFilter.AutoFilterCondition = DevExpress.XtraTreeList.Columns.AutoFilterCondition.Contains;
            this.nameCol.OptionsFilter.ImmediateUpdatePopupDateFilter = DevExpress.Utils.DefaultBoolean.True;
            this.nameCol.OptionsFilter.ShowBlanksFilterItems = DevExpress.Utils.DefaultBoolean.True;
            this.nameCol.Visible = true;
            this.nameCol.VisibleIndex = 1;
            this.nameCol.Width = 518;
            // 
            // validateLbl
            // 
            this.validateLbl.Appearance.BackColor = System.Drawing.SystemColors.Info;
            this.validateLbl.Appearance.ForeColor = System.Drawing.Color.OrangeRed;
            this.validateLbl.Location = new System.Drawing.Point(11, 212);
            this.validateLbl.Name = "validateLbl";
            this.validateLbl.Size = new System.Drawing.Size(263, 13);
            this.validateLbl.TabIndex = 31;
            this.validateLbl.Text = "*Для сохранения заполните все необходимые поля";
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(11, 73);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(113, 13);
            this.labelControl6.TabIndex = 33;
            this.labelControl6.Text = "Группа номенклатуры";
            // 
            // MaterialEditFm
            // 
            this.AcceptButton = this.saveBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.CancelButton = this.cancelBtn;
            this.ClientSize = new System.Drawing.Size(751, 248);
            this.Controls.Add(this.labelControl6);
            this.Controls.Add(this.materialGroupsEdit);
            this.Controls.Add(this.validateLbl);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.storageGroupsEdit);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.notesTBox);
            this.Controls.Add(this.descriptionTBox);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.nameTBox);
            this.Controls.Add(this.articleTBox);
            this.Controls.Add(this.saveBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MaterialEditFm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Номенклатура";
            ((System.ComponentModel.ISupportInitialize)(this.nameTBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.articleTBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.descriptionTBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.notesTBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.storageGroupsEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.materialValidationProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.materialGroupsEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.materialGroupsTreeList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit nameTBox;
        private DevExpress.XtraEditors.TextEdit articleTBox;
        private DevExpress.XtraEditors.SimpleButton saveBtn;
        private DevExpress.XtraEditors.SimpleButton cancelBtn;
        private DevExpress.XtraEditors.TextEdit descriptionTBox;
        private DevExpress.XtraEditors.TextEdit notesTBox;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LookUpEdit storageGroupsEdit;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider materialValidationProvider;
        private DevExpress.XtraEditors.LabelControl validateLbl;
        private DevExpress.XtraEditors.TreeListLookUpEdit materialGroupsEdit;
        private DevExpress.XtraTreeList.TreeList materialGroupsTreeList;
        private DevExpress.XtraTreeList.Columns.TreeListColumn codeCol;
        private DevExpress.XtraTreeList.Columns.TreeListColumn nameCol;
        private DevExpress.XtraEditors.LabelControl labelControl6;
    }
}