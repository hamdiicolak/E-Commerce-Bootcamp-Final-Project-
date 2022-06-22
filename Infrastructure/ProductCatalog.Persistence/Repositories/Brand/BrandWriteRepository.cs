using ProductCatalog.Application.Repositories;
using ProductCatalog.Domain.Entities;
using ProductCatalog.Persistence.Contexts;

namespace ProductCatalog.Persistence.Repositories
{
	public class BrandWriteRepository : WriteRepository<Brand>, IBrandWriteRepository
	{
		public BrandWriteRepository(ProductCatalogDbContext context) : base(context) { }
	}
}
