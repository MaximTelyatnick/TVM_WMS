using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TVM_WMS.DAL.Entities
{
    public class UserRights
    {
        [Key]
        public int UserRightId { get; set; }
        public short AllowRead { get; set; }
        public short AllowWrite { get; set; }
    }
}
