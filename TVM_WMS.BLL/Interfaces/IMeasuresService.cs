using System.Collections.Generic;
using TVM_WMS.BLL.DTO;

namespace TVM_WMS.BLL.Interfaces
{
    public interface IMeasuresService
    {
        IEnumerable<MeasuresDTO> GetMeasures();

        int MeasureCreate(MeasuresDTO mdto);
        void MeasureUpdate(MeasuresDTO mdto);
        bool MeasureDelete(MeasuresDTO mdto);

        void Dispose();
    }
}
