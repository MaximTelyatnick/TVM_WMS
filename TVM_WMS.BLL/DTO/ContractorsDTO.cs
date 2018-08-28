using TVM_WMS.BLL.BusinessLogicModule;

namespace TVM_WMS.BLL.DTO
{
    public class ContractorsDTO : ObjectBase
    {
        public int ContractorId { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string Srn { get; set; }
        public string Tin { get; set; }
    }
}
