using AutoMapper;
using MediatR;
using ProductCatalog.Application.Repositories;
using ProductCatalog.Application.ServiceResponses;
using ProductCatalog.Domain.Entities;

namespace ProductCatalog.Application.Features
{
	public class NewOfferCommandHandler : IRequestHandler<NewOfferCommandRequest, ServiceResponse<bool>>
	{
		private readonly IOfferWriteRepository _offerWriteRepository;
		private readonly IOfferReadRepository _offerReadRepository;
		private readonly IProductWriteRepository _productWriteRepository;
		private readonly IProductReadRepository _productReadRepository;
		private readonly IMapper _mapper;

		public NewOfferCommandHandler(IMapper mapper, IOfferWriteRepository offerWriteRepository, IProductReadRepository productReadRepository, IProductWriteRepository productWriteRepository, IOfferReadRepository offerReadRepository)
		{
			_mapper = mapper;
			_offerWriteRepository = offerWriteRepository;
			_productReadRepository = productReadRepository;
			_productWriteRepository = productWriteRepository;
			_offerReadRepository = offerReadRepository;
		}

		public async Task<ServiceResponse<bool>> Handle(NewOfferCommandRequest request, CancellationToken cancellationToken)
		{
			NewOfferCommandValidator validator = new();

			var response = new ServiceResponse<bool>(new List<string>(), false);
			var validationResult = await validator.ValidateAsync(request);

			if (!validationResult.IsValid)
			{
				response.ErrorMessages = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
				return response;
			}

			response.ResponseData = true;
			var offer = await _offerReadRepository.GetOffer(x => x.ProductId == request.ProductId && x.UserId == request.UserId);
			var product = await _productReadRepository.GetProductById(request.ProductId);

			if (offer == null)
			{
				var newOffer = _mapper.Map<Offer>(request);
				if (product.Offers == null)
					product.Offers = new List<Offer>();

				product.Offers.Add(newOffer);
				await _offerWriteRepository.AddAsync(newOffer);
			}
			else
			{
				offer.OfferPrice = request.OfferPrice;
				if (product.Offers.FirstOrDefault(x => x.UserId == request.UserId) != null)
					product.Offers.FirstOrDefault(x => x.UserId == request.UserId).OfferPrice = request.OfferPrice;
				await _offerWriteRepository.UpdateAsync(offer);

			}

			await _productWriteRepository.UpdateAsync(product);
			await _productWriteRepository.SaveAsync();
			await _offerWriteRepository.SaveAsync();

			return response;
		}
	}
}
