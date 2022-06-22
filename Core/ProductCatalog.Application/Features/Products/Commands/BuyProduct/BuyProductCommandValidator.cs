using FluentValidation;
namespace ProductCatalog.Application.Features.Products.Commands.BuyProduct
{
	public class BuyProductCommandValidator : AbstractValidator<BuyProductCommandRequest>
	{
		public BuyProductCommandValidator()
		{
			//RuleFor(p => p.Name).NotEmpty().WithMessage("'Ürün adı' alanı gereklidir");
			//RuleFor(p => p.AmountOfStock).NotEmpty().WithMessage(" 'Ürün stok' alanı gereklidir");
			
		}
	}
}
