using System.Linq;
using System.Threading.Tasks;
using ClientManagement.Core.Entities;
using ClientManagement.Core.Helpers;
using Microsoft.AspNetCore.Identity;

namespace ClientManagment.PersistanceV2.DefaultAuthSeeds
{
	public class AuthorizationDataSeed
	{
		public static async Task SeedEssentialAsync(UserManager<ApplicationUser> userManager,
			RoleManager<IdentityRole> roleManager)
		{
			// Seed roles
			await roleManager.CreateAsync(new IdentityRole(Authorization.Roles.Administrator.ToString()));
			await roleManager.CreateAsync(new IdentityRole(Authorization.Roles.Businessman.ToString()));
			await roleManager.CreateAsync(new IdentityRole(Authorization.Roles.Customer.ToString()));

			// Seed default users
			var defaultAdministrator = new ApplicationUser
			{
				UserName = Authorization.defaultAdmin_username, 
				Email = Authorization.defaultAdmin_email, 
				EmailConfirmed = true, 
				PhoneNumberConfirmed = true
			};
			var defaultBusinessman = new ApplicationUser
			{
				UserName = Authorization.defaultBusinessman_username,
				Email = Authorization.defaultBusinessman_email,
				EmailConfirmed = true,
				PhoneNumberConfirmed = true
			};
			var defaultCustomer = new ApplicationUser
			{
				UserName = Authorization.defaultCustomer_username,
				Email = Authorization.defaultCustomer_email,
				EmailConfirmed = true,
				PhoneNumberConfirmed = true
			};

			await CreateUsers(defaultAdministrator, Authorization.defaultAdmin_password,
				Authorization.defaultAdmin_role,
				userManager, roleManager);
			await CreateUsers(defaultBusinessman, Authorization.defaultBusinessman_password,
				Authorization.defaultBusinessman_role,
				userManager, roleManager);
			await CreateUsers(defaultCustomer, Authorization.defaultBusinessman_password,
				Authorization.defaultCustomer_role,
				userManager, roleManager);
		}

		private static async Task CreateUsers(ApplicationUser user, string password, Authorization.Roles role, 
			UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
		{
			if (userManager.Users.All(u => u.Id != user.Id))
			{
				await userManager.CreateAsync(user, password);
				await userManager.AddToRoleAsync(user, role.ToString());
			}
		}
	}
}