using KudryavtsevAlexey.Forum.Domain.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using KudryavtsevAlexey.Forum.Domain.BaseExceptions;

namespace KudryavtsevAlexey.Forum.Domain.CustomExceptions
{
    public class ArticleMainCommentsNotFoundException : CollectionNotFoundException
    {
        public ArticleMainCommentsNotFoundException(int id)
            :base($"Main comments of article with identifier {id} were not found")
        {

        }
    }
}
