using KudryavtsevAlexey.Forum.Domain.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KudryavtsevAlexey.Forum.Services.ServicesAbstractions
{
    public interface IUserService
    {
        public Task<User> GetUserById(int id);

        public void AuthenticateUser(User user);
    }
}
