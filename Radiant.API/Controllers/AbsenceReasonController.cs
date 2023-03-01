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
    public class AbsenceReasonController : ControllerBase
    {
        private readonly IGenericBusiness<AbsenceReasonDto> _absenceReasonBusiness;
        private readonly ILogger<AbsenceReasonController> _logger;

        public AbsenceReasonController(IGenericBusiness<AbsenceReasonDto> absenceReasonBusiness
            , ILogger<AbsenceReasonController> logger)
        {
            _absenceReasonBusiness = absenceReasonBusiness;
            _logger = logger;
        }

        /// <summary>
        /// Get all AbsenceReasons
        /// </summary>
        /// <returns></returns>
        [Produces("application/json")]
        [HttpGet]
        public async Task<ActionResult<List<AbsenceReasonDto>>> GetAll()
        {
            try
            {
                var absenceReasons = await _absenceReasonBusiness.GetAll();
                return Ok(absenceReasons);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Get AbsenceReason by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [Route("{id}")]
        [HttpGet]
        public async Task<ActionResult<AbsenceReasonDto>> GetAbsenceReasonById(int id)
        {
            try
            {
                _logger.LogInformation("Get AbsenceReason by id");
                var absenceReason = await _absenceReasonBusiness.GetById(id);
                return Ok(absenceReason);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Create AbsenceReason
        /// </summary>
        /// <param name="absenceReason"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] AbsenceReasonDto absenceReason)
        {
            try
            {
                var createdRecord = await _absenceReasonBusiness.Create(absenceReason);
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
        public async Task<ActionResult> EditAbsenceReason([FromBody] AbsenceReasonDto absenceReason)
        {
            try
            {
                var updatedRecord = await _absenceReasonBusiness.Edit(absenceReason);
                return Ok(updatedRecord);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Delete AbsenceReason
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [Route("{id}")]
        [HttpDelete]
        public async Task<ActionResult> DeleteAbsenceReason(int id)
        {
            try
            {
                await _absenceReasonBusiness.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}