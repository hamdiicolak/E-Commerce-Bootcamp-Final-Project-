using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProductCatalog.Application.Features;
using ProductCatalog.Application.Features.Categories.Queries.GetAllOffers;
using ProductCatalog.Application.Features.Offers.Commands.ApproveOffer;
using ProductCatalog.Application.Features.Offers.Commands.DeclineOffer;
using ProductCatalog.Application.ServiceResponses;
using ProductCatalog.Domain.Entities;

namespace ProductCatalog.WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class OffersController : ControllerBase
	{
		private readonly IMediator _mediator;
		private readonly UserManager<User> _userManager;

		public OffersController(IMediator mediator, UserManager<User> userManager)
		{
			_mediator = mediator;
			_userManager = userManager;
		}

		#region Get All Offers

		[Authorize]
		[HttpGet]
		public async Task<IActionResult> GetAllOffers()
			=> Ok(await _mediator.Send(new GetAllOffersQueryRequest()));

		#endregion

		#region New Offer

		[Authorize]
		[HttpPost]
		public async Task<IActionResult> NewOffer(NewOfferCommandRequest newOffer)
		{
			var userId = _userManager.Users.FirstOrDefault(x => x.Email == HttpContext.User.Identity.Name).Id;
			newOffer.UserId = userId;

			ServiceResponse<bool> response = await _mediator.Send(newOffer);
			if (response.ResponseData)
				return Ok(response);

			return BadRequest(response);
		}

		#endregion

		#region Approve Offer

		[Authorize]
		[HttpPut("ApproveOffer/{id}")]
		public async Task<IActionResult> ApproveOffer(int id)
		{
			ServiceResponse<bool> response = await _mediator.Send(new ApproveOfferCommandRequest() { OfferId = id});
			if (response.ResponseData)
				return Ok(response);

			return BadRequest(response);
		}

		#endregion

		#region Decline Offer

		[Authorize]
		[HttpDelete("DeclineOffer/{id}")]
		public async Task<IActionResult> DeclineOffer(int id)
		{
			ServiceResponse<bool> response = await _mediator.Send(new DeclineOfferCommandRequest() { OfferId = id});
			if (response.ResponseData)
				return Ok(response);

			return BadRequest(response);
		}

		#endregion



	}
}
