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

using TVM_WMS.BLL.BusinessLogicModule;
using TVM_WMS.BLL.Interfaces;
using TVM_WMS.BLL.Services;
using TVM_WMS.BLL.DTO;
using TVM_WMS.BLL.DTO.QueryDTO;

namespace TVM_WMS.GUI
{
    public partial class ZonePresenceFm : Form
    {
        private IStorageGroupZonesService storageGroupZonesService;
                
        private BindingSource zonePresenceBS = new BindingSource();
        
        private IEnumerable<StorageGroupZonePresenceDTO> zonePresenceList;

        private int _zoneNameId;
        private string _zoneName;

        public ZonePresenceFm(int zoneNameId, string zoneName)
        {
            InitializeComponent();
            
            _zoneNameId = zoneNameId;
            _zoneName = zoneName;

            splashScreenManager.ShowWaitForm();
                
            LoadDataByZone(_zoneNameId);
            
            zonePresenceBS.DataSource = zonePresenceList;
            zonePresenceGrid.DataSource = zonePresenceBS;

            zoneNameTBox.EditValue = _zoneName;

            splashScreenManager.CloseWaitForm();
        }

        private void LoadDataByZone(int zoneNameId)
        {
            storageGroupZonesService = Program.kernel.Get<IStorageGroupZonesService>();
            zonePresenceList = storageGroupZonesService.GetStorageGroupZonePresence(zoneNameId, 0, -1);
        }
    }
}
