using System.ComponentModel;

namespace ProductCatalog.UI.Models
{
	public class GetAllUserProductsViewModel
	{
		[DisplayName("Ürün Id")]
		public int Id { get; set; }
		[DisplayName("Ürün Adı")]
		public string Name { get; set; }
		[DisplayName("Ürün Fiyat")]
		public decimal Price { get; set; }
		[DisplayName("Kullanıcı Adı")]
		public string UserName { get; set; }
		public int? UserId { get; set; }
		public bool IsOfferable { get; set; }
		public bool IsSold { get; set; }
		public string ImageUrl { get; set; }
		[DisplayName("Kategori")]
		public string Category { get; set; }
		[DisplayName("Marka")]
		public string Brand { get; set; }
		[DisplayName("Renk")]
		public string Color { get; set; }
		[DisplayName("Kullanım Durumu")]
		public string UsingStatus { get; set; }
		[DisplayName("Beden")]
		public string Size { get; set; }
		[DisplayName("Ürün Tanımı")]
		public string Description { get; set; }
	}
}
