using System.Collections.Generic;
using TVM_WMS.BLL.BusinessLogicModule;
using TVM_WMS.BLL.DTO;

namespace TVM_WMS.BLL.Interfaces
{
    public interface IMaterialsService
    {
        IEnumerable<MaterialsDTO> GetMaterials();
        ZoneNamesDTO GetZoneNameByMaterial(int materialId);

        short MaterialCreate(MaterialsDTO mgdto);
        void MaterialUpdate(MaterialsDTO mgdto);
        Error.ErrorCRUD MaterialDelete(MaterialsDTO mgdto);

        void Dispose();
    }
}
