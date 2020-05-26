using System;

namespace ClientManagement.Core.Helpers
{
	public class CustomException : Exception
	{
		public int ErrorCode { get; set; }
		public CustomException(int errorCode, string errorMessage) : base(errorMessage)
		{
			ErrorCode = errorCode;
		}
	}
}