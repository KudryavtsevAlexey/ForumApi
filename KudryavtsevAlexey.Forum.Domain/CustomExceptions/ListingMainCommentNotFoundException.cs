using KudryavtsevAlexey.Forum.Domain.BaseExceptions;

namespace KudryavtsevAlexey.Forum.Domain.CustomExceptions
{
    public class ListingMainCommentNotFoundException : NotFoundException
    {
        public ListingMainCommentNotFoundException(int listingMainCommentId)
            :base($"Listing main comment with identifier {listingMainCommentId} was not found")
        {
            
        }
    }
}
