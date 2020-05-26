namespace ClientManagement.Core.Helpers
{
	public class Authorization
	{
		public enum Roles
		{
			Administrator, 
			Businessman, 
			Customer
		}
		// Default Administrator
		public const string defaultAdmin_username = "admin";
		public const string defaultAdmin_email = "admin@admin.com";
		public const string defaultAdmin_password = "Admin123";
		public const Roles defaultAdmin_role = Roles.Administrator;
		// Default Businessman
		public const string defaultBusinessman_username = "businessman";
		public const string defaultBusinessman_email = "businessman@businessman.com";
		public const string defaultBusinessman_password = "Businessman123";
		public const Roles defaultBusinessman_role = Roles.Businessman;
		// Default Customer
		public const string defaultCustomer_username = "customer";
		public const string defaultCustomer_email = "customer@customer.com";
		public const string defaultCustomer_password = "Customer123";
		public const Roles defaultCustomer_role = Roles.Customer;
	}
}