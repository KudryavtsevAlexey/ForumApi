using System.Threading.Tasks;
using AutoMapper;
using KudryavtsevAlexey.Forum.Domain.CustomExceptions;
using KudryavtsevAlexey.Forum.Domain.Entities;
using KudryavtsevAlexey.Forum.Infrastructure.Database;
using KudryavtsevAlexey.Forum.Services.Dtos.Subscriber;
using KudryavtsevAlexey.Forum.Services.ServicesAbstractions;
using Microsoft.EntityFrameworkCore;

namespace KudryavtsevAlexey.Forum.Services.Services
{
	public class SubscriberService : ISubscriberService
	{
		private readonly ForumDbContext _dbContext;
		private readonly IMapper _mapper;

		public SubscriberService(ForumDbContext dbContext, IMapper mapper)
		{
			_dbContext = dbContext;
			_mapper = mapper;
		}

		public async Task<SubscriberDto> GetSubscriberById(int subscriberId)
		{
			var subscriber = await _dbContext.Subscribers
				.FirstOrDefaultAsync(x => x.Id == subscriberId);

			if (subscriber is null)
			{
				throw new SubscriberNotFoundException(subscriberId);
			}

			var subscriberDto = _mapper.Map<SubscriberDto>(subscriber);

			return subscriberDto;
		}

		public async Task CreateSubscriber(FindUserToSubscribeDto findUserToSubscribeDto)
		{
			if (findUserToSubscribeDto.UserId == findUserToSubscribeDto.SubscriberId)
			{
				throw new SameUserIdentifiersException(findUserToSubscribeDto.UserId, findUserToSubscribeDto.SubscriberId);
			}

			var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == findUserToSubscribeDto.UserId);

			if (user is null)
			{
				throw new UserNotFoundException(findUserToSubscribeDto.UserId);
			}

			var subscriber = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == findUserToSubscribeDto.SubscriberId);

			if (subscriber is null)
			{
				throw new UserNotFoundException(findUserToSubscribeDto.SubscriberId);
			}

			var newSubscriber = _mapper.Map<Subscriber>(subscriber);
			var newSubscription = _mapper.Map<Subscription>(user);

			newSubscriber.UserId = subscriber.Id;
			newSubscriber.User = subscriber;
			newSubscriber.User.Subscriptions.Add(newSubscription);

			newSubscription.UserId = user.Id;
			newSubscription.User = user;
			newSubscription.User.Subscribers.Add(newSubscriber);

			await _dbContext.Subscribers.AddAsync(newSubscriber); 
			await _dbContext.Subscriptions.AddAsync(newSubscription);
			await _dbContext.SaveChangesAsync();
		}

		public async Task DeleteSubscriber(int userId, int subscriberId)
		{
			var user = await _dbContext.Users
				.Include(x => x.Subscribers)
				.FirstOrDefaultAsync(x => x.Id == userId);

			if (user is null)
			{
				throw new UserNotFoundException(userId);
			}

			var subscriber = await _dbContext.Subscribers.FirstOrDefaultAsync(x => x.Id == subscriberId);

			if (subscriber is null)
			{
				throw new SubscriberNotFoundException(subscriberId);
			}

			var subscription = await _dbContext.Subscriptions.FirstOrDefaultAsync(x => x.UserId == userId);

			_dbContext.Subscribers.Remove(subscriber);
			_dbContext.Subscriptions.Remove(subscription);

			await _dbContext.SaveChangesAsync();
		}
	}
}
