using System;
using System.IdentityModel.Tokens.Jwt;
using KudryavtsevAlexey.Forum.Infrastructure.Database;
using KudryavtsevAlexey.Forum.IntegrationTests.DataHelpers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.IdentityModel.Tokens;
using WebMotions.Fake.Authentication.JwtBearer;

namespace KudryavtsevAlexey.Forum.IntegrationTests.WebApplicationFactory
{
	public class CustomWebApplicationFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
	{
		protected override void ConfigureWebHost(IWebHostBuilder builder)
		{
			builder.UseEnvironment("Testing");

			builder.ConfigureServices(services =>
			{
				var serviceProvider = new ServiceCollection()
					.AddEntityFrameworkInMemoryDatabase()
					.BuildServiceProvider();

				var sp = services.BuildServiceProvider();

				using (var scope = sp.CreateScope())
				{
					var scopedServices = scope.ServiceProvider;

					var dbContext = scopedServices.GetRequiredService<ForumDbContext>();

					var logger = scopedServices.GetRequiredService<ILogger<WebApplicationFactory<TStartup>>>();

					dbContext.Database.EnsureDeleted();
					dbContext.Database.EnsureCreated();

					try
					{
						services.InitializeTestingDatabase(dbContext);
					}
					catch (Exception ex)
					{
						logger.LogError(ex,
							$"An error occurred seeding the database with test messages. Error: {ex.Message}");
					}
				}
				base.ConfigureWebHost(builder);
			});
		}
	}
}
