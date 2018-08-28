namespace TVM_WMS.GUI
{
    partial class AuthorizationFm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AuthorizationFm));
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.loginTBox = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.passwordTBox = new DevExpress.XtraEditors.TextEdit();
            this.signBtn = new DevExpress.XtraEditors.SimpleButton();
            this.settingsBtn = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.loginTBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.passwordTBox.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl2.Location = new System.Drawing.Point(10, 41);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(43, 13);
            this.labelControl2.TabIndex = 40;
            this.labelControl2.Text = "Пароль";
            // 
            // loginTBox
            // 
            this.loginTBox.Location = new System.Drawing.Point(57, 12);
            this.loginTBox.Name = "loginTBox";
            this.loginTBox.Properties.Mask.ShowPlaceHolders = false;
            this.loginTBox.Size = new System.Drawing.Size(195, 20);
            this.loginTBox.TabIndex = 1;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl1.Location = new System.Drawing.Point(17, 15);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(34, 13);
            this.labelControl1.TabIndex = 38;
            this.labelControl1.Text = "Логин";
            // 
            // passwordTBox
            // 
            this.passwordTBox.Location = new System.Drawing.Point(57, 38);
            this.passwordTBox.Name = "passwordTBox";
            this.passwordTBox.Properties.Mask.ShowPlaceHolders = false;
            this.passwordTBox.Size = new System.Drawing.Size(195, 20);
            this.passwordTBox.TabIndex = 2;
            this.passwordTBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.passwordTBox_KeyDown);
            // 
            // signBtn
            // 
            this.signBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.signBtn.Image = ((System.Drawing.Image)(resources.GetObject("signBtn.Image")));
            this.signBtn.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.signBtn.Location = new System.Drawing.Point(162, 96);
            this.signBtn.Name = "signBtn";
            this.signBtn.Size = new System.Drawing.Size(95, 23);
            this.signBtn.TabIndex = 4;
            this.signBtn.Text = "Войти";
            this.signBtn.Click += new System.EventHandler(this.signBtn_Click);
            // 
            // settingsBtn
            // 
            this.settingsBtn.Image = ((System.Drawing.Image)(resources.GetObject("settingsBtn.Image")));
            this.settingsBtn.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.settingsBtn.Location = new System.Drawing.Point(61, 96);
            this.settingsBtn.Name = "settingsBtn";
            this.settingsBtn.Size = new System.Drawing.Size(95, 23);
            this.settingsBtn.TabIndex = 3;
            this.settingsBtn.Text = "Настройки";
            this.settingsBtn.Click += new System.EventHandler(this.settingsBtn_Click);
            // 
            // AuthorizationFm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(269, 131);
            this.Controls.Add(this.signBtn);
            this.Controls.Add(this.settingsBtn);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.loginTBox);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.passwordTBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AuthorizationFm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Авторизация";
            this.Shown += new System.EventHandler(this.AuthorizationFm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.loginTBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.passwordTBox.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit loginTBox;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit passwordTBox;
        private DevExpress.XtraEditors.SimpleButton signBtn;
        private DevExpress.XtraEditors.SimpleButton settingsBtn;
    }
}