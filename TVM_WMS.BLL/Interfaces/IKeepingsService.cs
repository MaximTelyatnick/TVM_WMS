using System;
using System.Collections.Generic;

using TVM_WMS.BLL.BusinessLogicModule;
using TVM_WMS.BLL.DTO;
using TVM_WMS.BLL.DTO.QueryDTO;


namespace TVM_WMS.BLL.Interfaces
{
    public interface IKeepingsService
    {
        IEnumerable<KeepingsDTO> GetKeepings();
        IEnumerable<KeepingMaterialsDTO> GetExpendituresFromKeeping();
        IEnumerable<HistoryKeepingsDTO> GetHistoryKeepings(DateTime beginDate, DateTime endDate);

        decimal GetQuantitySumByReceiptId(int receiptId);

        int KeepingCreate(KeepingsDTO kpdto);
        void KeepingUpdate(KeepingsDTO kpdto);
        bool KeepingDelete(KeepingsDTO kpdto);

        int HistoryKeepingCreate(HistoryKeepingsDTO hkdto);
        void HistoryKeepingCreateRange(List<HistoryKeepingsDTO> source);
        bool HistoryKeepingDelete(HistoryKeepingsDTO hkdto);

        void Dispose();
    }
}
