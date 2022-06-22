using ProductCatalog.Application.Repositories;
using ProductCatalog.Domain.Entities;
using ProductCatalog.Persistence.Contexts;

namespace ProductCatalog.Persistence.Repositories
{
	public class CategoryReadRepository : ReadRepository<Category>, ICategoryReadRepository
	{
		public CategoryReadRepository(ProductCatalogDbContext context) : base(context) { }
	}
}
