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
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraEditors;
using DevExpress.Utils.Win;


namespace TVM_WMS.GUI
{
    public partial class MaterialsFm : DevExpress.XtraEditors.XtraForm
    {
        private IMaterialsService materialsService;
        private BindingSource materialsBS = new BindingSource();

        private IMaterialGroupsService materialGroupsService;
        private BindingSource materialGroupsBS = new BindingSource();
        private BindingSource materialGroupsFindBS = new BindingSource();
        private bool access;

        public MaterialsFm()
        {
            InitializeComponent();
            splashScreenManager.ShowWaitForm();
            LoadMaterialGroupsData();
            LoadMaterialsData();
            access = UsersService.AuthorizatedUserAccess.Any(c => c.TaskName == "materialsItem" && c.AccessRightId == 1);// чтение
            if (access)
                AuthorizatedUserAccess();

            groupsTree.OptionsView.ShowAutoFilterRow = true;
            groupsTree.OptionsBehavior.EnableFiltering = true;
            groupsTree.OptionsFilter.FilterMode = FilterMode.Smart;
            groupsTree.OptionsFind.AllowFindPanel = true;
            groupsTree.OptionsFind.AlwaysVisible = true;
            groupsTree.Columns["Code"].SortOrder = SortOrder.Ascending;
            groupsTree.DataSource = materialGroupsBS;
            groupsTree.KeyFieldName = "MaterialGroupId";
            groupsTree.ParentFieldName = "ParentId";

            splashScreenManager.CloseWaitForm();
        }
        #region Event's

            private void addGroupBtn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
            {
                var groupId = ((MaterialGroupsDTO)materialGroupsBS.Current).MaterialGroupId;
                using (MaterialGroupEditFm materialGroupEditFm = new MaterialGroupEditFm(Utils.Operation.Add, new MaterialGroupsDTO { ParentId = groupId }))
                {
                    if (materialGroupEditFm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        int return_MaterialGroupId = materialGroupEditFm.Return();
                        groupsTree.BeginUpdate();
                        LoadMaterialGroupsData();
                        groupsTree.EndUpdate();
                    }
                }
            }

            private void editGroupBtn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
            {
                if (materialGroupsBS.Count != 0)
                {
                    using (MaterialGroupEditFm materialGroupEditFm = new MaterialGroupEditFm(Utils.Operation.Update, (MaterialGroupsDTO)materialGroupsBS.Current))
                    {
                        if (materialGroupEditFm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        {
                            int return_MaterialGroupId = materialGroupEditFm.Return();
                            groupsTree.BeginUpdate();
                            LoadMaterialGroupsData();
                            groupsTree.EndUpdate();
                        }
                    }
                }
            }

            private void deleteGroupBtn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
            {
                if (materialGroupsBS.Count != 0)
                {
                    if (MessageBox.Show("Удалить группу?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        Error.ErrorCRUD result = materialGroupsService.MaterialGroupDelete((MaterialGroupsDTO)materialGroupsBS.Current);
                        if (result == Error.ErrorCRUD.NoError)
                        {
                            this.materialGroupsBS.RemoveCurrent();
                            this.groupsTree.DataSource = null;
                            this.groupsTree.DataSource = this.materialGroupsBS;
                            LoadMaterialsData();
                        }
                        else
                        {
                            switch (result)
                            {
                                case Error.ErrorCRUD.RelationError:
                                    MessageBox.Show("Группу нельзя удалить. Есть связанные данные!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    break;
                                case Error.ErrorCRUD.DatabaseError:
                                    MessageBox.Show("Ошибка Базы данных!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                }
            }

            private void addMaterial_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
            {
                addMaterial_();
            }

            private void editMaterial_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
            {
                editMaterial_();
            }

            private void materialsGridView_DoubleClick(object sender, System.EventArgs e)
            {
                if (!access)
                {
                    editMaterial_();
                }
            }

            private void deleteMaterial_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
            {
                deleteMaterial_();
            }

            private void groupsTree_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
            {
                if (this.groupsTree.FocusedNode.Selected == true)
                {
                    if ((short)this.groupsTree.FocusedNode[groupsTree.KeyFieldName] != 0) // любая группа
                    {
                        if (!access)
                        {
                            addGroupBtn.Enabled = true;
                            editGroupBtn.Enabled = true;
                            deleteGroupBtn.Enabled = true;
                            addMaterial.Enabled = true;
                        }

                        var source = materialsService.GetMaterials().Where(x => x.MaterialGroupId == (short)this.groupsTree.FocusedNode[groupsTree.KeyFieldName]).ToList();
                        if (source != null)
                        {
                            materialsBS.DataSource = source;
                            materialsGrid.DataSource = materialsBS;
                            if (!access)
                            {
                                editMaterial.Enabled = true;
                                deleteMaterial.Enabled = true;
                            }
                        }
                    }
                    else // Все материалы
                    {
                        if (!access)
                        {
                            addMaterial.Enabled = false;
                            editMaterial.Enabled = false;
                            deleteMaterial.Enabled = false;
                            editGroupBtn.Enabled = false;
                            deleteGroupBtn.Enabled = false;
                        }

                        var source = materialsService.GetMaterials().ToList();
                        if (source != null)
                        {
                            materialsBS.DataSource = source;
                            materialsGrid.DataSource = materialsBS;
                        }
                    }
                }

            }

            private void materialsGridView_KeyDown(object sender, KeyEventArgs e)
            {
                if (!access)
                {
                    if (e.KeyCode == Keys.Delete && ((DevExpress.XtraGrid.Views.Grid.GridView)sender).RowCount > 0)
                    {
                        deleteMaterial_();
                    }
                    if (e.KeyCode == Keys.Insert && ((DevExpress.XtraGrid.Views.Grid.GridView)sender).RowCount > 0)
                    {
                        addMaterial_();
                    }
                }
            }

            private void treeListBtn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
            {
                CheckButton btn = sender as CheckButton;

                if (btn.Checked == true)
                {
                    groupsTree.ExpandAll();
                    groupsTree.Focus();
                    btn.Text = "Свернуть";
                }
                else
                {
                    groupsTree.CollapseAll();
                    groupsTree.Focus();
                    btn.Text = "Развернуть";
                }
            }

            private void CheckItem_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
            {

                if (CheckItem.Checked == true)
                {
                    groupsTree.ExpandAll();
                    groupsTree.Focus();
                    CheckItem.Caption = "Свернуть";
                }
                else
                {
                    groupsTree.CollapseAll();
                    groupsTree.Focus();
                    CheckItem.Caption = "Развернуть";
                }
            }

        #endregion

        #region Metod's

            private void LoadMaterialsData()
            {
                materialsService = Program.kernel.Get<IMaterialsService>();
                materialsBS.DataSource = materialsService.GetMaterials();
                materialsGrid.DataSource = this.materialsBS;
            }

            private void LoadMaterialGroupsData()
            {
                materialGroupsService = Program.kernel.Get<IMaterialGroupsService>();
                materialGroupsBS.DataSource = materialGroupsService.GetMaterialGroups();
                materialGroupsFindBS.DataSource = materialGroupsService.GetMaterialGroups();
                MaterialGroupsDTO allMaterials = new MaterialGroupsDTO { MaterialGroupId = 0, ParentId = null, Name = "Все материалы", Code = "00" };
                int index = materialGroupsBS.Add(allMaterials);
                materialGroupsBS.Position = index;
                groupsTree.DataSource = materialGroupsBS;
            }


            private void addMaterial_()
            {
                if (materialGroupsBS.Count != 0)
                {
                    var groupId = ((MaterialGroupsDTO)materialGroupsBS.Current).MaterialGroupId;
                    using (MaterialEditFm materialEditFm = new MaterialEditFm(Utils.Operation.Add, new MaterialsDTO { MaterialGroupId = groupId }))
                    {
                        if (materialEditFm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        {
                            int return_MaterialId = materialEditFm.Return();
                            materialsGridView.BeginDataUpdate();

                            materialsService = Program.kernel.Get<IMaterialsService>();
                            materialsBS.DataSource = materialsService.GetMaterials();
                            materialsGrid.DataSource = materialsBS;

                            materialsGridView.EndDataUpdate();
                            int rowHandle = materialsGridView.LocateByValue("MaterialId", return_MaterialId);
                            materialsGridView.FocusedRowHandle = rowHandle;
                        }
                    }
                }
            }

            private void editMaterial_()
            {
                if (materialsBS.Count != 0)
                {
                    if (materialsBS.Count != 0)
                    {
                        using (MaterialEditFm materialEditFm = new MaterialEditFm(Utils.Operation.Update, (MaterialsDTO)materialsBS.Current))
                        {
                            if (materialEditFm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                            {
                                int return_MaterialId = materialEditFm.Return();
                                materialsGridView.BeginDataUpdate();

                                materialsService = Program.kernel.Get<IMaterialsService>();
                                materialsBS.DataSource = materialsService.GetMaterials();
                                materialsGrid.DataSource = materialsBS;

                                materialsGridView.EndDataUpdate();
                                int rowHandle = materialsGridView.LocateByValue("MaterialId", return_MaterialId);
                                materialsGridView.FocusedRowHandle = rowHandle;
                            }
                        }
                    }
                }
            }

            private void deleteMaterial_()
            {
                if (materialsBS.Count != 0)
                {
                    if (MessageBox.Show("Удалить материал?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                         Error.ErrorCRUD result = this.materialsService.MaterialDelete((MaterialsDTO)materialsBS.Current);
                         if (result == Error.ErrorCRUD.NoError)
                         {
                             this.materialsBS.RemoveCurrent();
                             LoadMaterialsData();
                         }
                         else
                         {
                             switch (result)
                             {
                                 case Error.ErrorCRUD.RelationError:
                                     MessageBox.Show("Материал нельзя удалить. Есть связанные данные!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                     break;
                                 case Error.ErrorCRUD.DatabaseError:
                                     MessageBox.Show("Ошибка Базы данных!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                     break;
                                 default:
                                     break;
                             }
                         }
                    }
                }
            }

            private void AuthorizatedUserAccess()
            {
                addGroupBtn.Enabled = false;
                editGroupBtn.Enabled = false;
                deleteGroupBtn.Enabled = false;
                addMaterial.Enabled = false;
                 editMaterial.Enabled = false;
                 deleteMaterial.Enabled = false;
            }

        #endregion
       
     }
}
