using MediatR;
using ProductCatalog.Application.ServiceResponses;

namespace ProductCatalog.Application.Features.Colors
{
	public class GetAllColorsQueryRequest : IRequest<ServiceResponse<IReadOnlyList<GetAllColorsQueryResponse>>> { }
}
