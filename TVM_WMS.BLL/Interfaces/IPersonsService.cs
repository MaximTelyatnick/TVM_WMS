using System.Collections.Generic;
using TVM_WMS.BLL.DTO;

namespace TVM_WMS.BLL.Interfaces
{
    public interface IPersonsService
    {
        IEnumerable<PersonsDTO> GetPersons();

        int PersonCreate(PersonsDTO pdto);
        void PersonUpdate(PersonsDTO pdto);
        bool PersonDelete(PersonsDTO pdto);

        void Dispose();
    }
}
