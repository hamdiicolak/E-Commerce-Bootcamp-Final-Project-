using AutoMapper;
using MediatR;
using ProductCatalog.Application.Repositories;
using ProductCatalog.Application.ServiceResponses;

namespace ProductCatalog.Application.Features.Brands
{
	public class GetBrandQueryHandler : IRequestHandler<GetBrandQueryRequest, ServiceResponse<GetBrandQueryResponse>>
	{
		private readonly IBrandReadRepository _brandReadRepository;
		private readonly IMapper _mapper;

		public GetBrandQueryHandler(IBrandReadRepository brandReadRepository, IMapper mapper)
		{
			_brandReadRepository = brandReadRepository;
			_mapper = mapper;
		}

		public async Task<ServiceResponse<GetBrandQueryResponse>> Handle(GetBrandQueryRequest request, CancellationToken cancellationToken)
		{
			var validator = new GetBrandQueryValidator();
			var validationResult = await validator.ValidateAsync(request);

			if (!validationResult.IsValid)
			{
				var response = new ServiceResponse<GetBrandQueryResponse>(validationResult.Errors.Select(q => q.ErrorMessage).ToList(), null);
				return response;
			}

			var brand = await _brandReadRepository.GetByIdAsync(request.Id);
			return new ServiceResponse<GetBrandQueryResponse>(new List<string>(), _mapper.Map<GetBrandQueryResponse>(brand));
		}
	}
}
