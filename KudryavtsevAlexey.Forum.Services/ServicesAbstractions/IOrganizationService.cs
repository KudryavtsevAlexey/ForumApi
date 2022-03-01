using System.Collections.Generic;
using System.Threading.Tasks;
using KudryavtsevAlexey.Forum.Services.Dtos.Organization;
using KudryavtsevAlexey.Forum.Services.Dtos.User;

namespace KudryavtsevAlexey.Forum.Services.ServicesAbstractions
{
    public interface IOrganizationService
    {
        public Task<OrganizationDto> GetOrganizationById(int d);

        public Task<List<ApplicationUserDto>> GetOrganizationUsers(int id);

        public Task CreateOrganization(CreateOrganizationDto organizationDto);

        public Task UpdateOrganization(UpdateOrganizationDto organizationDto);

        public Task DeleteOrganization(int organizationId);
    }
}
