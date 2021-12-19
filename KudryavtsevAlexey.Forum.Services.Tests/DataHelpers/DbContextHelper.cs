using System.Collections.Generic;
using KudryavtsevAlexey.Forum.Domain.Entities;
using KudryavtsevAlexey.Forum.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace KudryavtsevAlexey.Forum.Services.Tests.DataHelpers
{
    public class DbContextHelper
    {
        public ForumDbContext Context { get; set; }

        public DbContextHelper()
        {
            var builder = new DbContextOptionsBuilder<ForumDbContext>();

            builder.UseInMemoryDatabase("TestForumDb")
                .ConfigureWarnings(x=>x.Ignore(InMemoryEventId.TransactionIgnoredWarning));

            var options = builder.Options;

            Context = new ForumDbContext(options);

			var organizations = OrganizationHelper.GetMany();
			var articles = ArticleHelper.GetMany();
			var listings = ListingHelper.GetMany();
			var tags = TagHelper.GetMany();
			var users = UserHelper.GetMany();
			var articleMainComments = ArticleMainCommentHelper.GetMany();
			var listingMainComments = ListingMainCommentHelper.GetMany();
			var articleSubComments = ArticleSubCommentHelper.GetMany();
			var listingSubComments = ListingSubCommentHelper.GetMany();

			for (int i = 0; i < 5; i++)
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
			}

			Context.SaveChanges();
        }
    }
}
