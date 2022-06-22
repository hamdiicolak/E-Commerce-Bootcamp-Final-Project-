using MediatR;
using ProductCatalog.Application.ServiceResponses;

namespace ProductCatalog.Application.Features.Categories.Queries.GetCategory
{
	public class GetCategoryQueryRequest : IRequest<ServiceResponse<GetCategoryQueryResponse>>
	{
		public int Id { get; set; }
	}
}