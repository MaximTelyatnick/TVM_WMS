using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TVM_WMS.DAL.Entities
{
    public class EnumerationTypes
    {
        [Key]
        public int EnumerationTypeId{ get; set; }
        public string EnumerationTypeName { get; set; }
    }
}
