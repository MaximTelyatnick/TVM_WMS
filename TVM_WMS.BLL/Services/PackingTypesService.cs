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
    public class PackingTypesService : IPackingTypesService
    {
        private IUnitOfWork Database { get; set; }
        private IRepository<PackingTypes> PackingTypes;
        private IMapper mapper;
        private readonly Logger _logger = LogManager.GetCurrentClassLogger();

        public PackingTypesService(IUnitOfWork uow)
        {
            Database = uow;
            PackingTypes = Database.GetRepository<PackingTypes>();
           
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<PackingTypes, PackingTypesDTO>();
                cfg.CreateMap<PackingTypesDTO, PackingTypes>();
            });

            mapper = config.CreateMapper();
        }

        public IEnumerable<PackingTypesDTO> GetPackingTypes()
        {
             return mapper.Map<IEnumerable<PackingTypes>, List<PackingTypesDTO>>(PackingTypes.GetAll());
        }

        public int PackingTypeCreate(PackingTypesDTO packingType)
        {
            var createrecord = PackingTypes.Create(mapper.Map<PackingTypes>(packingType));
            return (int)createrecord.PackingTypeId;
        }

        public void PackingTypeUpdate(PackingTypesDTO packingType)
        {

            var eGroup = PackingTypes.GetAll().SingleOrDefault(c => c.PackingTypeId == packingType.PackingTypeId);
            PackingTypes.Update((mapper.Map<PackingTypesDTO, PackingTypes>(packingType, eGroup)));
        }

        public bool PackingTypeDelete(PackingTypesDTO packingType)
        {
            try
            {
                PackingTypes.Delete(PackingTypes.GetAll().FirstOrDefault(c => c.PackingTypeId == packingType.PackingTypeId));
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