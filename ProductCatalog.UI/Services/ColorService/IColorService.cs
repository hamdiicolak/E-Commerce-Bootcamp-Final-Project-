using ProductCatalog.UI.Models;

namespace ProductCatalog.UI.Services
{
	public interface IColorService
	{
		Task<IReadOnlyList<ColorsViewModel>> GetAllColorsAsync();
	}
}
