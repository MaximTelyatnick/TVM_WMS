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
using System.Windows.Forms;

namespace TVM_WMS.BLL.Services
{
    public class StorageGroupZonesService : IStorageGroupZonesService
    {
        private IUnitOfWork Database { get; set; }
        private IRepository<StorageGroupZones> StorageGroupZones;
        private IRepository<StorageGroupZonePresence> StorageGroupZonePresence;
        private IMapper mapper;
        private readonly Logger _logger = LogManager.GetCurrentClassLogger();

        public StorageGroupZonesService(IUnitOfWork uow)
        {
            Database = uow;
            StorageGroupZones = Database.GetRepository<StorageGroupZones>();
            StorageGroupZonePresence = Database.GetRepository<StorageGroupZonePresence>();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<StorageGroupZones, StorageGroupZonesDTO>();
                cfg.CreateMap<StorageGroupZonesDTO, StorageGroupZones>();
                cfg.CreateMap<StorageGroupZonePresence, StorageGroupZonePresenceDTO>();
            });

            mapper = config.CreateMapper();
        }

        public IEnumerable<StorageGroupZonesDTO> GetStorageGroupZones()
        {
            return mapper.Map<IEnumerable<StorageGroupZones>, List<StorageGroupZonesDTO>>(StorageGroupZones.GetAll());
        }

        public bool RenewalStorageGroupZones(List<StorageGroupsByZonesDTO> storageGroupZones)
        {
            bool result;
            
            var dbSideRusult = mapper.Map<IEnumerable<StorageGroupZones>, List<StorageGroupZonesDTO>>(StorageGroupZones.GetAll());

            var linqSideRusult = storageGroupZones.Select(s => new StorageGroupZonesDTO 
                                                                        {
                                                                            StorageGroupZoneId = s.StorageGroupZoneId ?? 0, 
                                                                            StorageGroupId = s.StorageGroupId, 
                                                                            ZoneNameId = s.ZoneNameId ?? 0 
                                                                        }).ToList();

            var ids = dbSideRusult.Select(s => s.StorageGroupZoneId)
                .Union(linqSideRusult.Select(s => s.StorageGroupZoneId));

            var fullResult = (from i in ids
                              join db in dbSideRusult on i equals db.StorageGroupZoneId into j_db
                              from db in j_db.DefaultIfEmpty()
                              join linq in linqSideRusult on i equals linq.StorageGroupZoneId into j_linq
                              from linq in j_linq.DefaultIfEmpty()
                              select new { db, linq })
                              .ToList();

            string caseStr;
            int storageGroupZoneId = 0;

            try
            {
                for (int i = 0; i < fullResult.Count(); i++)
                {
                    caseStr = (fullResult[i].db == null) ? "add" :
                        (fullResult[i].linq == null) ? "delete" :
                        (!PropertyCompare.Equal<StorageGroupZonesDTO>(fullResult[i].db, fullResult[i].linq)) ? "update" : "";

                    switch (caseStr)
                    {
                        case "add":
                            {
                                StorageGroupZones.Create(mapper.Map<StorageGroupZones>(fullResult[i].linq));
                            }
                            break;
                        case "update":
                            {
                                storageGroupZoneId = fullResult[i].linq.StorageGroupZoneId;
                                var eGroup = StorageGroupZones.GetAll().SingleOrDefault(c => c.StorageGroupZoneId == storageGroupZoneId);

                                StorageGroupZones.Update((mapper.Map<StorageGroupZonesDTO, StorageGroupZones>(fullResult[i].linq, eGroup)));
                            }
                            break;
                        case "delete":
                            {
                                storageGroupZoneId = fullResult[i].db.StorageGroupZoneId;
                                StorageGroupZones.Delete(StorageGroupZones.GetAll().FirstOrDefault(c => c.StorageGroupZoneId == storageGroupZoneId));
                            }
                            break;
                    }
                }

                result = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Действие отменено.\n" + ex.Message, "Сохранение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                result = false;
            }
                        
            return result;
        }

        public IEnumerable<StorageGroupZonePresenceDTO> GetStorageGroupZonePresence(int zoneNameId, int materialId, int algorithm)
        {
            FbParameter[] Parameters =
                {
                    new FbParameter("_ZoneNameId", zoneNameId)
                };

            string procName = @"select * from ""GetStorageGroupZonePresence""(@_ZoneNameId)";

            var query = mapper.Map<IEnumerable<StorageGroupZonePresence>, List<StorageGroupZonePresenceDTO>>(StorageGroupZonePresence.SQLExecuteProc(procName, Parameters));

            List<StorageGroupZonePresenceDTO> cellList = new List<StorageGroupZonePresenceDTO>();

            switch (algorithm)
            {
                case -1:
                    cellList = query;
                    break;
                case 0: //в пустую по умолчанию 0
                    cellList = query.Where(w => w.LoadingStatusId == 1 && w.MaterialId == 0).OrderBy(o => o.WareHouseId).ToList();
                    break;
                case 1:
                    cellList = query.Where(w => w.LoadingStatusId == 2 && w.MaterialId == materialId).OrderBy(o => o.WareHouseId).ToList();
                    break;
                case 2:
                    cellList = query.Where(w => w.LoadingStatusId == 2 && w.MaterialId != 0).OrderBy(o => o.WareHouseId).ToList();
                    break;
            }

            return cellList;
        }

        public IEnumerable<StorageGroupZonePresenceDTO> GetReserveZonePresence(int storageId, int loadingStatus)
        {
            FbParameter[] Parameters =
                {
                    new FbParameter("StorageId", storageId)
                };

            string procName = @"select * from ""GetReserveZonePresence""(@StorageId)";

            var query = mapper.Map<IEnumerable<StorageGroupZonePresence>, List<StorageGroupZonePresenceDTO>>(StorageGroupZonePresence.SQLExecuteProc(procName, Parameters));

            List<StorageGroupZonePresenceDTO> cellList = new List<StorageGroupZonePresenceDTO>();

            switch (loadingStatus)
            {
                case -1: //вся коллекция 
                    cellList = query;
                    break;
                case 0: //свободные + частично загруженные
                    cellList = query.Where(w => w.LoadingStatusId < 3).OrderBy(o => o.WareHouseId).ToList();
                    break;
                case 1:
                    cellList = query.Where(w => w.LoadingStatusId == 1).OrderBy(o => o.WareHouseId).ToList();
                    break;
                case 2:
                    cellList = query.Where(w => w.LoadingStatusId == 2).OrderBy(o => o.WareHouseId).ToList();
                    break;
            }

            return cellList;
        }

        public void CreateRange(List<StorageGroupZonesDTO> storageGroupZones)
        {
           
            for (int i = 0; i <= storageGroupZones.Count - 1; i++)
            {
                var createrecord = StorageGroupZones.Create(mapper.Map<StorageGroupZones>(storageGroupZones[i]));
            }
        }

        public int StorageGroupZonesCreate(StorageGroupZonesDTO storageGroupZones)
        {

            
            var createrecord = StorageGroupZones.Create(mapper.Map<StorageGroupZones>(storageGroupZones));
            return (int)createrecord.StorageGroupZoneId;
        }

        public void StorageGroupZonesUpdate(StorageGroupZonesDTO storageGroupZones)
        {

            var eGroup = StorageGroupZones.GetAll().SingleOrDefault(c => c.StorageGroupZoneId == storageGroupZones.StorageGroupZoneId);

            StorageGroupZones.Update((mapper.Map<StorageGroupZonesDTO, StorageGroupZones>(storageGroupZones, eGroup)));
        }

        public bool StorageGroupZonesDelete(StorageGroupZonesDTO storageGroupZones)
        {
            try
            {

                StorageGroupZones.Delete(StorageGroupZones.GetAll().FirstOrDefault(c => c.StorageGroupZoneId == storageGroupZones.StorageGroupZoneId));
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
