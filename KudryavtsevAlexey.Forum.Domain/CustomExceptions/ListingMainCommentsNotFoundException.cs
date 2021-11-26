using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KudryavtsevAlexey.Forum.Domain.CustomExceptions
{
    public class ListingMainCommentsNotFoundException : Exception
    {
        public ListingMainCommentsNotFoundException(int id)
            :base($"Main comments of listing with identifier {id} were not found")
        {
            
        }
    }
}
