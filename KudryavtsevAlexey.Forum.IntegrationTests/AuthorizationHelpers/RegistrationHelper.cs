using KudryavtsevAlexey.Forum.Services.Dtos.User;

namespace KudryavtsevAlexey.Forum.IntegrationTests.AuthorizationHelpers
{
	public static class RegistrationHelper
	{
		public static RegisterUserDto CreateRegisterUserDto()
		{
			var registerUserDto = new RegisterUserDto(Email: "RegistrationEmail1@test.com", Password: "RegistrationPassword1",
				ConfirmedPassword: "RegistrationPassword1", Name: "RegistrationName1",
				OrganizationName: "Organization1", Location: "RegistrationLocation1",
				UserName: "RegistrationUserName1");

			return registerUserDto;
		}
	}
}
