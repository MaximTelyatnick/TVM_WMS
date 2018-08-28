using System.Collections.Generic;
using System.Linq;
using AutoMapper;

using TVM_WMS.DAL.Entities;
using TVM_WMS.DAL.Entities.QueryModel;
using TVM_WMS.DAL.Interfaces;
using TVM_WMS.DAL.Repositories;

using TVM_WMS.BLL.DTO;
using TVM_WMS.BLL.DTO.QueryDTO;
using TVM_WMS.BLL.Interfaces;
using TVM_WMS.BLL.BusinessLogicModule;
using System;
using NLog;
using System.Globalization;

namespace TVM_WMS.BLL.Services
{
    public class ReceiptsService : IReceiptsService
    {
        private IUnitOfWork Database { get; set; }
        private IRepository<Receipts> Receipts;
        private IRepository<Materials> Materials;
        private IRepository<Units> Units;
        private IRepository<Statuses> Statuses;
        private IRepository<Orders> Orders;
        private IRepository<ReceiptsForKeeping> ReceiptsForKeeping;
        private IRepository<ReceiptAcceptances> ReceiptAcceptances;
        private IRepository<ReceiptsForAcceptance> ReceiptsForAcceptance;

        private IMapper mapper;
        private readonly Logger _logger = LogManager.GetCurrentClassLogger();

        public ReceiptsService(IUnitOfWork uow)
        {
            Database = uow;
            Receipts = Database.GetRepository<Receipts>();
            Materials = Database.GetRepository<Materials>();
            Units = Database.GetRepository<Units>();
            Statuses = Database.GetRepository<Statuses>();
            Orders = Database.GetRepository<Orders>();
            ReceiptsForKeeping = Database.GetRepository<ReceiptsForKeeping>();
            ReceiptAcceptances = Database.GetRepository<ReceiptAcceptances>();
            ReceiptsForAcceptance = Database.GetRepository<ReceiptsForAcceptance>();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ReceiptsForKeeping, ReceiptsForKeepingDTO>();
                cfg.CreateMap<ReceiptsDTO, Receipts>();
                cfg.CreateMap<Receipts, ReceiptsDTO>();
                cfg.CreateMap<ReceiptsForAcceptance, ReceiptsForAcceptanceDTO>();
            });

            mapper = config.CreateMapper();
        }

        public ReceiptsDTO GetReceiptById(int id)
        {
            return mapper.Map<Receipts, ReceiptsDTO>(Receipts.GetAll().FirstOrDefault(s => s.ReceiptId == id));
        }

        public IEnumerable<ReceiptsDTO> GetReceiptsByOrderId(int orderId)
        {
            return mapper.Map<IEnumerable<Receipts>, List<ReceiptsDTO>>(Receipts.GetAll().Where(s => s.OrderId == orderId));      
        }

        public IEnumerable<ReceiptsDTO> GetReceipts()
        {
            var result = (from r in Receipts.GetAll()
                          join m in Materials.GetAll() on r.MaterialId equals m.MaterialId into pc
                          from m in pc.DefaultIfEmpty()
                          join u in Units.GetAll() on r.UnitId equals u.UnitId into un
                          from u in un.DefaultIfEmpty()
                          join s in Statuses.GetAll() on r.StatusId equals s.StatusId into ps
                          from s in ps.DefaultIfEmpty()
                          select new ReceiptsDTO
                          {
                              ReceiptId = r.ReceiptId,
                              OrderId = r.OrderId,
                              MaterialId = r.MaterialId,
                              UnitId = r.UnitId,
                              Quantity = r.Quantity,
                              TotalPrice = r.TotalPrice,
                              UnitPrice = r.UnitPrice,
                              DateProduction = r.DateProduction,
                              DateExpiration = r.DateExpiration,
                              Name = m.Name,
                              Article = m.Article,
                              UnitLocalName = u.UnitLocalName,
                              StatusId = r.StatusId,
                              StatusName = s.StatusName,
                              Checked = "0"
                          });


            return result.ToList();
        }

        public IEnumerable<ReceiptsForAcceptanceDTO> GetReceiptsForAcceptance()
        {
            string procName = @"select * from ""GetReceiptsWithMaterialEntry""";
            return mapper.Map<IEnumerable<ReceiptsForAcceptance>, List<ReceiptsForAcceptanceDTO>>(ReceiptsForAcceptance.SQLExecuteProc(procName));
        }

        public IEnumerable<ReceiptsDTO> GetReceiptsForJournal(DateTime beginDate, DateTime endDate)
        {
            var result = (from r in Receipts.GetAll()
                          join o in Orders.GetAll() on r.OrderId equals o.OrderId into ro
                          from o in ro.DefaultIfEmpty()
                          join m in Materials.GetAll() on r.MaterialId equals m.MaterialId into pc
                          from m in pc.DefaultIfEmpty()
                          join u in Units.GetAll() on r.UnitId equals u.UnitId into un
                          from u in un.DefaultIfEmpty()
                          where r.StatusId == 6 //  принято
                          where (o.OrderDate >= beginDate && o.OrderDate <= endDate)
                          select new ReceiptsDTO
                          {
                              ReceiptId = r.ReceiptId,
                              MaterialId = r.MaterialId,
                              UnitId = r.UnitId,
                              Quantity = r.Quantity,
                              Name = m.Name,
                              Article = m.Article,
                              UnitLocalName = u.UnitLocalName,
                              StatusId = r.StatusId
                          }).ToList();
            return result;
        }

        public IEnumerable<ReceiptsForKeepingDTO> GetReceiptsForKeeping()
        {
            string procName = @"select * from ""GetReceiptsForKeeping""";
            return mapper.Map<IEnumerable<ReceiptsForKeeping>, List<ReceiptsForKeepingDTO>>(ReceiptsForKeeping.SQLExecuteProc(procName));
        }

        public void UpdateRange(List<ReceiptsDTO> listReceipts)
        {
            for (int i = 0; i <= listReceipts.Count - 1; i++)
            {
                Receipts.Update(mapper.Map<Receipts>(listReceipts[i]));
            }
        }

        public int ReceiptCreate(ReceiptsDTO receipt)
        {
            var createrecord = Receipts.Create(mapper.Map<Receipts>(receipt));
            return (int)createrecord.ReceiptId;
        }

        public void ReceiptUpdate(ReceiptsDTO receipt)
        {
            var eGroup = Receipts.GetAll().SingleOrDefault(c => c.ReceiptId == receipt.ReceiptId);
            Receipts.Update((mapper.Map<ReceiptsDTO, Receipts>(receipt, eGroup)));
        }

        public Error.ErrorCRUD ReceiptDelete(ReceiptsDTO receipt)
        {
            try
            {
                Error.ErrorCRUD result = CanDelete(receipt.ReceiptId );
                if (result == Error.ErrorCRUD.CanDelete)
                {
                    Receipts.Delete(Receipts.GetAll().FirstOrDefault(c => c.ReceiptId == receipt.ReceiptId));
                    return Error.ErrorCRUD.NoError;
                }
                else
                {
                    return result;
                }
            }
            catch (Exception ex)
            {
                return Error.ErrorCRUD.DatabaseError;
            }
        }

        private Error.ErrorCRUD CanDelete(int receiptId)
        {
            return (ReceiptAcceptances.GetAll().Any(s => s.ReceiptId == receiptId)) ? Error.ErrorCRUD.RelationError : Error.ErrorCRUD.CanDelete;
        }

        public bool ReceiptAllDelete(int? order_id)
        {
            try
            {
                var delReceipts = Receipts.GetAll().Where(c => c.OrderId == order_id);
                Receipts.DeleteAll(delReceipts);
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