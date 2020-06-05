using System.Collections.Generic;
using System.Threading.Tasks;
using ClientManagement.Core.Entities.DTO;

namespace ClientManagement.Core.Services
{
	public interface IBService
	{
		Task<BServiceDTO> AddServiceAsync(BServiceDTO model);
		Task<IEnumerable<BServiceDTO>> GetActiveServicesForBusinessAsync(int businessId);
	}
}