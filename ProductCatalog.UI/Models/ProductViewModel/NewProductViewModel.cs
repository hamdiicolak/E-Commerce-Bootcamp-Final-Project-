using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductCatalog.UI.Models
{
	public class NewProductViewModel
	{
		[DisplayName("Ürün Adı")]
		[Required(ErrorMessage = "İsim alanı gereklidir")]
		public string Name { get; set; }
		[DisplayName("Ürün Fiyat")]
		[Required(ErrorMessage = "Fiyat alanı gereklidir")]
		public decimal Price { get; set; }
		// It's nullable because I dont get it from the view
		// Since it lacks in ModelState.IsValid I made it nullable 
		// and set it in the controller action. It's not nullable on the Api side
		public string? ImageUrl { get; set; }
		[Display(Name = "Image")]
		[Required(ErrorMessage = "Ürün için bir resim seçmelisiniz")]
		public IFormFile Image { get; set; }
		[Required(ErrorMessage = "Categori alanı gereklidir")]
		public int CategoryId { get; set; }
		public int? BrandId { get; set; }
		public int? ColorId { get; set; }
		[Required(ErrorMessage = "Kullanım durumu alanı gereklidir")]
		public int UsingStatusId { get; set; }
		[DisplayName("Beden")]
		[Required(ErrorMessage = "Beden alanı gereklidir")]
		public string Size { get; set; }
		[DisplayName("Ürün Tanımı")]
		[Required(ErrorMessage = "Ürün tanımı alanı gereklidir")]
		public string Description { get; set; }
	}
}
