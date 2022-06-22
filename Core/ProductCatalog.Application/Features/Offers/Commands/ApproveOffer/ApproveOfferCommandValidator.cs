using FluentValidation;

namespace ProductCatalog.Application.Features.Offers.Commands.ApproveOffer
{
	public class ApproveOfferCommandValidator : AbstractValidator<ApproveOfferCommandRequest>
	{
		public ApproveOfferCommandValidator()
		{
			RuleFor(p => p.OfferId).NotNull().NotEmpty().WithMessage("'User Id' alanı gereklidir");
		}
	}
}
