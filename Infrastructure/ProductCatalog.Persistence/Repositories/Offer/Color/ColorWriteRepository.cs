using ProductCatalog.Application.Repositories;
using ProductCatalog.Domain.Entities;
using ProductCatalog.Persistence.Contexts;

namespace ProductCatalog.Persistence.Repositories
{
	public class ColorWriteRepository : WriteRepository<Color>, IColorWriteRepository
	{
		public ColorWriteRepository(ProductCatalogDbContext context) : base(context) { }
	}
}
