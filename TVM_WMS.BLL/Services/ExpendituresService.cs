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
    public class ExpendituresService : IExpendituresService
    {
        private IUnitOfWork Database { get; set; }
        private IRepository<Expenditures> Expenditures;
        private IRepository<Keepings> Keepings;
        private IRepository<Receipts> Receipts;
        private IRepository<ReceiptAcceptances> ReceiptAcceptances;
        private IRepository<Materials> Materials;
        private IRepository<Units> Units;
        private IRepository<Users> Users;
        private IRepository<WareHouses> WareHouses;
        private IRepository<StoreNames> StoreNames;

        private IMapper mapper;
        private readonly Logger _logger = LogManager.GetCurrentClassLogger();

        public ExpendituresService(IUnitOfWork uow)
        {
            Database = uow;
            Expenditures = Database.GetRepository<Expenditures>();
            Keepings = Database.GetRepository<Keepings>();
            Receipts = Database.GetRepository<Receipts>();
            ReceiptAcceptances = Database.GetRepository<ReceiptAcceptances>();
            Materials = Database.GetRepository<Materials>();
            Units = Database.GetRepository<Units>();
            Users = Database.GetRepository<Users>();
            WareHouses = Database.GetRepository<WareHouses>();
            StoreNames = Database.GetRepository<StoreNames>();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Expenditures, ExpendituresDTO>();
                cfg.CreateMap<ExpendituresDTO, Expenditures>();
            });

            mapper = config.CreateMapper();
        }


        public IEnumerable<ExpendituresDTO> GetExpenditures()
        {
            return mapper.Map<IEnumerable<Expenditures>, List<ExpendituresDTO>>(Expenditures.GetAll());
        }

        public IEnumerable<ExpendituresDTO> GetExpendituresForJournal(DateTime beginDate, DateTime endDate)
        {
            var result = (from e in Expenditures.GetAll()
                          join k in Keepings.GetAll() on e.KeepingId equals k.KeepingId into ek
                          from k in ek.DefaultIfEmpty()
                          join w in WareHouses.GetAll() on k.WareHouseId equals w.WareHouseId into kw
                          from w in kw.DefaultIfEmpty()
                          join sn in StoreNames.GetAll() on w.StoreNameId equals sn.StoreNameId into wsn
                          from sn in wsn.DefaultIfEmpty()
                          join sn_p in StoreNames.GetAll() on sn.ParentId equals sn_p.StoreNameId into snpar
                          from sn_p in snpar.DefaultIfEmpty()
                          join ra in ReceiptAcceptances.GetAll() on e.ReceiptAcceptanceId equals ra.AcceptanceId into rae
                          from ra in rae.DefaultIfEmpty()
                          join r in Receipts.GetAll() on ra.ReceiptId equals r.ReceiptId into rc
                          from r in rc.DefaultIfEmpty()
                          join m in Materials.GetAll() on r.MaterialId equals m.MaterialId into pc
                          from m in pc.DefaultIfEmpty()
                          join u in Units.GetAll() on r.UnitId equals u.UnitId into un
                          from u in un.DefaultIfEmpty()
                          join us in Users.GetAll() on e.UserId equals us.UserId into eus
                          from us in eus.DefaultIfEmpty()
                          where (e.ExpDate >= beginDate && e.ExpDate <= endDate)
                          select new ExpendituresDTO
                          {
                              ExpendituresId = e.ExpendituresId,
                              ExpDate = e.ExpDate,
                              UserId = e.UserId,
                              KeepingId = k.KeepingId,
                              WareHouseId = w.WareHouseId,
                              StoreNameId = sn.StoreNameId,
                              StoreNameParentId = sn_p.StoreNameId,
                              NumberCell = w.NumberCell,
                              ReceiptAcceptanceId = e.ReceiptAcceptanceId,
                              MaterialId = r.MaterialId,
                              UnitId = r.UnitId,
                              Quantity = e.Quantity,
                              Name = m.Name,
                              Article = m.Article,
                              UnitLocalName = u.UnitLocalName,
                              UserName = us.Fio
                          }).ToList();

            return result;
        }

        public int ExpenditureCreate(ExpendituresDTO keeping)
        {
            var createrecord = Expenditures.Create(mapper.Map<Expenditures>(keeping));
            return (int)createrecord.KeepingId;
        }

        public void ExpenditureUpdate(ExpendituresDTO expenditure)
        {

            var eGroup = Expenditures.GetAll().SingleOrDefault(c => c.ExpendituresId == expenditure.ExpendituresId);
            Expenditures.Update((mapper.Map<ExpendituresDTO, Expenditures>(expenditure, eGroup)));
        }

        public void CreateRange(List<ExpendituresDTO> listExpenditures)
        {
            Expenditures.CreateRange(mapper.Map<List<ExpendituresDTO>,IEnumerable<Expenditures>>(listExpenditures));
        }

        public bool ExpenditureDelete(ExpendituresDTO expenditure)
        {
            try
            {
                Expenditures.Delete(Expenditures.GetAll().FirstOrDefault(c => c.ExpendituresId == expenditure.ExpendituresId));
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
