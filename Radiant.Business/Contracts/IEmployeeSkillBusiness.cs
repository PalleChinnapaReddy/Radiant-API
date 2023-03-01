using Radiant.Business.Models;
using Radiant.Business.Models.CustomizedAPI;
using Radiant.Business.Models.FilterModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Radiant.Business.Contracts
{
    public interface IEmployeeSkillBusiness:IGenericBusiness<EmployeeSkillDto>
    {
        Task<List<UpsertEmpSkillDto>> PostEmpSkill(EmployeeSkillRequestDto employeeSkillRequest);
        Task<List<EmployeeSkillMatrixDto>> GetEmployeeSkillMatrixByManagerId(EmployeeSkillSearchDto searchDto);
        Task<List<EmpSkillDto>> GetEmployeeSkillMatrixByEmployeeId(long employeeId);
        Task<List<EmployeeSkillSummaryDto>> GetSkillSummaryReport(long? departmentId, long? managerId, DateTime reportDate);
    }
}
