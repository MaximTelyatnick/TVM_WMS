using System.Collections.Generic;
using TVM_WMS.BLL.BusinessLogicModule;
using TVM_WMS.BLL.DTO;

namespace TVM_WMS.BLL.Interfaces
{
    public interface IUnitsService
    {
        IEnumerable<UnitsDTO> GetUnits();

        short UnitCreate(UnitsDTO undto);
        void UnitUpdate(UnitsDTO undto);
        Error.ErrorCRUD UnitDelete(UnitsDTO unit);

        void Dispose();
    }
}
