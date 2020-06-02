using System.Threading.Tasks;
using ClientManagement.Core.Entities.DTO;

namespace ClientManagement.Core.Services
{
	public interface IBusinessService
	{
		Task<BusinessModel> AddBusinessAsync(BusinessModel model);
		Task<BusinessModel> GetBusinessByIdAsync(int businessId);
	}
}