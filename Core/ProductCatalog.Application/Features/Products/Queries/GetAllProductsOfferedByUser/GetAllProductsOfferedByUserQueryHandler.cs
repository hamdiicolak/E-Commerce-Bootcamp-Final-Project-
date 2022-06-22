using AutoMapper;
using MediatR;
using ProductCatalog.Application.Repositories;
using ProductCatalog.Application.ServiceResponses;

namespace ProductCatalog.Application.Features.Products.Queries.GetAllProductsOfferedByUser
{
	public class GetAllProductsOfferedByUserQueryHandler : IRequestHandler<GetAllProductsOfferedByUserQueryRequest, ServiceResponse<IReadOnlyList<GetAllProductsOfferedByUserQueryResponse>>>
	{
		private readonly IProductReadRepository _productReadRepository;

		private readonly IMapper _mapper;

		public GetAllProductsOfferedByUserQueryHandler(IProductReadRepository ProductReadRepository, IMapper mapper)
		{
			_productReadRepository = ProductReadRepository;
			_mapper = mapper;
		}

		public async Task<ServiceResponse<IReadOnlyList<GetAllProductsOfferedByUserQueryResponse>>> Handle(GetAllProductsOfferedByUserQueryRequest request, CancellationToken cancellationToken)
		{
			var validator = new GetAllProductsOfferedByUserQueryValidator();
			var validationResult = await validator.ValidateAsync(request);

			if (!validationResult.IsValid)
			{
				var response = new ServiceResponse<IReadOnlyList<GetAllProductsOfferedByUserQueryResponse>>(validationResult.Errors.Select(q => q.ErrorMessage).ToList(), null);
				return response;
			}

			var allProductsOfferedByUser = await _productReadRepository.GetAllProductsOfferedByUser(x => x.Offers.Any(o => o.UserId == request.UserId));
			return new ServiceResponse<IReadOnlyList<GetAllProductsOfferedByUserQueryResponse>>(new List<string>(), _mapper.Map<IReadOnlyList<GetAllProductsOfferedByUserQueryResponse>>(allProductsOfferedByUser));
		}
	}
}
