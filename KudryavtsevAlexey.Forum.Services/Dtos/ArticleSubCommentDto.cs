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
        int ArticleId,
        ArticleDto Article,
        int MainCommentId,
        ArticleMainCommentDto MainComment);
}
