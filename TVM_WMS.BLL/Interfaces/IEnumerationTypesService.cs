using System.Collections.Generic;
using TVM_WMS.BLL.DTO;

namespace TVM_WMS.BLL.Interfaces
{
   public interface IEnumerationTypesService
    {
        IEnumerable<EnumerationTypesDTO> GetEnumerationTypes();
        void Dispose();
    }
}
