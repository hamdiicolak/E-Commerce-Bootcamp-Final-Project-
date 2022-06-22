using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProductCatalog.Application.Features.Brands;
using ProductCatalog.Application.ServiceResponses;

namespace ProductCatalog.WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BrandsController : ControllerBase
	{
        private readonly IMediator _mediator;

		public BrandsController(IMediator mediator)
		{
			_mediator = mediator;
		}


		#region Get All Brands

		[HttpGet]
        public async Task<IActionResult> GetAllBrands()
            => Ok(await _mediator.Send(new GetAllBrandsQueryRequest()));

        #endregion

        #region Get Brand By Id

        [HttpGet("{id}")]
        public async Task<ServiceResponse<GetBrandQueryResponse>> GetBrandById(int id)
            => await _mediator.Send(new GetBrandQueryRequest { Id = id });

        #endregion
    }
}
