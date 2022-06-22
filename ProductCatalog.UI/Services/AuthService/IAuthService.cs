using ProductCatalog.UI.Models;
using ProductCatalog.UI.Models.AuthViewModel;

namespace ProductCatalog.UI.Services
{
	public interface IAuthService
	{
		Task<HttpResponseMessage> LogIn(LogInViewModel user);
		Task<ServiceResponse<bool>> SignUp(SignUpViewModel newUser);
		Task<LoggedInUserIdViewModel> GetLoggedInUserId();
	}
}
