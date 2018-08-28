namespace TVM_WMS.GUI
{
    partial class ErrorListControl
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
            this.alarmGrid = new DevExpress.XtraGrid.GridControl();
            this.alarmGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.alarmNumberCol = new DevExpress.XtraGrid.Columns.GridColumn();
            this.alarmTextCol = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.alarmGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.alarmGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // alarmGrid
            // 
            this.alarmGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.alarmGrid.Location = new System.Drawing.Point(0, 0);
            this.alarmGrid.MainView = this.alarmGridView;
            this.alarmGrid.Name = "alarmGrid";
            this.alarmGrid.Size = new System.Drawing.Size(669, 382);
            this.alarmGrid.TabIndex = 20;
            this.alarmGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.alarmGridView});
            // 
            // alarmGridView
            // 
            this.alarmGridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.alarmNumberCol,
            this.alarmTextCol});
            this.alarmGridView.GridControl = this.alarmGrid;
            this.alarmGridView.Name = "alarmGridView";
            this.alarmGridView.OptionsDetail.DetailMode = DevExpress.XtraGrid.Views.Grid.DetailMode.Default;
            this.alarmGridView.OptionsView.ShowGroupPanel = false;
            this.alarmGridView.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            this.alarmGridView.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.alarmGridView_RowStyle);
            // 
            // alarmNumberCol
            // 
            this.alarmNumberCol.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.alarmNumberCol.AppearanceCell.ForeColor = System.Drawing.Color.Black;
            this.alarmNumberCol.AppearanceCell.Options.UseFont = true;
            this.alarmNumberCol.AppearanceCell.Options.UseForeColor = true;
            this.alarmNumberCol.AppearanceCell.Options.UseTextOptions = true;
            this.alarmNumberCol.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.alarmNumberCol.AppearanceHeader.Options.UseTextOptions = true;
            this.alarmNumberCol.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.alarmNumberCol.Caption = "Код ";
            this.alarmNumberCol.FieldName = "AlarmNumber";
            this.alarmNumberCol.Name = "alarmNumberCol";
            this.alarmNumberCol.OptionsColumn.AllowEdit = false;
            this.alarmNumberCol.OptionsColumn.AllowFocus = false;
            this.alarmNumberCol.Visible = true;
            this.alarmNumberCol.VisibleIndex = 0;
            this.alarmNumberCol.Width = 51;
            // 
            // alarmTextCol
            // 
            this.alarmTextCol.AppearanceHeader.Options.UseTextOptions = true;
            this.alarmTextCol.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.alarmTextCol.Caption = "Текст сообщения";
            this.alarmTextCol.FieldName = "AlarmText";
            this.alarmTextCol.Name = "alarmTextCol";
            this.alarmTextCol.OptionsColumn.AllowEdit = false;
            this.alarmTextCol.OptionsColumn.AllowFocus = false;
            this.alarmTextCol.Visible = true;
            this.alarmTextCol.VisibleIndex = 1;
            this.alarmTextCol.Width = 600;
            // 
            // ErrorList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.alarmGrid);
            this.Name = "ErrorList";
            this.Size = new System.Drawing.Size(669, 382);
            ((System.ComponentModel.ISupportInitialize)(this.alarmGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.alarmGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl alarmGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView alarmGridView;
        private DevExpress.XtraGrid.Columns.GridColumn alarmNumberCol;
        private DevExpress.XtraGrid.Columns.GridColumn alarmTextCol;
    }
}
