using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Radiant.Business.Contracts;
using Radiant.Business.Models;
using Radiant.Business.Models.FilterModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Radiant.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StageController : ControllerBase
    {
        private readonly IStageBusiness _stageBusiness;
        private readonly IEmployeeBusiness _employeeBusiness;
        private readonly ILogger<StageController> _logger;

        public StageController(IStageBusiness stageBusiness
            , IEmployeeBusiness employeeBusiness
            , ILogger<StageController> logger)
        {
            _stageBusiness = stageBusiness;
            _employeeBusiness = employeeBusiness;
            _logger = logger;
        }

        /// <summary>
        /// Get all Stages
        /// </summary>
        /// <returns></returns>
        [Produces("application/json")]
        [HttpGet]
        public async Task<ActionResult<List<StageDto>>> GetAll()
        {
            try
            {
                var stages = await _stageBusiness.GetAll();
                return Ok(stages);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Get Stage by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [Route("{id}")]
        [HttpGet]
        public async Task<ActionResult<StageDto>> GetStageById(int id)
        {
            try
            {
                _logger.LogInformation("Get Stage by id");
                var stage = await _stageBusiness.GetById(id);
                return Ok(stage);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Create Stage
        /// </summary>
        /// <param name="stage"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] StageDto stage)
        {
            try
            {
                var stages = await _stageBusiness.GetAll();
                if (stages.Any(s => s.Lineid == stage.Lineid && string.Equals(s.Stagedescription == stage.Stagedescription, StringComparison.InvariantCultureIgnoreCase)))
                {
                    return BadRequest("Cannot create stage with same description in the same Line");
                }
                var createdRecord = await _stageBusiness.Create(stage);
                return Ok(createdRecord);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        /// <summary>
        /// Edit Stage
        /// </summary>
        /// <param name="stage"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [HttpPut]
        public async Task<ActionResult> EditStage([FromBody] StageDto stage)
        {
            try
            {
                var stages = await _stageBusiness.GetAll();
                if (stages.Any(s => s.Lineid == stage.Lineid && s.Stageid != stage.Stageid 
                && string.Equals(s.Stagedescription == stage.Stagedescription, StringComparison.InvariantCultureIgnoreCase)))
                {
                    return BadRequest("Cannot create stage with same description in the same Line");
                }
                var updatedRecord = await _stageBusiness.Edit(stage);
                return Ok(updatedRecord);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Delete Stage
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [Route("{id}")]
        [HttpDelete]
        public async Task<ActionResult> DeleteStage(int id)
        {
            try
            {
                var stageEmployees = await _employeeBusiness.Search(new EmployeeSearchDto { CurrentShiftid = id, PageSize = 1 });
                if (stageEmployees.TotalRows != 0)
                {
                    return BadRequest("Cannot delete the Shift. The given Shift has active employees.");
                }
                await _stageBusiness.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Get Stages
        /// </summary>
        /// <param name="deptId"></param>
        /// <param name="subdeptId"></param>
        /// <param name="lineId"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [Route("GetStageByDeptAndLine")]
        [HttpGet]
        public async Task<ActionResult<List<StageDto>>> GetStageByDeptAndLine([FromQuery]long deptId, [FromQuery] long subdeptId, [FromQuery] long lineId)
        {
            try
            {
                var stages = await _stageBusiness.GetStageByDeptAndLine(deptId, subdeptId, lineId);
                return Ok(stages);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        /// <summary>
        /// Get Stages by line
        /// </summary>
        /// <param name="lineId"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [Route("GetStageByLine")]
        [HttpGet]
        public async Task<ActionResult<List<StageDto>>> GetStageByLine([FromQuery] long lineId)
        {
            try
            {
                var stages = await _stageBusiness.GetStageByLine(lineId);
                return Ok(stages);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}