using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KudryavtsevAlexey.Forum.Domain.BaseExceptions;

namespace KudryavtsevAlexey.Forum.Domain.CustomExceptions
{
    public class ArticleMainCommentNotFoundException : NotFoundException
    {
        public ArticleMainCommentNotFoundException(int articleMainCommentId)
            :base($"Article main comment with identifier {articleMainCommentId} was not found")
        {
            
        }
    }
}
