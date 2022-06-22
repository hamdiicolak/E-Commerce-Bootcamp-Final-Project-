using AutoMapper;
using MediatR;
using ProductCatalog.Application.Repositories;
using ProductCatalog.Application.ServiceResponses;

namespace ProductCatalog.Application.Features.UsingStatuses
{
	public class GetUsingStatusQueryHandler : IRequestHandler<GetUsingStatusQueryRequest, ServiceResponse<GetUsingStatusQueryResponse>>
	{
		private readonly IUsingStatusReadRepository _usingStatusReadRepository;
		private readonly IMapper _mapper;

		public GetUsingStatusQueryHandler(IUsingStatusReadRepository usingStatusReadRepository, IMapper mapper)
		{
			_usingStatusReadRepository = usingStatusReadRepository;
			_mapper = mapper;
		}

		public async Task<ServiceResponse<GetUsingStatusQueryResponse>> Handle(GetUsingStatusQueryRequest request, CancellationToken cancellationToken)
		{
			var validator = new GetUsingStatusQueryValidator();
			var validationResult = await validator.ValidateAsync(request);

			if (!validationResult.IsValid)
			{
				var response = new ServiceResponse<GetUsingStatusQueryResponse>(validationResult.Errors.Select(q => q.ErrorMessage).ToList(), null);
				return response;
			}

			var usingStatus = await _usingStatusReadRepository.GetByIdAsync(request.Id);
			return new ServiceResponse<GetUsingStatusQueryResponse>(new List<string>(), _mapper.Map<GetUsingStatusQueryResponse>(usingStatus));
		}
	}
}
