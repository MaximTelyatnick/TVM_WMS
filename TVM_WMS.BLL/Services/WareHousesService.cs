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
    public class WareHousesService : IWareHousesService
    {
        private IUnitOfWork Database { get; set; }
        
        private IRepository<WareHouses> WareHouses;
        private IRepository<StoreNames> StoreNames;
        private IRepository<CellZones> CellZones;
        private IRepository<ZoneNames> ZoneNames;
        private IRepository<StorageGroupZones> StorageGroupZones;
        private IRepository<CellInfo> CellInfo;
        private IRepository<CellPresence> CellPresence;
        private IRepository<WareHouseCellsInfo> WareHouseCellsInfo;
        private IRepository<WareHousePresences> WareHousePresences;
        private IRepository<Measures> Measures;
        
        private IMapper mapper;
        private readonly Logger _logger = LogManager.GetCurrentClassLogger();

        public WareHousesService(IUnitOfWork uow)
        {
            Database = uow;
            WareHouses = Database.GetRepository<WareHouses>();
            StoreNames = Database.GetRepository<StoreNames>();
            CellZones = Database.GetRepository<CellZones>();
            ZoneNames = Database.GetRepository<ZoneNames>();
            StorageGroupZones = Database.GetRepository<StorageGroupZones>();
            CellInfo = Database.GetRepository<CellInfo>();
            CellPresence = Database.GetRepository<CellPresence>();
            WareHouseCellsInfo = Database.GetRepository<WareHouseCellsInfo>();
            WareHousePresences = Database.GetRepository<WareHousePresences>();
            Measures = Database.GetRepository<Measures>();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CellInfo, WareHousesDTO>();
                cfg.CreateMap<CellPresence, CellPresenceDTO>();
                cfg.CreateMap<WareHouseCellsInfo, WareHousesDTO>();
                cfg.CreateMap<WareHouses, WareHousesDTO>();
                cfg.CreateMap<WareHousesDTO, WareHouses>();
                cfg.CreateMap<WareHousePresences, WareHousePresencesDTO>();
            });

            mapper = config.CreateMapper();
        }

        public WareHousesDTO GetWareHouseById(int id)
        {
            var entities = WareHouses.GetAll().FirstOrDefault(s => s.WareHouseId == id);
            return mapper.Map<WareHouses, WareHousesDTO>(entities);         
        }

        public IEnumerable<WareHousesDTO> GetWareHouses()
        {
            string procName = @"select * from ""GetWareHouses""";

            return mapper.Map<IEnumerable<WareHouseCellsInfo>, List<WareHousesDTO>>(WareHouseCellsInfo.SQLExecuteProc(procName));
        }

        public IEnumerable<WareHousePresencesDTO> GetWareHousePresences()
        {
            string procName = @"select * from ""GetWareHousePresences""";

            return mapper.Map<IEnumerable<WareHousePresences>, List<WareHousePresencesDTO>>(WareHousePresences.SQLExecuteProc(procName));
        }
               
        public IEnumerable<CellPresenceDTO> GetCellPresence(int warehouseId)
        {
            FbParameter[] Parameters =
                {
                    new FbParameter("_WareHouseId", warehouseId)
                 };

            string procName = @"select * from ""GetReceiptsByCell""(@_WareHouseId)";

            return mapper.Map<IEnumerable<CellPresence>, List<CellPresenceDTO>>(CellPresence.SQLExecuteProc(procName, Parameters));
        }

        public WareHousesDTO GetCellInfo(int warehouseId)
        {
            FbParameter[] Parameters =
                {
                    new FbParameter("_WarehouseId", warehouseId)
                 };

            string procName = @"select * from ""GetCellInfo""(@_WareHouseId) ";

            return mapper.Map<IEnumerable<CellInfo>, List<WareHousesDTO>>(CellInfo.SQLExecuteProc(procName, Parameters)).First();
        }

        public void SetEnumerationCells(IEnumerable<WareHousesDTO> wareHouse)
        {
            WareHousesDTO[] outArray = new WareHousesDTO[] { };

            int curStoreId = wareHouse.First().StoreNameId;
            int? sortedType = StoreNames.GetAll().First(s => s.StoreNameId == curStoreId).EnumerationTypeId;

            var paramModel = StoreNames.GetAll().FirstOrDefault(w => w.StoreNameId == curStoreId);
            var paramArr = wareHouse.Cast<WareHousesDTO>().ToArray();

            int arrCount = paramArr.Length;

            if (arrCount > 0)
            {
                outArray = GetSortedArray(paramArr, (int)paramModel.LineCount, (int)paramModel.ColumnCount, (int)paramModel.EnumerationTypeId);
            }

            int nextCellNumber = GetNextCellNumber(paramModel.ParentId ?? 0);

            for (int i = 0; i < arrCount; i++)
            {
                if (outArray[i].Checked)
                {
                    outArray[i].NumberCell = 0;
                }
                else
                {
                    outArray[i].NumberCell = nextCellNumber;
                    nextCellNumber++;
                }
                WareHousesUpdate(outArray[i]);
            }

        }

        private int GetNextCellNumber(int storeParentId)
        {
           int rezult;

           var value = (from sn in StoreNames.GetAll()
                        join wh in WareHouses.GetAll() on sn.StoreNameId equals wh.StoreNameId into snwh
                        from wh in snwh.DefaultIfEmpty()
                        where sn.ParentId == storeParentId
                        select new WareHousesDTO()
                        {
                            NumberCell = wh.NumberCell
                        }).Max(s => s.NumberCell);

           if (value == null)
           {
               rezult = 1;
           }
           else
           {
              rezult = (int)value + 1;
           }

           return rezult;
        }

        private T[] GetSortedArray<T>(T[] inArr, int lineCount, int columnCount, int sortType)
        {
            int t = 0;
            int k = 0;
            int size = lineCount * columnCount;
            T[] outarray = new T[size];
            T[] buffer = new T[columnCount];
                        
            switch (sortType)
            {
                case 1:
                    {
                        Array.Reverse(inArr);//приводим массив в нужную последовательность.
                        for (int i = 0; i < lineCount; i++)
                        {
                            Array.Copy(inArr, t, buffer, 0, columnCount);//копируем элементы массива по 'у' штук с 't' позиции(на входе - начало создаваевомого массива - 
                            Array.Reverse(buffer);
                            Array.Copy(buffer, 0, outarray, t, columnCount);

                            t = t + columnCount;//назначаем следующую позицию для старта копирования.
                        }
                    }
                    break;
                case 2:
                    {
                        Array.Reverse(inArr);//приводим массив в нужную последовательность.
                        for (int i = 0; i < lineCount; i++)
                        {
                            Array.Copy(inArr, t, buffer, 0, columnCount);//копируем элементы массива по 'у' штук с 't' позиции(на входе - начало создаваевомого массива - 

                            if (i % 2 == 0)
                                Array.Reverse(buffer);

                            Array.Copy(buffer, 0, outarray, t, columnCount);

                            t = t + columnCount;//назначаем следующую позицию для старта копирования.
                        }
                    }
                    break;
            }

            return outarray;
        }
        
        #region CRUD method's

        public void WareHousesUpdate(WareHousesDTO wareHouse)
        {
            var item = WareHouses.GetAll().SingleOrDefault(c => c.WareHouseId == wareHouse.WareHouseId);

            WareHouses.Update((mapper.Map<WareHousesDTO, WareHouses>(wareHouse, item)));
        }

        public bool WareHousesRangeCreate(IEnumerable<WareHousesDTO> wareHouse)
        {
            WareHouses.CreateRange(mapper.Map<IEnumerable<WareHouses>>(wareHouse));

            return true;
        }

        public bool WareHousesRangeDelete(IEnumerable<WareHousesDTO> wareHouse)
        {
            WareHouses.DeleteAll(mapper.Map<IEnumerable<WareHouses>>(wareHouse));
            return true;
        }

        #endregion

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
