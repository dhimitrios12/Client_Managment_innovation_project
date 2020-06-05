using System;

namespace ClientManagement.Core.Entities.DTO
{
	public class BServiceDTO
	{
		public string ServiceName { get; set; }
		public string Description { get; set; }
		public double Price { get; set; }
		public double Duration { get; set; }
		public int BusinessId { get; set; }
	}
}