using KudryavtsevAlexey.Forum.Services.Dtos.User;

namespace KudryavtsevAlexey.Forum.Services.Tests.DtoHelpers
{
	public static class UserDtoHelper
    {
	    public static SignInUserDto Create()
	    {
		    return new SignInUserDto(Email: "UserEmail1", Password: "UserPassword1");
	    }
    }
}
