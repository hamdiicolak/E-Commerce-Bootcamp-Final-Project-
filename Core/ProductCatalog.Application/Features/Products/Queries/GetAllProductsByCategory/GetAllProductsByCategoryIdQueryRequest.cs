using MediatR;
using ProductCatalog.Application.ServiceResponses;

namespace ProductCatalog.Application.Features.Products.Queries.GetAllProductsByCategory
{
	public class GetAllProductsByCategoryIdQueryRequest : IRequest<ServiceResponse<IReadOnlyList<GetAllProductsByCategoryIdQueryResponse>>>
	{
		public int CategoryId { get; set; }
	}
}
