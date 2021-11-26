using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KudryavtsevAlexey.Forum.Domain.CustomExceptions
{
    public class ListingsCommentsNotFoundException : Exception
    {
        public ListingsCommentsNotFoundException()
            :base("Comments to listing were not found")
        {
            
        }
    }
}
