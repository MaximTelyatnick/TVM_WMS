using System;

namespace TVM_WMS.BLL.DTO
{
    public class GlobalSettingsDTO
    {
        public int Id { get; set; }
        public int SettingTypeId { get; set; }
        public int SettingKindId { get; set; }
        public string SettingValue { get; set; }
    }
}
