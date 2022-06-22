using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProductCatalog.Application.Features.UsingStatuses;
using ProductCatalog.Application.ServiceResponses;

namespace ProductCatalog.WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UsingStatusesController : ControllerBase
	{
		private readonly IMediator _mediator;

		public UsingStatusesController(IMediator mediator)
		{
			_mediator = mediator;
		}

		#region Get All UsingStatuses

		[HttpGet]
		public async Task<IActionResult> GetAllUsingStatuses()
			=> Ok(await _mediator.Send(new GetAllUsingStatusesQueryRequest()));

		#endregion

		#region Get UsingStatus By Id

		[HttpGet("{id}")]
		public async Task<ServiceResponse<GetUsingStatusQueryResponse>> GetUsingStatusById(int id)
			=> await _mediator.Send(new GetUsingStatusQueryRequest { Id = id });

		#endregion
	}
}
