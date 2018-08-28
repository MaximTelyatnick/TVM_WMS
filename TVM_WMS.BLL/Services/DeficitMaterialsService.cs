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
using FirebirdSql.Data.FirebirdClient;
using TVM_WMS.BLL.DTO.QueryDTO;
using TVM_WMS.DAL.Entities.QueryModel;

namespace TVM_WMS.BLL.Services
{
    public class DeficitMaterialsService : IDeficitMaterialsService
    {
        private IUnitOfWork Database { get; set; }
        private IRepository<DeficitMaterials> DeficitMaterials;
        private IRepository<DeficitCalcMaterials> DeficitCalcMaterials;
        private IMapper mapper;
        private readonly Logger _logger = LogManager.GetCurrentClassLogger();

        public DeficitMaterialsService(IUnitOfWork uow)
        {
            Database = uow;
            DeficitMaterials = Database.GetRepository<DeficitMaterials>();
            DeficitCalcMaterials = Database.GetRepository<DeficitCalcMaterials>();

            var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<DeficitMaterials, DeficitMaterialsDTO>();
                    cfg.CreateMap<DeficitMaterialsDTO, DeficitMaterials>();
                    cfg.CreateMap<DeficitCalcMaterials, DeficitCalcMaterialsDTO>();
                });

            mapper = config.CreateMapper();
        }

        public IEnumerable<DeficitMaterialsDTO> GetDeficitMaterials()
        {
            return mapper.Map<IEnumerable<DeficitMaterials>, List<DeficitMaterialsDTO>>(DeficitMaterials.GetAll());
        }

        public IEnumerable<DeficitCalcMaterialsDTO> GetDeficitCalcMaterials(int countDays)
        {
            FbParameter[] Parameters =
                {
                    new FbParameter("CountDays", countDays)
                 };

            string procName = @"select * from ""GetMaterialDeficit""(@CountDays)";

            return mapper.Map<IEnumerable<DeficitCalcMaterials>, List<DeficitCalcMaterialsDTO>>(DeficitCalcMaterials.SQLExecuteProc(procName, Parameters));        
        }

        public int DeficitMaterialCreate(DeficitMaterialsDTO dmdto)
        {
            var createrecord = DeficitMaterials.Create(mapper.Map<DeficitMaterials>(dmdto));
            return (int)createrecord.Id;
        }

        public void CreateRange(List<DeficitMaterialsDTO> dmdto)
        {
            for (int i = 0; i <= dmdto.Count - 1; i++)
            {
                var createrecord = DeficitMaterials.Create(mapper.Map<DeficitMaterials>(dmdto[i]));
            }
        }

        public void DeficitMaterialUpdate(DeficitMaterialsDTO dmdto)
        {

            var eGroup = DeficitMaterials.GetAll().SingleOrDefault(c => c.Id == dmdto.Id);

            DeficitMaterials.Update((mapper.Map<DeficitMaterialsDTO, DeficitMaterials>(dmdto, eGroup)));
        }

        public bool DeficitMaterialDelete(DeficitMaterialsDTO dmdto)
        {
            try
            {
                DeficitMaterials.Delete(DeficitMaterials.GetAll().FirstOrDefault(c => c.Id == dmdto.Id));
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
