using System.Collections.Generic;
using TVM_WMS.BLL.DTO;
using TVM_WMS.BLL.DTO.QueryDTO;

namespace TVM_WMS.BLL.Interfaces
{
    public interface IDeficitMaterialsService
    {
        IEnumerable<DeficitMaterialsDTO> GetDeficitMaterials();
        IEnumerable<DeficitCalcMaterialsDTO> GetDeficitCalcMaterials(int countDays);

        int DeficitMaterialCreate(DeficitMaterialsDTO dmdto);
        void DeficitMaterialUpdate(DeficitMaterialsDTO dmdto);
        bool DeficitMaterialDelete(DeficitMaterialsDTO dmdto);

        void CreateRange(List<DeficitMaterialsDTO> dmdto);

        void Dispose();
    }
}
