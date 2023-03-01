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
using System.Linq;
using System.Threading.Tasks;

namespace Radiant.Business.CoreBusiness
{
    public class EmployeeBusiness : IEmployeeBusiness
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ILogger<EmployeeBusiness> _logger;
        private readonly IMapper _modelMapper;

        public EmployeeBusiness(IEmployeeRepository employeeRepository
            , ILogger<EmployeeBusiness> logger
            , IMapper modelMapper)
        {
            _employeeRepository = employeeRepository;
            _logger = logger;
            _modelMapper = modelMapper;
        }

        public async Task<EmployeeDto> Create(EmployeeDto item)
        {
            try
            {
                var employee = _modelMapper.Map<Employee>(item);
                var createdRecord = await _employeeRepository.Create(employee);
                return _modelMapper.Map<EmployeeDto>(createdRecord);
            }
            catch
            {
                throw;
            }
        }

        public async Task Create(List<EmployeeDto> item)
        {
            try
            {
                var employees = _modelMapper.Map<List<Employee>>(item.Distinct().ToList());
                if (employees.Any())
                {
                    await _employeeRepository.Create(employees);
                }
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
                await _employeeRepository.Delete(id);
            }
            catch
            {
                throw;
            }
        }

        public async Task<EmployeeDto> Edit(EmployeeDto item)
        {
            try
            {
                var employee = _modelMapper.Map<Employee>(item);
                var updatedRecord = await _employeeRepository.Edit(employee);
                return _modelMapper.Map<EmployeeDto>(updatedRecord);
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<EmployeeDto>> GetAll()
        {
            try
            {
                var employees = await _employeeRepository.GetAll();
                return _modelMapper.Map<List<EmployeeDto>>(employees);
            }
            catch
            {
                throw;
            }
        }
        public async Task<List<EmployeeDto>> GetAll(bool status)
        {
            try
            {
                var employees = await _employeeRepository.GetAll(status);
                return _modelMapper.Map<List<EmployeeDto>>(employees);
            }
            catch
            {
                throw;
            }
        }

        public async Task<EmployeeDto> GetById(long id)
        {
            try
            {
                var employee = await _employeeRepository.GetById(id);
                return _modelMapper.Map<EmployeeDto>(employee);
            }
            catch
            {
                throw;
            }
        }

        public async Task<EmployeeDto> GetByName(string name)
        {
            try
            {
                var employee = await _employeeRepository.GetByName(name);
                return _modelMapper.Map<EmployeeDto>(employee);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<EmployeeSearchResponseDto> Search(EmployeeSearchDto searchDto)
        {
            try
            {
                var searchModel = _modelMapper.Map<EmployeeSearch>(searchDto);
                var employeeSearchResponse = await _employeeRepository.Search(searchModel);
                return _modelMapper.Map<EmployeeSearchResponseDto>(employeeSearchResponse);
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<DropdownValueDto>> GetEmployeesByRoleName(string roleName)
        {
            try
            {
                var employees = await _employeeRepository.GetEmployeesByRoleName(roleName);
                return _modelMapper.Map<List<DropdownValueDto>>(employees);
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<DropdownValueDto>> GetManagersByDepartment(int? departmentId)
        {
            try
            {
                var employees = await _employeeRepository.GetManagersByDepartment(departmentId);
                return _modelMapper.Map<List<DropdownValueDto>>(employees);
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<EmployeeDto>> GetEmployeesByShift(long shiftId)
        {
            try
            {
                var employees = await _employeeRepository.GetEmployeesByShift(shiftId);
                return _modelMapper.Map<List<EmployeeDto>>(employees);
            }
            catch
            {
                throw;
            }
        }
        public async Task<bool> ChangePasswordByEmployeeId(long eId, string password)
        {
            try
            {
                var status = await _employeeRepository.ChangePasswordByEmployeeId(eId, password);
                return status;
            }
            catch
            {
                throw;
            }
        }

        public async Task<EmployeeLinesDashboardResponseDto> GetLineDashboardData(EmployeeLinesDashboardSearchDto searchDto)
        {
            try
            {
                var searchModel = _modelMapper.Map<EmployeeLinesDashboardSearch>(searchDto);
                var employeeData = await _employeeRepository.GetLineDashboardData(searchModel);
                return _modelMapper.Map<EmployeeLinesDashboardResponseDto>(employeeData);
            }
            catch
            {
                throw;
            }
        }

        public async Task BulkEdit(EmployeeBulkEditDto bulkEditDto)
        {
            try
            {
                var bulkEditModel = _modelMapper.Map<EmployeeBulkEditModel>(bulkEditDto);
                await _employeeRepository.BulkEdit(bulkEditModel);
            }
            catch
            {
                throw;
            }
        }

        public async Task UpdateDependencies(UpdateDependencyDto updateDependencyDto)
        {
            try
            {
                var updateDependencyModel = _modelMapper.Map<UpdateDependencyModel>(updateDependencyDto);
                await _employeeRepository.UpdateDependencies(updateDependencyModel);
            }
            catch
            {
                throw;
            }
        }

        public List<EmployeeDto> GetNewEmployees(List<EmployeeDto> employeeDtos)
        {
            try
            {
                var employees = _modelMapper.Map<List<Employee>>(employeeDtos);
                var filteredEmployeeDtos = _employeeRepository.GetNewEmployees(employees);
                if (filteredEmployeeDtos != null && filteredEmployeeDtos.Count != 0)
                {
                    return _modelMapper.Map<List<EmployeeDto>>(filteredEmployeeDtos);
                }

                return null;
            }
            catch
            {
                throw;
            }
        }

        public async Task Edit(EmployeeDto employeeDto, bool skipValidations)
        {
            try
            {
                var employee = _modelMapper.Map<Employee>(employeeDto);
                await _employeeRepository.Edit(employee, skipValidations, default(DateTime?));
            }
            catch
            {
                throw;
            }
        }

        public async Task Delete(EmployeeDeleteDto employeeDeleteDto)
        {
            try
            {
                var employee = _modelMapper.Map<EmployeeDeleteModel>(employeeDeleteDto);
                await _employeeRepository.Delete(employee);
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<EmployeeDto>> GetAll(long? managerId, string employeeIds)
        {
            try
            {
                var employees = await _employeeRepository.GetAll(managerId, employeeIds);
                return _modelMapper.Map<List<EmployeeDto>>(employees);
            }
            catch
            {
                throw;
            }
        }

        public async Task Delete(EmployeeBulkDeleteDto bulkDeleteDto)
        {
            try
            {
                var employee = _modelMapper.Map<EmployeeBulkDeleteModel>(bulkDeleteDto);
                await _employeeRepository.BulkDelete(employee);
            }
            catch(Exception ex)
            {
                throw ex;
            }

        }

        public async Task Reactivate(BulkReactivateDto bulkReactivateDto)
        {
            try
            {
                var bulkReactivateModel = _modelMapper.Map<BulkReactivateModel>(bulkReactivateDto);
                await _employeeRepository.Reactivate(bulkReactivateModel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<EmployeeDropdownDto>> GetEmployeesByManager(long? managerId)
        {
            try
            {
                var employees = await _employeeRepository.GetEmployeesByManager(managerId);
                return _modelMapper.Map<List<EmployeeDropdownDto>>(employees);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<List<EmployeeDropdownDto>> Get3rdPartyEmployees(long? managerId)
        {
            try
            {
                var employees = await _employeeRepository.Get3rdPartyEmployees(managerId);
                return _modelMapper.Map<List<EmployeeDropdownDto>>(employees);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
