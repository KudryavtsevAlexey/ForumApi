using System.Collections.Generic;
using KudryavtsevAlexey.Forum.Domain.Entities;

namespace KudryavtsevAlexey.Forum.Services.Dtos
{
    public record PutArticleDto(
            int Id,
            string Title,
            string ShortDescription,
            List<Tag> Tags);
}
