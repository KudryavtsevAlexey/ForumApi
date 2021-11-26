using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KudryavtsevAlexey.Forum.Domain.CustomExceptions
{
    public class ListingSubCommentNotFoundException : NotFoundException
    {
        public ListingSubCommentNotFoundException(int id)
            :base($"Listing subcomment with identifier {id} was not found")
        {
            
        }
    }
}
