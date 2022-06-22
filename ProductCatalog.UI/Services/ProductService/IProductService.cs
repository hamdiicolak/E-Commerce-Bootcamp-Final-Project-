using ProductCatalog.UI.Models;

namespace ProductCatalog.UI.Services
{
	public interface IProductService
	{
		Task<IReadOnlyList<ProductViewModel>> GetAllProductsAsync();
		Task<IReadOnlyList<ProductViewModel>> GetAllProductsByCategoryIdAsync(int categoryId);
		Task<ProductViewModel> GetProductDetailAsync(int id);
		Task<ServiceResponse<bool>> AddProductAsync(NewProductViewModel newProduct);
		Task<ServiceResponse<bool>> BuyProduct(int productId);

	}
}
