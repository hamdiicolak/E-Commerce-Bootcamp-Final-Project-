using ProductCatalog.UI.Extensions;
using ProductCatalog.UI.Models;

namespace ProductCatalog.UI.Services
{
	public class CategoryService : ICategoryService
	{
		private readonly HttpClient _client;
		private readonly IHttpContextAccessor _httpContextAccessor;

		public CategoryService(HttpClient client, IHttpContextAccessor httpContextAccessor)
		{
			_client = client;
			_httpContextAccessor = httpContextAccessor;
		}

		public async Task<IReadOnlyList<CategoriesViewModel>> GetAllCategoriesAsync()
		{
			var result = await _client.ReadContentAs<IReadOnlyList<CategoriesViewModel>>("/api/Categories");
			return result.ResponseData;
		}
	}
}
