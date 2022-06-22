using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProductCatalog.Application.Features.Products.Queries.GetAllOfferedUserProducts;
using ProductCatalog.Application.Features.Products.Queries.GetAllProductsOfferedByUser;
using ProductCatalog.Application.Features.Products.Queries.GetUserProducts;
using ProductCatalog.Application.ServiceResponses;
using ProductCatalog.Domain.Entities;

namespace ProductCatalog.WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MyAccountController : ControllerBase
	{
		private readonly IMediator _mediator;
		private readonly UserManager<User> _userManager;

		public MyAccountController(IMediator mediator, UserManager<User> userManager)
		{
			_mediator = mediator; 
			_userManager = userManager;
		}

		#region Get All User Products

		[Authorize]
		[HttpGet]
		public async Task<ServiceResponse<IReadOnlyList<GetAllUserProductsQueryResponse>>> GetAllUserProducts()
		{
			var userId = _userManager.Users.FirstOrDefault(x => x.Email == HttpContext.User.Identity.Name).Id;
			return await _mediator.Send(new GetUserProductsQueryRequest { UserId = userId });
		}

		#endregion

		#region Get All Offered User Products

		[Authorize]
		[HttpGet("MyOfferedProducts")]
		public async Task<ServiceResponse<IReadOnlyList<GetAllOfferedUserProductsQueryResponse>>> GetAllOfferedUserProducts()
		{
			var userId = _userManager.Users.FirstOrDefault(x => x.Email == HttpContext.User.Identity.Name).Id;
			var allOfferedUserProducts = await _mediator.Send(new GetAllOfferedUserProductsQueryRequest { UserId = userId });
			return allOfferedUserProducts;
		}

		#endregion

		#region Get All Products Offered ByUser

		[Authorize]
		[HttpGet("MyOffers")]
		public async Task<ServiceResponse<IReadOnlyList<GetAllProductsOfferedByUserQueryResponse>>> GetAllProductsOfferedByUser()
		{
			var userId = _userManager.Users.FirstOrDefault(x => x.Email == HttpContext.User.Identity.Name).Id;
			var allProductsOfferedByUser = await _mediator.Send(new GetAllProductsOfferedByUserQueryRequest { UserId = userId });
			return allProductsOfferedByUser;
		}

		#endregion

		

	}
}
