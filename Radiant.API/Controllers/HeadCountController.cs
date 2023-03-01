using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Radiant.Business.Contracts;
using Radiant.Business.Models;
using Radiant.Business.Models.CustomizedAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Radiant.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeadCountController : ControllerBase
    {
        private readonly IHeadCountBusiness _headCountBusiness;
        private readonly ILogger<HeadCountController> _logger;

        public HeadCountController(IHeadCountBusiness headCountBusiness
            , ILogger<HeadCountController> logger)
        {
            _headCountBusiness = headCountBusiness;
            _logger = logger;
        }

        /// <summary>
        /// Get Assigned HeadCounts
        /// </summary>
        /// <returns></returns>
        [Produces("application/json")]
        [HttpGet]
        public async Task<ActionResult<List<AssignedHeadCountDto>>> GetAssignedHeadCounts([FromQuery] AssignedHeadCountRequestDto requestDto)
        {
            try
            {
                var radiantHolidays = await _headCountBusiness.GetAssignedHeadCounts(requestDto);
                return Ok(radiantHolidays);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error ocurred while fetching AssingedHeadCounts. Details:{ex.Message}");
                return StatusCode(500, ex.Message);
            }
        }


        /// <summary>
        /// Updates AssignedHeadCounts
        /// </summary>
        /// <returns></returns>
        [Produces("application/json")]
        [HttpPost]
        public async Task<ActionResult> UpdateAssignedHeadCounts([FromBody] List<HeadCountAssignedTypeDto> headCountAssignedTypes)
        {
            try
            {
                await _headCountBusiness.UpdateAssignedHeadCounts(headCountAssignedTypes);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error ocurred while fetching AssingedHeadCounts. Details:{ex.Message}");
                return StatusCode(500, ex.Message);
            }
        }
    }
}
