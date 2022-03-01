using KudryavtsevAlexey.Forum.Services.Dtos.Base;

namespace KudryavtsevAlexey.Forum.Services.Dtos.User
{
    public record UpdateApplicationUserDto(
        int Id,
        string Name,
        string UserName,
        string Summary,
        string Location) : BaseDto(Id);
}
