using AutoMapper;
using KudryavtsevAlexey.Forum.Domain.CustomExceptions;
using KudryavtsevAlexey.Forum.Domain.Entities;
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

        public async Task<List<SubscriberDto>> GetUserSubscribers(int userId)
        {
            var user = await _dbContext.Users
                .Include(x=>x.Subscribers)
                .ThenInclude(x=>x.Organization)
                .FirstOrDefaultAsync(x => x.Id == userId);

            if (user is null)
            {
                throw new UserNotFoundException(userId);
            }

            var userSubscribersDtos = _mapper.Map<List<SubscriberDto>>(user.Subscribers);

            return userSubscribersDtos;
        }

        public async Task CreateSubscriber(int userId, int subscriberId)
        {
            if (userId == subscriberId)
            {
                throw new SameUserIdentifiersException(userId, subscriberId);
            }

            var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == userId);

            if (user is null)
            {
                throw new UserNotFoundException(userId);
            }

            var subscriber = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == subscriberId);

            if (subscriber is null)
            {
                throw new UserNotFoundException(subscriberId);
            }

            var createdSubscriber = _mapper.Map<Subscriber>(subscriber);

            user.Subscribers.Add(createdSubscriber);
            createdSubscriber.Users.Add(user);

            await _dbContext.Subscribers.AddAsync(createdSubscriber);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteSubscriber(int subscriberId)
        {
            var subscriber = await _dbContext.Subscribers.FirstOrDefaultAsync(x => x.Id == subscriberId);

            if (subscriber is null)
            {
                throw new SubscriberNotFoundException(subscriberId);
            }

            _dbContext.Subscribers.Remove(subscriber);
            await _dbContext.SaveChangesAsync();
        }
    }
}
