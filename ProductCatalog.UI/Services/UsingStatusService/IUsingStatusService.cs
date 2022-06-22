using ProductCatalog.UI.Models;

namespace ProductCatalog.UI.Services
{
	public interface IUsingStatusService
	{
		Task<IReadOnlyList<UsingStatusViewModel>> GetAllUsingStatusesAsync();
	}
}
