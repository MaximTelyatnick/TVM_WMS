using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using TVM_WMS.BLL.BusinessLogicModule;
using TVM_WMS.BLL.Interfaces;
using TVM_WMS.BLL.Services;
using TVM_WMS.BLL.DTO;
using TVM_WMS.BLL.DTO.QueryDTO;
using Ninject;
using DevExpress.XtraPrinting;
using System.IO;

namespace TVM_WMS.GUI
{
    public partial class DeficitMaterialsFm : DevExpress.XtraEditors.XtraForm
    {
        private IDeficitMaterialsService deficitMaterialsService;
        private BindingSource deficitMaterialsBS = new BindingSource();
        private int calcValue;
        private bool access;

        public DeficitMaterialsFm()
        {
            InitializeComponent();
            splashScreenManager.ShowWaitForm();
            calcValue = 7;
            dayEditItem.EditValue = calcValue;
            LoadData(Int32.Parse(dayEditItem.EditValue.ToString()));

            access = UsersService.AuthorizatedUserAccess.Any(c => c.TaskName == "deficitItem" && c.AccessRightId == 1);//чтение
            if (access)
                AuthorizatedUserAccess();

            splashScreenManager.CloseWaitForm();
        }

        #region Event's

        private void deficitGridView_CustomRowCellEdit(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            stockPersentColColoring(e);
        }

        private void deficitGrid_DoubleClick(object sender, EventArgs e)
        {
            DeficitEdit();
        }
        #endregion

        #region Metod's

        private void LoadData(int calcDays)
        {
            deficitMaterialsService = Program.kernel.Get<IDeficitMaterialsService>();
            var deficitMaterials = deficitMaterialsService.GetDeficitCalcMaterials(calcDays);
            deficitMaterialsBS.DataSource = deficitMaterials;
            deficitGrid.DataSource = deficitMaterialsBS;
        }

        public void AuthorizatedUserAccess()
        {
            addNormBtn.Enabled = false;
        }

        private void stockPersentColColoring(DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            if (e.Column == stockPersentCol)
            {
                decimal percent = Convert.ToInt32(e.CellValue);
                if (percent <= 25)
                {
                    e.RepositoryItem = repositoryItemProgressBar1;
                }
                if (percent > 25 && percent < 60)
                {
                    e.RepositoryItem = repositoryItemProgressBar2;
                }
                if (percent >= 60)
                {
                    e.RepositoryItem = repositoryItemProgressBar3;
                }
            }
        }

        private void DeficitEdit()
        {
            var current = (DeficitCalcMaterialsDTO)deficitMaterialsBS.Current;
            Utils.Operation operation;

            if (current.DeficitMaterialId != null)
                operation = Utils.Operation.Update;
            else
                operation = Utils.Operation.Add;

            using (DeficitEditFm deficitEditFm = new DeficitEditFm(operation, current))
            {
                if (deficitEditFm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    int return_DeficitMaterialId = deficitEditFm.Return();

                    deficitGridView.BeginUpdate();
                    LoadData(calcValue);
                    deficitGridView.EndUpdate();
                    deficitGrid.Refresh();
                }
            }
        }

        private void DeficitPrint()
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
                    link.Component = deficitGrid;
                    link.Landscape = true;// ориентация альбомная
                    link.PaperKind = System.Drawing.Printing.PaperKind.A4;

                    string fileExtenstion = new FileInfo(exportFilePath).Extension;

                    switch (fileExtenstion)
                    {
                        case ".pdf":
                            deficitGridView.OptionsPrint.ExpandAllDetails = true;
                            deficitGridView.OptionsPrint.AutoWidth = true;
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

        #endregion

        private void repositoryItemCalcButtonEdit_Click(object sender, EventArgs e)
        {
            ButtonEdit editor = sender as ButtonEdit;
            calcValue = Int32.Parse(editor.EditValue.ToString());
            LoadData(calcValue);
        }

        private void addNormBtn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DeficitEdit();
        }

        private void printDeficitBtn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DeficitPrint();
        }

        private void refreshDataBtn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            splashScreenManager.ShowWaitForm();
            calcValue = Int32.Parse(dayEditItem.EditValue.ToString());
            LoadData(calcValue);
            splashScreenManager.CloseWaitForm();
        }

        
}
}