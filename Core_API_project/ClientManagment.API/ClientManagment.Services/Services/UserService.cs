using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
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
		private readonly IMapper _mapper;

		public UserService(UserManager<ApplicationUser> userManager, 
			RoleManager<IdentityRole> roleManager, 
			IOptions<TokenOptionsModel> tokenOptions, 
			IMapper mapper)
		{
			_userManager = userManager;
			_roleManager = roleManager;
			_mapper = mapper;
			_tokenOptions = tokenOptions.Value;
		}

		public async Task<UserAuthenticationModel> RegisterUserAsync(RegisterViewModel model)
		{
			var user = _mapper.Map<ApplicationUser>(model);

			var userWithSameEmail = await _userManager.FindByEmailAsync(user.Email);
			if (userWithSameEmail != null)
			{
				throw new HttpResponseException
				{
					Status = 409,
					Value = new
					{
						Field = "Email",
						Message = $"There is already an user registered with this email: {user.Email}"
					}
				};
			}

			user.UserName = string.Format("{0}.{1}", user.Name.ToLowerInvariant(), user.Surname.ToLowerInvariant());
			var result = await _userManager.CreateAsync(user, model.Password);

			if (result.Succeeded == true)
			{
				await _userManager.AddToRoleAsync(user, Authorization.Roles.Customer.ToString());
				
				var authenticationModel = new UserAuthenticationModel
				{
					UserId = user.Id,
					Email = user.Email,
					Roles = new List<string>{ Authorization.Roles.Customer.ToString() }
				};
				var tokenData = await GenerateJwtSecurityToken(user);
				authenticationModel.TokenExpirationDate = DateTime.Parse(tokenData["expireDate"].ToString());
				authenticationModel.Token = tokenData["token"].ToString();
				return authenticationModel;
			}


			// Could not create user for some reason
			throw new HttpResponseException
			{
				Status = 500,
				Value = new
				{
					Field = "None",
					Message = $"Could not register user. InternalError."
				}
			};
		}

		public async Task<UserAuthenticationModel> GetTokenAsync(LoginModel model)
		{
			var user = await _userManager.FindByEmailAsync(model.Email);
			if (user == null)
			{
				throw new HttpResponseException
				{
					Status = 404,
					Value = new { Field = "Email", 
						Message = "There are no accounts registered with this email." }
				};
			}

			if (await _userManager.CheckPasswordAsync(user, model.Password))
			{
				var authenticationModel = _mapper.Map<UserAuthenticationModel>(user);
				var tokenData = await GenerateJwtSecurityToken(user);
				authenticationModel.Token = tokenData["token"].ToString();
				authenticationModel.TokenExpirationDate = DateTime.Parse(tokenData["expireDate"].ToString());
				// authenticationModel.Name = user.Name;
				// authenticationModel.Surname = user.Surname;
				// authenticationModel.Email = user.Email;
				// authenticationModel.UserId = user.Id;
				var rolesList = await _userManager.GetRolesAsync(user);
				authenticationModel.Roles = rolesList.ToList();
				return authenticationModel;
			}

			// Incorrect credentials
			throw new HttpResponseException
			{
				Status = 404,
				Value = new
				{
					Field = "Password",
					Message = "Incorrect password"
				}
			};
		}

		private async Task<Dictionary<string, object>> GenerateJwtSecurityToken(ApplicationUser user)
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
			DateTime expireDate = DateTime.UtcNow.AddDays(Double.Parse(_tokenOptions.AccessTokenExpiration));
			var jwtSecurityToken = new JwtSecurityToken(
					issuer: _tokenOptions.Issuer,
					audience: _tokenOptions.Audience,
					claims: claims,
					expires: expireDate,
					signingCredentials: signingCredentials
				);
			var jwtTokenHandler = new JwtSecurityTokenHandler();
			return new Dictionary<string, object>()
			{
				{"token", jwtTokenHandler.WriteToken(jwtSecurityToken)},
				{"expireDate", expireDate}
			};
		}
	}
}