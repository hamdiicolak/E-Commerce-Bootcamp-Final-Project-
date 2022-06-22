using ProductCatalog.Domain.Entities;
using System.Linq.Expressions;

namespace ProductCatalog.Application.Repositories
{
	public interface IOfferReadRepository : IReadRepository<Offer>
	{
		public Task<Offer> GetOffer(Expression<Func<Offer, bool>> predicate);
	}
}
