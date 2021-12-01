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
using AutoMapper;
using KudryavtsevAlexey.Forum.Services.Dtos;

namespace KudryavtsevAlexey.Forum.Services.Services
{
    internal sealed class OrganizationService : IOrganizationService
    {
        private readonly ForumDbContext _dbContext;
        private readonly IMapper _mapper;

        public OrganizationService(ForumDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<OrganizationDto> GetOrganizationByName(string organizationName)
        {
            var organization = await _dbContext.Organizations
                .FirstOrDefaultAsync(x => x.Name.ToLower() == organizationName.ToLower());

            if (organization is null)
            {
                throw new OrganizationNotFoundException(organizationName);
            }

            var organizationDto = _mapper.Map<OrganizationDto>(organization);

            return organizationDto;
        }

        public async Task<List<ArticleDto>> GetOrganizationArticles(string organizationName)
        {
            var organization = await _dbContext.Organizations
                .Include(x => x.Articles)
                .FirstOrDefaultAsync(x => x.Name.ToLower() == organizationName.ToLower());

            if (organization is null)
            {
                throw new OrganizationNotFoundException(organizationName);
            }

            var organizationArticlesDtos = _mapper.Map<List<ArticleDto>>(organization.Articles);

            return organizationArticlesDtos;
        }

        public async Task<List<ListingDto>> GetOrganizationListings(string organizationName)
        {
            var organization = await _dbContext.Organizations
                .Include(x => x.Listings)
                .FirstOrDefaultAsync(x => x.Name.ToLower() == organizationName.ToLower());

            if (organization is null)
            {
                throw new OrganizationNotFoundException(organizationName);
            }

            var organizationListingsDtos = _mapper.Map<List<ListingDto>>(organization.Listings);

            return organizationListingsDtos;
        }

        public async Task<List<UserDto>> GetOrganizationUsers(string organizationName)
        {
            var organization = await _dbContext.Organizations
                .Include(x => x.Users)
                .FirstOrDefaultAsync(x => x.Name.ToLower() == organizationName.ToLower());

            if (organization is null)
            {
                throw new OrganizationNotFoundException(organizationName);
            }

            var organizationUsersDtos = _mapper.Map<List<UserDto>>(organization.Users);

            return organizationUsersDtos;
        }
    }
}
