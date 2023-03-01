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
    public class RoleController : ControllerBase
    {
        private readonly IGenericBusiness<RoleDto> _roleBusiness;
        private readonly ILogger<RoleController> _logger;

        public RoleController(IGenericBusiness<RoleDto> roleBusiness
            , ILogger<RoleController> logger)
        {
            _roleBusiness = roleBusiness;
            _logger = logger;
        }

        /// <summary>
        /// Get all Roles
        /// </summary>
        /// <returns></returns>
        [Produces("application/json")]
        [HttpGet]
        public async Task<ActionResult<List<RoleDto>>> GetAll()
        {
            try
            {
                var roles = await _roleBusiness.GetAll();
                return Ok(roles);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Get Role by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [Route("{id}")]
        [HttpGet]
        public async Task<ActionResult<RoleDto>> GetRoleById(int id)
        {
            try
            {
                _logger.LogInformation("Get Role by id");
                var role = await _roleBusiness.GetById(id);
                return Ok(role);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Create Role
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] RoleDto role)
        {
            try
            {
                var existingRole = await _roleBusiness.GetByName(role.Roledetails);
                if (existingRole != null)
                {
                    return BadRequest("Another Role exists with same Roledetails");
                }
                var createdRow = await _roleBusiness.Create(role);
                return Ok(createdRow);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        /// <summary>
        /// Edit Role
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [HttpPut]
        public async Task<ActionResult> EditRole([FromBody] RoleDto role)
        {
            try
            {
                var existingRole = await _roleBusiness.GetByName(role.Roledetails);
                if (existingRole != null && existingRole.Roleid != role.Roleid)
                {
                    return BadRequest("Another Role exists with same Roledetails");
                }
                var updatedRow = await _roleBusiness.Edit(role);
                return Ok(updatedRow);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Delete Role
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [Route("{id}")]
        [HttpDelete]
        public async Task<ActionResult> DeleteRole(int id)
        {
            try
            {
                var existingRole = await _roleBusiness.GetById(id);
                if (existingRole.ActiveEmployeeCount > 0)
                {
                    return BadRequest("Cannot delete the Role. The given Role has active employees.");
                }
                await _roleBusiness.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}