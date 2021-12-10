using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KudryavtsevAlexey.Forum.Domain.BaseExceptions;

namespace KudryavtsevAlexey.Forum.Domain.CustomExceptions
{
    public class ArticleSubCommentNotFoundException : NotFoundException
    {
        public ArticleSubCommentNotFoundException(int? id)
            :base($"Article subcomment with identifier {id} was not found")
        {
            
        }
    }
}
