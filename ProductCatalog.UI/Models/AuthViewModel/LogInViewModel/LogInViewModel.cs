using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProductCatalog.UI.Models
{
	public class LogInViewModel
	{
		[DisplayName("Email")]
		[Required(ErrorMessage = "Email alanı gereklidir")]
		public string Email { get; set; }

		[DataType(DataType.Password)]
		[DisplayName("Şifre")]
		[Required(ErrorMessage = "Şifre alanı gereklidir")]
		public string Password { get; set; }
	}
}
