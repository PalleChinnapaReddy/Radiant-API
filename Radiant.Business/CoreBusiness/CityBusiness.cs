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
    public class CityBusiness : ICityBusiness
    {
        private readonly ICityRepository _cityRepository;
        private readonly ILogger<CityBusiness> _logger;
        private readonly IMapper _modelMapper;

        public CityBusiness(ICityRepository cityRepository
            , ILogger<CityBusiness> logger
            , IMapper modelMapper)
        {
            _cityRepository = cityRepository;
            _logger = logger;
            _modelMapper = modelMapper;
        }

        public async Task<CityDto> Create(CityDto item)
        {
            try
            {
                var city = _modelMapper.Map<City>(item);
                var createdRecord = await _cityRepository.Create(city);
                return _modelMapper.Map<CityDto>(createdRecord);
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
                await _cityRepository.Delete(id);
            }
            catch
            {
                throw;
            }
        }

        public async Task<CityDto> Edit(CityDto item)
        {
            try
            {
                var city = _modelMapper.Map<City>(item);
                var updatedRecord = await _cityRepository.Edit(city);
                return _modelMapper.Map<CityDto>(updatedRecord);
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<CityDto>> GetAll()
        {
            try
            {
                var cities = await _cityRepository.GetAll();
                return _modelMapper.Map<List<CityDto>>(cities);
            }
            catch
            {
                throw;
            }
        }

        public async Task<CityDto> GetById(long id)
        {
            try
            {
                var city = await _cityRepository.GetById(id);
                return _modelMapper.Map<CityDto>(city);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public Task<CityDto> GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<List<CityDto>> GetCitiesByStateId(long stateid)
        {
            try
            {
                return  _modelMapper.Map<List<CityDto>>(await _cityRepository.GetCitiesByStateId(stateid));
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
