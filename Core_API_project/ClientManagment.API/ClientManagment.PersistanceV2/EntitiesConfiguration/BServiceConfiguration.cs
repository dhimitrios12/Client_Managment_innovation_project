using ClientManagement.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClientManagment.PersistanceV2.EntitiesConfiguration
{
	public class BServiceConfiguration : IEntityTypeConfiguration<BService>
	{
		public void Configure(EntityTypeBuilder<BService> builder)
		{
			builder.ToTable("Services");
			builder.HasKey(x => x.Id);
			builder.Property(x => x.ServiceName).IsRequired().HasMaxLength(100);
			builder.Property(x => x.Description).IsRequired().HasMaxLength(1000);
			builder.Property(x => x.Price).IsRequired().HasColumnType("decimal(18, 2)");
			builder.Property(x => x.Duration).IsRequired();
			builder.Property(x => x.IsActive).IsRequired();
			builder.Property(x => x.CreatedOn).IsRequired();
			builder.Property(x => x.ModifiedOn).IsRequired();
			builder.HasOne(x => x.Business)
				.WithMany(x => x.Services)
				.HasForeignKey(x => x.BusinessId);
		}
	}
}