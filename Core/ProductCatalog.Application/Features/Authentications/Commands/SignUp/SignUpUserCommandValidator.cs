using FluentValidation;

namespace ProductCatalog.Application.Features.Authentications.Commands.SignUp
{
	public class SignUpUserCommandValidator : AbstractValidator<SignUpUserCommandRequest>
	{
		public SignUpUserCommandValidator()
		{
			RuleFor(p => p.FirstName).NotNull().NotEmpty().WithMessage("'İsim' alanini doldurmaniz gerekiyor");
			RuleFor(p => p.LastName).NotNull().NotEmpty().WithMessage("'Soyisim' alanini doldurmaniz gerekiyor");
			RuleFor(p => p.UserName).NotNull().NotEmpty().WithMessage("'Kullanici Adi' alanini doldurmaniz gerekiyor");

			RuleFor(p => p.FirstName).MinimumLength(5).WithMessage("'İsim' alani en az 5 karakter olmali");
			RuleFor(p => p.LastName).MinimumLength(5).WithMessage("'Soyisim' alani en az 5 karakter olmali");

			RuleFor(p => p.FirstName).MaximumLength(15).WithMessage("'İsim' alani en fazla 15 karakter olmali");
			RuleFor(p => p.LastName).MaximumLength(15).WithMessage("'Soyisim' alani en fazla 15 karakter olmali");


			RuleFor(p => p.Email).MinimumLength(8).WithMessage("'Email' alani en az 8 karakter olmali");
			RuleFor(p => p.Email).MaximumLength(40).WithMessage("'Email' alani en fazla 20 karakter olmali");
			RuleFor(p => p.Password).NotEmpty().WithMessage("'Sifre' alanini doldurmaniz gerekiyor");
			RuleFor(p => p.Password).MinimumLength(8).WithMessage("'Sifre' alani en az 8 karakter olmali");
			RuleFor(p => p.Password).Matches("[A-Z]").WithMessage("'Sifre' alani en az 1 tane kücük karakter icermeli");
			RuleFor(p => p.Password).Matches("[A-Z]").WithMessage("'Sifre' alani en az 1 tane büyük karakter icermeli");
			RuleFor(p => p.Password).Matches(@"\d").WithMessage("'Sifre' alani en az 1 tane rakam icermeli");
			RuleFor(p => p.Password).Matches(@"[][""!@$%^&*(){}:;<>,.?/+_=|'~\\-]").WithMessage("'Sifre' alani en az 1 tane ozel karakter icermeli");
		}
	}
}
