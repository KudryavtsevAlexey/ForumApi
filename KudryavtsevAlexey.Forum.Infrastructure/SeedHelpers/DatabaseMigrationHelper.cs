using System;
using System.Threading.Tasks;
using KudryavtsevAlexey.Forum.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace KudryavtsevAlexey.Forum.Infrastructure.SeedHelpers;

public static class DatabaseMigrationHelper
{
    public static async Task DatabaseMigrateAsync(this IServiceProvider serviceProvider)
    {
        var context = serviceProvider.GetRequiredService<ForumDbContext>();
        
        if (context.Database.IsSqlServer())
        {
            await context.Database.MigrateAsync();
        }

        await context.SeedDatabaseAsync();
    }
}