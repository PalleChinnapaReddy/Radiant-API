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
    public class OtStatusController : ControllerBase
    {
        private readonly IGenericBusiness<OtStatusDto> _otStatusBusiness;
        private readonly ILogger<AbsenceReasonController> _logger;

        public OtStatusController(IGenericBusiness<OtStatusDto> otStatusBusiness
            , ILogger<AbsenceReasonController> logger)
        {
            _otStatusBusiness = otStatusBusiness;
            _logger = logger;
        }

        /// <summary>
        /// Get all OtStatus
        /// </summary>
        /// <returns></returns>
        [Produces("application/json")]
        [HttpGet]
        public async Task<ActionResult<List<OtStatusDto>>> GetAll()
        {
            try
            {
                var otStatuses = await _otStatusBusiness.GetAll();
                return Ok(otStatuses);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Get OtStatus by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [Route("{id}")]
        [HttpGet]
        public async Task<ActionResult<OtStatusDto>> GetOtStatusById(int id)
        {
            try
            {
                _logger.LogInformation("Get OtStatus by id");
                var otStatus= await _otStatusBusiness.GetById(id);
                return Ok(otStatus);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Create OtStatus
        /// </summary>
        /// <param name="otstatus"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] OtStatusDto otStatus)
        {
            try
            {
                var createdRecord = await _otStatusBusiness.Create(otStatus);
                return Ok(createdRecord);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        /// <summary>
        /// Edit AbsenceReason
        /// </summary>
        /// <param name="absenceReason"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [HttpPut]
        public async Task<ActionResult> EditOtStatus([FromBody] OtStatusDto otStatus )
        {
            try
            {
                var updatedRecord = await _otStatusBusiness.Edit(otStatus);
                return Ok(updatedRecord);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Delete OtStatus
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [Route("{id}")]
        [HttpDelete]
        public async Task<ActionResult> DeleteOtStatus(int id)
        {
            try
            {
                await _otStatusBusiness.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}