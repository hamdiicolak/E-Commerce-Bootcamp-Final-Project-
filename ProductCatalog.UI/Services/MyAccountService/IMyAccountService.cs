using ProductCatalog.UI.Models;

namespace ProductCatalog.UI.Services
{
	public interface IMyAccountService
	{
		Task<IReadOnlyList<GetAllUserProductsViewModel>> GetAllUserProductsAsync();
		Task<IReadOnlyList<GetAllUserProductsViewModel>> GetAllProductsOfferedByUser();
		Task<IReadOnlyList<GetAllUserProductsViewModel>> GetAllOfferedUserProducts();
		Task<ProductViewModel> GetUserProductDetailAsync(int id);
	}
}
