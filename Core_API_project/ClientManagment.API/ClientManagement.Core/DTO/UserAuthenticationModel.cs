using System.Collections.Generic;

namespace ClientManagement.Core.DTO
{
	public class UserAuthenticationModel
	{
		public bool IsAuthenticated { get; set; }
		public string Message { get; set; }
		public string Email { get; set; }
		public List<string> Roles { get; set; }
		public string Token { get; set; }
	}
}