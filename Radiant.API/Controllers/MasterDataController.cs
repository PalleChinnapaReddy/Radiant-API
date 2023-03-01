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
    public class MasterDataController : ControllerBase
    {
        private readonly IMasterDataBusiness _masterDataBusiness;
        private readonly ILogger<MasterDataController> _logger;

        public MasterDataController(IMasterDataBusiness masterDataBusiness
            , ILogger<MasterDataController> logger)
        {
            _masterDataBusiness = masterDataBusiness;
            _logger = logger;
        }

        /// <summary>
        /// Get all Cities
        /// </summary>
        /// <returns>list of cities </returns>
        [Produces("application/json")]
        [Route("getcities")]
        [HttpGet]
        public async Task<ActionResult<List<CityDto>>> GetAll()
        {
            try
            {
                var cities = await _masterDataBusiness.GetCities();
                return Ok(cities);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Get all martialstatus 
        /// </summary>
        /// <returns></returns>
        [Produces("application/json")]
        [Route("getmartialstatus")]
        [HttpGet]
        public async Task<ActionResult<List<MaritalstatusDto>>> GetMartialStatus()
        {
            try
            {
                _logger.LogInformation("Get Martial Statuses");
                var maritalstatuses = await _masterDataBusiness.GetMartialStatus();
                return Ok(maritalstatuses);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Get all Paymenttypes
        /// </summary>
        /// <returns></returns>
        [Produces("application/json")]
        [Route("GetPaymenttypes")]
        [HttpGet]
        public async Task<ActionResult<List<PaymenttypeDto>>> GetPaymenttypes()
        {
            try
            {
                _logger.LogInformation("Get Payment Type");
                var paymenttypes = await _masterDataBusiness.GetPaymenttypes();
                return Ok(paymenttypes);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Get all Attachement Types
        /// </summary>
        /// <returns></returns>
        [Produces("application/json")]
        [Route("GetAttachementTypes")]
        [HttpGet]
        public async Task<ActionResult<List<AttachmentsDto>>> GetAttachementTypes()
        {
            try
            {
                _logger.LogInformation("Get Attachement Type");
                var attachments = await _masterDataBusiness.GetAttachments();
                return Ok(attachments);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
                _logger.LogError(ex.ToString());
            }
        }


    }
}