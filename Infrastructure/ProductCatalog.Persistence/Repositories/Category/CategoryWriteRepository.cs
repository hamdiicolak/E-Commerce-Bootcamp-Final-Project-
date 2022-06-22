using ProductCatalog.Application.Repositories;
using ProductCatalog.Domain.Entities;
using ProductCatalog.Persistence.Contexts;

namespace ProductCatalog.Persistence.Repositories
{
	public class CategoryWriteRepository : WriteRepository<Category>, ICategoryWriteRepository
	{
		public CategoryWriteRepository(ProductCatalogDbContext context) : base(context) { }
	}
}
