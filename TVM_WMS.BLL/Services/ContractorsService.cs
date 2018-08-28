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
    public class ContractorsService : IContractorsService
    {
        private IUnitOfWork Database { get; set; }
        private IRepository<Contractors> Contractors;
        private IRepository<Orders> Orders;
        private IMapper mapper;
        private readonly Logger _logger = LogManager.GetCurrentClassLogger();

        public ContractorsService(IUnitOfWork uow)
        {
            Database = uow;
            Contractors = Database.GetRepository<Contractors>();
            Orders = Database.GetRepository<Orders>();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Contractors, ContractorsDTO>();
                cfg.CreateMap<ContractorsDTO, Contractors>();
                cfg.CreateMap<Orders, OrdersDTO>();
            });

            mapper = config.CreateMapper();
        }

        public IEnumerable<ContractorsDTO> GetContractors()
        {
            return mapper.Map<IEnumerable<Contractors>, List<ContractorsDTO>>(Contractors.GetAll());
        }

        public int ContractorCreate(ContractorsDTO contractor)
        {
            var createrecord = Contractors.Create(mapper.Map<Contractors>(contractor));
            return (int)createrecord.ContractorId;
        }

        public void ContractorUpdate(ContractorsDTO contractor)
        {

            var eGroup = Contractors.GetAll().SingleOrDefault(c => c.ContractorId == contractor.ContractorId);

            Contractors.Update((mapper.Map<ContractorsDTO, Contractors>(contractor, eGroup)));
        }

        public Error.ErrorCRUD ContractorDelete(ContractorsDTO contractor)
        {
            try
            {
                Error.ErrorCRUD result = CanDelete(contractor.ContractorId);
                if (result == Error.ErrorCRUD.CanDelete)
                {
                    Contractors.Delete(Contractors.GetAll().FirstOrDefault(c => c.ContractorId == contractor.ContractorId));
                    return Error.ErrorCRUD.NoError;
                }
                else
                {
                    return Error.ErrorCRUD.RelationError;
                }
            }
            catch (Exception ex)
            {
                return Error.ErrorCRUD.DatabaseError;
            }
            
        }

        private Error.ErrorCRUD CanDelete(int contractorId)
        {
            return (Orders.GetAll().Any(s => s.ContractorId == contractorId)) ? Error.ErrorCRUD.RelationError : Error.ErrorCRUD.CanDelete;
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}