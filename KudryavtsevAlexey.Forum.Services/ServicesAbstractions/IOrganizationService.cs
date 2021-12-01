using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KudryavtsevAlexey.Forum.Domain.Entities;
using KudryavtsevAlexey.Forum.Services.Dtos;

namespace KudryavtsevAlexey.Forum.Services.ServicesAbstractions
{
    public interface IOrganizationService
    {
        public Task<OrganizationDto> GetOrganizationByName(string organizationName);

        public Task<List<UserDto>> GetOrganizationUsers(string organizationName);

        public Task<List<ListingDto>> GetOrganizationListings(string organizationName);

        public Task<List<ArticleDto>> GetOrganizationArticles(string organizationName);
    }
}
