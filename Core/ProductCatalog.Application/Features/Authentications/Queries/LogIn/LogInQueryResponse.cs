namespace ProductCatalog.Application.Features.Authentications.Queries.LogIn
{
	public class LogInQueryResponse
	{
		public int Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		public string Token { get; set; }
	}
}
