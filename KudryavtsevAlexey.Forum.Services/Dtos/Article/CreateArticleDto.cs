using KudryavtsevAlexey.Forum.Services.Dtos.Tag;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KudryavtsevAlexey.Forum.Services.Dtos.Article
{
    public record CreateArticleDto(
        string Title,
        string ShortDescription,
        List<TagDto> Tags,
        int OrganizationId,
        int UserId);
}
