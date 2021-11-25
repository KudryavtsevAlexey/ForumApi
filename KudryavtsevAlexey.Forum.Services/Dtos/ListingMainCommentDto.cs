using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KudryavtsevAlexey.Forum.Services.Dtos
{
    public record ListingMainCommentDto(
        int Id,
        int ListingId,
        ListingDto Listing,
        IEnumerable<ListingSubCommentDto> SubComments);
}
