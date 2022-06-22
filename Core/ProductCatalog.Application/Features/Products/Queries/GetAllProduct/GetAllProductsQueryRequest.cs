using MediatR;
using ProductCatalog.Application.ServiceResponses;

namespace ProductCatalog.Application.Features.Products.Queries.GetAllProduct
{
    public class GetAllProductsQueryRequest : IRequest<ServiceResponse<IReadOnlyList<GetAllProductsQueryResponse>>> { }
}
