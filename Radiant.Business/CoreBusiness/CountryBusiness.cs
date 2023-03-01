using AutoMapper;
using Microsoft.Extensions.Logging;
using Radiant.Business.Contracts;
using Radiant.Business.Models;
using Radiant.DataAccess.Models;
using Radiant.DataAccess.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Radiant.Business.CoreBusiness
{
    public class CountryBusiness : IGenericBusiness<CountryDto>
    {
        private readonly IGenericRepository<Country> _countryRepository;
        private readonly ILogger<CountryBusiness> _logger;
        private readonly IMapper _modelMapper;

        public CountryBusiness(IGenericRepository<Country> countryRepository
            , ILogger<CountryBusiness> logger
            , IMapper modelMapper)
        {
            _countryRepository = countryRepository;
            _logger = logger;
            _modelMapper = modelMapper;
        }

        public async Task<CountryDto> Create(CountryDto item)
        {
            try
            {
                var country = _modelMapper.Map<Country>(item);
                var createdRecord = await _countryRepository.Create(country);
                return _modelMapper.Map<CountryDto>(createdRecord);
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
                await _countryRepository.Delete(id);
            }
            catch
            {
                throw;
            }
        }

        public async Task<CountryDto> Edit(CountryDto item)
        {
            try
            {
                var country = _modelMapper.Map<Country>(item);
                var updatedRecord = await _countryRepository.Edit(country);
                return _modelMapper.Map<CountryDto>(updatedRecord);
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<CountryDto>> GetAll()
        {
            try
            {
                var countrys = await _countryRepository.GetAll();
                return _modelMapper.Map<List<CountryDto>>(countrys);
            }
            catch
            {
                throw;
            }
        }

        public async Task<CountryDto> GetById(long id)
        {
            try
            {
                var country = await _countryRepository.GetById(id);
                return _modelMapper.Map<CountryDto>(country);
            }
            catch
            {
                throw;
            }
        }

        public Task<CountryDto> GetByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}
