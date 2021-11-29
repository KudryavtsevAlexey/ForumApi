using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KudryavtsevAlexey.Forum.Domain.BaseExceptions;

namespace KudryavtsevAlexey.Forum.Domain.CustomExceptions
{
    public class ArticleNotFoundException : NotFoundException
    {
        public ArticleNotFoundException(int id)
            : base($"Article with the identifier {id} was not found")
        {
        }
    }
}
