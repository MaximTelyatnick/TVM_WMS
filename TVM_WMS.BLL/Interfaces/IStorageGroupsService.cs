using System.Collections.Generic;
using TVM_WMS.BLL.BusinessLogicModule;
using TVM_WMS.BLL.DTO;
using TVM_WMS.BLL.DTO.QueryDTO;

namespace TVM_WMS.BLL.Interfaces
{
    public interface IStorageGroupsService
    {
        IEnumerable<StorageGroupsByZonesDTO> GetFreeStorageGroups(int storeNameId);
        IEnumerable<StorageGroupsByZonesDTO> GetStorageGroupsByZone(int zoneNameId);
        IEnumerable<StorageGroupsDTO> GetStorageGroups();

        int StorageGroupsCreate(StorageGroupsDTO sndto);
        void StorageGroupsUpdate(StorageGroupsDTO sndto);
        Error.ErrorCRUD StorageGroupsDelete(StorageGroupsDTO storageGroups);

        void Dispose();

    }
}
