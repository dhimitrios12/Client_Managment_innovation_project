using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ClientManagement.Core.DTO;
using ClientManagement.Core.Entities;
using ClientManagement.Core.Entities.DTO;
using ClientManagement.Core.Helpers;
using ClientManagement.Core.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

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

		public async Task<UserAuthenticationModel> GetTokenAsync(LoginModel model)
		{
			var authenticationModel = new UserAuthenticationModel();
			var user = await _userManager.FindByEmailAsync(model.Email);
			if (user == null)
			{
				authenticationModel.IsAuthenticated = false;
				authenticationModel.Message = "There are no accounts registered with this email.";
				return authenticationModel;
			}

			if (await _userManager.CheckPasswordAsync(user, model.Password))
			{
				authenticationModel.IsAuthenticated = true;
				authenticationModel.Token = await GenerateJWTSecurityToken(user);
				authenticationModel.Email = user.Email;
				var rolesList = await _userManager.GetRolesAsync(user);
				authenticationModel.Roles = rolesList.ToList();
				return authenticationModel;
			}
			// Incorrect credentials
			authenticationModel.IsAuthenticated = false;
			authenticationModel.Message = "Incorrect credentials";
			return authenticationModel;
		}

		private async Task<string> GenerateJWTSecurityToken(ApplicationUser user)
		{
			var userClaims = await _userManager.GetClaimsAsync(user);
			var userRoles = await _userManager.GetRolesAsync(user);

			// Generating role claims
			var roleClaims = new List<Claim>();
			foreach (string userRole in userRoles)
			{
					roleClaims.Add(new Claim("roles", userRole));
			}

			// Putting all claims together
			var claims = new []
			{
				new Claim(JwtRegisteredClaimNames.Email, user.Email),
				new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName),
				new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()), 
				new Claim("userId", user.Id), 
			}
			.Union(userClaims)
			.Union(roleClaims);

			var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenOptions.Key));
			var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

			// Building JWT
			var jwtSecurityToken = new JwtSecurityToken(
					issuer: _tokenOptions.Issuer,
					audience: _tokenOptions.Audience,
					claims: claims,
					expires: DateTime.UtcNow.AddDays(Double.Parse(_tokenOptions.AccessTokenExpiration)),
					signingCredentials: signingCredentials
				);
			var jwtTokenHandler = new JwtSecurityTokenHandler();
			return jwtTokenHandler.WriteToken(jwtSecurityToken);
		}
	}
}