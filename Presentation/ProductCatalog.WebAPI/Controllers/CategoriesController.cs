using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductCatalog.Application.Features.Categories.Queries.GetAllCategories;
using ProductCatalog.Application.Features.Categories.Queries.GetCategory;
using ProductCatalog.Application.ServiceResponses;

namespace ProductCatalog.WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CategoriesController(IMediator mediator) 
        {
            _mediator = mediator; 
        }

        #region Get All Categories

        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
            => Ok(await _mediator.Send(new GetAllCategoriesQueryRequest()));

        #endregion

        #region Get Category By Id

        [HttpGet("{id}")]
        public async Task<ServiceResponse<GetCategoryQueryResponse>> GetCategoryById(int id)
            => await _mediator.Send(new GetCategoryQueryRequest { Id = id });

        #endregion
    }
}
