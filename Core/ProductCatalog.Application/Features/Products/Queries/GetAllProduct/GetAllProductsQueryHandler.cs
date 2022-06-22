using AutoMapper;
using MediatR;
using ProductCatalog.Application.Repositories;
using ProductCatalog.Application.ServiceResponses;

namespace ProductCatalog.Application.Features.Products.Queries.GetAllProduct
{
	public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQueryRequest, ServiceResponse<IReadOnlyList<GetAllProductsQueryResponse>>>
	{
		private readonly IProductReadRepository _productReadRepository;
		private readonly IMapper _mapper;

		public GetAllProductsQueryHandler(IProductReadRepository ProductReadRepository, IMapper mapper)
		{
			_productReadRepository = ProductReadRepository;
			_mapper = mapper;
		}
		public async Task<ServiceResponse<IReadOnlyList<GetAllProductsQueryResponse>>> Handle(GetAllProductsQueryRequest request, CancellationToken cancellationToken)
		{
			var products = await _productReadRepository.GetAllProducts();

			return new ServiceResponse<IReadOnlyList<GetAllProductsQueryResponse>> (new List<string>(), _mapper.Map<IReadOnlyList<GetAllProductsQueryResponse>>(products));
		}
	}
}
