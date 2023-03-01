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
    public class ShiftController : ControllerBase
    {
        private readonly IShiftBusiness _shiftBusiness;
        private readonly IEmployeeBusiness _employeeBusiness;
        private readonly ILogger<ShiftController> _logger;

        public ShiftController(IShiftBusiness shiftBusiness
            , IEmployeeBusiness employeeBusiness
            , ILogger<ShiftController> logger)
        {
            _shiftBusiness = shiftBusiness;
            _employeeBusiness = employeeBusiness;
            _logger = logger;
        }

        /// <summary>
        /// Get all Shifts
        /// </summary>
        /// <returns></returns>
        [Produces("application/json")]
        [HttpGet]
        public async Task<ActionResult<List<ShiftDto>>> GetAll()
        {
            try
            {
                var shifts = await _shiftBusiness.GetAll();
                return Ok(shifts);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Get Shift by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [Route("{id}")]
        [HttpGet]
        public async Task<ActionResult<ShiftDto>> GetShiftById(int id)
        {
            try
            {
                _logger.LogInformation("Get Shift by id");
                var shift = await _shiftBusiness.GetById(id);
                return Ok(shift);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Create Shift
        /// </summary>
        /// <param name="shift"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] ShiftDto shift)
        {
            try
            {
                if (shift.Shiftactivedate == shift.Shiftinactivedate && shift.Shiftstarttime == shift.Shiftendtime)
                {
                    return BadRequest("Shift Start and End dates cannot be the same");
                }
                var createdRecord = await _shiftBusiness.Create(shift);
                return Ok(createdRecord);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        /// <summary>
        /// Edit Shift
        /// </summary>
        /// <param name="shift"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [HttpPut]
        public async Task<ActionResult> EditShift([FromBody] ShiftDto shift)
        {
            try
            {
                var updatedRecord = await _shiftBusiness.Edit(shift);
                return Ok(updatedRecord);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Delete Shift
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [Route("{id}")]
        [HttpDelete]
        public async Task<ActionResult> DeleteShift(int id)
        {
            try
            {
                var shiftEmployees = await _employeeBusiness.Search(new EmployeeSearchDto { CurrentShiftid = id, PageSize = 1 });
                if (shiftEmployees.TotalRows != 0)
                {
                    return BadRequest("Cannot delete the Shift. The given Shift has active employees.");
                }
                var shift = await _shiftBusiness.GetById(id);
                if (shift.Shiftinactivedate < DateTime.Now.Date)
                {
                    return BadRequest("Please select active shift");
                }
                await _shiftBusiness.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Get active Shifts by date
        /// </summary>
        /// <returns></returns>
        [Produces("application/json")]
        [HttpGet]
        [Route("GetActiveShiftsByDate")]
        public async Task<ActionResult<List<ShiftDto>>> GetActiveShiftsByDate(DateTime dateTime)
        {
            try
            {
                var shifts = await _shiftBusiness.GetActiveShiftsByDate(dateTime);
                return Ok(shifts);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
