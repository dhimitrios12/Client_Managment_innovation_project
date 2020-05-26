using System.Linq;
using System.Threading.Tasks;
using ClientManagement.Core.Entities;
using ClientManagement.Core.Entities.DTO;
using ClientManagement.Core.Helpers;
using ClientManagement.Core.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.JsonWebTokens;

namespace ClientManagment.Services.Services
{
	public class UserService : IUserService
	{
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly RoleManager<IdentityRole> _roleManager;
		private readonly TokenOptionsModel _tokenOptions;

		public UserService(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IOptions<TokenOptionsModel> tokenOptions)
		{
			_userManager = userManager;
			_roleManager = roleManager;
			_tokenOptions = tokenOptions.Value;
		}

		public async Task<UserManagerResponse> RegisterUserAsync(RegisterViewModel model)
		{
			if (model.Password != model.ConfirmPassword)
			{
				return new UserManagerResponse
				{
					Message = "Passwords do not match",
					IsSuccess = false
				};
			}

			var user = new ApplicationUser
			{
				Email = model.Email, 
				UserName = model.Email
			};

			var userWithSameEmail = await _userManager.FindByEmailAsync(user.Email);
			if (userWithSameEmail != null)
			{
				return new UserManagerResponse
				{
					Message = "Cold not create user.",
					IsSuccess = false,
					Errors = new string[] { "There is already a user registered with this email." },
				};
			}

			var result = await _userManager.CreateAsync(user, model.Password);

			if (result.Succeeded == true)
			{
				await _userManager.AddToRoleAsync(user, Authorization.Roles.Customer.ToString());
				return new UserManagerResponse
				{
					Message = "User was created successfully.",
					IsSuccess = true
				};
			}

			return new UserManagerResponse
			{
				Message = "Cold not create user.",
				IsSuccess = false,
				Errors = result.Errors.Select(e => e.Description)
			};
		}
	}
}