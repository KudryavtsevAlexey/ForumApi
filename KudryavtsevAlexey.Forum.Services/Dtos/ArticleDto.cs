using System;
using System.Collections.Generic;

namespace KudryavtsevAlexey.Forum.Services.Dtos
{
    public record ArticleDto(
        int Id,
        string Title,
        string ShortDescription, 
        List<TagDto> Tags,
        int OrganizationId,
        OrganizationDto Organization,
        int UserId,
        UserDto User,
        DateTime? PublishedAt,
        List<ArticleMainCommentDto> MainComments) : BaseDto(Id);
}
