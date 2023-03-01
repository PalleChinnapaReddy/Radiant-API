using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Radiant.DataAccess.FilterModels;
using Radiant.DataAccess.Models;
using Radiant.DataAccess.Repository.Contracts;
using Radiant.DataAccess.Response;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Radiant.DataAccess.Repository
{
    public class AttendanceOtApprovalRepository : IAttendanceOTApprovalRepository
    {
        private readonly ILogger<AttendanceOtApproval> _logger;
        private readonly CustomRadiantDbContext _dbContext;

        public AttendanceOtApprovalRepository(ILogger<AttendanceOtApproval> logger
            , CustomRadiantDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }
        public async Task<AttendanceOtApproval> Create(AttendanceOtApproval record)
        {
            await _dbContext.AttendanceOtApproval.AddAsync(record);
            await _dbContext.SaveChangesAsync();
            return record;
        }

        public async Task Delete(long id)
        {
            var attendanceOtApproval = await GetById(id);
            //attendanceOtApproval.Attendanceapprovalid
            //attendanceOtApproval.Isac
            //_dbContext.
        }

        public async Task<AttendanceOtApproval> Edit(AttendanceOtApproval record)
        {
            var approvedStatus = _dbContext.OtStatus
                .SingleOrDefault((r) => r.Otstatusdescription != null && r.Otstatusdescription.ToLower() == "approved");
            if(record.Otstatusid == approvedStatus?.Otstatusid)
            {
                var approvedRecord = await _dbContext.EmployeeAttendance
                    .Where(ea => ea.Employeeattendanceid == record.Employeeattendanceid)
                    .AsNoTracking().FirstOrDefaultAsync();
                if(approvedRecord != null)
                {
                    var toChange = await _dbContext.EmployeeAttendance
                                      .Where(ea => ea.Empid == record.Employeeattendance.Empid 
                                      && ea.Employeeattendanceid != record.Employeeattendanceid
                                      && ea.Attendancedate.HasValue 
                                      && ea.Attendancedate.Value.Date == approvedRecord.Attendancedate.Value.Date
                                      )
                                      .AsNoTracking().ToListAsync();
                    if(toChange != null && toChange.Any())
                    {
                        foreach (var empAttendance in toChange)
                        {
                            empAttendance.Ispresent = default(bool?);
                            _dbContext.EmployeeAttendance.Update(empAttendance);
                        }
                    }
                }

                    
                record.Employeeattendance.Ispresent = true;
                var payrollShift = _dbContext.Payrollshift.Where((ps) => ps.Shiftactivedate == record.Employeeattendance.Attendancedate
                                   && ps.Shiftstartthresholdfrom <= record.Employeeattendance.Checkintime.Value.TimeOfDay
                                   && record.Employeeattendance.Checkintime.Value.TimeOfDay <= ps.Shiftstartthresholdto).FirstOrDefault();
                if (payrollShift != null)
                {
                    record.Employeeattendance.Payrollshiftid = payrollShift.Payrollshiftid;

                }
            else
            {
                record.Employeeattendance.Ispresent = default(bool?);
            }
            
            }
            _dbContext.AttendanceOtApproval.Update(record);
            await _dbContext.SaveChangesAsync();
            return record;
        }

        public async Task<List<AttendanceOtApproval>> GetAll()
        {
            return await _dbContext.AttendanceOtApproval.AsNoTracking()
                .Include((aoa)=>aoa.Employeeattendance).ThenInclude(ea=>ea.Emp)
                .Include((aoa) => aoa.Employeeattendance).ThenInclude(ea => ea.AttendanceType)
                .Include((aoa)=>aoa.Otstatus)
                .OrderByDescending(c => c.CreatedOn)
                .ToListAsync();
        }

        public async Task<AttendanceOtApproval> GetById(long id)
        {
            return await _dbContext.AttendanceOtApproval.Where(aop => aop.Attendanceapprovalid == id)
                .AsNoTracking()
                .Include(aoa=>aoa.Employeeattendance).ThenInclude(ea=>ea.Emp)
                .Include(aoa => aoa.Employeeattendance).ThenInclude(ea => ea.Emp)
                .Include(aoa=>aoa.Otstatus)
                .FirstOrDefaultAsync();
        }

        public Task<AttendanceOtApproval> GetByName(string name)
        {
            throw new System.NotImplementedException();
        }

        public async Task<AttendanceOTApprovalResponse> GetRequestsByManagerId(AttendanceOtSearch filterModel)
        {
     
             var filterQuery =  _dbContext.AttendanceOtApproval.AsNoTracking()
                .Where(q=>(!filterModel.ManagerId.HasValue || q.Employeeattendance.Emp.CurrentLinemanagerid == filterModel.ManagerId.Value)
                && (q.Employeeattendance.Attendancedate >= filterModel.StartDate 
                || q.Employeeattendance.Attendancedate <= filterModel.EndDate))
               .Include((aoa) => aoa.Employeeattendance).ThenInclude(ea => ea.Emp)
               .Include((aoa) => aoa.Employeeattendance).ThenInclude(ea => ea.AttendanceType)
               .Include((aoa) => aoa.Otstatus)
               .OrderByDescending(c => c.CreatedOn);
            return new AttendanceOTApprovalResponse
            {
                PendingRequests = await filterQuery.Where(q => q.Otstatusid == null).Skip((filterModel.PageNumber) * filterModel.PageSize).Take(filterModel.PageSize)
                .ToListAsync(),
                ValidatedRequests = await filterQuery.Where(q => q.Otstatusid != null).Skip((filterModel.PageNumber) * filterModel.PageSize).Take(filterModel.PageSize)
                .ToListAsync(),
                TotalPendingCount = filterQuery.Where(q => q.Otstatusid == null).Count(),
                TotalValidatedCount= filterQuery.Where(q => q.Otstatusid != null).Count()
            };
        }
    }
}