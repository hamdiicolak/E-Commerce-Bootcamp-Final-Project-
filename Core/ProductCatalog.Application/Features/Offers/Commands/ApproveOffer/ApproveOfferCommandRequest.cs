using MediatR;
using ProductCatalog.Application.ServiceResponses;

namespace ProductCatalog.Application.Features.Offers.Commands.ApproveOffer
{
	public class ApproveOfferCommandRequest : IRequest<ServiceResponse<bool>>
	{
		public int OfferId { get; set; }
	}
}
