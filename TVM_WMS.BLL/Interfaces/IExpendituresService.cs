using System.Collections.Generic;
using TVM_WMS.BLL.DTO;
using TVM_WMS.BLL.DTO.QueryDTO;
using System;


namespace TVM_WMS.BLL.Interfaces
{
    public interface IExpendituresService
    {
        IEnumerable<ExpendituresDTO> GetExpenditures();
        IEnumerable<ExpendituresDTO> GetExpendituresForJournal(DateTime beginDate, DateTime endDate);
                
        int ExpenditureCreate(ExpendituresDTO exdto);
        void ExpenditureUpdate(ExpendituresDTO exdto);
        void CreateRange(List<ExpendituresDTO> listExpenditures);
        bool ExpenditureDelete(ExpendituresDTO exdto);
                
        void Dispose();
    }
}
