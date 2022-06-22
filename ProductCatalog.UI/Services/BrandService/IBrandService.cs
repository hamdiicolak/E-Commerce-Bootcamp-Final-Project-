using ProductCatalog.UI.Models;
namespace ProductCatalog.UI.Services
{
	public interface IBrandService
	{
		Task<IReadOnlyList<BrandsViewModel>> GetAllBrandsAsync();
	}
}
