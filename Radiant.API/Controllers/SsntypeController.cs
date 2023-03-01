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
    public class SsntypeController : ControllerBase
    {
        private readonly IGenericBusiness<SsntypeDto> _ssdTypeBusiness;
        private readonly ILogger<SsntypeController> _logger;

        public SsntypeController(IGenericBusiness<SsntypeDto> ssdTypeBusiness
            , ILogger<SsntypeController> logger)
        {
            _ssdTypeBusiness = ssdTypeBusiness;
            _logger = logger;
        }

        /// <summary>
        /// Get all Ssdtypes
        /// </summary>
        /// <returns></returns>
        [Produces("application/json")]
        [HttpGet]
        public async Task<ActionResult<List<SsntypeDto>>> GetAll()
        {
            try
            {
                var ssdTypes = await _ssdTypeBusiness.GetAll();
                return Ok(ssdTypes);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Get Ssdtype by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [Route("{id}")]
        [HttpGet]
        public async Task<ActionResult<SsntypeDto>> GetSsdtypeById(int id)
        {
            try
            {
                _logger.LogInformation("Get Ssdtype by id");
                var ssdType = await _ssdTypeBusiness.GetById(id);
                return Ok(ssdType);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Create Ssdtype
        /// </summary>
        /// <param name="Ssdtype"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] SsntypeDto Ssdtype)
        {
            try
            {
                var createdRecord = await _ssdTypeBusiness.Create(Ssdtype);
                return Ok(createdRecord);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        /// <summary>
        /// Edit Ssdtype
        /// </summary>
        /// <param name="Ssdtype"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [HttpPut]
        public async Task<ActionResult> EditSsdtype([FromBody] SsntypeDto Ssdtype)
        {
            try
            {
                var updatedRecord = await _ssdTypeBusiness.Edit(Ssdtype);
                return Ok(updatedRecord);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Delete Ssdtype
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [Route("{id}")]
        [HttpDelete]
        public async Task<ActionResult> DeleteSsdtype(int id)
        {
            try
            {
                await _ssdTypeBusiness.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}