using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ninject;
using System;
using System.Collections;

using TVM_WMS.BLL.BusinessLogicModule;
using TVM_WMS.BLL.Interfaces;
using TVM_WMS.BLL.Services;
using TVM_WMS.BLL.DTO;
using System.Collections.Generic;
using TVM_WMS.BLL.DTO.QueryDTO;

namespace TVM_WMS.GUI
{
    public partial class RequirementOrderEditFm : Form
    {
        private IPersonsService personsService;
        private BindingSource personsBS = new BindingSource();
        private IRequirementsService requirementsService;
        private BindingSource requirementOrdersBS = new BindingSource();
        private BindingSource requirementMaterialsBS = new BindingSource();

        private Utils.Operation operation;
        private Action<object> callback;
        private RequirementOrdersDTO order2;

        private List<KeepingMaterialsDTO> result;
        private IEnumerable<RequirementMaterialsDTO> requirementMaterialsByOrder;
       // private List<RequirementMaterialsDTO> requirementMaterialsDTO;


        private RequirementOrderEditFm(Utils.Operation operation)
        {
            InitializeComponent();
            LoadRequirementOrdersData();

            this.operation = operation;

            requirementNumberTBox.DataBindings.Add("EditValue", requirementOrdersBS, "RequirementNumber");
            requirementDateTBox.DataBindings.Add("EditValue", requirementOrdersBS, "RequirementDate");
            
            personsBS.DataSource = personsService.GetPersons();
            responsiblePersonEdit.Properties.DataSource = personsBS;
            responsiblePersonEdit.Properties.ValueMember = "PersonId";
            responsiblePersonEdit.Properties.DisplayMember = "Name";
            responsiblePersonEdit.Properties.NullText = "Нет данных";
        }

        private void LoadRequirementOrdersData()
        {
            requirementsService = Program.kernel.Get<IRequirementsService>();
            personsService = Program.kernel.Get<IPersonsService>();
        }

        private void LoadRequirementMaterialsData()
        {
            requirementMaterialsByOrder = requirementsService.GetRequirementMaterials().Where(m => m.RequirementOrderId == ((RequirementOrdersDTO)requirementOrdersBS.Current).RequirementOrderId).ToList();

            requirementMaterialsBS.DataSource = requirementMaterialsByOrder;
            this.requirementMaterialsGrid.DataSource = requirementMaterialsBS;
        }

        public RequirementOrderEditFm(Utils.Operation operation, RequirementOrdersDTO order, Action<object> callback)
            : this(operation)
        {
            this.callback = callback;
            this.order2 = order;
            responsiblePersonEdit.EditValue = order.ResponsiblePersonId;

            if (this.operation == Utils.Operation.Add)
                this.order2.RequirementDate = DateTime.Today;

            this.requirementOrdersBS.DataSource = this.order2;

            LoadRequirementMaterialsData();

            if (this.operation == Utils.Operation.Update)
                requirementMaterialsGridView.Columns["storeQuantityCol"].Visible = false;
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            requirementMaterialsBS.DataSource = requirementMaterialsByOrder;

            if ((requirementNumberTBox.EditValue.ToString().Length != 0) && (requirementMaterialsBS.Count > 0))
            {
                if (MessageBox.Show("Сохранить изменения?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    this.order2.ResponsiblePersonId = (responsiblePersonEdit.ItemIndex >= 0) ? ((PersonsDTO)responsiblePersonEdit.GetSelectedDataRow()).PersonId : (int?)null;

                    if (this.operation == Utils.Operation.Update)
                    {
                        requirementsService.RequirementOrderUpdate((RequirementOrdersDTO)requirementOrdersBS.Current);

                        if (this.callback != null)
                        {
                            requirementMaterialsBS.DataSource = requirementMaterialsByOrder;

                            List<RequirementMaterialsDTO> requirementMaterialsDTO = (List<RequirementMaterialsDTO>)requirementMaterialsBS.DataSource;

                            for (int i = 0; i <= requirementMaterialsDTO.Count - 1; i++)
                            {
                                switch (requirementMaterialsDTO[i].Changes)
                                {
                                    case 1: //добавлена запись
                                        {
                                            int pId = requirementsService.RequirementMaterialCreate(requirementMaterialsDTO[i]);
                                            break;
                                        }
                                    case 2://отредактирована запись
                                        {
                                            requirementsService.RequirementMaterialUpdate(requirementMaterialsDTO[i]);
                                            break;
                                        }
                                    case 3://удалена запись
                                        {
                                            requirementsService.RequirementMaterialDelete(requirementMaterialsDTO[i]);
                                            break;
                                        }
                                    default:
                                        break;
                                }
                            }

                            this.callback(this.order2);
                            LoadRequirementOrdersData();
                            LoadRequirementMaterialsData();
                        }
                    }
                    else
                    {
                        List<RequirementMaterialsDTO> requirementMaterialsDTO = (List<RequirementMaterialsDTO>)requirementMaterialsBS.DataSource;
                        var quantityNull = requirementMaterialsDTO.Where(c => c.RequiredQuantity > 0).Count();
                       
                        if (quantityNull > 0)
                        {
                            this.order2.RequirementOrderId = requirementsService.RequirementOrderCreate((RequirementOrdersDTO)requirementOrdersBS.Current);

                            requirementMaterialsDTO.Select(c => { c.RequirementOrderId = this.order2.RequirementOrderId; return c; }).ToList();

                            for (int i = 0; i <= requirementMaterialsDTO.Count - 1; i++)
                            {
                                int pId = requirementsService.RequirementMaterialCreate(requirementMaterialsDTO[i]);
                            }
                        }
                    }

                    this.Close();
                }
            }
            else
                MessageBox.Show("Не введен номер документа или содержимое!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void addRequirementMaterialBtn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            RequirementMaterialsEditFm receiptEdit = new RequirementMaterialsEditFm();

            if (receiptEdit.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                result = receiptEdit.Return();

                 var resultMaterials = (from m in result
                         
                          select new  RequirementMaterialsDTO
                          {
                              MaterialId = m.MaterialId,
                              UnitId = m.UnitId,
                              Name = m.MaterialName,
                              Article = m.Article,
                              UnitLocalName = m.UnitLocalName,
                              QuantityStore = m.QuantityStore,
                              Changes = 1,
                              RequirementOrderId = order2.RequirementOrderId,
                              RequiredQuantity = 0
                          })
                           .ToList();

                 for (int i = 0; i <= resultMaterials.Count - 1; i++)
                     requirementMaterialsBS.Add(resultMaterials[i]);

                requirementMaterialsBS.EndEdit();
                requirementMaterialsGridView.Focus();
            }
        }
              

        private void deleteRequirementMaterialBtn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if ((RequirementMaterialsDTO)requirementMaterialsBS.Current != null)
            {
                if (((RequirementMaterialsDTO)requirementMaterialsBS.Current).RequirementMaterialId != 0)
                {
                    requirementMaterialsByOrder.Where(m => m.RequirementMaterialId == ((RequirementMaterialsDTO)requirementMaterialsBS.Current).RequirementMaterialId).Select(c => { c.Changes = 3; return c; }).ToList();

                    requirementMaterialsBS.DataSource = requirementMaterialsByOrder.Where(m => m.Changes != 3);
                    this.requirementMaterialsGrid.DataSource = requirementMaterialsBS;
                }
                else
                {
                    requirementMaterialsBS.RemoveCurrent();
                }

            }
        }

        private void OrderEditFm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (System.Windows.Forms.Application.OpenForms["RequirementOrdersFm"] != null)
            {
                (System.Windows.Forms.Application.OpenForms["RequirementOrdersFm"] as RequirementOrdersFm).LoadOrdersData();
            }
        }

        private void requirementMaterialsGridView_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.Name == "requiredQuantityCol")
            {
                if ((RequirementMaterialsDTO)requirementMaterialsBS.Current != null)
                {
                    if (((RequirementMaterialsDTO)requirementMaterialsBS.Current).RequirementMaterialId != 0)
                    {
                        requirementMaterialsByOrder.Where(m => m.RequirementMaterialId == ((RequirementMaterialsDTO)requirementMaterialsBS.Current).RequirementMaterialId).Select(c => { c.Changes = 2; return c; }).ToList();

                        this.requirementMaterialsGrid.DataSource = requirementMaterialsBS;
                    }
                }
            }
        }
    }
}
