using System;

namespace ClientManagement.Core.Entities.DTO
{
	public class BusinessModel
	{
		public string Name { get; set; }
		public string Address { get; set; }
		public DateTime StartTime { get; set; }
		public DateTime FinishTime { get; set; }
		public int BusinessTypeId { get; set; }
	}
}