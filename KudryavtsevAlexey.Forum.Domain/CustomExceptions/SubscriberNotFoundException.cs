using KudryavtsevAlexey.Forum.Domain.BaseExceptions;

namespace KudryavtsevAlexey.Forum.Domain.CustomExceptions
{
    public class SubscriberNotFoundException : NotFoundException
    {
        public SubscriberNotFoundException(int subscriberId)
            : base($"Subscriber with the identifier {subscriberId} was not found")
        {

        }
    }
}
