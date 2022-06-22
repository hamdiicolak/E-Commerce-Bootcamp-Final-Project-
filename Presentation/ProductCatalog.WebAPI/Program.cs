using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using ProductCatalog.Application;
using ProductCatalog.Application.Settings.Authentication;
using ProductCatalog.Persistence;
using System.Text;

var builder = WebApplication.CreateBuilder(args);


#region Layer Service Registration

builder.Services.ConfigureInfrastructureServices(builder.Configuration);
builder.Services.ConfigureApplicationServices();

// gets JwtSettings instance which is in a json format on the appsettings.json file
// sets its to a new instance on program side
builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("JWT"));
var jwt = builder.Configuration.GetSection("JWT").Get<JwtSettings>();

#endregion



// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// Swagger 
builder.Services.AddSwaggerGen(options =>
{
	options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
	{
		Name = "JWT Authentication",
		Description = "Jwt Bearer Token **_only_**",
		In = ParameterLocation.Header,
		Type = SecuritySchemeType.Http,
		Scheme = "bearer",
		BearerFormat = "JWT",
		Reference = new OpenApiReference
		{
			Id = JwtBearerDefaults.AuthenticationScheme,
			Type = ReferenceType.SecurityScheme
		},
	});

	var security =
		new OpenApiSecurityRequirement
		{
			{
				new OpenApiSecurityScheme
				{
					Reference = new OpenApiReference
					{
						Id = "Bearer",
						Type = ReferenceType.SecurityScheme
					},
					UnresolvedReference = true
				},
				new List<string>()
			}
		};
	options.AddSecurityRequirement(security);
});

builder.Services
	.AddAuthentication(options =>
	{
		options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
		options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
		options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
	})
	.AddJwtBearer(options =>
	{
		options.RequireHttpsMetadata = false;
		options.TokenValidationParameters = new TokenValidationParameters
		{
			ValidIssuer = jwt.Issuer,
			ValidAudience = jwt.Issuer,
			IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.Secret)),
			ClockSkew = TimeSpan.Zero
		};
	});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
