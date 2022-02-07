using KudryavtsevAlexey.Forum.Domain.Entities;
using KudryavtsevAlexey.Forum.Infrastructure.Database;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using KudryavtsevAlexey.Forum.Domain.Entities.Comments;

namespace KudryavtsevAlexey.Forum.IntegrationTests.DataHelpers
{
    public static class DbContextHelper
    {
	    public static void InitializeTestingDatabase(this IServiceCollection serviceCollection, ForumDbContext dbContext)
	    {
		    var organizations = new List<Organization> {OrganizationHelper.GetOne()};
		    organizations.AddRange(OrganizationHelper.GetMany());

			var articles = new List<Article> {ArticleHelper.GetOne()};
			articles.AddRange(ArticleHelper.GetMany());

			var listings = new List<Listing>() {ListingHelper.GetOne()};
			listings.AddRange(ListingHelper.GetMany());

			var tags = new List<Tag>() {TagHelper.GetOne()};
			tags.AddRange(TagHelper.GetMany());

			var users = new List<ApplicationUser>() {UserHelper.GetOne()};
			users.AddRange(UserHelper.GetMany());

			var articleMainComments = new List<ArticleMainComment>() {ArticleMainCommentHelper.GetOne()};
			articleMainComments.AddRange(ArticleMainCommentHelper.GetMany());

			var listingMainComments = new List<ListingMainComment>() {ListingMainCommentHelper.GetOne()};
			listingMainComments.AddRange(ListingMainCommentHelper.GetMany());

			var articleSubComments = new List<ArticleSubComment>() {ArticleSubCommentHelper.GetOne()};
			articleSubComments.AddRange(ArticleSubCommentHelper.GetMany());

			var listingSubComments = new List<ListingSubComment>() {ListingSubCommentHelper.GetOne()};
			listingSubComments.AddRange(ListingSubCommentHelper.GetMany());

			var subscribers = new List<Subscriber>();
			var subscriptions = new List<Subscription>();

			for (int i = 0; i < organizations.Count; i++)
			{
				organizations[i].Users.Add(users[i]);

				articles[i].MainComments.Add(articleMainComments[i]);
				articles[i].Tags.Add(tags[i]);
				articles[i].User = users[i];

				listings[i].MainComments.Add(listingMainComments[i]);
				listings[i].Tags.Add(tags[i]);
				listings[i].User = users[i];

				tags[i].Articles.Add(articles[i]);
				tags[i].Listings.Add(listings[i]);

				users[i].Articles.Add(articles[i]);
				users[i].Listings.Add(listings[i]);
				users[i].Organization = organizations[i];

				var subscriber = new Subscriber();
				var subscription = new Subscription();

				/// <summary>
				/// subscriber.User = users[1];
				///
				/// subscription.User = users[0];
				/// subscription.User.Name = UserName1;
				/// </summary>

				subscriber.User = users[(i % 4) + 1];
				subscriber.User.Subscriptions.Add(subscription);

				subscription.User = users[i];
				subscription.User.Subscribers.Add(subscriber);

				subscribers.Add(subscriber);
				subscriptions.Add(subscription);

				articleMainComments[i].Article = articles[i];
				articleMainComments[i].SubComments.Add(articleSubComments[i]);
				articleMainComments[i].User = users[i];

				listingMainComments[i].Listing = listings[i];
				listingMainComments[i].SubComments.Add(listingSubComments[i]);
				listingMainComments[i].User = users[i];

				articleSubComments[i].Article = articles[i];
				articleSubComments[i].ArticleMainComment = articleMainComments[i];
				articleSubComments[i].User = users[i];

				listingSubComments[i].Listing = listings[i];
				listingSubComments[i].ListingMainComment = listingMainComments[i];
				listingSubComments[i].User = users[i];
			}

			dbContext.Organizations.AddRange(organizations);
			dbContext.Articles.AddRange(articles);
			dbContext.Listings.AddRange(listings);
			dbContext.Tags.AddRange(tags);
			dbContext.Users.AddRange(users);
			dbContext.Subscribers.AddRange(subscribers);
			dbContext.Subscriptions.AddRange(subscriptions);
			dbContext.ArticleMainComments.AddRange(articleMainComments);
			dbContext.ListingMainComments.AddRange(listingMainComments);
			dbContext.ArticleSubComments.AddRange(articleSubComments);
			dbContext.ListingSubComments.AddRange(listingSubComments);

			dbContext.SaveChanges();
        }
    }
}