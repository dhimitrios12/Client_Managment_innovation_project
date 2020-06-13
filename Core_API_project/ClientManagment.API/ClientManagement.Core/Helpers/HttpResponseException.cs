using System;

namespace ClientManagement.Core.Helpers
{
	public class HttpResponseException : Exception
	{
		public int Status { get; set; } = 500;
		public string Field { get; set; }

		public HttpResponseException(int status, string field, string message) : base(message)
		{
			Status = status;
			Field = field;
		}
	}
}