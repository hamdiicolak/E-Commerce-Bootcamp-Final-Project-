using AutoMapper;
using MediatR;
using ProductCatalog.Application.Repositories;
using ProductCatalog.Application.ServiceResponses;
using ProductCatalog.Domain.Entities;

namespace ProductCatalog.Application.Features.Products.Commands.New_Product
{
	public class NewProductCommandHandler : IRequestHandler<NewProductCommandRequest, ServiceResponse<bool>>
	{
		private readonly IProductWriteRepository _productWriteRepository;
		private readonly IMapper _mapper;

		public NewProductCommandHandler(IProductWriteRepository productWriteRepository, IMapper mapper)
		{
			_productWriteRepository = productWriteRepository;
			_mapper = mapper;
		}

		public async Task<ServiceResponse<bool>> Handle(NewProductCommandRequest request, CancellationToken cancellationToken)
		{
			NewProductCommandValidator validator = new();

			var response = new ServiceResponse<bool>(new List<string>(), false);
			var validationResult = await validator.ValidateAsync(request);

			if (!validationResult.IsValid)
			{
				response.ErrorMessages = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
				return response;
			}

			response.ResponseData = true;
			var product = _mapper.Map<Product>(request);
			await _productWriteRepository.AddAsync(product);
			await _productWriteRepository.SaveAsync();
			return response;
		}
	}
}
