using System.ComponentModel.DataAnnotations;

namespace TVM_WMS.DAL.Entities
{
    public class ZoneTypes
    {
        [Key]
        public int ZoneTypeId { get; set; }
        public string ZoneTypeName { get; set; }
    }
}
