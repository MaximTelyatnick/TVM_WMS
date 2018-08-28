using System.ComponentModel.DataAnnotations;

namespace TVM_WMS.DAL.Entities
{
    public class Persons
    {
        [Key]   
        public int PersonId { get; set; }
        public string PersonName { get; set; }
        public int? ProfessionId { get; set; }

    }
}
