using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;
using KudryavtsevAlexey.Forum.Infrastructure.Helpers;
using Microsoft.Extensions.DependencyInjection;
using Serilog.Events;
using KudryavtsevAlexey.Forum.Api;

var configuration = new ConfigurationBuilder()
	.AddJsonFile("appsettings.json")
	.Build();

Log.Logger = new LoggerConfiguration()
	.ReadFrom.Configuration(configuration)
	.MinimumLevel.Verbose()
	.MinimumLevel.Override("System", LogEventLevel.Warning)
	.MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
	.Enrich.FromLogContext()
	.WriteTo.Console()
	.WriteTo.File("Logs.txt")
	.CreateLogger();

Log.Information("Application starting up");
var host = CreateHostBuilder(args).Build();

using (var scope = host.Services.CreateScope())
{
	await scope.ServiceProvider.DatabaseMigrate();
}

await host.RunAsync();

static IHostBuilder CreateHostBuilder(string[] args) =>
	Host.CreateDefaultBuilder(args)
		.UseSerilog()
		.ConfigureWebHostDefaults(webBuilder =>
		{
			webBuilder.UseStartup<Startup>();
		});
