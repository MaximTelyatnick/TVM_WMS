using System;
using System.ComponentModel.DataAnnotations;

namespace TVM_WMS.DAL.Entities
{
    public class SettingTypes
    {
        [Key]
        public int Id { get; set; }
        public string SettingSectionName { get; set; }
    }
}
