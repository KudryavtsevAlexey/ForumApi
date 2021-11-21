using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KudryavtsevAlexey.Forum.Domain.Entities.Comments;

namespace KudryavtsevAlexey.Forum.Services.ServicesAbstractions
{
    public interface ICommentService
    {
        public List<ArticleMainComment> GetComments();

        public Task<ArticleMainComment> GetCommentById(int id);
    }
}
