using ClientManagement.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClientManagment.PersistanceV2.EntitiesConfiguration
{
	public class BusinessConfiguration : IEntityTypeConfiguration<Business>
	{
		public void Configure(EntityTypeBuilder<Business> builder)
		{
			builder.ToTable("Business");
			builder.HasKey(b => b.Id);
			builder.Property(b => b.Name).IsRequired().HasMaxLength(150);
			builder.Property(b => b.Address).IsRequired().HasMaxLength(500);
			builder.Property(b => b.StartTime).IsRequired();
			builder.Property(b => b.FinishTime).IsRequired();
			builder.Property(b => b.IsActive);
			builder.HasOne(b => b.BusinessType)
				.WithMany(b => b.Businesses)
				.HasForeignKey(b => b.BusinessTypeId)
				.OnDelete(DeleteBehavior.Restrict);
		}
	}
}