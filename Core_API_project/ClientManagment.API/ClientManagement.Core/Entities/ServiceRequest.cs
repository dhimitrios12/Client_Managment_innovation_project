using System;
using System.Collections.Generic;
using System.Reflection;

namespace ClientManagement.Core.Entities
{
	public class ServiceRequest
	{
		public int Id { get; set; }
		public bool IsApproved { get; set; }
		public string Notes { get; set; }
		public DateTime StartTime { get; set; }
		public DateTime EndTime { get; set; }
		public DateTime CreatedOn { get; set; }
		public bool IsActive { get; set; }
		public IList<ServiceServiceRequest> ServiceServiceRequests { get; set; }
		public string UserId { get; set; }
		public ApplicationUser Client { get; set; }
	}
}