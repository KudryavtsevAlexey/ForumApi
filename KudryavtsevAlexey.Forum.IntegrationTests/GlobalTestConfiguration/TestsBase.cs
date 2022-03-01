using AutoMapper;
using KudryavtsevAlexey.Forum.Api;
using KudryavtsevAlexey.Forum.Infrastructure.Database;
using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Net.Http;
using Microsoft.Extensions.DependencyInjection;

namespace KudryavtsevAlexey.Forum.IntegrationTests.GlobalTestConfiguration
{
	public abstract class TestsBase : IDisposable
	{
		protected readonly WebApplicationFactory<Startup> _factory;
		protected readonly HttpClient _client;
		protected readonly ForumDbContext _dbContext;
		protected readonly IMapper _mapper;

		protected TestsBase(WebApplicationFactory<Startup> factory)
		{
			_factory = factory;
			_client = _factory.CreateClient(new WebApplicationFactoryClientOptions()
			{
				AllowAutoRedirect = false
			});

			_dbContext = _factory.Services.GetRequiredService<ForumDbContext>();
			_mapper = _factory.Services.GetRequiredService<IMapper>();
		}

		public void Dispose()
		{
			// Every test
		}
	}
}
