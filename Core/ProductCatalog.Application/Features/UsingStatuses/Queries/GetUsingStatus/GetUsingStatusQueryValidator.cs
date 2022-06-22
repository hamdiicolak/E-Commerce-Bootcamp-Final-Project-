using FluentValidation;

namespace ProductCatalog.Application.Features.UsingStatuses
{
	public class GetUsingStatusQueryValidator : AbstractValidator<GetUsingStatusQueryRequest>
	{
		public GetUsingStatusQueryValidator()
		{
			RuleFor(x => x.Id).NotEmpty().WithMessage("ID alanı gereklidir!");
			RuleFor(x => x.Id).GreaterThan(0).WithMessage("Uygulamamızda 0 ve negatif değerli Id'ler kullanılmamaktır!");
		}
	}
}
