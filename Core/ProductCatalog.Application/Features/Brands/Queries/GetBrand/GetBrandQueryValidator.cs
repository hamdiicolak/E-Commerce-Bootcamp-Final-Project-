using FluentValidation;

namespace ProductCatalog.Application.Features.Brands
{
	public class GetBrandQueryValidator : AbstractValidator<GetBrandQueryRequest>
	{
		public GetBrandQueryValidator()
		{
			RuleFor(x => x.Id).NotEmpty().WithMessage("ID alanı gereklidir!");
			RuleFor(x => x.Id).GreaterThan(0).WithMessage("Uygulamamızda 0 ve negatif değerli Id'ler kullanılmamaktır!");
		}
	}
}
