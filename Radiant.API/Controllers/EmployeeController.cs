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
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radiant.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeBusiness _employeeBusiness;
        private readonly IReportBusiness _reportBusiness;
        private readonly ILogger<EmployeeController> _logger;

        public EmployeeController(IEmployeeBusiness employeeBusiness
            , IReportBusiness reportBusiness
            , ILogger<EmployeeController> logger)
        {
            _employeeBusiness = employeeBusiness;
            _reportBusiness = reportBusiness;
            _logger = logger;
        }

        /// <summary>
        /// Get all Employees
        /// </summary>
        /// <returns></returns>
        [Produces("application/json")]
        [HttpGet]
        public async Task<ActionResult<List<EmployeeDto>>> GetAll()
        {
            try
            {
                var Employees = await _employeeBusiness.GetAll();
                return Ok(Employees);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Get all Employees
        /// </summary>
        /// <returns></returns>
        [Produces("application/json")]
        [Route("EmployeesByStatus")]
        [HttpGet]
        public async Task<ActionResult<List<EmployeeDto>>> GetAll(bool status)
        {
            try
            {
                var Employees = await _employeeBusiness.GetAll(status);
                return Ok(Employees);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Get Employee by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [Route("{id}")]
        [HttpGet]
        public async Task<ActionResult<EmployeeDto>> GetEmployeeById(int id)
        {
            try
            {
                _logger.LogInformation("Get Employee by id");
                var Employee = await _employeeBusiness.GetById(id);
                return Ok(Employee);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Create Employee
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] EmployeeDto employee)
        {
            try
            {
                var createdRecord = await _employeeBusiness.Create(employee);
                return Ok(createdRecord);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        /// <summary>
        /// Edit Employee
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [HttpPut]
        public async Task<ActionResult> EditEmployee([FromBody] EmployeeDto employee)
        {
            try
            {
                if (employee.CurrentLinemanagerid.HasValue)
                {
                    if (employee.Empid == employee.CurrentLinemanagerid)
                    {
                        return BadRequest("Cannot assing yourself as Manager");
                    }

                    var empHierarchy = await _reportBusiness.GetEmpHierarchy(employee.CurrentLinemanagerid.Value);
                    if (empHierarchy.Any(e => e.ManagerId.GetValueOrDefault() == employee.Empid))
                    {
                        return BadRequest($"Couldn't perform the operation. Employee's(Name:{employee.Firstname} + {employee.Lastname}-Id:{employee.Empid}) Hierarchy is greater than the Manager's(Name:{employee.CurrentLinemanager?.Firstname + employee.CurrentLinemanager?.Lastname}-Id:{employee.CurrentLinemanager?.Empid}) Hierarchy.");
                    }
                }

                //employee.Password = BCrypt.Net.BCrypt.HashPassword(employee.Password);
                var updatedRecord = await _employeeBusiness.Edit(employee);
                return Ok(updatedRecord);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Delete Employee
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [Route("{id}")]
        [HttpDelete]
        public async Task<ActionResult> DeleteEmployee(int id)
        {
            try
            {
                var activeEmployees = await _employeeBusiness.Search(new EmployeeSearchDto { CurrentLinemanagerid = id, PageSize = 1, Status = true });
                if (activeEmployees.TotalRows != 0)
                {
                    return BadRequest("Cannot delete the Employee. The given Employee has active reportees.");
                }
                await _employeeBusiness.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Deletes the Employee
        /// </summary>
        /// <param name="employeeDeleteDto"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [Route("deleteemployeebybody")]
        [HttpPost]
        public async Task<ActionResult> DeleteEmployeeByBody([FromBody] EmployeeDeleteDto employeeDeleteDto)
        {
            try
            {
                var activeEmployees = await _employeeBusiness.Search(new EmployeeSearchDto { CurrentLinemanagerid = employeeDeleteDto.Empid, PageSize = 1, Status = true });
                if (activeEmployees.TotalRows != 0)
                {
                    return BadRequest("Cannot delete the Employee. The given Employee has active reportees.");
                }
                await _employeeBusiness.Delete(employeeDeleteDto);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Get all products
        /// </summary>
        /// <returns></returns>
        [Produces("application/json")]
        [Route("Search")]
        [HttpGet]
        public async Task<ActionResult<EmployeeSearchResponseDto>> SearchEmployees([FromQuery] EmployeeSearchDto searchDto)
        {
            try
            {
                var userId = searchDto.ManagerId.HasValue ? searchDto.ManagerId.Value : long.Parse(HttpContext.User.FindFirst("UserId")?.Value);
                var empDetails = await _employeeBusiness.GetById(userId);
                if (empDetails.CurrentRole.Roledetails.Equals("HR Admin") ||
                    empDetails.CurrentRole.Roledetails.Equals("Super Admin"))
                {
                    searchDto.CurrentLinemanagerid = default(long?);
                }
                else
                {
                    searchDto.CurrentLinemanagerid = userId;
                }
                var employees = await _employeeBusiness.Search(searchDto);
                return Ok(employees);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Get Employees with given ids
        /// </summary>
        /// <returns></returns>
        [Produces("application/json")]
        [Route("BulkSearch")]
        [HttpPost]
        public async Task<ActionResult<EmployeeSearchResponseDto>> BulkSearchEmployees([FromBody] BulkSearch bulkSearch)
        {
            try
            {
                long? managerId = long.Parse(HttpContext.User.FindFirst("UserId")?.Value);
                var empDetails = await _employeeBusiness.GetById(managerId.Value);
                if (empDetails.CurrentRole.Roledetails.Equals("HR Admin") ||
                    empDetails.CurrentRole.Roledetails.Equals("Super Admin"))
                {
                    managerId = default(long?);
                }
                var employees = await _employeeBusiness.GetAll(managerId, bulkSearch.EmployeeIds.Trim());
                return Ok(employees);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Get Employees By Role
        /// </summary>
        /// <returns></returns>
        [Produces("application/json")]
        [Route("GetEmployeesByRole/{roleName}")]
        [HttpGet]
        public async Task<ActionResult<List<DropdownValueDto>>> GetEmployeesByRole(string roleName)
        {
            try
            {
                var employees = await _employeeBusiness.GetEmployeesByRoleName(roleName);
                return Ok(employees);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Get Employees By Role
        /// </summary>
        /// <returns></returns>
        [Produces("application/json")]
        [Route("GetManagersByDepartment/{departmentId}")]
        [HttpGet]
        public async Task<ActionResult<List<DropdownValueDto>>> GetManagersByDepartment(int? departmentId)
        {
            try
            {
                var employees = await _employeeBusiness.GetManagersByDepartment(departmentId);
                return Ok(employees);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        /// <summary>
        /// Get Employees By Shift
        /// </summary>
        /// <returns></returns>
        [Produces("application/json")]
        [Route("GetEmployeesByShift/{shiftId}")]
        [HttpGet]
        public async Task<ActionResult<List<EmployeeDto>>> GetEmployeesByShift(long shiftId)
        {
            try
            {
                var employees = await _employeeBusiness.GetEmployeesByShift(shiftId);
                return Ok(employees);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Change Password for Employee
        /// </summary>
        /// <returns></returns>
        [Produces("application/json")]
        //[Authorize(Roles = "HR Admin, Super Admin")]
        [Route("ChangePasswordByEmployeeId")]
        [HttpPost]
        public async Task<ActionResult<bool>> ChangePasswordByEmployeeId(ChangePassword obj)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(obj.Password))
                {
                    obj.Password = BCrypt.Net.BCrypt.HashPassword(obj.Password);
                }
                else
                {
                    return BadRequest();
                }
                var status = await _employeeBusiness.ChangePasswordByEmployeeId(obj.EId, obj.Password);
                return Ok(status);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Get Employees for LineDashboard
        /// </summary>
        /// <param name="searchDto"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [Route("LineDashboardData")]
        [HttpGet]
        public async Task<ActionResult<EmployeeLinesDashboardResponseDto>> GetLineDashboardData([FromQuery] EmployeeLinesDashboardSearchDto searchDto)
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
                var employees = await _employeeBusiness.GetLineDashboardData(searchDto);
                return Ok(employees);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bulkEditDto"></param>
        /// <returns></returns>
        /// [Produces("application/json")]
        [Route("BulkEdit")]
        [HttpPost]
        public async Task<ActionResult> BulkEdit([FromBody] EmployeeBulkEditDto bulkEditDto)
        {
            try
            {
                if (bulkEditDto.ManagerId.HasValue)
                {
                    var empHierarchy = await _reportBusiness.GetEmpHierarchy(bulkEditDto.ManagerId.Value);
                    foreach (var empId in bulkEditDto.Empids)
                    {
                        if (empHierarchy.Any(e => e.ManagerId.GetValueOrDefault() == empId))
                        {
                            return BadRequest($"Couldn't perform the operation. Employee with Id:{empId} Hierarchy is greater than the Manager Hierarchy with Id:{bulkEditDto.ManagerId}.");
                        }
                    }
                }

                await _employeeBusiness.BulkEdit(bulkEditDto);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Updates all dependencies for the specified Attribute
        /// </summary>
        /// <param name="updateDependencyDto"></param>
        /// <returns></returns>
        [Route("UpdateDependency")]
        [HttpPost]
        public async Task<ActionResult> UpdateDependencies([FromBody] UpdateDependencyDto updateDependencyDto)
        {
            try
            {
                await _employeeBusiness.UpdateDependencies(updateDependencyDto);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Route("UpdateEmptyEmployees")]
        [HttpGet]
        public async Task<ActionResult> UpdateEmptyEmployees()
        {
            try
            {
                StringBuilder responseMessage = new StringBuilder();
                var employees = await _employeeBusiness.GetAll();
                foreach (var employee in employees.Where(e => string.IsNullOrWhiteSpace(e.Firstname) && string.IsNullOrWhiteSpace(e.Lastname)))
                {
                    try
                    {
                        await _employeeBusiness.Edit(employee, skipValidations: true);
                    }
                    catch (Exception ex)
                    {
                        responseMessage.AppendLine($"Couldn't update the employee with Id:{employee.Empid}. Details:{ex.Message}");
                    }

                }
                return Ok(responseMessage.ToString());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Deletes the Employees
        /// </summary>
        /// <param name="bulkDeleteDto"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [Route("BulkDelete")]
        [HttpPost]
        public async Task<ActionResult> BulkDelete([FromBody] EmployeeBulkDeleteDto bulkDeleteDto)
        {
            try
            {
                await _employeeBusiness.Delete(bulkDeleteDto);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Reactivates the Employees
        /// </summary>
        /// <param name="bulkReactivateDto"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [Route("BulkReactivate")]
        [HttpPost]
        public async Task<ActionResult> BulkReactivate([FromBody] BulkReactivateDto bulkReactivateDto)
        {
            try
            {
                await _employeeBusiness.Reactivate(bulkReactivateDto);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Returns the Employees of the Manager
        /// </summary>
        /// <param name="managerId"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [Route("GetEmployeesByManager")]
        [HttpGet]
        public async Task<ActionResult> GetEmployeesByManager([FromQuery] long? managerId)
        {
            try
            {
                if (!managerId.HasValue)
                {
                    managerId = long.Parse(HttpContext.User.FindFirst("UserId")?.Value);
                }

                var empDetails = await _employeeBusiness.GetById(managerId.Value);
                if (empDetails.CurrentRole.Roledetails.Equals("HR Admin") ||
                    empDetails.CurrentRole.Roledetails.Equals("Super Admin"))
                {
                    managerId = default(long?);
                }
                var employeeDropdownValues = await _employeeBusiness.GetEmployeesByManager(managerId);
                return Ok(employeeDropdownValues);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Returns the Employees of the Manager
        /// </summary>
        /// <param name="managerId"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [Route("Get3rdPartyEmployees")]
        [HttpGet]
        public async Task<ActionResult> Get3rdPartyEmployees([FromQuery] long? managerId)
        {
            try
            {
                if (!managerId.HasValue)
                {
                    managerId = long.Parse(HttpContext.User.FindFirst("UserId")?.Value);
                }

                var empDetails = await _employeeBusiness.GetById(managerId.Value);
                if (empDetails.CurrentRole.Roledetails.Equals("HR Admin") ||
                    empDetails.CurrentRole.Roledetails.Equals("Super Admin"))
                {
                    managerId = default(long?);
                }
                var employeeDropdownValues = await _employeeBusiness.Get3rdPartyEmployees(managerId);
                return Ok(employeeDropdownValues);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
