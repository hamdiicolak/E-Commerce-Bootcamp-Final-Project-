using ProductCatalog.Application.Repositories;
using ProductCatalog.Domain.Entities;
using ProductCatalog.Persistence.Contexts;

namespace ProductCatalog.Persistence.Repositories
{
	public class OfferWriteRepository : WriteRepository<Offer>, IOfferWriteRepository
	{
		public OfferWriteRepository(ProductCatalogDbContext context) : base(context) { }
	}
}
