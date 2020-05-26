using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClientManagement.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClientManagment.API.Controllers
{
	[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BusinessTypeController : ControllerBase
    {
	    private readonly IBusinessTypeService _businessTypeService;

	    public BusinessTypeController(IBusinessTypeService businessTypeService)
	    {
		    _businessTypeService = businessTypeService;
	    }

		/// <summary>
		/// Gets all BusinessTypes
		/// </summary>
	    [HttpGet]
	    public async Task<IActionResult> Get()
	    {
		    var businessTypes = await _businessTypeService.GetBusinessTypesAsync();
		    return Ok(businessTypes);
	    }

		/// <summary>
		/// Gets all active BusinessTypes
		/// </summary>
		[HttpGet("GetActive")]
		public async Task<IActionResult> GetActive()
		{
			var businessTypes = await _businessTypeService.GetActiveBusinessTypesAsync();
			return Ok(businessTypes);
		}
	}
}