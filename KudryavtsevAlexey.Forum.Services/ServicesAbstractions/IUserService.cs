using System.Collections.Generic;
using System.Threading.Tasks;
using KudryavtsevAlexey.Forum.Services.Dtos.User;

namespace KudryavtsevAlexey.Forum.Services.ServicesAbstractions
{
    public interface IUserService
    {
        public Task<ApplicationUserDto> GetUserById(int userId);

        public Task<List<ApplicationUserDto>> GetUserSubscribers(int userId);

        public Task UpdateUser(UpdateApplicationUserDto userDto);
    }
}
