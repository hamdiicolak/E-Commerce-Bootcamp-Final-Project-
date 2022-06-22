using Microsoft.AspNetCore.Mvc;
using ProductCatalog.UI.Models;
using ProductCatalog.UI.Services;

namespace ProductCatalog.UI.Controllers
{
	public class OffersController : Controller
	{
		private readonly IOfferService _offerService;

		public OffersController(IOfferService offerService)
		{
			_offerService = offerService;
		}

		#region New Offer

		[HttpPost]
		public async Task<IActionResult> NewOffer(IFormCollection fc, ProductAndOfferVM productAndOfferVM)
		{
			int productId = Convert.ToInt32(fc["productId"]);

			productAndOfferVM.Offer.ProductId = productId;

			var result = await _offerService.NewOffer(productAndOfferVM.Offer);

			if (result.ResponseData)
			{
				return RedirectToAction("Index", "Home");
			}

			TempData["ErrorMessages"] = String.Join(", ", result.ErrorMessages.ToArray());
			return RedirectToAction("ProductDetail", "Products", new { id = productId });
		}

		#endregion

		#region Approve Offer

		public async Task<IActionResult> ApproveOffer(int id)
		{
			var result = await _offerService.ApproveOffer(id);
			if (result.ResponseData)
			{
				return RedirectToAction("Index", "Home");
			}

			TempData["ErrorMessage"] = String.Join(", ", result.ErrorMessages.ToArray());
			return RedirectToAction("GetAllOfferedUserProducts", "MyAccount");
		}

		#endregion

		#region Decline Offer

		public async Task<IActionResult> DeclineOffer(int id)
		{
			var result = await _offerService.DeclineOffer(id);
			if (result.ResponseData)
			{
				return RedirectToAction("Index", "Home");
			}

			TempData["ErrorMessage"] = String.Join(", ", result.ErrorMessages.ToArray());
			return RedirectToAction("GetAllOfferedUserProducts", "MyAccount");
		}

		#endregion

	}
}
