using TVM_WMS.BLL.BusinessLogicModule;

namespace TVM_WMS.BLL.DTO
{
    public class UserRolesDTO : ObjectBase
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
    }
}
