using System;
using System.Collections.Generic;

namespace KudryavtsevAlexey.Forum.Services.Dtos
{
    public record ArticleDto(
        int Id,
        string Title,
        string ShortDescription,
        IEnumerable<TagFieldsDto> Tags,
        int OrganizationId,
        OrganizationDto Organization,
        int UserId,
        UserDto User,
        DateTime? PublishedAt,
        IEnumerable<ArticleMainCommentDto> MainComments);
}
