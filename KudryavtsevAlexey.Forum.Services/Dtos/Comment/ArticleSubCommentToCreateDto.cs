using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KudryavtsevAlexey.Forum.Services.Dtos.Base;
using KudryavtsevAlexey.Forum.Services.Dtos.User;

namespace KudryavtsevAlexey.Forum.Services.Dtos.Comment
{
    public record ArticleSubCommentToCreateDto(
        string Content,
        int UserId,
        int ArticleId,
        int ArticleMainCommentId,
        DateTime? CreatedAt) : BaseCommentDto(Content, UserId, CreatedAt);
}
