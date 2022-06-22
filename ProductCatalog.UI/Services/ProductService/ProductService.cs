using ProductCatalog.UI.Extensions;
using ProductCatalog.UI.Models;

namespace ProductCatalog.UI.Services
{
	public class ProductService : IProductService
	{
		private readonly HttpClient _client;
		private readonly IHttpContextAccessor _httpContextAccessor;

		public ProductService(HttpClient client, IHttpContextAccessor httpContextAccessor)
		{
			_client = client;
			_httpContextAccessor = httpContextAccessor;
		}

		#region Add New Product

		public async Task<ServiceResponse<bool>> AddProductAsync(NewProductViewModel newProduct)
		{
			string url = $"/api/Products";
			var result = await _client.PostAsJson(_httpContextAccessor.HttpContext, url, newProduct);
			return result;
		}

		#endregion

		#region Get Product Detail

		public async Task<ProductViewModel> GetProductDetailAsync(int id)
		{
			var result = await _client.ReadContentAs<ProductViewModel>($"/api/Products/{id}");
			return result.ResponseData;
		}

		#endregion

		#region Get All Products

		public async Task<IReadOnlyList<ProductViewModel>> GetAllProductsAsync()
		{
			var result = await _client.ReadContentAs<IReadOnlyList<ProductViewModel>>($"/api/Products");
			return result.ResponseData;
		}

		#endregion

		#region Get All Products By Category Id

		public async Task<IReadOnlyList<ProductViewModel>> GetAllProductsByCategoryIdAsync(int categoryId)
		{
			var result = await _client.ReadContentAs<IReadOnlyList<ProductViewModel>>($"/api/Products/ByCategory/{categoryId}");
			return result.ResponseData;
		}

		#endregion

		#region Buy Product

		public async Task<ServiceResponse<bool>> BuyProduct(int productId)
		{
			var result = await _client.PutAsJson(_httpContextAccessor.HttpContext, $"/api/Products/{productId}", (string)null);
			return result;
		}

		#endregion
	}
}