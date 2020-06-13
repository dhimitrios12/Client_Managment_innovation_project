using System.Linq;
using AutoMapper;
using ClientManagement.Core.Entities;
using ClientManagement.Core.Entities.DTO;

namespace ClientManagment.Services.AutomapperProfiles
{
	public class EntityToModel : Profile
	{
		public EntityToModel()
		{
			CreateMap<Business, BusinessModel>();
			CreateMap<BService, BServiceDTO>();
			CreateMap<ServiceRequest, ServiceRequestResponseDTO>()
				.ForMember(dto => dto.Services, 
					opt => 
						opt.MapFrom(x => x.ServiceServiceRequests
							.Select(ssr => ssr.Service).ToList()));
			CreateMap<ApplicationUser, UserAuthenticationModel>()
				.ForMember(x => x.UserId, 
					opt => 
						opt.MapFrom(y => y.Id));
			
			CreateMap<ServiceRequest, BusinessScheduledServiceRequestItemDto>()
				.ForMember(x => x.Services,
					opt =>
						opt.MapFrom(y => y.ServiceServiceRequests
							.Select(s => s.Service).ToList()))
				.ForMember(x => x.UserName,
					opt =>
						opt.MapFrom(y => y.Client.Name))
				.ForMember(x => x.UserSurname,
					opt =>
						opt.MapFrom(y => y.Client.Surname))
				.ForMember(x => x.ServiceRequestId, 
					opt => 
						opt.MapFrom(y => y.Id));
		}
	}
}