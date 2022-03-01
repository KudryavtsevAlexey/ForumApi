using System.Threading.Tasks;
using KudryavtsevAlexey.Forum.Services.Dtos.User;

namespace KudryavtsevAlexey.Forum.Services.ServicesAbstractions
{
    public interface IAccountService
    {
        public Task Register(RegisterUserDto userDto);

        public Task<string> SignIn(SignInUserDto userDto);

        public Task SignOut();

        public Task DeleteUser(int userId);
    }
}
