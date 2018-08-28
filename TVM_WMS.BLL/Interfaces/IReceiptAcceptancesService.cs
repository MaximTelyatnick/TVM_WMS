using System.Collections.Generic;
using TVM_WMS.BLL.BusinessLogicModule;
using TVM_WMS.BLL.DTO;

namespace TVM_WMS.BLL.Interfaces
{
    public interface IReceiptAcceptancesService
    {
        IEnumerable<ReceiptAcceptancesDTO> GetReceiptAcceptanceByOrderId(int orderId);
        IEnumerable<ReceiptAcceptancesDTO> GetReceiptAcceptanceByReceiptId(int receiptId);
        ReceiptAcceptancesDTO GetReceiptAcceptanceById(int id);

        void ReceiptAcceptanceUpdate(ReceiptAcceptancesDTO radto);
        void CreateRange(List<ReceiptAcceptancesDTO> receiptAcceptances);
        void UpdateRange(List<ReceiptAcceptancesDTO> receiptAcceptances);
        Error.ErrorCRUD DeleteAll(int order_id);

        void Dispose();
    }
}
