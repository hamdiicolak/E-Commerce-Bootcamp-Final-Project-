using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProductCatalog.UI.Models;
using ProductCatalog.UI.Services;


namespace ProductCatalog.UI.Controllers
{
	public class ProductsController : Controller
	{
		private readonly IProductService _productService;
		private readonly ICategoryService _categoryService;
		private readonly IBrandService _brandService;
		private readonly IColorService _colorService;
		private readonly IUsingStatusService _usingStatusService;
		private readonly IWebHostEnvironment _webHostEnvironment;

		public ProductsController(IProductService productService, ICategoryService categoryService, IWebHostEnvironment webHostEnvironment, IBrandService brandService, IColorService colorService, IUsingStatusService usingStatusService)
		{
			_productService = productService;
			_categoryService = categoryService;
			_webHostEnvironment = webHostEnvironment;
			_brandService = brandService;
			_colorService = colorService;
			_usingStatusService = usingStatusService;
		}

		#region Add Product

		[HttpGet]
		public async Task<IActionResult> AddProduct()
		{
			await RefreshViewBagData();
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> AddProduct(NewProductViewModel newProduct)
		{
			if (!ModelState.IsValid)
			{
				await RefreshViewBagData();
				return View(newProduct);
			}

			string imageUrl = GetImageUrl(newProduct);
			newProduct.ImageUrl = imageUrl;

			var result = await _productService.AddProductAsync(newProduct);

			if (result.ResponseData)
			{
				SaveImage(newProduct);
				return RedirectToAction("Index", "Home");
			}

			await RefreshViewBagData();
			TempData["ErrorMessage"] = String.Join(", ", result.ErrorMessages.ToArray());
			return View(newProduct);

		}

		#endregion

		#region Get Product Detail

		[HttpGet]
		public async Task<IActionResult> ProductDetail(int id)
		{
			var productAndOfferVM = new ProductAndOfferVM();
			productAndOfferVM.Product = await _productService.GetProductDetailAsync(id);
			productAndOfferVM.Offer = new NewOfferOfferViewModel();
			return View(productAndOfferVM);
		}

		#endregion

		#region BuyProduct

		[HttpGet]
		public async Task<IActionResult> BuyProduct(int id)
		{
			var result = await _productService.BuyProduct(id);

			if (result.ResponseData)
				return RedirectToAction("Index", "Home");

			var product = await _productService.GetProductDetailAsync(id);
			TempData["ErrorMessages"] = String.Join(", ", result.ErrorMessages.ToArray());
			return RedirectToAction("ProductDetail", "Products", product);
		}

		#endregion

		#region Private Helpers

		private async Task RefreshViewBagData()
		{
			var colors = await _colorService.GetAllColorsAsync();
			ViewBag.Colors = new SelectList(colors, "Id", "Name");

			var usingStatuses = await _usingStatusService.GetAllUsingStatusesAsync();
			ViewBag.UsingStatuses = new SelectList(usingStatuses, "Id", "Name");

			var brands = await _brandService.GetAllBrandsAsync();
			ViewBag.Brands = new SelectList(brands, "Id", "Name");

			var categories = await _categoryService.GetAllCategoriesAsync();
			ViewBag.Categories = new SelectList(categories, "Id", "Name");
		}
		private string GetImageUrl(NewProductViewModel newProduct) => Guid.NewGuid().ToString() + "" + newProduct.Image.FileName;
		private void SaveImage(NewProductViewModel newProduct)
		{
			string imagesFolder = Path.Combine(_webHostEnvironment.WebRootPath, "uploadedFiles/Images");

			if (newProduct.Image != null)
			{
				string filePath = Path.Combine(imagesFolder, newProduct.ImageUrl);
				using (var fileStream = new FileStream(filePath, FileMode.Create))
				{
					newProduct.Image.CopyTo(fileStream);
				}
			}
		}

		#endregion

		#region Get Products By Category Id

		[HttpGet]
		public async Task<IActionResult> GetProductsByCategoryId(int id)
		{
			//IReadOnlyList<ProductViewModel> productsByCategoryId = await _productService.GetAllProductsByCategoryIdAsync(categoryId);
			TempData["categoryId"] = id;
			return RedirectToAction("Index", "Home");
		}

		#endregion
	}
}
