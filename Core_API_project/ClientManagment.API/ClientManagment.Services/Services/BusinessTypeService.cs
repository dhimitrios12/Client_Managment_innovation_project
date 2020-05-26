using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClientManagement.Core.Entities;
using ClientManagement.Core.Services;
using ClientManagment.PersistanceV2.Contexts;
using Microsoft.EntityFrameworkCore;

namespace ClientManagment.Services.Services
{
	public class BusinessTypeService : IBusinessTypeService
	{
		private readonly ApplicationDBContext _context;

		public BusinessTypeService(ApplicationDBContext context)
		{
			_context = context;
		}

		public async Task<List<BusinessType>> GetBusinessTypesAsync()
		{
			return await _context.BusinessTypes.ToListAsync();
		}

		public async Task<List<BusinessType>> GetActiveBusinessTypesAsync()
		{
			return await _context.BusinessTypes
				.Where(b => b.IsActive == true)
				.ToListAsync();
		}
	}
}