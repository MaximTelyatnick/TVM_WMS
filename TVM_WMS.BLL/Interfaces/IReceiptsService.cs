using System.Collections.Generic;
using TVM_WMS.BLL.DTO;
using TVM_WMS.BLL.DTO.QueryDTO;
using System;
using TVM_WMS.BLL.BusinessLogicModule;

namespace TVM_WMS.BLL.Interfaces
{
    public interface IReceiptsService
    {
        ReceiptsDTO GetReceiptById(int id);
        IEnumerable<ReceiptsDTO> GetReceipts();
        IEnumerable<ReceiptsForAcceptanceDTO> GetReceiptsForAcceptance();
        IEnumerable<ReceiptsForKeepingDTO> GetReceiptsForKeeping();
        IEnumerable<ReceiptsDTO> GetReceiptsByOrderId(int orderId);
        IEnumerable<ReceiptsDTO> GetReceiptsForJournal(DateTime beginDate, DateTime endDate);

        void UpdateRange(List<ReceiptsDTO> listReceipts);
        int ReceiptCreate(ReceiptsDTO recdto);
        void ReceiptUpdate(ReceiptsDTO recdto);
        Error.ErrorCRUD ReceiptDelete(ReceiptsDTO recdto);
        bool ReceiptAllDelete(int? order_id);

        void Dispose();
    }
}
