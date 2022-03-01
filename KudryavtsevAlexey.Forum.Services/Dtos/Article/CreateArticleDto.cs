using KudryavtsevAlexey.Forum.Services.Dtos.Tag;
using System.Collections.Generic;

namespace KudryavtsevAlexey.Forum.Services.Dtos.Article
{
    public record CreateArticleDto(
        string Title,
        string ShortDescription,
        List<TagDto> Tags,
        int UserId);
}
