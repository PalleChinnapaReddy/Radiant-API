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
    public class CityController : ControllerBase
    {
        private readonly ICityBusiness _cityBusiness;
        private readonly ILogger<CityController> _logger;

        public CityController(ICityBusiness cityBusiness
            , ILogger<CityController> logger)
        {
            _cityBusiness = cityBusiness;
            _logger = logger;
        }

        /// <summary>
        /// Get all Cities
        /// </summary>
        /// <returns></returns>
        [Produces("application/json")]
        [HttpGet]
        public async Task<ActionResult<List<CityDto>>> GetAll()
        {
            try
            {
                var countries = await _cityBusiness.GetAll();
                return Ok(countries);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Get all Cities of state
        /// </summary>
        /// <returns></returns>
        [Produces("application/json")]
        [HttpGet]
        [Route("GetCitiesByState")]
        public async Task<ActionResult<List<CityDto>>> GetCitiesByState(long stateId)
        {
            try
            {
                var cities = await _cityBusiness.GetCitiesByStateId(stateId);
                return Ok(cities);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Get City by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [Route("{id}")]
        [HttpGet]
        public async Task<ActionResult<CityDto>> GetCityById(int id)
        {
            try
            {
                _logger.LogInformation("Get City by id");
                var city = await _cityBusiness.GetById(id);
                return Ok(city);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Create City
        /// </summary>
        /// <param name="city"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CityDto city)
        {
            try
            {
                var createdRecord = await _cityBusiness.Create(city);
                return Ok(createdRecord);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        /// <summary>
        /// Edit City
        /// </summary>
        /// <param name="city"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [HttpPut]
        public async Task<ActionResult> EditCity([FromBody] CityDto city)
        {
            try
            {
                var updatedRecord = await _cityBusiness.Edit(city);
                return Ok(updatedRecord);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Delete City
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [Route("{id}")]
        [HttpDelete]
        public async Task<ActionResult> DeleteCity(int id)
        {
            try
            {
                await _cityBusiness.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
