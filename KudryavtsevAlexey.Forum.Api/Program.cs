using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;
using Microsoft.Extensions.DependencyInjection;
using Serilog.Events;
using KudryavtsevAlexey.Forum.Api;

public partial class Program
{
	public static async Task Main(string[] args)
	{
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

		await host.RunAsync();

		static IHostBuilder CreateHostBuilder(string[] args) =>
			Host.CreateDefaultBuilder(args)
				.UseSerilog()
				.ConfigureWebHostDefaults(webBuilder =>
				{
					webBuilder.UseStartup<Startup>();
				});
	}
}