using System;
using KudryavtsevAlexey.Forum.Services.Dtos.Base;
using KudryavtsevAlexey.Forum.Services.Dtos.User;

namespace KudryavtsevAlexey.Forum.Services.Dtos.Comment
{
    public record ArticleMainCommentToCreateDto(
        string Content,
        int UserId,
        int ArticleId,
        DateTime? CreatedAt) : BaseCommentDto(Content, UserId, CreatedAt);
}
