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
using TVM_WMS.BLL.DTO;
using TVM_WMS.BLL.Interfaces;
using Ninject;

namespace TVM_WMS.GUI
{
    public partial class SettingsStackerEditFm : DevExpress.XtraEditors.XtraForm
    {
        private ISettingsService settingsService;
        private BindingSource stackerBS = new BindingSource();

        private Utils.Operation _operation;
        private int _deviceId = -1;

        public SettingsStackerEditFm(Utils.Operation operation, DevicesDTO model)
        {
            InitializeComponent();

            _operation = operation;
            stackerBS.DataSource = model;

            nameTBox.DataBindings.Add("EditValue", stackerBS, "Name");
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            if (!ControlValidation()) return;
            
            if (MessageBox.Show("Сохранить изменения?", "Сохранение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                stackerBS.EndEdit();
                
                if (SavePlcSettings())
                {
                    DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private bool ControlValidation()
        {
            return stackerSettingValidationProvider.Validate();
        }


        public int Return()
        {
            return _deviceId;
        }

        private bool SavePlcSettings()
        {
            settingsService = Program.kernel.Get<ISettingsService>();

            if (FindDeviceNameDuplicate((DevicesDTO)stackerBS.Current))
            {
                MessageBox.Show("Устройство с таким именем уже используется для данного комп'ютера. Введите другое наименование.\n",
                                "Проверка уникальности наименования устройства", MessageBoxButtons.OK, MessageBoxIcon.Information);
                nameTBox.Focus();

                return false;
            }

            if (_operation == Utils.Operation.Add)
            {
                int deviceTypeId = settingsService.GetDeviceTypeIdByName("Stacker");
                ((DevicesDTO)stackerBS.Current).TypeId = deviceTypeId;
                ((DevicesDTO)stackerBS.Current).LocalCPUID = ConfigClass.Instance.LocalCPUID;

                stackerBS.EndEdit();

                _deviceId = settingsService.DeviceCreate((DevicesDTO)stackerBS.Current);

                //if (_deviceId > 0)
                //{
                //    ((ConfigClass.PlcSettingSource)plcSettingsBS.Current).DeviceId = _deviceId;
                //    var modelList = ConfigClass.Instance.ConvertPlcSettingsToModel(settingsService, (ConfigClass.PlcSettingSource)plcSettingsBS.Current);
                //    settingsService.DevicePropertiesCreate(modelList);
                //}
                //else
                //{
                //    MessageBox.Show("Ошибка при добавлении нового устройства! Проверьте настройки подключения.\n", "Сохранение", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    return false;
                //}
            }
            else
            {
                settingsService.DeviceUpdate((DevicesDTO)stackerBS.Current);

                //var modelList = ConfigClass.Instance.ConvertPlcSettingsToModel(settingsService, (ConfigClass.PlcSettingSource)plcSettingsBS.Current);
                //settingsService.DevicePropertiesUpdate(modelList);
            }

            return true;
        }

        private bool FindDeviceNameDuplicate(DevicesDTO item)
        {
            bool result = false;

            if (ConfigClass.Instance.DeviceSettingsList != null)
            {
                var source = (ConfigClass.Instance.DeviceSettingsList).FirstOrDefault(s => s.Name == item.Name);

                if (source != null)
                    result = (source.DeviceId != item.Id) ? true : false;
            }

            return result;
        }

        private void stackerSettingValidationProvider_ValidationFailed(object sender, DevExpress.XtraEditors.DXErrorProvider.ValidationFailedEventArgs e)
        {
            this.saveBtn.Enabled = false;
            this.validateLbl.Visible = true;
        }

        private void stackerSettingValidationProvider_ValidationSucceeded(object sender, DevExpress.XtraEditors.DXErrorProvider.ValidationSucceededEventArgs e)
        {
            bool isValidate = (stackerSettingValidationProvider.GetInvalidControls().Count == 0);
            this.saveBtn.Enabled = isValidate;
            this.validateLbl.Visible = !isValidate;
        }

        private void nameTBox_TextChanged(object sender, EventArgs e)
        {
            stackerSettingValidationProvider.Validate((Control)sender);
        }
    }
}