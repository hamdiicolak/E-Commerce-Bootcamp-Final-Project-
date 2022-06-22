using AutoMapper;
using MediatR;
using ProductCatalog.Application.Repositories;
using ProductCatalog.Application.ServiceResponses;

namespace ProductCatalog.Application.Features.Products.Queries.GetAllOfferedUserProducts
{
	public class GetAllOfferedUserProductsQueryHandler : IRequestHandler<GetAllOfferedUserProductsQueryRequest, ServiceResponse<IReadOnlyList<GetAllOfferedUserProductsQueryResponse>>>
	{
		private readonly IProductReadRepository _productReadRepository;
		private readonly IMapper _mapper;

		public GetAllOfferedUserProductsQueryHandler(IProductReadRepository ProductReadRepository, IMapper mapper)
		{
			_productReadRepository = ProductReadRepository;
			_mapper = mapper;
		}

		public async Task<ServiceResponse<IReadOnlyList<GetAllOfferedUserProductsQueryResponse>>> Handle(GetAllOfferedUserProductsQueryRequest request, CancellationToken cancellationToken)
		{
			var validator = new GetAllOfferedUserProductsQueryValidator();
			var validationResult = await validator.ValidateAsync(request);

			if (!validationResult.IsValid)
			{
				var response = new ServiceResponse<IReadOnlyList<GetAllOfferedUserProductsQueryResponse>>(validationResult.Errors.Select(q => q.ErrorMessage).ToList(), null);
				return response;
			}

			var allOfferedUserProducts = await _productReadRepository.GetAllOfferedUserProducts(x => x.UserId == request.UserId && x.Offers.Any());
			return new ServiceResponse<IReadOnlyList<GetAllOfferedUserProductsQueryResponse>>(new List<string>(), _mapper.Map<IReadOnlyList<GetAllOfferedUserProductsQueryResponse>>(allOfferedUserProducts));

		}
	}
}
