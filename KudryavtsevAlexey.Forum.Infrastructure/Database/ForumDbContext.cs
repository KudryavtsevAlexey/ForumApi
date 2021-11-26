using KudryavtsevAlexey.Forum.Domain.Entities;
using KudryavtsevAlexey.Forum.Domain.Entities.Comments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace KudryavtsevAlexey.Forum.Infrastructure.Database
{
    public class ForumDbContext : DbContext
    {
        public ForumDbContext(DbContextOptions<ForumDbContext> dbContextOptions) : base(dbContextOptions)
        {
            
		}

        public DbSet<Organization> Organizations { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Article> Articles { get; set; }

        public DbSet<Listing> Listings { get; set; }

		public DbSet<ArticleMainComment> ArticleMainComments { get; set; }

        public DbSet<ArticleSubComment> ArticleSubComments { get; set; }

        public DbSet<Subscriber> Subscribers { get; set; }

        public DbSet<ListingMainComment> ListingMainComments { get; set; }

        public DbSet<ListingSubComment> ListingSubComments { get; set; }

        public DbSet<SubscriberUser> SubscriberUsers { get; set; }

        public DbSet<Tag> Tags { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Article>()
                .HasKey(k => k.Id);

            builder.Entity<Article>()
                .HasOne(u => u.User)
                .WithMany(a => a.Articles)
                .IsRequired().OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Listing>()
                .HasKey(k => k.Id);

            builder.Entity<Listing>()
                .HasOne(u => u.User)
                .WithMany(a => a.Listings)
                .IsRequired().OnDelete(DeleteBehavior.Restrict);

            builder.Entity<User>()
                .HasKey(x => x.Id);

            builder.Entity<User>()
                .HasMany(x => x.Subscribers)
                .WithOne(x => x.User)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Subscriber>()
                .HasMany(x => x.Users)
                .WithOne(x => x.Subscriber)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<SubscriberUser>()
                .HasKey(k => new { k.UserId, k.SubscriberId });

            builder.Entity<ArticleMainComment>()
                .HasKey(k => k.Id);

            builder.Entity<ListingMainComment>()
                .HasKey(k => k.Id);

            builder.Entity<ArticleSubComment>()
                .HasKey(k => k.Id);

            builder.Entity<ListingSubComment>()
                .HasKey(k => k.Id);

            base.OnModelCreating(builder);
        }
    }
}
