namespace ClientManagement.Core.Helpers
{
	public class TokenOptionsModel
	{
		public string Key { get; set; }
		public string Audience { get; set; }
		public string Issuer { get; set; }
		public string AccessTokenExpiration { get; set; }
	}
}