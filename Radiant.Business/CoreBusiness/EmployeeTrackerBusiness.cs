using AutoMapper;
using Microsoft.Extensions.Logging;
using Radiant.Business.Contracts;
using Radiant.Business.Models;
using Radiant.Business.Models.CustomizedAPI;
using Radiant.DataAccess.Models;
using Radiant.DataAccess.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Radiant.Business.CoreBusiness
{
    public class EmployeeTrackerBusiness : IEmployeeTrackerBusiness
    {
        private readonly IEmployeeTrackerRepository _employeeTrackerRepository;
        private readonly ILogger<EmployeeTrackerBusiness> _logger;
        private readonly IMapper _modelMapper;

        public EmployeeTrackerBusiness(IEmployeeTrackerRepository employeeTrackerRepository
            , ILogger<EmployeeTrackerBusiness> logger
            , IMapper modelMapper)
        {
            _employeeTrackerRepository = employeeTrackerRepository;
            _logger = logger;
            _modelMapper = modelMapper;
        }

        public async Task<EmployeeTrackerDto> Create(EmployeeTrackerDto item)
        {
            try
            {
                var employeeTracker = _modelMapper.Map<EmployeeTracker>(item);
                var createdRecord = await _employeeTrackerRepository.Create(employeeTracker);
                return _modelMapper.Map<EmployeeTrackerDto>(createdRecord);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                throw ex;
            }
        }

        public async Task<List<EmployeeTrackerDto>> CreateAll(EmployeeShiftUpdate employeeShiftUpdate)
        {
            try
            {
                List<EmployeeTracker> employeeTrackers = new List<EmployeeTracker>();
                foreach (var emp in employeeShiftUpdate.Employees)
                {
                    EmployeeTracker employeeTrackerDto = new EmployeeTracker();
                    employeeTrackerDto.Empid = (long)Convert.ToDouble(emp);
                    employeeTrackerDto.Shiftid = employeeShiftUpdate.Shiftid;
                    employeeTrackerDto.Stageid = employeeShiftUpdate.Stageid;
                    employeeTrackerDto.Plantid = emp.CurrentPlantid;
                    employeeTrackerDto.Lineid = employeeShiftUpdate.Lineid;
                    employeeTrackerDto.Startdate = DateTime.Now;
                    employeeTrackerDto.Enddate = employeeShiftUpdate.isTemporary ? DateTime.Today.AddDays(1) : DateTime.Today.AddDays(365);
                    employeeTrackerDto.Contractorid = emp.CurrentContractorid;
                    employeeTrackerDto.Isactive = true;
                    employeeTrackers.Add(employeeTrackerDto);

                }

                var createdRecords = await _employeeTrackerRepository.CreateAll(employeeTrackers);
                return _modelMapper.Map<List<EmployeeTrackerDto>>(createdRecords);
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
                await _employeeTrackerRepository.Delete(id);
            }
            catch
            {
                throw;
            }
        }

        public async Task<EmployeeTrackerDto> Edit(EmployeeTrackerDto item)
        {
            try
            {
                var employeeTracker = _modelMapper.Map<EmployeeTracker>(item);
                var updatedRecord = await _employeeTrackerRepository.Edit(employeeTracker);
                return _modelMapper.Map<EmployeeTrackerDto>(updatedRecord);
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<EmployeeTrackerDto>> GetAll()
        {
            try
            {
                var employeeTrackers = await _employeeTrackerRepository.GetAll();
                return _modelMapper.Map<List<EmployeeTrackerDto>>(employeeTrackers);
            }
            catch
            {
                throw;
            }
        }

        public async Task<EmployeeTrackerDto> GetById(long id)
        {
            try
            {
                var employeeTracker = await _employeeTrackerRepository.GetById(id);
                return _modelMapper.Map<EmployeeTrackerDto>(employeeTracker);
            }
            catch
            {
                throw;
            }
        }

        public Task<EmployeeTrackerDto> GetByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}
