using System;
using System.ComponentModel.DataAnnotations;

namespace TVM_WMS.DAL.Entities
{
    public class SettingKinds
    {
        [Key]
        public int Id { get; set; }
        public string KindName { get; set; }
        public string Description { get; set; }
    }
}
