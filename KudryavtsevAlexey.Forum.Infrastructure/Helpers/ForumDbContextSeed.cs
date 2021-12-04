using KudryavtsevAlexey.Forum.Domain.Entities;
using KudryavtsevAlexey.Forum.Domain.Entities.Comments;
using KudryavtsevAlexey.Forum.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Security.Claims;
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

				await dbContext.Organizations.AddRangeAsync(organizations);

                await dbContext.Tags.AddRangeAsync(tags);

                await dbContext.SaveChangesAsync();
            }
		}
	}
}