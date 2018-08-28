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
using TVM_WMS.BLL.DTO.QueryDTO;

namespace TVM_WMS.GUI
{
    public partial class StoreCellPresenceFm : DevExpress.XtraEditors.XtraForm
    {
        private List<StorageGroupZonePresenceDTO> _dataSource;
        private List<StorageGroupZonePresenceDTO> warehouseHeaderList;
        private List<StorageGroupZonePresenceDTO> warehouseMaterialList;

        private BindingSource warehouseBS = new BindingSource();

        private StorageGroupZonePresenceDTO returnItem = new StorageGroupZonePresenceDTO();
        private int currentWarehouseId;

        public StoreCellPresenceFm(List<StorageGroupZonePresenceDTO> dataSource)
        {
            InitializeComponent();

            _dataSource = dataSource;

            warehouseHeaderList = _dataSource.GroupBy(g => new { g.WareHouseId }).Select(s => new StorageGroupZonePresenceDTO
            {
                WareHouseId = s.First().WareHouseId,
                StoreName = s.First().StoreName,
                RowName = s.First().RowName,
                NumberCell = s.First().NumberCell,
                CellMeasure = s.First().CellMeasure,
                CellPresence = s.First().CellPresence,
                MaxWeight = s.First().MaxWeight,
                CurrentWeight = s.First().CurrentWeight,
                FreeWeight = s.First().FreeWeight,
                ZoneTypeName = s.First().ZoneTypeName
            }).ToList();

            warehouseBS.DataSource = warehouseHeaderList;
            cellPresenceGrid.DataSource = warehouseBS;
        }

        private void applyBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        public StorageGroupZonePresenceDTO Return()
        {
            return returnItem;
        }

        private void cellPresenceGridView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            returnItem = (StorageGroupZonePresenceDTO)warehouseBS.Current;

            currentWarehouseId = ((StorageGroupZonePresenceDTO)warehouseBS.Current).WareHouseId;

            warehouseMaterialList = _dataSource.Where(s => s.WareHouseId == currentWarehouseId).ToList();

            materialGrid.DataSource = warehouseMaterialList;
        }

        private void cellPresenceGridView_CustomRowCellEdit(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            if (e.Column == cellPresenceColumn)
            {
                decimal percent = Convert.ToDecimal(e.CellValue);
                if (percent <= 30)
                {
                    e.RepositoryItem = cellPresenceRepositoryGreen;
                }
                if (percent > 30 && percent < 70)
                {
                    e.RepositoryItem = cellPresenceRepositoryYellow;
                }
                if (percent >= 70)
                {
                    e.RepositoryItem = cellPresenceRepositoryRed;
                }
            }
        }
    }
}