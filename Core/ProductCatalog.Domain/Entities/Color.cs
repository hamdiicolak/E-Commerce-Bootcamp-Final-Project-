namespace ProductCatalog.Domain.Entities
{
	public class Color : EntityBase
	{
		public string ColorName { get; set; }

		#region Product

		// One to many 
		// There may be more than one product belonging to the color.
		// Collection Navigation Property
		public ICollection<Product> Products { get; set; }

		#endregion
	}
}
