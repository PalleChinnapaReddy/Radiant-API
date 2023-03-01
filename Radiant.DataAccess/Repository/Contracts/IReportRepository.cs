using Radiant.DataAccess.Models.Reports;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Radiant.DataAccess.Repository.Contracts
{
    public interface IReportRepository
    {
        Task<List<AttendanceCountByDay>> GetAttendanceCountByDay(AttendanceCountByDayFilter filter);
        Task<List<AttendanceByEmployee>> GetAttendanceByEmployee(AttendanceByEmployeeFilter filter);
        Task<List<AttendanceCountByShift>> GetAttendanceCountByShift(AttendanceCountByShiftFilter filter);
        Task<List<HeadCountReportByDay>> GetHeadCountReportByDay(HeadCountReportByDayFilter filter);
        Task<List<AttendanceReportByDay>> GetAttendanceReportByDay(AttendanceReportByDayFilter filter);
        Task<List<EmpOTReport>> GetEmpOTReport(EmpOTReportFilter filter);
        Task<List<LoadPayrollData>> LoadPayrollData();
        Task<List<EmpHierarchy>> GetEmpHierarchy(long empid);
        Task<EmpAttendanceRefresh> EmpAttendanceRefreshSync(EmpAttendanceRefreshRequest empAttendanceRefreshRequest);
        Task<List<DashboardLineMetrics>> GetDashboardLineMetrics(DateTime date);
        Task<List<DashboardMetrics>> GetDashboardMetrics(DateTime date);
        Task<List<DashboardShiftMetrics>> GetDashboardShiftMetrics(DateTime date);
        Task<List<OTRegister>> GetOTRegister(int month,int year);
        Task<List<WageSheetRegister>> GetWageSheetRegister(int month,int year);
        Task<List<VendorPayable>> GetVendorPayable(int month, int year);


    }
}
