using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Extensions.DependencyInjection.Extensions;
using ProductCatalog.UI.Extensions;
using ProductCatalog.UI.Services;
using ProductCatalog.UI.Validation;

var builder = WebApplication.CreateBuilder(args);
var provider = builder.Services.BuildServiceProvider();
var configuration = provider.GetRequiredService<IConfiguration>();


// Add services to the container.

builder.Services.AddUIServices(configuration);
//builder.Services.AddValidators();

builder.Services.AddControllersWithViews().AddFluentValidation(
                opt =>
                {
                    opt.RegisterValidatorsFromAssemblyContaining(typeof(Program));
                });

var app = builder.Build();

ActionResultExtension.Configure(app.Services.GetRequiredService<IHttpContextAccessor>(),
app.Services.GetRequiredService<ITempDataDictionaryFactory>());

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
