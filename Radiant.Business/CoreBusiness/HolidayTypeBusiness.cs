using AutoMapper;
using Microsoft.Extensions.Logging;
using Radiant.Business.Contracts;
using Radiant.Business.Models;
using Radiant.DataAccess.Models;
using Radiant.DataAccess.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Radiant.Business.CoreBusiness
{
    public class HolidayTypeBusiness : IGenericBusiness<HolidayTypeDto>
    {
        private readonly IGenericRepository<Holidaytype> _holidayTypeRepository;
        private readonly ILogger<HolidayTypeBusiness> _logger;
        private readonly IMapper _modelMapper;

        public HolidayTypeBusiness(IGenericRepository<Holidaytype> holidayTypeRepository
            , ILogger<HolidayTypeBusiness> logger
            , IMapper modelMapper)
        {
            _holidayTypeRepository = holidayTypeRepository;
            _logger = logger;
            _modelMapper = modelMapper;
        }

        public async Task<HolidayTypeDto> Create(HolidayTypeDto item)
        {
            try
            {
                var role = _modelMapper.Map<Holidaytype>(item);
                var createdRecord = await _holidayTypeRepository.Create(role);
                return _modelMapper.Map<HolidayTypeDto>(createdRecord);
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
                await _holidayTypeRepository.Delete(id);
            }
            catch
            {
                throw;
            }
        }

        public async Task<HolidayTypeDto> Edit(HolidayTypeDto item)
        {
            try
            {
                var holidayType = _modelMapper.Map<Holidaytype>(item);
                var updatedRecord = await _holidayTypeRepository.Edit(holidayType);
                return _modelMapper.Map<HolidayTypeDto>(updatedRecord);
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<HolidayTypeDto>> GetAll()
        {
            try
            {
                var holidayTypes = await _holidayTypeRepository.GetAll();
                return _modelMapper.Map<List<HolidayTypeDto>>(holidayTypes);
            }
            catch
            {
                throw;
            }
        }

        public async Task<HolidayTypeDto> GetById(long id)
        {
            try
            {
                var holidayType = await _holidayTypeRepository.GetById(id);
                return _modelMapper.Map<HolidayTypeDto>(holidayType);
            }
            catch
            {
                throw;
            }
        }

        public async Task<HolidayTypeDto> GetByName(string name)
        {
            try
            {
                var role = await _holidayTypeRepository.GetByName(name);
                return _modelMapper.Map<HolidayTypeDto>(role);
            }
            catch
            {
                throw;
            }
        }
    }
}
