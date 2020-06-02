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
    public class BusinessController : ControllerBase
    {
	    private readonly IBusinessService _businessService;

	    public BusinessController(IBusinessService businessService)
	    {
		    _businessService = businessService;
	    }

	    [HttpPost]
        public async Task<IActionResult> AddBusiness([FromBody] BusinessModel model)
        {
	        if (!ModelState.IsValid)
	        {
		        return BadRequest(ModelState);
	        }

	        BusinessModel business = await _businessService.AddBusinessAsync(model);
	        return Ok(business);
        }
    }
}