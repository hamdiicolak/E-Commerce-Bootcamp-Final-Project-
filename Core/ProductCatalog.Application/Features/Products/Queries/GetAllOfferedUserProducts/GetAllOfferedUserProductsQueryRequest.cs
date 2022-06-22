using MediatR;
using ProductCatalog.Application.ServiceResponses;

namespace ProductCatalog.Application.Features.Products.Queries.GetAllOfferedUserProducts
{
	public class GetAllOfferedUserProductsQueryRequest : IRequest<ServiceResponse<IReadOnlyList<GetAllOfferedUserProductsQueryResponse>>>
	{
		public int UserId { get; set; }
	}
}
