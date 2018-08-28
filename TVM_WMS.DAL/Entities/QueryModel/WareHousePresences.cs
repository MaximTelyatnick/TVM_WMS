﻿using System;
using System.ComponentModel.DataAnnotations;

namespace TVM_WMS.DAL.Entities.QueryModel
{
    public class WareHousePresences
    {
        [Key]
        public int KeepingId { get; set; }
        public int ReceiptAcceptanceId { get; set; }
        public int WareHouseId { get; set; }
        public decimal QuantityStore { get; set; }
        public int OrderId { get; set; }
        public string OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public int MaterialId { get; set; }
        public int UnitId { get; set; }
        public decimal? UnitPrice { get; set; }
        public decimal? TotalPrice { get; set; }
        public DateTime? DateProduction { get; set; }
        public DateTime? DateExpiration { get; set; }
        public string Article { get; set; }
        public string MaterialName { get; set; }
        public string UnitLocalName { get; set; }
        public int? ContractorId { get; set; }
        public string ContractorName { get; set; }
        public int NumberCell { get; set; }
        public int StoreNameId { get; set; }
        public int StoreNameParentId { get; set; }
        public int ZoneNameId { get; set; }
        public string ZoneName { get; set; }
        public int StorageGroupId { get; set; }
        public string StorageGroupName { get; set; }
    }
}