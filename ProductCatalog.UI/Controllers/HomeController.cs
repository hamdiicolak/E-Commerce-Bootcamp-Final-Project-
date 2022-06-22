using Microsoft.AspNetCore.Mvc;
using ProductCatalog.UI.Models;
using ProductCatalog.UI.Services;
using X.PagedList;  

namespace ProductCatalog.UI.Controllers
{
	public class HomeController : Controller
	{
		private readonly IProductService _productService;
		private readonly ICategoryService _categoryService;

		public HomeController(IProductService productService, ICategoryService categoryService)
		{
			_categoryService = categoryService;
			_productService = productService;
		}

		#region Get All Products

		[HttpGet]
		public async Task<IActionResult> Index()
		{
			ProductAndCategoryVM productsAndCategories = new();
			productsAndCategories.Categories = await _categoryService.GetAllCategoriesAsync();

			if (!TempData.ContainsKey("categoryId"))
				productsAndCategories.Products = await _productService.GetAllProductsAsync();
			else
			{
				int categoryId = (int)TempData["categoryId"];
				productsAndCategories.Products = await _productService.GetAllProductsByCategoryIdAsync(categoryId);
			}


			return View(productsAndCategories);
		}

		#endregion

		#region Get All Categories



		#endregion

	}
}