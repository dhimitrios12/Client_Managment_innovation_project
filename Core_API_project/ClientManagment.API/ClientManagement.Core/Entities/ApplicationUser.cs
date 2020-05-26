using Microsoft.AspNetCore.Identity;

namespace ClientManagement.Core.Entities
{
	public class ApplicationUser : IdentityUser
	{
		public string Notes { get; set; }
	}
}