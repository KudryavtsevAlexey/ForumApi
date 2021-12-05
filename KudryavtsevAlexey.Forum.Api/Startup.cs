using System.Text;
using KudryavtsevAlexey.Forum.Api.Middlewares;
using KudryavtsevAlexey.Forum.Domain.Entities;
using KudryavtsevAlexey.Forum.Infrastructure.Database;
using KudryavtsevAlexey.Forum.Services.Profiles;
using KudryavtsevAlexey.Forum.Services.ServiceManager;
using KudryavtsevAlexey.Forum.Services.ServicesAbstractions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Serilog;

namespace KudryavtsevAlexey.Forum.Api
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		public void ConfigureServices(IServiceCollection services)
        {
			services.AddDbContext<ForumDbContext>(config =>
                config.UseSqlServer(Configuration.GetConnectionString("ForumDb")));

            services.AddAuthentication(config =>
            {
                config.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                config.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                config.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer("OAuthJwt", config =>
            {
                config.SaveToken = true;
				config.TokenValidationParameters = new TokenValidationParameters()
				{
					ValidateIssuer = true,
					ValidateAudience = true,
                    ValidIssuer = Configuration["Authentication:JwtBearer:Issuer"],
                    ValidAudience = Configuration["Authentication:JwtBearer:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Authentication:JwtBearer:SecretKey"])),
                };
            });

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

            services.AddAutoMapper(typeof(MappingProfile));

            services.AddSwaggerGen(config =>
			{
				config.SwaggerDoc("v1", new OpenApiInfo { Title = "ForumApi", Version = "v1" });
            });

			services.AddControllers()
                .AddNewtonsoftJson(options=>
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

			//TODO: ExceptionHandlingMiddleware

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
