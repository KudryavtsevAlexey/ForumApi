using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using KudryavtsevAlexey.Forum.Api;
using KudryavtsevAlexey.Forum.Infrastructure.Database;
using KudryavtsevAlexey.Forum.IntegrationTests.DtoHelpers;
using KudryavtsevAlexey.Forum.IntegrationTests.Extensions;
using KudryavtsevAlexey.Forum.IntegrationTests.WebApplicationFactory;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace KudryavtsevAlexey.Forum.IntegrationTests.SequenceTesting
{
	public class FullCycleTest : IClassFixture<CustomWebApplicationFactory<Startup>>
	{
		private const string CreateTagUrl = "api/tag/create";
		private const string CreateArticleUrl = "api/article/create";
		private const string CreateListingUrl = "api/listing/create";
		private const string CreateArticleMainCommentUrl = "api/comment/article-comment/create";
		private const string CreateArticleSubCommentUrl = "api/comment/article-subcomment/create";
		private const string CreateListingMainCommentUrl = "api/comment/listing-comment/create";
		private const string CreateListingSubCommentUrl = "api/comment/listing-subcomment/create";
		private readonly CustomWebApplicationFactory<Startup> _factory;
		private readonly HttpClient _client;
		private readonly ForumDbContext _dbContext;
		private readonly IMapper _mapper;
		private readonly DtoGenerator _dtoGenerator;

		public FullCycleTest(CustomWebApplicationFactory<Startup> factory)
		{
			_factory = factory;
			_client = _factory.CreateClient(new WebApplicationFactoryClientOptions()
			{
				AllowAutoRedirect = false
			});

			_dbContext = _factory.Services.GetRequiredService<ForumDbContext>();
			_mapper = _factory.Services.GetRequiredService<IMapper>();
			_dtoGenerator = new DtoGenerator(_dbContext, _mapper);
		}

		[Fact]
		public async Task FullCycle()
		{
			// arrange
			await _client.Register();

			var userId = _dbContext.Users.Last().Id;
			var articleId = _dbContext.Articles.Last().Id + 1;
			var listingId = _dbContext.Listings.Last().Id + 1;
			var articleMainCommentId = _dbContext.ArticleMainComments.Last().Id + 1;
			var listingMainCommentId = _dbContext.ListingMainComments.Last().Id + 1;

			var createTagDto = _dtoGenerator.GetCreateTagDto();
			var createArticleDto = _dtoGenerator.GetCreateArticleDto();
			var createListingDto = _dtoGenerator.GetCreateListingDto();
			var createArticleMainCommentDto = _dtoGenerator.GetCreateArticleMainCommentDto();
			var createArticleSubCommentDto = _dtoGenerator.GetCreateArticleSubCommentDto(userId, articleId, articleMainCommentId);
			var createListingMainCommentDto = _dtoGenerator.GetCreateListingMainCommentDto(userId, listingId);
			var createListingSubCommentDto = _dtoGenerator.GetCreateListingSubCommentDto(userId, listingId, listingMainCommentId);

			// TODO: Json
			var createTagJson = JsonGenerator.GetStringContent(createTagDto);
			var createArticleJson = JsonGenerator.GetStringContent(createArticleDto);
			var createListingJson = JsonGenerator.GetStringContent(createListingDto);
			var createArticleMainCommentJson = JsonGenerator.GetStringContent(createArticleMainCommentDto);
			var createArticleSubCommentJson = JsonGenerator.GetStringContent(createArticleSubCommentDto);
			var createListingMainCommentJson = JsonGenerator.GetStringContent(createListingMainCommentDto);
			var createListingSubCommentJson = JsonGenerator.GetStringContent(createListingSubCommentDto);

			// act
			var createTagResponseMessage = await _client.PostAsync(CreateTagUrl, createTagJson);
			var createArticleResponseMessage = await _client.PostAsync(CreateArticleUrl, createArticleJson);
			var createListingResponseMessage = await _client.PostAsync(CreateListingUrl, createListingJson);
			var createArticleMainCommentResponseMessage = await _client.PostAsync(CreateArticleMainCommentUrl, createArticleMainCommentJson);
			var createArticleSubCommentResponseMessage = await _client.PostAsync(CreateArticleSubCommentUrl, createArticleSubCommentJson);
			var createListingMainCommentResponseMessage = await _client.PostAsync(CreateListingMainCommentUrl, createListingMainCommentJson);
			var createListingSubCommentResponseMessage = await _client.PostAsync(CreateListingSubCommentUrl, createListingSubCommentJson);

			// assert
			Assert.True(createTagResponseMessage.IsSuccessStatusCode);
			Assert.True(createArticleResponseMessage.IsSuccessStatusCode);
			Assert.True(createListingResponseMessage.IsSuccessStatusCode);
			Assert.True(createArticleMainCommentResponseMessage.IsSuccessStatusCode);
			Assert.True(createArticleSubCommentResponseMessage.IsSuccessStatusCode);
			Assert.True(createListingMainCommentResponseMessage.IsSuccessStatusCode);
			Assert.True(createListingSubCommentResponseMessage.IsSuccessStatusCode);
		}
	}
}
