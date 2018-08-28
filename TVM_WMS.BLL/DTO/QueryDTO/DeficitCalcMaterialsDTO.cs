using System;
using TVM_WMS.BLL.BusinessLogicModule;

namespace TVM_WMS.BLL.DTO.QueryDTO
{
    public class DeficitCalcMaterialsDTO : ObjectBase
    {
        public int RecId { get; set; }
        public int MaterialId { get; set; }
        public int UnitId { get; set; }
        public string Article { get; set; }
        public string Name { get; set; }
        public string UnitLocalName { get; set; }
        public decimal QuantityForDeficit { get; set; }
        public decimal QuantityForKeep { get; set; }
        public decimal QuantityStore { get; set; }
        public decimal Rate { get; set; }
        public int? DeficitMaterialId { get; set; }
        public int StockDayQuantity { get; set; }
        public decimal StockPersent { get; set; }
    }
}
