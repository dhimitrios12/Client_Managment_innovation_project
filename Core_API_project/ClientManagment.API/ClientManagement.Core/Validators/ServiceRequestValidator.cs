using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using ClientManagement.Core.Entities.DTO;
using FluentValidation;

namespace ClientManagement.Core.Validators
{
	public class ServiceRequestValidator : AbstractValidator<ServiceRequestDTO>
	{
		public ServiceRequestValidator()
		{
			RuleFor(x => x.UserId).NotEmpty();
			RuleFor(x => x.StartTime).NotEmpty()
				.GreaterThanOrEqualTo(DateTime.Now.AddHours(-1));
			RuleFor(x => x.EndTime).NotEmpty()
				.Must((model, endTime) => endTime > model.StartTime);
			RuleFor(x => x.ServicesIds).NotEmpty()
				.Must(x => x.Count > 0 && x.Distinct().Count() == x.Count);
		}
	}
}