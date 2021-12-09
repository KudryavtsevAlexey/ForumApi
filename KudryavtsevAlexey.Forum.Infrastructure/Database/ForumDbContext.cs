using System.Linq;
using KudryavtsevAlexey.Forum.Domain.Entities;
using KudryavtsevAlexey.Forum.Domain.Entities.Comments;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace KudryavtsevAlexey.Forum.Infrastructure.Database
{
    public class ForumDbContext : IdentityDbContext<ApplicationUser, IdentityRole<int>, int>
    {
        public ForumDbContext(DbContextOptions<ForumDbContext> dbContextOptions) : base(dbContextOptions)
        {
            
		}

        public DbSet<Organization> Organizations { get; set; }

        public DbSet<Article> Articles { get; set; }

        public DbSet<Listing> Listings { get; set; }

		public DbSet<ArticleMainComment> ArticleMainComments { get; set; }

        public DbSet<ArticleSubComment> ArticleSubComments { get; set; }

        public DbSet<Subscriber> Subscribers { get; set; }

        public DbSet<ListingMainComment> ListingMainComments { get; set; }

        public DbSet<ListingSubComment> ListingSubComments { get; set; }

        public DbSet<Tag> Tags { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Article>()
                .HasKey(x => x.Id);

            builder.Entity<Article>()
                .HasOne(x => x.User)
                .WithMany(x => x.Articles)
                .IsRequired().OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Listing>()
                .HasKey(x => x.Id);

            builder.Entity<Listing>()
                .HasOne(x => x.User)
                .WithMany(x => x.Listings)
                .IsRequired().OnDelete(DeleteBehavior.Restrict);

            builder.Entity<ApplicationUser>()
                .HasKey(x => x.Id);

            builder.Entity<ApplicationUser>()
                .Property("Id").HasColumnType("int");

            builder.Entity<ApplicationUser>()
                .HasMany(x => x.ArticleMainComments)
                .WithOne(x => x.User)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<ApplicationUser>()
                .HasMany(x => x.ListingMainComments)
                .WithOne(x => x.User)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<ApplicationUser>()
                .HasMany(x => x.ArticleSubComments)
                .WithOne(x => x.User)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<ApplicationUser>()
                .HasMany(x => x.ListingSubComments)
                .WithOne(x => x.User)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<ApplicationUser>()
                .HasMany(x => x.Subscribers)
                .WithMany(x => x.Users)
                .LeftNavigation.ForeignKey.DeleteBehavior = DeleteBehavior.Restrict;

            builder.Entity<Subscriber>()
                .HasKey(x => x.Id);

            builder.Entity<ArticleMainComment>()
                .HasKey(x => x.Id);

            builder.Entity<ListingMainComment>()
                .HasKey(x => x.Id);

            builder.Entity<ArticleSubComment>()
                .HasOne(x => x.ArticleMainComment)
                .WithMany(x => x.SubComments)
                .IsRequired().OnDelete(DeleteBehavior.Restrict);

            builder.Entity<ListingSubComment>()
                .HasOne(x => x.ListingMainComment)
                .WithMany(x => x.SubComments)
                .IsRequired().OnDelete(DeleteBehavior.Restrict);

            builder.Entity<ArticleSubComment>()
                .HasKey(x => x.Id);

            builder.Entity<ListingSubComment>()
                .HasKey(x => x.Id);

            base.OnModelCreating(builder);
        }
    }
}
