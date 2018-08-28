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
using FirebirdSql.Data.FirebirdClient;

namespace TVM_WMS.BLL.Services
{
    public class StorageGroupsService : IStorageGroupsService
    {
        private IUnitOfWork Database { get; set; }
        private IRepository<StorageGroups> StorageGroups;
        private IRepository<ZoneNames> ZoneNames;
        private IRepository<StorageGroupZones> StorageGroupZones;
        private IRepository<StorageGroupsByZones> StorageGroupsByZones;
        private IRepository<Materials> Materials;
        private IMapper mapper;
        private readonly Logger _logger = LogManager.GetCurrentClassLogger();

        public StorageGroupsService(IUnitOfWork uow)
        {
            Database = uow;
            StorageGroups = Database.GetRepository<StorageGroups>();
            StorageGroupZones = Database.GetRepository<StorageGroupZones>();
            StorageGroupsByZones = Database.GetRepository<StorageGroupsByZones>();
            ZoneNames = Database.GetRepository<ZoneNames>();
            Materials = Database.GetRepository<Materials>();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<StorageGroups, StorageGroupsDTO>();
                cfg.CreateMap<StorageGroupsDTO, StorageGroups>();
                cfg.CreateMap<StorageGroupsByZones, StorageGroupsByZonesDTO>();
            });

            mapper = config.CreateMapper();
        }

        public IEnumerable<StorageGroupsDTO> GetStorageGroups()
        {
            return mapper.Map<IEnumerable<StorageGroups>, List<StorageGroupsDTO>>(StorageGroups.GetAll());
        }

        public IEnumerable<StorageGroupsByZonesDTO> GetFreeStorageGroups(int storeNameIdParam)
        {
            FbParameter[] Parameters =
                {
                    new FbParameter("StoreNameIdParam", storeNameIdParam)
                 };

            string procName = @"select * from ""GetFreeStorageGroups""(@StoreNameIdParam)";

            return mapper.Map<IEnumerable<StorageGroupsByZones>, List<StorageGroupsByZonesDTO>>(StorageGroupsByZones.SQLExecuteProc(procName, Parameters));

         }

        public IEnumerable<StorageGroupsByZonesDTO> GetStorageGroupsByZone(int zoneNameId)
        {

            string procName = @"select * from ""GetStorageGroupsByZone""";

            var list = mapper.Map<IEnumerable<StorageGroupsByZones>, List<StorageGroupsByZonesDTO>>(StorageGroupsByZones.SQLExecuteProc(procName));

            var returnList = list.Select(c => { c.GroupChecked = false; return c;}).ToList();

            if (zoneNameId != 0) // 0 если выбрать все зоны,ID если для конкретной
            {
               returnList = returnList.Where(c=> c.ZoneNameId == zoneNameId).Select(c => {return c;}).ToList(); 
            }

            return returnList;

        }

        public int StorageGroupsCreate(StorageGroupsDTO storageGroups)
        {
            var createrecord = StorageGroups.Create(mapper.Map<StorageGroups>(storageGroups));
            return (int)createrecord.StorageGroupId;
        }

        public void StorageGroupsUpdate(StorageGroupsDTO storageGroups)
        {

            var eGroup = StorageGroups.GetAll().SingleOrDefault(c => c.StorageGroupId == storageGroups.StorageGroupId);
            StorageGroups.Update((mapper.Map<StorageGroupsDTO, StorageGroups>(storageGroups, eGroup)));
        }

        public Error.ErrorCRUD StorageGroupsDelete(StorageGroupsDTO storageGroups)
        {
            try
            {
                Error.ErrorCRUD result = CanDelete(storageGroups.StorageGroupId);
                if (result == Error.ErrorCRUD.CanDelete)
                {
                    StorageGroups.Delete(StorageGroups.GetAll().FirstOrDefault(c => c.StorageGroupId == storageGroups.StorageGroupId));
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
            
        private Error.ErrorCRUD CanDelete(int storageGroupsId)
        {
            return (Materials.GetAll().Any(s => s.StorageGroupId == storageGroupsId)) ? Error.ErrorCRUD.RelationError : Error.ErrorCRUD.CanDelete;
        }
        public void Dispose()
        {
            Database.Dispose();
        }
    }
    
}
