using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using ProductCatalog.Application.Repositories;
using ProductCatalog.Application.ServiceResponses;
using ProductCatalog.Domain.Entities;

namespace ProductCatalog.Application.Features.Authentications.Queries.GetUserId
{
	public class GetLoggedInUserIdQueryHandler : IRequestHandler<GetLoggedInUserIdQueryRequest, ServiceResponse<GetLoggedInUserIdQueryResponse>>
    {
        private readonly ICategoryReadRepository _categoryReadRepository;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;

		public GetLoggedInUserIdQueryHandler(ICategoryReadRepository categoryReadRepository, IMapper mapper, UserManager<User> userManager)
		{
			_categoryReadRepository = categoryReadRepository;
			_mapper = mapper;
			_userManager = userManager;
		}

		public async Task<ServiceResponse<GetLoggedInUserIdQueryResponse>> Handle(GetLoggedInUserIdQueryRequest request, CancellationToken cancellationToken)
        {
            return new ServiceResponse<GetLoggedInUserIdQueryResponse>(new List<string>(), new GetLoggedInUserIdQueryResponse() { LoggedInUserId = request.LoggedInUserId });
        }
    }
}
