namespace TVM_WMS.GUI
{
    partial class QuantityEditFm
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
            this.cancelBtn = new DevExpress.XtraEditors.SimpleButton();
            this.saveBtn = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.quantityTBox = new DevExpress.XtraEditors.TextEdit();
            this.maхQuantityLbl = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.quantityTBox.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // cancelBtn
            // 
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Location = new System.Drawing.Point(184, 87);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 36;
            this.cancelBtn.Text = "Отмена";
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(91, 87);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(87, 23);
            this.saveBtn.TabIndex = 35;
            this.saveBtn.Text = "Подтвердить";
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(11, 44);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(60, 13);
            this.labelControl1.TabIndex = 33;
            this.labelControl1.Text = "Количество";
            // 
            // quantityTBox
            // 
            this.quantityTBox.Location = new System.Drawing.Point(98, 39);
            this.quantityTBox.Name = "quantityTBox";
            this.quantityTBox.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.quantityTBox.Properties.Appearance.Options.UseFont = true;
            this.quantityTBox.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black;
            this.quantityTBox.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.quantityTBox.Properties.Mask.EditMask = "n2";
            this.quantityTBox.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.quantityTBox.Properties.MaxLength = 99999999;
            this.quantityTBox.Size = new System.Drawing.Size(161, 26);
            this.quantityTBox.TabIndex = 1;
            this.quantityTBox.EditValueChanged += new System.EventHandler(this.quantityTBox_EditValueChanged);
            // 
            // maхQuantityLbl
            // 
            this.maхQuantityLbl.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.maхQuantityLbl.Appearance.ForeColor = System.Drawing.Color.Maroon;
            this.maхQuantityLbl.Location = new System.Drawing.Point(12, 12);
            this.maхQuantityLbl.Name = "maхQuantityLbl";
            this.maхQuantityLbl.Size = new System.Drawing.Size(143, 13);
            this.maхQuantityLbl.TabIndex = 37;
            this.maхQuantityLbl.Text = "Допустимое количество";
            // 
            // QuantityEditFm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(271, 122);
            this.Controls.Add(this.maхQuantityLbl);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.quantityTBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "QuantityEditFm";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Введите количество";
            ((System.ComponentModel.ISupportInitialize)(this.quantityTBox.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton cancelBtn;
        private DevExpress.XtraEditors.SimpleButton saveBtn;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit quantityTBox;
        private DevExpress.XtraEditors.LabelControl maхQuantityLbl;
    }
}