using System.Collections.Generic;

namespace ClientManagement.Core.Entities.DTO
{
	public class UserManagerResponse
	{
		public string Message { get; set; }
		public bool IsSuccess { get; set; }

		public IEnumerable<string> Errors { get; set; }
	}
}