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
using System.Windows.Forms;

namespace TVM_WMS.BLL.Services
{
    public class CellZonesService : ICellZonesService
    {
        private IUnitOfWork Database { get; set; }
        
        private IRepository<CellZones> CellZones;
        private IRepository<ZoneNames> ZoneNames;
        private IRepository<WareHouses> WareHouses;
        private IRepository<StoreNames> StoreNames;

        private IMapper mapper;
        private readonly Logger _logger = LogManager.GetCurrentClassLogger();

        public CellZonesService(IUnitOfWork uow)
        {
            Database = uow;
            CellZones = Database.GetRepository<CellZones>();
            ZoneNames = Database.GetRepository<ZoneNames>();
            WareHouses = Database.GetRepository<WareHouses>();
            StoreNames = Database.GetRepository<StoreNames>();

            var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<CellZones, CellZonesDTO>();
                    cfg.CreateMap<CellZonesDTO, CellZones>();
                });

            mapper = config.CreateMapper();
        }

        public IEnumerable<CellZonesDTO> GetCellZones()
        {
            return mapper.Map<IEnumerable<CellZones>, List<CellZonesDTO>>(CellZones.GetAll());
        }

        public List<int> GetStoreNamesByZoneId(int zoneId)
        {
            var result = (from cz in CellZones.GetAll()
                          join wh in WareHouses.GetAll() on cz.WareHouseId equals wh.WareHouseId
                          join sn in StoreNames.GetAll() on wh.StoreNameId equals sn.StoreNameId
                          where cz.ZoneNameId == zoneId
                          group sn by sn.StoreNameId into gr
                          select gr.Key 
                ).ToList();

            return result;
        }

        public bool FindReserveZoneByStoreName(int storeNameId)
        {
            var result = (from zn in ZoneNames.GetAll()
                          join cz in CellZones.GetAll() on zn.ZoneNameId equals cz.ZoneNameId
                          join wh in WareHouses.GetAll() on cz.WareHouseId equals wh.WareHouseId
                          join sn in StoreNames.GetAll() on wh.StoreNameId equals sn.StoreNameId
                          join sn_p in StoreNames.GetAll() on sn.ParentId equals sn_p.StoreNameId
                          where zn.ZoneTypeId == 2 && sn_p.StoreNameId == storeNameId
                          select new StoreNamesDTO() 
                          {
                              StoreNameId = sn_p.StoreNameId
                          }
                ).Any();

            return result;
        }

        public bool RenewalCellZones(List<WareHousesDTO> listCells)
        {
            bool result;

            var linqSideRusult = listCells.Where(s => s.ZoneNameId != null).Select(s => new CellZonesDTO
            {
                CellZoneId = s.CellZoneId ?? 0,
                WareHouseId = s.WareHouseId,
                ZoneNameId = s.ZoneNameId ?? 0
            }).ToList();
            
            var dbSideRusult = mapper.Map<IEnumerable<CellZones>, List<CellZonesDTO>>(CellZones.GetAll()).Where(cz => listCells.Where(lc => lc.CellZoneId == cz.CellZoneId).Any()).ToList();
                      
            var ids = dbSideRusult.Select(s => s.CellZoneId)
                .Union(linqSideRusult.Select(s => s.CellZoneId));

            var fullResult = (from i in ids
                              join db in dbSideRusult on i equals db.CellZoneId into j_db
                              from db in j_db.DefaultIfEmpty()
                              join linq in linqSideRusult on i equals linq.CellZoneId into j_linq
                              from linq in j_linq.DefaultIfEmpty()
                              select new { db, linq })
                              .ToList();

            string caseStr;
            int cellZoneId = 0;

            try
            {
                for (int i = 0; i < fullResult.Count(); i++)
                {
                    caseStr = (fullResult[i].db == null) ? "add" :
                        (fullResult[i].linq == null) ? "delete" :
                        (!PropertyCompare.Equal<CellZonesDTO>(fullResult[i].db, fullResult[i].linq)) ? "update" : "";

                    switch (caseStr)
                    {
                        case "add":
                            {
                                CellZones.Create(mapper.Map<CellZones>(fullResult[i].linq));
                            }
                            break;
                        case "update":
                            {
                                cellZoneId = fullResult[i].linq.CellZoneId;
                                var eGroup = CellZones.GetAll().SingleOrDefault(c => c.CellZoneId == cellZoneId);

                                CellZones.Update((mapper.Map<CellZonesDTO, CellZones>(fullResult[i].linq, eGroup)));
                            }
                            break;
                        case "delete":
                            {
                                cellZoneId = fullResult[i].db.CellZoneId;
                                CellZones.Delete(CellZones.GetAll().FirstOrDefault(c => c.CellZoneId == cellZoneId));
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
               
        public int CellZoneCreate(CellZonesDTO cellZone)
        {
            var createrecord = CellZones.Create(mapper.Map<CellZones>(cellZone));
            return (int)createrecord.CellZoneId;
        }

        public void CreateRange(List<CellZonesDTO> cellZones)
        {
            for (int i = 0; i <= cellZones.Count - 1; i++)
            {
                var createrecord = CellZones.Create(mapper.Map<CellZones>(cellZones[i]));
            }
        }

        public void CellZoneUpdate(CellZonesDTO cellZone)
        {

            var eGroup = CellZones.GetAll().SingleOrDefault(c => c.CellZoneId == cellZone.CellZoneId);

            CellZones.Update((mapper.Map<CellZonesDTO, CellZones>(cellZone, eGroup)));
        }

        public bool CellZoneDelete(CellZonesDTO cellZone)
        {
            try
            {
                CellZones.Delete(CellZones.GetAll().FirstOrDefault(c => c.CellZoneId == cellZone.CellZoneId));
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