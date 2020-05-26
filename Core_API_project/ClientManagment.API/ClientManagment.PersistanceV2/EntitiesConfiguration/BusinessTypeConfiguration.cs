using ClientManagement.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClientManagment.PersistanceV2.EntitiesConfiguration
{
	public class BusinessTypeConfiguration : IEntityTypeConfiguration<BusinessType>
	{
		public void Configure(EntityTypeBuilder<BusinessType> builder)
		{
			builder.HasKey(x => x.Id);
			builder.Property(x => x.Name).IsRequired().HasMaxLength(150);

			builder.HasData(
					new BusinessType {Id = 1, Name = "Berber", IsActive = true}
				);
		}
	}
}