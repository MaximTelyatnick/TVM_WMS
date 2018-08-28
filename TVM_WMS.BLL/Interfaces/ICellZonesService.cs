using System.Collections.Generic;
using TVM_WMS.BLL.DTO;

namespace TVM_WMS.BLL.Interfaces
{
    public interface ICellZonesService
    {
        IEnumerable<CellZonesDTO> GetCellZones();
        List<int> GetStoreNamesByZoneId(int zoneId);
        
        bool RenewalCellZones(List<WareHousesDTO> listCells);
        bool FindReserveZoneByStoreName(int storeNameId);
        
        int CellZoneCreate(CellZonesDTO czdto);
        void CellZoneUpdate(CellZonesDTO czdto);
        bool CellZoneDelete(CellZonesDTO czdto);

        void CreateRange(List<CellZonesDTO> czdto);

        void Dispose();
    }
}
