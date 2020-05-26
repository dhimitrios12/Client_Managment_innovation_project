using System.Collections.Generic;
using System.Threading.Tasks;
using ClientManagement.Core.Entities;

namespace ClientManagement.Core.Services
{
	public interface IBusinessTypeService
	{
		Task<List<BusinessType>> GetBusinessTypesAsync();
		Task<List<BusinessType>> GetActiveBusinessTypesAsync();
	}
}