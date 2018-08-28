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
    public class ProfessionService : IProfessionService
    {
        private IUnitOfWork Database { get; set; }
        private IRepository<Professions>  Professions;
        private IMapper mapper;

        public  ProfessionService(IUnitOfWork uow)
        {
            Database = uow;
            Professions = Database.GetRepository<Professions>();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Professions, ProfessionsDTO>();
                cfg.CreateMap<ProfessionsDTO, Professions>();
            });

            mapper = config.CreateMapper();
        }

        public IEnumerable<ProfessionsDTO> GetProfession()
        {
            return mapper.Map<IEnumerable< Professions>, List< ProfessionsDTO>>( Professions.GetAll());
        }

        public int  ProfessionCreate( ProfessionsDTO pdto)
        {
            var createrecord =  Professions.Create(mapper.Map< Professions>(pdto));
            return (int)createrecord.Id;
        }

        public void  ProfessionUpdate( ProfessionsDTO pdto)
        {

            var model =  Professions.GetAll().SingleOrDefault(c => c.Id == pdto.Id);

             Professions.Update((mapper.Map< ProfessionsDTO,  Professions>(pdto, model)));
        }

        public bool  ProfessionDelete( ProfessionsDTO pdto)
        {
            try
            {
                Professions.Delete( Professions.GetAll().FirstOrDefault(c => c.Id == pdto.Id));
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
