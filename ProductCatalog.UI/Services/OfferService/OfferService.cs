using ProductCatalog.UI.Extensions;
using ProductCatalog.UI.Models;

namespace ProductCatalog.UI.Services
{
	public class OfferService : IOfferService
	{
		private readonly HttpClient _client;
		private readonly IHttpContextAccessor _httpContextAccessor;

		public OfferService(HttpClient client, IHttpContextAccessor httpContextAccessor)
		{
			_client = client;
			_httpContextAccessor = httpContextAccessor;
		}

		public async Task<ServiceResponse<bool>> ApproveOffer(int offerId)
		{
			var result = await _client.PutAsJson(_httpContextAccessor.HttpContext, $"/api/Offers/ApproveOffer/{offerId}", (string)null);
			return result;
		}

		public async Task<ServiceResponse<bool>> DeclineOffer(int offerId)
		{
			var result = await _client.DeleteAs(_httpContextAccessor.HttpContext, $"/api/Offers/DeclineOffer/{offerId}");
			return result;
		}

		public async Task<IReadOnlyList<OfferViewModel>> GetAllOffers()
		{
			var result = await _client.ReadContentAs<IReadOnlyList<OfferViewModel>>(_httpContextAccessor.HttpContext, "/api/Offers");
			return result.ResponseData;
		}

		public async Task<ServiceResponse<bool>> NewOffer(NewOfferOfferViewModel newOffer)
		{
			string url = $"/api/Offers/";

			var result = await _client.PostAsJson(_httpContextAccessor.HttpContext, url, newOffer);

			return result;
		}
	}
}
