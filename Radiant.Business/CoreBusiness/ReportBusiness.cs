using AutoMapper;
using Microsoft.Extensions.Logging;
using Radiant.Business.Contracts;
using Radiant.Business.Models.Reports;
using Radiant.DataAccess.Models.Reports;
using Radiant.DataAccess.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Radiant.Business.CoreBusiness
{
    public class ReportBusiness : IReportBusiness
    {
        private readonly IReportRepository _reportRepository;
        private readonly ILogger<ReportBusiness> _logger;
        private readonly IMapper _modelMapper;

        public ReportBusiness(IReportRepository reportRepository
            , ILogger<ReportBusiness> logger
            , IMapper modelMapper)
        {
            _reportRepository = reportRepository;
            _logger = logger;
            _modelMapper = modelMapper;
        }

        public async Task<List<AttendanceByEmployeeDto>> GetAttendanceByEmployee(AttendanceByEmployeeFilterDto filter)
        {
            try
            {
                var attendanceByEmployeeFilter = _modelMapper.Map<AttendanceByEmployeeFilter>(filter);
                var attendanceByEmployee = await _reportRepository.GetAttendanceByEmployee(attendanceByEmployeeFilter);
                return _modelMapper.Map<List<AttendanceByEmployeeDto>>(attendanceByEmployee);
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<AttendanceCountByDayDto>> GetAttendanceCountByDay(AttendanceCountByDayFilterDto filter)
        {
            try
            {
                var attendanceCountByDayFilter = _modelMapper.Map<AttendanceCountByDayFilter>(filter);
                var attendanceCountByDay = await _reportRepository.GetAttendanceCountByDay(attendanceCountByDayFilter);
                return _modelMapper.Map<List<AttendanceCountByDayDto>>(attendanceCountByDay);
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<AttendanceCountByShiftDto>> GetAttendanceCountByShift(AttendanceCountByShiftFilterDto filter)
        {
            try
            {
                var attendanceCountByShiftFilter = _modelMapper.Map<AttendanceCountByShiftFilter>(filter);
                var attendanceCountByShift = await _reportRepository.GetAttendanceCountByShift(attendanceCountByShiftFilter);
                return _modelMapper.Map<List<AttendanceCountByShiftDto>>(attendanceCountByShift);
            }
            catch
            {
                throw;
            }
        }
        public async Task<List<AttendanceReportByDayDto>> GetAttendanceReportByDay(AttendanceReportByDayFilterDto filter)
        {
            try
            {
                var attendanceReportByDayFilter = _modelMapper.Map<AttendanceReportByDayFilter>(filter);
                var attendanceReportByDays = await _reportRepository.GetAttendanceReportByDay(attendanceReportByDayFilter);
                return _modelMapper.Map<List<AttendanceReportByDayDto>>(attendanceReportByDays);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public async Task<List<HeadCountReportByDayDto>> GetHeadCountReportByDay(HeadCountReportByDayFilterDto filter)
        {
            try
            {
                var headCountReportByDayFilter = _modelMapper.Map<HeadCountReportByDayFilter>(filter);
                var headCountReportByDays = await _reportRepository.GetHeadCountReportByDay(headCountReportByDayFilter);
                return _modelMapper.Map<List<HeadCountReportByDayDto>>(headCountReportByDays);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public async Task<List<EmpOTReportDto>> GetEmpOTReport(EmpOTReportFilterDto filter)
        {
            try
            {
                var empOTReportFilter = _modelMapper.Map<EmpOTReportFilter>(filter);
                var empOTReports = await _reportRepository.GetEmpOTReport(empOTReportFilter);
                return _modelMapper.Map<List<EmpOTReportDto>>(empOTReports);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<EmpAttendanceRefreshDto> EmpAttendanceRefreshSync(EmpAttendanceRefreshRequestDto empAttendanceRefreshRequestDto)
        {
            try
            {
                var empAttendanceRefreshRequest = _modelMapper.Map<EmpAttendanceRefreshRequest>(empAttendanceRefreshRequestDto);
                var result = await _reportRepository.EmpAttendanceRefreshSync(empAttendanceRefreshRequest);
                return _modelMapper.Map<EmpAttendanceRefreshDto>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<LoadPayrollDataDto>> LoadPayrollData()
        {
            try
            {
                var result = await _reportRepository.LoadPayrollData();
                return _modelMapper.Map<List<LoadPayrollDataDto>>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<EmpHierarchyDto>> GetEmpHierarchy(long empid)
        {
            try
            {
                var result = await _reportRepository.GetEmpHierarchy(empid);
                return _modelMapper.Map<List<EmpHierarchyDto>>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<DashboardLineMetricsDto>> GetDashboardLineMetrics(DateTime date)
        {
            try
            {
                var result = await _reportRepository.GetDashboardLineMetrics(date);
                return _modelMapper.Map<List<DashboardLineMetricsDto>>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<DashboardMetricsDto>> GetDashboardMetrics(DateTime date)
        {
            try
            {
                var result = await _reportRepository.GetDashboardMetrics(date);
                return _modelMapper.Map<List<DashboardMetricsDto>>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<DashboardShiftMetricsDto>> GetDashboardShiftMetrics(DateTime date)
        {
            try
            {
                var result = await _reportRepository.GetDashboardShiftMetrics(date);
                return _modelMapper.Map<List<DashboardShiftMetricsDto>>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<OTRegisterDto>> GetOTRegister(int month, int year)
        {
            try
            {
                var result = await _reportRepository.GetOTRegister(month,year);
                return _modelMapper.Map<List<OTRegisterDto>>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<WageSheetRegisterDto>> GetWageSheetRegister(int month, int year)
        {
            try
            {
                var result = await _reportRepository.GetWageSheetRegister(month,year);
                return _modelMapper.Map<List<WageSheetRegisterDto>>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<VendorPayableDto>> GetVendorPayable(int month, int year)
        {
            try
            {
                var result = await _reportRepository.GetVendorPayable(month,year);
                return _modelMapper.Map<List<VendorPayableDto>>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
