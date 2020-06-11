using System.Threading.Tasks;
using ClientManagement.Core.Entities.DTO;
using ClientManagement.Core.Helpers;
using ClientManagement.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace ClientManagment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
	    private readonly IBService _bservice;
	    private readonly IClientServiceRequest _clientServiceRequest;

	    public ServiceController(IBService bservice, IClientServiceRequest clientServiceRequest)
	    {
		    _bservice = bservice;
		    _clientServiceRequest = clientServiceRequest;
	    }

		/// <summary>
		/// Creates a new service for the specified business
		/// </summary>
		/// <param name="model"></param>
		[HttpPost]
		public async Task<IActionResult> AddServiceAsync([FromBody] BServiceDTO model)
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
		public async Task<IActionResult> GetBusinessServicesAsync(int businessId)
		{
			if (businessId <= 0)
			{
				return BadRequest("Passed parameter is not valid");
			}

			return Ok(await _bservice.GetActiveServicesForBusinessAsync(businessId));
		}

		/// <summary>
		/// Adds a service request for the user with the selected services
		/// </summary>
		/// <param name="model">Needed data for the request</param>
		[HttpPost("AddClientServiceRequest")]
		public async Task<IActionResult> AddClientServiceRequestAsync([FromBody] ServiceRequestDTO model)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var response = await _clientServiceRequest.AddServiceRequestAsync(model);
			return Ok(response);
		}

		/// <summary>
		/// Gets all service request that user has had
		/// </summary>
		/// <param name="userId">Id of the user</param>
		[HttpGet("GetServiceRequestForUser/{userId}")]
		public async Task<IActionResult> GetUserServiceRequestsAsync(string userId)
		{
			if (string.IsNullOrEmpty(userId) || string.IsNullOrWhiteSpace(userId))
			{
				return BadRequest("User Id can not be empty");
			}

			return Ok(await _clientServiceRequest.GetUserServiceRequestsAsync(userId));
		}

		/// <summary>
		/// Gets service request with the specified id
		/// </summary>
		/// <param name="serviceRequestId">Service request id</param>
		[HttpGet("GetServiceRequestById/{serviceRequestId}")]
		public async Task<IActionResult> GetServiceRequestByIdAsync(int serviceRequestId)
		{
			return Ok(await _clientServiceRequest.GetUserServiceRequestByIdAsync(serviceRequestId));
		}
	}
}