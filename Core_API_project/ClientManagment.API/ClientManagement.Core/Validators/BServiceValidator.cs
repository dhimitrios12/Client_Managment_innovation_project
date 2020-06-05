using ClientManagement.Core.Entities.DTO;
using FluentValidation;

namespace ClientManagement.Core.Validators
{
	public class BServiceValidator : AbstractValidator<BServiceDTO>
	{
		public BServiceValidator()
		{
			RuleFor(x => x.ServiceName).NotEmpty().MaximumLength(100);
			RuleFor(x => x.Description).NotEmpty().MaximumLength(1000);
			RuleFor(x => x.Price).GreaterThanOrEqualTo(0.0);
			RuleFor(x => x.Duration).NotEmpty()
				.GreaterThanOrEqualTo(5.0)
				.WithMessage("The duration must take 5 minutes or longer");
			RuleFor(x => x.BusinessId).NotEmpty();
		}
	}
}