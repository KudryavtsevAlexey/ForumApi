namespace KudryavtsevAlexey.Forum.Services.Dtos.User
{
    public record RegisterUserDto(
        string UserName,
        string Name,
        string Location,
        string Email,
        string Password,
        string ConfirmedPassword,
        string OrganizationName);
}
