using TVM_WMS.BLL.BusinessLogicModule;

namespace TVM_WMS.BLL.DTO
{
    public class PersonsDTO : ObjectBase
    {
        public int PersonId { get; set; }
        public string PersonName { get; set; }
        public int? ProfessionId { get; set; }
        public string ProfessionName { get; set; }

    }
}
