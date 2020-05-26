using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClientManagement.Core.Entities;
using ClientManagment.PersistanceV2.DefaultAuthSeeds;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ClientManagment.API
{
	public class Program
	{
		public static async Task Main(string[] args)
		{
			var host = CreateHostBuilder(args).Build();

			using (var scope = host.Services.CreateScope())
			{
				var services = scope.ServiceProvider;
				var loggerFactory = services.GetRequiredService<ILoggerFactory>();
				try
				{
					// Seed default Users and Roles
					var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
					var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
					await AuthorizationDataSeed.SeedEssentialAsync(userManager, roleManager);
				}
				catch (Exception e)
				{
					var logger = loggerFactory.CreateLogger<Program>();
					logger.LogError("An error has occurred seeding data in the database");
				}
			}

			await host.RunAsync();
		}

		public static IHostBuilder CreateHostBuilder(string[] args) =>
			Host.CreateDefaultBuilder(args)
				.ConfigureWebHostDefaults(webBuilder =>
				{
					webBuilder.UseStartup<Startup>();
				});
	}
}
