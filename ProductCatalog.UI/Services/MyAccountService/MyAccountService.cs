using ProductCatalog.UI.Extensions;
using ProductCatalog.UI.Models;

namespace ProductCatalog.UI.Services
{
	public class MyAccountService : IMyAccountService
	{
		private readonly HttpClient _client;
		private readonly IHttpContextAccessor _httpContextAccessor;

		public MyAccountService(HttpClient client, IHttpContextAccessor httpContextAccessor)
		{
			_client = client;
			_httpContextAccessor = httpContextAccessor;
		}

		#region Get All User Products

		public async Task<IReadOnlyList<GetAllUserProductsViewModel>> GetAllUserProductsAsync()
		{
			var result = await _client.ReadContentAs<IReadOnlyList<GetAllUserProductsViewModel>>(_httpContextAccessor.HttpContext, $"/api/MyAccount");
			return result.ResponseData;
		}

		#endregion

		#region Get All Products Offered ByUser

		public async Task<IReadOnlyList<GetAllUserProductsViewModel>> GetAllProductsOfferedByUser()
		{
			var result = await _client.ReadContentAs<IReadOnlyList<GetAllUserProductsViewModel>>(_httpContextAccessor.HttpContext, $"/api/MyAccount/MyOffers");
			return result.ResponseData;
		}

		#endregion

		#region Get All Offered User Products

		public async Task<IReadOnlyList<GetAllUserProductsViewModel>> GetAllOfferedUserProducts()
		{
			var result = await _client.ReadContentAs<IReadOnlyList<GetAllUserProductsViewModel>>(_httpContextAccessor.HttpContext, $"/api/MyAccount/MyOfferedProducts");
			return result.ResponseData;
		}

		#endregion

		#region Get Product Detail

		public async Task<ProductViewModel> GetUserProductDetailAsync(int id)
		{
			var result = await _client.ReadContentAs<ProductViewModel>(_httpContextAccessor.HttpContext, $"/api/Products/{id}");
			return result.ResponseData;
		}

		#endregion
	}
}
