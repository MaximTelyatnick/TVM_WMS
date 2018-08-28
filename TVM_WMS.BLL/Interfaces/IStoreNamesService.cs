using System.Collections.Generic;
using TVM_WMS.BLL.DTO;
using TVM_WMS.BLL.DTO.QueryDTO;

namespace TVM_WMS.BLL.Interfaces
{
    public interface IStoreNamesService
    {
        IEnumerable<StoreNamesDTO> GetStoreNames();
        IEnumerable<StoreTypesDTO> GetStoreTypes();
        IEnumerable<StoreNamesDTO> GetStoreNameWithFullHeader();
        IEnumerable<StoreNamesDTO> GetStoreNamesWithTypes();
        IEnumerable<StoreLoadDTO> GetStoreLoad();
        List<StoreNamesDTO> GetBindedStoreNames();

        StoreNamesDTO GetStoreNameById(int? id);

        List<StoreNamesDTO> GetRowByStoreNameId(int? id);

        int StoreNameCreate(StoreNamesDTO sndto);
        void StoreNameUpdate(StoreNamesDTO sndto);
        bool StoreNameDelete(StoreNamesDTO sndto);

        void Dispose();
    }
}
