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
using TVM_WMS.BLL.Infrastructure.SerialPortListener;
using TVM_WMS.BLL.Interfaces;
using Ninject;
using TVM_WMS.BLL.DTO;

namespace TVM_WMS.GUI
{
    public partial class SettingScannerEditFm : DevExpress.XtraEditors.XtraForm
    {
        private ISettingsService settingsService;
        private SerialSettings mySerialSettings = new SerialSettings();
        private BindingSource serialSettingsBS = new BindingSource();

        private Utils.Operation _operation;
        private int _deviceId;

        public ObjectBase Item
        {
            get { return serialSettingsBS.Current as ObjectBase; }
            set
            {
                serialSettingsBS.DataSource = value;
                //set in edit mode
                value.BeginEdit();
            }
        }

        public SettingScannerEditFm(Utils.Operation operation, ConfigClass.BarcodeSettingSource source)
        {
            InitializeComponent();
            
            _operation = operation;
            
            serialSettingsBS.DataSource = Item = source;

            nameTBox.DataBindings.Add("EditValue", serialSettingsBS, "Name");
          
            portNameEdit.Properties.DataSource = mySerialSettings.PortNameCollection;
            portNameEdit.Properties.ValueMember = "Column";
            portNameEdit.DataBindings.Add("EditValue", serialSettingsBS, "PortName");

            baudRateEdit.Properties.DataSource = mySerialSettings.BaudRateCollection;
            baudRateEdit.Properties.ValueMember = "Column";
            baudRateEdit.DataBindings.Add("EditValue", serialSettingsBS, "BaudRate");

            dataBitsEdit.Properties.DataSource = mySerialSettings.DataBitsCollection;
            dataBitsEdit.Properties.ValueMember = "Column";
            dataBitsEdit.DataBindings.Add("EditValue", serialSettingsBS, "DataBits");

            parityEdit.Properties.DataSource = Enum.GetValues(typeof(System.IO.Ports.Parity));
            parityEdit.Properties.ValueMember = "Column";
            parityEdit.DataBindings.Add("EditValue", serialSettingsBS, "Parity");

            stopBitsEdit.Properties.DataSource = Enum.GetValues(typeof(System.IO.Ports.StopBits));
            stopBitsEdit.Properties.ValueMember = "Column";
            stopBitsEdit.DataBindings.Add("EditValue", serialSettingsBS, "StopBits");
        }

        #region Method's

        private bool ControlValidation()
        {
            return scannerSettingValidationProvider.Validate();
        }

        public int Return()
        {
            return _deviceId;        
        }

        private bool SaveBarcodeSettings()
        {
            this.Item.EndEdit();
            
            settingsService = Program.kernel.Get<ISettingsService>();

            if (FindDeviceNameDuplicate((ConfigClass.BarcodeSettingSource)serialSettingsBS.Current))
            {
                MessageBox.Show("Устройство с таким именем уже используется для данного комп'ютера. Введите другое наименование.\n", 
                                "Проверка уникальности наименования устройства", MessageBoxButtons.OK, MessageBoxIcon.Information);
                nameTBox.Focus();
                
                return false;
            }

            if (_operation == Utils.Operation.Add)
            {
                int deviceTypeId = settingsService.GetDeviceTypeIdByName("BarcodeScanner");
                _deviceId = settingsService.DeviceCreate(new DevicesDTO()
                {
                    Name = ((ConfigClass.BarcodeSettingSource)serialSettingsBS.Current).Name,
                    LocalCPUID = ConfigClass.Instance.LocalCPUID,
                    TypeId = deviceTypeId
                });

                if (_deviceId > 0)
                {
                    ((ConfigClass.BarcodeSettingSource)serialSettingsBS.Current).DeviceId = _deviceId;
                    var modelList = ConfigClass.Instance.ConvertBarcodeSettingsToModel(settingsService, (ConfigClass.BarcodeSettingSource)serialSettingsBS.Current);
                    settingsService.DevicePropertiesCreate(modelList);
                }
                else
                {
                    MessageBox.Show("Ошибка при добавлении нового устройства! Проверьте настройки подключения.\n", "Сохранение", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            else
            {
                int deviceTypeId = settingsService.GetDeviceTypeIdByName("BarcodeScanner");
                
                settingsService.DeviceUpdate(new DevicesDTO()
                {
                    Id = ((ConfigClass.BarcodeSettingSource)serialSettingsBS.Current).DeviceId,
                    Name = ((ConfigClass.BarcodeSettingSource)serialSettingsBS.Current).Name,
                    LocalCPUID = ConfigClass.Instance.LocalCPUID,
                    TypeId = deviceTypeId
                });

                var modelList = ConfigClass.Instance.ConvertBarcodeSettingsToModel(settingsService, (ConfigClass.BarcodeSettingSource)serialSettingsBS.Current);
                settingsService.DevicePropertiesUpdate(modelList);
            }
            
            return true; 
        }

        private bool FindDeviceNameDuplicate(ConfigClass.BarcodeSettingSource item)
        {
            bool result = false;

            if (ConfigClass.Instance.BarcodeSettingList != null)
            {
                var source = (ConfigClass.Instance.BarcodeSettingList).FirstOrDefault(s => s.Name == item.Name);

                if (source != null)
                    result = (source.DeviceId != item.DeviceId) ? true : false;
            }

            return result;
        }

        #endregion

        #region Event's
        
        private void saveBtn_Click(object sender, EventArgs e)
        {
            if (!ControlValidation()) return;

            if (MessageBox.Show("Сохранить изменения?", "Сохранение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (SaveBarcodeSettings())
                {
                    DialogResult = DialogResult.OK;                   
                    this.Close();
                }
            }
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Item.CancelEdit();
            this.Close();
        }

        #endregion

        #region Validation's

        private void nameTBox_TextChanged(object sender, EventArgs e)
        {
            scannerSettingValidationProvider.Validate((Control)sender);
        }
        
        private void portNameEdit_EditValueChanged(object sender, EventArgs e)
        {
            scannerSettingValidationProvider.Validate((Control)sender);
        }

        private void baudRateEdit_EditValueChanged(object sender, EventArgs e)
        {
            scannerSettingValidationProvider.Validate((Control)sender);
        }

        private void dataBitsEdit_EditValueChanged(object sender, EventArgs e)
        {
            scannerSettingValidationProvider.Validate((Control)sender);
        }

        private void parityEdit_EditValueChanged(object sender, EventArgs e)
        {
            scannerSettingValidationProvider.Validate((Control)sender);
        }

        private void stopBitsEdit_EditValueChanged(object sender, EventArgs e)
        {
            scannerSettingValidationProvider.Validate((Control)sender);
        }

        private void scannerSettingValidationProvider_ValidationFailed(object sender, DevExpress.XtraEditors.DXErrorProvider.ValidationFailedEventArgs e)
        {
            this.saveBtn.Enabled = false;
            this.validateLbl.Visible = true;
        }

        private void scannerSettingValidationProvider_ValidationSucceeded(object sender, DevExpress.XtraEditors.DXErrorProvider.ValidationSucceededEventArgs e)
        {
            bool isValidate = (scannerSettingValidationProvider.GetInvalidControls().Count == 0);
            this.saveBtn.Enabled = isValidate;
            this.validateLbl.Visible = !isValidate;
        }

        #endregion
    }
}