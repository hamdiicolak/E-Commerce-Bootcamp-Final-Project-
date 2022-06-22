using FluentValidation;

namespace ProductCatalog.Application.Features.Offers.Commands.DeclineOffer
{
	public class DeclineOfferCommandValidator : AbstractValidator<DeclineOfferCommandRequest>
	{
		public DeclineOfferCommandValidator()
		{
			RuleFor(p => p.OfferId).NotNull().NotEmpty().WithMessage("'User Id' alanı gereklidir");
		}
	}
}
