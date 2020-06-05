using System.Threading.Tasks;
using ClientManagement.Core.Entities.DTO;
using ClientManagement.Core.Helpers;
using ClientManagement.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace ClientManagment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BServiceController : ControllerBase
    {
	    private readonly IBService _bservice;

	    public BServiceController(IBService bservice)
	    {
		    _bservice = bservice;
	    }

		/// <summary>
		/// Creates a new service for the specified business
		/// </summary>
		/// <param name="model"></param>
		[HttpPost]
	    public async Task<IActionResult> AddService([FromBody] BServiceDTO model)
	    {
		    if (!ModelState.IsValid)
		    {
			    return BadRequest(ModelState);
		    }

		    var response = await _bservice.AddServiceAsync(model);
		    return Ok(response);
	    }


		/// <summary>
		/// Gets all services provided by the business
		/// </summary>
		/// <param name="businessId">Id of the business</param>
		[HttpGet("BusinessServices/{businessId}")]
		public async Task<IActionResult> GetBusinessServices(int businessId)
		{
			if (businessId <= 0)
			{
				return BadRequest("Passed parameter is not valid");
			}

			return Ok(await _bservice.GetActiveServicesForBusinessAsync(businessId));
		}
    }
}