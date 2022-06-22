namespace ProductCatalog.Application.Features.Categories.Queries.GetAllOffers
{
	public class GetAllOffersQueryResponse
    {
		public int Id { get; set; }
		public int OfferPrice { get; set; }
		public int ProductId { get; set; }
		public int UserId { get; set; }
		public bool OfferApproved { get; set; }
	}
}
