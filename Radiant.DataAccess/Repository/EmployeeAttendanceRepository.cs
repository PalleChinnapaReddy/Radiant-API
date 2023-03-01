using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Radiant.DataAccess.FilterModels;
using Radiant.DataAccess.Models;
using Radiant.DataAccess.Repository.Contracts;
using Radiant.DataAccess.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Radiant.DataAccess.Repository
{
    public class EmployeeAttendanceRepository : IEmployeeAttendanceRepository
    {
        private readonly ILogger<EmployeeAttendance> _logger;
        private readonly CustomRadiantDbContext _dbContext;

        public EmployeeAttendanceRepository(ILogger<EmployeeAttendance> logger
            , CustomRadiantDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public async Task<EmployeeAttendance> Create(EmployeeAttendance record)
        {
            if (record.Ispresent == true)
            {
                record.AttendanceOtApproval.Add(new AttendanceOtApproval());
                record.Ispresent = default(bool?);
                var employeeAttendances = await _dbContext.EmployeeAttendance.Where(ea => ea.Empid == record.Empid && record.Checkintime <= ea.Checkintime
                && ea.Checkintime <= record.Checkouttime).ToListAsync();
                if (employeeAttendances != null && employeeAttendances.Any())
                {
                    foreach (var employeeAttendance in employeeAttendances)
                    {
                        employeeAttendance.Ispresent = default(bool?);
                        _dbContext.EmployeeAttendance.Update(employeeAttendance);
                    }
                }
            }
            else
            {
                var empAttendance = _dbContext.EmployeeAttendance.FirstOrDefault(ea => ea.Empid == record.Empid && ea.Attendancedate == record.Attendancedate);
                if (empAttendance != null)
                {
                    empAttendance.Ispresent = default(bool?);
                    _dbContext.EmployeeAttendance.Update(empAttendance);
                }
            }

            await _dbContext.EmployeeAttendance.AddAsync(record);
            await _dbContext.SaveChangesAsync();
            return record;
        }

        public async Task Delete(long id)
        {
            var employeeAttendance = await GetById(id);
            _dbContext.EmployeeAttendance.Remove(employeeAttendance);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<EmployeeAttendance> Edit(EmployeeAttendance record)
        {
           

            _dbContext.EmployeeAttendance.Update(record);
            await _dbContext.SaveChangesAsync();
            return record;
        }

        public async Task<List<EmployeeAttendance>> GetAll()
        {
            return await _dbContext.EmployeeAttendance.AsNoTracking()
                 .Include((ea) => ea.Absencereason)
                .Include((ea) => ea.AttendanceType)
                .Include((ea) => ea.Emp).ThenInclude(e => e.CurrentDepartment)
                .Include((ea) => ea.Emp).ThenInclude(e => e.Subdepartment)
                .Include((ea) => ea.Emp).ThenInclude(e => e.CurrentLine)
                .Include((ea) => ea.Emp).ThenInclude(e => e.CurrentStage)
                .Include((ea) => ea.Emp).ThenInclude(e => e.CurrentDepartment)
                .Include((ea) => ea.Shift)
                .Include((ea) => ea.Stage)
                .OrderByDescending(c => c.CreatedOn)
                .ToListAsync();
        }

        public async Task<List<DayAttendanceReport>> GetAttendanceReports(string shift, DateTime date)
        {
            var command = _dbContext.DayAttendanceReport.FromSqlRaw($@"
            SELECT * from public.currentdayattendancereport('{shift}','{date.ToString("yyyy-MM-dd")}')");
            return await command.ToListAsync();
        }

        public async Task<EmployeeAttendance> GetById(long id)
        {
            return await _dbContext.EmployeeAttendance.AsNoTracking()
                 .Include((ea) => ea.Absencereason)
                .Include((ea) => ea.AttendanceType)
                .Include((ea) => ea.Emp).ThenInclude(e => e.CurrentDepartment)
                .Include((ea) => ea.Emp).ThenInclude(e => e.Subdepartment)
                .Include((ea) => ea.Emp).ThenInclude(e => e.CurrentLine)
                .Include((ea) => ea.Emp).ThenInclude(e => e.CurrentStage)
                .Include((ea) => ea.Emp).ThenInclude(e => e.CurrentDepartment)
                .Include((ea) => ea.Shift)
                .Include((ea) => ea.Stage)
                .FirstOrDefaultAsync(x => x.Employeeattendanceid == id);
        }

        public Task<EmployeeAttendance> GetByName(string name)
        {
            throw new System.NotImplementedException();
        }

        public async Task<EmployeeAttendanceResponse> GetEmployeeAttendanceByManager(EmployeeAttendanceSearch filterModel)
        {
            var filteredRows = _dbContext.EmployeeAttendance.AsNoTracking().Where(e =>
            (!filterModel.ManagerId.HasValue || e.Emp.CurrentLinemanagerid == filterModel.ManagerId)
            && ((!filterModel.IsActive && !e.Emp.EmployeeTracker.Any(r => r.Startdate <= e.Attendancedate && r.Enddate >= e.Attendancedate))
            || ((filterModel.IsActive && e.Emp.EmployeeTracker.Any(r => r.Startdate <= e.Attendancedate && (!filterModel.ShiftId.HasValue || r.Shiftid == filterModel.ShiftId)
            && r.Enddate >= e.Attendancedate))))
            && e.Ispresent.HasValue && (!filterModel.IsPresent.HasValue || e.Ispresent == filterModel.IsPresent)
                && e.Attendancedate >= filterModel.StartDate && e.Attendancedate <= filterModel.EndDate)
                .OrderBy(e => e.Emp.Empcode).ThenBy(e => e.Attendancedate);
            return new EmployeeAttendanceResponse
            {
                TotalRows = filteredRows.Count(),
                Data = await filteredRows.Skip((filterModel.PageNumber) * filterModel.PageSize).Take(filterModel.PageSize).AsNoTracking()
                .Include((ea) => ea.Absencereason)
                .Include((ea) => ea.AttendanceType)
                .Include((ea) => ea.Emp).ThenInclude(e => e.CurrentDepartment)
                .Include((ea) => ea.Emp).ThenInclude(e => e.Subdepartment)
                .Include((ea) => ea.Emp).ThenInclude(e => e.CurrentLine)
                .Include((ea) => ea.Emp).ThenInclude(e => e.CurrentStage)
                .Include((ea) => ea.Emp).ThenInclude(e => e.CurrentContractor)
                .Include((ea) => ea.Shift)
                .Include((ea) => ea.Stage)
                .ToListAsync()
            };
        }

        public async Task<SelectedEmployeeDetails> GetSelectedEmployeeDetails(int id)
        {
            var employee = _dbContext.Employee.Where(e => e.Empid == id && e.Isactive == true).
                Include(e => e.CurrentDepartment)
                .Include(e => e.Subdepartment)
                .Include(e => e.CurrentLine)
                .Include(e => e.CurrentStage)
                .Include(e => e.EmployeeAttendance)
                .Include(e => e.Employeedocuments).AsNoTracking().FirstOrDefault();
            DateTime prevMonthStartDate = DateTime.Now.AddMonths(-1).AddDays(-DateTime.Now.Day + 1);
            DateTime prevMonthEndDate = DateTime.Now.AddDays(-DateTime.Now.Day);
            var employeeSkills = await _dbContext.Employeeskill.Where(e => e.Empid == id && e.Isactive == true).ToListAsync();
            var empImage = _dbContext.Attachments.FirstOrDefault(a => a.Attachmentfor == "Employee"
             && a.Attachmentsdetails == "Photo");
            var previousMonthSkill = employeeSkills.FirstOrDefault(s => s.Isactive == true
                && prevMonthStartDate <= s.Ratingdate && s.Ratingdate <= prevMonthEndDate);
            double? previousMonthSkillRating = default(double?);
            if (previousMonthSkill != null)
            {
                previousMonthSkillRating = ((float)(5 * (2 * previousMonthSkill.Attendancescore.GetValueOrDefault()
                       + previousMonthSkill.Lineleaderscore.GetValueOrDefault()
                       + previousMonthSkill.Skillratingscore.GetValueOrDefault())) / 2);
            }
            return new SelectedEmployeeDetails
            {
                Name = $"{employee.Firstname} {employee.Lastname}",
                DepartmentId = employee.CurrentDepartmentid,
                Department = employee.CurrentDepartment?.Departmentdescription,
                SubDepartmentId = employee.Subdepartmentid,
                SubDepartment = employee.Subdepartment?.Departmentdescription,
                LineId = employee.CurrentLineid,
                Line = employee.CurrentLine?.Linedescription,
                StageId = employee.CurrentStageid,
                Stage = employee.CurrentStage?.Stagedescription,
                DOJ = employee.Dateofjoining,
                NoOfDaysPresent = employee.EmployeeAttendance.Where(a => a.Ispresent == true &&
                prevMonthStartDate.AddDays(24) <= a.Attendancedate.GetValueOrDefault() && a.Attendancedate.GetValueOrDefault() < prevMonthEndDate.AddDays(25)).Count(),
                PreviousMonthRating = previousMonthSkillRating,
                IsCurrentMonthRatingExists = employeeSkills.Any(s => s.Isactive == true && s.Ratingdate > prevMonthEndDate),
                ImagePath = employee.Employeedocuments.FirstOrDefault(e => e.Isactive == true && e.Attachmentid == empImage.Attachmentsid)?.Employeedocuments1[0]
            };
        }
    }
}
