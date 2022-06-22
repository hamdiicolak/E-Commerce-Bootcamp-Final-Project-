using MediatR;
using ProductCatalog.Application.ServiceResponses;

namespace ProductCatalog.Application.Features
{
	public class NewOfferCommandRequest : IRequest<ServiceResponse<bool>>
	{
		public int OfferPrice { get; set; }
		public int ProductId { get; set; }
		public int UserId { get; set; }
	}
}
