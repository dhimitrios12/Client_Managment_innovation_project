using ClientManagement.Core.Entities.DTO;
using FluentValidation;

namespace ClientManagement.Core.Validators
{
	public class BusinessModelValidator : AbstractValidator<BusinessModel>
	{
		public BusinessModelValidator()
		{
			RuleFor(x => x.Name).NotEmpty().MaximumLength(150);
			RuleFor(x => x.Address).NotEmpty().MaximumLength(500);
			RuleFor(x => x.StartTime).NotEmpty();
			RuleFor(x => x.FinishTime).NotEmpty();
			RuleFor(x => x.BusinessTypeId).NotEmpty();
			RuleFor(x => x.UserId).NotEmpty();
		}
	}
}