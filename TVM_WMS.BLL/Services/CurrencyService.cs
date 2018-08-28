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
    public class CurrencyService : ICurrencyService
    {
        private IUnitOfWork Database { get; set; }
        private IRepository<Currency> Currency;
        private IMapper mapper;
        private readonly Logger _logger = LogManager.GetCurrentClassLogger();

        public CurrencyService(IUnitOfWork uow)
        {
            Database = uow;
            Currency = Database.GetRepository<Currency>();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Currency, CurrencyDTO>();
                cfg.CreateMap<CurrencyDTO, Currency>();
            });

            mapper = config.CreateMapper();
        }

        public IEnumerable<CurrencyDTO> GetCurrency()
        {
            return mapper.Map<IEnumerable<Currency>, List<CurrencyDTO>>(Currency.GetAll());
        }

        public short CurrencyCreate(CurrencyDTO currency)
        {
            var createrecord = Currency.Create(mapper.Map<Currency>(currency));
            return (short)createrecord.CurrencyId;
        }

        public void CurrencyUpdate(CurrencyDTO currency)
        {

            var eGroup = Currency.GetAll().SingleOrDefault(c => c.CurrencyId == currency.CurrencyId);
            Currency.Update((mapper.Map<CurrencyDTO, Currency>(currency, eGroup)));
        }

        public bool CurrencyDelete(CurrencyDTO currency)
        {
            try
            {
                Currency.Delete(Currency.GetAll().FirstOrDefault(c => c.CurrencyId == currency.CurrencyId));
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