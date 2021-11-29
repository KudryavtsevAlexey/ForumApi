using KudryavtsevAlexey.Forum.Domain.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KudryavtsevAlexey.Forum.Domain.BaseExceptions;

namespace KudryavtsevAlexey.Forum.Domain.CustomExceptions
{
    public class ListingsCommentsNotFoundException : CollectionNotFoundException
    {
        public ListingsCommentsNotFoundException()
            :base("Comments to listing were not found")
        {
            
        }
    }
}
