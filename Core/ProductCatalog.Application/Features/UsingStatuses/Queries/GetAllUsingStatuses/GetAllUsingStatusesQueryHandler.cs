using AutoMapper;
using MediatR;
using ProductCatalog.Application.Repositories;
using ProductCatalog.Application.ServiceResponses;

namespace ProductCatalog.Application.Features.UsingStatuses
{
	public class GetAllUsingStatusesQueryHandler : IRequestHandler<GetAllUsingStatusesQueryRequest, ServiceResponse<IReadOnlyList<GetAllUsingStatusesQueryResponse>>>
	{
		private readonly IUsingStatusReadRepository _usingStatusReadRepository;
		private readonly IMapper _mapper;

		public GetAllUsingStatusesQueryHandler(IUsingStatusReadRepository usingStatusReadRepository, IMapper mapper)
		{
			_usingStatusReadRepository = usingStatusReadRepository;
			_mapper = mapper;
		}

		public async Task<ServiceResponse<IReadOnlyList<GetAllUsingStatusesQueryResponse>>> Handle(GetAllUsingStatusesQueryRequest request, CancellationToken cancellationToken)
		{
			var usingStatuses = await _usingStatusReadRepository.GetAllAsync();
			return new ServiceResponse<IReadOnlyList<GetAllUsingStatusesQueryResponse>>(new List<string>(), _mapper.Map<IReadOnlyList<GetAllUsingStatusesQueryResponse>>(usingStatuses));
		}
	}
}
