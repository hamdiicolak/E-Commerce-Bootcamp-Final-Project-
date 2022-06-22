using ProductCatalog.Application.Repositories;
using ProductCatalog.Domain.Entities;
using ProductCatalog.Persistence.Contexts;

namespace ProductCatalog.Persistence.Repositories
{
	public class UsingStatusWriteRepository : WriteRepository<UsingStatus>, IUsingStatusWriteRepository
	{
		public UsingStatusWriteRepository(ProductCatalogDbContext context) : base(context) { }
	}
}
