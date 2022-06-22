using MediatR;
using ProductCatalog.Application.ServiceResponses;

namespace ProductCatalog.Application.Features.UsingStatuses
{
	public class GetAllUsingStatusesQueryRequest : IRequest<ServiceResponse<IReadOnlyList<GetAllUsingStatusesQueryResponse>>> { }
}
