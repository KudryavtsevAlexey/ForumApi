using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KudryavtsevAlexey.Forum.Domain.Entities;
using KudryavtsevAlexey.Forum.Services.Dtos.Article;
using KudryavtsevAlexey.Forum.Services.Dtos.Base;
using KudryavtsevAlexey.Forum.Services.Dtos.User;

namespace KudryavtsevAlexey.Forum.Services.Dtos.Comment
{
    public record ArticleSubCommentDto(
        int Id,
        string Name,
        DateTime CreatedAt,
        int UserId,
        ApplicationUserDto User,
        int ArticleId,
        ArticleDto Article,
        int ArticleMainCommentId,
        ArticleMainCommentDto ArticleMainComment) : BaseDto(Id);
}
