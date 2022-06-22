using AutoMapper;
using MediatR;
using ProductCatalog.Application.Repositories;
using ProductCatalog.Application.ServiceResponses;

namespace ProductCatalog.Application.Features.Colors
{
	public class GetColorQueryHandler : IRequestHandler<GetColorQueryRequest, ServiceResponse<GetColorQueryResponse>>
	{
		private readonly IColorReadRepository _colorReadRepository;
		private readonly IMapper _mapper;

		public GetColorQueryHandler(IColorReadRepository colorReadRepository, IMapper mapper)
		{
			_colorReadRepository = colorReadRepository;
			_mapper = mapper;
		}

		public async Task<ServiceResponse<GetColorQueryResponse>> Handle(GetColorQueryRequest request, CancellationToken cancellationToken)
		{
			var validator = new GetColorQueryValidator();
			var validationResult = await validator.ValidateAsync(request);

			if (!validationResult.IsValid)
			{
				var response = new ServiceResponse<GetColorQueryResponse>(validationResult.Errors.Select(q => q.ErrorMessage).ToList(), null);
				return response;
			}

			var color = await _colorReadRepository.GetByIdAsync(request.Id);
			return new ServiceResponse<GetColorQueryResponse>(new List<string>(), _mapper.Map<GetColorQueryResponse>(color));
		}
	}
}
