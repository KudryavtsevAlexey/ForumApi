using System.Text;
using FluentValidation.AspNetCore;
using KudryavtsevAlexey.Forum.Api.Middlewares;
using KudryavtsevAlexey.Forum.Domain.Entities;
using KudryavtsevAlexey.Forum.Infrastructure.Database;
using KudryavtsevAlexey.Forum.Services.Profiles;
using KudryavtsevAlexey.Forum.Services.ServiceManager;
using KudryavtsevAlexey.Forum.Services.Validation.Article;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Serilog;
using WebMotions.Fake.Authentication.JwtBearer;
using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;

namespace KudryavtsevAlexey.Forum.Api
{
	public class Startup
	{
		public Startup(IConfiguration configuration, IWebHostEnvironment env)
		{
			Configuration = configuration;
			Environment = env;
		}

		public IConfiguration Configuration { get; }
		public IWebHostEnvironment Environment { get; }

		public void ConfigureServices(IServiceCollection services)
		{
			AddDatabaseByEnvironment(services);

			services.AddIdentity<ApplicationUser, IdentityRole<int>>(config =>
			{
				config.Password.RequireDigit = true;
				config.Password.RequireLowercase = true;
				config.Password.RequireNonAlphanumeric = false;
				config.Password.RequireUppercase = true;
				config.Password.RequiredLength = 6;
			})
			.AddEntityFrameworkStores<ForumDbContext>()
			.AddDefaultTokenProviders();

			AddAuthenticationByEnvironment(services);

			IdentityModelEventSource.ShowPII = true;

			services.AddAutoMapper(typeof(MappingProfile));

			services.AddSwaggerGen(config =>
			{
				config.SwaggerDoc("v1", new OpenApiInfo {Title = "ForumApi", Version = "v1"});
			});

			services.AddAuthorization(config =>
			{
				config.AddPolicy("Bearer", new AuthorizationPolicyBuilder()
					.AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
					.RequireAuthenticatedUser().Build());
			});

			services.AddControllers()
				.AddFluentValidation(fv =>
					fv.RegisterValidatorsFromAssemblyContaining<CreateArticleDtoValidator>())
				.AddNewtonsoftJson(options =>
					options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

			services.AddScoped<IServiceManager, ServiceManager>();

			services.AddTransient<ExceptionHandlingMiddleware>();
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseHttpsRedirection();

			app.UseSerilogRequestLogging();

			app.UseRouting();

			app.UseAuthentication();

			app.UseAuthorization();

			app.UseMiddleware<ExceptionHandlingMiddleware>();

			app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
		}

		private void AddDatabaseByEnvironment(IServiceCollection services)
		{
			if (Environment.IsEnvironment("Testing"))
			{
				services.AddDbContext<ForumDbContext>(options =>
					options.UseInMemoryDatabase("TestingForumDb"));
			}
			else
			{
				services.AddDbContext<ForumDbContext>(options =>
					options.UseSqlServer(Configuration.GetConnectionString("ForumDb")));
			}
		}

		private void AddAuthenticationByEnvironment(IServiceCollection services)
		{
			if (Environment.IsEnvironment("Testing"))
			{
				services.AddAuthentication(FakeJwtBearerDefaults.AuthenticationScheme).AddFakeJwtBearer();
			}
			else
			{
				services.AddAuthentication(config =>
				{
					config.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
					config.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
				})
				.AddJwtBearer("Bearer", config =>
				{
					config.RequireHttpsMetadata = false;
					config.SaveToken = true;
					config.TokenValidationParameters = new TokenValidationParameters()
					{
						ValidateIssuer = true,
						ValidateAudience = true,
						ValidateIssuerSigningKey = true,
						ValidIssuer = Configuration["Authentication:JwtBearer:Issuer"],
						ValidAudience = Configuration["Authentication:JwtBearer:Audience"],
						IssuerSigningKey =
							new SymmetricSecurityKey(
								Encoding.UTF8.GetBytes(Configuration["Authentication:JwtBearer:SecretKey"])),
					};
				});
			}
		}
	}
}
