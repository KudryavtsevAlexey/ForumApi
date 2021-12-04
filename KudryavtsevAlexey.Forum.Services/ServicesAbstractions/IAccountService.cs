using KudryavtsevAlexey.Forum.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KudryavtsevAlexey.Forum.Services.Dtos;

namespace KudryavtsevAlexey.Forum.Services.ServicesAbstractions
{
    public interface IAccountService
    {
        public Task<string> Register(RegisterUserDto userDto);

        public Task<string> SignIn(SignInUserDto userDto);
    }
}
