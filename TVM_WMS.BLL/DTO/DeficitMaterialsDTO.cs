using TVM_WMS.BLL.BusinessLogicModule;

namespace TVM_WMS.BLL.DTO
{
    public class DeficitMaterialsDTO : ObjectBase
    {
        public int Id { get; set; }
        public int MaterialId { get; set; }
        public int UnitId { get; set; }
        public decimal Rate { get; set; }
    }
}
