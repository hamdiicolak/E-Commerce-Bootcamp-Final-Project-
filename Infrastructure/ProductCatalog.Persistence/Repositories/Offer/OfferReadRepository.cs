using Microsoft.EntityFrameworkCore;
using ProductCatalog.Application.Repositories;
using ProductCatalog.Domain.Entities;
using ProductCatalog.Persistence.Contexts;
using System.Linq.Expressions;

namespace ProductCatalog.Persistence.Repositories
{
	public class OfferReadRepository : ReadRepository<Offer>, IOfferReadRepository
	{
		private readonly ProductCatalogDbContext _context;

		public OfferReadRepository(ProductCatalogDbContext context) : base(context)
		{
			_context = context;
		}

		public async Task<Offer> GetOffer(Expression<Func<Offer, bool>> predicate)
		{
			return await _context.Offers
				   .Include(x => x.User)
				   .Include(x => x.Product)
				   .FirstOrDefaultAsync(predicate) ?? null;
		}
	}
}
