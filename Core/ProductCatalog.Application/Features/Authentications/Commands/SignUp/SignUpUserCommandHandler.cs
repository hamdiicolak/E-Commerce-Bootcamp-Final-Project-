using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using ProductCatalog.Application.ServiceResponses;
using ProductCatalog.Domain.Entities;

namespace ProductCatalog.Application.Features.Authentications.Commands.SignUp
{
	public class SignUpUserCommandHandler : IRequestHandler<SignUpUserCommandRequest, ServiceResponse<bool>>
	{
		private readonly UserManager<User> _userManager;
		private readonly IMapper _mapper;

		public SignUpUserCommandHandler(UserManager<User> userManager, IMapper mapper)
		{
			_userManager = userManager;
			_mapper = mapper;
		}

		public async Task<ServiceResponse<bool>> Handle(SignUpUserCommandRequest request, CancellationToken cancellationToken)
		{
			SignUpUserCommandValidator validationRules = new();
			var response = new ServiceResponse<bool>(new List<string>(), false);
			var validationResult = await validationRules.ValidateAsync(request);

			// Fluent Validation Errors
			if (!validationResult.IsValid)
			{
				response.ErrorMessages = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
				return response;
			}
			var userEntity = _mapper.Map<User>(request);

			// Library Errors
			IdentityResult result = await _userManager.CreateAsync(userEntity, request.Password);
			if (result.Succeeded)
			{
				response.ResponseData = true;
				return response;
			}
			else
			{
				foreach (var error in result.Errors)
					response.ErrorMessages.Add(error.Description + "\n");
			}
			return response;
		}
	}
}
