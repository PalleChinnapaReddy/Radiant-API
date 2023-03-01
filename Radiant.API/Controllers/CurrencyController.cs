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
    public class CurrencyController : ControllerBase
    {
        private readonly IGenericBusiness<CurrencyDto> _currencyBusiness;
        private readonly ILogger<CurrencyController> _logger;

        public CurrencyController(IGenericBusiness<CurrencyDto> currencyBusiness
            , ILogger<CurrencyController> logger)
        {
            _currencyBusiness = currencyBusiness;
            _logger = logger;
        }

        /// <summary>
        /// Get all Currencies
        /// </summary>
        /// <returns></returns>
        [Produces("application/json")]
        [HttpGet]
        public async Task<ActionResult<List<CurrencyDto>>> GetAll()
        {
            try
            {
                var countries = await _currencyBusiness.GetAll();
                return Ok(countries);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Get Currency by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [Route("{id}")]
        [HttpGet]
        public async Task<ActionResult<CurrencyDto>> GetCurrencyById(int id)
        {
            try
            {
                _logger.LogInformation("Get Currency by id");
                var currency = await _currencyBusiness.GetById(id);
                return Ok(currency);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Create Currency
        /// </summary>
        /// <param name="currency"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CurrencyDto currency)
        {
            try
            {
                var createdRecord = await _currencyBusiness.Create(currency);
                return Ok(createdRecord);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        /// <summary>
        /// Edit Currency
        /// </summary>
        /// <param name="currency"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [HttpPut]
        public async Task<ActionResult> EditCurrency([FromBody] CurrencyDto currency)
        {
            try
            {
                var updatedRecord = await _currencyBusiness.Edit(currency);
                return Ok(updatedRecord);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Delete Currency
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [Route("{id}")]
        [HttpDelete]
        public async Task<ActionResult> DeleteCurrency(int id)
        {
            try
            {
                await _currencyBusiness.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
