namespace ProductCatalog.UI.Models
{
	public class ProductAndCategoryVM
	{
		public IReadOnlyList<ProductViewModel> Products { get; set; }
		public IReadOnlyList<CategoriesViewModel> Categories { get; set; }
	}
}
