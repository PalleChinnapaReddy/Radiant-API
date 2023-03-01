using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Radiant.Business.Contracts;
using Radiant.Business.Models;
using Radiant.Business.Models.FilterModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Radiant.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContractorController : ControllerBase
    {
        private readonly ISearchableBusiness<ContractorDto, ContractorSearchDto> _contractorBusiness;
        private readonly IEmployeeBusiness _employeeBusiness;
        private readonly ILogger<ContractorController> _logger;

        public ContractorController(ISearchableBusiness<ContractorDto, ContractorSearchDto> contractorBusiness
            , IEmployeeBusiness employeeBusiness
            , ILogger<ContractorController> logger)
        {
            _contractorBusiness = contractorBusiness;
            _employeeBusiness = employeeBusiness;
            _logger = logger;
        }

        /// <summary>
        /// Get all Contractors
        /// </summary>
        /// <returns></returns>
        [Produces("application/json")]
        [HttpGet]
        public async Task<ActionResult<List<ContractorDto>>> GetAll()
        {
            try
            {
                var contractors = await _contractorBusiness.GetAll();
                return Ok(contractors);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Get Contractor by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [Route("{id}")]
        [HttpGet]
        public async Task<ActionResult<ContractorDto>> GetContractorById(int id)
        {
            try
            {
                _logger.LogInformation("Get Contractor by id");
                var contractor = await _contractorBusiness.GetById(id);
                return Ok(contractor);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Create Contractor
        /// </summary>
        /// <param name="contractor"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] ContractorDto contractor)
        {
            try
            {
                var createdRecord = await _contractorBusiness.Create(contractor);
                return Ok(createdRecord);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        /// <summary>
        /// Edit Contractor
        /// </summary>
        /// <param name="contractor"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [HttpPut]
        public async Task<ActionResult> EditContractor([FromBody] ContractorDto contractor)
        {
            try
            {
                var updatedRecord = await _contractorBusiness.Edit(contractor);
                return Ok(updatedRecord);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Delete Contractor
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [Route("{id}")]
        [HttpDelete]
        public async Task<ActionResult> DeleteContractor(int id)
        {
            try
            {
                var contractorEmployees = await _employeeBusiness.Search(new EmployeeSearchDto { CurrentContractorid = id, PageSize = 1 });
                if (contractorEmployees.TotalRows != 0)
                {
                    return BadRequest("Cannot delete the Contractor. The given Contractor has active employees.");
                }
                await _contractorBusiness.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Searches Contractors based on SearchCriteria Provided
        /// </summary>
        /// <param name="contractorSearchDto"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [HttpGet]
        [Route("/api/Contractor/Search")]
        public async Task<ActionResult<List<ContractorDto>>> Search([FromQuery]ContractorSearchDto contractorSearchDto)
        {
            try
            {
                var contractors = await _contractorBusiness.Search(contractorSearchDto);
                return Ok(contractors);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
