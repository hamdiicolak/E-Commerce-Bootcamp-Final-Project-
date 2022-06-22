using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProductCatalog.Application.Features.Colors;
using ProductCatalog.Application.ServiceResponses;

namespace ProductCatalog.WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ColorsController : ControllerBase
	{
		private readonly IMediator _mediator;

		public ColorsController(IMediator mediator)
		{
			_mediator = mediator;
		}

		#region Get All Colors

		[HttpGet]
		public async Task<IActionResult> GetAllColors()
			=> Ok(await _mediator.Send(new GetAllColorsQueryRequest()));

		#endregion

		#region Get Brand By Id

		[HttpGet("{id}")]
		public async Task<ServiceResponse<GetColorQueryResponse>> GetColorById(int id)
			=> await _mediator.Send(new GetColorQueryRequest { Id = id });

		#endregion

	}
}
