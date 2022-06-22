using MediatR;
using ProductCatalog.Application.ServiceResponses;

namespace ProductCatalog.Application.Features.Offers.Commands.DeclineOffer
{
	public class DeclineOfferCommandRequest : IRequest<ServiceResponse<bool>>
	{
		public int OfferId { get; set; }
		
	}
}
