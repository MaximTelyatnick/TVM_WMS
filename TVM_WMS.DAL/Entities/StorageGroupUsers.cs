﻿using System.ComponentModel.DataAnnotations;

namespace TVM_WMS.DAL.Entities
{
    public class StorageGroupUsers
    {
        [Key]
        public int StorageGroupUserId { get; set; }
        public int UserId { get; set; }
        public int StorageGroupId { get; set; }
    }
}
