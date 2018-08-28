using System.Collections.Generic;
using TVM_WMS.BLL.DTO;
using TVM_WMS.BLL.DTO.QueryDTO;

namespace TVM_WMS.BLL.Interfaces
{
    public interface IZoneNamesService
    {
        IEnumerable<ZoneNamesDTO> GetZoneNames(int storeNameIdParam);
        IEnumerable<ZoneNamesDTO> GetZones();
        IEnumerable<ZoneTypesDTO> GetZoneTypes();
        IEnumerable<ZoneNamesByStoreDTO> GetZoneNameByStore();
        IEnumerable<ZoneNamesDTO> GetZonesUnspecified();
        IEnumerable<CellQuantityByZonesDTO> GetCellQuantityByZones();

        short ZoneNameCreate(ZoneNamesDTO zndto);
        void ZoneNameUpdate(ZoneNamesDTO zndto);
        bool ZoneNameDelete(ZoneNamesDTO zndto);
        List<int> CanSelectedZone(List<int> listWareHouseId, List<int> listStorageGroupId);
        bool ZoneAllDelete(int zoneNameId);

        void Dispose();
    }
}
