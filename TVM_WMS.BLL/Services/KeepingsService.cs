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

namespace TVM_WMS.BLL.Services
{
    public class KeepingsService : IKeepingsService
    {
        private IUnitOfWork Database { get; set; }
        private IRepository<Keepings> keepings;
        private IRepository<KeepingMaterials> keepingMaterials;
        private IRepository<Expenditures> expenditures;
        private IRepository<ReceiptAcceptances> receiptAcceptances;
        private IRepository<Receipts> receipts;
        private IRepository<Orders> orders;
        private IRepository<HistoryKeepings> historyKeepings;
        private IRepository<Users> users;
        private IRepository<WareHouses> wareHouses;
        private IRepository<StoreNames> storeNames;
        private IRepository<Units> units;
        private IRepository<Materials> materials;

        private IMapper mapper;
        private readonly Logger _logger = LogManager.GetCurrentClassLogger();

        public KeepingsService(IUnitOfWork uow)
        {
            Database = uow;
            keepings = Database.GetRepository<Keepings>();
            keepingMaterials = Database.GetRepository<KeepingMaterials>();
            expenditures = Database.GetRepository<Expenditures>();
            receiptAcceptances = Database.GetRepository<ReceiptAcceptances>();
            receipts = Database.GetRepository<Receipts>();
            orders = Database.GetRepository<Orders>();
            historyKeepings = Database.GetRepository<HistoryKeepings>();
            users = Database.GetRepository<Users>();
            wareHouses = Database.GetRepository<WareHouses>();
            storeNames = Database.GetRepository<StoreNames>();
            units = Database.GetRepository<Units>();
            materials = Database.GetRepository<Materials>();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Keepings, KeepingsDTO>();
                cfg.CreateMap<KeepingsDTO, Keepings>();
                cfg.CreateMap<KeepingMaterials, KeepingMaterialsDTO>();
                cfg.CreateMap<ExpendituresDTO, Expenditures>();
                cfg.CreateMap<HistoryKeepings, HistoryKeepingsDTO>();
                cfg.CreateMap<HistoryKeepingsDTO, HistoryKeepings>();
            });

            mapper = config.CreateMapper();
        }

        public IEnumerable<KeepingMaterialsDTO> GetExpendituresFromKeeping()
        {
            string procName = @"select * from ""GetExpendituresFromKeeping""";
            return mapper.Map<IEnumerable<KeepingMaterials>, List<KeepingMaterialsDTO>>(keepingMaterials.SQLExecuteProc(procName));
        }

        public IEnumerable<KeepingsDTO> GetKeepings()
        {
            return mapper.Map<IEnumerable<Keepings>, List<KeepingsDTO>>(keepings.GetAll());
        }

        public IEnumerable<HistoryKeepingsDTO> GetHistoryKeepings(DateTime beginDate, DateTime endDate)
        {
            var result = (from hk in historyKeepings.GetAll()
                          join k in keepings.GetAll() on hk.KeepingId equals k.KeepingId into hkk
                          from k in hkk.DefaultIfEmpty()
                          join ra in receiptAcceptances.GetAll() on k.ReceiptAcceptanceId equals ra.AcceptanceId into hkra
                          from ra in hkra.DefaultIfEmpty()
                          join r in receipts.GetAll() on ra.ReceiptId equals r.ReceiptId into rar
                          from r in rar.DefaultIfEmpty()
                          join m in materials.GetAll() on r.MaterialId equals m.MaterialId into rm
                          from m in rm.DefaultIfEmpty()
                          join un in units.GetAll() on r.UnitId equals un.UnitId into run
                          from un in run.DefaultIfEmpty()
                          join o in orders.GetAll() on ra.OrderId equals o.OrderId into rao
                          from o in rao.DefaultIfEmpty()
                          join u in users.GetAll() on hk.UserId equals u.UserId into hku
                          from u in hku.DefaultIfEmpty()
                          join w in wareHouses.GetAll() on k.WareHouseId equals w.WareHouseId into hkw
                          from w in hkw.DefaultIfEmpty()
                          join sn in storeNames.GetAll() on w.StoreNameId equals sn.StoreNameId into wsn
                          from sn in wsn.DefaultIfEmpty()
                          join sn_p in storeNames.GetAll() on sn.ParentId equals sn_p.StoreNameId into snpar
                          from sn_p in snpar.DefaultIfEmpty()
                          where (hk.DateAdded >= beginDate && hk.DateAdded <= endDate)
                          select new HistoryKeepingsDTO()
                          {
                              Id = hk.Id,
                              KeepingId = hk.KeepingId,
                              DateAdded = hk.DateAdded,
                              NumberCell = w.NumberCell,
                              Quantity = hk.Quantity,
                              ReceiptAcceptanceId = k.ReceiptAcceptanceId,
                              UserId = hk.UserId,
                              UserName = u.Fio,
                              WareHouseId = w.WareHouseId,
                              StoreNameId = sn.StoreNameId,
                              StoreNameParentId = sn_p.StoreNameId,
                              OrderDate = o.OrderDate,
                              OrderNumber = o.OrderNumber,
                              Article = m.Article,
                              Name = m.Name,
                              UnitLocalName = un.UnitLocalName
                          }


                ).ToList();

            return result;
        }

        public decimal GetQuantitySumByReceiptId(int receiptId)
        {
            var result = (from k in keepings.GetAll()
                          join ra in receiptAcceptances.GetAll() on k.ReceiptAcceptanceId equals ra.AcceptanceId
                          join r in receipts.GetAll() on ra.ReceiptId equals r.ReceiptId
                          where r.ReceiptId == receiptId
                          select new KeepingsDTO
                          {
                              KeepingId = k.KeepingId,
                              Quantity = k.Quantity
                          }
                              ).Sum(x => x.Quantity);

            return (result != null) ? result : 0;
        }

        public int KeepingCreate(KeepingsDTO keeping)
        {
            var createrecord = keepings.Create(mapper.Map<Keepings>(keeping));
            return (int)createrecord.KeepingId;
        }

        public void KeepingUpdate(KeepingsDTO keeping)
        {

            var eGroup = keepings.GetAll().SingleOrDefault(c => c.KeepingId == keeping.KeepingId);
            keepings.Update((mapper.Map<KeepingsDTO, Keepings>(keeping, eGroup)));
        }

        public bool KeepingDelete(KeepingsDTO keeping)
        {
            try
            {                              
                    keepings.Delete(keepings.GetAll().FirstOrDefault(c => c.KeepingId == keeping.KeepingId));
                    return true;
              
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public int HistoryKeepingCreate(HistoryKeepingsDTO hkdto)
        {
            var createrecord = historyKeepings.Create(mapper.Map<HistoryKeepings>(hkdto));
            return (int)createrecord.Id;
        }

        public void HistoryKeepingCreateRange(List<HistoryKeepingsDTO> source)
        {
            historyKeepings.CreateRange(mapper.Map<List<HistoryKeepingsDTO>, IEnumerable<HistoryKeepings>>(source));
        }

        public bool HistoryKeepingDelete(HistoryKeepingsDTO hkdto)
        {
            try
            {
                historyKeepings.Delete(historyKeepings.GetAll().FirstOrDefault(c => c.Id == hkdto.Id));
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