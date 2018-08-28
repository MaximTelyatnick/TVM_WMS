using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ninject;
using System.Collections;
using DevExpress.XtraTreeList;

using TVM_WMS.BLL.BusinessLogicModule;
using TVM_WMS.BLL.Interfaces;
using TVM_WMS.BLL.Services;
using TVM_WMS.BLL.DTO;
using System.Collections.Generic;
using System;
using DevExpress.Utils.Menu;
using System.Xml.Serialization;
using System.IO;
using DevExpress.XtraPrinting;

namespace TVM_WMS.GUI
{
    public partial class ReceiptsJournalFm : DevExpress.XtraEditors.XtraForm
    {
        private IReceiptsService receiptsService;
        private BindingSource receiptsBS = new BindingSource();
        public class ReceiptsJournal : ObjectBase
        {
            public string Article { get; set; }
            public string Name { get; set; }
            public decimal Quantity { get; set; }
            public string UnitLocalName { get; set; }
        };
        private List<ReceiptsJournal> receiptsJournal;

        public ReceiptsJournalFm()
        {
            InitializeComponent();
            splashScreenManager.ShowWaitForm();
            DateTime beginDate = DateTime.Today;
            DateTime endDate = DateTime.Today;
            beginDateEdit.EditValue = beginDate;
            endDateEdit.EditValue = endDate;
            LoadData();
            splashScreenManager.CloseWaitForm();
            DXPopupMenu menu = new DXPopupMenu();
            menu.Items.Add(new DXMenuItem("PDF", new EventHandler(PDFClick), imageCollection.Images[1]));
            menu.Items.Add(new DXMenuItem("XML", new EventHandler(XMLClick), imageCollection.Images[0]));
            printDropDown.DropDownControl = menu;
        }

        private void showForDate_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            receiptsService = Program.kernel.Get<IReceiptsService>();
            DateTime beginDate = (DateTime)beginDateEdit.EditValue;
            DateTime endDate = (DateTime)endDateEdit.EditValue; ;
            receiptsJournal = receiptsService.GetReceiptsForJournal(beginDate, endDate).GroupBy(x => new { x.MaterialId, x.UnitId }).Select(x => new ReceiptsJournal
                                                                                        {
                                                                                            Article = x.First().Article,
                                                                                            Name = x.First().Name,
                                                                                            Quantity = x.Sum(y => y.Quantity),
                                                                                            UnitLocalName = x.First().UnitLocalName
                                                                                        }).ToList();
            receiptsBS.DataSource = receiptsJournal;
            this.receiptsJournalGrid.DataSource = receiptsBS;

        }

        void XMLClick(object sender, EventArgs e)
        {
            using (SaveFileDialog saveDialog = new SaveFileDialog())
            {
                saveDialog.Filter = "*.xml|*.xml";
                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    string exportFilePath = saveDialog.FileName;
                    XmlSerializer mySerializer = new XmlSerializer(typeof(List<ReceiptsJournal>));
                    using (StreamWriter myXmlWriter = new StreamWriter(exportFilePath))
                    {
                        try
                        {
                            mySerializer.Serialize(myXmlWriter, receiptsJournal);
                            MessageBox.Show("Файл сохранен\n", "Информация", MessageBoxButtons.OK);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Ошибка при сохранении\n" + ex.ToString());
                        }
                    }
                }
            }
        }

        void PDFClick(object sender, EventArgs e)
        {
            using (SaveFileDialog saveDialog = new SaveFileDialog())
            {
                saveDialog.Filter = "*.pdf|*.pdf";
                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    string exportFilePath = saveDialog.FileName;
                    DevExpress.XtraPrinting.PrintableComponentLink link = new DevExpress.XtraPrinting.PrintableComponentLink(new PrintingSystem());
                    link.VerticalContentSplitting = DevExpress.XtraPrinting.VerticalContentSplitting.Exact;
                    link.Margins.Left = 0;
                    link.Margins.Right = 0;
                    link.Margins.Top = 0;
                    link.Margins.Bottom = 0;
                    link.Component = receiptsJournalGrid;
                    //link.Landscape = true;// ориентация альбомная
                    link.PaperKind = System.Drawing.Printing.PaperKind.A4;

                    string fileExtenstion = new FileInfo(exportFilePath).Extension;

                    switch (fileExtenstion)
                    {
                        case ".pdf":
                            receiptsJournalGridView.OptionsPrint.ExpandAllDetails = true;
                            receiptsJournalGridView.OptionsPrint.AutoWidth = true;
                            link.ExportToPdf(exportFilePath);
                            break;
                        default:
                            break;
                    }

                    if (File.Exists(exportFilePath))
                    {
                        try
                        {
                            System.Diagnostics.Process.Start(exportFilePath);
                        }
                        catch
                        {
                            String msg = "The file could not be opened." + Environment.NewLine + Environment.NewLine + "Path: " + exportFilePath;
                            MessageBox.Show(msg, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        String msg = "The file could not be saved." + Environment.NewLine + Environment.NewLine + "Path: " + exportFilePath;
                        MessageBox.Show(msg, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
        }
    }
}