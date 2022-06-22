using AutoMapper;
using MediatR;
using ProductCatalog.Application.Repositories;
using ProductCatalog.Application.ServiceResponses;

namespace ProductCatalog.Application.Features.Products.Queries.GetProduct
{
	public class GetProductQueryHandler : IRequestHandler<GetProductQueryRequest, ServiceResponse<GetProductQueryResponse>>
	{
		private readonly IProductReadRepository _productReadRepository;
		private readonly IMapper _mapper;

		public GetProductQueryHandler(IProductReadRepository ProductReadRepository, IMapper mapper)
		{
			_productReadRepository = ProductReadRepository;
			_mapper = mapper;
		}

		public async Task<ServiceResponse<GetProductQueryResponse>> Handle(GetProductQueryRequest request, CancellationToken cancellationToken)
		{
			var validator = new GetProductQueryValidator();
			var validationResult = await validator.ValidateAsync(request);

			if (!validationResult.IsValid)
			{
				var response = new ServiceResponse<GetProductQueryResponse>(validationResult.Errors.Select(q => q.ErrorMessage).ToList(), null);
				return response;
			}

			var products = await _productReadRepository.GetProductById(request.Id);
			return new ServiceResponse<GetProductQueryResponse>(new List<string>(), _mapper.Map<GetProductQueryResponse>(products));
		}
	}
}
