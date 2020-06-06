using System;
using System.Collections.Generic;

namespace ClientManagement.Core.Entities.DTO
{
	public class ServiceRequestDTO
	{
		public string Notes { get; set; }
		public DateTime StartTime { get; set; }
		public DateTime EndTime { get; set; }
		public string UserId { get; set; }
		public List<int> ServicesIds { get; set; }
	}
}