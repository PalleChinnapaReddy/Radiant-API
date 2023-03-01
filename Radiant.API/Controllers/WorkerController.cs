using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using Radiant.Business.Contracts;
using Radiant.Business.Models;
using Radiant.Business.Models.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Radiant.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkerController : ControllerBase
    {
        const string EMPLOYEE_URL = "http://10.101.252.24:8090/api/Attendance/GetEmployeesByDateRange?Fromdate={0}&Todate={1}&Status=Yes";
        const string GET_EMPLOYEE_URL = "http://10.101.252.24:8090/api/Attendance/GetEmployees/";
        const string ATTENDANCE_URL = "http://10.101.252.24:8090/api/Attendance/GetLogs?Fromdate={0}&Todate={1}&Readerno=ALL&Ioflg=ALL";

        private readonly IEmployeeBusiness _employeeBusiness;
        private readonly IEmployeeAttendanceRefreshBusiness _employeeAttendanceRefreshBusiness;
        private readonly IReportBusiness _reportBusiness;
        private readonly ILogger<WorkerController> _logger;
        private HttpClient _httpClient;

        public WorkerController(IEmployeeBusiness employeeBusiness,
            IEmployeeAttendanceRefreshBusiness employeeAttendanceRefreshBusiness,
            IReportBusiness reportBusiness
            , ILogger<WorkerController> logger)
        {
            _employeeBusiness = employeeBusiness;
            _employeeAttendanceRefreshBusiness = employeeAttendanceRefreshBusiness;
            _reportBusiness = reportBusiness;
            _logger = logger;
        }

        /// <summary>
        /// Updates RadiantDb with Employee and Attendance Data
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> UpdateRadiantData()
        {
            try
            {
                var startTime = Request.Form["startTime"].ToString();
                var endTime = Request.Form["endTime"].ToString();
                _logger.LogInformation($"Invoked WorkerController for daterange {startTime} & {endTime}");
                await UpdateEmployees(startTime, endTime);

                await UpdateEmployeeAttendances(startTime, endTime);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while updating the attendance. Details:{ex.Message}");
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Updates RadiantDb with EmployeeData
        /// </summary>
        /// <returns></returns>

        [HttpPost]
        [Route("updateemployees")]
        public async Task<ActionResult> UpdateEmployees([FromBody] DateRangeDto dateRange)
        {
            try
            {
                var startDate = dateRange.StartDate.ToString("dd-MMMM-yyyy HH:mm:ss");
                var endDate = dateRange.EndDate.ToString("dd-MMMM-yyyy HH:mm:ss");
                _logger.LogInformation($"Invoked UpdateEmployees for daterange {startDate} & {endDate}");
                await UpdateEmployees(startDate, endDate);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while updating the employeeData. Details:{ex.Message}");
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Updates RadiantDb with AttendanceData
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("updateattendance")]
        public async Task<ActionResult> UpdateAttendance([FromBody] DateRangeDto dateRange)
        {
            try
            {
                var startDate = dateRange.StartDate.ToString("dd-MMMM-yyyy HH:mm:ss");
                var endDate = dateRange.EndDate.ToString("dd-MMMM-yyyy HH:mm:ss");
                _logger.LogInformation($"Invoked UpdateAttendance for daterange {startDate} & {endDate}");
                await UpdateEmployeeAttendances(startDate, endDate);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while updating the employeeData. Details:{ex.Message}");
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        [Route("bulk")]
        public async Task<ActionResult> UpdateRadiantBulkData([FromBody] DateRangeDto dateRange)
        {
            try
            {
                var startTime = dateRange.StartDate.ToString("dd-MMMM-yyyy HH:mm:ss");
                var endTime = dateRange.EndDate.ToString("dd-MMMM-yyyy HH:mm:ss");
                await UpdateEmployees(startTime, endTime);

                await UpdateEmployeeAttendancesForBulk(startTime, endTime);
                return Ok($"Data Loaded Successfuly from biometrics from {startTime} to {endTime}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while updating the attendance. Details:{ex.Message}");
                return StatusCode(500, ex.Message);
            }
        }

        private async Task UpdateEmployees(string startTime, string endTime)
        {
            List<EmployeeDto> employeeDtos = new List<EmployeeDto>();
            using (_httpClient = new HttpClient())
            {
                _logger.LogInformation($"Fetching Employee data for the date range: {startTime} and {endTime}");
                var responseMessage = await _httpClient.GetAsync(string.Format(EMPLOYEE_URL, startTime, endTime));
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseString = await responseMessage.Content.ReadAsStringAsync();
                    var responseContent = JArray.Parse(responseString);
                    foreach (var item in responseContent[0]["data"])
                    {
                        try
                        {
                            var employee = new EmployeeDto();
                            employee.Empcode = Convert.ToInt64(item["emp_Code"]);
                            employee.Dateofjoining = DateTime.ParseExact(item["doj"].ToString(), "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture);
                            employeeDtos.Add(employee);
                        }
                        catch (Exception ex)
                        {
                            _logger.LogError(ex, $"Failed to parse Employee Data: EmpCode{item["emp_Code"]}. DOJ:{item["doj"]}");
                        }
                    }
                    _logger.LogInformation($"Fetched Employee data: RowCount:{employeeDtos.Count}");
                }
                else
                {
                    _logger.LogError($"Failed to fetch Employees data for the date range: {startTime} & {endTime}");
                }
            }

            if (employeeDtos.Count != 0)
            {
                await _employeeBusiness.Create(employeeDtos);
            }

        }

        private async Task UpdateEmployeeAttendances(string startTime, string endTime)
        {
            var batchId = DateTime.Now.Ticks;
            List<EmployeeattendancerefreshDto> employeeAttendanceDtos = new List<EmployeeattendancerefreshDto>();
            List<EmployeeDto> employeeDtos = new List<EmployeeDto>();
            using (_httpClient = new HttpClient())
            {
                _logger.LogInformation($"Fetching EmployeeAttendance data for the date range: {startTime} and {endTime}");
                var responseMessage = await _httpClient.GetAsync(string.Format(ATTENDANCE_URL, startTime, endTime));
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseString = await responseMessage.Content.ReadAsStringAsync();
                    var responseContent = JArray.Parse(responseString);
                    foreach (var item in responseContent[0]["data"])
                    {
                        employeeDtos.Add(new EmployeeDto { Empcode = Convert.ToInt64(item["emp_Code"]) });
                        employeeAttendanceDtos.Add(new EmployeeattendancerefreshDto
                        {
                            EmpCode = Convert.ToInt64(item["emp_Code"]),
                            Time = DateTime.ParseExact(item["time"].ToString(), "M/d/yyyy h:mm:ss tt", System.Globalization.CultureInfo.InvariantCulture),
                            Readerno = Convert.ToInt64(item["readerno"]),
                            Readername = item["readername"].ToString(),
                            Io = item["io"].ToString(),
                            Batchid = batchId
                        });
                    }
                    _logger.LogInformation($"Fetched Attendance data: RowCount:{employeeAttendanceDtos.Count}");
                }
                else
                {
                    _logger.LogError($"Failed to fetch Employees data for the date range: {startTime} & {endTime}");
                }
            }

            if (employeeDtos.Count != 0)
            {
                await UpdateExistingEmployees(employeeDtos);

            }

            if (employeeAttendanceDtos.Count != 0)
            {
                await _employeeAttendanceRefreshBusiness.RefreshPostGreAttendance(employeeAttendanceDtos);
                await _reportBusiness.EmpAttendanceRefreshSync(new EmpAttendanceRefreshRequestDto { BatchId = batchId });
            }
        }

        private async Task UpdateExistingEmployees(List<EmployeeDto> employeeDtos)
        {
            employeeDtos = _employeeBusiness.GetNewEmployees(employeeDtos.Distinct().ToList());
            if (employeeDtos != null && employeeDtos.Count != 0)
            {
                foreach (var employee in employeeDtos)
                {
                    using (_httpClient = new HttpClient())
                    {
                        _logger.LogInformation($"Fetching Employee data for the Employee:{employee.Empcode}");
                        var responseMessage = await _httpClient.GetAsync(GET_EMPLOYEE_URL + employee.Empcode);
                        if (responseMessage.IsSuccessStatusCode)
                        {
                            var responseString = await responseMessage.Content.ReadAsStringAsync();
                            var responseContent = JArray.Parse(responseString);
                            employee.Dateofjoining = DateTime.ParseExact(responseContent[0]["data"][0]["doj"].ToString(), "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture);
                        }
                        else
                        {
                            _logger.LogError($"Failed to fetch Employees data for the Employee:{employee.Empcode}");
                        }
                    }
                }

                await _employeeBusiness.Create(employeeDtos);
            }
        }

        private async Task UpdateEmployeeAttendancesForBulk(string startTime, string endTime)
        {
            List<EmployeeattendancerefreshDto> employeeAttendanceDtos = new List<EmployeeattendancerefreshDto>();
            var startDate = DateTime.Parse(startTime);
            var finalEndDate = DateTime.Parse(endTime);

            using (_httpClient = new HttpClient())
            {
                var responseMessage = await _httpClient.GetAsync(string.Format(ATTENDANCE_URL, startDate.ToString("dd-MMMM-yyyy HH:mm:ss"), finalEndDate.ToString("dd-MMMM-yyyy HH:mm:ss")));
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseString = await responseMessage.Content.ReadAsStringAsync();
                    var responseContent = JArray.Parse(responseString);
                    foreach (var item in responseContent[0]["data"])
                    {
                        employeeAttendanceDtos.Add(new EmployeeattendancerefreshDto
                        {
                            EmpCode = Convert.ToInt64(item["emp_Code"]),
                            Time = DateTime.ParseExact(item["time"].ToString(), "M/d/yyyy h:mm:ss tt", System.Globalization.CultureInfo.InvariantCulture),
                            Readerno = Convert.ToInt64(item["readerno"]),
                            Readername = item["readername"].ToString(),
                            Io = item["io"].ToString()
                        });
                    }
                }
                else
                {
                    _logger.LogError($"Failed to fetch Employees data for the date range: {startDate} & {finalEndDate}");
                }

            }

            var endDate = startDate.AddHours(4);
            while (startDate <= finalEndDate)
            {
                var batchId = startDate.Ticks;
                var filterAttendanceDtos = employeeAttendanceDtos.Where(e => e.Time >= startDate && e.Time < endDate).ToList();
                filterAttendanceDtos.ForEach((x) => { x.Batchid = batchId; });

                if (filterAttendanceDtos.Count != 0)
                {
                    await _employeeAttendanceRefreshBusiness.RefreshPostGreAttendance(filterAttendanceDtos);
                    _logger.LogInformation("{0} - {1} number of records {2}", startDate, endDate, filterAttendanceDtos.Count);
                    await _reportBusiness.EmpAttendanceRefreshSync(new EmpAttendanceRefreshRequestDto { BatchId = batchId });
                }
                startDate = endDate;
                endDate = startDate.AddHours(4);
            }
        }
    }
}
