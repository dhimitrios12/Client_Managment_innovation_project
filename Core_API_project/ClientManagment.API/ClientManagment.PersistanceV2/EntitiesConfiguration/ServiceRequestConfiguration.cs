using ClientManagement.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClientManagment.PersistanceV2.EntitiesConfiguration
{
	public class ServiceRequestConfiguration : IEntityTypeConfiguration<ServiceRequest>
	{
		public void Configure(EntityTypeBuilder<ServiceRequest> builder)
		{
			builder.ToTable("ServiceRequest");
			builder.HasKey(x => x.Id);
			builder.Property(x => x.IsApproved).HasDefaultValue(false);
			builder.Property(x => x.Notes).HasMaxLength(500);
			builder.Property(x => x.StartTime).IsRequired();
			builder.Property(x => x.EndTime).IsRequired();
			builder.Property(x => x.CreatedOn).IsRequired();
			builder.Property(x => x.UserId).IsRequired();
			builder.HasOne(x => x.Client)
				.WithMany()
				.HasForeignKey(x => x.UserId);
		}
	}
}