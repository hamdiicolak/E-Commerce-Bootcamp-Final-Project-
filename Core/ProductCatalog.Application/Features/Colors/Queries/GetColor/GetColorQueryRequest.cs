using MediatR;
using ProductCatalog.Application.ServiceResponses;

namespace ProductCatalog.Application.Features.Colors
{
	public class GetColorQueryRequest : IRequest<ServiceResponse<GetColorQueryResponse>>
	{
		public int Id { get; set; }
	}
}