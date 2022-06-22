using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog.Application.Features.Products.Queries.GetProduct
{
	public class GetProductQueryValidator : AbstractValidator<GetProductQueryRequest>
	{
		public GetProductQueryValidator()
		{
			RuleFor(x => x.Id).NotEmpty().WithMessage("ID alanı gereklidir!");
			RuleFor(x => x.Id).GreaterThan(0).WithMessage("Uygulamamızda 0 ve negatif değerli Id'ler kullanılmamaktır!");
		}
	}
}
