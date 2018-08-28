using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TVM_WMS.DAL.Entities
{
    public class PackingTypes
    {
        [Key]
        public int PackingTypeId { get; set; }
        public string PackingName { get; set; }

    }
}