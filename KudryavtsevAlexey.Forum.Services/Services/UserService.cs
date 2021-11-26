using KudryavtsevAlexey.Forum.Domain.CustomExceptions;
using KudryavtsevAlexey.Forum.Domain.Entities;
using KudryavtsevAlexey.Forum.Infrastructure.Database;
using KudryavtsevAlexey.Forum.Services.ServicesAbstractions;

using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualBasic;

using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace KudryavtsevAlexey.Forum.Services.Services
{
    internal sealed class UserService : IUserService
    {
        private readonly ForumDbContext _dbContext;

        public UserService(ForumDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AuthenticateUser(User user)
        {
            //var claims = new List<Claim>()
            //{
            //    new Claim(JwtRegisteredClaimNames.Sub, user.Name)
            //};

            //byte[] bytes = Encoding.UTF8.GetBytes(Constants.SecretKey);

            //var key = new SymmetricSecurityKey(bytes);

            //var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            //var token = new JwtSecurityToken(Constants.Issuer,
            //    Constants.Audience,
            //    claims,
            //    notBefore:
            //    DateTime.Now,
            //    DateTime.Now.AddMinutes(60),
            //    signingCredentials);

            //var tokenValue = new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<User> GetUserById(int id)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(x=>x.Id == id);

            if (user == null)
            {
                throw new UserNotFoundException(id);
            }

            return user;
        }
    }
}
