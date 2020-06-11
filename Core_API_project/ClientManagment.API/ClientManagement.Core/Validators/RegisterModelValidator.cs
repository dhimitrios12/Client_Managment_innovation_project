using ClientManagement.Core.Entities.DTO;
using ClientManagement.Core.Validators.CustomValidators;
using FluentValidation;

namespace ClientManagement.Core.Validators
{
	public class RegisterModelValidator : AbstractValidator<RegisterViewModel>
	{
		public RegisterModelValidator()
		{
			RuleFor(x => x.Name).NotEmpty().MaximumLength(50);
			RuleFor(x => x.Surname).NotEmpty().MaximumLength(50);
			RuleFor(x => x.Email).EmailAddress().NotEmpty();
			RuleFor(x => x.Password).SetValidator(new UserPasswordValidator())
				.NotEmpty().MinimumLength(6);
		}
	}
}