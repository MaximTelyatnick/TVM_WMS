namespace TVM_WMS.GUI
{
    partial class WaitDialogFm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WaitDialogFm));
            this.breakBtn = new DevExpress.XtraEditors.SimpleButton();
            this.barcodeImageEdit = new DevExpress.XtraEditors.PictureEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.operationPBar = new DevExpress.XtraEditors.MarqueeProgressBarControl();
            this.waitTimer = new System.Windows.Forms.Timer(this.components);
            this.operationInfoLbl = new System.Windows.Forms.Label();
            this.stackerInfoLbl = new System.Windows.Forms.Label();
            this.cellInfoLbl = new System.Windows.Forms.Label();
            this.dropoffInfoLbl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.barcodeImageEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.operationPBar.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // breakBtn
            // 
            this.breakBtn.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.breakBtn.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.breakBtn.Appearance.Options.UseFont = true;
            this.breakBtn.Appearance.Options.UseForeColor = true;
            this.breakBtn.Location = new System.Drawing.Point(11, 391);
            this.breakBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.breakBtn.Name = "breakBtn";
            this.breakBtn.Size = new System.Drawing.Size(441, 38);
            this.breakBtn.TabIndex = 7;
            this.breakBtn.Text = "Отменить операцию";
            this.breakBtn.Click += new System.EventHandler(this.breakBtn_Click);
            // 
            // barcodeImageEdit
            // 
            this.barcodeImageEdit.EditValue = ((object)(resources.GetObject("barcodeImageEdit.EditValue")));
            this.barcodeImageEdit.Location = new System.Drawing.Point(11, 11);
            this.barcodeImageEdit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.barcodeImageEdit.Name = "barcodeImageEdit";
            this.barcodeImageEdit.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.barcodeImageEdit.Properties.Appearance.Options.UseBackColor = true;
            this.barcodeImageEdit.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.barcodeImageEdit.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.barcodeImageEdit.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            this.barcodeImageEdit.Properties.ZoomAccelerationFactor = 1D;
            this.barcodeImageEdit.Properties.ZoomPercent = 30D;
            this.barcodeImageEdit.Size = new System.Drawing.Size(441, 178);
            this.barcodeImageEdit.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 354);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 17);
            this.label3.TabIndex = 62;
            this.label3.Text = "Окно выдачи";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 322);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 17);
            this.label2.TabIndex = 60;
            this.label2.Text = "Ячейка";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 289);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 17);
            this.label1.TabIndex = 57;
            this.label1.Text = "Манипулятор";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 256);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 17);
            this.label4.TabIndex = 56;
            this.label4.Text = "Операция";
            // 
            // operationPBar
            // 
            this.operationPBar.EditValue = 0;
            this.operationPBar.Location = new System.Drawing.Point(11, 197);
            this.operationPBar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.operationPBar.Name = "operationPBar";
            this.operationPBar.Properties.MarqueeAnimationSpeed = 70;
            this.operationPBar.Properties.ProgressAnimationMode = DevExpress.Utils.Drawing.ProgressAnimationMode.Cycle;
            this.operationPBar.Properties.ProgressViewStyle = DevExpress.XtraEditors.Controls.ProgressViewStyle.Solid;
            this.operationPBar.Size = new System.Drawing.Size(441, 34);
            this.operationPBar.TabIndex = 2;
            // 
            // waitTimer
            // 
            this.waitTimer.Tick += new System.EventHandler(this.waitTimer_Tick);
            // 
            // operationInfoLbl
            // 
            this.operationInfoLbl.BackColor = System.Drawing.Color.White;
            this.operationInfoLbl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.operationInfoLbl.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.operationInfoLbl.Location = new System.Drawing.Point(107, 254);
            this.operationInfoLbl.Name = "operationInfoLbl";
            this.operationInfoLbl.Size = new System.Drawing.Size(345, 23);
            this.operationInfoLbl.TabIndex = 63;
            this.operationInfoLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // stackerInfoLbl
            // 
            this.stackerInfoLbl.BackColor = System.Drawing.Color.White;
            this.stackerInfoLbl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.stackerInfoLbl.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.stackerInfoLbl.Location = new System.Drawing.Point(107, 287);
            this.stackerInfoLbl.Name = "stackerInfoLbl";
            this.stackerInfoLbl.Size = new System.Drawing.Size(345, 23);
            this.stackerInfoLbl.TabIndex = 64;
            this.stackerInfoLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cellInfoLbl
            // 
            this.cellInfoLbl.BackColor = System.Drawing.Color.White;
            this.cellInfoLbl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cellInfoLbl.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.cellInfoLbl.Location = new System.Drawing.Point(107, 320);
            this.cellInfoLbl.Name = "cellInfoLbl";
            this.cellInfoLbl.Size = new System.Drawing.Size(345, 23);
            this.cellInfoLbl.TabIndex = 65;
            this.cellInfoLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dropoffInfoLbl
            // 
            this.dropoffInfoLbl.BackColor = System.Drawing.Color.White;
            this.dropoffInfoLbl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dropoffInfoLbl.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dropoffInfoLbl.Location = new System.Drawing.Point(107, 352);
            this.dropoffInfoLbl.Name = "dropoffInfoLbl";
            this.dropoffInfoLbl.Size = new System.Drawing.Size(345, 23);
            this.dropoffInfoLbl.TabIndex = 66;
            this.dropoffInfoLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // WaitDialogFm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 443);
            this.ControlBox = false;
            this.Controls.Add(this.dropoffInfoLbl);
            this.Controls.Add(this.cellInfoLbl);
            this.Controls.Add(this.stackerInfoLbl);
            this.Controls.Add(this.operationInfoLbl);
            this.Controls.Add(this.breakBtn);
            this.Controls.Add(this.barcodeImageEdit);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.operationPBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WaitDialogFm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Выполнение операции";
            ((System.ComponentModel.ISupportInitialize)(this.barcodeImageEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.operationPBar.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton breakBtn;
        private DevExpress.XtraEditors.PictureEdit barcodeImageEdit;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraEditors.MarqueeProgressBarControl operationPBar;
        private System.Windows.Forms.Timer waitTimer;
        private System.Windows.Forms.Label operationInfoLbl;
        private System.Windows.Forms.Label stackerInfoLbl;
        private System.Windows.Forms.Label cellInfoLbl;
        private System.Windows.Forms.Label dropoffInfoLbl;
    }
}