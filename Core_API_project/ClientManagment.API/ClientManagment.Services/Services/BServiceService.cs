using System;
using System.Collections.Generic;
using System.Linq;
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
	public class BServiceService : IBService
	{
		private readonly ApplicationDBContext _context;
		private readonly IMapper _mapper;

		public BServiceService(ApplicationDBContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public async Task<BServiceDTO> AddServiceAsync(BServiceDTO model)
		{
			// Check if business exists
			var business = await _context.Business
				.Include(x => x.Services)
				.FirstOrDefaultAsync(x => x.Id == model.BusinessId);

			if (business == null)
			{
				throw new HttpResponseException
				{
					Status = 400,
					Value = new
					{
						BusinessId = $"There is no business registered with Id = {model.BusinessId}"
					}
				};
			}

			var service = business.Services
				.FirstOrDefault(x => x.ServiceName == model.ServiceName);
				
			if (service != null)
			{
				throw new HttpResponseException
				{
					Status = 400, 
					Value = new
					{
						ServiceName = "There is already a service with this name registered in this business"
					}
				};
			}

			// Add new service
			service = _mapper.Map<BService>(model);
			service.CreatedOn = DateTime.UtcNow;
			service.ModifiedOn = DateTime.UtcNow;
			service.IsActive = true;
			await _context.Services.AddAsync(service);
			await _context.SaveChangesAsync();

			return _mapper.Map<BServiceDTO>(service);
		}

		public async Task<IEnumerable<BServiceDTO>> GetActiveServicesForBusinessAsync(int businessId)
		{
			// Check if business exists
			var business = await _context.Business
				.Include(x => x.Services)
				.FirstOrDefaultAsync(x => x.Id == businessId);

			if (business == null)
			{
				throw new HttpResponseException
				{
					Status = 400,
					Value = new
					{
						BusinessId = $"There is no business registered with Id = {businessId}"
					}
				};
			}

			return _mapper.Map<IEnumerable<BServiceDTO>>(business.Services);
		}
	}
}