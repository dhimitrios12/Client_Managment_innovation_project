using System.Collections;
using System.Collections.Generic;

namespace ClientManagement.Core.Entities
{
	public class BusinessType
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public bool IsActive { get; set; }
		public ICollection<Business> Businesses { get; set; }
	}
}