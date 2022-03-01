using System.Threading.Tasks;
using KudryavtsevAlexey.Forum.Services.Dtos.Subscriber;

namespace KudryavtsevAlexey.Forum.Services.ServicesAbstractions
{
	public interface ISubscriberService
	{
		public Task<SubscriberDto> GetSubscriberById(int subscriberId);

		public Task CreateSubscriber(int userId, int subscriberId);

		public Task DeleteSubscriber(int userId, int subscriberId);
	}
}
