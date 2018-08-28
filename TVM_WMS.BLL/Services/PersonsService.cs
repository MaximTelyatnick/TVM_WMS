using System.Collections.Generic;
using System.Linq;
using AutoMapper;

using TVM_WMS.DAL.Entities;
using TVM_WMS.DAL.Interfaces;
using TVM_WMS.DAL.Repositories;

using TVM_WMS.BLL.DTO;
using TVM_WMS.BLL.Interfaces;
using TVM_WMS.BLL.BusinessLogicModule;
using System;
using NLog;


namespace TVM_WMS.BLL.Services
{
    public class PersonsService : IPersonsService
    {
        private IUnitOfWork Database { get; set; }
        private IRepository<Persons> Persons;
        private IRepository<Professions> Professions;
        private IMapper mapper;
        public PersonsService(IUnitOfWork uow)
        {
            Database = uow;
            Persons = Database.GetRepository<Persons>();
            Professions = Database.GetRepository<Professions>();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Persons, PersonsDTO>();
                cfg.CreateMap<PersonsDTO, Persons>();
                cfg.CreateMap<Professions, ProfessionsDTO>();
            });

            mapper = config.CreateMapper();
        }

        public IEnumerable<PersonsDTO> GetPersons()
        {
            var result = (from p in Persons.GetAll()
                          join pr in Professions.GetAll() on p.ProfessionId equals pr.Id into pc
                          from pr in pc.DefaultIfEmpty()
                          select new PersonsDTO
                          {
                          PersonId = p.PersonId,
                          PersonName = p.PersonName,
                          ProfessionId = pr.Id,
                          ProfessionName = pr.ProfessionName
                          });

            return result.ToList();
        }

        public int PersonCreate(PersonsDTO pdto)
        {
            var createrecord = Persons.Create(mapper.Map<Persons>(pdto));
            return (int)createrecord.PersonId;
        }

        public void PersonUpdate(PersonsDTO pdto)
        {

            var model = Persons.GetAll().SingleOrDefault(c => c.PersonId == pdto.PersonId);

            Persons.Update((mapper.Map<PersonsDTO, Persons>(pdto, model)));
        }

        public bool PersonDelete(PersonsDTO pdto)
        {
            try
            {
                Persons.Delete(Persons.GetAll().FirstOrDefault(c => c.PersonId == pdto.PersonId));
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
