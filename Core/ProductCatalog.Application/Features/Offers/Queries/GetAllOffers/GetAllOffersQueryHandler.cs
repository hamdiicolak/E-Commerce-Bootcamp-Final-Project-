using AutoMapper;
using MediatR;
using ProductCatalog.Application.Repositories;
using ProductCatalog.Application.ServiceResponses;

namespace ProductCatalog.Application.Features.Categories.Queries.GetAllOffers
{
	public class GetAllOffersQueryHandler : IRequestHandler<GetAllOffersQueryRequest, ServiceResponse<IReadOnlyList<GetAllOffersQueryResponse>>>
    {
        private readonly IOfferReadRepository _offerReadRepository;
        private readonly IMapper _mapper;

        public GetAllOffersQueryHandler(IOfferReadRepository offerReadRepository, IMapper mapper)
        {
            _offerReadRepository = offerReadRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<IReadOnlyList<GetAllOffersQueryResponse>>> Handle(GetAllOffersQueryRequest request, CancellationToken cancellationToken)
        {
            var offers = await _offerReadRepository.GetAllAsync();
            return new ServiceResponse<IReadOnlyList<GetAllOffersQueryResponse>>(new List<string>(), _mapper.Map<IReadOnlyList<GetAllOffersQueryResponse>>(offers));
        }
    }
}
