using AutoMapper;
using MediatR;
using ProductCatalog.Application.Repositories;
using ProductCatalog.Application.ServiceResponses;
using ProductCatalog.Domain.Entities;

namespace ProductCatalog.Application.Features.Offers.Commands.ApproveOffer
{
	public class ApproveOfferCommandHandler : IRequestHandler<ApproveOfferCommandRequest, ServiceResponse<bool>>
	{
		private readonly IOfferWriteRepository _offerWriteRepository;
		private readonly IOfferReadRepository _offerReadRepository;
		private readonly IMapper _mapper;

		public ApproveOfferCommandHandler(IMapper mapper, IOfferWriteRepository offerWriteRepository, IOfferReadRepository offerReadRepository)
		{
			_mapper = mapper;
			_offerWriteRepository = offerWriteRepository;
			_offerReadRepository = offerReadRepository;
		}

		public async Task<ServiceResponse<bool>> Handle(ApproveOfferCommandRequest request, CancellationToken cancellationToken)
		{
			ApproveOfferCommandValidator validator = new();

			var response = new ServiceResponse<bool>(new List<string>(), false);
			var validationResult = await validator.ValidateAsync(request);

			if (!validationResult.IsValid)
			{
				response.ErrorMessages = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
				return response;
			}

			var offer = await _offerReadRepository.GetByIdAsync(request.OfferId);
			offer.OfferApproved = true;

			await _offerWriteRepository.UpdateAsync(offer);
			await _offerWriteRepository.SaveAsync();

			return response;
		}
	}
}
