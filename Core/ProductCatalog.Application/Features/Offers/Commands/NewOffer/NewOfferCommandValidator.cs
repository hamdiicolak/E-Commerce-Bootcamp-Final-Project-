using FluentValidation;

namespace ProductCatalog.Application.Features
{
	public class NewOfferCommandValidator : AbstractValidator<NewOfferCommandRequest>
	{
		public NewOfferCommandValidator()
		{
			RuleFor(p => p.OfferPrice).NotEmpty().WithMessage("'Teklif' alanı gereklidir");
			RuleFor(p => p.ProductId).NotEmpty().WithMessage("'Ürün Id' alanı gereklidir");
			RuleFor(p => p.UserId).NotEmpty().WithMessage("'User Id' alanı gereklidir");
		}
	}
}
