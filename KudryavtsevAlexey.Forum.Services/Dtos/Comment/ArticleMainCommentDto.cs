using KudryavtsevAlexey.Forum.Services.Dtos.Article;
using KudryavtsevAlexey.Forum.Services.Dtos.Base;
using KudryavtsevAlexey.Forum.Services.Dtos.User;
using System;
using System.Collections.Generic;

namespace KudryavtsevAlexey.Forum.Services.Dtos.Comment
{
    public record ArticleMainCommentDto(
        int Id,
        string Name,
        DateTime CreatedAt,
        int UserId,
        ApplicationUserDto User,
        int ArticleId,
        ArticleDto Article,
        List<ArticleSubCommentDto> SubComments) : BaseDto(Id);
}
