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
    public class OrdersService : IOrdersService
    {
        private IUnitOfWork Database { get; set; }
        private IRepository<Orders> Orders;
        private IRepository<Receipts> Receipts;
        private IRepository<Contractors> Contractors;
        private IRepository<Statuses> Statuses;
        private IRepository<ReceiptAcceptances> ReceiptAcceptances;
        private IMapper mapper;

        private readonly Logger _logger = LogManager.GetCurrentClassLogger();

        public OrdersService(IUnitOfWork uow)
        {
            Database = uow;
            Orders = Database.GetRepository<Orders>();
            Receipts = Database.GetRepository<Receipts>();
            Contractors = Database.GetRepository<Contractors>();
            Statuses = Database.GetRepository<Statuses>();
            ReceiptAcceptances = Database.GetRepository<ReceiptAcceptances>();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Orders, OrdersDTO>();
                cfg.CreateMap<OrdersDTO, Orders>();
                cfg.CreateMap<ReceiptAcceptances, ReceiptAcceptancesDTO>();
            });

            mapper = config.CreateMapper();
        }

        public IEnumerable<OrdersDTO> GetOrders(DateTime beginDate,DateTime endDate)
        {
            var result = (from o in Orders.GetAll()
                          join c in Contractors.GetAll() on o.ContractorId equals c.ContractorId into pc
                          from c in pc.DefaultIfEmpty()
                          join s in Statuses.GetAll() on o.StatusId equals s.StatusId into ps
                          from s in ps.DefaultIfEmpty()
                          where (o.OrderDate >= beginDate && o.OrderDate <= endDate)
                          select new OrdersDTO
                          {
                              OrderId = o.OrderId,
                              OrderNumber = o.OrderNumber,
                              OrderDate = o.OrderDate,
                              ContractorId = o.ContractorId,
                              ContractorName = c.Name,
                              StatusId = o.StatusId,
                              StatusName = s.StatusName,
                              Checked = "0"
                          });

            return result.ToList();
        }

        public OrdersDTO GetOrderByReceiptId(int id)
        {
            var result = (from or in Orders.GetAll()
                          join r in Receipts.GetAll() on or.OrderId equals r.OrderId into ord
                          from r in ord.DefaultIfEmpty()
                          where r.ReceiptId == id
                          select new OrdersDTO
                          {
                              OrderId = or.OrderId,
                              OrderNumber = or.OrderNumber,
                              OrderDate = or.OrderDate,
                              ContractorId = or.ContractorId,
                              StatusId = or.StatusId
                          }
            );

            return result.SingleOrDefault();
        }

        public OrdersDTO GetOrderById(int id)
        {
            return mapper.Map<Orders,OrdersDTO>(Orders.GetAll().FirstOrDefault(o => o.OrderId == id));
        }

        public IEnumerable<OrdersDTO> GetOrdersAcceptance()
        {
            var result = (from o in Orders.GetAll()
                          join c in Contractors.GetAll() on o.ContractorId equals c.ContractorId into pc
                          from c in pc.DefaultIfEmpty()
                          join s in Statuses.GetAll() on o.StatusId equals s.StatusId into ps
                          from s in ps.DefaultIfEmpty()
                          where o.StatusId == 1 // к поступлению
                          select new OrdersDTO
                          {
                              OrderId = o.OrderId,
                              OrderNumber = o.OrderNumber,
                              OrderDate = o.OrderDate,
                              ContractorId = o.ContractorId,
                              ContractorName = c.Name,
                              StatusId = o.StatusId,
                              StatusName = s.StatusName,
                              Checked = "0"
                          })
                          .ToList();

            return result.ToList();
        }

        public int OrderCreate(OrdersDTO order)
        {
            var createrecord = Orders.Create(mapper.Map<Orders>(order));
            return (int)createrecord.OrderId;
        }

        public void OrderUpdate(OrdersDTO order)
        {

            var eGroup = Orders.GetAll().SingleOrDefault(c => c.OrderId == order.OrderId);
            Orders.Update((mapper.Map<OrdersDTO, Orders>(order, eGroup)));
        }

        public void UpdateRange(List<OrdersDTO> listOrders)
        {
            for (int i = 0; i <= listOrders.Count - 1; i++)
            {
                Orders.Update(mapper.Map<Orders>(listOrders[i]));
            }
        }

        public Error.ErrorCRUD OrderDelete(OrdersDTO order)
        {
            try
            {
                Error.ErrorCRUD result = CanDelete(order.OrderId);
                if (result == Error.ErrorCRUD.CanDelete)

                {
                   Orders.Delete(Orders.GetAll().FirstOrDefault(c => c.OrderId == order.OrderId));
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

        private Error.ErrorCRUD CanDelete(int orderId)
        {
            return (ReceiptAcceptances.GetAll().Any(s => s.OrderId == orderId)) ? Error.ErrorCRUD.RelationError : Error.ErrorCRUD.CanDelete;
        }
        public void Dispose()
        {
            Database.Dispose();
        }
    }
}