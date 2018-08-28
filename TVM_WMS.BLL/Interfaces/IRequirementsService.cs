using System;
using System.Collections.Generic;
using TVM_WMS.BLL.DTO;
using TVM_WMS.BLL.DTO.QueryDTO;

namespace TVM_WMS.BLL.Interfaces
{
    public interface IRequirementsService
    {
        IEnumerable<RequirementOrdersDTO> GetRequirementOrders(DateTime beginDate, DateTime endDate);
        IEnumerable<RequirementMaterialsDTO> GetRequirementMaterials();
        IEnumerable<KeepingMaterialsDTO> GetAllKeepingMaterials();

        int RequirementOrderCreate(RequirementOrdersDTO rodto);
        void RequirementOrderUpdate(RequirementOrdersDTO rodto);
        bool RequirementOrderDelete(RequirementOrdersDTO rodto);

        int RequirementMaterialCreate(RequirementMaterialsDTO rmdto);
        void RequirementMaterialUpdate(RequirementMaterialsDTO rmdto);
        bool RequirementMaterialDelete(RequirementMaterialsDTO rmdto);
        bool RequirementMaterialAllDelete(int reqiurementOrder_id);
       
        void Dispose();
    }
}
