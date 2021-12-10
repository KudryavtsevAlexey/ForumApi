using KudryavtsevAlexey.Forum.Services.Dtos.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KudryavtsevAlexey.Forum.Services.Dtos.User;

namespace KudryavtsevAlexey.Forum.Services.Dtos.Comment
{
    public record UpdateArticleMainCommentDto(
        string Content);
}
