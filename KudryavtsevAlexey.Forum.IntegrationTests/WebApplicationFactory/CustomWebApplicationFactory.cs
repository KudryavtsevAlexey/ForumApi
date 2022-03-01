using System;
using KudryavtsevAlexey.Forum.Infrastructure.Database;
using KudryavtsevAlexey.Forum.IntegrationTests.DataHelpers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

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
