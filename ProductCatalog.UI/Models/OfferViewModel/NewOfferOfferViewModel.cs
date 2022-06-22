using System.ComponentModel;

namespace ProductCatalog.UI.Models
{
	public class NewOfferOfferViewModel
	{
		[DisplayName("Teklif")]
		public decimal OfferPrice { get; set; }
		[DisplayName("Ürün Id")]
		public int ProductId { get; set; }
	}
}
