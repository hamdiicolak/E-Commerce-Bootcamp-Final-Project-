using ProductCatalog.Application.Repositories;
using ProductCatalog.Domain.Entities;
using ProductCatalog.Persistence.Contexts;

namespace ProductCatalog.Persistence.Repositories
{
	public class ProductWriteRepository : WriteRepository<Product>, IProductWriteRepository
	{
		public ProductWriteRepository(ProductCatalogDbContext context) : base(context) { }
	}
}
