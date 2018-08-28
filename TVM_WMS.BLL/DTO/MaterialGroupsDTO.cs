using TVM_WMS.BLL.BusinessLogicModule;

namespace TVM_WMS.BLL.DTO
{
    public class MaterialGroupsDTO : ObjectBase
    {
        public short MaterialGroupId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public short? ParentId { get; set; }
    }
}
