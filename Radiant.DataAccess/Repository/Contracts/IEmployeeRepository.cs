using Radiant.DataAccess.FilterModels;
using Radiant.DataAccess.Models;
using Radiant.DataAccess.Response;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Radiant.DataAccess.Repository.Contracts
{
    public interface IEmployeeRepository : IGenericRepository<Employee>
    {
        Task<List<Employee>> GetAll(bool status);
        Task<List<Employee>> GetAll(long? managerId, string employeeIds);
        Task Create(List<Employee> employees);
        Task<Employee> Edit(Employee employee, bool skipValidations, DateTime? effectiveDate);
        Task<EmployeeSearchResponse> Search(EmployeeSearch filterModel);
        Task<EmployeeLinesDashboardResponse> GetLineDashboardData(EmployeeLinesDashboardSearch filterModel);
        Task<List<DropdownValue>> GetEmployeesByRoleName(string roleName);
        Task<List<Employee>> GetEmployeesByShift(long shiftId);
        Task<bool> ChangePasswordByEmployeeId(long eId, string password);
        Task BulkEdit(EmployeeBulkEditModel bulkEditModel);
        Task UpdateDependencies(UpdateDependencyModel updateDependencyModel);
        List<Employee> GetNewEmployees(List<Employee> employees);
        Task Delete(EmployeeDeleteModel employeeDeleteModel);
        Task BulkDelete(EmployeeBulkDeleteModel bulkDeleteModel);
        Task Reactivate(BulkReactivateModel bulkReactivateModel);
        Task<List<EmployeeDropdownModel>> GetEmployeesByManager(long? managerId);
        Task<List<EmployeeDropdownModel>> Get3rdPartyEmployees(long? managerId);
        Task<List<DropdownValue>> GetManagersByDepartment(int? departmentId);

    }
}
