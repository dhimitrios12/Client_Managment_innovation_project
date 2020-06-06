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
		}
	}
}