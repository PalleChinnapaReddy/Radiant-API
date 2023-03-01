using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Radiant.DataAccess.Models.Reports;
using Radiant.DataAccess.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Radiant.DataAccess.Repository
{
    public class ReportRepository : IReportRepository
    {
        private readonly ILogger<ReportRepository> _logger;
        private readonly CustomRadiantDbContext _dbContext;
        
        public ReportRepository(ILogger<ReportRepository> logger
            , CustomRadiantDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public async Task<List<AttendanceByEmployee>> GetAttendanceByEmployee(AttendanceByEmployeeFilter filter)
        {
            var command = _dbContext.AttendanceByEmployee.FromSqlRaw($@"SELECT * from public.attendance_by_employee('{filter.ContractorId}',--contractor
            '{filter.LineId}',--lineid
            '{filter.StageId}',--stageid
            '{filter.ShiftIds}',--shiftid
            '{filter.PlantId}', --plantid
            '{filter.EmpId}', --empid
            '{filter.StartDate.ToString("yyyy-MM-dd")}', --startdate
            '{filter.EndDate.ToString("yyyy-MM-dd")}' --enddate
            )");
            return await command.ToListAsync();
        }

        public async Task<List<AttendanceCountByDay>> GetAttendanceCountByDay(AttendanceCountByDayFilter filter)
        {
            var command = _dbContext.AttendanceCountByDay.FromSqlRaw($@"SELECT * from public.Attendance_Count_by_day('{filter.ContractorId}',--contractor
            '{filter.LineId}',--lineid
            '{filter.StageId}',--stageid
            '{filter.ShiftIds}',--shiftid
            '{filter.StartDate.ToString("yyyy-MM-dd")}', --startdate
            '{filter.EndDate.ToString("yyyy-MM-dd")}' --enddate
            )");
            return await command.ToListAsync();
        }

        public async Task<List<AttendanceCountByShift>> GetAttendanceCountByShift(AttendanceCountByShiftFilter filter)
        {
            var command = _dbContext.AttendanceCountByShift.FromSqlRaw($@"SELECT * from public.attendance_count_by_shift('{filter.ContractorId}',--contractor
            '{filter.LineId}',--lineid
            '{filter.StageId}',--stageid
            '{filter.ShiftIds}',--shiftid
            '{filter.StartDate.ToString("yyyy-MM-dd")}', --startdate
            '{filter.EndDate.ToString("yyyy-MM-dd")}' --enddate
            )");
            return await command.ToListAsync();
        }
        public async Task<List<AttendanceReportByDay>> GetAttendanceReportByDay(AttendanceReportByDayFilter filter)
        {
            var command = _dbContext.AttendanceReportByDay.FromSqlRaw(
                $@"SELECT * from public.AttendancereportbyDay(
            '{filter.Contractor}',--contractor
            '{filter.StageId}',--lineid
            '{filter.ShiftId}',--stageid
            '{filter.LineId}',
            '{filter.InActivePresent}',
            '{filter.StartDate.ToString("yyyy-MM-dd")}', --startdate
            '{filter.EndDate.ToString("yyyy-MM-dd")}' --enddate
            ) a order by a.employeeid"); //In this query we are getting employeecode with name employeeid
            var result = await command.ToListAsync();
            return result;
        }
        public async Task<List<HeadCountReportByDay>> GetHeadCountReportByDay(HeadCountReportByDayFilter filter)
        {
            var command = _dbContext.HeadCountReportByDay.FromSqlRaw($@"
            SELECT * from public.HeadcountreportbyDay(
            '{filter.Contractor}',--contractor
            '{filter.StageId}',--lineid
            '{filter.ShiftId}',--stageid
            '{filter.LineId}',
            '{filter.GivenDate.ToString("yyyy-MM-dd")}' --startdate
            )");
            return await command.ToListAsync();
        }
        public async Task<List<EmpOTReport>> GetEmpOTReport(EmpOTReportFilter filter)
        {
            var command = _dbContext.EmpOTReport.FromSqlRaw($@"
            SELECT * from public.EmpOTReport(
            '{filter.Contractor}',--contractor
            '{filter.StartDate.ToString("yyyy-MM-dd")}',--startdate
            '{filter.EndDate.ToString("yyyy-MM-dd")}'--enddate
            )");
            return await command.ToListAsync();
        }
        public async Task<List<EmpHierarchy>> GetEmpHierarchy(long empid)
        {
            var command = _dbContext.EmpHierarchy.FromSqlRaw($@"
            SELECT * from public.emphierarchy(
            '{empid}'--empid
            )");
            return await command.ToListAsync();
        }
        public async Task<List<LoadPayrollData>> LoadPayrollData()
        {
            var command = _dbContext.LoadPayrollData.FromSqlRaw($@"
            SELECT * from public.LoadpayrollData()");
            return await command.ToListAsync();
        }
        public async Task<EmpAttendanceRefresh> EmpAttendanceRefreshSync(EmpAttendanceRefreshRequest empAttendanceRefreshRequest)
        {
            var command = _dbContext.EmpAttendanceRefresh.FromSqlRaw($@"
            SELECT * from public.EmpAttendanceRefresh(
            '{empAttendanceRefreshRequest.BatchId}'--batchid
            )");
            return await command.FirstOrDefaultAsync();
        }

        public async Task<List<DashboardLineMetrics>> GetDashboardLineMetrics(DateTime date)
        {
            var command = _dbContext.DashboardLineMetrics.FromSqlRaw($@"
            SELECT * from public.dashboard_line_Shift_metrics('{date.ToString("yyyy-MM-dd")}')");
            return await command.ToListAsync();
        }

        public async Task<List<DashboardMetrics>> GetDashboardMetrics(DateTime date)
        {
            var command = _dbContext.DashboardMetrics.FromSqlRaw($@"
            SELECT * from public.dashboard_metrics('{date.ToString("yyyy-MM-dd")}')");
            return await command.ToListAsync();
        }

        public async Task<List<DashboardShiftMetrics>> GetDashboardShiftMetrics(DateTime date)
        {
            var command = _dbContext.DashboardShiftMetrics.FromSqlRaw($@"
            SELECT * from public.dashboard_shift_metrics('{date.ToString("yyyy-MM-dd")}')");
            return await command.ToListAsync();
        }

        public async Task<List<OTRegister>> GetOTRegister(int month, int year)
        {
            var command = _dbContext.OTRegister.FromSqlRaw($@"
            SELECT * from public.OTRegister('{month}','{year}')");
            return await command.ToListAsync();
        }

        public async Task<List<WageSheetRegister>> GetWageSheetRegister(int month, int year)
        {
            try
            {
                var command = _dbContext.WageSheetRegister.FromSqlRaw($@"
            SELECT * from public.WageSheetRegister('{month}','{year}')");
                return await command.ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<VendorPayable>> GetVendorPayable(int month, int year)
        {
            var command = _dbContext.VendorPayable.FromSqlRaw($@"
            SELECT * from public.vendorPayable('{month}','{year}')");
            return await command.ToListAsync();
        }
    }
}
