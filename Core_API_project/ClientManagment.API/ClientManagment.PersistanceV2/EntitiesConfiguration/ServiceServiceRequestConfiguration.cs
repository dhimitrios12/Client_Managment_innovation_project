using ClientManagement.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClientManagment.PersistanceV2.EntitiesConfiguration
{
	public class ServiceServiceRequestConfiguration : IEntityTypeConfiguration<ServiceServiceRequest>
	{
		public void Configure(EntityTypeBuilder<ServiceServiceRequest> builder)
		{
			builder.ToTable("ServiceXServiceRequests");
			builder.HasKey(x => new {x.ServiceId, x.ServiceRequestId});
			builder.HasOne(x => x.Service)
				.WithMany(x => x.ServiceServiceRequests)
				.HasForeignKey(x => x.ServiceId);
			builder.HasOne(x => x.ServiceRequest)
				.WithMany(x => x.ServiceServiceRequests)
				.HasForeignKey(x => x.ServiceRequestId);
		}
	}
}