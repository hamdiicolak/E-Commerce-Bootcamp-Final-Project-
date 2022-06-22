namespace ProductCatalog.Application.Features.Products.Queries.GetProduct
{
	public class GetProductQueryResponse
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public decimal Price { get; set; }
		public string UserName { get; set; }
		public bool IsOfferable { get; set; }
		public bool IsSold { get; set; }
		public string ImageUrl { get; set; }
		public string Category { get; set; }
		public string Brand { get; set; }
		public string Color { get; set; }
		public string UsingStatus { get; set; }
		public string Size { get; set; }
		public string Description { get; set; }
	}
}
