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
    public class ShiftBusiness : IShiftBusiness
    {
        private readonly IShiftRepository _shiftRepository;
        private readonly ILogger<ShiftBusiness> _logger;
        private readonly IMapper _modelMapper;

        public ShiftBusiness(IShiftRepository shiftRepository
            , ILogger<ShiftBusiness> logger
            , IMapper modelMapper)
        {
            _shiftRepository = shiftRepository;
            _logger = logger;
            _modelMapper = modelMapper;
        }

        public async Task<ShiftDto> Create(ShiftDto item)
        {
            try
            {
                var shift = _modelMapper.Map<Shift>(item);
                var createdRecord = await _shiftRepository.Create(shift);
                return _modelMapper.Map<ShiftDto>(createdRecord);
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
                await _shiftRepository.Delete(id);
            }
            catch
            {
                throw;
            }
        }

        public async Task<ShiftDto> Edit(ShiftDto item)
        {
            try
            {
                var shift = _modelMapper.Map<Shift>(item);
                var updatedRecord = await _shiftRepository.Edit(shift);
                return _modelMapper.Map<ShiftDto>(updatedRecord);
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<ShiftDto>> GetActiveShiftsByDate(DateTime dateTime)
        {
            try
            {
                var shifts = await _shiftRepository.GetActiveShiftsByDate(dateTime);
                return _modelMapper.Map<List<ShiftDto>>(shifts);
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<ShiftDto>> GetAll()
        {
            try
            {
                var shifts = await _shiftRepository.GetAll();
                return _modelMapper.Map<List<ShiftDto>>(shifts);
            }
            catch
            {
                throw;
            }
        }

        public async Task<ShiftDto> GetById(long id)
        {
            try
            {
                var shift = await _shiftRepository.GetById(id);
                return _modelMapper.Map<ShiftDto>(shift);
            }
            catch
            {
                throw;
            }
        }

        public Task<ShiftDto> GetByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}



