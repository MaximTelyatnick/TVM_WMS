namespace TVM_WMS.GUI
{
    partial class OperationCustomWaitFm
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
            this.operationRGroup = new DevExpress.XtraEditors.RadioGroup();
            this.applyBtn = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.operationRGroup.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // operationRGroup
            // 
            this.operationRGroup.Dock = System.Windows.Forms.DockStyle.Top;
            this.operationRGroup.EditValue = 0;
            this.operationRGroup.Location = new System.Drawing.Point(0, 0);
            this.operationRGroup.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.operationRGroup.Name = "operationRGroup";
            this.operationRGroup.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 14F);
            this.operationRGroup.Properties.Appearance.Options.UseFont = true;
            this.operationRGroup.Properties.Appearance.Options.UseTextOptions = true;
            this.operationRGroup.Properties.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.operationRGroup.Properties.Columns = 1;
            this.operationRGroup.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(0, "Продолжить выполнение операции"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(1, "Вернуть кассету")});
            this.operationRGroup.Size = new System.Drawing.Size(509, 193);
            this.operationRGroup.TabIndex = 1;
            this.operationRGroup.SelectedIndexChanged += new System.EventHandler(this.operationRGroup_SelectedIndexChanged);
            // 
            // applyBtn
            // 
            this.applyBtn.Appearance.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.applyBtn.Appearance.Options.UseFont = true;
            this.applyBtn.Location = new System.Drawing.Point(12, 201);
            this.applyBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.applyBtn.Name = "applyBtn";
            this.applyBtn.Size = new System.Drawing.Size(485, 28);
            this.applyBtn.TabIndex = 2;
            this.applyBtn.Text = "Подтвердить действие";
            this.applyBtn.Click += new System.EventHandler(this.applyBtn_Click);
            // 
            // OperationCustomWaitFm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(509, 244);
            this.Controls.Add(this.applyBtn);
            this.Controls.Add(this.operationRGroup);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OperationCustomWaitFm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Выполнение задания";
            ((System.ComponentModel.ISupportInitialize)(this.operationRGroup.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.RadioGroup operationRGroup;
        private DevExpress.XtraEditors.SimpleButton applyBtn;
    }
}