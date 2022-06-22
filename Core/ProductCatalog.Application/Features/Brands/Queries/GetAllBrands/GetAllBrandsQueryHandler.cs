using AutoMapper;
using MediatR;
using ProductCatalog.Application.Repositories;
using ProductCatalog.Application.ServiceResponses;

namespace ProductCatalog.Application.Features.Brands
{
	public class GetAllBrandsQueryHandler : IRequestHandler<GetAllBrandsQueryRequest, ServiceResponse<IReadOnlyList<GetAllBrandsQueryResponse>>>
	{
		private readonly IBrandReadRepository _brandReadRepository;
		private readonly IMapper _mapper;

		public GetAllBrandsQueryHandler(IBrandReadRepository brandReadRepository, IMapper mapper)
		{
			_brandReadRepository = brandReadRepository;
			_mapper = mapper;
		}

		public async Task<ServiceResponse<IReadOnlyList<GetAllBrandsQueryResponse>>> Handle(GetAllBrandsQueryRequest request, CancellationToken cancellationToken)
		{
			var brandes = await _brandReadRepository.GetAllAsync();
			return new ServiceResponse<IReadOnlyList<GetAllBrandsQueryResponse>> (new List<string>(), _mapper.Map<IReadOnlyList<GetAllBrandsQueryResponse>>(brandes));
		}
	}
}
