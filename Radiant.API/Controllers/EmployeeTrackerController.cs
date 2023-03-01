using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Radiant.Business.Contracts;
using Radiant.Business.Models;
using Radiant.Business.Models.CustomizedAPI;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Radiant.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeTrackerController : ControllerBase
    {
        private readonly IEmployeeTrackerBusiness _employeeTrackerBusiness;
        private readonly ILogger<EmployeeTrackerController> _logger;

        public EmployeeTrackerController(IEmployeeTrackerBusiness employeeTrackerBusiness
            , ILogger<EmployeeTrackerController> logger)
        {
            _employeeTrackerBusiness = employeeTrackerBusiness;
            _logger = logger;
        }

        /// <summary>
        /// Get all EmployeeTrackers
        /// </summary>
        /// <returns></returns>
        [Produces("application/json")]
        [HttpGet]
        public async Task<ActionResult<List<EmployeeTrackerDto>>> GetAll()
        {
            try
            {
                var employeeTrackers = await _employeeTrackerBusiness.GetAll();
                return Ok(employeeTrackers);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Get EmployeeTracker by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [Route("{id}")]
        [HttpGet]
        public async Task<ActionResult<EmployeeTrackerDto>> GetEmployeeTrackerById(int id)
        {
            try
            {
                _logger.LogInformation("Get EmployeeTracker by id");
                var employeeTracker = await _employeeTrackerBusiness.GetById(id);
                return Ok(employeeTracker);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Create EmployeeTracker
        /// </summary>
        /// <param name="employeeTracker"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] EmployeeTrackerDto employeeTracker)
        {
            try
            {
                var createdRecord = await _employeeTrackerBusiness.Create(employeeTracker);
                return Ok(createdRecord);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Create EmployeeTrackers
        /// </summary>
        /// <param name="employeeShiftUpdate"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [HttpPost]
        [Route("/CreateShift")]
        public async Task<ActionResult> CreateShift([FromBody] EmployeeShiftUpdate employeeShiftUpdate)
        {
            try
            {
                var createdRecord = await _employeeTrackerBusiness.CreateAll(employeeShiftUpdate);
                return Ok(createdRecord);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        /// <summary>
        /// Edit EmployeeTracker
        /// </summary>
        /// <param name="employeeTracker"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [HttpPut]
        public async Task<ActionResult> EditEmployeeTracker([FromBody] EmployeeTrackerDto employeeTracker)
        {
            try
            {
                var updatedRecord = await _employeeTrackerBusiness.Edit(employeeTracker);
                return Ok(updatedRecord);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Delete EmployeeTracker
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [Route("{id}")]
        [HttpDelete]
        public async Task<ActionResult> DeleteEmployeeTracker(int id)
        {
            try
            {
                await _employeeTrackerBusiness.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
