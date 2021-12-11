using KudryavtsevAlexey.Forum.Domain.BaseExceptions;

namespace KudryavtsevAlexey.Forum.Domain.CustomExceptions
{
    public class SameUserIdentifiersException : SameIdentifiersException
    {
        public SameUserIdentifiersException(int userId, int subscriberId)
            : base($"User can't subscribe to himself (identifiers: {userId})")
        {

        }
    }
}
