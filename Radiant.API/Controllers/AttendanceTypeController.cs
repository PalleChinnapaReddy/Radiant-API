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
    public class AttendanceTypeController : ControllerBase
    {
        private readonly IGenericBusiness<AttendancetypeDto> _attendanceTypeBusiness;
        private readonly ILogger<AttendanceTypeController> _logger;

        public AttendanceTypeController(IGenericBusiness<AttendancetypeDto> attendanceTypeBusiness
            , ILogger<AttendanceTypeController> logger)
        {
            _attendanceTypeBusiness = attendanceTypeBusiness;
            _logger = logger;
        }

        /// <summary>
        /// Get all Attendancetypes
        /// </summary>
        /// <returns></returns>
        [Produces("application/json")]
        [HttpGet]
        public async Task<ActionResult<List<AttendancetypeDto>>> GetAll()
        {
            try
            {
                var attendancetypes = await _attendanceTypeBusiness.GetAll();
                return Ok(attendancetypes);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}