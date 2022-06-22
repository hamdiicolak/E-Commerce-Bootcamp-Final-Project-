using MediatR;
using ProductCatalog.Application.ServiceResponses;

namespace ProductCatalog.Application.Features.Authentications.Queries.LogIn
{
	public class LogInQueryRequest : IRequest<ServiceResponse<LogInQueryResponse>>
	{
		public string Email { get; set; }
		public string Password { get; set; }

		public LogInQueryRequest(string email, string password)
		{
			Email = email ?? throw new ArgumentNullException(nameof(email));
			Password = password ?? throw new ArgumentNullException(nameof(password));
		}
	}
}
