using System;
using KudryavtsevAlexey.Forum.Services.Dtos.Base;

namespace KudryavtsevAlexey.Forum.Services.Dtos.Comment
{
    public record CreateListingMainCommentDto(
        string Content,
        int UserId,
        int ListingId,
        DateTime? CreatedAt) : BaseCommentDto(Content, UserId, CreatedAt);
}
