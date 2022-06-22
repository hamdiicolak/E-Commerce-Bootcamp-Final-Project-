using AutoMapper;
using MediatR;
using ProductCatalog.Application.Repositories;
using ProductCatalog.Application.ServiceResponses;

namespace ProductCatalog.Application.Features.Colors
{
	public class GetAllColorsQueryHandler : IRequestHandler<GetAllColorsQueryRequest, ServiceResponse<IReadOnlyList<GetAllColorsQueryResponse>>>
	{
		private readonly IColorReadRepository _colorReadRepository;
		private readonly IMapper _mapper;

		public GetAllColorsQueryHandler(IColorReadRepository colorReadRepository, IMapper mapper)
		{
			_colorReadRepository = colorReadRepository;
			_mapper = mapper;
		}

		public async Task<ServiceResponse<IReadOnlyList<GetAllColorsQueryResponse>>> Handle(GetAllColorsQueryRequest request, CancellationToken cancellationToken)
		{
			var colors = await _colorReadRepository.GetAllAsync();
			return new ServiceResponse<IReadOnlyList<GetAllColorsQueryResponse>>(new List<string>(), _mapper.Map<IReadOnlyList<GetAllColorsQueryResponse>>(colors));
		}
	}
}
