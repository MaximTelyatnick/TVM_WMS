using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using TVM_WMS.BLL.DTO;
using TVM_WMS.BLL.Interfaces;
using Ninject;
using TVM_WMS.BLL.BusinessLogicModule;
using TVM_WMS.BLL.DTO.QueryDTO;

namespace TVM_WMS.GUI
{
    public partial class DeviceBindingEditControl : DevExpress.XtraEditors.XtraUserControl
    {
        private IStoreNamesService storeNamesService;
        
        private BindingSource devicesBS = new BindingSource();
        private BindingSource storeNamesBS = new BindingSource();
        
        private int _deviceId = -1;
        private int _storeNameId = -1;

        private Utils.DeviceTypes _deviceType;

        public DeviceBindingEditControl(List<DeviceInfoDTO> source, Utils.DeviceTypes deviceType)
        {
            InitializeComponent();

            devicesBS.DataSource = source;
            _deviceType = deviceType;

            if (_deviceType != Utils.DeviceTypes.Stacker)
            {
                storeLbl.Visible = false;
                storeNamesEdit.Visible = false;
            }

            deviceEdit.Properties.DataSource = devicesBS;
            deviceEdit.Properties.ValueMember = "DeviceId";
            deviceEdit.Properties.DisplayMember = "Name";

            storeNamesService = Program.kernel.Get<IStoreNamesService>();
            storeNamesBS.DataSource = storeNamesService.GetStoreNameWithFullHeader().Where(w => w.EnableAuthomatization > 0);
            storeNamesEdit.Properties.DataSource = storeNamesBS;
            storeNamesEdit.Properties.ValueMember = "StoreNameId";
            storeNamesEdit.Properties.DisplayMember = "Name";

            storeNamesEdit.ItemIndex = 1;
        }

        private void deviceEdit_EditValueChanged(object sender, EventArgs e)
        {
            if (deviceEdit.EditValue != null)
                _deviceId = (int)deviceEdit.EditValue;
        }

        private void storeNamesEdit_EditValueChanged(object sender, EventArgs e)
        {
            if (storeNamesEdit.EditValue != null)
                _storeNameId = (int)storeNamesEdit.EditValue;
        }

        public int ReturnDeviceId()
        {
            return _deviceId;
        }

        public int ReturnStoreNameId()
        {
            return _storeNameId;
        }
        
   }
}
