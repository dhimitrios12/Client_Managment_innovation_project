using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using ClientManagement.Core.Entities.DTO;

namespace ClientManagement.Core.Services
{
	public interface IClientServiceRequest
	{
		Task<IList<ServiceRequestResponseDTO>> GetUserServiceRequestsAsync(string userId);
		Task<IList<ServiceRequestResponseDTO>> GetActiveUserServiceRequestsAsync(string userId);
		Task<ServiceRequestResponseDTO> GetUserServiceRequestByIdAsync(int serviceRequestId);
		Task<ServiceRequestResponseDTO> AddServiceRequestAsync(ServiceRequestDTO model);
		Task<List<BusinessScheduledServiceRequestItemDto>> GetActiveServiceRequestForRBusinessAsync(IEnumerable<Claim> userClaims);
	}
}