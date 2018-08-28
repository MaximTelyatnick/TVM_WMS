using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using TVM_WMS.BLL.BusinessLogicModule;
using TVM_WMS.BLL.Interfaces;
using TVM_WMS.BLL.Services;
using TVM_WMS.BLL.DTO;
using Ninject;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.Utils;
using TVM_WMS.BLL.DTO.QueryDTO;

namespace TVM_WMS.GUI
{
    public partial class RequirementMaterialsEditFm : DevExpress.XtraEditors.XtraForm
    {
        private BindingSource requirementMaterialsBS = new BindingSource();
        private IRequirementsService requirementsService;
        List<KeepingMaterialsDTO> model = new List<KeepingMaterialsDTO>();
       // private Action<object> callback;

        public RequirementMaterialsEditFm()
        {
            InitializeComponent();

            requirementsService = Program.kernel.Get<IRequirementsService>();

            requirementMaterialsBS.DataSource = requirementsService.GetAllKeepingMaterials();
            materialsGrid.DataSource = requirementMaterialsBS;
        }

        public List<KeepingMaterialsDTO> Return()
        {
            return model;
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
          if (materialsGridView.SelectedRowsCount > 0)
          {
            for (int i = 0; i < materialsGridView.SelectedRowsCount; i++)
                model.Add((KeepingMaterialsDTO)materialsGridView.GetRow(materialsGridView.GetSelectedRows()[i]));

            this.Close();
          }
          else
              MessageBox.Show("Не выбраны данные!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
