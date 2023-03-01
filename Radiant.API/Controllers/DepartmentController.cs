using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Radiant.Business.Contracts;
using Radiant.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Radiant.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentBusiness _departmentBusiness;
        private readonly ILogger<DepartmentController> _logger;

        public DepartmentController(IDepartmentBusiness departmentBusiness
            , ILogger<DepartmentController> logger)
        {
            _departmentBusiness = departmentBusiness;
            _logger = logger;
        }

        /// <summary>
        /// Get all Departments
        /// </summary>
        /// <returns></returns>
        [Produces("application/json")]
        [HttpGet]
        public async Task<ActionResult<List<DepartmentDto>>> GetAll()
        {
            try
            {
                var departments = await _departmentBusiness.GetAll();
                return Ok(departments);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Get all Department Wise Report
        /// </summary>
        /// <returns></returns>
        [Produces("application/json")]
        [HttpGet]
        [Route("departmentwisereport")]
        public async Task<ActionResult<List<DepartmentWiseAttendanceReportDto>>> GetDepartmentWiseReport(DateTime date)
        {
            try
            {
                var departments = await _departmentBusiness.GetDepartmentWiseReport(date);
                return Ok(departments);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        /// <summary>
        /// Get Department by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [Route("{id}")]
        [HttpGet]
        public async Task<ActionResult<DepartmentDto>> GetDepartmentById(int id)
        {
            try
            {
                _logger.LogInformation("Get Department by id");
                var department = await _departmentBusiness.GetById(id);
                return Ok(department);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Create Department
        /// </summary>
        /// <param name="department"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] DepartmentDto department)
        {
            try
            {
                var existingDepartments = await _departmentBusiness.GetByParent(department.Parentdepartmentid);
                if (existingDepartments != null && existingDepartments.Any(d => d.Departmentdescription.Equals(department.Departmentdescription)))
                {
                    return BadRequest("Another department exists with same description");
                }

                var createdRecord = await _departmentBusiness.Create(department);
                return Ok(createdRecord);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        /// <summary>
        /// Edit Department
        /// </summary>
        /// <param name="department"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [HttpPut]
        public async Task<ActionResult> EditDepartment([FromBody] DepartmentDto department)
        {
            try
            {
                var existingDepartments = await _departmentBusiness.GetByParent(department.Parentdepartmentid);
                if (existingDepartments != null
                    && existingDepartments.Any(d => d.Departmentid != department.Departmentid && d.Departmentdescription.Equals(department.Departmentdescription)))
                {
                    return BadRequest("Another department exists with same description");
                }

                var updatedRecord = await _departmentBusiness.Edit(department);
                return Ok(updatedRecord);

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Delete Department
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [Route("{id}")]
        [HttpDelete]
        public async Task<ActionResult> DeleteDepartment(int id)
        {
            try
            {
                var lineId = await _departmentBusiness.GetLineIdFromMapping(id);
                if (lineId.HasValue)
                {
                    return BadRequest("Cannot delete the Department as it has active LineId");
                }
                var department = await _departmentBusiness.GetById(id);
                if (department.EmployeeCount > 0)
                {
                    return BadRequest("Cannot delete the department. The given department has active employees.");
                }
                await _departmentBusiness.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
