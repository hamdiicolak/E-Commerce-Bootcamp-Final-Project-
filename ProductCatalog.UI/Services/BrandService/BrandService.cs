using ProductCatalog.UI.Extensions;
using ProductCatalog.UI.Models;

namespace ProductCatalog.UI.Services
{
	public class BrandService : IBrandService
	{
		private readonly HttpClient _client;
		private readonly IHttpContextAccessor _httpContextAccessor;

		public BrandService(HttpClient client, IHttpContextAccessor httpContextAccessor)
		{
			_client = client;
			_httpContextAccessor = httpContextAccessor;
		}

		public async Task<IReadOnlyList<BrandsViewModel>> GetAllBrandsAsync()
		{
			var result = await _client.ReadContentAs<IReadOnlyList<BrandsViewModel>>("/api/Brands");
			return result.ResponseData;
		}
	}
}
