using System.Collections.Generic;
using System.Linq;
using AutoMapper;

using TVM_WMS.DAL.Entities;
using TVM_WMS.DAL.Entities.QueryModel;
using TVM_WMS.DAL.Interfaces;
using TVM_WMS.DAL.Repositories;

using TVM_WMS.BLL.DTO;
using TVM_WMS.BLL.Interfaces;
using TVM_WMS.BLL.BusinessLogicModule;
using System;
using NLog;
using System.Globalization;

namespace TVM_WMS.BLL.Services
{
    public class ReceiptAcceptancesService : IReceiptAcceptancesService
    {
        private IUnitOfWork Database { get; set; }
        private IRepository<Receipts> Receipts;
        private IRepository<Materials> Materials;
        private IRepository<Orders> Orders;
        private IRepository<Statuses> Statuses;
        private IRepository<Units> Units;
        private IRepository<Contractors> Contractors;
        private IRepository<Keepings> Keepings;
        private IRepository<ReceiptAcceptances> ReceiptAcceptances;
        private IMapper mapper;
        private readonly Logger _logger = LogManager.GetCurrentClassLogger();

        public ReceiptAcceptancesService(IUnitOfWork uow)
        {
            Database = uow;
            Receipts = Database.GetRepository<Receipts>();
            Materials = Database.GetRepository<Materials>();
            Orders = Database.GetRepository<Orders>();
            Statuses = Database.GetRepository<Statuses>();
            Contractors = Database.GetRepository<Contractors>();
            Units = Database.GetRepository<Units>(); 
            ReceiptAcceptances = Database.GetRepository<ReceiptAcceptances>();
            Keepings = Database.GetRepository<Keepings>();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ReceiptAcceptancesDTO, ReceiptAcceptances>();
                cfg.CreateMap<ReceiptAcceptances, ReceiptAcceptancesDTO>();
            });

            mapper = config.CreateMapper();
        }

        public ReceiptAcceptancesDTO GetReceiptAcceptanceById(int id)
        {
            var entities = ReceiptAcceptances.GetAll().FirstOrDefault(s => s.AcceptanceId == id);
            return mapper.Map<ReceiptAcceptances, ReceiptAcceptancesDTO>(entities);        
        }

        public IEnumerable<ReceiptAcceptancesDTO> GetReceiptAcceptanceByOrderId(int orderId)
        {
            return mapper.Map<IEnumerable<ReceiptAcceptances>, List<ReceiptAcceptancesDTO>>(ReceiptAcceptances.GetAll().Where(s => s.OrderId == orderId));      
        }

        public IEnumerable<ReceiptAcceptancesDTO> GetReceiptAcceptanceByReceiptId(int receiptId)
        {
            var result = (from ra in ReceiptAcceptances.GetAll()
                          join r in Receipts.GetAll() on ra.ReceiptId equals r.ReceiptId into rc
                          from r in rc.DefaultIfEmpty()
                          join o in Orders.GetAll() on r.OrderId equals o.OrderId into ro
                          from o in ro.DefaultIfEmpty()
                          join c in Contractors.GetAll() on o.ContractorId equals c.ContractorId into oc
                          from c in oc.DefaultIfEmpty()
                          join m in Materials.GetAll() on r.MaterialId equals m.MaterialId into pm
                          from m in pm.DefaultIfEmpty()
                          join s in Statuses.GetAll() on ra.StatusId equals s.StatusId into ps
                          from s in ps.DefaultIfEmpty()
                          join u in Units.GetAll() on r.UnitId equals u.UnitId into pu
                          from u in pu.DefaultIfEmpty()
                          where ra.ReceiptId == receiptId
                          select new ReceiptAcceptancesDTO
                          {
                              AcceptanceId = ra.AcceptanceId,
                              ReceiptId = ra.ReceiptId,
                              OrderId = ra.OrderId,
                              OrderDate = o.OrderDate,
                              OrderNumber = o.OrderNumber,
                              ContractorName = c.Name,
                              MaterialId = r.MaterialId,
                              Quantity = ra.Quantity,
                              Name = m.Name,
                              Article = m.Article,
                              StatusId = ra.StatusId,
                              StatusName = s.StatusName,
                              UnitLocalName = u.UnitLocalName,
                              PartNumber = ra.PartNumber,
                              DateExpiration = r.DateExpiration,
                              DateProduction = r.DateProduction
                          });


            return result;
        }
        
        public void CreateRange(List<ReceiptAcceptancesDTO> receiptAcceptances)
        {
            ReceiptAcceptances.CreateRange(mapper.Map<List<ReceiptAcceptancesDTO>,IEnumerable<ReceiptAcceptances>>(receiptAcceptances));
        }

        public void UpdateRange(List<ReceiptAcceptancesDTO> receiptAcceptances)
        {
            for (int i = 0; i <= receiptAcceptances.Count - 1; i++)
            {
                ReceiptAcceptances.Update(mapper.Map<ReceiptAcceptances>(receiptAcceptances[i]));
            }
        }
        public void ReceiptAcceptanceUpdate(ReceiptAcceptancesDTO radto)
        {
            var entity = ReceiptAcceptances.GetAll().SingleOrDefault(c => c.AcceptanceId == radto.AcceptanceId);
            ReceiptAcceptances.Update((mapper.Map<ReceiptAcceptancesDTO, ReceiptAcceptances>(radto, entity)));
        }

        public Error.ErrorCRUD DeleteAll(int receipt_id)
        {
            try
            {
                List<ReceiptAcceptances> delReceiptAcceptances = ReceiptAcceptances.GetAll().Where(c => c.ReceiptId == receipt_id).ToList();
                Error.ErrorCRUD result = CanDelete(delReceiptAcceptances);
                 if (result == Error.ErrorCRUD.CanDelete)
                 {
                     ReceiptAcceptances.DeleteAll(delReceiptAcceptances);
                     return Error.ErrorCRUD.NoError;
                 }
                 else
                 {
                     return result;
                 }
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                return Error.ErrorCRUD.DatabaseError;
            }

        }

        private Error.ErrorCRUD CanDelete(List<ReceiptAcceptances> delReceiptAcceptances)
        {
            var result = (from ra in delReceiptAcceptances
                          join r in Keepings.GetAll() on ra.AcceptanceId equals r.ReceiptAcceptanceId 

                          select new KeepingsDTO
                          {
                              ReceiptAcceptanceId = r.ReceiptAcceptanceId
                          }).ToList();

            return (result.Count != 0) ? Error.ErrorCRUD.RelationError : Error.ErrorCRUD.CanDelete;
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
