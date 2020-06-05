using System;
using System.Collections.Generic;

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
		public virtual BusinessType BusinessType { get; set; }
		public virtual ICollection<BService> Services { get; set; }
		public string UserId { get; set; }
		public virtual ApplicationUser User { get; set; }
	}
}