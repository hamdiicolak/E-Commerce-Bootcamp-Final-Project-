namespace ProductCatalog.UI.Models
{
	public class OfferViewModel
	{
		public int Id { get; set; }
		public int OfferPrice { get; set; }
		public int ProductId { get; set; }
		public int UserId { get; set; }
		public bool OfferApproved { get; set; }
	}
}
