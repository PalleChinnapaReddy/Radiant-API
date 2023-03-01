using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Radiant.Business.Contracts;
using Radiant.Business.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Radiant.Business.Models.FilterModels;


namespace Radiant.API.Controllers
{
    //[Authorize(Roles = "Line Workers")]
    [Route("api/[controller]")]
    [ApiController]
    public class HolidayController : ControllerBase
    {
        private readonly IRadiantHolidayBusiness _radiantHolidayBusiness;
        private readonly ILogger<HolidayController> _logger;

        public HolidayController(IRadiantHolidayBusiness radiantHolidayBusiness
            , ILogger<HolidayController> logger)
        {
            _radiantHolidayBusiness = radiantHolidayBusiness;
            _logger = logger;
        }

        /// <summary>
        /// Get all RadiantHolidays
        /// </summary>
        /// <returns></returns>
        [Produces("application/json")]
        [HttpGet]
        public async Task<ActionResult<List<RadiantHolidayDto>>> GetAll()
        {
            try
            {
                var radiantHolidays = await _radiantHolidayBusiness.GetAll();
                return Ok(radiantHolidays);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// Get all RadiantHolidays
        /// </summary>
        /// <returns></returns>
        [Produces("application/json")]
        [Route("getholidaysbytype")]
        [HttpGet]
        public async Task<ActionResult<List<RadiantHolidayDto>>> GetHolidaysByType([FromQuery] RadiantHolidayFilterDto  holidayByTypeSearchDto)
        {
            try
            {
                var radiantHolidays = await _radiantHolidayBusiness.GetAllByHolidayType(holidayByTypeSearchDto);
                return Ok(radiantHolidays);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Get RadiantHoliday by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [Route("{id}")]
        [HttpGet]
        public async Task<ActionResult<RadiantHolidayDto>> GetRadiantHolidayById(int id)
        {
            try
            {
                _logger.LogInformation("Get RadiantHoliday by id");
                var radiantHoliday = await _radiantHolidayBusiness.GetById(id);
                return Ok(radiantHoliday);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Create RadiantHoliday
        /// </summary>
        /// <param name="radiantHoliday"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] RadiantHolidayDto radiantHoliday)
        {
            try
            {
                var existingHoliday = await _radiantHolidayBusiness.GetHolidayByDate(radiantHoliday.Holiday.GetValueOrDefault());
                if (existingHoliday != null)
                {
                    return BadRequest("Another Holiday exists with same date");
                }
                var createdRecord = await _radiantHolidayBusiness.Create(radiantHoliday);
                return Ok(createdRecord);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Create RadiantHolidays
        /// </summary>
        /// <param name="holidays"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [HttpPost]
        [Route("CreateHolidays")]
        public async Task<ActionResult> CreateHolidays([FromBody] List<RadiantHolidayDto> holidays)
        {
            try
            {
                foreach (var radiantHoliday in holidays)
                {
                    var existingHoliday = await _radiantHolidayBusiness.GetHolidayByDate(radiantHoliday.Holiday.GetValueOrDefault());
                    if (existingHoliday != null)
                    {
                        return BadRequest("Another Holiday exists with same date");
                    }
                }
                var radiantHolidays = await _radiantHolidayBusiness.CreateHolidays(holidays);
                return Ok(radiantHolidays);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        /// <summary>
        /// Edit RadiantHoliday
        /// </summary>
        /// <param name="radiantHoliday"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [HttpPut]
        public async Task<ActionResult> EditRadiantHoliday([FromBody] RadiantHolidayDto radiantHoliday)
        {
            try
            {
                var existingHoliday = await _radiantHolidayBusiness.GetHolidayByDate(radiantHoliday.Holiday.GetValueOrDefault());
                if (existingHoliday != null && existingHoliday.Holidayid != radiantHoliday.Holidayid)
                {
                    return BadRequest("Another Holiday exists with same date");
                }
                var updatedRecord = await _radiantHolidayBusiness.Edit(radiantHoliday);
                return Ok(updatedRecord);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Delete RadiantHoliday
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [Route("{id}")]
        [HttpDelete]
        public async Task<ActionResult> DeleteRadiantHoliday(int id)
        {
            try
            {
                await _radiantHolidayBusiness.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
