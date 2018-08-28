namespace TVM_WMS.GUI
{
    partial class DeviceBindingEditControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.deviceLbl = new System.Windows.Forms.Label();
            this.deviceEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.storeNamesEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.storeLbl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.deviceEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.storeNamesEdit.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // deviceLbl
            // 
            this.deviceLbl.AutoSize = true;
            this.deviceLbl.ForeColor = System.Drawing.Color.Black;
            this.deviceLbl.Location = new System.Drawing.Point(3, 13);
            this.deviceLbl.Name = "deviceLbl";
            this.deviceLbl.Size = new System.Drawing.Size(118, 13);
            this.deviceLbl.TabIndex = 27;
            this.deviceLbl.Text = "Выберите устройство";
            // 
            // deviceEdit
            // 
            this.deviceEdit.Location = new System.Drawing.Point(3, 31);
            this.deviceEdit.Name = "deviceEdit";
            this.deviceEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deviceEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Наименование")});
            this.deviceEdit.Properties.PopupSizeable = false;
            this.deviceEdit.Properties.ShowHeader = false;
            this.deviceEdit.Size = new System.Drawing.Size(331, 20);
            this.deviceEdit.TabIndex = 34;
            this.deviceEdit.EditValueChanged += new System.EventHandler(this.deviceEdit_EditValueChanged);
            // 
            // storeNamesEdit
            // 
            this.storeNamesEdit.Location = new System.Drawing.Point(3, 82);
            this.storeNamesEdit.Name = "storeNamesEdit";
            this.storeNamesEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.storeNamesEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Наименование")});
            this.storeNamesEdit.Properties.PopupSizeable = false;
            this.storeNamesEdit.Properties.ShowHeader = false;
            this.storeNamesEdit.Size = new System.Drawing.Size(331, 20);
            this.storeNamesEdit.TabIndex = 36;
            this.storeNamesEdit.EditValueChanged += new System.EventHandler(this.storeNamesEdit_EditValueChanged);
            // 
            // storeLbl
            // 
            this.storeLbl.AutoSize = true;
            this.storeLbl.ForeColor = System.Drawing.Color.Black;
            this.storeLbl.Location = new System.Drawing.Point(3, 64);
            this.storeLbl.Name = "storeLbl";
            this.storeLbl.Size = new System.Drawing.Size(90, 13);
            this.storeLbl.TabIndex = 35;
            this.storeLbl.Text = "Выберите склад";
            // 
            // DeviceBindingEditControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.Controls.Add(this.storeNamesEdit);
            this.Controls.Add(this.storeLbl);
            this.Controls.Add(this.deviceEdit);
            this.Controls.Add(this.deviceLbl);
            this.Name = "DeviceBindingEditControl";
            this.Size = new System.Drawing.Size(337, 143);
            ((System.ComponentModel.ISupportInitialize)(this.deviceEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.storeNamesEdit.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label deviceLbl;
        private DevExpress.XtraEditors.LookUpEdit deviceEdit;
        private DevExpress.XtraEditors.LookUpEdit storeNamesEdit;
        private System.Windows.Forms.Label storeLbl;
    }
}
