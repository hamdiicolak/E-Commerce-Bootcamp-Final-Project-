using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace ProductCatalog.Application
{
	public static class ApplicationServicesRegistration
	{
		public static IServiceCollection ConfigureApplicationServices(this IServiceCollection services)
		{
			// => FluentValidation, AutoMapper, MediatR
			services.AddAutoMapper(Assembly.GetExecutingAssembly());
			services.AddMediatR(Assembly.GetExecutingAssembly());
			services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

			return services;
		}
	}
}
