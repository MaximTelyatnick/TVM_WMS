using System.ComponentModel.DataAnnotations;

namespace TVM_WMS.DAL.Entities.QueryModel
{
   public class StorageGroupsByZones
    {
       [Key]
       public int StorageGroupId { get; set; }
       public string StorageGroupName { get; set; }
       public string Description { get; set; }
       
       public int? StorageGroupZoneId { get; set; }
               
       public int? ZoneNameId { get; set; }
       public string ZoneName { get; set; }
       public string ZoneColor { get; set; }
    }
}
