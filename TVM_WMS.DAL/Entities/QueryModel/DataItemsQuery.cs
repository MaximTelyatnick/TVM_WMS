﻿using System.ComponentModel.DataAnnotations;

namespace TVM_WMS.DAL.Entities.QueryModel
{
    public class DataItemsQuery
    {
        [Key]
        public int Id { get; set; }
        public int DeviceId { get; set; }
        public string Name { get; set; }
        public bool CanListen { get; set; }
        public int ParentDeviceId { get; set; }
        public string Offset { get; set; }
        public int ItemTypeId { get; set; }
        public string TypeName { get; set; }
        public string DeviceName { get; set; }
        public string AbsoleteItemName { get; set; }
    }
}
