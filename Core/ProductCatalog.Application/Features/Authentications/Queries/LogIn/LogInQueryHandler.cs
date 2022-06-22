using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using ProductCatalog.Application.ServiceResponses;
using ProductCatalog.Domain.Entities;

namespace ProductCatalog.Application.Features.Authentications.Queries.LogIn
{
	public class LogInQueryHandler : IRequestHandler<LogInQueryRequest, ServiceResponse<LogInQueryResponse>>
	{
		private readonly UserManager<User> _userManager;
		private readonly IMapper _mapper;

		public LogInQueryHandler(UserManager<User> userManager, IMapper mapper)
		{
			_mapper = mapper;
			_userManager = userManager;
		}

		public async Task<ServiceResponse<LogInQueryResponse>> Handle(LogInQueryRequest request, CancellationToken cancellationToken)
		{
			var validator = new LogInQueryValidator();
			var validationResult = await validator.ValidateAsync(request);

			if (!validationResult.IsValid)
			{
				var response = new ServiceResponse<LogInQueryResponse>(validationResult.Errors.Select(q => q.ErrorMessage).ToList(), null);
				return response;
			}
			var user = _userManager.Users.SingleOrDefault(u => u.Email == request.Email);
			var userModel = _mapper.Map<LogInQueryResponse>(user);
			var userLoginResult = await _userManager.CheckPasswordAsync(user, request.Password);
			var serviceResponse = new ServiceResponse<LogInQueryResponse>(new List<string>(), null);
			if (userLoginResult)
			{
				serviceResponse.ResponseData = userModel;
				return serviceResponse;
			}

			serviceResponse.ErrorMessages.Add("'Kullanıcı adı' veya 'Şifre' hatalı!");
			return serviceResponse;
		}
	}
}
