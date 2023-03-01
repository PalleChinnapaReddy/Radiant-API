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
    public class ContractorTrackerController : ControllerBase
    {
        private readonly IGenericBusiness<ContractorTrackerDto> _contractorTrackerBusiness;
        private readonly ILogger<ContractorController> _logger;

        public ContractorTrackerController(IGenericBusiness<ContractorTrackerDto> contractorTrackerBusiness
            , ILogger<ContractorController> logger)
        {
            _contractorTrackerBusiness = contractorTrackerBusiness;
            _logger = logger;
        }

        /// <summary>
        /// Get all ContractorTrackers
        /// </summary>
        /// <returns></returns>
        [Produces("application/json")]
        [HttpGet]
        public async Task<ActionResult<List<ContractorTrackerDto>>> GetAll()
        {
            try
            {
                var contractorTrackers = await _contractorTrackerBusiness.GetAll();
                return Ok(contractorTrackers);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Get ContractorTracker by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [Route("{id}")]
        [HttpGet]
        public async Task<ActionResult<ContractorTrackerDto>> GetContractorTrackerById(int id)
        {
            try
            {
                _logger.LogInformation("Get ContractorTracker by id");
                var contractorTracker = await _contractorTrackerBusiness.GetById(id);
                return Ok(contractorTracker);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Create ContractorTracker
        /// </summary>
        /// <param name="contractorTracker"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] ContractorTrackerDto contractorTracker)
        {
            try
            {
                var createdRecord = await _contractorTrackerBusiness.Create(contractorTracker);
                return Ok(createdRecord);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        /// <summary>
        /// Edit ContractorTracker
        /// </summary>
        /// <param name="contractorTracker"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [HttpPut]
        public async Task<ActionResult> EditContractor([FromBody] ContractorTrackerDto contractorTracker)
        {
            try
            {
                var updatedRecord = await _contractorTrackerBusiness.Edit(contractorTracker);
                return Ok(updatedRecord);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Delete ContractorTracker
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [Route("{id}")]
        [HttpDelete]
        public async Task<ActionResult> DeleteContractorTracker(int id)
        {
            try
            {
                await _contractorTrackerBusiness.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
