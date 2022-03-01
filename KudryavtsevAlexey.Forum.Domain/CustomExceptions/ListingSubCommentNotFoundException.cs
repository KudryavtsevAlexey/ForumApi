using KudryavtsevAlexey.Forum.Domain.BaseExceptions;

namespace KudryavtsevAlexey.Forum.Domain.CustomExceptions
{
    public class ListingSubCommentNotFoundException : NotFoundException
    {
        public ListingSubCommentNotFoundException(int listingSubCommentId)
            :base($"Listing subcomment with identifier {listingSubCommentId} was not found")
        {
            
        }
    }
}
