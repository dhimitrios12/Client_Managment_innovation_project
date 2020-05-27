using ClientManagement.Core.Entities.DTO;
using ClientManagement.Core.Validators.CustomValidators;
using FluentValidation;

namespace ClientManagement.Core.Validators
{
	public class RegisterModelValidator : AbstractValidator<RegisterViewModel>
	{
		public RegisterModelValidator()
		{
			RuleFor(x => x.Email).EmailAddress().NotEmpty();
			RuleFor(x => x.Password).SetValidator(new UserPasswordValidator())
				.NotEmpty().MinimumLength(6);
			RuleFor(x => x.ConfirmPassword)
				.Must((registerViewModel, confirmPass) => confirmPass == registerViewModel.Password)
				.NotEmpty();
		}
	}
}