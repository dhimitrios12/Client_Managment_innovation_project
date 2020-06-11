using System;
using System.Collections.Generic;

namespace ClientManagement.Core.Entities.DTO
{
	public class UserAuthenticationModel
	{
		public String UserId { get; set; }
		public string Email { get; set; }
		public List<string> Roles { get; set; }
		public DateTime? TokenExpirationDate { get; set; }
		public string Token { get; set; }
	}
}