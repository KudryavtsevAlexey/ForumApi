using AutoMapper;
using KudryavtsevAlexey.Forum.Domain.CustomExceptions;
using KudryavtsevAlexey.Forum.Domain.Entities;
using KudryavtsevAlexey.Forum.Infrastructure.Database;
using KudryavtsevAlexey.Forum.Services.Dtos.User;
using KudryavtsevAlexey.Forum.Services.ServicesAbstractions;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

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

        public async Task<ApplicationUserDto> GetUserById(int userId)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == userId);

            if (user is null)
            {
                throw new UserNotFoundException(userId);
            }

            var userDto = _mapper.Map<ApplicationUserDto>(user);

            return userDto;
        }

        public async Task<List<ApplicationUserDto>> GetUserSubscribers(int userId)
        {
            var user = await _dbContext.Users
                .Include(x => x.Subscribers)
                .ThenInclude(x => x.User)
                .FirstOrDefaultAsync(x=>x.Id == userId);

            if (user is null)
            {
                throw new UserNotFoundException(userId);
            }

            var userSubscribersDtos = _mapper.Map<List<ApplicationUserDto>>(user.Subscribers);

            return userSubscribersDtos;
        }

        public async Task UpdateUser(UpdateApplicationUserDto userDto)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == userDto.Id);

            if (user is null)
            {
                throw new UserNotFoundException(userDto.Id);
            }

            var concurrencyStampBeforeUpdating = user.ConcurrencyStamp;

            user = _mapper.Map<ApplicationUser>(userDto);
            user.ConcurrencyStamp = concurrencyStampBeforeUpdating;

            var local = _dbContext.Users.Local.FirstOrDefault(x => x.Id == user.Id);

            if (local is not null)
            {
	            _dbContext.Entry(local).State = EntityState.Detached;
            }

            _dbContext.Entry(user).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
    }
}
