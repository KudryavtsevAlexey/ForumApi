using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KudryavtsevAlexey.Forum.Domain.Entities;
using KudryavtsevAlexey.Forum.Services.Tests.FakeEntities;

namespace KudryavtsevAlexey.Forum.Services.Tests.DataHelpers
{
    public static class UserHelper
    {
	    public static List<FakeApplicationUser> GetMany()
	    {
		    var listApplicationUsers = new List<FakeApplicationUser>()
		    {
				new FakeApplicationUser() {Name = "User2", UserName = "UserName2", Email = "UserEmail2@mail.ru", 
					Password = "UserPassword2", Location = "UserLocation2", Summary = "UserSummary2"},

				new FakeApplicationUser() {Name = "User3", UserName = "UserName3", Email = "UserEmail3@mail.ru",
					Password = "UserPassword3", Location = "UserLocation3", Summary = "UserSummary3"},

				new FakeApplicationUser() {Name = "User4", UserName = "UserName4", Email = "UserEmail4@mail.ru",
					Password = "UserPassword4", Location = "UserLocation4", Summary = "UserSummary4"},

				new FakeApplicationUser() {Name = "User4", UserName = "UserName4", Email = "UserEmail4@mail.ru",
					Password = "UserPassword4", Location = "UserLocation4", Summary = "UserSummary4"},
		    };

			return listApplicationUsers;
	    }

	    public static FakeApplicationUser GetOne()
	    {
		    return new FakeApplicationUser()
		    {
			    Name = "User1", UserName = "UserName1", Email = "UserEmail1@mail.ru",
			    Password = "UserPassword1", Location = "UserLocation1", Summary = "UserSummary1"
		    };
	    }
    }
}
