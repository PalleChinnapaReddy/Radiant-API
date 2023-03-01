using Microsoft.AspNetCore.Authorization;
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
    public class HolidayTypeController : ControllerBase
    {
        private readonly IGenericBusiness<HolidayTypeDto> _holidayTypeBusiness;
        private readonly ILogger<HolidayTypeController> _logger;
        private object existingholidayType;

        public HolidayTypeController(IGenericBusiness<HolidayTypeDto> holidayTypeBusiness
            , ILogger<HolidayTypeController> logger)
        {
            _holidayTypeBusiness = holidayTypeBusiness;
            _logger = logger;
        }

        /// <summary>
        /// Get all HolidayTypes
        /// </summary>
        /// <returns></returns>
        [Produces("application/json")]
        [HttpGet]
        public async Task<ActionResult<List<HolidayTypeDto>>> GetAll()
        {
            try
            {
                var radiantHolidays = await _holidayTypeBusiness.GetAll();
                return Ok(radiantHolidays);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Get HolidayType by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [Route("{id}")]
        [HttpGet]
        public async Task<ActionResult<HolidayTypeDto>> GetHolidayTypeById(int id)
        {
            try
            {
                _logger.LogInformation("Get HolidayType by id");
                var holidayType = await _holidayTypeBusiness.GetById(id);
                return Ok(holidayType);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        /// <summary>
        /// create holidayType
        /// </summary>
        /// <param name="holidayType"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] HolidayTypeDto holidayType)
        {
            try
            {
                var existingholidayType = await _holidayTypeBusiness.GetByName(holidayType.Holidaytypedetails);
                if (existingholidayType != null)
                {
                    return BadRequest("Another HolidayType exists with same HolidayType details");
                }
                var createdRow = await _holidayTypeBusiness.Create(holidayType);
                return Ok(createdRow);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Edit holidayType
        /// </summary>
        /// <param name="holidayType"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [HttpPut]
        public async Task<ActionResult> EditHolidayType([FromBody] HolidayTypeDto holidayType)
        {
            try
            {
                var existingholidayType = await _holidayTypeBusiness.GetByName(holidayType.Holidaytypedetails);
                if (existingholidayType != null && existingholidayType.Holidaytypeid != holidayType.Holidaytypeid)
                {
                    return BadRequest("Another HolidayType exists with same HolidayType details");
                }
                var updatedRow = await _holidayTypeBusiness.Edit(holidayType);
                return Ok(updatedRow);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Delete holidayType
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [Route("{id}")]
        [HttpDelete]
        public async Task<ActionResult> DeleteHolidayType(int id)
        {
            try
            {  
                await _holidayTypeBusiness.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
    