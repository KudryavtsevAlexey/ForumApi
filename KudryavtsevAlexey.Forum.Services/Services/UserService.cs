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
using AutoMapper;
using KudryavtsevAlexey.Forum.Services.Dtos;

namespace KudryavtsevAlexey.Forum.Services.Services
{
    internal sealed class UserService : IUserService
    {
        private readonly ForumDbContext _dbContext;
        private readonly IMapper _mapper;

        public UserService(ForumDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
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

        public async Task<UserDto> GetUserById(int id)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(x=>x.Id == id);

            if (user is null)
            {
                throw new UserNotFoundException(id);
            }

            var userDto = _mapper.Map<UserDto>(user);

            return userDto;
        }

        public async Task<List<SubscriberDto>> GetUserSubscribers(int id)
        {
            var user = await _dbContext.Users
                .Include(x=>x.Subscribers)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (user is null)
            {
                throw new UserNotFoundException(id);
            }

            var subscribers = _mapper.Map<List<SubscriberDto>>(user.Subscribers);

            return subscribers;
        }

    }
}
