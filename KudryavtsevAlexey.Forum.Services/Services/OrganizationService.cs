using KudryavtsevAlexey.Forum.Domain.CustomExceptions;
using KudryavtsevAlexey.Forum.Domain.Entities;
using KudryavtsevAlexey.Forum.Infrastructure.Database;
using KudryavtsevAlexey.Forum.Services.ServicesAbstractions;

using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KudryavtsevAlexey.Forum.Services.Services
{
    internal sealed class OrganizationService : IOrganizationService
    {
        private readonly ForumDbContext _dbContext;

        public OrganizationService(ForumDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Organization> GetOrganizationByName(string organizationName)
        {
            var organization = await _dbContext.Organizations.FirstOrDefaultAsync(o => o.Name == organizationName);

            if (organization is null)
            {
                throw new OrganizationNotFoundException(organizationName);
            }

            return organization;
        }

        public List<Article> GetOrganizationArticles(string organizationName)
        {
            return GetOrganizationByName(organizationName).Result.Articles.ToList();
        }

        public List<Listing> GetOrganizationListings(string organizationName)
        {
            return GetOrganizationByName(organizationName).Result.Listings.ToList();
        }

        public List<User> GetOrganizationUsers(string organizationName)
        {
            return GetOrganizationByName(organizationName).Result.Users.ToList();
        }
    }
}
