using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KudryavtsevAlexey.Forum.Services.Dtos
{
    public record ArticleMainCommentDto(
        int Id,
        int ArticleId,
        ArticleDto ArticleDto,
        IEnumerable<ArticleSubCommentDto> SubComments);
}
