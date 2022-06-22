using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ProductCatalog.UI.Enums;
using ProductCatalog.UI.Extensions;
using ProductCatalog.UI.Models;
using ProductCatalog.UI.Services;

namespace ProductCatalog.UI.Controllers
{
	public class AuthController : Controller
	{
		private readonly IAuthService _authService;

		public AuthController(IAuthService authService)
		{
			_authService = authService;
		}

		#region Log In

		[HttpGet]
		public async Task<IActionResult> LogIn()
		{
			if (HttpContext.HasCookie("Authorization"))
			{
				//Kullanıcı daha önce giriş yapmış ise yapılacak işlemler
				return RedirectToAction("Index", "Home");
			}

			return View();
		}

		[HttpPost]
		public async Task<IActionResult> LogIn(LogInViewModel user)
		{
			if (ModelState.IsValid == false)
			{
				return View(user).ShowMessage(Status.BadRequest, "Uyarı", "Eksik veya hatalı bilgiler mevcut!");
			}

			var response = await _authService.LogIn(user);
			var result = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
			var responseData = JsonConvert.DeserializeObject<ServiceResponse<LogInResponseViewModel>>(result);

			if (response.IsSuccessStatusCode)
			{
				HttpContext.SetCookie("Authorization", result, TimeSpan.FromDays(1));
				return RedirectToAction("Index", "Home");
			}

			TempData["ErrorMessages"] = String.Join(", ", responseData.ErrorMessages.ToArray());
			return View(user);
		}

		#endregion

		#region Sign Up

		[HttpGet]
		public async Task<IActionResult> SignUp()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> SignUp(SignUpViewModel newUser)
		{
			if (ModelState.IsValid == false)
			{
				return View(newUser).ShowMessage(Status.BadRequest, "Uyarı", "Eksik veya hatalı bilgiler mevcut!");
			}

			var result = await _authService.SignUp(newUser);

			if (result.ResponseData)
			{
				return RedirectToAction("Index", "Home");
			}

			return View(newUser);
		}

		#endregion

		#region Log Out

		public IActionResult LogOut()
		{
			HttpContext.DeleteCookie("Authorization");
			return RedirectToAction("Index", "Home");
		}

		#endregion
	}
}
