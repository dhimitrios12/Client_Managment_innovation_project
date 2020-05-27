using ClientManagement.Core.DTO;
using FluentValidation;

namespace ClientManagement.Core.Validators
{
	public class LoginModelValidator : AbstractValidator<LoginModel>
	{
		public LoginModelValidator()
		{
			RuleFor(x => x.Email).NotEmpty().EmailAddress();
			RuleFor(x => x.Password).NotEmpty();
		}
	}
}