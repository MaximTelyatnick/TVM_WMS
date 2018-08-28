using System.Collections.Generic;
using TVM_WMS.BLL.DTO;
using TVM_WMS.BLL.DTO.QueryDTO;

namespace TVM_WMS.BLL.Interfaces
{
    public interface IWareHousesService
    {
        IEnumerable<WareHousesDTO> GetWareHouses();
        IEnumerable<CellPresenceDTO> GetCellPresence(int warehouseId);
        IEnumerable<WareHousePresencesDTO> GetWareHousePresences();
        
        void SetEnumerationCells(IEnumerable<WareHousesDTO> wareHouse);
        
        WareHousesDTO GetCellInfo(int warehouseId);
        WareHousesDTO GetWareHouseById(int id);
        
        bool WareHousesRangeCreate(IEnumerable<WareHousesDTO> whdto);
        void WareHousesUpdate(WareHousesDTO wareHouse);
        bool WareHousesRangeDelete(IEnumerable<WareHousesDTO> whdto);

        void Dispose();
    }
}
