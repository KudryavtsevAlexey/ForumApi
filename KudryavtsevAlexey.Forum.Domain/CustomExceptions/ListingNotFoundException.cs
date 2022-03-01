using KudryavtsevAlexey.Forum.Domain.BaseExceptions;

namespace KudryavtsevAlexey.Forum.Domain.CustomExceptions
{
    public class ListingNotFoundException : NotFoundException
    {
        public ListingNotFoundException(int listingId) 
            : base($"Listing with the identifier {listingId} was not found")
        {

        }
    }
}
