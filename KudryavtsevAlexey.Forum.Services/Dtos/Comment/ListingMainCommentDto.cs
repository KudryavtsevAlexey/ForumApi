using KudryavtsevAlexey.Forum.Services.Dtos.Base;
using KudryavtsevAlexey.Forum.Services.Dtos.Listing;
using KudryavtsevAlexey.Forum.Services.Dtos.User;
using System;
using System.Collections.Generic;

namespace KudryavtsevAlexey.Forum.Services.Dtos.Comment
{
    public record ListingMainCommentDto(
        int Id,
        string Content,
        DateTime? CreatedAt,
        int UserId,
        ApplicationUserDto User,
        int ListingId,
        ListingDto Listing,
        List<ListingSubCommentDto> SubComments) : BaseCommentDto(Content, UserId, CreatedAt);
}
