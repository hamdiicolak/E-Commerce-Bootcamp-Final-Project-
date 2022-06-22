using ProductCatalog.UI.Models;

namespace ProductCatalog.UI.Services
{
	public interface ICategoryService
	{
		Task<IReadOnlyList<CategoriesViewModel>> GetAllCategoriesAsync();
	}
}
