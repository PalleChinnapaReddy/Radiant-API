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
    public class PayrollShiftBusiness : IPayrollShiftBusiness
    {
        private readonly IPayrollShiftRepository _shiftRepository;
        private readonly ILogger<PayrollShiftBusiness> _logger;
        private readonly IMapper _modelMapper;

        public PayrollShiftBusiness(IPayrollShiftRepository shiftRepository
            , ILogger<PayrollShiftBusiness> logger
            , IMapper modelMapper)
        {
            _shiftRepository = shiftRepository;
            _logger = logger;
            _modelMapper = modelMapper;
        }

        public async Task<PayrollshiftDto> Create(PayrollshiftDto item)
        {
            try
            {
                var shift = _modelMapper.Map<Payrollshift>(item);
                var createdRecord = await _shiftRepository.Create(shift);
                return _modelMapper.Map<PayrollshiftDto>(createdRecord);
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
                await _shiftRepository.Delete(id);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<PayrollshiftDto> Edit(PayrollshiftDto item)
        {
            try
            {
                var shift = _modelMapper.Map<Payrollshift>(item);
                var updatedRecord = await _shiftRepository.Edit(shift);
                return _modelMapper.Map<PayrollshiftDto>(updatedRecord);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<PayrollshiftDto>> Edit(List<PayrollshiftDto> item)
        {
            try
            {
                var shift = _modelMapper.Map<List<Payrollshift>>(item);
                var updatedRecord = await _shiftRepository.Edit(shift);
                return _modelMapper.Map<List<PayrollshiftDto>>(updatedRecord);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<PayrollshiftDto>> GetActiveShiftsByDate(DateTime dateTime)
        {
            try
            {
                var shifts = await _shiftRepository.GetActiveShiftsByDate(dateTime);
                return _modelMapper.Map<List<PayrollshiftDto>>(shifts);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<PayrollshiftDto>> GetActiveShiftsByDateAndShift(DateTime dateTime, long? shiftId)
        {
            try
            {
                var shifts = await _shiftRepository.GetActiveShiftsByDateAndShift(dateTime,shiftId);
                return _modelMapper.Map<List<PayrollshiftDto>>(shifts);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<PayrollshiftDto>> GetAll()
        {
            try
            {
                var shifts = await _shiftRepository.GetAll();
                return _modelMapper.Map<List<PayrollshiftDto>>(shifts);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<PayrollshiftDto> GetById(long id)
        {
            try
            {
                var shift = await _shiftRepository.GetById(id);
                return _modelMapper.Map<PayrollshiftDto>(shift);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<PayrollshiftDto> GetByName(string name)
        {
            try
            {
                var shift = await _shiftRepository.GetByName(name);
                return _modelMapper.Map<PayrollshiftDto>(shift);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}



