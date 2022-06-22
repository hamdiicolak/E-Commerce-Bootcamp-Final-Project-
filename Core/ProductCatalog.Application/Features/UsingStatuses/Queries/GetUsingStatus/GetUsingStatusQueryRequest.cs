using MediatR;
using ProductCatalog.Application.ServiceResponses;

namespace ProductCatalog.Application.Features.UsingStatuses
{
	public class GetUsingStatusQueryRequest : IRequest<ServiceResponse<GetUsingStatusQueryResponse>>
	{
		public int Id { get; set; }
	}
}