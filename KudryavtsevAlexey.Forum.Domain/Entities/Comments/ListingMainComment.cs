using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KudryavtsevAlexey.Forum.Domain.Entities.Comments
{
    public class ListingMainComment : Comment
    {
        public int ListingId { get; set; }

        public Listing Listing { get; set; }

        public ICollection<ListingSubComment> SubComments { get; set; }
    }
}
