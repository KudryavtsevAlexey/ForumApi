using KudryavtsevAlexey.Forum.Domain.BaseEntities;

namespace KudryavtsevAlexey.Forum.Domain.Entities.Comments
{
    public class ListingSubComment : Comment
    {
        public int ListingId { get; set; }

        public Listing Listing { get; set; }

        public int ListingMainCommentId { get; set; }

        public ListingMainComment ListingMainComment { get; set; }
    }
}
