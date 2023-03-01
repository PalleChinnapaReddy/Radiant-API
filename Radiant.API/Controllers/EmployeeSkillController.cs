using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Radiant.Business.Contracts;
using Radiant.Business.Models;
using Radiant.Business.Models.FilterModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Radiant.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeSkillController : ControllerBase
    {
        private readonly IEmployeeSkillBusiness _employeeSkillBusiness;
        private readonly IEmployeeBusiness _employeeBusiness;
        private readonly ILogger<EmployeeSkillController> _logger;

        public EmployeeSkillController(IEmployeeSkillBusiness employeeSkillBusiness
            , IEmployeeBusiness employeeBusiness
            , ILogger<EmployeeSkillController> logger)
        {
            _employeeSkillBusiness = employeeSkillBusiness;
            _employeeBusiness = employeeBusiness;
            _logger = logger;
        }

        /// <summary>
        /// Get all EmployeeSkills
        /// </summary>
        /// <returns></returns>
        [Produces("application/json")]
        [HttpGet]
        public async Task<ActionResult<List<EmployeeSkillDto>>> GetAll()
        {
            try
            {
                var employeeSkills = await _employeeSkillBusiness.GetAll();
                return Ok(employeeSkills);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Get EmployeeSkill by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [Route("{id}")]
        [HttpGet]
        public async Task<ActionResult<EmployeeSkillDto>> GetEmployeeSkillById(int id)
        {
            try
            {
                _logger.LogInformation("Get EmployeeSkill by id");
                var employeeSkill = await _employeeSkillBusiness.GetById(id);
                return Ok(employeeSkill);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Create EmployeeSkill
        /// </summary>
        /// <param name="employeeSkill"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] EmployeeSkillDto employeeSkill)
        {
            try
            {
                var createdRecord = await _employeeSkillBusiness.Create(employeeSkill);
                return Ok(createdRecord);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        /// <summary>
        /// Edit EmployeeSkill
        /// </summary>
        /// <param name="employeeSkill"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [HttpPut]
        public async Task<ActionResult> EditEmployeeSkill([FromBody] EmployeeSkillDto employeeSkill)
        {
            try
            {
                var updatedRecord = await _employeeSkillBusiness.Edit(employeeSkill);
                return Ok(updatedRecord);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Delete EmployeeSkill
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [Route("{id}")]
        [HttpDelete]
        public async Task<ActionResult> DeleteEmployeeSkill(int id)
        {
            try
            {
                await _employeeSkillBusiness.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Get  Employee Skill Matrix
        /// </summary>
        /// <param name="searchDto"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [Route("getemployeeskillmatrixbymanager")]
        [HttpGet]
        public async Task<ActionResult> GetEmployeeSkillMatrix([FromQuery] EmployeeSkillSearchDto searchDto)
        {
            try
            {
                var userId = searchDto.ManagerId.HasValue ? searchDto.ManagerId.Value : long.Parse(HttpContext.User.FindFirst("UserId")?.Value);
                searchDto.ManagerId = userId;
                var employeeSkillMatrices = await _employeeSkillBusiness.GetEmployeeSkillMatrixByManagerId(searchDto);
                return Ok(employeeSkillMatrices);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        /// <summary>
        /// Get  Employee Skill Matrix by employeeid
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [Route("getemployeeskillmatrixbyemployee/{employeeId}")]
        [HttpGet]
        public async Task<ActionResult> GetEmployeeSkillMatrixByEmpId(long employeeId)
        {
            try
            {
                var employeeSkillMatrices = await _employeeSkillBusiness.GetEmployeeSkillMatrixByEmployeeId(employeeId);
                return Ok(employeeSkillMatrices);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        /// <summary>
        /// Delete EmployeeSkill
        /// </summary>
        /// <param name="employeeSkillRequestDto"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [Route("postempskill")]
        [HttpPost]
        public async Task<ActionResult> PostEmpSkill([FromBody] EmployeeSkillRequestDto employeeSkillRequestDto)
        {
            try
            {
                var empStatus = await _employeeSkillBusiness.PostEmpSkill(employeeSkillRequestDto);
                return Ok(empStatus);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Generates Skill Summary Report
        /// </summary>
        /// <param name="departmentId"></param>
        /// <param name="managerId"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [Route("GetSkillSummaryReport")]
        [HttpGet]
        public async Task<ActionResult> GetSkillSummaryReport([FromQuery] long? departmentId, [FromQuery] long? managerId, DateTime reportDate)
        {
            try
            {
                var userId = managerId.HasValue ? managerId.Value : long.Parse(HttpContext.User.FindFirst("UserId")?.Value);
                var empDetails = await _employeeBusiness.GetById(userId);
                if (empDetails.CurrentRole.Roledetails.Equals("HR Admin") ||
                    empDetails.CurrentRole.Roledetails.Equals("Super Admin"))
                {
                    managerId = default(long?);
                }

                var empSkillSummaries = await _employeeSkillBusiness.GetSkillSummaryReport(departmentId, managerId, reportDate);
                return Ok(empSkillSummaries);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}
