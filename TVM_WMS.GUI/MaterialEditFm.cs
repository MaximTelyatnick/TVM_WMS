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
using TVM_WMS.BLL.Interfaces;
using TVM_WMS.BLL.BusinessLogicModule;
using TVM_WMS.BLL.DTO;
using Ninject;
using DevExpress.XtraEditors.DXErrorProvider;

namespace TVM_WMS.GUI
{
    public partial class MaterialEditFm : DevExpress.XtraEditors.XtraForm
    {
        private IMaterialsService materialsService;
        private IStorageGroupsService storageGroupsService;
        private IMaterialGroupsService materialGroupsService;
        
        private BindingSource materialBS = new BindingSource();
        private BindingSource materialGroupsBS = new BindingSource();
       
        private Utils.Operation operation;

        public ObjectBase Item
        {
            get { return materialBS.Current as ObjectBase; }
            set
            {
                materialBS.DataSource = value;
                //set in edit mode
                value.BeginEdit();
            }
        }

        public MaterialEditFm(Utils.Operation operation, MaterialsDTO material)
        {
            InitializeComponent();
            LoadMaterialsData();
            this.operation = operation;
            materialBS.DataSource = Item = material;

            articleTBox.DataBindings.Add("EditValue", materialBS, "Article");
            nameTBox.DataBindings.Add("EditValue", materialBS, "Name");
            descriptionTBox.DataBindings.Add("EditValue", materialBS, "Description");
            notesTBox.DataBindings.Add("EditValue", materialBS, "Notes");

            storageGroupsEdit.DataBindings.Add("EditValue", materialBS, "StorageGroupId", true, DataSourceUpdateMode.OnPropertyChanged);
            storageGroupsEdit.Properties.DataSource = storageGroupsService.GetStorageGroups();
            storageGroupsEdit.Properties.ValueMember = "StorageGroupId";
            storageGroupsEdit.Properties.DisplayMember = "StorageGroupName";

            materialGroupsEdit.DataBindings.Add("EditValue", materialBS, "MaterialGroupId", true, DataSourceUpdateMode.OnPropertyChanged);
            materialGroupsEdit.Properties.DataSource = materialGroupsService.GetMaterialGroups();
            materialGroupsEdit.Properties.ValueMember = "MaterialGroupId";
            materialGroupsEdit.Properties.DisplayMember = "Name";
            materialGroupsTreeList.KeyFieldName = "MaterialGroupId";
            materialGroupsTreeList.ParentFieldName = "ParentId";
            materialGroupsEdit.Properties.NullText = "[нет данных]";

            if (operation == Utils.Operation.Add)
            {
                storageGroupsEdit.EditValue = 0;
                materialGroupsEdit.EditValue = ((MaterialsDTO)Item).MaterialGroupId == null ? 0 : ((MaterialsDTO)Item).MaterialGroupId;
            }

        }
        #region  Event's

        private void saveBtn_Click(object sender, System.EventArgs e)
        {
            if (!ControlValidation()) return;

            if (MessageBox.Show("Сохранить изменения?", "Сохранение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (operation == Utils.Operation.Add && IsDuplicateRecord(((MaterialsDTO)Item).Article))
                {
                    MessageBox.Show("Номенклатура с такими кодом уже существует!", "Сохранение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    articleTBox.Focus();
                    return;
                }

                SaveMaterial();

                DialogResult = DialogResult.OK;
                this.Close();
            }

            this.Close();
        }

        private void storageGroupsEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            switch (e.Button.Index)
            {
                case 1: //Add
                    {
                        using (StorageGroupEditFm storageGroupEditFm = new StorageGroupEditFm(Utils.Operation.Add, new StorageGroupsDTO()))
                        {
                            if (storageGroupEditFm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                            {
                                int return_StorageGroupId = storageGroupEditFm.Return();
                                
                                storageGroupsService = Program.kernel.Get<IStorageGroupsService>();
                                storageGroupsEdit.Properties.DataSource = storageGroupsService.GetStorageGroups();
                                storageGroupsEdit.EditValue = return_StorageGroupId;
                            }
                        }
                        break;
                    }
                case 2: //Edit
                    {
                        using (StorageGroupEditFm storageGroupEditFm = new StorageGroupEditFm(Utils.Operation.Add, (StorageGroupsDTO)storageGroupsEdit.GetSelectedDataRow()))
                        {
                            if (storageGroupEditFm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                            {
                                int return_StorageGroupId = storageGroupEditFm.Return();
                                
                                storageGroupsService = Program.kernel.Get<IStorageGroupsService>();
                                storageGroupsEdit.Properties.DataSource = storageGroupsService.GetStorageGroups();
                                storageGroupsEdit.EditValue = return_StorageGroupId;
                            }
                        }
                        break;
                    }

                default:
                    {
                        break;
                    }
            }
        }
        
        private void cancelBtn_Click(object sender, System.EventArgs e)
        {
            this.Item.CancelEdit();
            this.Close();
        }

        #endregion

        #region  Method's

        private void LoadMaterialsData()
        {
            materialsService = Program.kernel.Get<IMaterialsService>();
            storageGroupsService = Program.kernel.Get<IStorageGroupsService>();
            materialGroupsService = Program.kernel.Get<IMaterialGroupsService>();
        }

        private void SaveMaterial()
        {
            this.Item.EndEdit();

            if (this.operation == Utils.Operation.Add)
                ((MaterialsDTO)Item).MaterialId = materialsService.MaterialCreate((MaterialsDTO)Item);
            else
                materialsService.MaterialUpdate((MaterialsDTO)Item);
        }

        private bool ControlValidation()
        {
            return materialValidationProvider.Validate();
        }

        private bool IsDuplicateRecord(string article)
        {
            int itemCount = materialsService.GetMaterials().Count(s => s.Article == article);

            return (itemCount > 0);
        }

        public int Return()
        {
            return ((MaterialsDTO)Item).MaterialId;
        }

        #endregion

        #region Validation's

        private void articleTBox_TextChanged(object sender, EventArgs e)
        {
            materialValidationProvider.Validate((Control)sender);
        }

        private void nameTBox_TextChanged(object sender, EventArgs e)
        {
            materialValidationProvider.Validate((Control)sender);
        }

        private void materialGroupsEdit_EditValueChanged(object sender, EventArgs e)
        {
            materialValidationProvider.Validate((Control)sender);
        }

        private void materialValidationProvider_ValidationFailed(object sender, DevExpress.XtraEditors.DXErrorProvider.ValidationFailedEventArgs e)
        {
            this.saveBtn.Enabled = false;
            this.validateLbl.Visible = true;
        }

        private void materialValidationProvider_ValidationSucceeded(object sender, DevExpress.XtraEditors.DXErrorProvider.ValidationSucceededEventArgs e)
        {
            bool isValidate = (materialValidationProvider.GetInvalidControls().Count == 0);
            this.saveBtn.Enabled = isValidate;
            this.validateLbl.Visible = !isValidate;
        }
        #endregion

    }
}
