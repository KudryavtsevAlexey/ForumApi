using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KudryavtsevAlexey.Forum.Services.Dtos.Base;
using KudryavtsevAlexey.Forum.Services.Dtos.Listing;
using KudryavtsevAlexey.Forum.Services.Dtos.User;

namespace KudryavtsevAlexey.Forum.Services.Dtos.Comment
{
    public record ListingMainCommentDto(
        int Id,
        string Name,
        DateTime CreatedAt,
        int UserId,
        ApplicationUserDto User,
        int ListingId,
        ListingDto Listing,
        List<ListingSubCommentDto> SubComments) : BaseDto(Id);
}
