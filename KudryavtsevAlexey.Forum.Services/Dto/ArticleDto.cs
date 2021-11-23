using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using KudryavtsevAlexey.Forum.Domain.Entities;
using KudryavtsevAlexey.Forum.Domain.Entities.Comments;

namespace KudryavtsevAlexey.Forum.Services.Dto
{
    public record ArticleDto(int Id,
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
