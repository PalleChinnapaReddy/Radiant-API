using AutoMapper;
using Microsoft.Extensions.Logging;
using Radiant.Business.Contracts;
using Radiant.Business.Models;
using Radiant.Business.Models.CustomizedAPI;
using Radiant.Business.Models.FilterModels;
using Radiant.Business.Models.Response;
using Radiant.DataAccess.FilterModels;
using Radiant.DataAccess.Models;
using Radiant.DataAccess.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Radiant.Business.CoreBusiness
{
    public class EmployeeAttendanceBusiness : IEmployeeAttendanceBusiness
    {
        private readonly IEmployeeAttendanceRepository _employeeAttendanceRepository;
        private readonly ILogger<EmployeeAttendanceBusiness> _logger;
        private readonly IMapper _modelMapper;

        public EmployeeAttendanceBusiness(IEmployeeAttendanceRepository employeeAttendanceRepository
            , ILogger<EmployeeAttendanceBusiness> logger
            , IMapper modelMapper)
        {
            _employeeAttendanceRepository = employeeAttendanceRepository;
            _logger = logger;
            _modelMapper = modelMapper;
        }

        public async Task<EmployeeAttendanceDto> Create(EmployeeAttendanceDto item)
        {
            try
            {
                var employeeAttendance = _modelMapper.Map<EmployeeAttendance>(item);
                var createdRecord = await _employeeAttendanceRepository.Create(employeeAttendance);
                return _modelMapper.Map<EmployeeAttendanceDto>(createdRecord);
            }
            catch
            {
                throw;
            }
        }

        public Task Create(List<EmployeeDto> item)
        {
            throw new NotImplementedException();
        }

        public async Task Delete(long id)
        {
            try
            {
                await _employeeAttendanceRepository.Delete(id);
            }
            catch
            {
                throw;
            }
        }

        public async Task<EmployeeAttendanceDto> Edit(EmployeeAttendanceDto item)
        {
            try
            {
                var employeeAttendance = _modelMapper.Map<EmployeeAttendance>(item);
                var updatedRecord = await _employeeAttendanceRepository.Edit(employeeAttendance);
                return _modelMapper.Map<EmployeeAttendanceDto>(updatedRecord);
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<EmployeeAttendanceDto>> GetAll()
        {
            try
            {
                var employeeAttendances = await _employeeAttendanceRepository.GetAll();
                return _modelMapper.Map<List<EmployeeAttendanceDto>>(employeeAttendances);
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<DayAttendanceReportDto>> GetAttendanceReports(string shift, DateTime date)
        {
            try
            {
                var employeeAttendances = await _employeeAttendanceRepository.GetAttendanceReports(shift,date);
                return _modelMapper.Map<List<DayAttendanceReportDto>>(employeeAttendances);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<EmployeeAttendanceDto> GetById(long id)
        {
            try
            {
                var employeeAttendance = await _employeeAttendanceRepository.GetById(id);
                return _modelMapper.Map<EmployeeAttendanceDto>(employeeAttendance);
            }
            catch
            {
                throw;
            }
        }

        public Task<EmployeeAttendanceDto> GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<EmployeeAttendanceResponseDto> GetEmployeeAttendanceByManager(EmployeeAttendanceSearchDto searchDto)
        {
            try
            {
                var filterModel = _modelMapper.Map< EmployeeAttendanceSearch>(searchDto);
                var employeeAttendances = await _employeeAttendanceRepository.GetEmployeeAttendanceByManager(filterModel);
                return _modelMapper.Map<EmployeeAttendanceResponseDto>(employeeAttendances);
            }
            catch
            {
                throw;
            }
        }

        public async Task<SelectedEmployeeDetailsDto> GetSelectedEmployeeDetails(int id)
        {
            try
            {
                var selectedEmployeeDetails = await _employeeAttendanceRepository.GetSelectedEmployeeDetails(id);
                return _modelMapper.Map<SelectedEmployeeDetailsDto>(selectedEmployeeDetails);
            }
            catch
            {
                throw;
            }
        }
    }
}
