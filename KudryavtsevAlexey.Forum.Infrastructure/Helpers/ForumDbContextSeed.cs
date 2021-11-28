using KudryavtsevAlexey.Forum.Domain.Entities;
using KudryavtsevAlexey.Forum.Domain.Entities.Comments;
using KudryavtsevAlexey.Forum.Infrastructure.Database;

using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KudryavtsevAlexey.Forum.Infrastructure.Helpers
{
    public static class ForumDbContextSeed
	{
		public static async Task SeedDatabase(this ForumDbContext dbContext)
		{
			if (await dbContext.Organizations.AnyAsync().ConfigureAwait(false)) return;
			{
				var organizations = new List<Organization>()
				{
					new()
					{
						Name = "Meta",
					},

					new()
					{
						Name = "Amazon",
					},

					new()
					{
						Name = "Netflix",
					},

					new()
					{
						Name = "Google",
					},

					new()
					{
						Name = "Apple",
					}
				};

                var tags = new List<Tag>()
				{
					new()
                    {
                        Name = "front-end",
					},

					new()
                    {
						Name = "data-science",
					},

                    new()
                    {
						Name =  "mobile",
					},
                    
                    new()
                    {
						Name = "gamedev",
					},
                    
                    new()
                    {
						Name = "backend",
					},
                    
                    new()
                    {
						Name = "full-stack",
					},
                    
                    new()
                    {
                        Name = "database",
					},

                    new() 
                    {
						Name = "QA",
					}
                };

                var metaUsers = new List<User>()
				{
					new()
					{
						UserName = "Alexander",
						Name = "Alexander",
						Summary = "Programmer Alexander",
						Location = "USA: Menlo Park, California",
						JoinedAt = DateTime.Now.Subtract(TimeSpan.FromDays(250)),
						Organization = organizations[0],
					},

					new()
					{
						UserName = "Sergey",
						Name = "Sergey",
						Summary = "Technical Director Sergey",
						Location = "USA: Menlo Park, California",
						JoinedAt = DateTime.Now.Subtract(TimeSpan.FromDays(300)),
						Organization = organizations[0]
					},

					new()
					{
						UserName = "Tatiana",
						Name = "Tatiana",
						Summary = "Manager Tatiana",
						Location = "USA: Menlo Park, California",
						JoinedAt = DateTime.Now.Subtract(TimeSpan.FromDays(275)),
						Organization = organizations[0]
					},

					new()
					{
						UserName = "Vladimir",
						Name = "Vladimir",
						Summary = "Programmer Vladimir",
						Location = "USA: Menlo Park, California",
						JoinedAt = DateTime.Now,
						Organization = organizations[0]
					},

					new()
					{
						UserName = "Andrey",
						Name = "Andrey",
						Summary = "Programmer Andrey",
						Location = "USA: Menlo Park, California",
						JoinedAt = DateTime.Now.Subtract(TimeSpan.FromDays(280)),
						Organization = organizations[0]
					},

					new()
					{
						UserName = "Nikolay",
						Name = "Nikolay",
						Summary = "Techlead Nikolay",
						Location = "USA: Menlo Park, California",
						JoinedAt = DateTime.Now.Subtract(TimeSpan.FromDays(270)),
						Organization = organizations[0]
					}
				};

                var amazonUsers = new List<User>()
				{
					new()
					{
						UserName = "Olga",
						Name = "Olga",
						Summary = "Programmer Olga",
						Location = "USA: Seattle, Washington",
						JoinedAt = DateTime.Now.Subtract(TimeSpan.FromDays(220)),
						Organization = organizations[1]
					},

					new()
					{
						UserName = "Victor",
						Name = "Victor",
						Summary = "Manager Victor",
						Location = "USA: Seattle, Washington",
						JoinedAt = DateTime.Now.Subtract(TimeSpan.FromDays(210)),
						Organization = organizations[1]
					},

					new()
					{
						UserName = "Alexey",
						Name = "Alexey",
						Summary = "Programmer Alexey",
						Location = "USA: Seattle, Washington",
						JoinedAt = DateTime.Now.Subtract(TimeSpan.FromDays(200)),
						Organization = organizations[1]
					},

					new()
					{
						UserName = "Natalia",
						Name = "Natalia",
						Summary = "Techlead Natalia",
						Location = "USA: Seattle, Washington",
						JoinedAt = DateTime.Now.Subtract(TimeSpan.FromDays(170)),
						Organization = organizations[1]
					},

					new()
					{
						UserName = "Ivan",
						Name = "Ivan",
						Summary = "Technical Director Ivan",
						Location = "USA: Seattle, Washington",
						JoinedAt = DateTime.Now.Subtract(TimeSpan.FromDays(240)),
						Organization = organizations[1]
					},

					new()
					{
						UserName = "Dmitry",
						Name = "Dmitry",
						Summary = "Programmer Dmitry",
						Location = "USA: Seattle, Washington",
						JoinedAt = DateTime.Now.Subtract(TimeSpan.FromDays(215)),
						Organization = organizations[1]
					}
				};

                var netflixUsers = new List<User>()
				{
					new()
					{
						UserName = "Igor",
						Name = "Igor",
						Summary = "Programmer Igor",
						Location = "USA: Los Gatos, California",
						JoinedAt = DateTime.Now.Subtract(TimeSpan.FromDays(250)),
						Organization = organizations[2]
					},

					new()
					{
						UserName = "Anatoly",
						Name = "Anatoly",
						Summary = "Technical Director Anatoly",
						Location = "USA: Los Gatos, California",
						JoinedAt = DateTime.Now.Subtract(TimeSpan.FromDays(300)),
						Organization = organizations[2]
					},

					new()
					{
						UserName = "Oleg",
						Name = "Oleg",
						Summary = "Manager Oleg",
						Location = "USA: Los Gatos, California",
						JoinedAt = DateTime.Now.Subtract(TimeSpan.FromDays(275)),
						Organization = organizations[2]
					},

					new()
					{
						UserName = "Paul",
						Name = "Paul",
						Summary = "Programmer Paul",
						Location = "USA: Los Gatos, California",
						JoinedAt = DateTime.Now.Subtract(TimeSpan.FromDays(260)),
						Organization = organizations[2]
					},

					new()
					{
						UserName = "Vitaly",
						Name = "Vitaly",
						Summary = "Programmer Vitaly",
						Location = "USA: Los Gatos, California",
						JoinedAt = DateTime.Now.Subtract(TimeSpan.FromDays(280)),
						Organization = organizations[2]
					},

					new()
					{
						UserName = "Valery",
						Name = "Valery",
						Summary = "Techlead Valery",
						Location = "USA: Los Gatos, California",
						JoinedAt = DateTime.Now.Subtract(TimeSpan.FromDays(270)),
						Organization = organizations[2]
					}
				};

                var googleUsers = new List<User>()
				{
					new()
					{
						UserName = "Vadim",
						Name = "Vadim",
						Summary = "Programmer Vadim",
						Location = "USA: Mountain View, California",
						JoinedAt = DateTime.Now.Subtract(TimeSpan.FromDays(90)),
						Organization = organizations[3]
					},

					new()
					{
						UserName = "Darya",
						Name = "Darya",
						Summary = "Technical Director Darya",
						Location = "USA: Mountain View, California",
						JoinedAt = DateTime.Now.Subtract(TimeSpan.FromDays(100)),
						Organization = organizations[3]
					},

					new()
					{
						UserName = "Nikita",
						Name = "Nikita",
						Summary = "Manager Nikita",
						Location = "USA: Mountain View, California",
						JoinedAt = DateTime.Now.Subtract(TimeSpan.FromDays(80)),
						Organization = organizations[3]
					},

					new()
					{
						UserName = "Ruslan",
						Name = "Ruslan",
						Summary = "Programmer Ruslan",
						Location = "USA: Mountain View, California",
						JoinedAt = DateTime.Now.Subtract(TimeSpan.FromDays(75)),
						Organization = organizations[3]
					},

					new()
					{
						UserName = "Boris",
						Name = "Boris",
						Summary = "Programmer Boris",
						Location = "USA: Mountain View, California",
						JoinedAt = DateTime.Now.Subtract(TimeSpan.FromDays(70)),
						Organization = organizations[3]
					},

					new()
					{
						UserName = "Kirill",
						Name = "Kirill",
						Summary = "Techlead Kirill",
						Location = "USA: Mountain View, California",
						JoinedAt = DateTime.Now.Subtract(TimeSpan.FromDays(95)),
						Organization = organizations[3]
					}
				};

                var appleUsers = new List<User>()
				{
					new()
					{
						UserName = "Denis",
						Name = "Denis",
						Summary = "Programmer Denis",
						Location = "USA: Cupertino, California",
						JoinedAt = DateTime.Now.Subtract(TimeSpan.FromDays(120)),
						Organization = organizations[4]
					},

					new()
					{
						UserName = "Darya",
						Name = "Darya",
						Summary = "Technical Director Darya",
						Location = "USA: Cupertino, California",
						JoinedAt = DateTime.Now.Subtract(TimeSpan.FromDays(160)),
						Organization = organizations[4]
					},

					new()
					{
						UserName = "Konstantin",
						Name = "Konstantin",
						Summary = "Manager Konstantin",
						Location = "USA: Cupertino, California",
						JoinedAt = DateTime.Now.Subtract(TimeSpan.FromDays(140)),
						Organization = organizations[4]
					},

					new()
					{
						UserName = "Vyacheslav",
						Name = "Vyacheslav",
						Summary = "Programmer Vyacheslav",
						Location = "USA: Cupertino, California",
						JoinedAt = DateTime.Now.Subtract(TimeSpan.FromDays(145)),
						Organization = organizations[4]
					},

					new()
					{
						UserName = "Evgeniya",
						Name = "Evgeniya",
						Summary = "Programmer Evgeniya",
						Location = "USA: Cupertino, California",
						JoinedAt = DateTime.Now.Subtract(TimeSpan.FromDays(130)),
						Organization = organizations[4]
					},

					new()
					{
						UserName = "Peter",
						Name = "Peter",
						Summary = "Techlead Peter",
						Location = "USA: Cupertino, California",
						JoinedAt = DateTime.Now.Subtract(TimeSpan.FromDays(150)),
						Organization = organizations[4]
					}
				};

                var subscribers = new List<Subscriber>()
				{
                    new()
                    {
                        UserName = "Anatoly",
                        Name = "Anatoly",
                        Organization = organizations[2],
						Users = new List<User>() {netflixUsers[1]}
                    },


                    new()
                    {
                        UserName = "Oleg",
                        Name = "Oleg",
                        Organization = organizations[2],
                        Users = new List<User>() {netflixUsers[2]}
					},

                    new()
					{
						UserName = "Paul",
						Name = "Paul",
						Organization = organizations[2],
                        Users = new List<User>() {netflixUsers[3]}
					},

                    new()
                    {
                        UserName = "Vitaly",
                        Name = "Vitaly",
                        Organization = organizations[2],
                        Users = new List<User>() {netflixUsers[4]}
					},

                    new()
                    {
                        UserName = "Valery",
                        Name = "Valery",
                        Organization = organizations[2],
                        Users = new List<User>() {netflixUsers[5]}
					}
				};

                for (int i = 1; i < netflixUsers.Count; i++)
                {
					netflixUsers[i].Subscribers = new List<Subscriber>() { subscribers[i - 1] };
                }

                await dbContext.Users.AddRangeAsync(metaUsers);

                await dbContext.Users.AddRangeAsync(amazonUsers);

                await dbContext.Users.AddRangeAsync(netflixUsers);

                await dbContext.Users.AddRangeAsync(googleUsers);

                await dbContext.Users.AddRangeAsync(appleUsers);

				await dbContext.Subscribers.AddRangeAsync(subscribers);

				var articles = new List<Article>()
				{
					new()
					{
						Title = "8 ways to cause memory leaks in .NET",
						ShortDescription = "The most common causes of memory leaks in .NET applications",
						Organization = organizations[0],
						User = metaUsers[0],
						PublishedAt = null,
						Tags = new List<Tag>() {tags[4]},
					},

                    new()
					{
						Title = "Not all test solutions are created equal",
						ShortDescription = "The problem about the Severomuisky tunnel",
						Organization = organizations[0],
						User = metaUsers[1],
						PublishedAt = DateTime.Now.Subtract(TimeSpan.FromMinutes(30)),
                        Tags = new List<Tag>() {tags[7]},
					},

					new()
					{
						Title = "Finding deadlock in .NET 5 using dump analysis",
						ShortDescription = "How I investigated one of these situations and came to unexpected conclusions",
						Organization = organizations[0],
						User = metaUsers[2],
						PublishedAt = DateTime.Now.Subtract(TimeSpan.FromHours(2)),
                        Tags = new List<Tag>() {tags[4]},
					},

					new()
					{
						Title = "Changing advanced print settings via API",
						ShortDescription = "Print settings that are advanced, as well as how to change them through the nanoCAD API",
						Organization = organizations[0],
						User = metaUsers[3],
						PublishedAt = DateTime.Now.Subtract(TimeSpan.FromHours(2)),
                        Tags = new List<Tag>() {tags[4]},
					},

					new()
					{
						Title = "Worker Services in .NET",
						ShortDescription = "Simplifying the process of writing services",
						Organization = organizations[0],
						User = metaUsers[4],
						PublishedAt = null,
                        Tags = new List<Tag>() {tags[4]},
					},

					new()
					{
						Title = "C# learning plan",
						ShortDescription = "The name speaks for itself",
						Organization = organizations[1],
						User = amazonUsers[0],
						PublishedAt = DateTime.Now.Subtract(TimeSpan.FromHours(3)),
                        Tags = new List<Tag>() {tags[0], tags[4], tags[5]},
					},

					new()
					{
						Title = "My first Pet project",
						ShortDescription = "Rethinking the regex approach",
						Organization = organizations[1],
						User = amazonUsers[1],
						PublishedAt = DateTime.Now.Subtract(TimeSpan.FromHours(4)),
                        Tags = new List<Tag>() {tags[4]},
					},

					new()
					{
						Title = "How to make beautiful text output in C#",
						ShortDescription = "Practice using arrays, loops, some classes and methods",
						Organization = organizations[1],
						User = amazonUsers[2],
						PublishedAt = null,
                        Tags = new List<Tag>() {tags[0], tags[5]},
					},

					new()
					{
						Title = "Time and date in Razor Pages forms",
						ShortDescription = "Options for managing both time and date",
						Organization = organizations[2],
						User = netflixUsers[0],
						PublishedAt = DateTime.Now.Subtract(TimeSpan.FromDays(1)),
                        Tags = new List<Tag>() {tags[0], tags[5]},
					},

					new()
					{
						Title = "Everything will be fine with C#",
						ShortDescription = "I was very upset by yesterday's post",
						Organization = organizations[2],
						User = netflixUsers[1],
						PublishedAt = null,
                        Tags = new List<Tag>() {tags[4]},
					},

					new()
					{
						Title = "How to calculate sine faster than anyone",
						ShortDescription = "Answer to a regular question",
						Organization = organizations[2],
						User = netflixUsers[2],
						PublishedAt = DateTime.Now.Subtract(TimeSpan.FromHours(15)),
                        Tags = new List<Tag>() {tags[4]},
					},

					new()
					{
						Title = "What will happen with C#",
						ShortDescription = "My ideas and thoughts about the fate of the language",
						Organization = organizations[3],
						User = googleUsers[0],
						PublishedAt = null,
                        Tags = new List<Tag>() {tags[4]},
					},

					new()
					{
						Title = "Console application that draws a heart in C#",
						ShortDescription = "The application was created rather for fun",
						Organization = organizations[3],
						User = googleUsers[1],
						PublishedAt = null,
                        Tags = new List<Tag>() {tags[0], tags[5]},
					},

					new()
					{
						Title = "Book C # 9 and .NET 5. Development and Optimization",
						ShortDescription = "By the end of the book, you will have acquired the knowledge and skills necessary to use C # 9 and .NET 5 to develop services, web and mobile applications.",
						Organization = organizations[3],
						User = googleUsers[2],
						PublishedAt = DateTime.Now.Subtract(TimeSpan.FromDays(19)),
                        Tags = new List<Tag>() {tags[4]},
					},

					new()
					{
						Title = "Speed up pow",
						ShortDescription = "Several non-standard algorithms for raising a number to a power",
						Organization = organizations[3],
						User = googleUsers[3],
						PublishedAt = DateTime.Now.Subtract(TimeSpan.FromHours(7)),
                        Tags = new List<Tag>() {tags[4]},
					},

					new()
					{
						Title = "Overview of what's new in C # 10",
						ShortDescription = "Descriptions along with explanatory code snippets",
						Organization = organizations[3],
						User = googleUsers[4],
						PublishedAt = null,
                        Tags = new List<Tag>() { tags[0], tags[4], tags[5], tags[6], tags[7]},
					},

					new()
					{
						Title = "Deploying an ASP.NET Web Application",
						ShortDescription = "Web Application Deployment Guide",
						Organization = organizations[4],
						User = appleUsers[1],
						PublishedAt = DateTime.Now.Subtract(TimeSpan.FromDays(10)),
                        Tags = new List<Tag>() {tags[0], tags[4], tags[5]},
					},

					new()
					{
						Title = "View Variables in ASP.NET MVC Applications",
						ShortDescription = "Using views in an MVC module",
						Organization = organizations[4],
						User = appleUsers[3],
						PublishedAt = null,
                        Tags = new List<Tag>() {tags[0], tags[5]},
					},

					new()
					{
						Title = "Caching Data and Pages in ASP.NET",
						ShortDescription = "Some problems of web applications and how they are solved with caching.",
						Organization = organizations[4],
						User = appleUsers[5],
						PublishedAt = DateTime.Now.Subtract(TimeSpan.FromDays(14)),
                        Tags = new List<Tag>() {tags[4]},
					},
				};

                var listings = new List<Listing>()
				{
					new()
					{
						Title = "MetaListing",
						ShortDescription = "MetaListingDescription",
						Category = "meta",
                        Tags = new List<Tag>() {tags[1]},
						User = metaUsers[1],
						PublishedAt = null,
						Organization = organizations[0],
                    },
					new()
					{
						Title = "AmazonListing",
						ShortDescription = "AmazonListingDescription",
						Category = "amazon",
                        Tags = new List<Tag>() {tags[2]},
						User = amazonUsers[2],
						PublishedAt = DateTime.Now.Subtract(TimeSpan.FromDays(3)),
						Organization = organizations[1],
					},
					new()
					{
						Title = "NetflixListing",
						ShortDescription = "NetflixListingDescription",
						Category = "netflix",
                        Tags = new List<Tag>() {tags[3]},
						User = netflixUsers[3],
						PublishedAt = null,
						Organization = organizations[2],
					},
					new()
					{
						Title = "GoogleListing",
						ShortDescription = "GoogleListingDescription",
						Category = "google",
                        Tags = new List<Tag>() {tags[6]},
						User = googleUsers[4],
						PublishedAt = DateTime.Now.Subtract(TimeSpan.FromMinutes(45)),
						Organization = organizations[3],
					},
					new()
					{
						Title = "AppleListing",
						ShortDescription = "AppleListingDescription",
						Category = "apple",
                        Tags = new List<Tag>() { tags[2]},
						User = appleUsers[5],
						PublishedAt = DateTime.Now.Subtract(TimeSpan.FromHours(4)),
						Organization = organizations[3],
					},
				};

                tags[0].Articles = new List<Article>()
                {
                    articles[5], articles[7], articles[8], articles[12], articles[15], articles[16], articles[17]
                };

                tags[1].Listings = new List<Listing>()
                {
                    listings[0]
                };

                tags[2].Listings = new List<Listing>()
                {
                    listings[1],
                    listings[4]
                };

                tags[3].Listings = new List<Listing>()
                {
                    listings[2]
                };

                tags[4].Articles = new List<Article>()
                {
                    articles[0], articles[2], articles[3], articles[4], articles[5], articles[6], articles[9],
                    articles[10], articles[11], articles[13], articles[14], articles[15], articles[16], articles[18]
                };

                tags[5].Articles = new List<Article>()
                {
                    articles[5], articles[7], articles[8], articles[12], articles[15], articles[16], articles[17]
                };

                tags[6].Articles = new List<Article>()
                {
                    articles[15]
                };

                tags[6].Listings = new List<Listing>()
                {
                    listings[3]
                };

                tags[7].Articles = new List<Article>()
                {
                    articles[1], articles[15]
                };

				await dbContext.Organizations.AddRangeAsync(organizations);

                await dbContext.Articles.AddRangeAsync(articles);

                await dbContext.Listings.AddRangeAsync(listings);

                await dbContext.Tags.AddRangeAsync(tags);

				var timeToAnswer = 5;

                var articleMainComments = new List<ArticleMainComment>();
                var listingMainComments = new List<ListingMainComment>();
                var articleSubComments = new List<ArticleSubComment>();
                var listingSubComments = new List<ListingSubComment>();

				for (int i = 0; i < articles.Count; i++)
                {
                    if (articles[i].PublishedAt != null)
                    {
						var mainComment = new ArticleMainComment()
                        {
                            Name = $"Main comment to {articles[i].Title} article",
                            CreatedAt = DateTime.Now.Subtract(TimeSpan.FromDays(i + 10)),
                            Article = articles[i],
                        };

                        var subComment = new ArticleSubComment()
                        {
                            Name = $"Subcomment to {articles[i].Title} article",
                            CreatedAt = DateTime.Now.Subtract(TimeSpan.FromDays(i + 10 - timeToAnswer)),
                            ArticleMainComment = mainComment,
							Article = articles[i]
                        };

						mainComment.SubComments = new List<ArticleSubComment>() { subComment };

                        articles[i].MainComments = new List<ArticleMainComment>() { mainComment };

                        articleMainComments.Add(mainComment);
                        articleSubComments.Add(subComment);
					}
                }

				for (int i = 0; i < listings.Count; i++)
				{
					if (listings[i].PublishedAt != null)
					{
						var mainComment = new ListingMainComment()
						{
							Name = $"Main comment to {listings[i].Title} listing",
							CreatedAt = DateTime.Now.Subtract(TimeSpan.FromDays(i + 10)),
							Listing = listings[i],
						};

						var subComment = new ListingSubComment()
						{
							Name = $"Subcomment to {listings[i].Title} listing",
							CreatedAt = DateTime.Now.Subtract(TimeSpan.FromDays(i + 10 - timeToAnswer)),
                            ListingMainComment = mainComment,
							Listing = listings[i]
						};

						mainComment.SubComments = new List<ListingSubComment>() { subComment };

                        listings[i].MainComments = new List<ListingMainComment>() { mainComment };

                        listingMainComments.Add(mainComment);
						listingSubComments.Add(subComment);
					}
				}

                await dbContext.ArticleMainComments.AddRangeAsync(articleMainComments);

                await dbContext.ArticleSubComments.AddRangeAsync(articleSubComments);

                await dbContext.ListingMainComments.AddRangeAsync(listingMainComments);

                await dbContext.ListingSubComments.AddRangeAsync(listingSubComments);

                await dbContext.SaveChangesAsync();
            }
		}
	}
}