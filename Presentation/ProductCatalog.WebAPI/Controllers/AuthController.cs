using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ProductCatalog.Application.Features.Authentications.Commands.SignUp;
using ProductCatalog.Application.Features.Authentications.Queries.GetUserId;
using ProductCatalog.Application.Features.Authentications.Queries.LogIn;
using ProductCatalog.Application.ServiceResponses;
using ProductCatalog.Application.Settings.Authentication;
using ProductCatalog.Domain.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ProductCatalog.WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthController : ControllerBase
	{
		private readonly IMediator _mediator;
		private readonly UserManager<User> _userManager;
		private readonly JwtSettings _jwtSettings;

		public AuthController(IMediator mediator, IOptionsSnapshot<JwtSettings> jwtSettings, UserManager<User> userManager)
		{
			_mediator = mediator;
			_jwtSettings = jwtSettings.Value;
			_userManager = userManager;
		}

		#region Sign Up

		[HttpPost("SignUp")]
		public async Task<IActionResult> SignUp(SignUpUserCommandRequest signUpUserCommandRequest)
		{
			ServiceResponse<bool> response = await _mediator.Send(signUpUserCommandRequest);
			if (response.ResponseData)
				return Ok(response);

			return BadRequest(response);
		}

		#endregion

		#region Log In

		[HttpPost("LogIn")]
		public async Task<IActionResult> LogIn(string email, string password)
		{
			var query = new LogInQueryRequest(email, password);
			var userModel = await _mediator.Send(query);

			if (userModel.ResponseData != null)
			{
				userModel.ResponseData.Token = GenerateJwt(userModel.ResponseData);

				var response = new ServiceResponse<LogInQueryResponse>(new List<string>(), userModel.ResponseData);
				return Ok(response);
			}
			return BadRequest(new ServiceResponse<LogInQueryResponse>(userModel.ErrorMessages, userModel.ResponseData));
		}

		#endregion

		#region Get Logged In User Id

		[Authorize]
		[HttpGet("GetLoggedInUserId")]
		public async Task<IActionResult> GetLoggedInUserId()
		{
			var loggedInUserId = _userManager.Users.FirstOrDefault(x => x.Email == HttpContext.User.Identity.Name).Id;

			return Ok(await _mediator.Send(new GetLoggedInUserIdQueryRequest() { LoggedInUserId = loggedInUserId }));
		}

		#endregion



		#region JWT Generator

		private string GenerateJwt(LogInQueryResponse userModel)
		{
			var claims = new List<Claim>
				{
					new Claim(JwtRegisteredClaimNames.Sub, userModel.Id.ToString()),
					new Claim(ClaimTypes.Name, userModel.Email),
					new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
					new Claim(ClaimTypes.NameIdentifier, userModel.Id.ToString())
				};
			var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Secret));
			var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
			var expires = DateTime.Now.AddDays(Convert.ToDouble(_jwtSettings.ExpirationInDays));

			var token = new JwtSecurityToken(
				issuer: _jwtSettings.Issuer,
				audience: _jwtSettings.Issuer,
				claims,
				expires: expires,
				signingCredentials: creds
			);

			return new JwtSecurityTokenHandler().WriteToken(token);
		}

		#endregion
	}
}
