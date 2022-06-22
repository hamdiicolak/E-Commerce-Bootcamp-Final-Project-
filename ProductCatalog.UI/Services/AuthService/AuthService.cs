using ProductCatalog.UI.Extensions;
using ProductCatalog.UI.Models;
using System.Net.Http.Headers;
using System.Text.Json;
using Newtonsoft.Json;
using ProductCatalog.UI.Models.AuthViewModel;

namespace ProductCatalog.UI.Services
{
	public class AuthService : IAuthService
	{
		private readonly HttpClient _client;
		private readonly IHttpContextAccessor _httpContextAccessor;

		public AuthService(HttpClient client, IHttpContextAccessor httpContextAccessor)
		{
			_client = client;
			_httpContextAccessor = httpContextAccessor;
		}

		public async Task<LoggedInUserIdViewModel> GetLoggedInUserId()
		{
			string url = $"/api/Auth/GetLoggedInUserId";
			var result = await _client.ReadContentAs<LoggedInUserIdViewModel>(_httpContextAccessor.HttpContext, url);
			return result.ResponseData;
		}

		#region LogIn 

		public async Task<HttpResponseMessage> LogIn(LogInViewModel user)
		{
			string url = $"/api/Auth/LogIn?email={user.Email}&password={user.Password}";

			var request = new HttpRequestMessage(new HttpMethod("POST"), $"{url}");

			request.Headers.TryAddWithoutValidation("accept", "*/*");
			if (_httpContextAccessor.HttpContext.HasCookie("Authorization"))
			{
				var myCookie = _httpContextAccessor.HttpContext.GetCookie("Authorization");
				request.Headers.TryAddWithoutValidation("Authorization", myCookie);
			}

			var dataAsString = System.Text.Json.JsonSerializer.Serialize(user);
			var content = new StringContent(dataAsString);
			content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

			var response = await _client.PostAsync(url, content);

			return response;
		}


		#endregion

		#region SignUp

		public async Task<ServiceResponse<bool>> SignUp(SignUpViewModel newUser)
		{
			string url = $"/api/Auth/SignUp";

			var result = await _client.PostAsJson(_httpContextAccessor.HttpContext, url, newUser);

			return result;
		}

		#endregion
	}
}
