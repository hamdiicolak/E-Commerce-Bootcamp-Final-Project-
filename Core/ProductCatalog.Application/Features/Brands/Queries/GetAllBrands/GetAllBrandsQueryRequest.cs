using MediatR;
using ProductCatalog.Application.ServiceResponses;

namespace ProductCatalog.Application.Features.Brands
{
	public class GetAllBrandsQueryRequest : IRequest<ServiceResponse<IReadOnlyList<GetAllBrandsQueryResponse>>> { }
}
