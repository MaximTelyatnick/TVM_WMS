using System.Collections.Generic;
using TVM_WMS.BLL.DTO;

namespace TVM_WMS.BLL.Interfaces
{
    public interface IProfessionService
    {
        IEnumerable<ProfessionsDTO> GetProfession();

        int ProfessionCreate(ProfessionsDTO pdto);
        void ProfessionUpdate(ProfessionsDTO pdto);
        bool ProfessionDelete(ProfessionsDTO pdto);

        void Dispose();
    }
}

