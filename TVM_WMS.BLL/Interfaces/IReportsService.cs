using System.Collections.Generic;
using TVM_WMS.BLL.DTO;

namespace TVM_WMS.BLL.Interfaces
{
    public interface IReportsService
    {
        void PrintWareHouses(List<WareHousesDTO> wareHouseList, StoreNamesDTO storeName);
        void Dispose();
    }
}
