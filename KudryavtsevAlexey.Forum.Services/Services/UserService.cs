using AutoMapper;
using KudryavtsevAlexey.Forum.Domain.CustomExceptions;
using KudryavtsevAlexey.Forum.Infrastructure.Database;
using KudryavtsevAlexey.Forum.Services.Dtos.User;
using KudryavtsevAlexey.Forum.Services.ServicesAbstractions;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        public async Task<ApplicationUserDto> GetUserById(int id)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);

            if (user is null)
            {
                throw new UserNotFoundException(id);
            }

            var userDto = _mapper.Map<ApplicationUserDto>(user);

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

            var userSubscribersDtos = _mapper.Map<List<SubscriberDto>>(user.Subscribers);

            return userSubscribersDtos;
        }
    }
}
