using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KudryavtsevAlexey.Forum.Domain.BaseExceptions;

namespace KudryavtsevAlexey.Forum.Domain.CustomExceptions
{
    public class ListingMainCommentNotFoundException : NotFoundException
    {
        public ListingMainCommentNotFoundException(int? id)
            :base($"Listing main comment with identifier {id} was not found")
        {
            
        }
    }
}
