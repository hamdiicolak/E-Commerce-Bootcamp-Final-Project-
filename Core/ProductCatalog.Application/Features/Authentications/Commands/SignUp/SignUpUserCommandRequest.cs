using MediatR;
using ProductCatalog.Application.ServiceResponses;

namespace ProductCatalog.Application.Features.Authentications.Commands.SignUp
{
	public class SignUpUserCommandRequest : IRequest<ServiceResponse<bool>>
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string UserName { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
	}
}
