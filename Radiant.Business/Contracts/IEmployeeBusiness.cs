using Radiant.Business.Models;
using Radiant.Business.Models.CustomizedAPI;
using Radiant.Business.Models.FilterModels;
using Radiant.Business.Models.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Radiant.Business.Contracts
{
    public interface IEmployeeBusiness : IGenericBusiness<EmployeeDto>
    {
        Task<List<EmployeeDto>> GetAll(bool status);
        Task<List<EmployeeDto>> GetAll(long? managerId, string employeeIds);
        Task Edit(EmployeeDto employee, bool skipValidations);
        Task<EmployeeSearchResponseDto> Search(EmployeeSearchDto searchDto);
        Task<EmployeeLinesDashboardResponseDto> GetLineDashboardData(EmployeeLinesDashboardSearchDto searchDto);

        Task Create(List<EmployeeDto> item);

        Task<List<DropdownValueDto>> GetEmployeesByRoleName(string roleName);
        Task<List<DropdownValueDto>> GetManagersByDepartment(int? departmentId);

        Task<List<EmployeeDto>> GetEmployeesByShift(long shiftId);
        Task<bool> ChangePasswordByEmployeeId(long eId, string password);
        Task BulkEdit(EmployeeBulkEditDto bulkEditDto);
        Task UpdateDependencies(UpdateDependencyDto updateDependencyDto);
        List<EmployeeDto> GetNewEmployees(List<EmployeeDto> employees);
        Task Delete(EmployeeDeleteDto employeeDeleteDto);
        Task Delete(EmployeeBulkDeleteDto bulkDeleteDto);
        Task Reactivate(BulkReactivateDto bulkReactivateDto);
        Task<List<EmployeeDropdownDto>> GetEmployeesByManager(long? managerId);
        Task<List<EmployeeDropdownDto>> Get3rdPartyEmployees(long? managerId);
    }
}
