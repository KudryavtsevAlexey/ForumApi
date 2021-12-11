using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KudryavtsevAlexey.Forum.Domain.BaseExceptions;

namespace KudryavtsevAlexey.Forum.Domain.CustomExceptions
{
    public class ListingNotFoundException : NotFoundException
    {
        public ListingNotFoundException(int listingId) 
            : base($"Listing with the identifier {listingId} was not found")
        {

        }
    }
}
