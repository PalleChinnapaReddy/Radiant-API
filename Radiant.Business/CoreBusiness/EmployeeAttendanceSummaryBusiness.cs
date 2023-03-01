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
    public class EmployeeAttendanceSummaryBusiness : IGenericBusiness<EmployeeAttendanceSummaryDto>
    {
        private readonly IGenericRepository<EmployeeAttendanceSummary> _employeeAttendanceSummaryRepository;
        private readonly ILogger<EmployeeAttendanceSummaryBusiness> _logger;
        private readonly IMapper _modelMapper;

        public EmployeeAttendanceSummaryBusiness(IGenericRepository<EmployeeAttendanceSummary> employeeAttendanceSummaryRepository
            , ILogger<EmployeeAttendanceSummaryBusiness> logger
            , IMapper modelMapper)
        {
            _employeeAttendanceSummaryRepository = employeeAttendanceSummaryRepository;
            _logger = logger;
            _modelMapper = modelMapper;
        }

        public async Task<EmployeeAttendanceSummaryDto> Create(EmployeeAttendanceSummaryDto item)
        {
            try
            {
                var employeeAttendanceSummary = _modelMapper.Map<EmployeeAttendanceSummary>(item);
                var createdRecord = await _employeeAttendanceSummaryRepository.Create(employeeAttendanceSummary);
                return _modelMapper.Map<EmployeeAttendanceSummaryDto>(createdRecord);
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
                await _employeeAttendanceSummaryRepository.Delete(id);
            }
            catch
            {
                throw;
            }
        }

        public async Task<EmployeeAttendanceSummaryDto> Edit(EmployeeAttendanceSummaryDto item)
        {
            try
            {
                var employeeAttendanceSummary = _modelMapper.Map<EmployeeAttendanceSummary>(item);
                var updatedRecord = await _employeeAttendanceSummaryRepository.Edit(employeeAttendanceSummary);
                return _modelMapper.Map<EmployeeAttendanceSummaryDto>(updatedRecord);
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<EmployeeAttendanceSummaryDto>> GetAll()
        {
            try
            {
                var employeeAttendanceSummaryies = await _employeeAttendanceSummaryRepository.GetAll();
                return _modelMapper.Map<List<EmployeeAttendanceSummaryDto>>(employeeAttendanceSummaryies);
            }
            catch
            {
                throw;
            }
        }

        public async Task<EmployeeAttendanceSummaryDto> GetById(long id)
        {
            try
            {
                var employeeAttendanceSummary = await _employeeAttendanceSummaryRepository.GetById(id);
                return _modelMapper.Map<EmployeeAttendanceSummaryDto>(employeeAttendanceSummary);
            }
            catch
            {
                throw;
            }
        }

        public Task<EmployeeAttendanceSummaryDto> GetByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}
