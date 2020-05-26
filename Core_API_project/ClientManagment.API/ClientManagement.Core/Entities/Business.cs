using System;

namespace ClientManagement.Core.Entities
{
	public class Business
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Address { get; set; }
		public DateTime StartTime { get; set; }
		public DateTime FinishTime { get; set; }
		public int BusinessTypeId { get; set; }
		public bool IsActive { get; set; }
		public BusinessType BusinessType { get; set; }
	}
}