namespace TVM_WMS.GUI
{
    partial class ReceiptsEditFm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReceiptsEditFm));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule2 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule3 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            this.saveBtn = new DevExpress.XtraEditors.SimpleButton();
            this.cancelBtn = new DevExpress.XtraEditors.SimpleButton();
            this.quantityTBox = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.unitPriceTBox = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.totalPriceTBox = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.dateProductionEdit = new DevExpress.XtraEditors.DateEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.dateExpirationEdit = new DevExpress.XtraEditors.DateEdit();
            this.receiptValidationProvider = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
            this.materialsGridEdit = new DevExpress.XtraEditors.GridLookUpEdit();
            this.gridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.unitEdit = new DevExpress.XtraEditors.GridLookUpEdit();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.validateLbl = new DevExpress.XtraEditors.LabelControl();
            this.articleCol = new DevExpress.XtraGrid.Columns.GridColumn();
            this.nameCol = new DevExpress.XtraGrid.Columns.GridColumn();
            this.unitLocalNameCol = new DevExpress.XtraGrid.Columns.GridColumn();
            this.unitFullNameCol = new DevExpress.XtraGrid.Columns.GridColumn();
            this.unitCodeCol = new DevExpress.XtraGrid.Columns.GridColumn();
            this.unitInternationalNameCol = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.quantityTBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.unitPriceTBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.totalPriceTBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateProductionEdit.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateProductionEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateExpirationEdit.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateExpirationEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.receiptValidationProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.materialsGridEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.unitEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(409, 214);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(75, 23);
            this.saveBtn.TabIndex = 8;
            this.saveBtn.Text = "Сохранить";
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Location = new System.Drawing.Point(490, 214);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 9;
            this.cancelBtn.Text = "Отмена";
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // quantityTBox
            // 
            this.quantityTBox.EditValue = "0";
            this.quantityTBox.Location = new System.Drawing.Point(105, 66);
            this.quantityTBox.Name = "quantityTBox";
            this.quantityTBox.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.quantityTBox.Properties.Appearance.Options.UseTextOptions = true;
            this.quantityTBox.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.quantityTBox.Properties.Mask.EditMask = "n2";
            this.quantityTBox.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.quantityTBox.Properties.NullText = "0,00";
            this.quantityTBox.Properties.NullValuePrompt = "0,00";
            this.quantityTBox.Properties.NullValuePromptShowForEmptyValue = true;
            this.quantityTBox.Size = new System.Drawing.Size(169, 20);
            this.quantityTBox.TabIndex = 3;
            conditionValidationRule1.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.Greater;
            conditionValidationRule1.ErrorText = "Поле КОЛИЧЕСТВО обязательное для заполнения";
            conditionValidationRule1.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical;
            conditionValidationRule1.Value1 = "0";
            this.receiptValidationProvider.SetValidationRule(this.quantityTBox, conditionValidationRule1);
            this.quantityTBox.TextChanged += new System.EventHandler(this.quantityTBox_TextChanged);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 69);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(60, 13);
            this.labelControl1.TabIndex = 4;
            this.labelControl1.Text = "Количество";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(12, 14);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(67, 13);
            this.labelControl2.TabIndex = 5;
            this.labelControl2.Text = "Номенлатура";
            // 
            // unitPriceTBox
            // 
            this.unitPriceTBox.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.unitPriceTBox.Location = new System.Drawing.Point(105, 92);
            this.unitPriceTBox.Name = "unitPriceTBox";
            this.unitPriceTBox.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.unitPriceTBox.Properties.Appearance.Options.UseTextOptions = true;
            this.unitPriceTBox.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.unitPriceTBox.Properties.Mask.EditMask = "n2";
            this.unitPriceTBox.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.unitPriceTBox.Properties.NullText = "0,00";
            this.unitPriceTBox.Properties.NullValuePrompt = "0,00";
            this.unitPriceTBox.Properties.NullValuePromptShowForEmptyValue = true;
            this.unitPriceTBox.Size = new System.Drawing.Size(169, 20);
            this.unitPriceTBox.TabIndex = 4;
            this.unitPriceTBox.TextChanged += new System.EventHandler(this.unitPriceTBox_TextChanged);
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(12, 95);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(26, 13);
            this.labelControl3.TabIndex = 8;
            this.labelControl3.Text = "Цена";
            // 
            // totalPriceTBox
            // 
            this.totalPriceTBox.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.totalPriceTBox.Location = new System.Drawing.Point(105, 118);
            this.totalPriceTBox.Name = "totalPriceTBox";
            this.totalPriceTBox.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.totalPriceTBox.Properties.Appearance.Options.UseTextOptions = true;
            this.totalPriceTBox.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.totalPriceTBox.Properties.Mask.EditMask = "n2";
            this.totalPriceTBox.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.totalPriceTBox.Properties.NullText = "0,00";
            this.totalPriceTBox.Properties.NullValuePrompt = "0,00";
            this.totalPriceTBox.Properties.NullValuePromptShowForEmptyValue = true;
            this.totalPriceTBox.Size = new System.Drawing.Size(169, 20);
            this.totalPriceTBox.TabIndex = 5;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(12, 121);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(54, 13);
            this.labelControl4.TabIndex = 10;
            this.labelControl4.Text = "Стоимость";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(12, 147);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(75, 13);
            this.labelControl5.TabIndex = 12;
            this.labelControl5.Text = "Дата выпуска ";
            // 
            // dateProductionEdit
            // 
            this.dateProductionEdit.EditValue = null;
            this.dateProductionEdit.Location = new System.Drawing.Point(105, 144);
            this.dateProductionEdit.Name = "dateProductionEdit";
            this.dateProductionEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateProductionEdit.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateProductionEdit.Size = new System.Drawing.Size(169, 20);
            this.dateProductionEdit.TabIndex = 6;
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(12, 173);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(88, 13);
            this.labelControl6.TabIndex = 14;
            this.labelControl6.Text = "Дата реализации";
            // 
            // dateExpirationEdit
            // 
            this.dateExpirationEdit.EditValue = null;
            this.dateExpirationEdit.Location = new System.Drawing.Point(105, 170);
            this.dateExpirationEdit.Name = "dateExpirationEdit";
            this.dateExpirationEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateExpirationEdit.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateExpirationEdit.Size = new System.Drawing.Size(169, 20);
            this.dateExpirationEdit.TabIndex = 7;
            // 
            // receiptValidationProvider
            // 
            this.receiptValidationProvider.ValidationMode = DevExpress.XtraEditors.DXErrorProvider.ValidationMode.Auto;
            this.receiptValidationProvider.ValidationFailed += new DevExpress.XtraEditors.DXErrorProvider.ValidationFailedEventHandler(this.receiptValidationProvider_ValidationFailed);
            this.receiptValidationProvider.ValidationSucceeded += new DevExpress.XtraEditors.DXErrorProvider.ValidationSucceededEventHandler(this.receiptValidationProvider_ValidationSucceeded);
            // 
            // materialsGridEdit
            // 
            this.materialsGridEdit.EditValue = 0;
            this.materialsGridEdit.Location = new System.Drawing.Point(105, 10);
            this.materialsGridEdit.Name = "materialsGridEdit";
            this.materialsGridEdit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.materialsGridEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, ((System.Drawing.Image)(resources.GetObject("materialsGridEdit.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "Добавить", null, null, true),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, ((System.Drawing.Image)(resources.GetObject("materialsGridEdit.Properties.Buttons1"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "Корректировать", null, null, true)});
            this.materialsGridEdit.Properties.ImmediatePopup = true;
            this.materialsGridEdit.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            this.materialsGridEdit.Properties.PopupFormMinSize = new System.Drawing.Size(634, 250);
            this.materialsGridEdit.Properties.PopupFormSize = new System.Drawing.Size(634, 250);
            this.materialsGridEdit.Properties.PopupResizeMode = DevExpress.XtraEditors.Controls.ResizeMode.LiveResize;
            this.materialsGridEdit.Properties.View = this.gridLookUpEdit1View;
            this.materialsGridEdit.Size = new System.Drawing.Size(460, 22);
            this.materialsGridEdit.TabIndex = 1;
            conditionValidationRule2.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.Greater;
            conditionValidationRule2.ErrorText = "Поле НОМЕНКЛАТУРА обязательное для заполнения";
            conditionValidationRule2.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical;
            conditionValidationRule2.Value1 = 0;
            this.receiptValidationProvider.SetValidationRule(this.materialsGridEdit, conditionValidationRule2);
            this.materialsGridEdit.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.materialsGridEdit_ButtonClick);
            this.materialsGridEdit.EditValueChanged += new System.EventHandler(this.materialsGridEdit_EditValueChanged);
            // 
            // gridLookUpEdit1View
            // 
            this.gridLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.articleCol,
            this.nameCol});
            this.gridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridLookUpEdit1View.Name = "gridLookUpEdit1View";
            this.gridLookUpEdit1View.OptionsDetail.DetailMode = DevExpress.XtraGrid.Views.Grid.DetailMode.Default;
            this.gridLookUpEdit1View.OptionsFind.AlwaysVisible = true;
            this.gridLookUpEdit1View.OptionsFind.FindMode = DevExpress.XtraEditors.FindMode.Always;
            this.gridLookUpEdit1View.OptionsFind.SearchInPreview = true;
            this.gridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridLookUpEdit1View.OptionsView.ShowAutoFilterRow = true;
            this.gridLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // unitEdit
            // 
            this.unitEdit.EditValue = 0;
            this.unitEdit.Location = new System.Drawing.Point(105, 38);
            this.unitEdit.Name = "unitEdit";
            this.unitEdit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.unitEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, ((System.Drawing.Image)(resources.GetObject("unitEdit.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3, "Добавить", null, null, true),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, ((System.Drawing.Image)(resources.GetObject("unitEdit.Properties.Buttons1"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4, "Корректировать", null, null, true)});
            this.unitEdit.Properties.ImmediatePopup = true;
            this.unitEdit.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            this.unitEdit.Properties.PopupResizeMode = DevExpress.XtraEditors.Controls.ResizeMode.LiveResize;
            this.unitEdit.Properties.View = this.gridView1;
            this.unitEdit.Size = new System.Drawing.Size(460, 22);
            this.unitEdit.TabIndex = 2;
            conditionValidationRule3.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.Greater;
            conditionValidationRule3.ErrorText = "Не выбрана единица измерения";
            conditionValidationRule3.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical;
            conditionValidationRule3.Value1 = 0;
            this.receiptValidationProvider.SetValidationRule(this.unitEdit, conditionValidationRule3);
            this.unitEdit.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.unitEdit_ButtonClick);
            this.unitEdit.EditValueChanged += new System.EventHandler(this.unitEdit_EditValueChanged);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.unitLocalNameCol,
            this.unitFullNameCol,
            this.unitCodeCol,
            this.unitInternationalNameCol});
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsDetail.DetailMode = DevExpress.XtraGrid.Views.Grid.DetailMode.Default;
            this.gridView1.OptionsFind.AlwaysVisible = true;
            this.gridView1.OptionsFind.FindMode = DevExpress.XtraEditors.FindMode.Always;
            this.gridView1.OptionsFind.SearchInPreview = true;
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(12, 42);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(73, 13);
            this.labelControl7.TabIndex = 15;
            this.labelControl7.Text = "Ед. измерения";
            // 
            // validateLbl
            // 
            this.validateLbl.Appearance.BackColor = System.Drawing.SystemColors.Info;
            this.validateLbl.Appearance.ForeColor = System.Drawing.Color.OrangeRed;
            this.validateLbl.Location = new System.Drawing.Point(26, 222);
            this.validateLbl.Name = "validateLbl";
            this.validateLbl.Size = new System.Drawing.Size(263, 13);
            this.validateLbl.TabIndex = 31;
            this.validateLbl.Text = "*Для сохранения заполните все необходимые поля";
            // 
            // articleCol
            // 
            this.articleCol.Caption = "Код";
            this.articleCol.FieldName = "Article";
            this.articleCol.Name = "articleCol";
            this.articleCol.OptionsColumn.AllowEdit = false;
            this.articleCol.OptionsColumn.AllowFocus = false;
            this.articleCol.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.articleCol.Visible = true;
            this.articleCol.VisibleIndex = 0;
            // 
            // nameCol
            // 
            this.nameCol.Caption = "Наименование";
            this.nameCol.FieldName = "Name";
            this.nameCol.Name = "nameCol";
            this.nameCol.OptionsColumn.AllowEdit = false;
            this.nameCol.OptionsColumn.AllowFocus = false;
            this.nameCol.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.nameCol.Visible = true;
            this.nameCol.VisibleIndex = 1;
            // 
            // unitLocalNameCol
            // 
            this.unitLocalNameCol.AppearanceHeader.Options.UseTextOptions = true;
            this.unitLocalNameCol.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.unitLocalNameCol.Caption = "Ед. изм.";
            this.unitLocalNameCol.FieldName = "UnitLocalName";
            this.unitLocalNameCol.Name = "unitLocalNameCol";
            this.unitLocalNameCol.OptionsColumn.AllowEdit = false;
            this.unitLocalNameCol.OptionsColumn.AllowFocus = false;
            this.unitLocalNameCol.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.unitLocalNameCol.Visible = true;
            this.unitLocalNameCol.VisibleIndex = 0;
            // 
            // unitFullNameCol
            // 
            this.unitFullNameCol.AppearanceHeader.Options.UseTextOptions = true;
            this.unitFullNameCol.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.unitFullNameCol.Caption = "Полное наименование";
            this.unitFullNameCol.FieldName = "UnitFullName";
            this.unitFullNameCol.Name = "unitFullNameCol";
            this.unitFullNameCol.OptionsColumn.AllowEdit = false;
            this.unitFullNameCol.OptionsColumn.AllowFocus = false;
            this.unitFullNameCol.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.unitFullNameCol.Visible = true;
            this.unitFullNameCol.VisibleIndex = 1;
            // 
            // unitCodeCol
            // 
            this.unitCodeCol.AppearanceHeader.Options.UseTextOptions = true;
            this.unitCodeCol.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.unitCodeCol.Caption = "Код";
            this.unitCodeCol.FieldName = "UnitCode";
            this.unitCodeCol.Name = "unitCodeCol";
            this.unitCodeCol.OptionsColumn.AllowEdit = false;
            this.unitCodeCol.OptionsColumn.AllowFocus = false;
            this.unitCodeCol.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.unitCodeCol.Visible = true;
            this.unitCodeCol.VisibleIndex = 2;
            // 
            // unitInternationalNameCol
            // 
            this.unitInternationalNameCol.AppearanceHeader.Options.UseTextOptions = true;
            this.unitInternationalNameCol.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.unitInternationalNameCol.Caption = "Международное обозначение";
            this.unitInternationalNameCol.FieldName = "UnitInternationalName";
            this.unitInternationalNameCol.Name = "unitInternationalNameCol";
            this.unitInternationalNameCol.OptionsColumn.AllowEdit = false;
            this.unitInternationalNameCol.OptionsColumn.AllowFocus = false;
            this.unitInternationalNameCol.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.unitInternationalNameCol.Visible = true;
            this.unitInternationalNameCol.VisibleIndex = 3;
            // 
            // ReceiptsEditFm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(577, 249);
            this.Controls.Add(this.materialsGridEdit);
            this.Controls.Add(this.validateLbl);
            this.Controls.Add(this.labelControl7);
            this.Controls.Add(this.labelControl6);
            this.Controls.Add(this.dateExpirationEdit);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.dateProductionEdit);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.totalPriceTBox);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.unitPriceTBox);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.quantityTBox);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.unitEdit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ReceiptsEditFm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Приход";
            ((System.ComponentModel.ISupportInitialize)(this.quantityTBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.unitPriceTBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.totalPriceTBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateProductionEdit.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateProductionEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateExpirationEdit.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateExpirationEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.receiptValidationProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.materialsGridEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.unitEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton saveBtn;
        private DevExpress.XtraEditors.SimpleButton cancelBtn;
        private DevExpress.XtraEditors.TextEdit quantityTBox;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit unitPriceTBox;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit totalPriceTBox;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.DateEdit dateProductionEdit;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.DateEdit dateExpirationEdit;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider receiptValidationProvider;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.LabelControl validateLbl;
        private DevExpress.XtraEditors.GridLookUpEdit materialsGridEdit;
        private DevExpress.XtraGrid.Views.Grid.GridView gridLookUpEdit1View;
        private DevExpress.XtraGrid.Columns.GridColumn articleCol;
        private DevExpress.XtraGrid.Columns.GridColumn nameCol;
        private DevExpress.XtraEditors.GridLookUpEdit unitEdit;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn unitLocalNameCol;
        private DevExpress.XtraGrid.Columns.GridColumn unitFullNameCol;
        private DevExpress.XtraGrid.Columns.GridColumn unitCodeCol;
        private DevExpress.XtraGrid.Columns.GridColumn unitInternationalNameCol;
    }
}