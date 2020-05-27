using System.Linq;
using FluentValidation.Validators;

namespace ClientManagement.Core.Validators.CustomValidators
{
	public class UserPasswordValidator : PropertyValidator
	{
		public UserPasswordValidator() : base("'Password' must contain at least one number.")
		{

		}

		protected override bool IsValid(PropertyValidatorContext context)
		{
			var password = context.PropertyValue as string;
			if (!string.IsNullOrEmpty(password) && password.Any(char.IsDigit) && password.Any(char.IsUpper))
			{
				return true;
			}

			return false;
		}

	}
}