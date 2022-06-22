using MediatR;
using ProductCatalog.Application.ServiceResponses;

namespace ProductCatalog.Application.Features.Categories.Queries.GetAllOffers
{
	public class GetAllOffersQueryRequest : IRequest<ServiceResponse<IReadOnlyList<GetAllOffersQueryResponse>>> { }
}
