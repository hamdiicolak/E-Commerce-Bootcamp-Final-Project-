using ProductCatalog.UI.Extensions;
using ProductCatalog.UI.Models;

namespace ProductCatalog.UI.Services
{
	public class ColorService : IColorService
	{
		private readonly HttpClient _client;
		private readonly IHttpContextAccessor _httpContextAccessor;

		public ColorService(HttpClient client, IHttpContextAccessor httpContextAccessor)
		{
			_client = client;
			_httpContextAccessor = httpContextAccessor;
		}

		public async Task<IReadOnlyList<ColorsViewModel>> GetAllColorsAsync()
		{
			var result = await _client.ReadContentAs<IReadOnlyList<ColorsViewModel>>("/api/Colors");
			return result.ResponseData;
		}
	}
}
