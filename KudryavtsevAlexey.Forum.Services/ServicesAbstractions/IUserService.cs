using KudryavtsevAlexey.Forum.Domain.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KudryavtsevAlexey.Forum.Services.Dtos;

namespace KudryavtsevAlexey.Forum.Services.ServicesAbstractions
{
    public interface IUserService
    {
        public Task<UserDto> GetUserById(int id);

        public void AuthenticateUser(User user);

        public Task<List<SubscriberDto>> GetUserSubscribers(int id);
    }
}
