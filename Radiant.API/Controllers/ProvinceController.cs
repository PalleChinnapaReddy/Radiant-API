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
    public class ProvinceController : ControllerBase
    {
        private readonly IGenericBusiness<ProvinceDto> _provinceBusiness;
        private readonly ILogger<ProvinceController> _logger;

        public ProvinceController(IGenericBusiness<ProvinceDto> provinceBusiness
            , ILogger<ProvinceController> logger)
        {
            _provinceBusiness = provinceBusiness;
            _logger = logger;
        }

        /// <summary>
        /// Get all Provinces
        /// </summary>
        /// <returns></returns>
        [Produces("application/json")]
        [HttpGet]
        public async Task<ActionResult<List<ProvinceDto>>> GetAll()
        {
            try
            {
                var provinces = await _provinceBusiness.GetAll();
                return Ok(provinces);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Get Province by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [Route("{id}")]
        [HttpGet]
        public async Task<ActionResult<ProvinceDto>> GetProvinceById(int id)
        {
            try
            {
                _logger.LogInformation("Get Province by id");
                var province = await _provinceBusiness.GetById(id);
                return Ok(province);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Create Province
        /// </summary>
        /// <param name="province"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] ProvinceDto province)
        {
            try
            {
                var createdRecord = await _provinceBusiness.Create(province);
                return Ok(createdRecord);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        /// <summary>
        /// Edit Province
        /// </summary>
        /// <param name="province"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [HttpPut]
        public async Task<ActionResult> EditProvince([FromBody] ProvinceDto province)
        {
            try
            {
                var updatedRecord = await _provinceBusiness.Edit(province);
                return Ok(updatedRecord);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Delete Province
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [Route("{id}")]
        [HttpDelete]
        public async Task<ActionResult> DeleteProvince(int id)
        {
            try
            {
                await _provinceBusiness.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
