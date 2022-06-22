using FluentValidation;
using ProductCatalog.UI.Models;

namespace ProductCatalog.UI.Validation
{
	public class SignUpValidator : AbstractValidator<SignUpViewModel>
	{
		public SignUpValidator()
		{
			RuleFor(p => p.FirstName).NotNull().NotEmpty().WithMessage("'İsim' alanini gerekiyor")
				.MinimumLength(5).WithMessage("'İsim' alani en az 5 karakter olmali")
				.MaximumLength(15).WithMessage("'İsim' alani en fazla 15 karakter olmali");

			RuleFor(p => p.LastName).NotNull().NotEmpty().WithMessage("'Soyisim' alanini doldurmaniz gerekiyor")
				.MinimumLength(5).WithMessage("'Soyisim' alani en az 5 karakter olmali")
				.MaximumLength(15).WithMessage("'Soyisim' alani en fazla 15 karakter olmali");

			RuleFor(p => p.UserName).NotNull().NotEmpty().WithMessage("'Kullanici Adi' alanini doldurmaniz gerekiyor");

			RuleFor(p => p.Email).MinimumLength(8).WithMessage("'Email' alani en az 8 karakter olmali")
				.NotNull().WithMessage("'Email' null olamaz.")
				.MaximumLength(40).WithMessage("'Email' alani en fazla 20 karakter olmali");

			RuleFor(p => p.Password).NotEmpty().WithMessage("'Sifre' alanini doldurmaniz gerekiyor")
				.MinimumLength(8).WithMessage("'Sifre' alani en az 8 karakter olmali")
				.Matches("[A-Z]").WithMessage("'Sifre' alani en az 1 tane kücük karakter icermeli")
				.Matches("[A-Z]").WithMessage("'Sifre' alani en az 1 tane büyük karakter icermeli")
				.Matches(@"\d").WithMessage("'Sifre' alani en az 1 tane rakam icermeli")
				.Matches(@"[][""!@$%^&*(){}:;<>,.?/+_=|'~\\-]").WithMessage("'Sifre' alani en az 1 tane ozel karakter icermeli");

		}
	}
}
