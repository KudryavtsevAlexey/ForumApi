using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KudryavtsevAlexey.Forum.Domain.CustomExceptions
{
    public class ArticlesCommentsNotFoundException : Exception
    {
        public ArticlesCommentsNotFoundException()
            :base("Comments to articles were not found")
        {
            
        }
    }
}
