using MediatR;
using ProductCatalog.Application.ServiceResponses;

namespace ProductCatalog.Application.Features.Products.Queries.GetProduct
{
	public class GetProductQueryRequest : IRequest<ServiceResponse<GetProductQueryResponse>>
	{
		public int Id { get; set; }
	}
}
