using System;
using KudryavtsevAlexey.Forum.Services.Dtos.Base;

namespace KudryavtsevAlexey.Forum.Services.Dtos.Comment
{
    public record CreateArticleSubCommentDto(
        string Content,
        int UserId,
        int ArticleId,
        int ArticleMainCommentId,
        DateTime? CreatedAt) : BaseCommentDto(Content, UserId, CreatedAt);
}
