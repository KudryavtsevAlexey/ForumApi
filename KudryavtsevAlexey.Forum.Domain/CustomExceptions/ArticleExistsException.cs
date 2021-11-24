using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KudryavtsevAlexey.Forum.Domain.CustomExceptions
{
    public class ArticleExistsException : Exception
    {
        public ArticleExistsException(int id)
            :base($"Article with identifier {id} already exists in database")
        {
            
        }
    }
}
