using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KudryavtsevAlexey.Forum.Domain.Entities;

namespace KudryavtsevAlexey.Forum.Services.Dtos
{
    public record ArticleSubCommentDto(
        int Id,
        string Name,
        DateTime CreatedAt,
        int ArticleId,
        ArticleDto Article,
        int ArticleMainCommentId,
        ArticleMainCommentDto ArticleMainComment) : BaseDto(Id);
}
