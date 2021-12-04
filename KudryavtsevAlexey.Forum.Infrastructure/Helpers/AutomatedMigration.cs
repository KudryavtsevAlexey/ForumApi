using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KudryavtsevAlexey.Forum.Domain.Entities;
using KudryavtsevAlexey.Forum.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace KudryavtsevAlexey.Forum.Infrastructure.Helpers
{
    public static class AutomatedMigration
    {
        public static async Task DatabaseMigrate(this IServiceProvider services)
        {
            var dbContext = services.GetRequiredService<ForumDbContext>();

            if (dbContext.Database.IsSqlServer())
            {
	            dbContext.Database.Migrate();
            }

            await dbContext.SeedDatabase();
        }
    }
}
