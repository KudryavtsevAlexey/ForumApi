using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using KudryavtsevAlexey.Forum.Api;
using KudryavtsevAlexey.Forum.Infrastructure.Database;
using KudryavtsevAlexey.Forum.IntegrationTests.Extensions;
using KudryavtsevAlexey.Forum.IntegrationTests.GlobalTestConfiguration;
using KudryavtsevAlexey.Forum.IntegrationTests.WebApplicationFactory;
using KudryavtsevAlexey.Forum.Services.Dtos.Article;
using KudryavtsevAlexey.Forum.Services.Dtos.Comment;
using KudryavtsevAlexey.Forum.Services.Dtos.Listing;
using KudryavtsevAlexey.Forum.Services.Dtos.Organization;
using KudryavtsevAlexey.Forum.Services.Dtos.Tag;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Xunit;

namespace KudryavtsevAlexey.Forum.IntegrationTests.CrudIntegrationTests
{
	public class CrudTests : IClassFixture<CustomWebApplicationFactory<Startup>>
	{
		private readonly WebApplicationFactory<Startup> _factory;
		private readonly HttpClient _client;
		private readonly ForumDbContext _dbContext;
		private readonly IMapper _mapper;

		public CrudTests(CustomWebApplicationFactory<Startup> factory)
		{
			_factory = factory;
			_client = _factory.CreateClient(new WebApplicationFactoryClientOptions()
			{
				AllowAutoRedirect = false
			});

			_dbContext = _factory.Services.GetRequiredService<ForumDbContext>();
			_mapper = _factory.Services.GetRequiredService<IMapper>();
		}

		[Theory]
		[InlineData("api/organization/create", "api/organization/find/name", "api/organization/update", "api/organization/")]
		public async Task OrganizationCrudTest(string createUrl, string getUrl, string updateUrl, string deleteUrl)
		{
			// arrange
			await _client.Register();

			var createOrganizationDto = new CreateOrganizationDto(Name: "CreatedOrganizationName");
			var createOrganizationJson = new StringContent(JsonConvert.SerializeObject(createOrganizationDto), Encoding.UTF8, "application/json");

			var organizationName = createOrganizationDto.Name;
			var organizationId = _dbContext.Organizations.Last().Id;

			var updateOrganizationDto = new UpdateOrganizationDto(createOrganizationDto.Name);
			var updateOrganizationJson = new StringContent(JsonConvert.SerializeObject(updateOrganizationDto), Encoding.UTF8, "application/json");

			// act
			var countBeforeCreate = _dbContext.Organizations.Count();
			var postResponseMessage = await _client.PostAsync(createUrl, createOrganizationJson);
			var countAfterCreate = _dbContext.Organizations.Count();

			var getResponseMessage = await _client.GetAsync($"{getUrl}?organizationName={organizationName}");
			var patchResponseMessage = await _client.PatchAsync($"{updateUrl}?id={organizationId}", updateOrganizationJson);

			var countBeforeDelete = _dbContext.Organizations.Count();
			var deleteResponseMessage = await _client.DeleteAsync($"{deleteUrl}{organizationId}/delete");
			var countAfterDelete = _dbContext.Organizations.Count();
			
			// assert
			Assert.Equal(HttpStatusCode.NoContent, postResponseMessage.StatusCode);
			Assert.Equal(countBeforeCreate + 1, countAfterCreate);
			Assert.Equal(HttpStatusCode.OK, getResponseMessage.StatusCode);
			Assert.Equal(HttpStatusCode.NoContent, patchResponseMessage.StatusCode);
			Assert.Equal(HttpStatusCode.NoContent, deleteResponseMessage.StatusCode);
			Assert.Equal(countBeforeDelete - 1, countAfterDelete);
		}

		[Theory]
		[InlineData("api/article/create", "api/article/find/id", "api/article/update", "api/article/")]
		public async Task ArticleCrudTest(string createUrl, string getUrl, string updateUrl, string deleteUrl)
		{
			// arrange
			await _client.Register();

			var userId = _dbContext.Users.First().Id;
			var tag = _dbContext.Tags.First();

			var tagDto = _mapper.Map<TagDto>(tag);

			var createArticleDto = new CreateArticleDto(UserId: userId, ShortDescription: "ArticleShortDescription1",
				Title: "ArticleTitle1", Tags: new List<TagDto>() {tagDto});
			var createArticleJson = new StringContent(JsonConvert.SerializeObject(createArticleDto), Encoding.UTF8,
				"application/json");

			var updateArticleDto = new UpdateArticleDto(Title: "UpdatedArticleTitle", Tags: createArticleDto.Tags,
				ShortDescription: createArticleDto.ShortDescription);
			var updateArticleJson = new StringContent(JsonConvert.SerializeObject(updateArticleDto), Encoding.UTF8,
				"application/json");

			// act
			var countBeforeCreate = _dbContext.Articles.Count();
			var postResponseMessage = await _client.PostAsync(createUrl, createArticleJson);
			var countAfterCreate = _dbContext.Articles.Count();

			var articleId = _dbContext.Articles.Last().Id;
			var getResponseMessage = await _client.GetAsync($"{getUrl}?id={articleId}");
			var updateResponseMessage = await _client.PatchAsync($"{updateUrl}?id={articleId}", updateArticleJson);

			var countBeforeDelete = _dbContext.Articles.Count();
			var deleteResponseMessage = await _client.DeleteAsync($"{deleteUrl}{articleId}/delete");
			var countAfterDelete = _dbContext.Articles.Count();

			// assert
			Assert.Equal(HttpStatusCode.NoContent, postResponseMessage.StatusCode);
			Assert.Equal(countBeforeCreate + 1, countAfterCreate);
			Assert.Equal(HttpStatusCode.OK, getResponseMessage.StatusCode);
			Assert.Equal(HttpStatusCode.NoContent, updateResponseMessage.StatusCode);
			Assert.Equal(HttpStatusCode.NoContent, deleteResponseMessage.StatusCode);
			Assert.Equal(countBeforeDelete - 1, countAfterDelete);
		}

		[Theory]
		[InlineData("api/listing/create", "api/listing/find/id", "api/listing/update", "api/listing/")]
		public async Task ListingCrudTest(string createUrl, string getUrl, string updateUrl, string deleteUrl)
		{
			// arrange
			await _client.Register();

			var userId = _dbContext.Users.Last().Id;
			var tag = _dbContext.Tags.Last();

			var tagDto = _mapper.Map<TagDto>(tag);

			var createListingDto = new CreateListingDto(UserId: userId, Category: "ListingCategory1",
				ShortDescription: "ListingShortDescription1", Title: "ListingTitle1",
				Tags: new List<TagDto>() {tagDto});
			var createListingJson = new StringContent(JsonConvert.SerializeObject(createListingDto), Encoding.UTF8,
				"application/json");

			var updatedTag = _dbContext.Tags.First();
			var updatedTagDto = _mapper.Map<TagDto>(updatedTag);

			var updateListingDto = new UpdateListingDto(Category: "UpdatedListingCategory1",
				ShortDescription: "UpdatedShortDescription1", Title: "UpdatedListingTitle1",
				Tags: new List<TagDto>() {tagDto, updatedTagDto});
			var updateListingJson = new StringContent(JsonConvert.SerializeObject(updateListingDto), Encoding.UTF8,
				"application/json");

			// act
			var countBeforeCreate = _dbContext.Listings.Count();
			var postResponseMessage = await _client.PostAsync(createUrl, createListingJson);
			var countAfterCreate = _dbContext.Listings.Count();

			var listingId = _dbContext.Listings.Last().Id;
			var getResponseMessage = await _client.GetAsync($"{getUrl}?id={listingId}");
			var updateResponseMessage = await _client.PatchAsync($"{updateUrl}?id={listingId}", updateListingJson);

			var countBeforeDelete = _dbContext.Listings.Count();
			var deleteResponseMessage = await _client.DeleteAsync($"{deleteUrl}{listingId}/delete");
			var countAfterDelete = _dbContext.Listings.Count();

			// assert
			Assert.Equal(HttpStatusCode.NoContent, postResponseMessage.StatusCode);
			Assert.Equal(countBeforeCreate + 1, countAfterCreate);
			Assert.Equal(HttpStatusCode.OK, getResponseMessage.StatusCode);
			Assert.Equal(HttpStatusCode.NoContent, updateResponseMessage.StatusCode);
			Assert.Equal(HttpStatusCode.NoContent, deleteResponseMessage.StatusCode);
			Assert.Equal(countBeforeDelete - 1, countAfterDelete);
		}

		[Theory]
		[InlineData("api/tag/create", "api/tag/find/id", "api/tag/update", "api/tag/")]
		public async Task TagCrudTest(string createUrl, string getUrl, string updateUrl, string deleteUrl)
		{
			// arrange
			await _client.Register();

			var createTagDto = new CreateTagDto(Name: "CreatedTag1");
			var createTagJson = new StringContent(JsonConvert.SerializeObject(createTagDto), Encoding.UTF8,
				"application/json");

			var updateTagDto = new UpdateTagDto(Name: "UpdatedTag1");
			var updateTagJson = new StringContent(JsonConvert.SerializeObject(updateTagDto), Encoding.UTF8,
				"application/json");
			
			// act
			var countBeforeCreate = _dbContext.Tags.Count();
			var postResponseMessage = await _client.PostAsync(createUrl, createTagJson);
			var countAfterCreate = _dbContext.Tags.Count();

			var tagId = _dbContext.Tags.Last().Id;
			var getResponseMessage = await _client.GetAsync($"{getUrl}?id={tagId}");
			var updateResponseMessage = await _client.PatchAsync($"{updateUrl}?id={tagId}", updateTagJson);

			var countBeforeDelete = _dbContext.Tags.Count();
			var deleteResponseMessage = await _client.DeleteAsync($"{deleteUrl}{tagId}/delete");
			var countAfterDelete = _dbContext.Tags.Count();

			// assert
			Assert.Equal(HttpStatusCode.NoContent, postResponseMessage.StatusCode);
			Assert.Equal(countBeforeCreate + 1, countAfterCreate);
			Assert.Equal(HttpStatusCode.OK, getResponseMessage.StatusCode);
			Assert.Equal(HttpStatusCode.NoContent, updateResponseMessage.StatusCode);
			Assert.Equal(HttpStatusCode.NoContent, deleteResponseMessage.StatusCode);
			Assert.Equal(countBeforeDelete - 1, countAfterDelete);
		}

		[Theory]
		[InlineData("api/comment/article-comment/create", "api/comment/article-comment/find/id", "api/comment/article-comment/update", "api/comment/article-comment/")]
		public async Task ArticleMainCommentCrudTest(string createUrl, string getUrl, string updateUrl, string deleteUrl)
		{
			// arrange
			await _client.Register();

			var userId = _dbContext.Users.First().Id;
			var articleId = _dbContext.Articles.First().Id;

			var createArticleMainCommentDto = new CreateArticleMainCommentDto("CorrectArticleMainCommentContent1", userId,
				articleId, DateTime.UtcNow.Date);
			var createArticleMainCommentJson =
				new StringContent(JsonConvert.SerializeObject(createArticleMainCommentDto), Encoding.UTF8,
					"application/json");

			var updateArticleMainCommentDto =
				new UpdateArticleMainCommentDto(Content: "CorrectUpdatedArticleMainCommentContent1");
			var updateArticleMainCommentJson =
				new StringContent(JsonConvert.SerializeObject(updateArticleMainCommentDto), Encoding.UTF8,
					"application/json");

			// act
			var countBeforeCreate = _dbContext.ArticleMainComments.Count();
			var postResponseMessage = await _client.PostAsync(createUrl, createArticleMainCommentJson);
			var countAfterCreate = _dbContext.ArticleMainComments.Count();

			var articleMainCommentId = _dbContext.ArticleMainComments.Last().Id;
			var getResponseMessage = await _client.GetAsync($"{getUrl}?id={articleMainCommentId}");
			var updateResponseMessage = await _client.PatchAsync($"{updateUrl}?id={articleMainCommentId}", updateArticleMainCommentJson);

			var countBeforeDelete = _dbContext.ArticleMainComments.Count();
			var deleteResponseMessage = await _client.DeleteAsync($"{deleteUrl}{articleMainCommentId}/delete");
			var countAfterDelete = _dbContext.ArticleMainComments.Count();

			// assert
			Assert.Equal(HttpStatusCode.NoContent, postResponseMessage.StatusCode);
			Assert.Equal(countBeforeCreate + 1, countAfterCreate);
			Assert.Equal(HttpStatusCode.OK, getResponseMessage.StatusCode);
			Assert.Equal(HttpStatusCode.NoContent, updateResponseMessage.StatusCode);
			Assert.Equal(HttpStatusCode.NoContent, deleteResponseMessage.StatusCode);
			Assert.Equal(countBeforeDelete - 1, countAfterDelete);
		}

		[Theory]
		[InlineData("api/comment/listing-comment/create", "api/comment/listing-comment/find/id", "api/comment/listing-comment/update", "api/comment/listing-comment/")]
		public async Task ListingMainCommentCrudTest(string createUrl, string getUrl, string updateUrl, string deleteUrl)
		{
			// arrange
			await _client.Register();

			var userId = _dbContext.Users.First().Id;
			var listingId = _dbContext.Listings.First().Id;

			var createListingMainCommentDto = new CreateListingMainCommentDto(
				Content: "CorrectListingMainCommentContent1", CreatedAt: DateTime.UtcNow.Date, UserId: userId,
				ListingId: listingId);
			var createListingMainCommentJson =
				new StringContent(JsonConvert.SerializeObject(createListingMainCommentDto), Encoding.UTF8,
					"application/json");

			var updateListingMainCommentDto =
				new UpdateListingMainCommentDto(Content: "CorrectUpdatedListingMainCommentContent1");
			var updateListignMainCommentJson =
				new StringContent(JsonConvert.SerializeObject(updateListingMainCommentDto), Encoding.UTF8,
					"application/json");

			// act
			var countBeforeCreate = _dbContext.ListingMainComments.Count();
			var postResponseMessage = await _client.PostAsync(createUrl, createListingMainCommentJson);
			var countAfterCreate = _dbContext.ListingMainComments.Count();

			var listingMainCommentId = _dbContext.ListingMainComments.First().Id;
			var getResponseMessage = await _client.GetAsync($"{getUrl}?id={listingMainCommentId}");
			var updateResponseMessage = await _client.PatchAsync($"{updateUrl}?id={listingMainCommentId}", updateListignMainCommentJson);

			var countBeforeDelete = _dbContext.ListingMainComments.Count();
			var deleteResponseMessage = await _client.DeleteAsync($"{deleteUrl}{listingMainCommentId}/delete");
			var countAfterDelete = _dbContext.ListingMainComments.Count();

			// assert
			Assert.Equal(HttpStatusCode.NoContent, postResponseMessage.StatusCode);
			Assert.Equal(countBeforeCreate + 1, countAfterCreate);
			Assert.Equal(HttpStatusCode.OK, getResponseMessage.StatusCode);
			Assert.Equal(HttpStatusCode.NoContent, updateResponseMessage.StatusCode);
			Assert.Equal(HttpStatusCode.NoContent, deleteResponseMessage.StatusCode);
			Assert.Equal(countBeforeDelete - 1, countAfterDelete);
		}
	}
}