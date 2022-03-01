using System.Collections.Generic;
using KudryavtsevAlexey.Forum.Services.Dtos.Base;
using KudryavtsevAlexey.Forum.Services.Dtos.User;

namespace KudryavtsevAlexey.Forum.Services.Dtos.Organization
{
    public record OrganizationDto(
        int Id,
        string Name,
        List<ApplicationUserDto> Users) : BaseDto(Id);
}
