using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KudryavtsevAlexey.Forum.Services.Dtos
{
    public record ListingSubCommentDto(
        int Id,
        string Name,
        int ListingMainCommentId,
        ListingMainCommentDto ListingMainComment);
}
