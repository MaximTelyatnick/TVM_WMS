namespace TVM_WMS.GUI
{
    partial class ConfirmQuantityFm
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
            this.okBtn = new DevExpress.XtraEditors.SimpleButton();
            this.cancelBtn = new DevExpress.XtraEditors.SimpleButton();
            this.articleLbl = new DevExpress.XtraEditors.LabelControl();
            this.materialLbl = new DevExpress.XtraEditors.LabelControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.currentWeightTBox = new DevExpress.XtraEditors.TextEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.oldWeightTBox = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.cellTBox = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.waitTimer = new System.Windows.Forms.Timer(this.components);
            this.quantityEdit = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.unitLocalNameLbl = new DevExpress.XtraEditors.LabelControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.maxQuantityLbl = new DevExpress.XtraEditors.LabelControl();
            this.confirmValidationProvider = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.currentWeightTBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.oldWeightTBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cellTBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quantityEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.confirmValidationProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // okBtn
            // 
            this.okBtn.Location = new System.Drawing.Point(251, 390);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(94, 23);
            this.okBtn.TabIndex = 4;
            this.okBtn.Text = "Подтвердить";
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(351, 390);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(94, 23);
            this.cancelBtn.TabIndex = 5;
            this.cancelBtn.Text = "Отмена";
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // articleLbl
            // 
            this.articleLbl.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.articleLbl.Location = new System.Drawing.Point(95, 12);
            this.articleLbl.Name = "articleLbl";
            this.articleLbl.Size = new System.Drawing.Size(99, 13);
            this.articleLbl.TabIndex = 3;
            this.articleLbl.Text = "[Код материала]";
            // 
            // materialLbl
            // 
            this.materialLbl.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.materialLbl.Location = new System.Drawing.Point(95, 31);
            this.materialLbl.Name = "materialLbl";
            this.materialLbl.Size = new System.Drawing.Size(160, 13);
            this.materialLbl.TabIndex = 4;
            this.materialLbl.Text = "[Наименование материала]";
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.currentWeightTBox);
            this.groupControl1.Controls.Add(this.labelControl5);
            this.groupControl1.Controls.Add(this.oldWeightTBox);
            this.groupControl1.Controls.Add(this.labelControl4);
            this.groupControl1.Controls.Add(this.cellTBox);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Location = new System.Drawing.Point(12, 215);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(433, 152);
            this.groupControl1.TabIndex = 5;
            this.groupControl1.Text = "Текущее состояние ячейки";
            // 
            // currentWeightTBox
            // 
            this.currentWeightTBox.Location = new System.Drawing.Point(152, 108);
            this.currentWeightTBox.Name = "currentWeightTBox";
            this.currentWeightTBox.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 16F);
            this.currentWeightTBox.Properties.Appearance.Options.UseFont = true;
            this.currentWeightTBox.Size = new System.Drawing.Size(276, 32);
            this.currentWeightTBox.TabIndex = 3;
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Tahoma", 14F);
            this.labelControl5.Location = new System.Drawing.Point(5, 113);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(111, 23);
            this.labelControl5.TabIndex = 8;
            this.labelControl5.Text = "Текущий вес";
            // 
            // oldWeightTBox
            // 
            this.oldWeightTBox.Location = new System.Drawing.Point(152, 70);
            this.oldWeightTBox.Name = "oldWeightTBox";
            this.oldWeightTBox.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 16F);
            this.oldWeightTBox.Properties.Appearance.Options.UseFont = true;
            this.oldWeightTBox.Size = new System.Drawing.Size(276, 32);
            this.oldWeightTBox.TabIndex = 2;
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 14F);
            this.labelControl4.Location = new System.Drawing.Point(5, 75);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(134, 23);
            this.labelControl4.TabIndex = 6;
            this.labelControl4.Text = "Начальный вес";
            // 
            // cellTBox
            // 
            this.cellTBox.Location = new System.Drawing.Point(152, 32);
            this.cellTBox.Name = "cellTBox";
            this.cellTBox.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 16F);
            this.cellTBox.Properties.Appearance.Options.UseFont = true;
            this.cellTBox.Size = new System.Drawing.Size(276, 32);
            this.cellTBox.TabIndex = 1;
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 14F);
            this.labelControl3.Location = new System.Drawing.Point(5, 37);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(90, 23);
            this.labelControl3.TabIndex = 4;
            this.labelControl3.Text = "Ячейка №";
            // 
            // waitTimer
            // 
            this.waitTimer.Interval = 1000;
            this.waitTimer.Tick += new System.EventHandler(this.waitTimer_Tick);
            // 
            // quantityEdit
            // 
            this.quantityEdit.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.quantityEdit.Location = new System.Drawing.Point(12, 104);
            this.quantityEdit.Name = "quantityEdit";
            this.quantityEdit.Properties.Appearance.BorderColor = System.Drawing.Color.LimeGreen;
            this.quantityEdit.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 48F, System.Drawing.FontStyle.Bold);
            this.quantityEdit.Properties.Appearance.ForeColor = System.Drawing.Color.Navy;
            this.quantityEdit.Properties.Appearance.Options.UseBorderColor = true;
            this.quantityEdit.Properties.Appearance.Options.UseFont = true;
            this.quantityEdit.Properties.Appearance.Options.UseForeColor = true;
            this.quantityEdit.Properties.Appearance.Options.UseTextOptions = true;
            this.quantityEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.quantityEdit.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.quantityEdit.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered;
            this.quantityEdit.Properties.Mask.EditMask = "n2";
            this.quantityEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.quantityEdit.Size = new System.Drawing.Size(433, 86);
            this.quantityEdit.TabIndex = 0;
            this.quantityEdit.TextChanged += new System.EventHandler(this.quantityEdit_TextChanged);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 12);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(77, 13);
            this.labelControl1.TabIndex = 6;
            this.labelControl1.Text = "Код материала";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(12, 31);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(73, 13);
            this.labelControl2.TabIndex = 7;
            this.labelControl2.Text = "Наименование";
            // 
            // unitLocalNameLbl
            // 
            this.unitLocalNameLbl.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.unitLocalNameLbl.Location = new System.Drawing.Point(95, 49);
            this.unitLocalNameLbl.Name = "unitLocalNameLbl";
            this.unitLocalNameLbl.Size = new System.Drawing.Size(51, 13);
            this.unitLocalNameLbl.TabIndex = 8;
            this.unitLocalNameLbl.Text = "[Ед.изм.]";
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(12, 50);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(73, 13);
            this.labelControl7.TabIndex = 9;
            this.labelControl7.Text = "Ед. измерения";
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(12, 69);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(49, 13);
            this.labelControl8.TabIndex = 11;
            this.labelControl8.Text = "Доступно";
            // 
            // maxQuantityLbl
            // 
            this.maxQuantityLbl.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.maxQuantityLbl.Appearance.ForeColor = System.Drawing.Color.Maroon;
            this.maxQuantityLbl.Location = new System.Drawing.Point(95, 68);
            this.maxQuantityLbl.Name = "maxQuantityLbl";
            this.maxQuantityLbl.Size = new System.Drawing.Size(68, 13);
            this.maxQuantityLbl.TabIndex = 10;
            this.maxQuantityLbl.Text = "[Доступно]";
            // 
            // confirmValidationProvider
            // 
            this.confirmValidationProvider.ValidationMode = DevExpress.XtraEditors.DXErrorProvider.ValidationMode.Auto;
            this.confirmValidationProvider.ValidationFailed += new DevExpress.XtraEditors.DXErrorProvider.ValidationFailedEventHandler(this.confirmValidationProvider_ValidationFailed);
            this.confirmValidationProvider.ValidationSucceeded += new DevExpress.XtraEditors.DXErrorProvider.ValidationSucceededEventHandler(this.confirmValidationProvider_ValidationSucceeded);
            // 
            // ConfirmQuantityFm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(457, 425);
            this.Controls.Add(this.labelControl8);
            this.Controls.Add(this.maxQuantityLbl);
            this.Controls.Add(this.labelControl7);
            this.Controls.Add(this.unitLocalNameLbl);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.materialLbl);
            this.Controls.Add(this.articleLbl);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.okBtn);
            this.Controls.Add(this.quantityEdit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConfirmQuantityFm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Подтверждение количества";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ConfirmQuantityFm_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.currentWeightTBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.oldWeightTBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cellTBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quantityEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.confirmValidationProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton okBtn;
        private DevExpress.XtraEditors.SimpleButton cancelBtn;
        private DevExpress.XtraEditors.LabelControl articleLbl;
        private DevExpress.XtraEditors.LabelControl materialLbl;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.TextEdit currentWeightTBox;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.TextEdit oldWeightTBox;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit cellTBox;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private System.Windows.Forms.Timer waitTimer;
        private DevExpress.XtraEditors.TextEdit quantityEdit;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl unitLocalNameLbl;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.LabelControl maxQuantityLbl;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider confirmValidationProvider;
    }
}