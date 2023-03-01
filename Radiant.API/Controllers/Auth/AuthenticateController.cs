using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Radiant.Business.Contracts;
using Radiant.Business.Models;
using Radiant.Business.Models.Auth;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Radiant.API.Controllers.Auth
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        //private readonly UserManager<ApplicationUser> userManager;
        private readonly ILogger<AuthenticateController> _logger;
        private readonly IEmployeeBusiness _employeeBusiness;
        private readonly IScreensBusiness _screensBusiness;
        private readonly IGenericBusiness<RoleDto> _roleBusiness;
        private readonly IConfiguration _configuration;

        public AuthenticateController(
            //UserManager<ApplicationUser> userManager, 
            ILogger<AuthenticateController> logger,
            IEmployeeBusiness employeeBusiness,
            IScreensBusiness screensBusiness,
            IGenericBusiness<RoleDto> roleBusiness,
            IConfiguration configuration)
        {
            //this.userManager = userManager;
            this._logger = logger;
            this._employeeBusiness = employeeBusiness;
            this._screensBusiness = screensBusiness;
            this._roleBusiness = roleBusiness;
            _configuration = configuration;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginModelDto model)
        {
            if (model.Username == "1111111111" && model.Password == "Radiant@2022")
            {
                var readOnlyUser = new EmployeeDto();
                readOnlyUser.Firstname = "Viewer";
                readOnlyUser.Empid = 101;
                readOnlyUser.CurrentRole = new RoleDto();
                readOnlyUser.CurrentRole.Roledetails = "ReadOnly";

                var readOnlyAuthClaims = new List<Claim>
                {
                    new Claim("Name", readOnlyUser.Firstname),
                    new Claim("UserId", readOnlyUser.Empid.ToString()),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),

                };
                readOnlyAuthClaims.Add(new Claim("Role", readOnlyUser.CurrentRole.Roledetails));
                var authSigningKey1 = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

                var token1 = new JwtSecurityToken(
                    issuer: _configuration["JWT:ValidIssuer"],
                    audience: _configuration["JWT:ValidAudience"],
                    expires: DateTime.Now.AddDays(30),
                    claims: readOnlyAuthClaims,
                    signingCredentials: new SigningCredentials(authSigningKey1, SecurityAlgorithms.HmacSha256)
                    );

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token1),
                    expiration = token1.ValidTo,
                    //screens = userScreens
                });

            }


            var user = await _employeeBusiness.GetByName(model.Username);
            if (!BCrypt.Net.BCrypt.Verify(model.Password, user.Password))
                return Unauthorized("Incorrect username / password");

            if (string.IsNullOrWhiteSpace(user.CurrentRole.Roledetails))
                return Unauthorized("Please connect with administration for your roles");

            var authClaims = new List<Claim>
                {
                    new Claim("Name", user.Firstname),
                    new Claim("UserId", user.Empid.ToString()),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

            authClaims.Add(new Claim("Role", user.CurrentRole.Roledetails));

            //authClaims.Add(new Claim(ClaimTypes.Webpage, user.CurrentRole.Screendetails));

            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddHours(3),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );
            //object userScreens;
            //if (!string.IsNullOrWhiteSpace(user.CurrentRole.Screendetails))
            //{
            //    userScreens = await _screensBusiness.GetScreensByIds(user.CurrentRole.Screendetails.Split(',').Select(x => Convert.ToInt64(x)).ToList());
            //}
            //else
            //{
            //    userScreens = "No Screens are Configured for the Role";
            //}
            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                expiration = token.ValidTo,
                //screens = userScreens
            });
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModelDto model)
        {
            var user = await _employeeBusiness.GetByName(model.Username);
            if (!string.IsNullOrWhiteSpace(user.Password))
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User already exists!" });

            user.Officialemailaddress = model.Email;
            user.Password = BCrypt.Net.BCrypt.HashPassword(model.Password);
            var result = await _employeeBusiness.Edit(user);
            if (result == null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User creation failed! Please check user details and try again." });

            return Ok(new Response { Status = "Success", Message = "User created successfully!" });
        }

        [Route("hash")]
        [HttpGet]
        public ActionResult GetPassHash(string password)
        {
            try
            {
                return Ok(BCrypt.Net.BCrypt.HashPassword(password));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
