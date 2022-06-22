using Microsoft.AspNetCore.Mvc;
using ProductCatalog.UI.Models;
using ProductCatalog.UI.Services;

namespace ProductCatalog.UI.Controllers
{
	public class MyAccountController : Controller
	{
		private readonly IMyAccountService _myAccountService;
		private readonly IOfferService _offerService;
		private readonly IAuthService _authService;

		public MyAccountController(IMyAccountService myAccountService, IProductService productService, IOfferService offerService, IAuthService authService)
		{
			_myAccountService = myAccountService;
			_offerService = offerService;
			_authService = authService;
		}

		#region Get All User Products

		[HttpGet]
		public async Task<IActionResult> Index()
		{
			var product = await _myAccountService.GetAllUserProductsAsync();
			return View(product);
		}

		#endregion

		#region Get All Offered User Products

		public async Task<IActionResult> GetAllOfferedUserProducts()
		{
			UserProductAndOfferVM userProductsAndAllOffers = new();
			userProductsAndAllOffers.Products = await _myAccountService.GetAllOfferedUserProducts();
			var response = await _authService.GetLoggedInUserId();
			userProductsAndAllOffers.LoggedInUserId = response.LoggedInUserId;
			userProductsAndAllOffers.Offers = await _offerService.GetAllOffers();

			return View(userProductsAndAllOffers);
		}

		#endregion

		#region Get All Products Offered ByUser

		public async Task<IActionResult> GetAllProductsOfferedByUser()
		{
			UserProductAndOfferVM userProductsAndAllOffers = new();
			userProductsAndAllOffers.Products = await _myAccountService.GetAllProductsOfferedByUser();
			var response = await _authService.GetLoggedInUserId();
			userProductsAndAllOffers.LoggedInUserId = response.LoggedInUserId;
			userProductsAndAllOffers.Offers = await _offerService.GetAllOffers();

			return View(userProductsAndAllOffers);
		}

		#endregion

		

		#region Get User Product Detail

		[HttpGet("userproduct/id")]
		public async Task<IActionResult> UserProductDetail(int id)
		{
			var product = await _myAccountService.GetUserProductDetailAsync(id);
			return View(product);
		}

		#endregion

	}
}
