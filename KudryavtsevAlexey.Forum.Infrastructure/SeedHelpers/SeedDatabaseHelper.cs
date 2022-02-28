using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KudryavtsevAlexey.Forum.Domain.Entities;
using KudryavtsevAlexey.Forum.Infrastructure.Database;

namespace KudryavtsevAlexey.Forum.Infrastructure.SeedHelpers;

public static class SeedDatabaseHelper
{
    public static async Task SeedDatabaseAsync(this ForumDbContext dbContext)
    {
        if (!dbContext.Organizations.Any())
        {
            var organizations = new List<Organization>
            {
                new() {Name = "OrganizationName1"},
                new() {Name = "OrganizationName2"},
                new() {Name = "OrganizationName3"},
                new() {Name = "OrganizationName4"},
                new() {Name = "OrganizationName5"}
            };

            await dbContext.Organizations.AddRangeAsync(organizations);
            await dbContext.SaveChangesAsync();
        }
    }
}