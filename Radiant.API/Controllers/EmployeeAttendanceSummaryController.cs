using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Radiant.Business.Contracts;
using Radiant.Business.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Radiant.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeAttendanceSummaryController : ControllerBase
    {
        private readonly IGenericBusiness<EmployeeAttendanceSummaryDto> _employeeAttendanceSummaryBusiness;
        private readonly ILogger<EmployeeAttendanceSummaryController> _logger;

        public EmployeeAttendanceSummaryController(IGenericBusiness<EmployeeAttendanceSummaryDto> employeeAttendanceSummaryBusiness
            , ILogger<EmployeeAttendanceSummaryController> logger)
        {
            _employeeAttendanceSummaryBusiness = employeeAttendanceSummaryBusiness;
            _logger = logger;
        }

        /// <summary>
        /// Get all EmployeeAttendanceSummaries
        /// </summary>
        /// <returns></returns>
        [Produces("application/json")]
        [HttpGet]
        public async Task<ActionResult<List<EmployeeAttendanceSummaryDto>>> GetAll()
        {
            try
            {
                var employeeAttendanceSummaries = await _employeeAttendanceSummaryBusiness.GetAll();
                return Ok(employeeAttendanceSummaries);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Get EmployeeAttendanceSummary by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [Route("{id}")]
        [HttpGet]
        public async Task<ActionResult<EmployeeAttendanceSummaryDto>> GetEmployeeAttendanceSummaryById(int id)
        {
            try
            {
                _logger.LogInformation("Get EmployeeAttendanceSummary by id");
                var employeeAttendanceSummary = await _employeeAttendanceSummaryBusiness.GetById(id);
                return Ok(employeeAttendanceSummary);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Create EmployeeAttendanceSummary
        /// </summary>
        /// <param name="employeeAttendanceSummary"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] EmployeeAttendanceSummaryDto employeeAttendanceSummary)
        {
            try
            {
                var createdRecord = await _employeeAttendanceSummaryBusiness.Create(employeeAttendanceSummary);
                return Ok(createdRecord);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        /// <summary>
        /// Edit EmployeeAttendanceSummary
        /// </summary>
        /// <param name="employeeAttendanceSummary"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [HttpPut]
        public async Task<ActionResult> EditEmployeeAttendanceSummary([FromBody] EmployeeAttendanceSummaryDto employeeAttendanceSummary)
        {
            try
            {
                var updatedRecord = await _employeeAttendanceSummaryBusiness.Edit(employeeAttendanceSummary);
                return Ok(updatedRecord);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Delete EmployeeAttendanceSummary
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [Route("{id}")]
        [HttpDelete]
        public async Task<ActionResult> DeleteEmployeeAttendanceSummary(int id)
        {
            try
            {
                await _employeeAttendanceSummaryBusiness.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
