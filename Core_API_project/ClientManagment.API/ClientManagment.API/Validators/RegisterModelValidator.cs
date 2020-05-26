using System.Security.Cryptography.X509Certificates;
using ClientManagement.Core.Entities.DTO;
using ClientManagment.API.Validators.CustomValidators;
using FluentValidation;

namespace ClientManagment.API.Validators
{
	public class RegisterModelValidator : AbstractValidator<RegisterViewModel>
	{
		public RegisterModelValidator()
		{
			RuleFor(x => x.Email).EmailAddress().NotEmpty();
			RuleFor(x => x.Password).SetValidator(new UserPasswordValidator())
				.NotEmpty().MinimumLength(6);
			RuleFor(x => x.ConfirmPassword)
				.Must((registerViewModel, confirmPass )=> confirmPass == registerViewModel.Password)
				.NotEmpty();
		}
	}
}