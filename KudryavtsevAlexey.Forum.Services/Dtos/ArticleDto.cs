using KudryavtsevAlexey.Forum.Domain.Entities;
using KudryavtsevAlexey.Forum.Domain.Entities.Comments;

using System;
using System.Collections.Generic;

namespace KudryavtsevAlexey.Forum.Services.Dtos
{
    public record ArticleDto(
        int Id,
        string Title,
        string ShortDescription,
        List<Tag> Tags,
        int OrganizationId,
        Organization Organization,
        int UserId,
        User User,
        DateTime PublishedAt,
        List<ArticleMainComment> MainComments);
}
