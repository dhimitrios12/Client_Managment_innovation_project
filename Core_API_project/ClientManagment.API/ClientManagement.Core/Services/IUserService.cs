using System.Threading.Tasks;
using ClientManagement.Core.Entities.DTO;

namespace ClientManagement.Core.Services
{
	public interface IUserService
	{
		Task<UserManagerResponse> RegisterUserAsync(RegisterViewModel model);
		Task<UserAuthenticationModel> GetTokenAsync(LoginModel model);
	}
}