using FluentValidation;

namespace ProductCatalog.Application.Features.Authentications.Queries.LogIn
{
	public class LogInQueryValidator : AbstractValidator<LogInQueryRequest>
	{
		public LogInQueryValidator()
		{
			RuleFor(p => p.Email).NotEmpty().WithMessage("'Email' alanini doldurmaniz gerekiyor")
				.MinimumLength(8).WithMessage("'Email' alani en az 8 karakter olmali")
				.MaximumLength(40).WithMessage("'Email' alani en fazla 40 karakter olmalidir.");
			RuleFor(p => p.Password).NotEmpty().WithMessage("'Sifre' alanini doldurmaniz gerekiyor")
				.MinimumLength(8).WithMessage("'Sifre' alani en az 8 karakter olmalidir.")
				.MaximumLength(20).WithMessage("'Şifre' alani en fazla 20 karakter olmalidir.");
		}
	}
}
