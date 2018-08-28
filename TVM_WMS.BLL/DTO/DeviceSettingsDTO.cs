using System;

namespace TVM_WMS.BLL.DTO
{
    public class DeviceSettingsDTO
    {
        public int Id { get; set; }
        public int DeviceId { get; set; }
        public int SettingKindId { get; set; }
        public string SettingValue { get; set; }
    }
}
