using System.Collections.Generic;
using System.Linq;
using AutoMapper;

using TVM_WMS.DAL.Entities;
using TVM_WMS.DAL.Interfaces;
using TVM_WMS.DAL.Repositories;
using TVM_WMS.DAL.Entities.QueryModel;

using TVM_WMS.BLL.DTO;
using TVM_WMS.BLL.DTO.QueryDTO;
using TVM_WMS.BLL.Interfaces;
using TVM_WMS.BLL.BusinessLogicModule;
using System;
using NLog;

namespace TVM_WMS.BLL.Services
{
    public class RequirementsService : IRequirementsService
    {
        private IUnitOfWork Database { get; set; }
        private IRepository<RequirementOrders> RequirementOrders;
        private IRepository<RequirementMaterials> RequirementMaterials;
        private IRepository<Materials> Materials;
        private IRepository<Units> Units;
        private IRepository<Persons> Persons;
        private IRepository<KeepingMaterials> KeepingMaterials;
        private IMapper mapper;

        private readonly Logger _logger = LogManager.GetCurrentClassLogger();

        public RequirementsService(IUnitOfWork uow)
        {
            Database = uow;
            RequirementOrders = Database.GetRepository<RequirementOrders>();
            RequirementMaterials = Database.GetRepository<RequirementMaterials>();

            Materials = Database.GetRepository<Materials>();
            Units = Database.GetRepository<Units>();
            Persons = Database.GetRepository<Persons>();
            KeepingMaterials = Database.GetRepository<KeepingMaterials>();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<RequirementOrders, RequirementOrdersDTO>();
                cfg.CreateMap<RequirementOrdersDTO, RequirementOrders>();
                cfg.CreateMap<RequirementMaterials, RequirementMaterialsDTO>();
                cfg.CreateMap<RequirementMaterialsDTO, RequirementMaterials>();
                cfg.CreateMap<Persons, PersonsDTO>();
                cfg.CreateMap<KeepingMaterials, KeepingMaterialsDTO>();
            });

            mapper = config.CreateMapper();
        }

        public IEnumerable<RequirementOrdersDTO> GetRequirementOrders(DateTime beginDate, DateTime endDate)
        {
            var result = (from r in mapper.Map<IEnumerable<RequirementOrders>, IEnumerable<RequirementOrdersDTO>>(RequirementOrders.GetAll())
                          join m in mapper.Map<IEnumerable<Persons>, IEnumerable<PersonsDTO>>(Persons.GetAll()) on r.ResponsiblePersonId equals m.PersonId into pc
                          from m in pc.DefaultIfEmpty(new PersonsDTO())
                          where (r.RequirementDate >= beginDate && r.RequirementDate <= endDate)
                          select new RequirementOrdersDTO
                          {
                              RequirementOrderId = r.RequirementOrderId,
                              ResponsiblePersonId = r.ResponsiblePersonId,
                              RequirementNumber = r.RequirementNumber,
                              RequirementDate = r.RequirementDate,
                              PersonName = m.PersonName
                          })
                         .ToList();

            return result;

        }

        public IEnumerable<RequirementMaterialsDTO> GetRequirementMaterials()
        {
            var result = (from r in RequirementMaterials.GetAll()
                          join m in Materials.GetAll() on r.MaterialId equals m.MaterialId into pc
                          from m in pc.DefaultIfEmpty()
                          join u in Units.GetAll() on r.UnitId equals u.UnitId into un
                          from u in un.DefaultIfEmpty()

                          select new RequirementMaterialsDTO
                          {
                              RequirementMaterialId = r.RequirementMaterialId,
                              RequirementOrderId = r.RequirementOrderId,
                              MaterialId = r.MaterialId,
                              RequiredQuantity = r.RequiredQuantity,
                              Name = m.Name,
                              Article = m.Article,
                              UnitLocalName = u.UnitLocalName,
                              UnitId = r.UnitId
                          })
                          .ToList();

            return result.ToList();
         }

        public IEnumerable<KeepingMaterialsDTO> GetAllKeepingMaterials()
        {
            string procName = @"select * from ""GetAllKeepingMaterials""";
           
            return mapper.Map<IEnumerable<KeepingMaterials>, List<KeepingMaterialsDTO>>(KeepingMaterials.SQLExecuteProc(procName));
        }

        public int RequirementOrderCreate(RequirementOrdersDTO rodto)
        {
            var createRecord = RequirementOrders.Create(mapper.Map<RequirementOrders>(rodto));
            return (int)createRecord.RequirementOrderId;
        }

        public void RequirementOrderUpdate(RequirementOrdersDTO rodto)
        {

            var model = RequirementOrders.GetAll().SingleOrDefault(c => c.RequirementOrderId == rodto.RequirementOrderId);

            RequirementOrders.Update((mapper.Map<RequirementOrdersDTO, RequirementOrders>(rodto, model)));
        }

        public bool RequirementOrderDelete(RequirementOrdersDTO rodto)
        {
            try
            {
                RequirementOrders.Delete(RequirementOrders.GetAll().FirstOrDefault(c => c.RequirementOrderId == rodto.RequirementOrderId));
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public int RequirementMaterialCreate(RequirementMaterialsDTO rmdto)
        {
            var createRecord = RequirementMaterials.Create(mapper.Map<RequirementMaterials>(rmdto));
            return (int)createRecord.RequirementMaterialId;
        }

        public void RequirementMaterialUpdate(RequirementMaterialsDTO rmdto)
        {

            var model = RequirementMaterials.GetAll().SingleOrDefault(c => c.RequirementMaterialId == rmdto.RequirementMaterialId);

            RequirementMaterials.Update((mapper.Map<RequirementMaterialsDTO, RequirementMaterials>(rmdto, model)));
        }

        public bool RequirementMaterialDelete(RequirementMaterialsDTO rmdto)
        {
            try
            {
                RequirementMaterials.Delete(RequirementMaterials.GetAll().FirstOrDefault(c => c.RequirementMaterialId == rmdto.RequirementMaterialId));
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool RequirementMaterialAllDelete(int requirementOrder_id)
        {
            try
            {
                var delRequirementMaterials = RequirementMaterials.GetAll().Where(c => c.RequirementOrderId == requirementOrder_id);
                RequirementMaterials.DeleteAll(delRequirementMaterials);
                return true;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                return false;
            }

        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
