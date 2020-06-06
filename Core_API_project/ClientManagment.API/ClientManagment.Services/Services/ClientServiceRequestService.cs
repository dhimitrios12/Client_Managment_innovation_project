using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using ClientManagement.Core.Entities;
using ClientManagement.Core.Entities.DTO;
using ClientManagement.Core.Helpers;
using ClientManagement.Core.Services;
using ClientManagment.PersistanceV2.Contexts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ClientManagment.Services.Services
{
	public class ClientServiceRequestService : IClientServiceRequest
	{
		private readonly ApplicationDBContext _context;
		private readonly IMapper _mapper;
		private readonly UserManager<ApplicationUser> _userManager;

		public ClientServiceRequestService(ApplicationDBContext context, IMapper mapper, UserManager<ApplicationUser> userManager)
		{
			_context = context;
			_mapper = mapper;
			_userManager = userManager;
		}

		public async Task<IList<ServiceRequestResponseDTO>> GetUserServiceRequestsAsync(string userId)
		{
			var user = await _userManager.FindByIdAsync(userId);

			if (user == null)
			{
				throw new HttpResponseException
				{
					Status = 404,
					Value = new { UserId = $"User with id = {userId} does not exist" }
				};
			}

			var services = await _context.ServiceRequests
				.Include(x => x.ServiceServiceRequests)
				.ThenInclude(x => x.Service)
				.Where(x => x.UserId == userId)
				.ToListAsync();
			return _mapper.Map<IList<ServiceRequestResponseDTO>>(services);
		}

		public async Task<IList<ServiceRequestResponseDTO>> GetActiveUserServiceRequestsAsync(string userId)
		{
			var user = await _userManager.FindByIdAsync(userId);

			if (user == null)
			{
				throw new HttpResponseException
				{
					Status = 404,
					Value = new { UserId = $"User with id = {userId} does not exist" }
				};
			}

			var services = await _context.ServiceRequests
				.Include(x => x.ServiceServiceRequests)
				.ThenInclude(x => x.Service)
				.Where(x => x.UserId == userId && x.IsApproved == true)
				.ToListAsync();
			return _mapper.Map<IList<ServiceRequestResponseDTO>>(services);
		}

		public async Task<ServiceRequestResponseDTO> GetUserServiceRequestByIdAsync(int serviceRequestId)
		{
			var serviceRequest = await _context.ServiceRequests
				.Include(x => x.ServiceServiceRequests)
				.ThenInclude(x => x.Service)
				.FirstOrDefaultAsync(x => x.Id == serviceRequestId);

			return _mapper.Map<ServiceRequestResponseDTO>(serviceRequest);
		}

		public async Task<ServiceRequestResponseDTO> AddServiceRequestAsync(ServiceRequestDTO model)
		{
			var user = await _userManager.FindByIdAsync(model.UserId);

			if (user == null)
			{
				throw new HttpResponseException
				{
					Status = 404,
					Value = new { UserId = $"User with id = {model.UserId} does not exist" }
				};
			}

			ServiceRequest serviceRequest = _mapper.Map<ServiceRequest>(model);
			serviceRequest.CreatedOn = DateTime.UtcNow;
			serviceRequest.IsApproved = false;
			serviceRequest.Client = user;
			serviceRequest.ServiceServiceRequests = new List<ServiceServiceRequest>();
			foreach (int serviceId in model.ServicesIds)
			{
				var service = await _context.Services
					.FirstOrDefaultAsync(x => x.Id == serviceId && x.IsActive == true);

				if (service == null)
				{
					throw new HttpResponseException
					{
						Status = 404,
						Value = new {ServicesIds = "One or more services do not exist"}
					};
				}

				ServiceServiceRequest sxServiceRequest = new ServiceServiceRequest
				{
					Service = service
				};
				serviceRequest.ServiceServiceRequests.Add(sxServiceRequest);
			}

			await _context.ServiceRequests.AddAsync(serviceRequest);
			await _context.SaveChangesAsync();
			return _mapper.Map<ServiceRequestResponseDTO>(serviceRequest);
		}
	}
}