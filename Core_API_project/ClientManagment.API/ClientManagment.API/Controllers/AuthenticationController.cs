using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClientManagement.Core.Entities.DTO;
using ClientManagement.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClientManagment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthenticationController(IUserService userService)
        {
            _userService = userService;
        }

        // api/authentication/register
        /// <summary>
        /// Registers a new user to the service
        /// </summary>
        /// <param name="model">Register model</param>
        [HttpPost("Register")]
        public async Task<IActionResult> RegisterAsync([FromQuery]RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _userService.RegisterUserAsync(model);

            return Ok(response);
        }

        /// <summary>
        /// Get JWT security token
        /// </summary>
        /// <returns>Authentication token</returns>
        [HttpPost("Token")]
        public async Task<IActionResult> GetTokenAsync([FromBody] LoginModel model)
        {
            var token = await _userService.GetTokenAsync(model);
            return Ok(token);
        }
    }
}