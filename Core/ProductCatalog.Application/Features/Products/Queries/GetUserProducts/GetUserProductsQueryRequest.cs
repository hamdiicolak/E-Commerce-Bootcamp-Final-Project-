using MediatR;
using ProductCatalog.Application.ServiceResponses;

namespace ProductCatalog.Application.Features.Products.Queries.GetUserProducts
{
	public class GetUserProductsQueryRequest : IRequest<ServiceResponse<IReadOnlyList<GetAllUserProductsQueryResponse>>>
	{
		public int UserId { get; set; }
	}
}
