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
    public class PayrollConfigController : ControllerBase
    {
        private readonly IPayrollConfigBusiness _payrollConfigBusiness;
        private readonly ILogger<PayrollConfigController> _logger;

        public PayrollConfigController(IPayrollConfigBusiness PayrollConfigBusiness
            , ILogger<PayrollConfigController> logger)
        {
            _payrollConfigBusiness = PayrollConfigBusiness;
            _logger = logger;
        }

        /// <summary>
        /// Get all PayrollConfigs
        /// </summary>
        /// <returns></returns>
        [Produces("application/json")]
        [HttpGet]
        public async Task<ActionResult<List<PayrollConfigDto>>> GetAll()
        {
            try
            {
                var payrollConfigs = await _payrollConfigBusiness.GetAll();
                return Ok(payrollConfigs);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [Produces("application/json")]
        [HttpGet]
        [Route("GetPayrollConfigByMonth")]
        public async Task<ActionResult<List<PayrollConfigDto>>> Get(DateTime dateTime)
        {
            try
            {
                var payrollConfigs = await _payrollConfigBusiness.GetPayrollConfigByMonth(dateTime);
                return Ok(payrollConfigs);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Get PayrollConfig by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [Route("{id}")]
        [HttpGet]
        public async Task<ActionResult<PayrollConfigDto>> GetPayrollConfigById(int id)
        {
            try
            {
                _logger.LogInformation("Get PayrollConfig by id");
                var payrollConfig = await _payrollConfigBusiness.GetById(id);
                return Ok(payrollConfig);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Create PayrollConfig
        /// </summary>
        /// <param name="payrollConfig"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] PayrollConfigDto payrollConfig)
        {
            try
            {
                var createdRecord = await _payrollConfigBusiness.Create(payrollConfig);
                return Ok(createdRecord);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        /// <summary>
        /// Edit PayrollConfig
        /// </summary>
        /// <param name="payrollConfig"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [HttpPut]
        public async Task<ActionResult> EditPayrollConfig([FromBody] PayrollConfigDto payrollConfig)
        {
            try
            {
                var updatedRecord = await _payrollConfigBusiness.Edit(payrollConfig);
                return Ok(updatedRecord);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Delete PayrollConfig
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [Route("{id}")]
        [HttpDelete]
        public async Task<ActionResult> DeletePayrollConfig(int id)
        {
            try
            {
                await _payrollConfigBusiness.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
