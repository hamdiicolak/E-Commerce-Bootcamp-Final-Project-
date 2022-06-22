using MediatR;
using ProductCatalog.Application.ServiceResponses;

namespace ProductCatalog.Application.Features.Products.Commands.New_Product
{
	public class NewProductCommandRequest : IRequest<ServiceResponse<bool>>
	{
		public string Name { get; set; }
		public decimal Price { get; set; }
		public bool IsOfferable { get; set; }
		public bool IsSold { get; set; }
		public string ImageUrl { get; set; }
		public string Description { get; set; }
		public string Size { get; set; }
		public int CategoryId { get; set; }
		public int UserId { get; set; }
		public int? BrandId { get; set; }
		public int? ColorId { get; set; }
		public int UsingStatusId { get; set; }
	}
}
