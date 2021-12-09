using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KudryavtsevAlexey.Forum.Services.Dtos.User
{
    public record SignInUserDto(
        string Email,
        string Password);
}
