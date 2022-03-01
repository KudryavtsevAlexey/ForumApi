using KudryavtsevAlexey.Forum.Domain.BaseExceptions;

namespace KudryavtsevAlexey.Forum.Domain.CustomExceptions
{
    public class OrganizationNotFoundException : NotFoundException
    {
        public OrganizationNotFoundException(string organizationName)
            : base($"Organization with the name {organizationName} was not found")
        {

        }

        public OrganizationNotFoundException(int organizationId)
            :base($"Organization with the identifier {organizationId} was not found")
        {
            
        }
    }
}
