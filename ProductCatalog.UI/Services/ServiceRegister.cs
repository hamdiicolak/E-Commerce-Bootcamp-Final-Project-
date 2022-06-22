using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace ProductCatalog.UI.Services
{
	public static class ServiceRegister
	{
		public static void AddUIServices(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddHttpClient<ICategoryService, CategoryService>(c =>
			   c.BaseAddress = new Uri(configuration["HttClientUrl:API"]));

			services.AddHttpClient<IProductService, ProductService>(c =>
			   c.BaseAddress = new Uri(configuration["HttClientUrl:API"]));

			services.AddHttpClient<IAuthService, AuthService>(c =>
				c.BaseAddress = new Uri(configuration["HttClientUrl:API"]));

			services.AddHttpClient<IMyAccountService, MyAccountService>(c =>
				c.BaseAddress = new Uri(configuration["HttClientUrl:API"]));

			services.AddHttpClient<IBrandService, BrandService>(c =>
				c.BaseAddress = new Uri(configuration["HttClientUrl:API"]));

			services.AddHttpClient<IColorService, ColorService>(c =>
				c.BaseAddress = new Uri(configuration["HttClientUrl:API"]));

			services.AddHttpClient<IUsingStatusService, UsingStatusService>(c =>
				c.BaseAddress = new Uri(configuration["HttClientUrl:API"]));

			services.AddHttpClient<IOfferService, OfferService>(c =>
				c.BaseAddress = new Uri(configuration["HttClientUrl:API"]));

			services.AddHttpContextAccessor();
			services.TryAddSingleton<IActionContextAccessor, ActionContextAccessor>();

		}
	}
}
