using System.Collections.Generic;
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
	}
}