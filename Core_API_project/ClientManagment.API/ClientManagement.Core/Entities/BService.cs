using System;
using System.Collections.Generic;

namespace ClientManagement.Core.Entities
{
	public class BService
	{
		public int Id { get; set; }
		public string ServiceName { get; set; }
		public string Description { get; set; }
		public double Price { get; set; }
		public double Duration { get; set; }
		public bool IsActive { get; set; }
		public DateTime CreatedOn { get; set; }
		public DateTime ModifiedOn { get; set; }
		public int BusinessId { get; set; }
		public virtual Business Business { get; set; }
		public IList<ServiceServiceRequest> ServiceServiceRequests{ get; set; }
	}
}