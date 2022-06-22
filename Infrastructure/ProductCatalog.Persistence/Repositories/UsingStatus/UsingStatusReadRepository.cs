using ProductCatalog.Application.Repositories;
using ProductCatalog.Domain.Entities;
using ProductCatalog.Persistence.Contexts;

namespace ProductCatalog.Persistence.Repositories
{
	public class UsingStatusReadRepository : ReadRepository<UsingStatus>, IUsingStatusReadRepository
	{
		public UsingStatusReadRepository(ProductCatalogDbContext context) : base(context) { }
	}
}
