using System.Linq;
using System.Threading.Tasks;
using ClientManagement.Core.Entities;
using ClientManagement.Core.Entities.DTO;
using ClientManagement.Core.Helpers;
using ClientManagement.Core.Services;
using Microsoft.AspNetCore.Identity;

namespace ClientManagment.Services.Services
{
	public class UserService : IUserService
	{
		private readonly UserManager<ApplicationUser> _userManager;

		public UserService(UserManager<ApplicationUser> userManager)
		{
			_userManager = userManager;
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

			var result = await _userManager.CreateAsync(user, model.Password);

			if (result.Succeeded == true)
			{
				return new UserManagerResponse
				{
					Message = "User was created successfully",
					IsSuccess = true
				};
			}

			return new UserManagerResponse
			{
				Message = "Cold not create user",
				IsSuccess = false,
				Errors = result.Errors.Select(e => e.Description)
			};
		}
	}
}