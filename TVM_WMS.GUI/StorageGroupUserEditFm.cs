using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ninject;
using System.Collections;
using DevExpress.XtraTreeList;
using System.Collections.Generic;
using System.ComponentModel;

using DevExpress.XtraEditors;
using DevExpress.Utils;
using DevExpress.XtraEditors.Controls;

using TVM_WMS.BLL.BusinessLogicModule;
using TVM_WMS.BLL.Interfaces;
using TVM_WMS.BLL.Services;
using TVM_WMS.BLL.DTO;

namespace TVM_WMS.GUI
{
    public partial class StorageGroupUserEditFm : DevExpress.XtraEditors.XtraForm
    {
        private IStorageGroupsService storageGroupsService;

        private BindingSource storageGroupsBS = new BindingSource();
        
        private List<StorageGroupsDTO> _returnStorageGroupList = new List<StorageGroupsDTO>();
        private List<StorageGroupsDTO> _existsStorageGroupList = new List<StorageGroupsDTO>();
        private List<StorageGroupsDTO> _currentStorageGroupList = new List<StorageGroupsDTO>();

        public StorageGroupUserEditFm(List<StorageGroupsDTO> existsStorageGroupList)
        {
            InitializeComponent();

            _existsStorageGroupList = existsStorageGroupList;

            LoadData();

            storageGroupsBS.DataSource = _currentStorageGroupList;
            storageGroupGrid.DataSource = storageGroupsBS;
        }

        private void LoadData()
        {
            storageGroupsService = Program.kernel.Get<IStorageGroupsService>();
            var query = storageGroupsService.GetStorageGroups().Where(s => !_existsStorageGroupList.Where(sg => sg.StorageGroupId == s.StorageGroupId).Any()).ToList();
            _currentStorageGroupList = query.Select(c => { c.GroupChecked = false; return c; }).ToList();
        }

        public List<StorageGroupsDTO> Return()
        {
            return _returnStorageGroupList;
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            _returnStorageGroupList = _currentStorageGroupList.Where(c => c.GroupChecked == true).ToList();

            if (_returnStorageGroupList.Count > 0)
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Сохранение отменено. Выберите одну или несколько групп!", "Добавление складских групп", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }
    }

}