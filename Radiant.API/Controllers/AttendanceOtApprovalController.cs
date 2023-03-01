using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Radiant.Business.Contracts;
using Radiant.Business.Models;
using Radiant.Business.Models.FilterModels;
using Radiant.Business.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Radiant.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendanceOtApprovalController : ControllerBase
    {
        private readonly IAttendanceOTApprovalBusiness _attendanceOtApprovalBusiness;
        private readonly IEmployeeBusiness _employeeBusiness;
        private readonly ILogger<AttendanceOtApprovalController> _logger;

        public AttendanceOtApprovalController(IAttendanceOTApprovalBusiness attendanceOtApprovalBusiness
            , IEmployeeBusiness employeeBusiness
            , ILogger<AttendanceOtApprovalController> logger)
        {
            _attendanceOtApprovalBusiness = attendanceOtApprovalBusiness;
            _employeeBusiness = employeeBusiness;
            _logger = logger;
        }

        /// <summary>
        /// Get all AttendanceOtApprovals
        /// </summary>
        /// <returns></returns>
        [Produces("application/json")]
        [HttpGet]
        public async Task<ActionResult<List<AttendanceOtApprovalDto>>> GetAll()
        {
            try
            {

                var attendanceOtApprovals = await _attendanceOtApprovalBusiness.GetAll();
                return Ok(attendanceOtApprovals);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        /// <summary>
        /// Get all AttendanceOtApprovals By ManagerID
        /// </summary>
        /// <returns></returns>
        [Produces("application/json")]
        [HttpGet]
        [Route("requests")]
        public async Task<ActionResult<AttendanceOTApprovalResponseDto>> GetByManagerId([FromQuery] AttendanceOtSearchDto searchDto)
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
                var attendanceOtApprovals = await _attendanceOtApprovalBusiness.GetRequestsByManagerId(searchDto);
                return Ok(attendanceOtApprovals);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Get AttendanceOtApproval by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [Route("{id}")]
        [HttpGet]
        public async Task<ActionResult<AttendanceOtApprovalDto>> GetAttendanceOtApprovalById(int id)
        {
            try
            {
                _logger.LogInformation("Get AttendanceOtApproval by id");
                var attendanceOtApproval = await _attendanceOtApprovalBusiness.GetById(id);
                return Ok(attendanceOtApproval);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Create AttendanceOtApproval
        /// </summary>
        /// <param name="attendanceOtApproval"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] AttendanceOtApprovalDto attendanceOtApproval)
        {
            try
            {
                var createdRecord = await _attendanceOtApprovalBusiness.Create(attendanceOtApproval);
                return Ok(createdRecord);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        /// <summary>
        /// Edit AttendanceOtApproval
        /// </summary>
        /// <param name="attendanceOtApproval"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [HttpPut]
        public async Task<ActionResult> EditAttendanceOtApproval([FromBody] AttendanceOtApprovalDto attendanceOtApproval)
        {
            try
            {
                var updatedRecord = await _attendanceOtApprovalBusiness.Edit(attendanceOtApproval);
                return Ok(updatedRecord);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Delete AttendanceOtApproval
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [Route("{id}")]
        [HttpDelete]
        public async Task<ActionResult> DeleteAttendanceOtApproval(int id)
        {
            try
            {
                await _attendanceOtApprovalBusiness.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
