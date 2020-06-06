namespace ClientManagement.Core.Entities
{
	public class ServiceServiceRequest
	{
		public int ServiceId { get; set; }
		public BService Service { get; set; }
		public int ServiceRequestId { get; set; }
		public ServiceRequest ServiceRequest { get; set; }
	}
}