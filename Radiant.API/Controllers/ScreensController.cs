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
    public class ScreensController : ControllerBase
    {
        private readonly IScreensBusiness _screensBusiness;
        private readonly ILogger<ScreensController> _logger;

        public ScreensController(IScreensBusiness ScreensBusiness
            , ILogger<ScreensController> logger)
        {
            _screensBusiness = ScreensBusiness;
            _logger = logger;
        }

        /// <summary>
        /// Get all Screens
        /// </summary>
        /// <returns></returns>
        [Produces("application/json")]
        [HttpGet]
        public async Task<ActionResult<List<ScreensDto>>> GetAll()
        {
            try
            {
                var screens = await _screensBusiness.GetAll();
                return Ok(screens);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Get Screens by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [Route("{id}")]
        [HttpGet]
        public async Task<ActionResult<ScreensDto>> GetScreensById(int id)
        {
            try
            {
                _logger.LogInformation("Get Screens by id");
                var Screens = await _screensBusiness.GetById(id);
                return Ok(Screens);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Create Screens
        /// </summary>
        /// <param name="Screens"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] ScreensDto Screens)
        {
            try
            {
                var createdRecord = await _screensBusiness.Create(Screens);
                return Ok(createdRecord);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        /// <summary>
        /// Edit Screens
        /// </summary>
        /// <param name="Screens"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [HttpPut]
        public async Task<ActionResult> EditScreens([FromBody] ScreensDto Screens)
        {
            try
            {
                var updatedRecord = await _screensBusiness.Edit(Screens);
                return Ok(updatedRecord);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Delete Screens
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [Route("{id}")]
        [HttpDelete]
        public async Task<ActionResult> DeleteScreens(int id)
        {
            try
            {
                await _screensBusiness.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
