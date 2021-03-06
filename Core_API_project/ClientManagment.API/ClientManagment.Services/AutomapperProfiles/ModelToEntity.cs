﻿using System.Collections.Generic;
using AutoMapper;
using ClientManagement.Core.Entities;
using ClientManagement.Core.Entities.DTO;

namespace ClientManagment.Services.AutomapperProfiles
{
	public class ModelToEntity : Profile
	{
		public ModelToEntity()
		{
			CreateMap<BusinessModel, Business>();
			CreateMap<BServiceDTO, BService>();
			CreateMap<ServiceRequestDTO, ServiceRequest>();
			CreateMap<RegisterViewModel, ApplicationUser>();
		}
	}
}