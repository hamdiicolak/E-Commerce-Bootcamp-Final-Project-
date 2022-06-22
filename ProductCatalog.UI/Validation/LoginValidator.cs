using FluentValidation;
using ProductCatalog.UI.Models;

namespace ProductCatalog.UI.Validation
{
	public class LogInValidator : AbstractValidator<LogInViewModel>
	{
		public LogInValidator()
		{
			RuleFor(p => p.Email).NotNull().WithMessage("'Email' null olamaz.")
				.NotEmpty().WithMessage("'Email' alanini doldurmaniz gerekiyor")
				.MinimumLength(8).WithMessage("'Email' alani en az 8 karakter olmali")
				.MaximumLength(40).WithMessage("'Email' alani en fazla 40 karakter olmalidir."); 
			RuleFor(p => p.Password).NotEmpty().WithMessage("'Sifre' alanini doldurmaniz gerekiyor")
				.MinimumLength(8).WithMessage("'Sifre' alani en az 8 karakter olmalidir.")
				.MaximumLength(40).WithMessage("'Şifre' alani en fazla 40 karakter olmalidir.");
		}
	}
}
