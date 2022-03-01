using KudryavtsevAlexey.Forum.Domain.BaseExceptions;

namespace KudryavtsevAlexey.Forum.Domain.CustomExceptions
{
    public class TagNotFoundException : NotFoundException
    {
        public TagNotFoundException(int tagId)
            :base($"$Tag with the identifier {tagId} was not found")
        {
            
        }
    }
}
