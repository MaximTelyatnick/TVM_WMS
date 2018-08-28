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
    public class UnitsService : IUnitsService
    {
        private IUnitOfWork Database { get; set; }
        private IRepository<Units> Units;
        private IRepository<Receipts> Receipts;
        private IMapper mapper;
        private readonly Logger _logger = LogManager.GetCurrentClassLogger();

        public UnitsService(IUnitOfWork uow)
        {
            Database = uow;
            Units = Database.GetRepository<Units>();
            Receipts = Database.GetRepository<Receipts>();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Units, UnitsDTO>();
                cfg.CreateMap<UnitsDTO, Units>();
                cfg.CreateMap<Receipts, ReceiptsDTO>();
            });

            mapper = config.CreateMapper();
        }

        public IEnumerable<UnitsDTO> GetUnits()
        {
              return mapper.Map<IEnumerable<Units>, List<UnitsDTO>>(Units.GetAll());
        }

        public short UnitCreate(UnitsDTO unit)
        {
            var createrecord = Units.Create(mapper.Map<Units>(unit));
            return (short)createrecord.UnitId;
        }

        public void UnitUpdate(UnitsDTO unit)
        {

            var eGroup = Units.GetAll().SingleOrDefault(c => c.UnitId == unit.UnitId);

            Units.Update((mapper.Map<UnitsDTO, Units>(unit, eGroup)));
        }

        public Error.ErrorCRUD UnitDelete(UnitsDTO unit)
        {
            try
            {
                 Error.ErrorCRUD result = CanDelete(unit.UnitId);
                 if (result == Error.ErrorCRUD.CanDelete)
                 {
                     Units.Delete(Units.GetAll().FirstOrDefault(c => c.UnitId == unit.UnitId));
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

        private Error.ErrorCRUD CanDelete(int unitId)
        {
            return (Receipts.GetAll().Any(s => s.UnitId == unitId)) ? Error.ErrorCRUD.RelationError : Error.ErrorCRUD.CanDelete;
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}