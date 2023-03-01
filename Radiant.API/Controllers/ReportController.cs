using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Radiant.Business.Contracts;
using Radiant.Business.Models.Reports;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;

namespace Radiant.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IReportBusiness _reportBusiness;
        private readonly ILogger<ReportController> _logger;
        private readonly string UPLOAD_DIRECTORY = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Reports");

        public ReportController(IReportBusiness reportBusiness
            , ILogger<ReportController> logger)
        {
            _reportBusiness = reportBusiness;
            _logger = logger;
            if (!Directory.Exists(UPLOAD_DIRECTORY))
            {
                Directory.CreateDirectory(UPLOAD_DIRECTORY);
            }
        }

        /// <summary>
        /// Get all AttendanceCountByDay
        /// </summary>
        /// <returns></returns>
        [Produces("application/json")]
        [HttpGet]
        [Route("attendance_count_by_day")]
        public async Task<ActionResult<List<AttendanceCountByDayDto>>> GetAttendanceCountByDay([FromQuery] AttendanceCountByDayFilterDto attendanceCountByDayFilterDto)
        {
            try
            {
                var attendanceCountByDay = await _reportBusiness.GetAttendanceCountByDay(attendanceCountByDayFilterDto);
                return Ok(attendanceCountByDay);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Get all AttendanceByEmployee
        /// </summary>
        /// <returns></returns>
        [Produces("application/json")]
        [HttpGet]
        [Route("attendance_by_employee")]
        public async Task<ActionResult<List<AttendanceByEmployeeDto>>> GetAttendanceByEmployee([FromQuery] AttendanceByEmployeeFilterDto attendanceByEmployeeFilterDto)
        {
            try
            {
                var attendanceCountByEmployee = await _reportBusiness.GetAttendanceByEmployee(attendanceByEmployeeFilterDto);
                return Ok(attendanceCountByEmployee);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Get all AttendanceByEmployee
        /// </summary>
        /// <returns></returns>
        [Produces("application/json")]
        [HttpGet]
        [Route("attendance_count_by_shift")]
        public async Task<ActionResult<List<AttendanceCountByShiftDto>>> GetAttendanceCountByShift([FromQuery] AttendanceCountByShiftFilterDto attendanceCountByShiftFilterDto)
        {
            try
            {
                var attendanceCountByShift = await _reportBusiness.GetAttendanceCountByShift(attendanceCountByShiftFilterDto);
                return Ok(attendanceCountByShift);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [Produces("application/json")]
        [HttpGet]
        [Route("attendancereportbyday")]
        /// <summary>
        /// Get all AttendanceByEmployee for a Day
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult<List<AttendanceReportByDayDto>>> GetAttendanceReportByDay([FromQuery] AttendanceReportByDayFilterDto attendanceReportByDayFilterDto)
        {
            try
            {
                var attendanceReportByDays = await _reportBusiness.GetAttendanceReportByDay(attendanceReportByDayFilterDto);
                return Ok(attendanceReportByDays);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [Produces("application/json")]
        [HttpGet]
        [Route("headcountreportbyday")]
        /// <summary>
        /// Get all HeadCount by Day
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult<List<HeadCountReportByDayDto>>> GetHeadCountReportByDay([FromQuery] HeadCountReportByDayFilterDto headCountReportByDayFilterDto)
        {
            try
            {
                var headCountReportByDays = await _reportBusiness.GetHeadCountReportByDay(headCountReportByDayFilterDto);
                return Ok(headCountReportByDays);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [Produces("application/json")]
        [HttpGet]
        [Route("emphierarch")]
        /// <summary>
        /// Get Employee hierarchy 
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult<List<EmpHierarchyDto>>> GetEmpHierarchy([FromQuery] long empid)
        {
            try
            {
                var empHierarchies = await _reportBusiness.GetEmpHierarchy(empid);
                return Ok(empHierarchies);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [Produces("application/json")]
        [HttpGet]
        [Route("loadpayrolldata")]
        /// <summary>
        /// Load Payroll Data
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult<List<LoadPayrollDataDto>>> GetLoadPayrollData([FromQuery] HeadCountReportByDayFilterDto headCountReportByDayFilterDto)
        {
            try
            {
                var result = await _reportBusiness.LoadPayrollData();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [Produces("application/json")]
        [HttpGet]
        [Route("empattendancerefresh")]
        /// <summary>
        /// Get all empattendancerefresh 
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult<EmpAttendanceRefreshDto>> EmpAttendanceRefreshSync([FromQuery] EmpAttendanceRefreshRequestDto empAttendanceRefreshRequestDto)
        {
            try
            {
                var empAttendanceRefresh = await _reportBusiness.EmpAttendanceRefreshSync(empAttendanceRefreshRequestDto);
                return Ok(empAttendanceRefresh);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }



        [Produces("application/json")]
        [HttpGet]
        [Route("getempotreport")]
        /// <summary>
        /// Get all EmpOTReport 
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult<List<EmpOTReportDto>>> GetEmpOTReport([FromQuery] EmpOTReportFilterDto empOTReportFilterDto)
        {
            try
            {
                var empOTReportDtos = await _reportBusiness.GetEmpOTReport(empOTReportFilterDto);
                return Ok(empOTReportDtos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [Produces("application/json")]
        [HttpGet]
        [Route("dashboardlinemetrics")]
        /// <summary>
        /// Get all Dashboard Line Metrics 
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult<List<DashboardLineMetricsDto>>> GetDashboardLineMetrics([FromQuery] DateTime date)
        {
            try
            {
                var dashboardLineMetrics = await _reportBusiness.GetDashboardLineMetrics(date);
                return Ok(dashboardLineMetrics);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [Produces("application/json")]
        [HttpGet]
        [Route("dashboardmetrics")]
        /// <summary>
        /// Get all Dashboard metrics 
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult<List<DashboardMetricsDto>>> GetDashBoardMetrics([FromQuery] DateTime date)
        {
            try
            {
                var dashboardMetrics = await _reportBusiness.GetDashboardMetrics(date);
                return Ok(dashboardMetrics);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [Produces("application/json")]
        [HttpGet]
        [Route("dashboardshiftmetrics")]
        /// <summary>
        /// Get all Dashboard Shift Metrics 
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult<List<DashboardShiftMetricsDto>>> GetDashboardShiftMetrics([FromQuery] DateTime date)
        {
            try
            {
                var dashboardShiftMetrics = await _reportBusiness.GetDashboardShiftMetrics(date);
                return Ok(dashboardShiftMetrics);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [Produces("application/json")]
        [HttpGet]
        [Route("otregister")]
        /// <summary>
        /// Get all OT Register 
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult<List<OTRegisterDto>>> GetOTRegister([FromQuery] int month, [FromQuery] int year)
        {
            try
            {
                var oTRegisters = await _reportBusiness.GetOTRegister(month, year);
                return Ok(oTRegisters);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [Produces("application/json")]
        [HttpGet]
        [Route("vendorpayable")]
        /// <summary>
        /// Get all Vendor payable 
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult<List<VendorPayableDto>>> GetVendorPayable([FromQuery] int month, [FromQuery] int year)
        {
            try
            {
                var vendorPayables = await _reportBusiness.GetVendorPayable(month, year);
                return Ok(vendorPayables);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [Produces("application/json")]
        [HttpGet]
        [Route("wagesheetregister")]
        /// <summary>
        /// Get all Wage Sheet Register 
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult<List<WageSheetRegisterDto>>> GetWageSheetRegister([FromQuery] int month, [FromQuery] int year)
        {
            try
            {
                var wageSheetRegisters = await _reportBusiness.GetWageSheetRegister(month, year);
                return Ok(wageSheetRegisters);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Upload Report
        /// </summary>
        /// <param name="folder_name"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [HttpPost]
        [Route("upload_file")]
        public async Task<ActionResult> Create([FromForm] string folder_name = "")
        {
            try
            {
                var dirPath = UPLOAD_DIRECTORY;
                if (!string.IsNullOrWhiteSpace(folder_name))
                {
                    var dirToCreate = Path.Combine(UPLOAD_DIRECTORY, folder_name);
                    if (!Directory.Exists(dirToCreate))
                    {
                        Directory.CreateDirectory(dirToCreate);
                    }
                }
                var files = Request.Form.Files;
                if (files.Count == 0)
                {
                    return BadRequest("Atleast one file is expected to upload");
                }

                List<string> filePaths = new List<string>();
                bool isRootFolder = string.IsNullOrWhiteSpace(folder_name);
                foreach (var file in files)
                {
                    var filePath = file.FileName;
                    if (!isRootFolder)
                    {
                        filePath = Path.Combine(folder_name, file.FileName);
                    }
                    var fullPath = Path.Combine(dirPath, filePath);
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                        filePaths.Add(filePath);
                    }
                }

                return Ok(JsonConvert.SerializeObject(filePaths));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Returns document content to display on UI or download
        /// </summary>
        /// <param name="relativePath"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("get_file")]
        public async Task<ActionResult> GetFile([FromQuery] string relativePath)
        {
            try
            {
                string filePath = Path.Combine(UPLOAD_DIRECTORY, relativePath);
                if (System.IO.File.Exists(filePath))
                {
                    byte[] fileBytes = await System.IO.File.ReadAllBytesAsync(filePath);
                    return File(fileBytes, "application/force-download", System.IO.Path.GetFileName(filePath));
                }

                return StatusCode(404, "Could not find the document");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
