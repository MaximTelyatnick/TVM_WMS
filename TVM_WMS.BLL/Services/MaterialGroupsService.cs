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
    public class MaterialGroupsService : IMaterialGroupsService
    {
        private IUnitOfWork Database { get; set; }
        private IRepository<MaterialGroups> MaterialGroups;
        private IRepository<Materials> Materials;
        private IMapper mapper;
        private readonly Logger _logger = LogManager.GetCurrentClassLogger();

        public MaterialGroupsService(IUnitOfWork uow)
        {
            Database = uow;
            MaterialGroups = Database.GetRepository<MaterialGroups>();
            Materials = Database.GetRepository<Materials>();
          
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<MaterialGroups, MaterialGroupsDTO>();
                cfg.CreateMap<MaterialGroupsDTO, MaterialGroups>();
                cfg.CreateMap<Materials, MaterialsDTO>();
            });

            mapper = config.CreateMapper();
        }

        public IEnumerable<MaterialGroupsDTO> GetMaterialGroups()
        {
            return mapper.Map<IEnumerable<MaterialGroups>, List<MaterialGroupsDTO>>(MaterialGroups.GetAll());
        }

        public short MaterialGroupCreate(MaterialGroupsDTO materialGroup)
        {
            var createrecord = MaterialGroups.Create(mapper.Map<MaterialGroups>(materialGroup));
            return createrecord.MaterialGroupId;
        }

        public void MaterialGroupUpdate(MaterialGroupsDTO materialGroup)
        {
            var eGroup = MaterialGroups.GetAll().SingleOrDefault(c => c.MaterialGroupId == materialGroup.MaterialGroupId);
            MaterialGroups.Update((mapper.Map<MaterialGroupsDTO, MaterialGroups>(materialGroup, eGroup)));
        }

        public Error.ErrorCRUD MaterialGroupDelete(MaterialGroupsDTO materialGroup)
        {
            try
            {
                Error.ErrorCRUD result = CanDelete(materialGroup.MaterialGroupId);
                if (result == Error.ErrorCRUD.CanDelete)
                {
                    MaterialGroups.Delete(MaterialGroups.GetAll().FirstOrDefault(c => c.MaterialGroupId == materialGroup.MaterialGroupId));
                    return Error.ErrorCRUD.NoError;
                }
                else
                {
                    return Error.ErrorCRUD.RelationError;
                }
            }
            catch(Exception ex) 
            {
                return Error.ErrorCRUD.DatabaseError;
            }
        }

        private Error.ErrorCRUD CanDelete(int materialGroupId)
        {
            return (Materials.GetAll().Any(s => s.MaterialGroupId == materialGroupId)) ? Error.ErrorCRUD.RelationError : Error.ErrorCRUD.CanDelete;
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
