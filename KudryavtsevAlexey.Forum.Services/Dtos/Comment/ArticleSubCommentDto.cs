using KudryavtsevAlexey.Forum.Services.Dtos.Article;
using KudryavtsevAlexey.Forum.Services.Dtos.Base;
using KudryavtsevAlexey.Forum.Services.Dtos.User;
using System;

namespace KudryavtsevAlexey.Forum.Services.Dtos.Comment
{
    public record ArticleSubCommentDto(
        int Id,
        string Content,
        int UserId,
        ApplicationUserDto User,
        int ArticleId,
        ArticleDto Article,
        int ArticleMainCommentId,
        ArticleMainCommentDto ArticleMainComment,
        DateTime? CreatedAt) : BaseCommentDto(Content, UserId, CreatedAt);
}
