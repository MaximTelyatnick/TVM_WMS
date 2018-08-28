using System.Collections.Generic;
using TVM_WMS.BLL.DTO;

namespace TVM_WMS.BLL.Interfaces
{
    public interface ICurrencyService
    {
        IEnumerable<CurrencyDTO> GetCurrency();

        short CurrencyCreate(CurrencyDTO curdto);
        void CurrencyUpdate(CurrencyDTO curdto);
        bool CurrencyDelete(CurrencyDTO curdto);

        void Dispose();
    }
}
