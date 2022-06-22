using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProductCatalog.UI.Models
{
	public class SignUpViewModel
	{
		[DisplayName("İsim")]
		public string FirstName { get; set; }
		[DisplayName("Soyisim")]
		public string LastName { get; set; }
		[DisplayName("Kullanıcı Adi")]
		public string UserName { get; set; }
		[DisplayName("Email")]
		[EmailAddress(ErrorMessage = "Geçersiz Email Addresi")]
		public string Email { get; set; }
		[DisplayName("Şifre")]
		public string Password { get; set; }
	}
}
