using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using KudryavtsevAlexey.Forum.Infrastructure.Database;
using KudryavtsevAlexey.Forum.Services.Dtos.Article;
using KudryavtsevAlexey.Forum.Services.Dtos.Comment;
using KudryavtsevAlexey.Forum.Services.Dtos.Listing;
using KudryavtsevAlexey.Forum.Services.Dtos.Organization;
using KudryavtsevAlexey.Forum.Services.Dtos.Subscriber;
using KudryavtsevAlexey.Forum.Services.Dtos.Tag;
using KudryavtsevAlexey.Forum.Services.Dtos.User;

namespace KudryavtsevAlexey.Forum.IntegrationTests.DtoHelpers
{ 
	public class DtoGenerator
	{
		private readonly ForumDbContext _dbContext;
		private readonly IMapper _mapper;

		public DtoGenerator(ForumDbContext dbContext, IMapper mapper)
		{
			_dbContext = dbContext;
			_mapper = mapper;
		}

		public CreateOrganizationDto GetCreateOrganizationDto()
		{
			return new CreateOrganizationDto(Name: "CreatedOrganizationName");
		}

		public UpdateOrganizationDto GetUpdateOrganizationDto(int organizationId)
		{
			return new UpdateOrganizationDto(organizationId, "UpdatedOrganizationName");
		}

		public CreateArticleDto GetCreateArticleDto()
		{
			var userId = _dbContext.Users.First().Id;
			var tag = _dbContext.Tags.First();

			var tagDto = _mapper.Map<TagDto>(tag);

			return new CreateArticleDto(UserId: userId, ShortDescription: "ArticleShortDescription1",
				Title: "ArticleTitle1", Tags: new List<TagDto>() { tagDto });
		}

		public UpdateArticleDto GetUpdateArticleDto(CreateArticleDto createArticleDto, int articleId)
		{
			return new UpdateArticleDto(Id: articleId, Title: "UpdatedArticleTitle", Tags: createArticleDto.Tags,
				ShortDescription: createArticleDto.ShortDescription);
		}

		public CreateListingDto GetCreateListingDto()
		{
			var userId = _dbContext.Users.First().Id;
			var tag = _dbContext.Tags.First();

			var tagDto = _mapper.Map<TagDto>(tag);

			return new CreateListingDto(UserId: userId, Category: "ListingCategory1",
				ShortDescription: "ListingShortDescription1", Title: "ListingTitle1",
				Tags: new List<TagDto>() {tagDto});
		}

		public UpdateListingDto GetUpdateListingDto(int listingId, List<TagDto> tags)
		{
			return new UpdateListingDto(Id: listingId, Category: "UpdatedListingCategory1",
				ShortDescription: "UpdatedShortDescription1", Title: "UpdatedListingTitle1",
				Tags: tags);
		}

		public CreateTagDto GetCreateTagDto()
		{
			return new CreateTagDto(Name: "CreatedTag1");
		}

		public UpdateTagDto GetUpdateTagDto(int tagId)
		{
			return new UpdateTagDto(Id: tagId, Name: "UpdatedTag1");
		}

		public CreateArticleMainCommentDto GetCreateArticleMainCommentDto()
		{
			var userId = _dbContext.Users.First().Id;
			var articleId = _dbContext.Articles.First().Id;

			return new CreateArticleMainCommentDto("CorrectArticleMainCommentContent1", userId,
				articleId, DateTime.UtcNow.Date);
		}

		public UpdateArticleMainCommentDto GetUpdateArticleMainCommentDto(int articleMainCommentId)
		{
			return new UpdateArticleMainCommentDto(Id: articleMainCommentId, Content: "CorrectUpdatedArticleMainCommentContent1");
		}

		public CreateListingMainCommentDto GetCreateListingMainCommentDto(int  userId, int listingId)
		{
			return new CreateListingMainCommentDto(
				Content: "CorrectListingMainCommentContent1", CreatedAt: DateTime.UtcNow.Date, UserId: userId,
				ListingId: listingId);
		}

		public UpdateListingMainCommentDto GetUpdateListingMainCommentDto(int listingMainCommentId)
		{
			return new UpdateListingMainCommentDto(Id: listingMainCommentId, Content: "CorrectUpdatedListingMainCommentContent1");
		}

		public CreateArticleSubCommentDto GetCreateArticleSubCommentDto(int userId, int articleId, int articleMainCommentId)
		{
			return new CreateArticleSubCommentDto(Content: "CorrectArticleSubCommentContent1",
				CreatedAt: DateTime.UtcNow.Date, UserId: userId, ArticleId: articleId,
				ArticleMainCommentId: articleMainCommentId);
		}

		public UpdateArticleSubCommentDto GetUpdateArticleSubCommentDto(int articleSubCommentId)
		{
			return new UpdateArticleSubCommentDto(Id: articleSubCommentId, Content: "CorrectUpdatedArticleSubCommentContent1");
		}

		public CreateListingSubCommentDto GetCreateListingSubCommentDto(int userId, int listingId, int listingMainCommentId)
		{
			return new CreateListingSubCommentDto(
				Content: "CorrectListingMainCommentContent1", CreatedAt: DateTime.UtcNow.Date, UserId: userId,
				ListingId: listingId, ListingMainCommentId: listingMainCommentId);
		}

		public UpdateListingSubCommentDto GetUpdateListingSubCommentDto(int listingSubCommentId)
		{
			return new UpdateListingSubCommentDto(Id: listingSubCommentId, Content: "CorrectUpdatedListingMainCommentContent1");
		}

		public FindUserToSubscribeDto GetFindUserToSubscribeDto(int userId, int subscriberId)
		{
			return new FindUserToSubscribeDto(userId, subscriberId);
		}

		public UpdateApplicationUserDto GetUpdateApplicationUserDto(int createdSubscriberId)
		{
			return new UpdateApplicationUserDto(Id: createdSubscriberId, Location: "UpdatedApplicationUserLocation1",
				Name: "UpdatedName1", Summary: "UpdatedApplicationUserSummary1",
				UserName: "UpdatedApplicationUserName");
		}
	}
}
