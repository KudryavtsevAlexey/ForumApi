using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KudryavtsevAlexey.Forum.Domain.Entities;
using KudryavtsevAlexey.Forum.Services.Dtos.Base;
using KudryavtsevAlexey.Forum.Services.Dtos.Comment;
using KudryavtsevAlexey.Forum.Services.Dtos.Listing;
using KudryavtsevAlexey.Forum.Services.Dtos.User;

namespace KudryavtsevAlexey.Forum.Services.Dtos
{
    public record ListingSubCommentDto(
        int Id,
        string Name,
        DateTime CreatedAt,
        int UserId,
        ApplicationUserDto User,
        int ListingId,
        ListingDto Listing,
        int ListingMainCommentId,
        ListingMainCommentDto ListingMainComment) : BaseDto(Id);
}
