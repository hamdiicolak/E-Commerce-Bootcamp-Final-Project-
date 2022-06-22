using FluentValidation;

namespace ProductCatalog.Application.Features.Categories.Queries.GetCategory
{
	public class GetCategoryQueryValidator : AbstractValidator<GetCategoryQueryRequest>
	{
		public GetCategoryQueryValidator()
		{
			RuleFor(x => x.Id).NotEmpty().WithMessage("ID alanı gereklidir!");
			RuleFor(x => x.Id).GreaterThan(0).WithMessage("Uygulamamızda 0 ve negatif değerli Id'ler kullanılmamaktır!");
		}
	}
}
