using AutoMapper;
using MediatR;
using ProductCatalog.Application.Repositories;
using ProductCatalog.Application.ServiceResponses;

namespace ProductCatalog.Application.Features.Categories.Queries.GetCategory
{
	public class GetCategoryQueryHandler : IRequestHandler<GetCategoryQueryRequest, ServiceResponse<GetCategoryQueryResponse>>
	{
		private readonly ICategoryReadRepository _categoryReadRepository;
		private readonly IMapper _mapper;

		public GetCategoryQueryHandler(ICategoryReadRepository categoryReadRepository, IMapper mapper)
		{
			_categoryReadRepository = categoryReadRepository;
			_mapper = mapper;
		}

		public async Task<ServiceResponse<GetCategoryQueryResponse>> Handle(GetCategoryQueryRequest request, CancellationToken cancellationToken)
		{
			var validator = new GetCategoryQueryValidator();
			var validationResult = await validator.ValidateAsync(request);

			if (!validationResult.IsValid)
			{
				var response = new ServiceResponse<GetCategoryQueryResponse>(validationResult.Errors.Select(q => q.ErrorMessage).ToList(), null);
				return response;
			}

			var category = await _categoryReadRepository.GetByIdAsync(request.Id);
			return new ServiceResponse<GetCategoryQueryResponse>(new List<string>(), _mapper.Map<GetCategoryQueryResponse>(category));
		}
	}
}
