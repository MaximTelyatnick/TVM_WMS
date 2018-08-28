using System.Collections.Generic;
using TVM_WMS.BLL.DTO;

namespace TVM_WMS.BLL.Interfaces
{
    public interface IPackingTypesService
    {
        IEnumerable<PackingTypesDTO> GetPackingTypes();

        int PackingTypeCreate(PackingTypesDTO pdto);
        void PackingTypeUpdate(PackingTypesDTO pdto);
        bool PackingTypeDelete(PackingTypesDTO pdto);

        void Dispose();
    }
}