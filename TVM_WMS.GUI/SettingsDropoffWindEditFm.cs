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
using TVM_WMS.BLL.DTO.QueryDTO;


namespace TVM_WMS.GUI
{
    public partial class SettingsDropoffWindEditFm : DevExpress.XtraEditors.XtraForm
    {

        private ISettingsService settingsService;
        private BindingSource dropoffWindBS = new BindingSource();

        private Utils.Operation _operation;
        private int _deviceId;


        public SettingsDropoffWindEditFm(Utils.Operation operation, DeviceInfoDTO model)
        {
            InitializeComponent();

            _deviceId = (operation == Utils.Operation.Add) ? -1 : model.DeviceId;
            _operation = operation;
            dropoffWindBS.DataSource = model;

            nameTBox.DataBindings.Add("EditValue", dropoffWindBS, "Name");
            windNumberTBox.DataBindings.Add("EditValue", dropoffWindBS, "SettingValue");
        }

        private void dropoffSettingValidationProvider_ValidationFailed(object sender, DevExpress.XtraEditors.DXErrorProvider.ValidationFailedEventArgs e)
        {
            this.saveBtn.Enabled = false;
            this.validateLbl.Visible = true;
        }

        private void dropoffSettingValidationProvider_ValidationSucceeded(object sender, DevExpress.XtraEditors.DXErrorProvider.ValidationSucceededEventArgs e)
        {
            bool isValidate = (dropoffSettingValidationProvider.GetInvalidControls().Count == 0);
            this.saveBtn.Enabled = isValidate;
            this.validateLbl.Visible = !isValidate;
        }

        private void nameTBox_TextChanged(object sender, EventArgs e)
        {
            dropoffSettingValidationProvider.Validate((Control)sender);
        }

        private void textEdit1_TextChanged(object sender, EventArgs e)
        {
            dropoffSettingValidationProvider.Validate((Control)sender);
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            if (!ControlValidation()) return;

            if (MessageBox.Show("Сохранить изменения?", "Сохранение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                dropoffWindBS.EndEdit();

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
            return dropoffSettingValidationProvider.Validate();
        }


        public int Return()
        {
            return _deviceId;
        }

        private bool SavePlcSettings()
        {
            settingsService = Program.kernel.Get<ISettingsService>();

            if (FindDeviceNameDuplicate((DeviceInfoDTO)dropoffWindBS.Current))
            {
                MessageBox.Show("Устройство с таким именем уже используется для данного комп'ютера. Введите другое наименование.\n",
                                "Проверка уникальности наименования устройства", MessageBoxButtons.OK, MessageBoxIcon.Information);
                nameTBox.Focus();

                return false;
            }

            DevicesDTO entity = new DevicesDTO()
            {
                Id = ((DeviceInfoDTO)dropoffWindBS.Current).DeviceId,
                Name = ((DeviceInfoDTO)dropoffWindBS.Current).Name,
                TypeId = ((DeviceInfoDTO)dropoffWindBS.Current).TypeId,
                LocalCPUID = ((DeviceInfoDTO)dropoffWindBS.Current).LocalCPUID
            };
            
            if (_operation == Utils.Operation.Add)
            {
                int deviceTypeId = settingsService.GetDeviceTypeIdByName("DropoffWindow");
                entity.TypeId = deviceTypeId;
                entity.LocalCPUID = ConfigClass.Instance.LocalCPUID;

                dropoffWindBS.EndEdit();

                _deviceId = settingsService.DeviceCreate(entity);

                if (_deviceId > 0)
                {
                    int skId = settingsService.GetSettingKindIdByName("WindNumber");

                    settingsService.DeviceSettingCreate(new DeviceSettingsDTO()
                    {
                        DeviceId = _deviceId,
                        SettingKindId = skId,
                        SettingValue = ((DeviceInfoDTO)dropoffWindBS.Current).SettingValue
                    });
                }
                else
                {
                    MessageBox.Show("Ошибка при добавлении нового устройства! Проверьте настройки подключения.\n", "Сохранение", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            else
            {
                settingsService.DeviceUpdate(entity);

                var model = new DeviceSettingsDTO()
                {
                    Id = ((DeviceInfoDTO)dropoffWindBS.Current).DeviceSettingId ?? 0,
                    DeviceId = ((DeviceInfoDTO)dropoffWindBS.Current).DeviceId,
                    SettingKindId = ((DeviceInfoDTO)dropoffWindBS.Current).SettingKindId ?? 0,
                    SettingValue = ((DeviceInfoDTO)dropoffWindBS.Current).SettingValue
                };

                settingsService.DeviceSettingUpdate(model);
            }

            return true;
        }

        private bool FindDeviceNameDuplicate(DeviceInfoDTO item)
        {
            bool result = false;

            if (ConfigClass.Instance.DeviceSettingsList != null)
            {
                var source = (ConfigClass.Instance.DeviceSettingsList).FirstOrDefault(s => s.Name == item.Name);

                if (source != null)
                    result = (source.DeviceId != item.DeviceId) ? true : false;
            }

            return result;
        }
    }
}