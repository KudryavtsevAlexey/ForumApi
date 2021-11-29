using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KudryavtsevAlexey.Forum.Domain.BaseExceptions;

namespace KudryavtsevAlexey.Forum.Domain.CustomExceptions
{
    public class OrganizationNotFoundException : NotFoundException
    {
        public OrganizationNotFoundException(string organizationName)
            : base($"Organization with the name {organizationName} was not found")
        {

        }
    }
}
