using System.Collections.Generic;
using TVM_WMS.BLL.DTO;
using TVM_WMS.BLL.DTO.QueryDTO;

namespace TVM_WMS.BLL.Interfaces
{
    public interface IStorageGroupZonesService
    {
        IEnumerable<StorageGroupZonesDTO> GetStorageGroupZones();
        IEnumerable<StorageGroupZonePresenceDTO> GetStorageGroupZonePresence(int zoneNameId, int materialId, int algorithm);
        IEnumerable<StorageGroupZonePresenceDTO> GetReserveZonePresence(int storageId, int loadingStatus);

        bool RenewalStorageGroupZones(List<StorageGroupsByZonesDTO> storageGroupZones);

        int StorageGroupZonesCreate(StorageGroupZonesDTO sndto);
        void StorageGroupZonesUpdate(StorageGroupZonesDTO sndto);
        bool StorageGroupZonesDelete(StorageGroupZonesDTO sndto);

        void CreateRange(List<StorageGroupZonesDTO> sndto);
        void Dispose();

    }
}
