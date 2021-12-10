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
    public interface IUserService
    {
        public Task<ApplicationUserDto> GetUserById(int? id);

        public Task<List<SubscriberDto>> GetUserSubscribers(int? id);
    }
}
