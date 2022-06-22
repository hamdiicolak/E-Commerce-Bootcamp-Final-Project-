using ProductCatalog.UI.Extensions;
using ProductCatalog.UI.Models;

namespace ProductCatalog.UI.Services
{
	public class UsingStatusService : IUsingStatusService
	{
		private readonly HttpClient _client;
		private readonly IHttpContextAccessor _httpContextAccessor;

		public UsingStatusService(HttpClient client, IHttpContextAccessor httpContextAccessor)
		{
			_client = client;
			_httpContextAccessor = httpContextAccessor;
		}

		public async Task<IReadOnlyList<UsingStatusViewModel>> GetAllUsingStatusesAsync()
		{
			var result = await _client.ReadContentAs<IReadOnlyList<UsingStatusViewModel>>("/api/UsingStatuses");
			return result.ResponseData;
		}
	}
}
