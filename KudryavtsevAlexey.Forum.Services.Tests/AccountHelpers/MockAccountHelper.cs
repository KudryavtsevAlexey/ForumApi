using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KudryavtsevAlexey.Forum.Services.Tests.FakeEntities;
using Microsoft.AspNetCore.Identity;
using Moq;

namespace KudryavtsevAlexey.Forum.Services.Tests.AccountHelpers
{
    public static class MockAccountHelper
    {
	    public static Mock<UserManager<FakeApplicationUser>> MockUserManager()
	    {
		    var store = new Mock<IUserStore<FakeApplicationUser>>();

		    var userManager = new Mock<UserManager<FakeApplicationUser>>(store.Object, null, null, null, null, null, null, null, null);

		    userManager.Object.UserValidators.Add(new UserValidator<FakeApplicationUser>());

			userManager.Object.PasswordValidators.Add(new PasswordValidator<FakeApplicationUser>());

			return userManager;
	    }
    }
}
