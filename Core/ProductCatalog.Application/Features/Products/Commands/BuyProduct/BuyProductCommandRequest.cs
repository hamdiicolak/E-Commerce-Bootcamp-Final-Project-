using MediatR;
using ProductCatalog.Application.ServiceResponses;

namespace ProductCatalog.Application.Features.Products.Commands.BuyProduct
{
	public class BuyProductCommandRequest : IRequest<ServiceResponse<bool>> 
	{
		public int Id { get; set; }
	}
}
