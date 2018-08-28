using System;

namespace TVM_WMS.BLL.DTO
{
    public class DevicesDTO
    {
        public int Id { get; set; }
        public int? TypeId { get; set; }
        public string Name { get; set; }
        public string LocalCPUID { get; set; }
    }
}
