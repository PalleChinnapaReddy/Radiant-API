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
    public class EmployeeSalaryBusiness : IGenericBusiness<EmployeeSalaryDto>
    {
        private readonly IGenericRepository<Employeesalary> _employeeSalaryRepository;
        private readonly ILogger<EmployeeSalaryBusiness> _logger;
        private readonly IMapper _modelMapper;

        public EmployeeSalaryBusiness(IGenericRepository<Employeesalary> employeeSalaryRepository
            , ILogger<EmployeeSalaryBusiness> logger
            , IMapper modelMapper)
        {
            _employeeSalaryRepository = employeeSalaryRepository;
            _logger = logger;
            _modelMapper = modelMapper;
        }

        public async Task<EmployeeSalaryDto> Create(EmployeeSalaryDto item)
        {
            try
            {
                var employeeSalary = _modelMapper.Map<Employeesalary>(item);
                var createdRecord = await _employeeSalaryRepository.Create(employeeSalary);
                return _modelMapper.Map<EmployeeSalaryDto>(createdRecord);
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
                await _employeeSalaryRepository.Delete(id);
            }
            catch
            {
                throw;
            }
        }

        public async Task<EmployeeSalaryDto> Edit(EmployeeSalaryDto item)
        {
            try
            {
                var employeeSalary = _modelMapper.Map<Employeesalary>(item);
                var updatedRecord = await _employeeSalaryRepository.Edit(employeeSalary);
                return _modelMapper.Map<EmployeeSalaryDto>(updatedRecord);
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<EmployeeSalaryDto>> GetAll()
        {
            try
            {
                var employeeSalaries = await _employeeSalaryRepository.GetAll();
                return _modelMapper.Map<List<EmployeeSalaryDto>>(employeeSalaries);
            }
            catch
            {
                throw;
            }
        }

        public async Task<EmployeeSalaryDto> GetById(long id)
        {
            try
            {
                var employeeSalary = await _employeeSalaryRepository.GetById(id);
                return _modelMapper.Map<EmployeeSalaryDto>(employeeSalary);
            }
            catch
            {
                throw;
            }
        }

        public Task<EmployeeSalaryDto> GetByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}
