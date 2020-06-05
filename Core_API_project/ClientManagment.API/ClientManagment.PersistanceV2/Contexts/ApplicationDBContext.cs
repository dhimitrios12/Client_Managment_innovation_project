using System;
using System.Collections.Generic;
using System.Text;
using ClientManagement.Core.Entities;
using ClientManagment.PersistanceV2.EntitiesConfiguration;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ClientManagment.PersistanceV2.Contexts
{
	public class ApplicationDBContext : IdentityDbContext<ApplicationUser>
	{
		public ApplicationDBContext(DbContextOptions options) : base(options)
		{
			
		}

		public DbSet<BusinessType> BusinessTypes { get; set; }
		public DbSet<Business> Business { get; set; }
		public DbSet<BService> Services { get; set; }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);
			// Changing default identity tables names
			builder.ApplyConfiguration(new ApplicationUserConfiguration());
			builder.Entity<IdentityRole>().ToTable("Roles");
			builder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims");
			builder.Entity<IdentityUserToken<string>>().ToTable("UserTokens");
			builder.Entity<IdentityUserLogin<string>>().ToTable("UserLogins");
			builder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaims");
			builder.Entity<IdentityUserRole<string>>().ToTable("UserRoles");

			//// Seeding data for roles
			//builder.Entity<IdentityRole>().HasData(
			//	new IdentityRole("Admin"){NormalizedName = "ADMIN"},
			//	new IdentityRole("Customer"){NormalizedName = "CUSTOMER"},
			//	new IdentityRole("Businessmen") { NormalizedName = "BUSINESSMEN"}
			//	);

			builder.ApplyConfiguration(new BusinessTypeConfiguration());
			builder.ApplyConfiguration(new BusinessConfiguration());
			builder.ApplyConfiguration(new BServiceConfiguration());
		}
	}
}
