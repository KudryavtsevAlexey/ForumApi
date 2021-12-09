using System.Collections.Generic;
using KudryavtsevAlexey.Forum.Domain.Entities;
using KudryavtsevAlexey.Forum.Services.Dtos.Tag;

namespace KudryavtsevAlexey.Forum.Services.Dtos
{
    public record ArticleToUpdateDto(
        string Title,
        string ShortDescription,
        List<TagDto> Tags);
}
