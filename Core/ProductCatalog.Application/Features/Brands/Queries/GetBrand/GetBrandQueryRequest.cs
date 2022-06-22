using MediatR;
using ProductCatalog.Application.ServiceResponses;

namespace ProductCatalog.Application.Features.Brands
{
	public class GetBrandQueryRequest : IRequest<ServiceResponse<GetBrandQueryResponse>>
	{
		public int Id { get; set; }
	}
}