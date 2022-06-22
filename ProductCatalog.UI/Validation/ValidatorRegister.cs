using FluentValidation.AspNetCore;

namespace ProductCatalog.UI.Validation
{
	public static class ValidatorRegister
	{
		public static void AddValidators(this IServiceCollection services)
		{
			services.AddControllersWithViews().AddFluentValidation(
				a => a.RegisterValidatorsFromAssemblyContaining<LogInValidator>());

			services.AddControllersWithViews().AddFluentValidation(
				a => a.RegisterValidatorsFromAssemblyContaining<SignUpValidator>());

			services.AddControllersWithViews().AddFluentValidation(
				a => a.RegisterValidatorsFromAssemblyContaining<NewProductValidator>());

		}
	}
}
