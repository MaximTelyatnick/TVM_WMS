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
using FirebirdSql.Data.FirebirdClient;
using TVM_WMS.DAL.Entities.QueryModel;
using TVM_WMS.BLL.DTO.QueryDTO;

namespace TVM_WMS.BLL.Services
{
    public class ZoneNamesService : IZoneNamesService
    {
        private IUnitOfWork Database { get; set; }
        private IRepository<ZoneNames> ZoneNames;
        private IRepository<ZoneNamesByStore> ZoneNamesByStore;
        private IRepository<ZoneTypes> ZoneTypes;
        private IRepository<CellZones> CellZones;
        private IRepository<StorageGroupZones> StorageGroupZones;
        private IRepository<CellQuantityByZones> CellQuantityByZones;
        private IMapper mapper;
        private readonly Logger _logger = LogManager.GetCurrentClassLogger();

        public ZoneNamesService(IUnitOfWork uow)
        {
            Database = uow;
            ZoneNamesByStore = Database.GetRepository<ZoneNamesByStore>();
            ZoneNames = Database.GetRepository<ZoneNames>();
            ZoneTypes = Database.GetRepository<ZoneTypes>();
            CellZones = Database.GetRepository<CellZones>();
            CellQuantityByZones = Database.GetRepository<CellQuantityByZones>();
            StorageGroupZones = Database.GetRepository<StorageGroupZones>();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ZoneNames, ZoneNamesDTO>();
                cfg.CreateMap<ZoneNamesDTO, ZoneNames>();
                cfg.CreateMap<ZoneTypes, ZoneTypesDTO>();
                cfg.CreateMap<ZoneNamesByStore, ZoneNamesByStoreDTO>();
                cfg.CreateMap<CellQuantityByZones, CellQuantityByZonesDTO>();
            });

            mapper = config.CreateMapper();
        }

        public IEnumerable<ZoneNamesDTO> GetZoneNames(int storeNameIdParam)
        {

            FbParameter[] Parameters =
                {
                    new FbParameter("StoreNameIdParam", storeNameIdParam)
                 };

            string procName = @"select * from ""GetZoneNames""(@StoreNameIdParam)";

            return mapper.Map<IEnumerable<ZoneNames>, List<ZoneNamesDTO>>(ZoneNames.SQLExecuteProc(procName, Parameters));

        }

        public IEnumerable<ZoneNamesByStoreDTO> GetZoneNameByStore()
        {

            string procName = @"select * from ""GetZoneNameByStore""";

            return mapper.Map<IEnumerable<ZoneNamesByStore>, List<ZoneNamesByStoreDTO>>(ZoneNamesByStore.SQLExecuteProc(procName));

        }


        public IEnumerable<CellQuantityByZonesDTO> GetCellQuantityByZones()
        {

            string procName = @"select * from ""GetCellQuantityByZones""";

            return mapper.Map<IEnumerable<CellQuantityByZones>, List<CellQuantityByZonesDTO>>(CellQuantityByZones.SQLExecuteProc(procName));

        }
        
        public IEnumerable<ZoneNamesDTO> GetZonesUnspecified()
        {

            var result = (from zn in ZoneNames.GetAll()
                          join zt in ZoneTypes.GetAll() on zn.ZoneTypeId equals zt.ZoneTypeId into z
                          from zt in z.DefaultIfEmpty()
                          join cz in CellZones.GetAll() on zn.ZoneNameId equals cz.ZoneNameId into c
                          from cz in c.DefaultIfEmpty()
                          where cz.ZoneNameId == null
                          select new ZoneNamesDTO
                          {
                              ZoneNameId = zn.ZoneNameId,
                              ZoneName = zn.ZoneName,
                              ZoneColor = zn.ZoneColor,
                              ZoneTypeId = zn.ZoneTypeId,
                              ZoneTypeName = zt.ZoneTypeName
                          });

            return result.ToList();

        }

        public IEnumerable<ZoneTypesDTO> GetZoneTypes()
        {
            return mapper.Map<IEnumerable<ZoneTypes>, List<ZoneTypesDTO>>(ZoneTypes.GetAll());
        }

        public IEnumerable<ZoneNamesDTO> GetZones()
        {
            var zonesWithCells = (from cl in CellZones.GetAll()
                                  group cl by cl.ZoneNameId into g

                                 select new 
                                 {
                                     ZoneNameId = g.Key,
                                 });

            var result = (from zn in ZoneNames.GetAll()
                          join zt in ZoneTypes.GetAll() on zn.ZoneTypeId equals zt.ZoneTypeId into z
                          from zt in z.DefaultIfEmpty()
                          join cz in zonesWithCells on zn.ZoneNameId equals cz.ZoneNameId into c
                          from cz in c.DefaultIfEmpty()
                          select new ZoneNamesDTO
                          {
                              ZoneNameId = zn.ZoneNameId,
                              ZoneName = zn.ZoneName,
                              ZoneColor = zn.ZoneColor,
                              ZoneTypeId = zn.ZoneTypeId,
                              ZoneTypeName = zt.ZoneTypeName
                          });

            return result.ToList();
        }

        public short ZoneNameCreate(ZoneNamesDTO zoneName)
        {
            var createrecord = ZoneNames.Create(mapper.Map<ZoneNames>(zoneName));
            return (short)createrecord.ZoneNameId;
        }

        public void ZoneNameUpdate(ZoneNamesDTO zoneName)
        {

            var eGroup = ZoneNames.GetAll().SingleOrDefault(c => c.ZoneNameId == zoneName.ZoneNameId);

            ZoneNames.Update((mapper.Map<ZoneNamesDTO, ZoneNames>(zoneName, eGroup)));
        }

        public bool ZoneNameDelete(ZoneNamesDTO zoneName)
        {
            try
            {
                ZoneNames.Delete(ZoneNames.GetAll().FirstOrDefault(c => c.ZoneNameId == zoneName.ZoneNameId));
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        /// <summary>
        /// проерить 1. Проходит ли наменклатура по габаритам  
        /// </summary>
        /// <param name="listWareHouseId"></param>
        /// <param name="listStorageGroupId"></param>
        /// <returns></returns>
        public List<int> CanSelectedZone(List<int> listWareHouseId, List<int> listStorageGroupId)
        { 
             List<int> listId = new  List<int>();
             return listId;
        }

        public bool ZoneAllDelete(int zoneNameId)
        {
            try
            {
                var delCellZones = CellZones.GetAll().Where(c => c.ZoneNameId == zoneNameId);
                CellZones.DeleteAll(delCellZones);

                var delStorageGroupZones = StorageGroupZones.GetAll().Where(c => c.ZoneNameId == zoneNameId);
                StorageGroupZones.DeleteAll(delStorageGroupZones);

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
