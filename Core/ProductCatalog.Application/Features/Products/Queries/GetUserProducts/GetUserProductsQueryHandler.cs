using AutoMapper;
using MediatR;
using ProductCatalog.Application.Repositories;
using ProductCatalog.Application.ServiceResponses;

namespace ProductCatalog.Application.Features.Products.Queries.GetUserProducts
{
	public class GetUserProductsQueryHandler : IRequestHandler<GetUserProductsQueryRequest, ServiceResponse<IReadOnlyList<GetAllUserProductsQueryResponse>>>
	{
		private readonly IProductReadRepository _productReadRepository;

		private readonly IMapper _mapper;

		public GetUserProductsQueryHandler(IProductReadRepository ProductReadRepository, IMapper mapper)
		{
			_productReadRepository = ProductReadRepository;
			_mapper = mapper;
		}

		public async Task<ServiceResponse<IReadOnlyList<GetAllUserProductsQueryResponse>>> Handle(GetUserProductsQueryRequest request, CancellationToken cancellationToken)
		{
			var validator = new GetUserProductsQueryValidator();
			var validationResult = await validator.ValidateAsync(request);

			if (!validationResult.IsValid)
			{
				var response = new ServiceResponse<IReadOnlyList<GetAllUserProductsQueryResponse>>(validationResult.Errors.Select(q => q.ErrorMessage).ToList(), null);
				return response;
			}

			var userProducts = await _productReadRepository.GetAllUserProducts(x => x.UserId == request.UserId);
			return new ServiceResponse<IReadOnlyList<GetAllUserProductsQueryResponse>>(new List<string>(), _mapper.Map<IReadOnlyList<GetAllUserProductsQueryResponse>>(userProducts));
		}
	}
}
