using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ninject;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;

using TVM_WMS.BLL.BusinessLogicModule;
using TVM_WMS.BLL.Interfaces;
using TVM_WMS.BLL.Services;
using TVM_WMS.BLL.DTO;
using TVM_WMS.BLL.DTO.QueryDTO;

namespace TVM_WMS.GUI
{
    public partial class StorageGroupsByZonesFm : Form
    {
        private IStorageGroupsService storageGroupsService;
        private IStorageGroupZonesService storageGroupZonesService;
        private IZoneNamesService zoneNamesService;

        private BindingSource storageGroupsBS = new BindingSource();
        private BindingSource storageGroupsFreeBS = new BindingSource();
        private BindingSource zoneNamesBS = new BindingSource();
        private IEnumerable<StorageGroupsByZonesDTO> storageGroupsByZones;
        private List<StorageGroupsByZonesDTO> storageGroupsFree;
        private List<StorageGroupsByZonesDTO> storageGroupsFull;

        public StorageGroupsByZonesFm()
        {
            InitializeComponent();

            storageGroupZonesService = Program.kernel.Get<IStorageGroupZonesService>();
            storageGroupsService = Program.kernel.Get<IStorageGroupsService>();
            storageGroupsByZones = storageGroupsService.GetStorageGroupsByZone(0);
            storageGroupsFull = storageGroupsByZones.Where(c => c.ZoneNameId != null).ToList();
            storageGroupsBS.DataSource = storageGroupsFull;
            storageGroupsByZoneGrid.DataSource = storageGroupsBS;

            zoneNamesService = Program.kernel.Get<IZoneNamesService>();
            zoneNamesBS.DataSource = zoneNamesService.GetZones();
            zoneNameGridLookUpEdit.Properties.DataSource = zoneNamesBS;
            zoneNameGridLookUpEdit.Properties.ValueMember = "ZoneNameId";
            zoneNameGridLookUpEdit.Properties.DisplayMember = "ZoneName";
            zoneNameGridLookUpEdit.Properties.NullText = "Нет данных";
            storageGroupsFree = storageGroupsByZones.Where(c => c.ZoneNameId == null).ToList();
            storageGroupsFreeBS.DataSource = storageGroupsFree;
            storageGroupGrid.DataSource = storageGroupsFreeBS;
        }

        private void zoneNamesEdit_EditValueChanged(object sender, EventArgs e)
        {
            object key = zoneNameGridLookUpEdit.EditValue;
            var selectedIndex = zoneNameGridLookUpEdit.Properties.GetIndexByKeyValue(key);

            if (selectedIndex != -1) //если выбрана зона 
            {  
                var selected = ((ZoneNamesDTO)zoneNameGridLookUpEdit.GetSelectedDataRow()).ZoneColor;
                colorPickEdit.EditValue = ColorTranslator.FromHtml(selected);
            }
        }

        private void repositoryItemCheck_CheckStateChanged(object sender, EventArgs e)
        {
            //DevExpress.XtraEditors.CheckEdit editor = sender as DevExpress.XtraEditors.CheckEdit;

            //((StorageGroupsByZonesDTO)storageGroupGridView.GetFocusedRow()).GroupChecked = (editor.CheckState == CheckState.Checked ? 1 : 0);
        }

        private void checkGroupAll_CheckStateChanged(object sender, EventArgs e)
        {
            DevExpress.XtraEditors.CheckEdit editor = sender as DevExpress.XtraEditors.CheckEdit;
            if (editor.CheckState == CheckState.Checked)
            {
                storageGroupsFree.Where(c => c.ZoneNameId == null ).Select(c => { c.GroupChecked = true; return c; }).ToList();
            }
            else
            {
                storageGroupsFree.Where(c => c.ZoneNameId == null).Select(c => { c.GroupChecked = false; return c; }).ToList();
            }
            refreshStorageGroupsFree();
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            storageGroupsFreeBS.EndEdit();
            int countChecked = storageGroupsFree.Count(w => w.GroupChecked);
            
            object key = zoneNameGridLookUpEdit.EditValue;
            var selectedIndex = zoneNameGridLookUpEdit.Properties.GetIndexByKeyValue(key);

            if (selectedIndex != -1 && countChecked > 0)
            {
                int zoneId = ((ZoneNamesDTO)zoneNameGridLookUpEdit.GetSelectedDataRow()).ZoneNameId;
                string zoneName = ((ZoneNamesDTO)zoneNameGridLookUpEdit.GetSelectedDataRow()).ZoneName;
                string zoneColor = ((ZoneNamesDTO)zoneNameGridLookUpEdit.GetSelectedDataRow()).ZoneColor;

                var storageGroupsChecked = storageGroupsFree.Where(c => c.GroupChecked).ToList();

                for (int i = 0; i <= storageGroupsChecked.Count - 1; i++)
                {
                    storageGroupsFull.Add(new StorageGroupsByZonesDTO
                      {
                          StorageGroupZoneId = storageGroupsChecked[i].StorageGroupZoneId,
                          StorageGroupId = storageGroupsChecked[i].StorageGroupId,
                          ZoneNameId = zoneId,
                          ZoneName = zoneName,
                          ZoneColor = zoneColor,
                          StorageGroupName = storageGroupsChecked[i].StorageGroupName
                      });

                    storageGroupsFree.Remove((StorageGroupsByZonesDTO)storageGroupsChecked[i]);
                }

                refreshStorageGroupsFree();
                refreshStorageGroupsFull();
            }
            else
            {
                MessageBox.Show("Не выбрана зона хранения или складская группа!", "Перемещение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                zoneNameGridLookUpEdit.Focus();
            }
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            var storageGroup = ((StorageGroupsByZonesDTO)storageGroupsBS.Current);

            storageGroupsFull.Remove(storageGroup);

            storageGroupsFree.Add(new StorageGroupsByZonesDTO
            {
                StorageGroupZoneId = storageGroup.StorageGroupZoneId,
                StorageGroupId = storageGroup.StorageGroupId,
                ZoneNameId = storageGroup.ZoneNameId,
                ZoneName = storageGroup.ZoneName,
                ZoneColor = storageGroup.ZoneColor,
                StorageGroupName = storageGroup.StorageGroupName,
                GroupChecked = false
            });

            refreshStorageGroupsFree();
            refreshStorageGroupsFull();
        }

        private void refreshStorageGroupsFree()
        {    
            storageGroupsFreeBS.DataSource = null;
            storageGroupsFreeBS.DataSource = storageGroupsFree;
        }

        private void refreshStorageGroupsFull()
        {
            storageGroupsBS.DataSource = null;
            storageGroupsBS.DataSource = storageGroupsFull;
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Сохранить изменения?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                bool result = storageGroupZonesService.RenewalStorageGroupZones(storageGroupsFull);

                if (result)
                {
                    MessageBox.Show("Изменения успешно сохранены!", "Сохранение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                    return;
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void zoneNameGridLookUpEdit_QueryPopUp(object sender, CancelEventArgs e)
        {
            GridLookUpEdit editor = (GridLookUpEdit)sender;
            RepositoryItemGridLookUpEdit properties = editor.Properties;
            properties.PopupFormSize = new Size(editor.Width - 4, properties.PopupFormSize.Height);
        }
    }
}
