using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
