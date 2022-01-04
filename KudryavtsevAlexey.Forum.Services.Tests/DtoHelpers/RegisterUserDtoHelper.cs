using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KudryavtsevAlexey.Forum.Services.Dtos.User;

namespace KudryavtsevAlexey.Forum.Services.Tests.DtoHelpers
{
    public static class RegisterUserDtoHelper
    {
	    public static RegisterUserDto CreateValidRegisterUserDto()
	    {
		    return new RegisterUserDto(Email: "SampleUserEmail1@gmail.ru", Name: "SampleName1",
			    UserName: "SampleUserName1", Location: "SampleUserLocation1", Password: "SampleUserPassword1",
			    ConfirmedPassword: "SampleUserPassword1", OrganizationName: "Organization1");
	    }

	    public static RegisterUserDto CreateInvalidRegisterUserDto()
	    {
		    return new RegisterUserDto(Email: "SampleUserEmail1@gmail.ru", Name: "SampleName1",
			    UserName: "SampleUserName1", Location: "SampleUserLocation1", Password: "SampleUserPassword1",
			    ConfirmedPassword: "SampleUserPassword1", OrganizationName: "InvalidOrganizationName");
	    }
	}
}
