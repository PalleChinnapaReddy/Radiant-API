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
    public class CountryController : ControllerBase
    {
        private readonly IGenericBusiness<CountryDto> _countryBusiness;
        private readonly ILogger<CountryController> _logger;

        public CountryController(IGenericBusiness<CountryDto> countryBusiness
            , ILogger<CountryController> logger)
        {
            _countryBusiness = countryBusiness;
            _logger = logger;
        }

        /// <summary>
        /// Get all Countries
        /// </summary>
        /// <returns></returns>
        [Produces("application/json")]
        [HttpGet]
        public async Task<ActionResult<List<CountryDto>>> GetAll()
        {
            try
            {
                var countries = await _countryBusiness.GetAll();
                return Ok(countries);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Get Country by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [Route("{id}")]
        [HttpGet]
        public async Task<ActionResult<CountryDto>> GetCountryById(int id)
        {
            try
            {
                _logger.LogInformation("Get Country by id");
                var country = await _countryBusiness.GetById(id);
                return Ok(country);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Create Country
        /// </summary>
        /// <param name="country"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CountryDto country)
        {
            try
            {
                var createdRecord = await _countryBusiness.Create(country);
                return Ok(createdRecord);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        /// <summary>
        /// Edit Country
        /// </summary>
        /// <param name="country"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [HttpPut]
        public async Task<ActionResult> EditCountry([FromBody] CountryDto country)
        {
            try
            {
                var updatedRecord = await _countryBusiness.Edit(country);
                return Ok(updatedRecord);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Delete Country
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [Route("{id}")]
        [HttpDelete]
        public async Task<ActionResult> DeleteCountry(int id)
        {
            try
            {
                await _countryBusiness.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
