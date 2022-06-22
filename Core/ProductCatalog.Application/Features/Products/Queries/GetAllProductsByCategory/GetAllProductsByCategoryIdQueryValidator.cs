using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog.Application.Features.Products.Queries.GetAllProductsByCategory
{
	public class GetAllProductsByCategoryIdQueryValidator : AbstractValidator<GetAllProductsByCategoryIdQueryRequest>
	{
		public GetAllProductsByCategoryIdQueryValidator()
		{
			RuleFor(x => x.CategoryId).NotEmpty().WithMessage("ID alanı gereklidir!");
			RuleFor(x => x.CategoryId).GreaterThan(0).WithMessage("Uygulamamızda 0 ve negatif değerli Id'ler kullanılmamaktır!");
		}
	}
}
