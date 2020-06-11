using System.Threading.Tasks;
using ClientManagement.Core.Entities;
using ClientManagement.Core.Entities.DTO;

namespace ClientManagement.Core.Services
{
	public interface IUserService
	{
		Task<UserAuthenticationModel> RegisterUserAsync(RegisterViewModel model);
		Task<UserAuthenticationModel> GetTokenAsync(LoginModel model);
	}
}