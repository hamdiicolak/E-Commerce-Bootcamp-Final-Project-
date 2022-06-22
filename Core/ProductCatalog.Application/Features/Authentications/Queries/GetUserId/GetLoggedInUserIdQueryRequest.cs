using MediatR;
using ProductCatalog.Application.ServiceResponses;

namespace ProductCatalog.Application.Features.Authentications.Queries.GetUserId
{
	public class GetLoggedInUserIdQueryRequest : IRequest<ServiceResponse<GetLoggedInUserIdQueryResponse>> 
	{
		public int LoggedInUserId { get; set; }
	}
}
