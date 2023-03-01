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
    public class EmployeeRoleTrackerBusiness : IGenericBusiness<EmployeeRoleTrackerDto>
    {
        private readonly IGenericRepository<EmployeeRoleTracker> _employeeRoleTrackerRepository;
        private readonly ILogger<EmployeeRoleTrackerBusiness> _logger;
        private readonly IMapper _modelMapper;

        public EmployeeRoleTrackerBusiness(IGenericRepository<EmployeeRoleTracker> employeeRoleTrackerRepository
            , ILogger<EmployeeRoleTrackerBusiness> logger
            , IMapper modelMapper)
        {
            _employeeRoleTrackerRepository = employeeRoleTrackerRepository;
            _logger = logger;
            _modelMapper = modelMapper;
        }

        public async Task<EmployeeRoleTrackerDto> Create(EmployeeRoleTrackerDto item)
        {
            try
            {
                var employeeRoleTracker = _modelMapper.Map<EmployeeRoleTracker>(item);
                var createdRecord = await _employeeRoleTrackerRepository.Create(employeeRoleTracker);
                return _modelMapper.Map<EmployeeRoleTrackerDto>(createdRecord);
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
                await _employeeRoleTrackerRepository.Delete(id);
            }
            catch
            {
                throw;
            }
        }

        public async Task<EmployeeRoleTrackerDto> Edit(EmployeeRoleTrackerDto item)
        {
            try
            {
                var employeeRoleTracker = _modelMapper.Map<EmployeeRoleTracker>(item);
                var updatedRecord = await _employeeRoleTrackerRepository.Edit(employeeRoleTracker);
                return _modelMapper.Map<EmployeeRoleTrackerDto>(updatedRecord);
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<EmployeeRoleTrackerDto>> GetAll()
        {
            try
            {
                var employeeRoleTrackers = await _employeeRoleTrackerRepository.GetAll();
                return _modelMapper.Map<List<EmployeeRoleTrackerDto>>(employeeRoleTrackers);
            }
            catch
            {
                throw;
            }
        }

        public async Task<EmployeeRoleTrackerDto> GetById(long id)
        {
            try
            {
                var employeeRoleTracker = await _employeeRoleTrackerRepository.GetById(id);
                return _modelMapper.Map<EmployeeRoleTrackerDto>(employeeRoleTracker);
            }
            catch
            {
                throw;
            }
        }

        public Task<EmployeeRoleTrackerDto> GetByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}
