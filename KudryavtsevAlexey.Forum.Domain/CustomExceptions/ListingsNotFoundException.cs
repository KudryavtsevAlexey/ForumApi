using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KudryavtsevAlexey.Forum.Domain.BaseEntities;
using KudryavtsevAlexey.Forum.Domain.BaseExceptions;

namespace KudryavtsevAlexey.Forum.Domain.CustomExceptions
{
    public class ListingsNotFoundException : CollectionNotFoundException
    {
        public ListingsNotFoundException() : base("Listings were not found")
        {
            
        }
    }
}
