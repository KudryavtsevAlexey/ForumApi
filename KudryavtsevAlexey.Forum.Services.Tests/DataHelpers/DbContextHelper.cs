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

            //var organizations = OrganizationHelper.GetMany();
            //var articles = ArticleHelper.GetMany();
            //var listings = ListingHelper.GetMany();
            //var tags = TagHelper.GetMany();
            //var users = UserHelper.GetMany();
            //var subscribers = SubscriberHelper.GetMany();
            //var articleMainComments = ArticleMainCommentHelper.GetMany();
            //var listingMainComments = ListingMainCommentHelper.GetMany();
            //var articleSubComments = ArticleSubCommentHelper.GetMany();
            //var listingSubComments = ListingSubComments.GetMany();

            Context.SaveChanges();
        }
    }
}
