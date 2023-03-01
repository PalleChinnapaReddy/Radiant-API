using AutoMapper;
using Microsoft.Extensions.Logging;
using Radiant.Business.Contracts;
using Radiant.Business.Models;
using Radiant.Business.Models.FilterModels;
using Radiant.Business.Models.Response;
using Radiant.DataAccess.Models;
using Radiant.DataAccess.Models.Reports;
using Radiant.DataAccess.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Radiant.Business.CoreBusiness
{
    public class PayrollBusiness : IPayrollBusiness
    {
        private readonly IPayrollRepository _payrollRepository;
        private readonly ILogger<PayrollBusiness> _logger;
        private readonly IMapper _modelMapper;

        public PayrollBusiness(IPayrollRepository payrollRepository
            , ILogger<PayrollBusiness> logger
            , IMapper modelMapper)
        {
            _payrollRepository = payrollRepository;
            _logger = logger;
            _modelMapper = modelMapper;
        }
        public async Task<PayrollDto> Create(PayrollDto item)
        {
            try
            {
                var payroll = _modelMapper.Map<Payroll>(item);
                var createdRecord = await _payrollRepository.Create(payroll);
                return _modelMapper.Map<PayrollDto>(createdRecord);
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
                await _payrollRepository.Delete(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<PayrollDto> Edit(PayrollDto item)
        {
            try
            {
                var payroll = _modelMapper.Map<Payroll>(item);
                var updatedRecord = await _payrollRepository.Edit(payroll);
                return _modelMapper.Map<PayrollDto>(updatedRecord);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<PayrollDto>> GetAll()
        {
            try
            {
                var updatedRecord = await _payrollRepository.GetAll();
                return _modelMapper.Map<List<PayrollDto>>(updatedRecord);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<PayrollDto> GetById(long id)
        {
            try
            {
                var updatedRecord = await _payrollRepository.GetById(id);
                return _modelMapper.Map<PayrollDto>(updatedRecord);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Task<PayrollDto> GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<ConsolidationAttendanceResponseDto> GetConsolidatedAttendanceByMonth(ConsolidatedAttendanceByMonthFilterDto filter)
        {
            try
            {
                var mappedFilter = _modelMapper.Map<ConsolidatedAttendanceByMonthFilter>(filter);
                var consolidationAttendanceByMonths = await _payrollRepository.GetConsolidatedAttendanceByMonth(mappedFilter);
                return _modelMapper.Map<ConsolidationAttendanceResponseDto>(consolidationAttendanceByMonths);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<ConsolidationByMonthDto>> GetConsolidationByMonth(string contractorId)
        {
            try
            {
                var consolidationByMonths = await _payrollRepository.GetConsolidationByMonth(contractorId);
                return _modelMapper.Map<List<ConsolidationByMonthDto>>(consolidationByMonths);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<AttendancePayrollResponseDto> GetPayrollAttendance(AttendancePayrollFilterDto attendancePayrollFilterDto)
        {
            try
            {
                var payrollAttendance = await _payrollRepository.GetPayrollAttendance(_modelMapper.Map<AttendancePayrollFilter>(attendancePayrollFilterDto));
                return _modelMapper.Map<AttendancePayrollResponseDto>(payrollAttendance);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<PayrollResponseDto> GetReviewPayroll(PayrollFilterDto payrollFilter)
        {
            try
            {
                var payrollResponse = await _payrollRepository.GetReviewPayroll(_modelMapper.Map<PayrollFilter>(payrollFilter));
                return _modelMapper.Map<PayrollResponseDto>(payrollResponse);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
