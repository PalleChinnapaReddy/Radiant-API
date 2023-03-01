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
    public class PlantController : ControllerBase
    {
        private readonly IGenericBusiness<PlantDto> _plantBusiness;
        private readonly ILogger<PlantController> _logger;

        public PlantController(IGenericBusiness<PlantDto> plantBusiness
            , ILogger<PlantController> logger)
        {
            _plantBusiness = plantBusiness;
            _logger = logger;
        }

        /// <summary>
        /// Get all Plants
        /// </summary>
        /// <returns></returns>
        [Produces("application/json")]
        [HttpGet]
        public async Task<ActionResult<List<PlantDto>>> GetAll()
        {
            try
            {
                var plants = await _plantBusiness.GetAll();
                return Ok(plants);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Get Plant by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [Route("{id}")]
        [HttpGet]
        public async Task<ActionResult<PlantDto>> GetPlantById(int id)
        {
            try
            {
                _logger.LogInformation("Get Plant by id");
                var plant = await _plantBusiness.GetById(id);
                return Ok(plant);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Create Plant
        /// </summary>
        /// <param name="plant"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] PlantDto plant)
        {
            try
            {
                var createdRecord = await _plantBusiness.Create(plant);
                return Ok(createdRecord);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        /// <summary>
        /// Edit Plant
        /// </summary>
        /// <param name="plant"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [HttpPut]
        public async Task<ActionResult> EditPlant([FromBody] PlantDto plant)
        {
            try
            {
                var updatedRecord = await _plantBusiness.Edit(plant);
                return Ok(updatedRecord);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Delete Plant
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [Route("{id}")]
        [HttpDelete]
        public async Task<ActionResult> DeletePlant(int id)
        {
            try
            {
                await _plantBusiness.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
