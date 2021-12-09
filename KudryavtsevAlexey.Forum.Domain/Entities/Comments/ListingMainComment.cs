using KudryavtsevAlexey.Forum.Domain.BaseEntities;
using System.Collections.Generic;

namespace KudryavtsevAlexey.Forum.Domain.Entities.Comments
{
    public class ListingMainComment : Comment
    {
        public int ListingId { get; set; }

        public Listing Listing { get; set; }

        public ICollection<ListingSubComment> SubComments { get; set; }

        public ListingMainComment()
        {
            SubComments = new List<ListingSubComment>();
        }
    }
}
