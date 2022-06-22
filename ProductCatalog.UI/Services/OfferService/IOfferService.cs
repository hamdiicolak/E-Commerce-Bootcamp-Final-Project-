using ProductCatalog.UI.Models;

namespace ProductCatalog.UI.Services
{
	public interface IOfferService
	{
		Task<ServiceResponse<bool>> NewOffer(NewOfferOfferViewModel newUser);
		Task<ServiceResponse<bool>> ApproveOffer(int offerId);
		Task<ServiceResponse<bool>> DeclineOffer(int offerId);
		Task<IReadOnlyList<OfferViewModel>> GetAllOffers();
	}
}
