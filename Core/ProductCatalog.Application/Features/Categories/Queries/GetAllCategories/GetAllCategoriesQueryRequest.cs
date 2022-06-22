using MediatR;
using ProductCatalog.Application.ServiceResponses;

namespace ProductCatalog.Application.Features.Categories.Queries.GetAllCategories
{
	public class GetAllCategoriesQueryRequest : IRequest<ServiceResponse<IReadOnlyList<GetAllCategoriesQueryResponse>>> { }
}
