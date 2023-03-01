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
    public class PayrollConfigBusiness : IPayrollConfigBusiness
    {
        private readonly IPayrollConfigRepository _payrollConfigRepository;
        private readonly ILogger<PayrollConfigBusiness> _logger;
        private readonly IMapper _modelMapper;

        public PayrollConfigBusiness(IPayrollConfigRepository payrollConfigRepository
            , ILogger<PayrollConfigBusiness> logger
            , IMapper modelMapper)
        {
            _payrollConfigRepository = payrollConfigRepository;
            _logger = logger;
            _modelMapper = modelMapper;
        }

        public async Task<PayrollConfigDto> Create(PayrollConfigDto item)
        {
            try
            {
                var PayrollConfig = _modelMapper.Map<Payrollconfig>(item);
                var createdRecord = await _payrollConfigRepository.Create(PayrollConfig);
                return _modelMapper.Map<PayrollConfigDto>(createdRecord);
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
                await _payrollConfigRepository.Delete(id);
            }
            catch
            {
                throw;
            }
        }

        public async Task<PayrollConfigDto> Edit(PayrollConfigDto item)
        {
            try
            {
                var payrollConfig = _modelMapper.Map<Payrollconfig>(item);
                var updatedRecord = await _payrollConfigRepository.Edit(payrollConfig);
                return _modelMapper.Map<PayrollConfigDto>(updatedRecord);
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<PayrollConfigDto>> GetAll()
        {
            try
            {
                var payrollconfigs = await _payrollConfigRepository.GetAll();
                return _modelMapper.Map<List<PayrollConfigDto>>(payrollconfigs);
            }
            catch
            {
                throw;
            }
        }

        public async Task<PayrollConfigDto> GetById(long id)
        {
            try
            {
                var payrollConfig = await _payrollConfigRepository.GetById(id);
                return _modelMapper.Map<PayrollConfigDto>(payrollConfig);
            }
            catch
            {
                throw;
            }
        }

        public Task<PayrollConfigDto> GetByName(string name)
        {
            throw new NotImplementedException();
        }
        public async Task<List<PayrollConfigDto>> GetPayrollConfigByMonth(DateTime dateTime)
        {
            try
            {
                var payrollconfigs = await _payrollConfigRepository.GetPayrollConfigByMonth(dateTime);
                return _modelMapper.Map<List<PayrollConfigDto>>(payrollconfigs);
            }
            catch
            {
                throw;
            }
        }
    }
}

