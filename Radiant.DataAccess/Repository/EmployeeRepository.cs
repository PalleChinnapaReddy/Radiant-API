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
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ILogger<Employee> _logger;
        private readonly CustomRadiantDbContext _dbContext;

        public EmployeeRepository(ILogger<Employee> logger
            , CustomRadiantDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public async Task<Employee> Create(Employee record)
        {
            record = await MapEmployeeRelations(record, true);
            await _dbContext.Employee.AddAsync(record);
            await _dbContext.SaveChangesAsync();
            return record;
        }

        private async Task<Employee> MapEmployeeRelations(Employee record, Boolean isActive, DateTime? effectiveDate = default(DateTime?))
        {
            Employee employee = await GetEmployeeById(record.Empid);
            var currentDateTime = DateTime.Now;
            if (effectiveDate.HasValue)
            {
                currentDateTime = effectiveDate.Value;
            }

            record.UpdatedOn = currentDateTime;

            if (employee != null)
            {
                record.Password = employee.Password;
            }
            if (isActive)
            {
                var recordSalary = record.Employeesalary?.FirstOrDefault()?.Gross;
                if (recordSalary.HasValue)
                {
                    var command = _dbContext.UpsertEmpSalary.FromSqlRaw($@"
                        select * from public.upsert_emp_sal(
                        '{record.Empid}',
	                    false,
	                    '{recordSalary}')");
                    await command.ToListAsync();
                }

                if (employee == null 
                || employee.CurrentLineid != record.CurrentLineid
                || employee.CurrentStageid != record.CurrentStageid
                || employee.CurrentShiftid != record.CurrentShiftid
                || employee.CurrentContractorid != record.CurrentContractorid
                || employee.CurrentPlantid != record.CurrentPlantid
                || employee.Isactive != record.Isactive)
                {
                    if (employee != null)
                    {
                        if (employee.Isactive == true)
                        {
                            var empTrackers = employee.EmployeeTracker.Where(e => e.Isactive == true).ToList();
                            record.EmployeeTracker.Clear();
                            empTrackers.ForEach((e) =>
                            {
                                e.Isactive = false;
                                e.Enddate = currentDateTime.AddDays(-1).Date;
                                e.UpdatedOn = currentDateTime;
                                e.UpdatedBy = record.UpdatedBy;
                                record.EmployeeTracker.Add(e);
                            });
                        }
                        else
                        {
                            var empTracker = employee.EmployeeTracker.Where(e => e.Isactive == false).OrderByDescending(c => c.Emptrackerid).LastOrDefault();
                            record.EmployeeTracker.Clear();
                            if (empTracker.Enddate.Date == DateTime.Now.Date)
                            {
                                empTracker.Enddate = currentDateTime.AddDays(-1).Date;
                            }
                            record.EmployeeTracker.Add(empTracker);

                        }
                    }

                    EmployeeTracker employeeTracker = new EmployeeTracker();
                    employeeTracker.Contractorid = record.CurrentContractorid;
                    employeeTracker.Empid = record.Empid;
                    employeeTracker.Lineid = record.CurrentLineid;
                    employeeTracker.Stageid = record.CurrentStageid;
                    employeeTracker.Shiftid = record.CurrentShiftid;
                    employeeTracker.Plantid = record.CurrentPlantid;
                    employeeTracker.Startdate = currentDateTime.Date;
                    employeeTracker.CreatedOn = currentDateTime;
                    employeeTracker.CreatedBy = record.UpdatedBy;
                    employeeTracker.UpdatedOn = currentDateTime;
                    employeeTracker.UpdatedBy = record.UpdatedBy;
                    record.EmployeeTracker.Add(employeeTracker);
                }
                if (employee == null
                    || employee.CurrentRoleid != record.CurrentRoleid
                    || employee.CurrentDepartmentid != record.CurrentDepartmentid 
                    || employee.Subdepartmentid != record.Subdepartmentid
                    || employee.Ildl != record.Ildl
                    || employee.Isactive != record.Isactive)
                {
                    if (employee != null)
                    {
                        if (employee.Isactive == true)
                        {
                            var empRoleTrackers = employee.EmployeeRoleTracker.Where(e => e.Isactive == true).ToList();
                            record.EmployeeRoleTracker.Clear();
                            empRoleTrackers.ForEach((e) =>
                            {
                                e.Isactive = false;
                                e.Enddate = currentDateTime.AddDays(-1).Date;
                                e.UpdatedOn = currentDateTime;
                                e.UpdatedBy = record.UpdatedBy;
                                record.EmployeeRoleTracker.Add(e);
                            });
                        }
                        else
                        {
                            var empRoleTracker = employee.EmployeeRoleTracker.Where(e => e.Isactive == false).OrderByDescending(c => c.Emproletrackerid).LastOrDefault();
                            record.EmployeeRoleTracker.Clear();
                            if (empRoleTracker.Enddate.Date == DateTime.Now.Date)
                            {
                                empRoleTracker.Enddate = currentDateTime.AddDays(-1).Date;
                            }
                            record.EmployeeRoleTracker.Add(empRoleTracker);

                        }
                    }
                    EmployeeRoleTracker employeeRoleTracker = new EmployeeRoleTracker();
                    employeeRoleTracker.Roleid = record.CurrentRoleid;
                    employeeRoleTracker.Empid = record.Empid;
                    employeeRoleTracker.Departmentid = record.CurrentDepartmentid;
                    employeeRoleTracker.Subdepartmentid = record.Subdepartmentid;
                    employeeRoleTracker.Ildl = record.Ildl;
                    employeeRoleTracker.Startdate = currentDateTime.Date;
                    employeeRoleTracker.CreatedOn = currentDateTime;
                    employeeRoleTracker.CreatedBy = record.UpdatedBy;
                    employeeRoleTracker.UpdatedOn = currentDateTime;
                    employeeRoleTracker.UpdatedBy = record.UpdatedBy;
                    record.EmployeeRoleTracker.Add(employeeRoleTracker);
                }
                record.Dateofleaving = DateTime.MaxValue.Date;
                return record;
            }
            else
            {
                employee.Isactive = false;
                employee.Dateofleaving = record.Dateofleaving.Date;
                employee.LeavingReason = record.LeavingReason;
                employee.CommentsOnEmployeeReliving = record.CommentsOnEmployeeReliving;
                employee.IsEligibleForRehire = record.IsEligibleForRehire;
                var empTrackers = employee.EmployeeTracker.Where(e => e.Isactive == true).ToList();
                empTrackers.ForEach((empTracker) =>
                {
                    empTracker.Isactive = false;
                    empTracker.Enddate = record.Dateofleaving.Date;
                    empTracker.UpdatedOn = currentDateTime;
                    empTracker.UpdatedBy = record.UpdatedBy;
                });
                employee.EmployeeTracker = empTrackers;
                var employeeRoleTrackers = employee.EmployeeRoleTracker.Where(e => e.Isactive == true).ToList();
                employeeRoleTrackers.ForEach((empTracker) =>
                {
                    empTracker.Isactive = false;
                    empTracker.Enddate = record.Dateofleaving.Date;
                    empTracker.UpdatedOn = currentDateTime;
                    empTracker.UpdatedBy = record.UpdatedBy;
                });
                employee.EmployeeRoleTracker = employeeRoleTrackers;
                var employeeDocuments = employee.Employeedocuments.Where(e => e.Isactive == true).ToList();
                employeeDocuments.ForEach((empDoc) =>
                {
                    empDoc.Isactive = false;
                    empDoc.UpdatedOn = currentDateTime;
                    empDoc.UpdatedBy = record.UpdatedBy;
                });
                employee.Employeedocuments = employeeDocuments;
                var employeesalaries = employee.Employeesalary.Where(e => e.Isactive == true).ToList();
                employeesalaries.ForEach((empDoc) =>
                {
                    empDoc.Isactive = false;
                    empDoc.UpdatedOn = currentDateTime;
                    empDoc.UpdatedBy = record.UpdatedBy;
                });
                employee.Employeesalary = employeesalaries;
                return employee;
            }

        }

        public async Task Delete(long id)
        {
            var record = new Employee();
            record.Empid = id;
            var employee = await MapEmployeeRelations(record, false);

            _dbContext.Employee.Update(employee);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Employee> Edit(Employee record)
        {
            return await Edit(record, false, default(DateTime?));
        }

        public async Task<Employee> Edit(Employee record, bool skipValidations, DateTime? effectiveDate)
        {
            if (!skipValidations)
            {
                var emp = await GetByName(record.Phonenumber);
                if (emp != null && record.Empid != emp.Empid)
                {
                    //throw new Exception("Duplicate Phone Number "+emp.Empcode);
                    throw new Exception("Duplicate Phone Number ");
                }

                var ssn = await GetBySSN(record.Ssn, record.Empid);
                if (ssn != null && record.Empid != ssn.Empid)
                {
                    //throw new Exception("Duplicate SSN " +ssn.Empcode);
                    throw new Exception("Duplicate SSN ");
                }
            }

            record = record.Isactive.HasValue && record.Isactive == true ? await MapEmployeeRelations(record, true, effectiveDate) : await MapEmployeeRelations(record, false);
            record.Employeesalary.Clear();
            _dbContext.Employee.Update(record);
            await _dbContext.SaveChangesAsync();
            return record;
        }

        public async Task<List<Employee>> GetAll()
        {
            return await _dbContext.Employee.Where(e => e.Isactive == true).AsNoTracking()
                .Include((e) => e.Presentcity)
                .Include((e) => e.CurrentContractor)
                .Include((e) => e.CurrentDepartment)
                .Include((e) => e.CurrentShift)
                .Include((e) => e.CurrentStage)
                .Include((e) => e.CurrentLine)
                .Include((e) => e.CurrentRole)
                .Include((e) => e.Education)
                .Include((e) => e.Gender)
                .Include((e) => e.Ssntype)
                .Include((e) => e.CurrentLinemanager)
                .Include((e) => e.CurrentStagemanager)
                .Include((e) => e.CurrentPlant)
                .Include((e) => e.Subdepartment)
                .Include((e) => e.Employeesalary)
                .ToListAsync();
        }
        public async Task<List<Employee>> GetAll(bool status)
        {
            return await _dbContext.Employee.Where(e => e.Isactive == status).AsNoTracking()
               .Include((e) => e.Presentcity)
               .Include((e) => e.CurrentContractor)
               .Include((e) => e.CurrentDepartment)
               .Include((e) => e.CurrentShift)
               .Include((e) => e.CurrentStage)
               .Include((e) => e.CurrentLine)
               .Include((e) => e.CurrentRole)
               .Include((e) => e.Education)
               .Include((e) => e.Gender)
               .Include((e) => e.Ssntype)
               .Include((e) => e.CurrentLinemanager)
               .Include((e) => e.CurrentStagemanager)
               .Include((e) => e.CurrentPlant)
               .Include((e) => e.Subdepartment)
               .Include((e) => e.Employeesalary)
               .ToListAsync();
        }

        public async Task<Employee> GetById(long id)
        {
            return await _dbContext.Employee
                .Where(x => x.Empid == id)
                .Include((e) => e.CurrentRole)
                .Include((e) => e.EmployeeRoleTracker)
                .Include((e) => e.EmployeeTracker)
                .Include((e) => e.Employeedocuments)
                .Include((e) => e.Employeesalary)
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }
        private async Task<Employee> GetEmployeeById(long id)
        {
            return await _dbContext.Employee
                .Where(x => x.Empid == id)
                .Include((e) => e.EmployeeRoleTracker)
                .Include((e) => e.EmployeeTracker)
                .Include((e) => e.Employeedocuments)
                .Include((e) => e.Employeesalary)
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }
        public async Task<Employee> GetByName(string name)
        {
            return await _dbContext.Employee.AsNoTracking()
                 .Where(x => x.Phonenumber == name && x.Isactive == true)
                 .Include((e) => e.CurrentRole)
                 .FirstOrDefaultAsync();
        }
        public async Task<Employee> GetBySSN(string ssn, long empId)
        {
            return await _dbContext.Employee.AsNoTracking()
                 .Where(x => x.Ssn == ssn && x.Isactive == true && x.Empid != empId)
                 .FirstOrDefaultAsync();
        }

        public async Task Create(List<Employee> employees)
        {
            employees = employees.Where(e => !_dbContext.Employee.Any(e1 => e1.Empcode == e.Empcode)).ToList();
            for (int i = 0; i < employees.Count; i++)
            {
                employees[i] = await MapEmployeeRelations(employees[i], true);
            }
            if (employees.Any())
            {
                await _dbContext.Employee.AddRangeAsync(employees);
                await _dbContext.SaveChangesAsync();
            }

        }
        public List<Employee> GetNewEmployees(List<Employee> employees)
        {
            return employees.Where(e => !_dbContext.Employee.Any(e1 => e1.Empcode == e.Empcode)).ToList();
        }

        public async Task<EmployeeSearchResponse> Search(EmployeeSearch filterModel)
        {
            var filteredRows = _dbContext.Employee.AsNoTracking().Where(e => e.Isactive == filterModel.Status
                    && (!filterModel.EmpCode.HasValue || e.Empcode == filterModel.EmpCode)
                    && (!filterModel.EmpId.HasValue || e.Empid == filterModel.EmpId)
                    && (string.IsNullOrWhiteSpace(filterModel.Name)
                    || (e.Firstname != null && e.Firstname.ToLower().Contains(filterModel.Name.ToLower()))
                    || (e.Middlename != null && e.Middlename.ToLower().Contains(filterModel.Name.ToLower()))
                    || (e.Lastname != null && e.Lastname.ToLower().Contains(filterModel.Name.ToLower())))
                    && (string.IsNullOrWhiteSpace(filterModel.Email)
                    || (e.Personalemailaddress != null && e.Personalemailaddress.ToLower() == filterModel.Email.ToLower())
                    || (e.Officialemailaddress != null && e.Officialemailaddress.ToLower() == filterModel.Email.ToLower()))
                    && (!filterModel.Genderid.HasValue || e.Genderid == filterModel.Genderid)
                    && (!filterModel.Dob.HasValue || e.Dob == filterModel.Dob)
                    && (string.IsNullOrWhiteSpace(filterModel.Phonenumber) || e.Phonenumber == filterModel.Phonenumber)
                    && (!filterModel.Permanentcityid.HasValue || e.Permanentcityid == filterModel.Permanentcityid)
                    && (!filterModel.Educationid.HasValue || e.Educationid == filterModel.Educationid)
                    && (string.IsNullOrWhiteSpace(filterModel.Address1)
                    || (e.Address1 != null && e.Address1.ToLower() == filterModel.Address1.ToLower()))
                    && (string.IsNullOrWhiteSpace(filterModel.Address2)
                    || (e.Address2 != null && e.Address2.ToLower() == filterModel.Address2.ToLower()))
                    && (string.IsNullOrWhiteSpace(filterModel.Presentzip)
                    || (e.Presentzip != null && e.Presentzip.ToLower() == filterModel.Presentzip.ToLower())
                    || (e.Permanentzip != null && e.Permanentzip.ToLower() == filterModel.Presentzip.ToLower()))
                    && (!filterModel.Dateofjoining.HasValue || e.Dateofjoining == filterModel.Dateofjoining)
                    && (!filterModel.CurrentRoleid.HasValue || e.CurrentRoleid == filterModel.CurrentRoleid)
                    && (!filterModel.CurrentContractorid.HasValue || e.CurrentContractorid == filterModel.CurrentContractorid)
                    && (!filterModel.CurrentPlantid.HasValue || e.CurrentPlantid == filterModel.CurrentPlantid)
                    && ((filterModel.IsDepartmentNull && !e.CurrentDepartmentid.HasValue) || (!filterModel.IsDepartmentNull
                    && (!filterModel.CurrentDepartmentid.HasValue || e.CurrentDepartmentid == filterModel.CurrentDepartmentid)))
                    && ((filterModel.IsSubDepartmetnNull && !e.Subdepartmentid.HasValue) || (!filterModel.IsSubDepartmetnNull
                    && (!filterModel.Subdepartmentid.HasValue || e.Subdepartmentid == filterModel.Subdepartmentid)))
                    && ((filterModel.IsLineNull && !e.CurrentLineid.HasValue) || (!filterModel.IsLineNull
                    && (!filterModel.CurrentLineid.HasValue || e.CurrentLineid == filterModel.CurrentLineid)))
                    && (!filterModel.CurrentLinemanagerid.HasValue || e.CurrentLinemanagerid == filterModel.CurrentLinemanagerid)
                    && (!filterModel.CurrentStageid.HasValue || e.CurrentStageid == filterModel.CurrentStageid)
                    && ((filterModel.IsShiftNull && !e.CurrentShiftid.HasValue) || (!filterModel.IsShiftNull
                    && (!filterModel.CurrentShiftid.HasValue || e.CurrentShiftid == filterModel.CurrentShiftid)))
                    && (!filterModel.Payperhour.HasValue || e.Payperhour == filterModel.Payperhour)
                    && (!filterModel.Ssntypeid.HasValue || e.Ssntypeid == filterModel.Ssntypeid)
                    && (string.IsNullOrWhiteSpace(filterModel.Ssn)
                    || (e.Ssn != null && e.Ssn.ToLower() == filterModel.Ssn.ToLower()))
                    && (string.IsNullOrWhiteSpace(filterModel.Bankname)
                    || (e.Bankname != null && e.Bankname.ToLower() == filterModel.Bankname.ToLower()))
                     && (string.IsNullOrWhiteSpace(filterModel.Ifsc)
                    || (e.Ifsc != null && e.Ifsc.ToLower() == filterModel.Ifsc.ToLower()))
                     && (string.IsNullOrWhiteSpace(filterModel.Accountnumber)
                    || (e.Accountnumber != null && e.Accountnumber.ToLower() == filterModel.Accountnumber.ToLower()))
                    && (string.IsNullOrWhiteSpace(filterModel.Esic) || string.IsNullOrWhiteSpace(e.Esic) && e.Esic.ToLower() == filterModel.Esic.ToLower())
                     && (string.IsNullOrWhiteSpace(filterModel.Uan)
                    || (e.Uan != null && e.Uan.ToLower() == filterModel.Uan.ToLower())));

            return new EmployeeSearchResponse
            {
                TotalRows = filteredRows.Count(),
                Data = await filteredRows.OrderBy(c => c.Empcode).Skip((filterModel.PageNumber) * filterModel.PageSize).Take(filterModel.PageSize).AsNoTracking()
                .Include((e) => e.Presentcity)
                .Include((e) => e.CurrentContractor)
                .Include((e) => e.CurrentDepartment)
                .Include((e) => e.CurrentShift)
                .Include((e) => e.CurrentStage)
                .Include((e) => e.CurrentLine)
                .Include((e) => e.CurrentRole)
                .Include((e) => e.Education)
                .Include((e) => e.Gender)
                .Include((e) => e.Ssntype)
                .Include((e) => e.CurrentLinemanager)
                .Include((e) => e.CurrentStagemanager)
                .Include((e) => e.CurrentPlant)
                .Include((e) => e.Subdepartment)
                .Include((e) => e.Employeesalary)
                .Include((e) => e.Permanentcity)
                .Include((e)=> e.Nation)
                .Include((e) => e.Employeedocuments).ThenInclude(d=>d.Attachment)
                .ToListAsync()
            };
        }

        public async Task<List<DropdownValue>> GetEmployeesByRoleName(string roleName)
        {
            return await _dbContext.Employee.AsNoTracking().Include(x => x.CurrentRole)
                .Where(x => x.CurrentRole.Roledetails.ToLower() == roleName.ToLower() && x.Isactive == true)
                .Select(s => new DropdownValue
                {
                    Id = s.Empid,
                    Name = (String.Format("{0} {1}", s.Firstname, s.Lastname)).Trim(),
                }).ToListAsync();

        }


        public async Task<List<DropdownValue>> GetManagersByDepartment(int? departmentId)
        {
            var roleName = "manager";
            return await _dbContext.Employee.AsNoTracking().Include(x => x.CurrentRole)
                .Where(x => x.CurrentRole.Roledetails.ToLower() == roleName.ToLower() 
                && x.Isactive == true 
                &&(!departmentId.HasValue || x.CurrentDepartmentid == departmentId))
                .Select(s => new DropdownValue
                {
                    Id = s.Empid,
                    Name = (String.Format("{0} {1}", s.Firstname, s.Lastname)).Trim(),
                }).ToListAsync();

        }
        public async Task<List<Employee>> GetEmployeesByShift(long shiftId)
        {
            return await _dbContext.Employee.AsNoTracking().
                Include(x => x.CurrentShift).
                Where(x => x.CurrentShift.Shiftid == shiftId).ToListAsync();
        }

        public async Task<bool> ChangePasswordByEmployeeId(long eId, string password)
        {
            var emp = await this.GetById(eId);
            if (emp != null)
            {
                emp.Password = password;
                _dbContext.Update(emp);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<EmployeeLinesDashboardResponse> GetLineDashboardData(EmployeeLinesDashboardSearch filterModel)
        {
            var filteredRows = _dbContext.Employee.Include(e => e.EmployeeAttendance).AsNoTracking()
                .Where(e => e.EmployeeTracker.Any(et=> et.Startdate <= filterModel.CurrentDate && filterModel.CurrentDate <= et.Enddate)
                && (!filterModel.ManagerId.HasValue || e.CurrentLinemanagerid == filterModel.ManagerId)
                && (!filterModel.LineId.HasValue || e.CurrentLineid == filterModel.LineId)
                && (!filterModel.ShiftId.HasValue || e.CurrentShiftid == filterModel.ShiftId)
                && (!filterModel.StageId.HasValue || e.CurrentStageid == filterModel.StageId)
                ).Select(e => new EmployeeLinesDashboard
                {
                    EmpId = e.Empid,
                    EmpCode = e.Empcode,
                    Name = e.Firstname,
                    Line = e.CurrentLine != null ? e.CurrentLine.Linedescription : string.Empty,
                    Stage = e.CurrentStage != null ? e.CurrentStage.Stagedescription : string.Empty,
                    IsPresent = e.EmployeeAttendance.Any(x => x.Attendancedate.Value.Date == filterModel.CurrentDate.Value.Date && x.Ispresent == true),
                    SkillRating = e.Employeeskill.FirstOrDefault() != null ? e.Employeeskill.FirstOrDefault().Skillratingscore.GetValueOrDefault() : 0
                })
                .Where(row => !filterModel.IsPresent.HasValue || row.IsPresent == filterModel.IsPresent);

            return new EmployeeLinesDashboardResponse
            {
                TotalRows = filteredRows.Count(),
                Data = await filteredRows.Skip((filterModel.PageNumber) * filterModel.PageSize).Take(filterModel.PageSize).AsNoTracking().ToListAsync()
            };
        }

        public async Task BulkEdit(EmployeeBulkEditModel bulkEditModel)
        {
            foreach (var empId in bulkEditModel.Empids)
            {
                var employee = _dbContext.Employee.AsNoTracking().FirstOrDefault(e => e.Empid == empId);
                if (bulkEditModel.ShiftId.HasValue)
                {
                    employee.CurrentShiftid = bulkEditModel.ShiftId;
                }

                if (bulkEditModel.DepartmentId.HasValue)
                {
                    employee.CurrentDepartmentid = bulkEditModel.DepartmentId;
                    employee.Subdepartmentid = bulkEditModel.SubDepartmentId;
                    employee.CurrentLineid = bulkEditModel.LineId;
                    employee.CurrentStageid = bulkEditModel.StageId;
                }
                if (bulkEditModel.ManagerId.HasValue)
                {
                    employee.CurrentLinemanagerid = bulkEditModel.ManagerId;
                }
                if (bulkEditModel.Il.HasValue)
                {
                    employee.Ildl = bulkEditModel.Il;
                }
                await Edit(employee, skipValidations: true, effectiveDate: bulkEditModel.EffectiveDate);
            }
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateDependencies(UpdateDependencyModel updateDependencyModel)
        {
            var command = _dbContext.SqlWithStatusText.FromSqlRaw($"select * from public.UpdateDependencies('{updateDependencyModel.Attribute}',{updateDependencyModel.NewValue},{updateDependencyModel.CurrentValue},{updateDependencyModel.IsDeleted})");
            await command.ToListAsync();
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(EmployeeDeleteModel employeeDeleteModel)
        {
            var record = new Employee();
            record.Empid = employeeDeleteModel.Empid;
            record.Dateofleaving = employeeDeleteModel.LastWorkingDay.Date;
            var employee = await MapEmployeeRelations(record, false);
            employee.LeavingReason = employeeDeleteModel.LeavingReason;
            employee.Dateofleaving = employeeDeleteModel.LastWorkingDay;
            employee.CommentsOnEmployeeReliving = employeeDeleteModel.CommentsOnEmployeeRelieving;
            employee.IsEligibleForRehire = employeeDeleteModel.IsEligibleForRehire;
            _dbContext.Employee.Update(employee);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Employee>> GetAll(long? managerId, string employeeIds)
        {
            var empIds = employeeIds.Split(",").ToList();
            return await _dbContext.Employee.Where(e =>
            (!managerId.HasValue || e.CurrentLinemanagerid == managerId)
            && empIds.Contains(e.Empcode.ToString())).AsNoTracking()
               .Include((e) => e.Presentcity)
               .Include((e) => e.CurrentContractor)
               .Include((e) => e.CurrentDepartment)
               .Include((e) => e.CurrentShift)
               .Include((e) => e.CurrentStage)
               .Include((e) => e.CurrentLine)
               .Include((e) => e.CurrentRole)
               .Include((e) => e.Education)
               .Include((e) => e.Gender)
               .Include((e) => e.Ssntype)
               .Include((e) => e.CurrentLinemanager)
               .Include((e) => e.CurrentStagemanager)
               .Include((e) => e.CurrentPlant)
               .Include((e) => e.Subdepartment)
               .Include((e) => e.Employeesalary)
               .ToListAsync();
        }

        public async Task BulkDelete(EmployeeBulkDeleteModel bulkDeleteModel)
        {
            var employeeList = new List<Employee>();
            foreach (var empId in bulkDeleteModel.Empids)
            {
                var record = new Employee();
                record.Empid = empId;
                record.Dateofleaving = bulkDeleteModel.LastWorkingDay.Date;
                record.LeavingReason = bulkDeleteModel.LeavingReason;
                record.Dateofleaving = bulkDeleteModel.LastWorkingDay;
                record.CommentsOnEmployeeReliving = bulkDeleteModel.CommentsOnEmployeeRelieving;
                record.IsEligibleForRehire = bulkDeleteModel.IsEligibleForRehire;
                var employee = await MapEmployeeRelations(record, false);
                employeeList.Add(employee);
            }
            _dbContext.Employee.UpdateRange(employeeList);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Reactivate(BulkReactivateModel bulkReactivateModel)
        {
            foreach (var empId in bulkReactivateModel.Empids)
            {
                var employee = _dbContext.Employee.AsNoTracking().FirstOrDefault(e => e.Empid == empId);
                employee.Isactive = true;
                //employee.IsRehired = true;
                await Edit(employee, skipValidations: true, effectiveDate: bulkReactivateModel.EffectiveDate);
            }
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<EmployeeDropdownModel>> GetEmployeesByManager(long? managerId)
        {

            return await _dbContext.Employee.AsNoTracking()
                .Include(e=>e.CurrentDepartment)
                .Include(e=>e.Subdepartment)
                .Where(e => e.Isactive == true &&
            (!managerId.HasValue || e.CurrentLinemanagerid == managerId))
                .Select(e => new EmployeeDropdownModel
                {
                    EmpId = e.Empid,
                    EmpCode = e.Empcode.GetValueOrDefault(),
                    Name = $"{e.Firstname} {e.Lastname}",
                    Department = e.CurrentDepartmentid.HasValue? e.CurrentDepartment.Departmentdescription:"",
                    SubDepartment = e.Subdepartmentid.HasValue?e.Subdepartment.Departmentdescription:""
                })
                .OrderByDescending(e=>e.EmpCode)
                .ToListAsync();
        }
        public async Task<List<EmployeeDropdownModel>> Get3rdPartyEmployees(long? managerId)
        {

            return await _dbContext.Employee.AsNoTracking()
                .Include(e => e.CurrentDepartment)
                .Include(e => e.Subdepartment)
                .Where(e => e.Isactive == true &&
            (!managerId.HasValue || e.CurrentLinemanagerid == managerId) 
            && (!e.CurrentDepartmentid.HasValue 
            || e.CurrentDepartment.Departmentdescription.ToLower().Trim() == "production" 
            || (e.CurrentDepartment.Departmentdescription.ToUpper().Trim() == "QUALITY" && (!e.Subdepartmentid.HasValue || e.Subdepartment.Departmentdescription.ToLower().Trim() == "pqc")))
            )
                .Select(e => new EmployeeDropdownModel
                {
                    EmpId = e.Empid,
                    EmpCode = e.Empcode.GetValueOrDefault(),
                    Name = $"{e.Firstname} {e.Lastname}",
                    Department = e.CurrentDepartmentid.HasValue ? e.CurrentDepartment.Departmentdescription : "",
                    SubDepartment = e.Subdepartmentid.HasValue ? e.Subdepartment.Departmentdescription : ""
                })
                .OrderByDescending(e => e.EmpCode)
                .ToListAsync();
        }
    }
}