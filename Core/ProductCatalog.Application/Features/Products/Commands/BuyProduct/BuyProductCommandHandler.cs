using AutoMapper;
using MediatR;
using ProductCatalog.Application.Repositories;
using ProductCatalog.Application.ServiceResponses;
using ProductCatalog.Domain.Entities;

namespace ProductCatalog.Application.Features.Products.Commands.BuyProduct
{
	public class BuyProductCommandHandler : IRequestHandler<BuyProductCommandRequest, ServiceResponse<bool>>
	{
		private readonly IProductWriteRepository _productWriteRepository;
		private readonly IProductReadRepository _productReadRepository;
		private readonly IMapper _mapper;

		public BuyProductCommandHandler(IProductWriteRepository productWriteRepository, IMapper mapper, IProductReadRepository productReadRepository)
		{
			_productWriteRepository = productWriteRepository;
			_productReadRepository = productReadRepository;
			_mapper = mapper;
		}

		public async Task<ServiceResponse<bool>> Handle(BuyProductCommandRequest request, CancellationToken cancellationToken)
		{
			var product = await _productReadRepository.GetProductById(request.Id);
			product.IsOfferable = false;
			product.IsSold = true;

			await _productWriteRepository.UpdateAsync(product);
			await _productWriteRepository.SaveAsync();

			return new ServiceResponse<bool>(new List<string>(), true);
		}
	}
}
