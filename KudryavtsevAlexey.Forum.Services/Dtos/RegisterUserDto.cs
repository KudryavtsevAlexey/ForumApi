using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KudryavtsevAlexey.Forum.Services.Dtos
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
