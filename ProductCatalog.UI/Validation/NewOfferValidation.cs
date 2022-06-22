using FluentValidation;
using ProductCatalog.UI.Models;

namespace ProductCatalog.UI.Validation
{
	public class NewOfferValidation : AbstractValidator<NewOfferOfferViewModel>
	{
		public NewOfferValidation()
		{
			RuleFor(p => p.OfferPrice).NotNull().NotEmpty().WithMessage("'Teklif' alanı gereklidir")
				.GreaterThan(0).WithMessage("'Teklif' 0 dan büyük olmalı");
		}
	}
}
