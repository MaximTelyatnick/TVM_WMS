using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TVM_WMS.DAL.Entities
{
    public class UserRoles
    {
        [Key]
        public int RoleId { get; set; }
        public string RoleName { get; set; }
    }
}
