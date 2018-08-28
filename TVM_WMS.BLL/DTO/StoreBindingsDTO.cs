using System;

namespace TVM_WMS.BLL.DTO
{
    public class StoreBindingsDTO
    {
        public int Id { get; set; }
        public int DeviceBindingId { get; set; }
        public int StoreNameId { get; set; }
        public string Name { get; set; }
    }
}
