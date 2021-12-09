using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KudryavtsevAlexey.Forum.Services.Dtos.Comment
{
    public record ArticleSubCommentToUpdateDto(
        string Content,
        int UserId,
        int ArticleId,
        int ArticleMainCommentId);
}
