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
    public class EmployeeAttendanceRefreshController : ControllerBase
    {
        private readonly IEmployeeAttendanceRefreshBusiness _employeeAttendanceRefreshBusiness;
        private readonly ILogger<AbsenceReasonController> _logger;

        public EmployeeAttendanceRefreshController(IEmployeeAttendanceRefreshBusiness  employeeAttendanceRefreshBusiness
            , ILogger<AbsenceReasonController> logger)
        {
            _employeeAttendanceRefreshBusiness = employeeAttendanceRefreshBusiness;
            _logger = logger;
        }

        /// <summary>
        /// Add EmployeeAttendanceRefresh
        /// </summary>
        /// <param name="employeeattendancerefreshDtos"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] List<EmployeeattendancerefreshDto> employeeattendancerefreshDtos)
        {
            try
            {
                var createdRecord = await _employeeAttendanceRefreshBusiness.RefreshPostGreAttendance(employeeattendancerefreshDtos);
                return Ok(createdRecord);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


    }
}