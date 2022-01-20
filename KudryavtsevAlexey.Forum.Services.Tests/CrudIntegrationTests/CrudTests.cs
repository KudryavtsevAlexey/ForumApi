using System;
using System.Collections.Generic;
using System.Formats.Asn1;
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
using KudryavtsevAlexey.Forum.Services.Dtos.Subscriber;
using KudryavtsevAlexey.Forum.Services.Dtos.Tag;
using KudryavtsevAlexey.Forum.Services.Dtos.User;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
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
			var organizationId = _dbContext.Organizations.Last().Id + 1;

			var updateOrganizationDto = new UpdateOrganizationDto(organizationId, createOrganizationDto.Name);
			var updateOrganizationJson = new StringContent(JsonConvert.SerializeObject(updateOrganizationDto), Encoding.UTF8, "application/json");

			// act
			var countBeforeCreate = _dbContext.Organizations.Count();
			var postResponseMessage = await _client.PostAsync(createUrl, createOrganizationJson);
			var countAfterCreate = _dbContext.Organizations.Count();

			var getResponseMessage = await _client.GetAsync($"{getUrl}?organizationName={organizationName}");
			var patchResponseMessage = await _client.PatchAsync($"{updateUrl}", updateOrganizationJson);

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

			var articleId = _dbContext.Articles.Last().Id + 1;

			var updateArticleDto = new UpdateArticleDto(Id: articleId, Title: "UpdatedArticleTitle", Tags: createArticleDto.Tags,
				ShortDescription: createArticleDto.ShortDescription);
			var updateArticleJson = new StringContent(JsonConvert.SerializeObject(updateArticleDto), Encoding.UTF8,
				"application/json");

			// act
			var countBeforeCreate = _dbContext.Articles.Count();
			var postResponseMessage = await _client.PostAsync(createUrl, createArticleJson);
			var countAfterCreate = _dbContext.Articles.Count();

			var getResponseMessage = await _client.GetAsync($"{getUrl}?id={articleId}");
			var updateResponseMessage = await _client.PatchAsync($"{updateUrl}", updateArticleJson);

			// arrange
			var article = await _dbContext.Articles
				.Include(x => x.Tags)
				.ThenInclude(x => x.Articles)
				.LastAsync();
			
			// assert
			Assert.True(article.UserId > 0);
			Assert.True(article.Tags.Count > 0);
			Assert.True(article.Tags.First().Articles.Count > 0);

			// act
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

			var listingId = _dbContext.Listings.Last().Id + 1;

			var updateListingDto = new UpdateListingDto(Id: listingId, Category: "UpdatedListingCategory1",
				ShortDescription: "UpdatedShortDescription1", Title: "UpdatedListingTitle1",
				Tags: new List<TagDto>() {tagDto, updatedTagDto});
			var updateListingJson = new StringContent(JsonConvert.SerializeObject(updateListingDto), Encoding.UTF8,
				"application/json");

			// act
			var countBeforeCreate = _dbContext.Listings.Count();
			var postResponseMessage = await _client.PostAsync(createUrl, createListingJson);
			var countAfterCreate = _dbContext.Listings.Count();

			var getResponseMessage = await _client.GetAsync($"{getUrl}?id={listingId}");
			var updateResponseMessage = await _client.PatchAsync($"{updateUrl}", updateListingJson);

			// arrange
			var listing = await _dbContext.Listings
				.Include(x => x.Tags)
				.ThenInclude(x => x.Listings)
				.LastAsync();

			// assert
			Assert.True(listing.UserId > 0);
			Assert.True(listing.Tags.Count > 0);
			Assert.True(listing.Tags.First().Listings.Count > 0);

			// act
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

			var tagId = _dbContext.Tags.Last().Id + 1;

			var updateTagDto = new UpdateTagDto(Id: tagId, Name: "UpdatedTag1");
			var updateTagJson = new StringContent(JsonConvert.SerializeObject(updateTagDto), Encoding.UTF8,
				"application/json");
			
			// act
			var countBeforeCreate = _dbContext.Tags.Count();
			var postResponseMessage = await _client.PostAsync(createUrl, createTagJson);
			var countAfterCreate = _dbContext.Tags.Count();

			var getResponseMessage = await _client.GetAsync($"{getUrl}?id={tagId}");
			var updateResponseMessage = await _client.PatchAsync($"{updateUrl}", updateTagJson);

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

			var articleMainCommentId = _dbContext.ArticleMainComments.Last().Id + 1;

			var updateArticleMainCommentDto =
				new UpdateArticleMainCommentDto(Id: articleMainCommentId, Content: "CorrectUpdatedArticleMainCommentContent1");
			var updateArticleMainCommentJson =
				new StringContent(JsonConvert.SerializeObject(updateArticleMainCommentDto), Encoding.UTF8,
					"application/json");

			// act
			var countBeforeCreate = _dbContext.ArticleMainComments.Count();
			var postResponseMessage = await _client.PostAsync(createUrl, createArticleMainCommentJson);
			var countAfterCreate = _dbContext.ArticleMainComments.Count();

			var getResponseMessage = await _client.GetAsync($"{getUrl}?id={articleMainCommentId}");
			var updateResponseMessage = await _client.PatchAsync($"{updateUrl}", updateArticleMainCommentJson);

			// arrange
			var lastArticleMainComment = await _dbContext.ArticleMainComments
				.Include(x => x.Article)
				.Include(x => x.User)
				.LastAsync();

			// assert
			Assert.True(lastArticleMainComment.ArticleId > 0);
			Assert.True(lastArticleMainComment.UserId > 0);

			// act
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

			var listingMainCommentId = _dbContext.ListingMainComments.Last().Id + 1;

			var updateListingMainCommentDto =
				new UpdateListingMainCommentDto(Id: listingMainCommentId, Content: "CorrectUpdatedListingMainCommentContent1");
			var updateListingMainCommentJson =
				new StringContent(JsonConvert.SerializeObject(updateListingMainCommentDto), Encoding.UTF8,
					"application/json");

			// act
			var countBeforeCreate = _dbContext.ListingMainComments.Count();
			var postResponseMessage = await _client.PostAsync(createUrl, createListingMainCommentJson);
			var countAfterCreate = _dbContext.ListingMainComments.Count();

			var getResponseMessage = await _client.GetAsync($"{getUrl}?id={listingMainCommentId}");
			var updateResponseMessage = await _client.PatchAsync($"{updateUrl}", updateListingMainCommentJson);

			// arrange
			var lastListingMainComment = await _dbContext.ListingMainComments
				.Include(x => x.Listing)
				.Include(x => x.User)
				.LastAsync();

			// assert
			Assert.True(lastListingMainComment.ListingId > 0);
			Assert.True(lastListingMainComment.UserId > 0);

			// act
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

		[Theory]
		[InlineData("api/comment/article-subcomment/create", "api/comment/article-subcomment/find/id/", "api/comment/article-subcomment/update", "api/comment/article-subcomment/")]
		public async Task ArticleSubCommentCrudTest(string createUrl, string getUrl, string updateUrl, string deleteUrl)
		{
			// arrange
			await _client.Register();

			var userId = _dbContext.Users.First().Id;
			var articleId = _dbContext.Articles.First().Id;
			var articleMainCommentId = _dbContext.ArticleMainComments.First().Id;

			var createArticleSubCommentDto = new CreateArticleSubCommentDto(Content: "CorrectArticleSubCommentContent1",
				CreatedAt: DateTime.UtcNow.Date, UserId: userId, ArticleId: articleId,
				ArticleMainCommentId: articleMainCommentId);
			var createArticleSubCommentJson = new StringContent(JsonConvert.SerializeObject(createArticleSubCommentDto),
				Encoding.UTF8, "application/json");

			var articleSubCommentId = _dbContext.ArticleSubComments.Last().Id + 1;

			var updateArticleSubCommentDto =
				new UpdateArticleSubCommentDto(Id: articleSubCommentId, Content: "CorrectUpdatedArticleSubCommentContent1");
			var updateArticleSubCommentJson = new StringContent(JsonConvert.SerializeObject(updateArticleSubCommentDto),
				Encoding.UTF8, "application/json");

			// act
			var countBeforeCreate = _dbContext.ArticleSubComments.Count();
			var postResponseMessage = await _client.PostAsync(createUrl, createArticleSubCommentJson);
			var countAfterCreate = _dbContext.ArticleSubComments.Count();

			var getResponseMessage = await _client.GetAsync($"{getUrl}?id={articleSubCommentId}");
			var updateResponseMessage = await _client.PatchAsync($"{updateUrl}", updateArticleSubCommentJson);

			// arrange
			var lastArticleSubComment = await _dbContext.ArticleSubComments
				.Include(x => x.Article)
				.Include(x => x.User)
				.Include(x => x.ArticleMainComment)
				.LastAsync();

			// assert
			Assert.True(lastArticleSubComment.ArticleId > 0);
			Assert.True(lastArticleSubComment.ArticleMainCommentId > 0);
			Assert.True(lastArticleSubComment.UserId > 0);

			// act
			var countBeforeDelete = _dbContext.ArticleSubComments.Count();
			var deleteResponseMessage = await _client.DeleteAsync($"{deleteUrl}{articleSubCommentId}/delete");
			var countAfterDelete = _dbContext.ArticleSubComments.Count();

			// assert
			Assert.Equal(HttpStatusCode.NoContent, postResponseMessage.StatusCode);
			Assert.Equal(countBeforeCreate + 1, countAfterCreate);
			Assert.Equal(HttpStatusCode.OK, getResponseMessage.StatusCode);
			Assert.Equal(HttpStatusCode.NoContent, updateResponseMessage.StatusCode);
			Assert.Equal(HttpStatusCode.NoContent, deleteResponseMessage.StatusCode);
			Assert.Equal(countBeforeDelete - 1, countAfterDelete);
		}

		[Theory]
		[InlineData("api/comment/listing-subcomment/create", "api/comment/listing-subcomment/find/id", "api/comment/listing-subcomment/update", "api/comment/listing-subcomment/")]
		public async Task ListingSubCommentCrudTest(string createUrl, string getUrl, string updateUrl, string deleteUrl)
		{
			// arrange
			await _client.Register();

			var userId = _dbContext.Users.Last().Id;
			var listingId = _dbContext.Listings.Last().Id;
			var listingMainCommentId = _dbContext.ListingMainComments.Last().Id;

			var createListingSubCommentDto = new CreateListingSubCommentDto(
				Content: "CorrectListingMainCommentContent1", CreatedAt: DateTime.UtcNow.Date, UserId: userId,
				ListingId: listingId, ListingMainCommentId: listingMainCommentId);
			var createListingSubCommentJson = new StringContent(JsonConvert.SerializeObject(createListingSubCommentDto),
				Encoding.UTF8, "application/json");

			var listingSubCommentId = _dbContext.ListingSubComments.Last().Id + 1;

			var updateListingSubCommentDto =
				new UpdateListingSubCommentDto(Id: listingSubCommentId, Content: "CorrectUpdatedListingMainCommentContent1");
			var updateListingSubCommentJson = new StringContent(JsonConvert.SerializeObject(updateListingSubCommentDto),
				Encoding.UTF8, "application/json");

			// act
			var countBeforeCreate = _dbContext.ListingSubComments.Count();
			var postResponseMessage = await _client.PostAsync(createUrl, createListingSubCommentJson);
			var countAfterCreate = _dbContext.ListingSubComments.Count();

			var getResponseMessage = await _client.GetAsync($"{getUrl}?id={listingSubCommentId}");
			var updateResponseMessage = await _client.PatchAsync($"{updateUrl}", updateListingSubCommentJson);

			// arrange
			var lastListingSubComment = await _dbContext.ListingSubComments
				.Include(x => x.Listing)
				.Include(x => x.User)
				.Include(x => x.ListingMainComment)
				.LastAsync();

			// assert
			Assert.True(lastListingSubComment.ListingId > 0);
			Assert.True(lastListingSubComment.ListingMainCommentId > 0);
			Assert.True(lastListingSubComment.UserId > 0);

			// act
			var countBeforeDelete = _dbContext.ListingSubComments.Count();
			var deleteResponseMessage = await _client.DeleteAsync($"{deleteUrl}{listingSubCommentId}/delete");
			var countAfterDelete = _dbContext.ListingSubComments.Count();

			// assert
			Assert.Equal(HttpStatusCode.NoContent, postResponseMessage.StatusCode);
			Assert.Equal(countBeforeCreate + 1, countAfterCreate);
			Assert.Equal(HttpStatusCode.OK, getResponseMessage.StatusCode);
			Assert.Equal(HttpStatusCode.NoContent, updateResponseMessage.StatusCode);
			Assert.Equal(HttpStatusCode.NoContent, deleteResponseMessage.StatusCode);
			Assert.Equal(countBeforeDelete - 1, countAfterDelete);
		}

		[Theory]
		[InlineData("api/subscriber/sub", "api/subscriber/find", "api/user/update", "api/subscriber")]
		public async Task SubscriberCrudTest(string createUrl, string getUrl, string updateUrl, string deleteUrl)
		{
			// arrange
			int userId = await _dbContext.Users.Where(x => x.Subscribers.Count == 1)
				.Select(x => x.Id)
				.FirstOrDefaultAsync();

			await _client.Register();

			var subscriberId = _dbContext.Users.Last().Id;

			var findUserToSubscriberDto = new FindUserToSubscribeDto(userId, subscriberId);
			var findUserToSubscriberJson = new StringContent(JsonConvert.SerializeObject(findUserToSubscriberDto),
				Encoding.UTF8, "application/json");

			var createdSubscriberId = _dbContext.Subscribers.Last().Id + 1;
			// act
			var countBeforeCreate = _dbContext.Subscribers.Count();
			var postResponseMessage = await _client.PostAsync($"{createUrl}", findUserToSubscriberJson);
			var countAfterCreate = _dbContext.Subscribers.Count();

			var updateApplicationUserDto = new UpdateApplicationUserDto(Id: createdSubscriberId, Location: "UpdatedApplicationUserLocation1",
				Name: "UpdatedName1", Summary: "UpdatedApplicationUserSummary1",
				UserName: "UpdatedApplicationUserName");
			var updateApplicationUserJson = new StringContent(JsonConvert.SerializeObject(updateApplicationUserDto),
				Encoding.UTF8, "application/json");

			var getResponseMessage = await _client.GetAsync($"{getUrl}?id={createdSubscriberId}");
			var updateResponseMessage = await _client.PatchAsync($"{updateUrl}", updateApplicationUserJson);

			// arrange
			var subscriber = await _dbContext.Subscribers
				.Include(x => x.User)
				.ThenInclude(x => x.Subscribers)
				.LastAsync();

			var subscription = await _dbContext.Subscriptions
				.Include(x => x.User)
				.ThenInclude(x => x.Subscriptions)
				.LastAsync();

			// assert
			Assert.True(subscriber.UserId > 0);
			Assert.True(subscription.UserId > 0);
			Assert.True(subscriber.User.Subscribers.Count > 0);
			Assert.True(subscription.User.Subscriptions.Count > 0);
			Assert.True(subscriber.User.Subscribers.First().UserId > 0);
			Assert.True(subscription.User.Subscriptions.First().UserId > 0);

			// act
			var countSubscribersBeforeDelete = _dbContext.Subscribers.Count();
			var countSubscriptionsBeforeDelete = _dbContext.Subscriptions.Count();
			var deleteResponseMessage = await _client.DeleteAsync($"{deleteUrl}/unsub?userId={subscription.UserId}&subscriberId={subscriber.UserId}");
			var countSubscribersAfterDelete = _dbContext.Subscribers.Count();
			var countSubscriptionsAfterDelete = _dbContext.Subscriptions.Count();

			// assert
			Assert.Equal(HttpStatusCode.NoContent, postResponseMessage.StatusCode);
			Assert.Equal(countBeforeCreate + 1, countAfterCreate);
			Assert.Equal(HttpStatusCode.OK, getResponseMessage.StatusCode);
			Assert.Equal(HttpStatusCode.NoContent, updateResponseMessage.StatusCode);
			Assert.Equal(HttpStatusCode.NoContent, deleteResponseMessage.StatusCode);
			Assert.Equal(countSubscribersBeforeDelete - 1, countSubscribersAfterDelete);
			Assert.Equal(countSubscriptionsBeforeDelete - 1, countSubscriptionsAfterDelete);
		}
	}
}