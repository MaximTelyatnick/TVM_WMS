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
    public class EnumerationTypesService : IEnumerationTypesService
    {
        private IUnitOfWork Database { get; set; }
        private IRepository<EnumerationTypes> EnumerationTypes;
        private IMapper mapper;
        private readonly Logger _logger = LogManager.GetCurrentClassLogger();

        public EnumerationTypesService(IUnitOfWork uow)
        {
            Database = uow;
            EnumerationTypes = Database.GetRepository<EnumerationTypes>();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<EnumerationTypes, EnumerationTypesDTO>();
                cfg.CreateMap<EnumerationTypesDTO, EnumerationTypes>();
            });

            mapper = config.CreateMapper();
        }

        public IEnumerable<EnumerationTypesDTO> GetEnumerationTypes()
        {
                return mapper.Map<IEnumerable<EnumerationTypes>, List<EnumerationTypesDTO>>(EnumerationTypes.GetAll());
        }
  
        public void Dispose()
        {
            Database.Dispose();
        }
    }
}

