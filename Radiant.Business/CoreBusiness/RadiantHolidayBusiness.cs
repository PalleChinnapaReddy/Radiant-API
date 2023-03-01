using AutoMapper;
using Microsoft.Extensions.Logging;
using Radiant.Business.Contracts;
using Radiant.Business.Models;
using Radiant.Business.Models.FilterModels;
using Radiant.DataAccess.FilterModels;
using Radiant.DataAccess.Models;
using Radiant.DataAccess.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Radiant.Business.CoreBusiness
{
    public class RadiantHolidayBusiness : IRadiantHolidayBusiness
    {
        private readonly IRadiantHolidayRepository _radiantHolidayRepository;
        private readonly ILogger<RadiantHolidayBusiness> _logger;
        private readonly IMapper _modelMapper;

        public RadiantHolidayBusiness(IRadiantHolidayRepository radiantHolidayRepository
            , ILogger<RadiantHolidayBusiness> logger
            , IMapper modelMapper)
        {
            _radiantHolidayRepository = radiantHolidayRepository;
            _logger = logger;
            _modelMapper = modelMapper;
        }

        public async Task<RadiantHolidayDto> Create(RadiantHolidayDto item)
        {
            try
            {
                var radiantHoliday = _modelMapper.Map<RadiantHoliday>(item);
                var createdRecord = await _radiantHolidayRepository.Create(radiantHoliday);
                return _modelMapper.Map<RadiantHolidayDto>(createdRecord);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<RadiantHolidayDto>> CreateHolidays(List<RadiantHolidayDto> holidayDtos)
        {
            try
            {
                var radiantHolidays = _modelMapper.Map<List<RadiantHoliday>>(holidayDtos);
                var createdRecord = await _radiantHolidayRepository.CreateHolidays(radiantHolidays);
                return _modelMapper.Map<List<RadiantHolidayDto>>(createdRecord);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task Delete(long id)
        {
            try
            {
                await _radiantHolidayRepository.Delete(id);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<RadiantHolidayDto> Edit(RadiantHolidayDto item)
        {
            try
            {
                var radiantHoliday = _modelMapper.Map<RadiantHoliday>(item);
                var updatedRecord = await _radiantHolidayRepository.Edit(radiantHoliday);
                return _modelMapper.Map<RadiantHolidayDto>(updatedRecord);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<RadiantHolidayDto>> GetAll()
        {
            try
            {
                var radiantHolidays = await _radiantHolidayRepository.GetAll();
                return _modelMapper.Map<List<RadiantHolidayDto>>(radiantHolidays);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<RadiantHolidayDto>> GetAllByHolidayType(RadiantHolidayFilterDto holidayByTypeSearchDto)
        {
            try
            {
                var radiantHolidayFilter = _modelMapper.Map<RadiantHolidayFilter>(holidayByTypeSearchDto);
                var radiantHolidays = await _radiantHolidayRepository.GetAllByHolidayType(radiantHolidayFilter);
                return _modelMapper.Map<List<RadiantHolidayDto>>(radiantHolidays);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<RadiantHolidayDto> GetById(long id)
        {
            try
            {
                var radiantHoliday = await _radiantHolidayRepository.GetById(id);
                return _modelMapper.Map<RadiantHolidayDto>(radiantHoliday);
            }
            catch
            {
                throw;
            }
        }

        public Task<RadiantHolidayDto> GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<RadiantHolidayDto> GetHolidayByDate(DateTime dateTime)
        {
            try
            {
                var radiantHoliday = await _radiantHolidayRepository.GetHolidayByDate(dateTime);
                return _modelMapper.Map<RadiantHolidayDto>(radiantHoliday);
            }
            catch
            {
                throw;
            }
        }
    }
}



