using MediatR;
using ProductCatalog.Application.ServiceResponses;

namespace ProductCatalog.Application.Features.Products.Queries.GetAllProductsOfferedByUser
{
	public class GetAllProductsOfferedByUserQueryRequest : IRequest<ServiceResponse<IReadOnlyList<GetAllProductsOfferedByUserQueryResponse>>>
	{
		public int UserId { get; set; }
	}
}
