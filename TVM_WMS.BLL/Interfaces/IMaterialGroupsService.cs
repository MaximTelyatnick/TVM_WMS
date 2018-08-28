using System.Collections.Generic;
using TVM_WMS.BLL.BusinessLogicModule;
using TVM_WMS.BLL.DTO;

namespace TVM_WMS.BLL.Interfaces
{
    public interface IMaterialGroupsService
    {
        IEnumerable<MaterialGroupsDTO> GetMaterialGroups();

        short MaterialGroupCreate(MaterialGroupsDTO mgdto);
        void MaterialGroupUpdate(MaterialGroupsDTO mgdto);
        Error.ErrorCRUD MaterialGroupDelete(MaterialGroupsDTO mgdto);
        void Dispose();
    }
}
