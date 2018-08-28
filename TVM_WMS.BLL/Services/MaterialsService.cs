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

namespace TVM_WMS.BLL.Services
{
    public class MaterialsService : IMaterialsService
    {
        private IUnitOfWork Database { get; set; }
        private IRepository<Materials> Materials;
        private IRepository<StorageGroups> StorageGroups;
        private IRepository<ZoneNames> ZoneNames;
        private IRepository<MaterialGroups> MaterialGroups;
        private IRepository<Receipts> Receipts;
        private IMapper mapper;
        private readonly Logger _logger = LogManager.GetCurrentClassLogger();

        public MaterialsService(IUnitOfWork uow)
        {
            Database = uow;
            Materials = Database.GetRepository<Materials>();
            StorageGroups = Database.GetRepository<StorageGroups>();
            MaterialGroups = Database.GetRepository<MaterialGroups>();
            ZoneNames = Database.GetRepository<ZoneNames>();
            Receipts = Database.GetRepository<Receipts>();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<MaterialsDTO, Materials>();
                cfg.CreateMap<Materials, MaterialsDTO>();
                cfg.CreateMap<ZoneNames, ZoneNamesDTO>();
                cfg.CreateMap<StorageGroups, StorageGroupsDTO>();
                cfg.CreateMap<Receipts, ReceiptsDTO>();
            });

            mapper = config.CreateMapper();
        }

        public IEnumerable<MaterialsDTO> GetMaterials()
        {
            var result = (from mt in Materials.GetAll()
                          join sg in StorageGroups.GetAll() on mt.StorageGroupId equals sg.StorageGroupId into ms
                          from sg in ms.DefaultIfEmpty()
                          join mg in MaterialGroups.GetAll() on mt.MaterialGroupId equals mg.MaterialGroupId into gr
                          from mg in gr.DefaultIfEmpty()
                          select new MaterialsDTO
                          {
                              MaterialId = mt.MaterialId,
                              Article = mt.Article,
                              Name = mt.Name,
                              GroupName = mg.Name,
                              Description = mt.Description,
                              Notes = mt.Notes,
                              MaterialGroupId = mt.MaterialGroupId,
                              StorageGroupId = sg.StorageGroupId,
                              StorageGroupName = sg.StorageGroupName
                          });

            return result.ToList();
        }

        public ZoneNamesDTO GetZoneNameByMaterial(int materialId)
        {
            FbParameter[] Parameters =
                {
                    new FbParameter("MaterialId", materialId)
                 };

            string procName = @"select * from ""GetZoneNameByMaterial""(@MaterialId)";


            var result = mapper.Map<IEnumerable<ZoneNames>, List<ZoneNamesDTO>>(ZoneNames.SQLExecuteProc(procName, Parameters));

            return result.FirstOrDefault();
        }

        #region CRUD method's

        public short MaterialCreate(MaterialsDTO material)
        {
            if (NotDublicate(material.Article))
            {
                try
                {
                    var createrecord = Materials.Create(mapper.Map<Materials>(material));
                    return (short)createrecord.MaterialId;
                }
                catch (Exception ex)
                {
                    return 0;
                }
            }
            else
                return -1;
        }

        private bool NotDublicate(string article)
        {
            return (Materials.GetAll().Where(c => c.Article == article).Count() == 0);
           
        }

        public void MaterialUpdate(MaterialsDTO material)
        {
            var eGroup = Materials.GetAll().SingleOrDefault(c => c.MaterialId == material.MaterialId);
            Materials.Update((mapper.Map<MaterialsDTO, Materials>(material, eGroup)));
        }

        public Error.ErrorCRUD MaterialDelete(MaterialsDTO material)
        {
            try
            {
                Error.ErrorCRUD result = CanDelete(material.MaterialId);
                if (result == Error.ErrorCRUD.CanDelete)
                {
                    Materials.Delete(Materials.GetAll().FirstOrDefault(c => c.MaterialId == material.MaterialId));
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

        private Error.ErrorCRUD CanDelete(int materialId)
        {
            return (Receipts.GetAll().Any(s => s.MaterialId == materialId)) ? Error.ErrorCRUD.RelationError : Error.ErrorCRUD.CanDelete;
        }
        #endregion

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}