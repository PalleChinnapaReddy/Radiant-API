using AutoMapper;
using Microsoft.Extensions.Logging;
using Radiant.Business.Contracts;
using Radiant.Business.Models;
using Radiant.DataAccess.Models;
using Radiant.DataAccess.Repository.Contracts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Radiant.Business.CoreBusiness
{
    public class CurrencyBusiness : IGenericBusiness<CurrencyDto>
    {
        private readonly IGenericRepository<Currency> _currencyRepository;
        private readonly ILogger<CurrencyBusiness> _logger;
        private readonly IMapper _modelMapper;

        public CurrencyBusiness(IGenericRepository<Currency> currencyRepository
            , ILogger<CurrencyBusiness> logger
            , IMapper modelMapper)
        {
            _currencyRepository = currencyRepository;
            _logger = logger;
            _modelMapper = modelMapper;
        }

        public async Task<CurrencyDto> Create(CurrencyDto item)
        {
            try
            {
                var currency = _modelMapper.Map<Currency>(item);
                var createdRecord = await _currencyRepository.Create(currency);
                return _modelMapper.Map<CurrencyDto>(createdRecord);
            }
            catch
            {
                throw;
            }
        }

        public async Task Delete(long id)
        {
            try
            {
                await _currencyRepository.Delete(id);
            }
            catch
            {
                throw;
            }
        }

        public async Task<CurrencyDto> Edit( CurrencyDto item)
        {
            try
            {
                var currency = _modelMapper.Map<Currency>(item);
                var updateRecord = await _currencyRepository.Edit( currency);
                return _modelMapper.Map<CurrencyDto>(updateRecord);
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<CurrencyDto>> GetAll()
        {
            try
            {
                var currencies = await _currencyRepository.GetAll();
                return _modelMapper.Map<List<CurrencyDto>>(currencies);
            }
            catch
            {
                throw;
            }
        }

        public async Task<CurrencyDto> GetById(long id)
        {
            try
            {
                var currency = await _currencyRepository.GetById(id);
                return _modelMapper.Map<CurrencyDto>(currency);
            }
            catch
            {
                throw;
            }
        }

        public Task<CurrencyDto> GetByName(string name)
        {
            throw new System.NotImplementedException();
        }
    }
}
