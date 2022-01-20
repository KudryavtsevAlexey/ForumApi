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
using KudryavtsevAlexey.Forum.Domain.Entities.Comments;
using System.Linq;

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

        public async Task<List<ApplicationUserDto>> GetOrganizationUsers(string organizationName)
        {
            var organization = await _dbContext.Organizations
                .Include(x => x.Users)
                .ThenInclude(x => x.Organization)
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

        public async Task UpdateOrganization(UpdateOrganizationDto organizationDto)
        {
            var organization = await _dbContext.Organizations.FirstOrDefaultAsync(x => x.Id == organizationDto.Id);

            if (organization is null)
            {
                throw new OrganizationNotFoundException(organizationDto.Id);
            }

            organization = _mapper.Map<Organization>(organizationDto);

            var local = _dbContext.Organizations.Local.FirstOrDefault(x => x.Id == organization.Id);

            if (!(local is null))
            {
	            _dbContext.Entry(local).State = EntityState.Detached;
            }

            _dbContext.Entry(organization).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteOrganization(int organizationId)
        {
            var organization = await _dbContext.Organizations.FirstOrDefaultAsync(x => x.Id == organizationId);

            if (organization is null)
            {
                throw new OrganizationNotFoundException(organizationId);
            }

            _dbContext.Organizations.Remove(organization);
            await _dbContext.SaveChangesAsync();
        }
    }
}
