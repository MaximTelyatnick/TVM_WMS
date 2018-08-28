using TVM_WMS.BLL.BusinessLogicModule;

namespace TVM_WMS.BLL.DTO
{
    public class AlarmsDTO : ObjectBase
    {
        public int Id { get; set; }
        public int? AlarmNumber { get; set; }
        public string AlarmText { get; set; }
    }
}
