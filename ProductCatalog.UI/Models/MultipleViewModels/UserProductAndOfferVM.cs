namespace ProductCatalog.UI.Models
{
	public class UserProductAndOfferVM
	{
		public IReadOnlyList<GetAllUserProductsViewModel> Products { get; set; }
		public IReadOnlyList<OfferViewModel> Offers { get; set; }
		public int LoggedInUserId { get; set; }

	}
}
