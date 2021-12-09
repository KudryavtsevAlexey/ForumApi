using System.Collections.Generic;
using KudryavtsevAlexey.Forum.Domain.Entities;
using KudryavtsevAlexey.Forum.Services.Dtos.Tag;

namespace KudryavtsevAlexey.Forum.Services.Dtos
{
    public record PutArticleDto(
            string Title,
            string ShortDescription,
            List<TagDto> Tags);
}
