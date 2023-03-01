using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Radiant.DataAccess.FilterModels;
using Radiant.DataAccess.Models;
using Radiant.DataAccess.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Radiant.DataAccess.Repository
{
    public class EmployeeSkillRepository : IEmployeeSkillRepository
    {
        private readonly ILogger<Employeeskill> _logger;
        private readonly CustomRadiantDbContext _dbContext;

        public EmployeeSkillRepository(ILogger<Employeeskill> logger
            , CustomRadiantDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }
        public async Task<Employeeskill> Create(Employeeskill record)
        {
            await _dbContext.Employeeskill.AddAsync(record);
            await _dbContext.SaveChangesAsync();
            return record;
        }

        public async Task Delete(long id)
        {
            var EmployeeSkill = await GetById(id);
            EmployeeSkill.Isactive = false;
            _dbContext.Employeeskill.Update(EmployeeSkill);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Employeeskill> Edit(Employeeskill record)
        {
            _dbContext.Employeeskill.Update(record);
            await _dbContext.SaveChangesAsync();
            return record;
        }

        public async Task<List<Employeeskill>> GetAll()
        {
            return await _dbContext.Employeeskill.Where(x => x.Isactive == true)
                .OrderByDescending(c => c.CreatedOn)
                .AsNoTracking()
                .Include(es => es.Emp).ThenInclude(e => e.CurrentDepartment)
                 .Include(es => es.Emp).ThenInclude(e => e.Subdepartment)
                 .Include(es => es.Emp).ThenInclude(e => e.CurrentShift)
                .ToListAsync();
        }

        public async Task<Employeeskill> GetById(long id)
        {
            return await _dbContext.Employeeskill.FirstOrDefaultAsync(x => x.Isactive == true && x.Employeeskillid == id);
        }

        public async Task<List<UpsertEmpSkill>> PostEmpSkill(EmployeeSkillRequest employeeSkillRequest)
        {
            var command = _dbContext.UpsertEmpSkill.FromSqlRaw($@"select * from upsert_emp_skill(
                '{employeeSkillRequest.EmpId}',
                '{employeeSkillRequest.OperatorErrors}',
                '{employeeSkillRequest.LineLeaderRating}',
                '{employeeSkillRequest.SkillRating}'
                )");
            return await command.ToListAsync();
        }

        public async Task<List<EmployeeSkillMatrix>> GetEmployeeSkillMatrixByManagerId(EmployeeSkillSearch filterModel)
        {
            var command = _dbContext.EmployeeSkillMatrix.FromSqlRaw($@"select * from emp_skillmatrix(
                '{filterModel.ManagerId}',
                '{filterModel.RatingDate.ToString("yyyy-MM-dd")}',
                 {filterModel.Active}
                ) e order by e.empcode ");
            return await command.ToListAsync();
        }

        public async Task<List<EmpSkill>> GetEmployeeSkillMatrixByEmployeeId(long employeeId)
        {
            var command = _dbContext.EmpSkill.FromSqlRaw($@"select * from get_emp_skill(
                '{employeeId}'
                )");
            var empSkills = await command.ToListAsync();
            var employee = _dbContext.Employee
                .Include(e => e.CurrentShift)
                .Include(e => e.CurrentLine)
                .Include(e => e.CurrentDesignation).AsNoTracking().FirstOrDefault(e => e.Empid == employeeId);
            foreach (var emp in empSkills)
            {
                emp.Name = $"{employee.Firstname} {employee.Lastname}";
                emp.LineId = employee.CurrentLineid;
                emp.LineDescription = employee.CurrentLine?.Linedescription;
                emp.Shiftid = employee.CurrentShiftid;
                emp.Shiftdetails = employee.CurrentShift?.Shiftdetails;
                emp.DesignationId = employee.CurrentDesignationid;
                emp.DesignationDescription = employee.CurrentDesignation?.Designationdescription;
            }

            return empSkills;
        }

        public Task<Employeeskill> GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<List<EmployeeSkillSummaryModel>> GetSkillSummaryReport(long? departmentId, long? managerId, DateTime reportDate)
        {
            List<EmployeeSkillSummaryModel> employeeSkillSummaries = new List<EmployeeSkillSummaryModel>();
            var employees = await _dbContext.Employee
                 .Include(e => e.CurrentDepartment)
                 .Include(e => e.CurrentLine)
                 .Include(e => e.CurrentStage)
                 .Include(e => e.Subdepartment)
                 .Where(e => e.Dateofjoining.Date <= reportDate.Date && e.Dateofleaving.Date >= reportDate.Date && (!e.CurrentDepartmentid.HasValue 
            || e.CurrentDepartment.Departmentdescription.ToLower().Trim() == "production"
            || (e.CurrentDepartment.Departmentdescription.ToUpper().Trim() == "QUALITY" 
            && (!e.Subdepartmentid.HasValue 
            || e.Subdepartment.Departmentdescription.ToLower().Trim() == "pqc")
            )
            )
            && (!departmentId.HasValue || e.CurrentDepartmentid == departmentId)
            && (!managerId.HasValue || e.CurrentLinemanagerid == managerId))
               .AsNoTracking().ToListAsync();
            foreach (var emp in employees)
            {
                var empSkillSummary = new EmployeeSkillSummaryModel
                {
                    EmpId = emp.Empid,
                    EmpCode = emp.Empcode,
                    Name = $"{emp.Firstname} {emp.Lastname}",
                    DepartmentId = emp.CurrentDepartmentid,
                    Department = emp.CurrentDepartment?.Departmentdescription,
                    LineId = emp.CurrentLineid,
                    Line = emp.CurrentLine?.Linedescription,
                    StageId = emp.CurrentStageid,
                    Stage = emp.CurrentStage?.Stagedescription
                };

                var empSkills = await _dbContext.Employeeskill.Where(e => e.Isactive == true && e.Empid == emp.Empid && e.Ratingdate.Year == reportDate.Year).ToListAsync();
                foreach (var empSkill in empSkills)
                {
                    empSkillSummary.Ratings.Add(new RatingModel
                    {
                        RatingDate = empSkill.Ratingdate,
                        Rating = ((float)(5 * (2 * empSkill.Attendancescore.GetValueOrDefault()
                        + empSkill.Lineleaderscore.GetValueOrDefault()
                        + empSkill.Skillratingscore.GetValueOrDefault())) / 2)
                    });
                }

                employeeSkillSummaries.Add(empSkillSummary);
            }

            return employeeSkillSummaries.OrderBy(ess=>ess.EmpCode).ToList();
        }
    }
}
