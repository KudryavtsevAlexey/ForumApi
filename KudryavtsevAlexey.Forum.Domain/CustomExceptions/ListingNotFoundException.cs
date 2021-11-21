using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KudryavtsevAlexey.Forum.Domain.CustomExceptions
{
    public class ListingNotFoundException : NotFoundException
    {
        public ListingNotFoundException(int id) 
            : base($"Listing with the identifier {id} was not found")
        {

        }
    }
}
