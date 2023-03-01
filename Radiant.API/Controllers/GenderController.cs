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
    public class GenderController : ControllerBase
    {
        private readonly IGenericBusiness<GenderDto> _genderBusiness;
        private readonly ILogger<GenderController> _logger;

        public GenderController(IGenericBusiness<GenderDto> genderBusiness
            , ILogger<GenderController> logger)
        {
            _genderBusiness = genderBusiness;
            _logger = logger;
        }

        /// <summary>
        /// Get all Genders
        /// </summary>
        /// <returns></returns>
        [Produces("application/json")]
        [HttpGet]
        public async Task<ActionResult<List<GenderDto>>> GetAll()
        {
            try
            {
                var genders = await _genderBusiness.GetAll();
                return Ok(genders);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Get Gender by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [Route("{id}")]
        [HttpGet]
        public async Task<ActionResult<GenderDto>> GetGenderById(int id)
        {
            try
            {
                _logger.LogInformation("Get Gender by id");
                var gender = await _genderBusiness.GetById(id);
                return Ok(gender);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Create Gender
        /// </summary>
        /// <param name="gender"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] GenderDto gender)
        {
            try
            {
                var createdRecord = await _genderBusiness.Create(gender);
                return Ok(createdRecord);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        /// <summary>
        /// Edit Gender
        /// </summary>
        /// <param name="gender"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [HttpPut]
        public async Task<ActionResult> EditGender([FromBody] GenderDto gender)
        {
            try
            {
                var updatedRecord = await _genderBusiness.Edit(gender);
                return Ok(updatedRecord);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Delete Gender
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [Route("{id}")]
        [HttpDelete]
        public async Task<ActionResult> DeleteGender(int id)
        {
            try
            {
                await _genderBusiness.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
