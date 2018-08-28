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
    public class MeasuresService : IMeasuresService
    {
        private IUnitOfWork Database { get; set; }
        private IRepository<Measures> Measures;
        private IRepository<PackingTypes> PackingTypes;
        private IRepository<Units> Units;
        private IMapper mapper;
        private readonly Logger _logger = LogManager.GetCurrentClassLogger();

        public MeasuresService(IUnitOfWork uow)
        {
            Database = uow;
            Measures = Database.GetRepository<Measures>();
            PackingTypes = Database.GetRepository<PackingTypes>();
            Units = Database.GetRepository<Units>();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<MeasuresDTO, Measures>();
                cfg.CreateMap<Measures, MeasuresDTO>();
            });

            mapper = config.CreateMapper();
        }

        public IEnumerable<MeasuresDTO> GetMeasures()
        {
            var result = (from m in Measures.GetAll()
                          join p in PackingTypes.GetAll() on m.PackingTypeId equals p.PackingTypeId into pc
                          from p in pc.DefaultIfEmpty()
                          join u in Units.GetAll() on m.UnitId equals u.UnitId into un
                          from u in un.DefaultIfEmpty()
                          select new MeasuresDTO
                          {
                              MeasureId = m.MeasureId,
                              Height = m.Height,
                              Width=m.Width,
                              Length = m.Length,
                              UnitWeight = m.UnitWeight,
                              UnitLocalName= u.UnitLocalName,
                              UnitId = m.UnitId,
                              PackingTypeId = m.PackingTypeId,
                              PackingName = p.PackingName,
                              FullName = p.PackingName + "  " + m.Height.ToString() + " x " + m.Width.ToString() + " x " + m.Length.ToString() + " ( " + m.UnitWeight.ToString() +" "+ u.UnitLocalName + " ) " 
                          });

            return result.ToList();

        }

        public int MeasureCreate(MeasuresDTO measure)
        {
            var createrecord = Measures.Create(mapper.Map<Measures>(measure));
            return (int)createrecord.MeasureId;
        }

        public void MeasureUpdate(MeasuresDTO measure)
        {

            var eGroup = Measures.GetAll().SingleOrDefault(c => c.MeasureId == measure.MeasureId);
            Measures.Update((mapper.Map<MeasuresDTO, Measures>(measure, eGroup)));
        }

        public bool MeasureDelete(MeasuresDTO measure)
        {
            try
            {
                Measures.Delete(Measures.GetAll().FirstOrDefault(c => c.MeasureId == measure.MeasureId));
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