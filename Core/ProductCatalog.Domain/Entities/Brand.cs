namespace ProductCatalog.Domain.Entities
{
	public class Brand : EntityBase
	{
		public string BrandName { get; set; }

		#region Product

		// One to many 
		// There may be more than one product belonging to the category.
		// Collection Navigation Property
		public ICollection<Product> Products { get; set; }

		#endregion
	}
}
