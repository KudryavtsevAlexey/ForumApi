using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KudryavtsevAlexey.Forum.Domain.Entities;

namespace KudryavtsevAlexey.Forum.Services.ServicesAbstractions
{
    public interface IOrganizationService
    {
        public Task<Organization> GetOrganizationByName(string organizationName);

        public List<User> GetOrganizationUsers(string organizationName);

        public List<Listing> GetOrganizationListings(string organizationName);

        public List<Article> GetOrganizationArticles(string organizationName);
    }
}
