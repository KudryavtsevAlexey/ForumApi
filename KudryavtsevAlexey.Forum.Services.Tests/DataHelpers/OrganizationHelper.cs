using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KudryavtsevAlexey.Forum.Domain.Entities;

namespace KudryavtsevAlexey.Forum.Services.Tests.DataHelpers
{
    public static class OrganizationHelper
    {
	    public static List<Organization> GetMany()
	    {
		    var listOrganizations = new List<Organization>()
		    {
				new Organization() {Name = "Organization2"},

				new Organization() {Name = "Organization3"},

				new Organization() {Name = "Organization4"},

				new Organization() {Name = "Organization5"},
		    };

			return listOrganizations;
	    }

	    public static Organization GetOne()
	    {
		    return new Organization() {Name = "Organization1"};
	    }
    }
}
