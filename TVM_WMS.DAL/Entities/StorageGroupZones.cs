using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TVM_WMS.DAL.Entities
{
    public class StorageGroupZones
    {
        [Key]
        public int StorageGroupZoneId { get; set; }
        public int StorageGroupId { get; set; }
        public int ZoneNameId { get; set; }

    }
}