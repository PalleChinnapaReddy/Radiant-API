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
    public class DesignationController : ControllerBase
    {
        private readonly IGenericBusiness<DesignationDto> _designationBusiness;
        private readonly ILogger<DesignationController> _logger;

        public DesignationController(IGenericBusiness<DesignationDto> designationBusiness
            , ILogger<DesignationController> logger)
        {
            _designationBusiness = designationBusiness;
            _logger = logger;
        }

        /// <summary>
        /// Get all Designations
        /// </summary>
        /// <returns></returns>
        [Produces("application/json")]
        [HttpGet]
        public async Task<ActionResult<List<DesignationDto>>> GetAll()
        {
            try
            {
                var designations = await _designationBusiness.GetAll();
                return Ok(designations);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Get Designation by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [Route("{id}")]
        [HttpGet]
        public async Task<ActionResult<DesignationDto>> GetDesignationById(int id)
        {
            try
            {
                _logger.LogInformation("Get Designation by id");
                var designation = await _designationBusiness.GetById(id);
                return Ok(designation);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Create Designation
        /// </summary>
        /// <param name="designation"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] DesignationDto designation)
        {
            try
            {
                var createdRecord = await _designationBusiness.Create(designation);
                return Ok(createdRecord);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        /// <summary>
        /// Edit Designation
        /// </summary>
        /// <param name="designation"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [HttpPut]
        public async Task<ActionResult> EditDesignation([FromBody] DesignationDto designation)
        {
            try
            {
                var updatedRecord = await _designationBusiness.Edit(designation);
                return Ok(updatedRecord);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Delete Designation
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [Route("{id}")]
        [HttpDelete]
        public async Task<ActionResult> DeleteDesignation(int id)
        {
            try
            {
                await _designationBusiness.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
