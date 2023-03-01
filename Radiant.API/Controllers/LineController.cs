using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Radiant.Business.Contracts;
using Radiant.Business.Models;
using Radiant.Business.Models.CustomizedAPI;
using Radiant.Business.Models.FilterModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Radiant.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LineController : ControllerBase
    {
        private readonly ILineBusiness _lineBusiness;
        private readonly IEmployeeBusiness _employeeBusiness;
        private readonly ILogger<LineController> _logger;

        public LineController(ILineBusiness lineBusiness
            , IEmployeeBusiness employeeBusiness
            , ILogger<LineController> logger)
        {
            _lineBusiness = lineBusiness;
            _employeeBusiness = employeeBusiness;
            _logger = logger;
        }

        /// <summary>
        /// Get all Lines
        /// </summary>
        /// <returns></returns>
        [Produces("application/json")]
        [HttpGet]
        public async Task<ActionResult<List<LinesDashboardDto>>> GetAll()
        {
            try
            {
                var lines = await _lineBusiness.GetAllLines();
                return Ok(lines);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Get Line by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [Route("{id}")]
        [HttpGet]
        public async Task<ActionResult<LineDto>> GetLineById(int id)
        {
            try
            {
                _logger.LogInformation("Get Line by id");
                var line = await _lineBusiness.GetById(id);
                return Ok(line);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        ///// Get Line by id
        ///// </summary>
        ///// <param name="deptId"></param>
        ///// <param name="subdeptId"></param>
        ///// <returns></returns>
        //[Produces("application/json")]
        //[Route("{id}")]
        //[HttpGet]
        //public async Task<ActionResult<LineDto>> GetLineById(int deptId,int subdeptId)
        //{
        //    try
        //    {
        //        _logger.LogInformation("Get Line by id");
        //        var line = await _lineBusiness.GetByDepartment(deptId,subdeptId);
        //        return Ok(line);
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, ex.Message);
        //    }
        //}

        /// <summary>
        /// Create Line
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] LineDto line)
        {
            try
            {
                var existingLine = await _lineBusiness.GetByName(line.Linedescription);
                if (existingLine != null)
                {
                    return BadRequest("Another Line exists with same description");
                }
                var createdRecord = await _lineBusiness.Create(line);
                return Ok(createdRecord);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        /// <summary>
        /// Edit Line
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [HttpPut]
        public async Task<ActionResult> EditLine([FromBody] LineDto line)
        {
            try
            {
                var existingLine = await _lineBusiness.GetByName(line.Linedescription);
                if (existingLine != null && existingLine.Lineid != line.Lineid)
                {
                    return BadRequest("Another Line exists with same description");
                }
                var updatedRecord = await _lineBusiness.Edit(line);
                return Ok(updatedRecord);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Delete Line
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [Route("{id}")]
        [HttpDelete]
        public async Task<ActionResult> DeleteLine(int id)
        {
            try
            {
                var lineEmployee = await _employeeBusiness.Search(new EmployeeSearchDto { CurrentLineid = id, PageSize = 1 });
                if (lineEmployee.TotalRows != 0)
                {
                    return BadRequest("Cannot delete the Line. The given Line has active employees.");
                }
                await _lineBusiness.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        
        /// <summary>
        /// Gets Lines
        /// </summary>
        /// <param name="deptId"></param>
        /// <param name="subdeptId"></param>
        /// <returns></returns>
        [HttpGet]
        [Produces("application/json")]
        [Route("GetLineByDept")]
        public async Task<ActionResult<List<LineDto>>> GetLineByDept([FromQuery]long deptId, [FromQuery]long subdeptId)
        {
            try
            {
                var lines = await _lineBusiness.GetLineByDept(deptId, subdeptId);
                return Ok(lines);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Gets Lines
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Produces("application/json")]
        [Route("GetLineDDValues")]
        public async Task<ActionResult<List<DropdownValueDto>>> GetLinesDDValues()
        {
            try
            {
                var lines = await _lineBusiness.GetLinesDDValues();
                return Ok(lines);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
