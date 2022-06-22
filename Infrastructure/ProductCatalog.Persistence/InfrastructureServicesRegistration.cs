using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProductCatalog.Application.Repositories;
using ProductCatalog.Domain.Entities;
using ProductCatalog.Persistence.Contexts;
using ProductCatalog.Persistence.Repositories;

namespace ProductCatalog.Persistence
{
	public static class InfrastructureServicesRegistration
	{
		public static IServiceCollection ConfigureInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddDbContext<ProductCatalogDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

			#region Repositories

			services.AddScoped<IProductReadRepository, ProductReadRepository>();
			services.AddScoped<IProductWriteRepository, ProductWriteRepository>();
			services.AddScoped<ICategoryReadRepository, CategoryReadRepository>();
			services.AddScoped<ICategoryWriteRepository, CategoryWriteRepository>();
			services.AddScoped<IBrandWriteRepository, BrandWriteRepository>();
			services.AddScoped<IBrandReadRepository, BrandReadRepository>();
			services.AddScoped<IColorWriteRepository, ColorWriteRepository>();
			services.AddScoped<IColorReadRepository, ColorReadRepository>();
			services.AddScoped<IUsingStatusWriteRepository, UsingStatusWriteRepository>();
			services.AddScoped<IUsingStatusReadRepository, UsingStatusReadRepository>();
			services.AddScoped<IOfferReadRepository, OfferReadRepository>();
			services.AddScoped<IOfferWriteRepository, OfferWriteRepository>();
			
			#endregion

			services.AddIdentity<User, Role>(options =>
			{
				options.Password.RequiredLength = 8;
				options.Password.RequireNonAlphanumeric = true;
				options.Password.RequireLowercase = true;
				options.Password.RequireUppercase = true;
				options.Password.RequireDigit = true;
				options.User.RequireUniqueEmail = true;
				options.User.AllowedUserNameCharacters = "abcçdefghiıjklmnoöpqrsştuüvwxyzABCÇDEFGHIİJKLMNOÖPQRSŞTUÜVWXYZ0123456789-._@+";
				options.SignIn.RequireConfirmedAccount = false;
				options.SignIn.RequireConfirmedEmail = false;
				options.SignIn.RequireConfirmedPhoneNumber = false;
				options.Lockout.MaxFailedAccessAttempts = 3;
				options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);

			}).AddEntityFrameworkStores<ProductCatalogDbContext>();


			return services;
		}
	}
}
