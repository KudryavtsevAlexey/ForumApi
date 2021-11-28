using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KudryavtsevAlexey.Forum.Domain.Entities;

namespace KudryavtsevAlexey.Forum.Services.Dtos
{
    public record ListingSubCommentDto(
        int Id,
        string Name,
        DateTime CreatedAt,
        int ListingId,
        ListingDto Listing,
        int ListingMainCommentId,
        ListingMainCommentDto ListingMainComment) : BaseDto(Id);
}
