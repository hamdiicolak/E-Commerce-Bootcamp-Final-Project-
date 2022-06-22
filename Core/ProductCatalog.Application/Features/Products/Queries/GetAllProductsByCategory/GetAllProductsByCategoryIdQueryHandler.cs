using AutoMapper;
using MediatR;
using ProductCatalog.Application.Repositories;
using ProductCatalog.Application.ServiceResponses;

namespace ProductCatalog.Application.Features.Products.Queries.GetAllProductsByCategory
{
	public class GetAllProductsByCategoryIdQueryHandler : IRequestHandler<GetAllProductsByCategoryIdQueryRequest, ServiceResponse<IReadOnlyList<GetAllProductsByCategoryIdQueryResponse>>>
	{
		private readonly IProductReadRepository _productReadRepository;

		private readonly IMapper _mapper;

		public GetAllProductsByCategoryIdQueryHandler(IProductReadRepository ProductReadRepository, IMapper mapper)
		{
			_productReadRepository = ProductReadRepository;
			_mapper = mapper;
		}

		public async Task<ServiceResponse<IReadOnlyList<GetAllProductsByCategoryIdQueryResponse>>> Handle(GetAllProductsByCategoryIdQueryRequest request, CancellationToken cancellationToken)
		{
			var validator = new GetAllProductsByCategoryIdQueryValidator();
			var validationResult = await validator.ValidateAsync(request);

			if (!validationResult.IsValid)
			{
				var response = new ServiceResponse<IReadOnlyList<GetAllProductsByCategoryIdQueryResponse>>(validationResult.Errors.Select(q => q.ErrorMessage).ToList(), null);
				return response;
			}

			var allProductsByCategoryId = await _productReadRepository.GetAllProductsByCategoryId(x => x.CategoryId == request.CategoryId);
			return new ServiceResponse<IReadOnlyList<GetAllProductsByCategoryIdQueryResponse>>(new List<string>(), _mapper.Map<IReadOnlyList<GetAllProductsByCategoryIdQueryResponse>>(allProductsByCategoryId));
		}
	}
}
