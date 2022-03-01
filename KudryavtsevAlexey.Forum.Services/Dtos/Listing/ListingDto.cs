using System;
using System.Collections.Generic;
using KudryavtsevAlexey.Forum.Services.Dtos.Base;
using KudryavtsevAlexey.Forum.Services.Dtos.Comment;
using KudryavtsevAlexey.Forum.Services.Dtos.Tag;
using KudryavtsevAlexey.Forum.Services.Dtos.User;

namespace KudryavtsevAlexey.Forum.Services.Dtos.Listing
{
    public record ListingDto(
        int Id,
        string Title,
        string ShortDescription,
        string Category,
        List<TagDto> Tags,
        int UserId,
        ApplicationUserDto User,
        DateTime? PublishedAt,
        List<ListingMainCommentDto> MainComments) : BaseDto(Id);
}
