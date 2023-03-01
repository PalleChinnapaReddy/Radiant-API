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
    public class EmployeeRoleTrackerController : ControllerBase
    {
        private readonly IGenericBusiness<EmployeeRoleTrackerDto> _employeeRoleTrackerBusiness;
        private readonly ILogger<EmployeeRoleTrackerController> _logger;

        public EmployeeRoleTrackerController(IGenericBusiness<EmployeeRoleTrackerDto> employeeRoleTrackerBusiness
            , ILogger<EmployeeRoleTrackerController> logger)
        {
            _employeeRoleTrackerBusiness = employeeRoleTrackerBusiness;
            _logger = logger;
        }

        /// <summary>
        /// Get all EmployeeRoleTrackers
        /// </summary>
        /// <returns></returns>
        [Produces("application/json")]
        [HttpGet]
        public async Task<ActionResult<List<EmployeeRoleTrackerDto>>> GetAll()
        {
            try
            {
                var employeeRoleTrackers = await _employeeRoleTrackerBusiness.GetAll();
                return Ok(employeeRoleTrackers);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Get EmployeeRoleTracker by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [Route("{id}")]
        [HttpGet]
        public async Task<ActionResult<EmployeeRoleTrackerDto>> GetEmployeeRoleTrackerById(int id)
        {
            try
            {
                _logger.LogInformation("Get EmployeeRoleTracker by id");
                var employeeRoleTracker = await _employeeRoleTrackerBusiness.GetById(id);
                return Ok(employeeRoleTracker);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Create EmployeeRoleTracker
        /// </summary>
        /// <param name="employeeRoleTracker"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] EmployeeRoleTrackerDto employeeRoleTracker)
        {
            try
            {
                var createdRecord = await _employeeRoleTrackerBusiness.Create(employeeRoleTracker);
                return Ok(createdRecord);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        /// <summary>
        /// Edit EmployeeRoleTracker
        /// </summary>
        /// <param name="employeeRoleTracker"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [HttpPut]
        public async Task<ActionResult> EditEmployeeRoleTracker([FromBody] EmployeeRoleTrackerDto employeeRoleTracker)
        {
            try
            {
                var updatedRecord = await _employeeRoleTrackerBusiness.Edit(employeeRoleTracker);
                return Ok(updatedRecord);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Delete EmployeeRoleTracker
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [Route("{id}")]
        [HttpDelete]
        public async Task<ActionResult> DeleteEmployeeRoleTracker(int id)
        {
            try
            {
                await _employeeRoleTrackerBusiness.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
