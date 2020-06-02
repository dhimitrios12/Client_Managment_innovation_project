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
		}
	}
}