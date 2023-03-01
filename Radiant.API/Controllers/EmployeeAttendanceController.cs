using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Radiant.Business.Contracts;
using Radiant.Business.Models;
using Radiant.Business.Models.CustomizedAPI;
using Radiant.Business.Models.FilterModels;
using Radiant.Business.Models.Response;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Radiant.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeAttendanceController : ControllerBase
    {
        private readonly IEmployeeAttendanceBusiness _employeeAttendanceBusiness;
        private readonly ILogger<EmployeeAttendanceController> _logger;
        private readonly IEmployeeBusiness _employeeBusiness;

        public EmployeeAttendanceController(IEmployeeAttendanceBusiness employeeAttendanceBusiness,
            IEmployeeBusiness employeeBusiness
            , ILogger<EmployeeAttendanceController> logger)
        {
            _employeeAttendanceBusiness = employeeAttendanceBusiness;
            _employeeBusiness = employeeBusiness;
            _logger = logger;
        }

        /// <summary>
        /// Get all EmployeeAttendance
        /// </summary>
        /// <returns></returns>
        [Produces("application/json")]
        [HttpGet]
        public async Task<ActionResult<List<EmployeeAttendanceDto>>> GetAll()
        {
            try
            {
                var employeeAttendances = await _employeeAttendanceBusiness.GetAll();
                return Ok(employeeAttendances);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Get all EmployeeAttendanceReports
        /// </summary>
        /// <returns></returns>
        [Produces("application/json")]
        [HttpGet]
        [Route("headcountreport")]
        public async Task<ActionResult<List<EmployeeAttendanceDto>>> GetEmployeeAttendanceReports(string shift,DateTime date)
        {
            try
            {
                var employeeAttendances = await _employeeAttendanceBusiness.GetAttendanceReports(shift,date);
                return Ok(employeeAttendances);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Get EmployeeAttendance by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [Route("{id}")]
        [HttpGet]
        public async Task<ActionResult<EmployeeAttendanceDto>> GetEmployeeAttendanceById(int id)
        {
            try
            {
                _logger.LogInformation("Get EmployeeAttendance by id");
                var employeeAttendance = await _employeeAttendanceBusiness.GetById(id);
                return Ok(employeeAttendance);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Create EmployeeAttendance
        /// </summary>
        /// <param name="employeeAttendance"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] EmployeeAttendanceDto employeeAttendance)
        {
            try
            {
                var createdRecord = await _employeeAttendanceBusiness.Create(employeeAttendance);
                return Ok(createdRecord);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        /// <summary>
        /// Edit EmployeeAttendance
        /// </summary>
        /// <param name="employeeAttendance"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [HttpPut]
        public async Task<ActionResult> EditEmployeeAttendance([FromBody] EmployeeAttendanceDto employeeAttendance)
        {
            try
            {
                var updatedRecord = await _employeeAttendanceBusiness.Edit(employeeAttendance);
                return Ok(updatedRecord);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Delete EmployeeAttendance
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [Route("{id}")]
        [HttpDelete]
        public async Task<ActionResult> DeleteEmployeeAttendance(int id)
        {
            try
            {
                await _employeeAttendanceBusiness.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Get Employee attendance using filters
        /// </summary>
        /// <param name="searchDto"></param>
        /// <returns></returns>
        [Authorize]
        [Produces("application/json")]
        [Route("attendancebymanager")]
        [HttpGet]
        public async Task<ActionResult<EmployeeAttendanceResponseDto>> GetEmployeeAttendanceByManager([FromQuery] EmployeeAttendanceSearchDto searchDto)
        {
            try
            {
                var userId = searchDto.ManagerId.HasValue ? searchDto.ManagerId.Value : long.Parse(HttpContext.User.FindFirst("UserId")?.Value);
                var empDetails = await _employeeBusiness.GetById(userId);
                if (empDetails.CurrentRole.Roledetails.Equals("HR Admin") ||
                    empDetails.CurrentRole.Roledetails.Equals("Super Admin"))
                {
                    searchDto.ManagerId = default(long?);
                }
                var employeeAttendances = await _employeeAttendanceBusiness.GetEmployeeAttendanceByManager(searchDto);
                return Ok(employeeAttendances);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Get SelectedEmployeeDetails by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [Route("GetSelectedEmployeeDetails/{id}")]
        [HttpGet]
        public async Task<ActionResult<SelectedEmployeeDetailsDto>> GetSelectedEmployeeDetails(int id)
        {
            try
            {
                var employeeDetailsDto = await _employeeAttendanceBusiness.GetSelectedEmployeeDetails(id);
                return Ok(employeeDetailsDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
