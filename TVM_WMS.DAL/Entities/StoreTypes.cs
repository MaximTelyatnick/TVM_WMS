using System.ComponentModel.DataAnnotations;

namespace TVM_WMS.DAL.Entities
{
    public class StoreTypes
    {
        [Key]
        public int StoreTypeId { get; set; }
        public string StoreTypeName { get; set; }
    }
}
