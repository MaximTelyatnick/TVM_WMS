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
using TVM_WMS.BLL.DTO.QueryDTO;
using TVM_WMS.DAL.Entities.QueryModel;

namespace TVM_WMS.BLL.Services
{
    public class StoreNamesService : IStoreNamesService
    {
        private IUnitOfWork Database { get; set; }
        
        private IRepository<StoreNames> StoreNames;
        private IRepository<StoreTypes> StoreTypes;
        private IRepository<SettingsService> SettingsService;
        private IRepository<StoreLoad> StoreLoad;
        
        private IMapper mapper;
        private readonly Logger _logger = LogManager.GetCurrentClassLogger();

        public StoreNamesService(IUnitOfWork uow)
        {
            Database = uow;
            StoreNames = Database.GetRepository<StoreNames>();
            StoreTypes = Database.GetRepository<StoreTypes>();
            SettingsService = Database.GetRepository<SettingsService>();
            StoreLoad = Database.GetRepository<StoreLoad>();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<StoreNames, StoreNamesDTO>();
                cfg.CreateMap<StoreNamesDTO, StoreNames>();
                cfg.CreateMap<StoreTypes, StoreTypesDTO>();
                cfg.CreateMap<StoreLoad, StoreLoadDTO>();
            });

            mapper = config.CreateMapper();
        }

        public IEnumerable<StoreNamesDTO> GetStoreNames()
        {
            var query = (from sn in StoreNames.GetAll()
                        join st in StoreTypes.GetAll() on sn.StoreTypeId equals st.StoreTypeId into snst
                        from st in snst.DefaultIfEmpty()
                        join p in StoreNames.GetAll() on sn.ParentId equals p.StoreNameId into snp
                        from p in snp.DefaultIfEmpty()
                        select new StoreNamesDTO()
                        {
                            StoreNameId = sn.StoreNameId,
                            ParentId = sn.ParentId,
                            CellCount = sn.CellCount,
                            ColumnCount = sn.ColumnCount,
                            LineCount = sn.LineCount,
                            Name = sn.Name,
                            ParentName = p.Name,
                            StoreTypeId = sn.StoreTypeId,
                            StoreTypeName = (sn.StoreTypeId != null) ? st.StoreTypeName : "",
                            EnableAuthomatization = sn.EnableAuthomatization,
                            EnumerationTypeId = sn.EnumerationTypeId
                        }).ToList();
            return query;
        }

        public List<StoreNamesDTO> GetBindedStoreNames()
        {
            var bindStoreNameIdList = ConfigClass.Instance.DeviceBindingSettingList.GroupBy(db => db.StoreNameParentId).Select(s => s.First()).ToList();

            return mapper.Map<IEnumerable<StoreNames>, List<StoreNamesDTO>>(StoreNames.GetAll()).Where(sn => bindStoreNameIdList.Where(bsn => bsn.StoreNameParentId == sn.StoreNameId).Any()).ToList();
        }

        public IEnumerable<StoreNamesDTO> GetStoreNamesWithTypes()
        {
            var query = from sn in StoreNames.GetAll()
                        join st in StoreTypes.GetAll() on sn.StoreTypeId equals st.StoreTypeId into snst
                        from st in snst.DefaultIfEmpty()
                        select new StoreNamesDTO()
                        {
                            StoreNameId = sn.StoreNameId,
                            ParentId = sn.ParentId,
                            CellCount = sn.CellCount,
                            ColumnCount = sn.ColumnCount,
                            LineCount = sn.LineCount,
                            Name = sn.Name,
                            StoreTypeId = sn.StoreTypeId,
                            StoreTypeName = (sn.StoreTypeId != null) ? st.StoreTypeName : "",
                            EnableAuthomatization = sn.EnableAuthomatization,
                            EnumerationTypeId = sn.EnumerationTypeId
                        };
            return query;
        }

        public IEnumerable<StoreNamesDTO> GetStoreNameWithFullHeader()
        {
            var query = (from sn in StoreNames.GetAll()
                         join sn_j in StoreNames.GetAll() on sn.ParentId equals sn_j.StoreNameId
                         where sn.ParentId != null
                         select new StoreNamesDTO()
                         {
                             StoreNameId = sn.StoreNameId,
                             Name = sn.Name + "(" + sn_j.Name + ")",
                             EnableAuthomatization = sn_j.EnableAuthomatization
                         });
            return query;
        }
        
        public IEnumerable<StoreTypesDTO> GetStoreTypes()
        {
            return mapper.Map<IEnumerable<StoreTypes>, List<StoreTypesDTO>>(StoreTypes.GetAll());
        }

        public IEnumerable<StoreLoadDTO> GetStoreLoad()
        {
            string procName = @"select * from ""GetStoreLoad""";

            return mapper.Map<IEnumerable<StoreLoad>, List<StoreLoadDTO>>(StoreLoad.SQLExecuteProc(procName)); 
        }

        public StoreNamesDTO GetStoreNameById(int? id)
        {
            var record = StoreNames.GetAll().SingleOrDefault(c => c.StoreNameId == id.Value);
            return mapper.Map<StoreNames, StoreNamesDTO>(record);
        }

        public List<StoreNamesDTO> GetRowByStoreNameId(int? id)
        {
            //var record = StoreNames.GetAll().SingleOrDefault(c => c.ParentId == id.Value);
            return mapper.Map<IEnumerable<StoreNames>, List<StoreNamesDTO>>(StoreNames.GetAll().Where(c => c.ParentId == id.Value)).ToList();
        }


        public int StoreNameCreate(StoreNamesDTO storeName)
        {
            var createrecord = StoreNames.Create(mapper.Map<StoreNames>(storeName));
            return (int)createrecord.StoreNameId;
        }

        public void StoreNameUpdate(StoreNamesDTO storeName)
        {
            var eGroup = StoreNames.GetAll().SingleOrDefault(c => c.StoreNameId == storeName.StoreNameId);

            StoreNames.Update((mapper.Map<StoreNamesDTO, StoreNames>(storeName, eGroup)));
        }

        public bool StoreNameDelete(StoreNamesDTO storeName)
        {
            try
            {
                StoreNames.Delete(StoreNames.GetAll().FirstOrDefault(c => c.StoreNameId == storeName.StoreNameId));
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