using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProductCatalog.Application.Features.Products.Commands.BuyProduct;
using ProductCatalog.Application.Features.Products.Commands.New_Product;
using ProductCatalog.Application.Features.Products.Queries.GetAllProduct;
using ProductCatalog.Application.Features.Products.Queries.GetAllProductsByCategory;
using ProductCatalog.Application.Features.Products.Queries.GetProduct;
using ProductCatalog.Application.ServiceResponses;
using ProductCatalog.Domain.Entities;

namespace ProductCatalog.WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly UserManager<User> _userManager;

		public ProductsController(IMediator mediator, UserManager<User> userManager)
		{
			_mediator = mediator;
            _userManager = userManager;
		}

		#region Get All Products

		[HttpGet]
        public async Task<IActionResult> GetAllProducts()
		{
            var temp = await _mediator.Send(new GetAllProductsQueryRequest());
            return Ok(temp);
        }

        #endregion

        #region Get Product By Id

        [HttpGet("{id}")]
        public async Task<ServiceResponse<GetProductQueryResponse>> GetProductById(int id) => await _mediator.Send(new GetProductQueryRequest { Id = id });

        #endregion

        #region Buy Product

        [Authorize]
        [HttpPut("{id}")]
        public async Task<ServiceResponse<bool>> BuyProduct(int id)
        {
            ServiceResponse<bool> response = await _mediator.Send(new BuyProductCommandRequest() { Id = id });
            return response;
        }

		#endregion

		#region Add New Product


		[Authorize]
        [HttpPost]
        public async Task<IActionResult> NewProduct(NewProductCommandRequest newProduct)
        {
            var userId = _userManager.Users.FirstOrDefault(x => x.Email == HttpContext.User.Identity.Name).Id;
            newProduct.UserId = userId;
            newProduct.IsOfferable = true;
            newProduct.IsSold = false;

            ServiceResponse<bool> response = await _mediator.Send(newProduct);
            if (response.ResponseData)
                return Ok(response);

            return BadRequest(response);
        }

        #endregion

        #region Get Products By Category Id

        [HttpGet("ByCategory/{categroyId}")]
        public async Task<IActionResult> GetAllProducts(int categroyId)
        {
            var temp = await _mediator.Send(new GetAllProductsByCategoryIdQueryRequest() { CategoryId = categroyId });
            return Ok(temp);
        }

        #endregion

    }
}
