using AutoMapper;
using MediatR;
using ProductCatalog.Application.Repositories;
using ProductCatalog.Application.ServiceResponses;

namespace ProductCatalog.Application.Features.Categories.Queries.GetAllCategories
{
	public class GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQueryRequest, ServiceResponse<IReadOnlyList<GetAllCategoriesQueryResponse>>>
    {
        private readonly ICategoryReadRepository _categoryReadRepository;
        private readonly IMapper _mapper;

        public GetAllCategoriesQueryHandler(ICategoryReadRepository categoryReadRepository, IMapper mapper)
        {
            _categoryReadRepository = categoryReadRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<IReadOnlyList<GetAllCategoriesQueryResponse>>> Handle(GetAllCategoriesQueryRequest request, CancellationToken cancellationToken)
        {
            var categories = await _categoryReadRepository.GetAllAsync();
            return new ServiceResponse<IReadOnlyList<GetAllCategoriesQueryResponse>>(new List<string>(), _mapper.Map<IReadOnlyList<GetAllCategoriesQueryResponse>>(categories));
        }
    }
}
