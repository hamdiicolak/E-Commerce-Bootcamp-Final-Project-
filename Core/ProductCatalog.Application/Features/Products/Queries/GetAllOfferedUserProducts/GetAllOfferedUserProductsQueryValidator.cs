using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog.Application.Features.Products.Queries.GetAllOfferedUserProducts
{
	public class GetAllOfferedUserProductsQueryValidator : AbstractValidator<GetAllOfferedUserProductsQueryRequest>
	{
		public GetAllOfferedUserProductsQueryValidator()
		{
			RuleFor(x => x.UserId).NotEmpty().WithMessage("ID alanı gereklidir!");
			RuleFor(x => x.UserId).GreaterThan(0).WithMessage("Uygulamamızda 0 ve negatif değerli Id'ler kullanılmamaktır!");
		}
	}
}
