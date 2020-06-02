using System.Threading.Tasks;
using AutoMapper;
using ClientManagement.Core.Entities;
using ClientManagement.Core.Entities.DTO;
using ClientManagement.Core.Helpers;
using ClientManagement.Core.Services;
using ClientManagment.PersistanceV2.Contexts;
using Microsoft.EntityFrameworkCore;

namespace ClientManagment.Services.Services
{
	public class BusinessService : IBusinessService
	{
		private readonly ApplicationDBContext _context;
		private readonly IMapper _mapper;

		public BusinessService(ApplicationDBContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public async Task<BusinessModel> AddBusinessAsync(BusinessModel model)
		{
			// If there is already a business with this name
			var business = await _context.Business
				.FirstOrDefaultAsync(x => x.Name.Trim() == model.Name.Trim());
			if (business != null)
			{
				throw new HttpResponseException()
				{
					Status = 409, Value = new {Name = "There is already a business registered with this name"}
				};
			}

			// Check if business type exists
			var businessType = await _context.BusinessTypes
				.FirstOrDefaultAsync(x => x.Id == model.BusinessTypeId
				                          && x.IsActive == true);
			if (businessType == null)
			{
				throw new HttpResponseException()
				{
					Status = 409,
					Value = new { BusinessTypeId = $"There is no active business type with id of {model.BusinessTypeId}" }
				};
			}

			// Create new business
			business = _mapper.Map<BusinessModel, Business>(model);
			await _context.Business.AddAsync(business);
			await _context.SaveChangesAsync();
			return _mapper.Map<Business, BusinessModel>(business);
		}

		public Task<BusinessModel> GetBusinessByIdAsync(int businessId)
		{
			throw new System.NotImplementedException();
		}
	}
}