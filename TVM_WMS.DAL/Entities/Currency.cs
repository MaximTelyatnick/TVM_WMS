using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TVM_WMS.DAL.Entities
{
   public class Currency
    {
        [Key]
        public short CurrencyId { get; set; }
        public string CurrencyName { get; set; }
        public string CurrencyCode { get; set; }   
        public string CurrencyNum { get; set; }  
    }
}
