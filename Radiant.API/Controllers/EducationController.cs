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
    public class EducationController : ControllerBase
    {
        private readonly IGenericBusiness<EducationDto> _educationBusiness;
        private readonly ILogger<EducationController> _logger;

        public EducationController(IGenericBusiness<EducationDto> educationBusiness
            , ILogger<EducationController> logger)
        {
            _educationBusiness = educationBusiness;
            _logger = logger;
        }

        /// <summary>
        /// Get all Educations
        /// </summary>
        /// <returns></returns>
        [Produces("application/json")]
        [HttpGet]
        public async Task<ActionResult<List<EducationDto>>> GetAll()
        {
            try
            {
                var educations = await _educationBusiness.GetAll();
                return Ok(educations);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Get Education by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [Route("{id}")]
        [HttpGet]
        public async Task<ActionResult<EducationDto>> GetEducationById(int id)
        {
            try
            {
                _logger.LogInformation("Get Education by id");
                var education = await _educationBusiness.GetById(id);
                return Ok(education);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Create Education
        /// </summary>
        /// <param name="education"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] EducationDto education)
        {
            try
            {
                var createdRecord = await _educationBusiness.Create(education);
                return Ok(createdRecord);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        /// <summary>
        /// Edit Education
        /// </summary>
        /// <param name="education"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [HttpPut]
        public async Task<ActionResult> EditEducation([FromBody] EducationDto education)
        {
            try
            {
                var updatedRecord = await _educationBusiness.Edit(education);
                return Ok(updatedRecord);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Delete Education
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [Route("{id}")]
        [HttpDelete]
        public async Task<ActionResult> DeleteEducation(int id)
        {
            try
            {
                await _educationBusiness.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
