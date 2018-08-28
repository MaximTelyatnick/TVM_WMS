namespace TVM_WMS.GUI
{
    partial class BarcodeLabelCommandReport
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

        #region Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DevExpress.XtraPrinting.BarCode.QRCodeGenerator qrCodeGenerator1 = new DevExpress.XtraPrinting.BarCode.QRCodeGenerator();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.BarcodeText = new DevExpress.XtraReports.UI.XRBarCode();
            this.CommandText = new DevExpress.XtraReports.UI.XRLabel();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.BarcodeText,
            this.CommandText});
            this.Detail.Dpi = 254F;
            this.Detail.HeightF = 850F;
            this.Detail.MultiColumn.Mode = DevExpress.XtraReports.UI.MultiColumnMode.UseColumnWidth;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 254F);
            this.Detail.PageBreak = DevExpress.XtraReports.UI.PageBreak.AfterBand;
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // BarcodeText
            // 
            this.BarcodeText.Alignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.BarcodeText.AutoModule = true;
            this.BarcodeText.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.BarcodeText.Dpi = 254F;
            this.BarcodeText.ForeColor = System.Drawing.Color.Black;
            this.BarcodeText.LocationFloat = new DevExpress.Utils.PointFloat(245.8958F, 109.125F);
            this.BarcodeText.Name = "BarcodeText";
            this.BarcodeText.Padding = new DevExpress.XtraPrinting.PaddingInfo(25, 25, 0, 0, 254F);
            this.BarcodeText.ShowText = false;
            this.BarcodeText.SizeF = new System.Drawing.SizeF(521.6873F, 489.9583F);
            this.BarcodeText.StylePriority.UseBorders = false;
            this.BarcodeText.StylePriority.UseForeColor = false;
            this.BarcodeText.Symbology = qrCodeGenerator1;
            this.BarcodeText.Text = "CONFIRMQUANTITY";
            // 
            // CommandText
            // 
            this.CommandText.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.CommandText.Dpi = 254F;
            this.CommandText.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold);
            this.CommandText.LocationFloat = new DevExpress.Utils.PointFloat(41.52088F, 609.2916F);
            this.CommandText.Multiline = true;
            this.CommandText.Name = "CommandText";
            this.CommandText.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.CommandText.SizeF = new System.Drawing.SizeF(964.6708F, 174.8365F);
            this.CommandText.StylePriority.UseBorders = false;
            this.CommandText.StylePriority.UseFont = false;
            this.CommandText.StylePriority.UseTextAlignment = false;
            this.CommandText.Text = "ПОДТВЕРДИТЬ КОЛИЧЕСТВО";
            this.CommandText.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // TopMargin
            // 
            this.TopMargin.Dpi = 254F;
            this.TopMargin.HeightF = 10F;
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 254F);
            this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // BottomMargin
            // 
            this.BottomMargin.Dpi = 254F;
            this.BottomMargin.HeightF = 16.10399F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 254F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // BarcodeLabelCommandReport
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin});
            this.Dpi = 254F;
            this.Margins = new System.Drawing.Printing.Margins(0, 0, 10, 16);
            this.PageHeight = 900;
            this.PageWidth = 1060;
            this.PaperKind = System.Drawing.Printing.PaperKind.Custom;
            this.ReportUnit = DevExpress.XtraReports.UI.ReportUnit.TenthsOfAMillimeter;
            this.SnapGridSize = 25F;
            this.Version = "16.1";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private DevExpress.XtraReports.UI.XRLabel CommandText;
        private DevExpress.XtraReports.UI.XRBarCode BarcodeText;
    }
}
