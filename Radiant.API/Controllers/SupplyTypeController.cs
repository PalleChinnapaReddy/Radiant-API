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
    public class SupplyTypeController : ControllerBase
    {
        private readonly IGenericBusiness<SupplyTypeDto> _supplyTypeBusiness;
        private readonly ILogger<SupplyTypeController> _logger;

        public SupplyTypeController(IGenericBusiness<SupplyTypeDto> supplyTypeBusiness
            , ILogger<SupplyTypeController> logger)
        {
            _supplyTypeBusiness = supplyTypeBusiness;
            _logger = logger;
        }

        /// <summary>
        /// Get all SupplyTypes
        /// </summary>
        /// <returns></returns>
        [Produces("application/json")]
        [HttpGet]
        public async Task<ActionResult<List<SupplyTypeDto>>> GetAll()
        {
            try
            {
                var supplyTypes = await _supplyTypeBusiness.GetAll();
                return Ok(supplyTypes);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Get SupplyType by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [Route("{id}")]
        [HttpGet]
        public async Task<ActionResult<SupplyTypeDto>> GetSupplyTypeById(int id)
        {
            try
            {
                _logger.LogInformation("Get SupplyType by id");
                var user = await _supplyTypeBusiness.GetById(id);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Create SupplyType
        /// </summary>
        /// <param name="SupplyType"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] SupplyTypeDto SupplyType)
        {
            try
            {
                var createdRecord = await _supplyTypeBusiness.Create(SupplyType);
                return Ok(createdRecord);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        /// <summary>
        /// Edit SupplyType
        /// </summary>
        /// <param name="SupplyType"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [HttpPut]
        public async Task<ActionResult> EditSupplyType([FromBody] SupplyTypeDto SupplyType)
        {
            try
            {
                var updatedRecord = await _supplyTypeBusiness.Edit(SupplyType);
                return Ok(updatedRecord);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Delete SupplyType
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [Route("{id}")]
        [HttpDelete]
        public async Task<ActionResult> DeleteSupplyType(int id)
        {
            try
            {
                await _supplyTypeBusiness.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}