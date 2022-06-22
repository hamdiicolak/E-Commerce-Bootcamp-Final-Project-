using ProductCatalog.Application.Repositories;
using ProductCatalog.Domain.Entities;
using ProductCatalog.Persistence.Contexts;

namespace ProductCatalog.Persistence.Repositories
{
	public class ColorReadRepository : ReadRepository<Color>, IColorReadRepository
	{
		public ColorReadRepository(ProductCatalogDbContext context) : base(context) { }
	}
}
