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
		public async Task<IActionResult> RegisterAsync([FromBody]RegisterViewModel model)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var result = await _userService.RegisterUserAsync(model);

			if (result.IsSuccess)
			{
				return Ok(result);
			}
			else
			{
				return BadRequest(result);
			}
		}
	}
}