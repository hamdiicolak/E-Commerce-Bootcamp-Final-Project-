using Newtonsoft.Json;
using ProductCatalog.UI.Models;
using ProductCatalog.UI.Services;
using System.Net;
using System.Net.Http.Headers;

namespace ProductCatalog.UI.Extensions
{
	public static class HttpClientExtensions
	{
		#region GET
		// Requests without Authentication
		public static async Task<ServiceResponse<T>> ReadContentAs<T>(this HttpClient httpClient, string url)
		{
			var request = new HttpRequestMessage(new HttpMethod("GET"), $"{url}");

			var response = await httpClient.SendAsync(request);

			if (!response.IsSuccessStatusCode)
			{
				List<string> errors = new List<string>();
				ServiceResponse<T> responseData;
				switch (response.StatusCode)
				{
					case HttpStatusCode.Unauthorized:
						errors.Add("Satın alabilmek için önce giriş yapmanız gerekmekte.");
						responseData = new ServiceResponse<T>(errors, (T)Activator.CreateInstance(typeof(T), new object()));
						return responseData;
					default:
						errors.Add("Error !!!");
						responseData = new ServiceResponse<T>(errors, (T)Activator.CreateInstance(typeof(T), new object()));
						return responseData;
				}
			}

			var dataAsString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ServiceResponse<T>>(dataAsString);
		}

		// Requests with Authentication 
		public static async Task<ServiceResponse<T>> ReadContentAs<T>(this HttpClient httpClient, HttpContext httpContext, string url)
		{
			var request = new HttpRequestMessage(new HttpMethod("GET"), $"{url}");

			request.Headers.TryAddWithoutValidation("accept", "*");
			if (httpContext.HasCookie("Authorization"))
			{
				var getCookie = httpContext.GetCookie("Authorization");
				var myCookie = JsonConvert.DeserializeObject<ServiceResponse<LogInResponseViewModel>>(getCookie);
				request.Headers.TryAddWithoutValidation("Authorization", "Bearer " + myCookie.ResponseData.Token);
			}

			var response = await httpClient.SendAsync(request);

			if (!response.IsSuccessStatusCode)
			{
				List<string> errors = new List<string>();
				ServiceResponse<T> responseData;
				switch (response.StatusCode)
				{
					case HttpStatusCode.Unauthorized:
						errors.Add("Satın alabilmek için önce giriş yapmanız gerekmekte.");
						responseData = new ServiceResponse<T>(errors, (T)Activator.CreateInstance(typeof(T), new object()));
						return responseData;
					default:
						errors.Add("Error !!!");
						responseData = new ServiceResponse<T>(errors, (T)Activator.CreateInstance(typeof(T), new object()));
						return responseData;
				}
			}

			var dataAsString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
			return JsonConvert.DeserializeObject<ServiceResponse<T>>(dataAsString);
		}
		#endregion

		#region POST
		public static async Task<ServiceResponse<bool>> PostAsJson<T>(this HttpClient httpClient, HttpContext httpContext, string url, T data)
		{
			var request = new HttpRequestMessage(new HttpMethod("POST"), $"{url}");

			request.Headers.TryAddWithoutValidation("accept", "*");
			if (httpContext.HasCookie("Authorization"))
			{
				var getCookie = httpContext.GetCookie("Authorization");
				var myCookie = JsonConvert.DeserializeObject<ServiceResponse<LogInResponseViewModel>>(getCookie);
				request.Headers.TryAddWithoutValidation("Authorization", "Bearer " + myCookie.ResponseData.Token);
			}

			var dataAsString = System.Text.Json.JsonSerializer.Serialize(data);
			request.Content = new StringContent(dataAsString);
			request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

			var response = await httpClient.SendAsync(request);


			if (!response.IsSuccessStatusCode)
			{
				List<string> errors = new List<string>();
				ServiceResponse<bool> responseData;
				switch (response.StatusCode)
				{
					case HttpStatusCode.Unauthorized:
						errors.Add("Satın alabilmek için önce giriş yapmanız gerekmekte.");
						responseData = new ServiceResponse<bool>(errors, false);
						return responseData;
					default:
						errors.Add("Error !!!");
						responseData = new ServiceResponse<bool>(errors, false);
						return responseData;
				}
			}


			var result = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ServiceResponse<bool>>(result);
		}
		#endregion

		#region PUT
		public static async Task<ServiceResponse<bool>> PutAsJson<T>(this HttpClient httpClient, HttpContext httpContext, string url, T data)
		{
			var request = new HttpRequestMessage(new HttpMethod("PUT"), $"{url}");

			request.Headers.TryAddWithoutValidation("accept", "*");
			if (httpContext.HasCookie("Authorization"))
			{
				var getCookie = httpContext.GetCookie("Authorization");
				var myCookie = JsonConvert.DeserializeObject<ServiceResponse<LogInResponseViewModel>>(getCookie);
				request.Headers.TryAddWithoutValidation("Authorization", "Bearer " + myCookie.ResponseData.Token);
			}

			var dataAsString = System.Text.Json.JsonSerializer.Serialize(data);
			request.Content = new StringContent(dataAsString);
			request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

			var response = await httpClient.SendAsync(request);

			if (!response.IsSuccessStatusCode)
			{
				List<string> errors = new List<string>();
				ServiceResponse<bool> responseData;
				switch (response.StatusCode)
				{
					case HttpStatusCode.Unauthorized:
						errors.Add("Satın alabilmek için önce giriş yapmanız gerekmekte.");
						responseData = new ServiceResponse<bool>(errors, false);
						return responseData;
					default:
						errors.Add("Error !!!");
						responseData = new ServiceResponse<bool>(errors, false);
						return responseData;
				}
			}

			var result = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ServiceResponse<bool>>(result);
		}
		#endregion

		#region DELETE

		public static async Task<ServiceResponse<bool>> DeleteAs(this HttpClient httpClient, HttpContext httpContext, string url)
		{
			var request = new HttpRequestMessage(new HttpMethod("DELETE"), $"{url}");

			request.Headers.TryAddWithoutValidation("accept", "*");
			if (httpContext.HasCookie("Authorization"))
			{
				var getCookie = httpContext.GetCookie("Authorization");
				var myCookie = JsonConvert.DeserializeObject<ServiceResponse<LogInResponseViewModel>>(getCookie);
				request.Headers.TryAddWithoutValidation("Authorization", "Bearer " + myCookie.ResponseData.Token);
			}

			var response = await httpClient.SendAsync(request);

			if (!response.IsSuccessStatusCode)
			{
				List<string> errors = new List<string>();
				ServiceResponse<bool> responseData;
				switch (response.StatusCode)
				{
					case HttpStatusCode.Unauthorized:
						errors.Add("Satın alabilmek için önce giriş yapmanız gerekmekte.");
						responseData = new ServiceResponse<bool>(errors, false);
						return responseData;
					default:
						errors.Add("Error !!!");
						responseData = new ServiceResponse<bool>(errors, false);
						return responseData;
				}
			}

			var result = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

			return JsonConvert.DeserializeObject<ServiceResponse<bool>>(result);
		}

		#endregion
	}
}
