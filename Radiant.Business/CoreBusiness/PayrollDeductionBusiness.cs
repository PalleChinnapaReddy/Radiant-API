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
    public class PayrollDeductionBusiness : IPayrollDeductionBusiness
    {
        private readonly IPayrollDeductionRepository _payrollDeductionRepository;
        private readonly ILogger<PayrollDeductionBusiness> _logger;
        private readonly IMapper _modelMapper;

        public PayrollDeductionBusiness(IPayrollDeductionRepository payrollDeductionRepository
            , ILogger<PayrollDeductionBusiness> logger
            , IMapper modelMapper)
        {
            _payrollDeductionRepository = payrollDeductionRepository;
            _logger = logger;
            _modelMapper = modelMapper;
        }
        public async Task<PayrolldeductionDto> Create(PayrolldeductionDto item)
        {
            try
            {
                var payroll = _modelMapper.Map<Payrolldeduction>(item);
                var createdRecord = await _payrollDeductionRepository.Create(payroll);
                return _modelMapper.Map<PayrolldeductionDto>(createdRecord);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task Delete(long id)
        {
            try
            {
                await _payrollDeductionRepository.Delete(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<PayrolldeductionDto> Edit(PayrolldeductionDto item)
        {
            try
            {
                var payroll = _modelMapper.Map<Payrolldeduction>(item);
                var updatedRecord = await _payrollDeductionRepository.Edit(payroll);
                return _modelMapper.Map<PayrolldeductionDto>(updatedRecord);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<PayrolldeductionDto>> GetAll()
        {
            try
            {
                var updatedRecord = await _payrollDeductionRepository.GetAll();
                return _modelMapper.Map<List<PayrolldeductionDto>>(updatedRecord);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<PayrolldeductionDto> GetById(long id)
        {
            try
            {
                var updatedRecord = await _payrollDeductionRepository.GetById(id);
                return _modelMapper.Map<PayrolldeductionDto>(updatedRecord);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Task<PayrolldeductionDto> GetByName(string name)
        {
            throw new NotImplementedException();
        }
        public Task<bool> UploadEmployeeDeduction(List<PayrolldeductionDto> payrolldeductions)
        {
            try
            {
                return _payrollDeductionRepository.UploadEmployeeDeduction(
                    _modelMapper.Map<List<Payrolldeduction>>(payrolldeductions));
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw ex;
            }
        }

    }
}
