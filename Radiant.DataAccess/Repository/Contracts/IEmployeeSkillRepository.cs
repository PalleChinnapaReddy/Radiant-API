using Radiant.DataAccess.FilterModels;
using Radiant.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Radiant.DataAccess.Repository.Contracts
{
    public interface IEmployeeSkillRepository:IGenericRepository<Employeeskill>
    {
        Task<List<UpsertEmpSkill>> PostEmpSkill(EmployeeSkillRequest employeeSkillRequest);
        Task<List<EmployeeSkillMatrix>> GetEmployeeSkillMatrixByManagerId(EmployeeSkillSearch searchDto);
        Task<List<EmpSkill>> GetEmployeeSkillMatrixByEmployeeId(long employeeId);
        Task<List<EmployeeSkillSummaryModel>> GetSkillSummaryReport(long? departmentId, long? managerId, DateTime reportDate);
    }
}
