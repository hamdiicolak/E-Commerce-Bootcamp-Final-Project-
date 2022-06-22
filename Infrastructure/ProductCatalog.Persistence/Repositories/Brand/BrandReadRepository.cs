using ProductCatalog.Application.Repositories;
using ProductCatalog.Domain.Entities;
using ProductCatalog.Persistence.Contexts;

namespace ProductCatalog.Persistence.Repositories
{
	public class BrandReadRepository : ReadRepository<Brand>, IBrandReadRepository
	{
		public BrandReadRepository(ProductCatalogDbContext context) : base(context) { }
	}
}
