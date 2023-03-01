using Radiant.Business.Models.Reports;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Radiant.Business.Contracts
{
    public interface IReportBusiness
    {
        Task<List<AttendanceCountByDayDto>> GetAttendanceCountByDay(AttendanceCountByDayFilterDto filter);
        Task<List<AttendanceByEmployeeDto>> GetAttendanceByEmployee(AttendanceByEmployeeFilterDto filter);
        Task<List<AttendanceCountByShiftDto>> GetAttendanceCountByShift(AttendanceCountByShiftFilterDto filter);
        Task<List<HeadCountReportByDayDto>> GetHeadCountReportByDay(HeadCountReportByDayFilterDto filter);
        Task<List<AttendanceReportByDayDto>> GetAttendanceReportByDay(AttendanceReportByDayFilterDto filter);
        Task<List<EmpOTReportDto>> GetEmpOTReport(EmpOTReportFilterDto filter);
        Task<List<LoadPayrollDataDto>> LoadPayrollData();
        Task<List<EmpHierarchyDto>> GetEmpHierarchy(long empid);
        Task<EmpAttendanceRefreshDto> EmpAttendanceRefreshSync(EmpAttendanceRefreshRequestDto empAttendanceRefreshRequestDto);
        Task<List<DashboardLineMetricsDto>> GetDashboardLineMetrics(DateTime date);
        Task<List<DashboardMetricsDto>> GetDashboardMetrics(DateTime date);
        Task<List<DashboardShiftMetricsDto>> GetDashboardShiftMetrics(DateTime date);
        Task<List<OTRegisterDto>> GetOTRegister(int month, int year);
        Task<List<WageSheetRegisterDto>> GetWageSheetRegister(int month, int year);
        Task<List<VendorPayableDto>> GetVendorPayable(int month, int year);
    }
}
