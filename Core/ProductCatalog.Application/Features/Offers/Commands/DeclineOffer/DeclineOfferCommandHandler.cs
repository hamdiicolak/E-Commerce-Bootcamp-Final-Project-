using AutoMapper;
using MediatR;
using ProductCatalog.Application.Repositories;
using ProductCatalog.Application.ServiceResponses;
using ProductCatalog.Domain.Entities;

namespace ProductCatalog.Application.Features.Offers.Commands.DeclineOffer
{
	public class DeclineOfferCommandHandler : IRequestHandler<DeclineOfferCommandRequest, ServiceResponse<bool>>
	{
		private readonly IOfferWriteRepository _offerWriteRepository;
		private readonly IOfferReadRepository _offerReadRepository;
		private readonly IMapper _mapper;

		public DeclineOfferCommandHandler(IMapper mapper, IOfferWriteRepository offerWriteRepository, IOfferReadRepository offerReadRepository)
		{
			_mapper = mapper;
			_offerWriteRepository = offerWriteRepository;
			_offerReadRepository = offerReadRepository;
		}

		public async Task<ServiceResponse<bool>> Handle(DeclineOfferCommandRequest request, CancellationToken cancellationToken)
		{
			DeclineOfferCommandValidator validator = new();

			var response = new ServiceResponse<bool>(new List<string>(), false);
			var validationResult = await validator.ValidateAsync(request);

			if (!validationResult.IsValid)
			{
				response.ErrorMessages = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
				return response;
			}

			var offer = await _offerReadRepository.GetByIdAsync(request.OfferId);

			await _offerWriteRepository.RemoveAsync(offer);
			await _offerWriteRepository.SaveAsync();

			return response;
		}
	}
}
