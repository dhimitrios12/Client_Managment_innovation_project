using Microsoft.AspNetCore.Identity;

namespace ClientManagement.Core.Entities
{
	public class ApplicationUser : IdentityUser
	{
		public string Name { get; set; }
		public string Surname { get; set; }
		public string Notes { get; set; }
	}
}