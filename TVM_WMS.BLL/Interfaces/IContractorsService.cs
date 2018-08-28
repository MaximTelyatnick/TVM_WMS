using System.Collections.Generic;
using TVM_WMS.BLL.BusinessLogicModule;
using TVM_WMS.BLL.DTO;

namespace TVM_WMS.BLL.Interfaces
{
    public interface IContractorsService
    {
        IEnumerable<ContractorsDTO> GetContractors();

        int ContractorCreate(ContractorsDTO cntdto);
        void ContractorUpdate(ContractorsDTO cntdto);
        Error.ErrorCRUD ContractorDelete(ContractorsDTO cntdto);

        void Dispose();
    }
}
