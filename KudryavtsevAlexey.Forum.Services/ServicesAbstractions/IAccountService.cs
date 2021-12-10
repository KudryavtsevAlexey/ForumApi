using KudryavtsevAlexey.Forum.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KudryavtsevAlexey.Forum.Services.Dtos;
using KudryavtsevAlexey.Forum.Services.Dtos.User;

namespace KudryavtsevAlexey.Forum.Services.ServicesAbstractions
{
    public interface IAccountService
    {
        public Task Register(RegisterUserDto userDto);

        public Task<string> SignIn(SignInUserDto userDto);

        public Task SignOut();

        public Task DeleteUser(int id);
    }
}
