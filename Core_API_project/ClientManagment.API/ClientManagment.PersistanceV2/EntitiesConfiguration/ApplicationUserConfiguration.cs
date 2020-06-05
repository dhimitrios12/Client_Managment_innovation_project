using ClientManagement.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClientManagment.PersistanceV2.EntitiesConfiguration
{
	public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
	{
		public void Configure(EntityTypeBuilder<ApplicationUser> builder)
		{
			builder.ToTable("Users");
			builder.Property(x => x.Name)
				.IsRequired()
				.HasMaxLength(50);
			builder.Property(x => x.Surname)
				.IsRequired()
				.HasMaxLength(50);
		}
	}
}