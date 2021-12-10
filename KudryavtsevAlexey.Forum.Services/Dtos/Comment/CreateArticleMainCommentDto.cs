using System;
using KudryavtsevAlexey.Forum.Services.Dtos.Base;
using KudryavtsevAlexey.Forum.Services.Dtos.User;

namespace KudryavtsevAlexey.Forum.Services.Dtos.Comment
{
    public record CreateArticleMainCommentDto(
        string Content,
        int UserId,
        int ArticleId,
        DateTime? CreatedAt) : BaseCommentDto(Content, UserId, CreatedAt);
}
