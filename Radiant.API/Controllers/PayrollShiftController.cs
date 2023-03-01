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
    public class PayrollShiftController : ControllerBase
    {
        private readonly IPayrollShiftBusiness _payrollShiftBusiness;
        private readonly IShiftBusiness _shiftBusiness;
        private readonly ILogger<PayrollShiftController> _logger;

        public PayrollShiftController(IPayrollShiftBusiness payrollShiftBusiness
            , IShiftBusiness shiftBusiness
            , ILogger<PayrollShiftController> logger)
        {
            _shiftBusiness = shiftBusiness;
            _payrollShiftBusiness = payrollShiftBusiness;
            _logger = logger;
        }

        /// <summary>
        /// Get all Shifts
        /// </summary>
        /// <returns></returns>
        [Produces("application/json")]
        [HttpGet]
        public async Task<ActionResult<List<PayrollshiftDto>>> GetAll()
        {
            try
            {
                var shifts = await _payrollShiftBusiness.GetAll();
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
        public async Task<ActionResult<PayrollshiftDto>> GetShiftById(int id)
        {
            try
            {
                _logger.LogInformation("Get Shift by id");
                var shift = await _payrollShiftBusiness.GetById(id);
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
        public async Task<ActionResult> Create([FromBody] PayrollshiftDto shift)
        {
            try
            {
                var createdRecord = await _payrollShiftBusiness.Create(shift);
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
        public async Task<ActionResult> EditShift([FromBody] PayrollshiftDto shift)
        {
            try
            {
                var updatedRecord = await _payrollShiftBusiness.Edit(shift);
                return Ok(updatedRecord);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Edit Shift
        /// </summary>
        /// <param name="shifts"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [HttpPut]
        [Route("editpayrollshifts")]
        public async Task<ActionResult> EditShift([FromBody] List<PayrollshiftDto> shifts)
        {
            try
            {
                if (shifts.Count > 0)
                {
                    foreach (var s in shifts)
                    {
                        if(s.Shiftactivedate.Value.Date < DateTime.Now.Date)
                        {
                            return BadRequest(String.Format("Cannot edit shifts for previous day {0} and name is {1}", s.Shiftactivedate, s.Shiftdetails));
                        }
                        var shift = shifts.Find(sh => sh.Payrollshiftid != s.Payrollshiftid
                                                && s.Shiftactivedate == sh.Shiftactivedate
                                                && s.Shiftstartthresholdfrom.Value.TotalMilliseconds >= sh.Shiftstartthresholdfrom.Value.TotalMilliseconds
                                                && s.Shiftstartthresholdfrom.Value.TotalMilliseconds <= sh.Shiftstartthresholdto.Value.TotalMilliseconds);
                        shift = shift != null? shifts.Find(sh => sh.Payrollshiftid != s.Payrollshiftid
                                                && s.Shiftactivedate == sh.Shiftactivedate
                                                && s.Shiftstartthresholdto.Value.TotalMilliseconds >= sh.Shiftstartthresholdfrom.Value.TotalMilliseconds
                                                && s.Shiftstartthresholdto.Value.TotalMilliseconds <= sh.Shiftstartthresholdto.Value.TotalMilliseconds):shift;
                        if(shift != null)
                        {
                            return BadRequest(String.Format("Conflicting Shift start time {0} with shift id {1} on date {2}", shift.Shiftstartthresholdfrom, shift.Shiftid, shift.Shiftactivedate));
                        }
                        else {
                            s.Isedited = true;
                            s.UpdatedOn = DateTime.Now;
                        }
                    }
                }
                var updatedRecord = await _payrollShiftBusiness.Edit(shifts);
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
        /// <param name="payrollshifts"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [Route("reset")]
        [HttpPost]
        public async Task<ActionResult> ResetPayrollShifts([FromBody]List<PayrollshiftDto> payrollshifts)
        {
            try
            {
                foreach(var payrollShift in payrollshifts)
                {
                    if(payrollShift.Isedited == true)
                    {
                        payrollShift.Isedited = false;
                        var shift = await _shiftBusiness.GetById((long)payrollShift.Shiftid);
                        if (shift != null)
                        {
                            payrollShift.Shiftstarttime = shift.Shiftstarttime;
                            payrollShift.Shiftstartthresholdfrom = shift.Shiftstartthresholdfrom;
                            payrollShift.Shiftstartthresholdto = shift.Shiftstartthresholdto;
                            payrollShift.Shiftstarttime = shift.Shiftstarttime;
                            payrollShift.Shiftendtime = shift.Shiftendtime;
                            payrollShift.Maxshiftendtime = shift.Shiftendtime;
                        }
                        payrollShift.Hours = null;
                        payrollShift.UpdatedOn = DateTime.Now;

                    }
                }
                var updatedShifts = await _payrollShiftBusiness.Edit(payrollshifts);
                return Ok(updatedShifts);
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
        public async Task<ActionResult<List<PayrollshiftDto>>> GetActiveShiftsByDate(DateTime dateTime)
        {
            try
            {
                var shifts = await _payrollShiftBusiness.GetActiveShiftsByDate(dateTime);
                return Ok(shifts);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
