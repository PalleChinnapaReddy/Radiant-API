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
    public class EmployeeSalaryController : ControllerBase
    {
        private readonly IGenericBusiness<EmployeeSalaryDto> _employeeSalaryBusiness;
        private readonly ILogger<EmployeeSalaryController> _logger;

        public EmployeeSalaryController(IGenericBusiness<EmployeeSalaryDto> employeeSalaryBusiness
            , ILogger<EmployeeSalaryController> logger)
        {
            _employeeSalaryBusiness = employeeSalaryBusiness;
            _logger = logger;
        }

        /// <summary>
        /// Get all EmployeeSalaries
        /// </summary>
        /// <returns></returns>
        [Produces("application/json")]
        [HttpGet]
        public async Task<ActionResult<List<EmployeeSalaryDto>>> GetAll()
        {
            try
            {
                var employeeSalaries = await _employeeSalaryBusiness.GetAll();
                return Ok(employeeSalaries);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Get EmployeeSalary by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [Route("{id}")]
        [HttpGet]
        public async Task<ActionResult<EmployeeSalaryDto>> GetEmployeeSalaryById(int id)
        {
            try
            {
                _logger.LogInformation("Get EmployeeSalary by id");
                var employeeSalary = await _employeeSalaryBusiness.GetById(id);
                return Ok(employeeSalary);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Create EmployeeSalary
        /// </summary>
        /// <param name="employeeSalary"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] EmployeeSalaryDto employeeSalary)
        {
            try
            {
                var createdRecord = await _employeeSalaryBusiness.Create(employeeSalary);
                return Ok(createdRecord);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        /// <summary>
        /// Edit EmployeeSalary
        /// </summary>
        /// <param name="employeeSalary"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [HttpPut]
        public async Task<ActionResult> EditEmployeeSalary([FromBody] EmployeeSalaryDto employeeSalary)
        {
            try
            {
                var updatedRecord = await _employeeSalaryBusiness.Edit(employeeSalary);
                return Ok(updatedRecord);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Delete EmployeeSalary
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [Route("{id}")]
        [HttpDelete]
        public async Task<ActionResult> DeleteEmployeeSalary(int id)
        {
            try
            {
                await _employeeSalaryBusiness.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
