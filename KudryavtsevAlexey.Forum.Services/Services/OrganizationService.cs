using AutoMapper;
using KudryavtsevAlexey.Forum.Domain.CustomExceptions;
using KudryavtsevAlexey.Forum.Infrastructure.Database;
using KudryavtsevAlexey.Forum.Services.Dtos.Article;
using KudryavtsevAlexey.Forum.Services.Dtos.Listing;
using KudryavtsevAlexey.Forum.Services.Dtos.Organization;
using KudryavtsevAlexey.Forum.Services.Dtos.User;
using KudryavtsevAlexey.Forum.Services.ServicesAbstractions;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using KudryavtsevAlexey.Forum.Domain.Entities;

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

        public async Task<List<ApplicationUserDto>> GetOrganizationUsers(string organizationName)
        {
            var organization = await _dbContext.Organizations
                .Include(x => x.Users)
                .FirstOrDefaultAsync(x => x.Name.ToLower() == organizationName.ToLower());

            if (organization is null)
            {
                throw new OrganizationNotFoundException(organizationName);
            }

            var organizationUsersDtos = _mapper.Map<List<ApplicationUserDto>>(organization.Users);

            return organizationUsersDtos;
        }

        public async Task CreateOrganization(CreateOrganizationDto organizationDto)
        {
            var organization = _mapper.Map<Organization>(organizationDto);

            await _dbContext.Organizations.AddAsync(organization);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateOrganization(int id, UpdateOrganizationDto organizationDto)
        {
            var organization = await _dbContext.Organizations.FirstOrDefaultAsync(x => x.Id == id);

            if (organization is null)
            {
                throw new OrganizationNotFoundException(id);
            }

            organization.Name = organizationDto.Name;

            _dbContext.Organizations.Update(organization);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteOrganization(int id)
        {
            var organization = await _dbContext.Organizations.FirstOrDefaultAsync(x => x.Id == id);

            if (organization is null)
            {
                throw new OrganizationNotFoundException(id);
            }

            _dbContext.Organizations.Remove(organization);
            await _dbContext.SaveChangesAsync();
        }
    }
}
